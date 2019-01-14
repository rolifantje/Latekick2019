using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using SevenZip;

namespace Latekick.Forms
{
    public class Utility
    {
        //public static void UnpackArchive(string archiveFile, string unzipdirectory)
        //{
        //    string UnpackLocation = unzipdirectory;

        //    SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
        //    SevenZipExtractor ex = new SevenZipExtractor(archiveFile);

        //    ex.ExtractArchive(unzipdirectory);
        //}

        public static void SendFeedbackMessage(ListView lvFeedback, string message)
        {
            ListViewItem messageItem = new ListViewItem();
            ListViewItem.ListViewSubItem timeColumn = new ListViewItem.ListViewSubItem(messageItem, DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture));
            ListViewItem.ListViewSubItem messageColumn = new ListViewItem.ListViewSubItem(messageItem, message);

            messageItem.SubItems.Add(timeColumn);
            messageItem.SubItems.Add(messageColumn);

            lvFeedback.Items.Add(messageItem);
            int index = lvFeedback.Items.IndexOf(messageItem);
            lvFeedback.EnsureVisible(index);
            Application.DoEvents();
        }

        public static string GetCurrencySymbol(string currencycode)
        {
            switch (Program.ThisUser.Currency)
            {
                case "EUR":
                    return "€";
                case "GBP":
                    return "£";
                case "USD":
                    return "$";
                default:
                    return "$";
            }
        }

        public static void ProcessBRISFile(DateTime dRaceDate, string coursecode_bris, string coursecode, ListView lvFeedback)
        {
            if (Program.ThisUser.Balance >= 1)
            {
                try
                {
                    string BalanceMessage = "";
                    Latekick.BLL.AccountManagement.User.PurchaseOne(Program.ThisUser, out BalanceMessage);

                    Utility.SendFeedbackMessage(lvFeedback, "Unzipping the BRIS archive.");

                    DirectoryInfo diBRIS = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\BRIS\\" + dRaceDate.ToString("ddMMMyyyy"));
                    DirectoryInfo diLatekick = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Latekick\\" + dRaceDate.ToString("ddMMMyyyy"));
                    DirectoryInfo diUnzip = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Unzip");

                    //Latekick.Forms.Utility.UnpackArchive(Application.StartupPath + "\\BRIS\\" + dRaceDate.ToString("ddMMMyyyy") + "\\" + coursecode + ".zip", Application.StartupPath + "\\Unzip");
                    Latekick.Forms.Utility.UnpackArchive(diBRIS.FullName + "\\" + coursecode + ".zip", diUnzip.FullName);

                    Utility.SendFeedbackMessage(lvFeedback, "Loading the BRIS files into memory.");
                    List<Latekick.BOL.Brisnet.Bris_Race> brisraces = Latekick.BLL.Parsing.Brisnet.ParseRaces(diUnzip.FullName + "\\" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + ".DRF");
                    List<Latekick.BOL.Brisnet.Bris_Entry> brishorses = Latekick.BLL.Parsing.Brisnet.ParseHorses(diUnzip.FullName + "\\" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + ".DR2");
                    List<Latekick.BOL.Brisnet.Bris_PastPerformance> brispps = Latekick.BLL.Parsing.Brisnet.ParsePPs(diUnzip.FullName + "\\" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + ".DR3");
                    List<Latekick.BOL.Brisnet.Bris_Stats> brisstats = Latekick.BLL.Parsing.Brisnet.ParseStats(diUnzip.FullName + "\\" + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + ".DR4");

                    Array.ForEach(Directory.GetFiles(diUnzip.FullName), delegate(string path) { File.Delete(path); });

                    Utility.SendFeedbackMessage(lvFeedback, "Converting BRIS data to Latekick (this step takes about 20 seconds).");
                    Latekick.BLL.Conversion.Brisnet2Latekick b2l = new Latekick.BLL.Conversion.Brisnet2Latekick();
                    b2l.ConvertRaces(brisraces);
                    b2l.ConvertHorses(brishorses);
                    b2l.ConvertPastPerformances(brispps);
                    b2l.ConvertStats(brisstats);

                    Latekick.BLL.Conversion.LatekickExtras lkextra = new Latekick.BLL.Conversion.LatekickExtras();
                    lkextra.LatekickCard = b2l.LK;
                    lkextra.UpdateRaces();
                    lkextra.UpdateProjectedRatings();
                    lkextra.UpdatePastPerformances();
                    lkextra.UpdateWorkouts();

                    Utility.SendFeedbackMessage(lvFeedback, "Storing the converted data.");

                    string retVal = string.Empty;
                    TextWriter writer = new StringWriter();
                    XmlSerializer serializer = new XmlSerializer(lkextra.LatekickCard.GetType());
                    serializer.Serialize(writer, lkextra.LatekickCard);
                    retVal = writer.ToString();


                    if (!diLatekick.Exists)
                        diLatekick.Create();

                    XmlDocument xd = new XmlDocument();
                    xd.InnerXml = retVal;
                    xd.Save(diLatekick.FullName + "\\" + coursecode + "_" + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + ".xml");

                    Utility.SendFeedbackMessage(lvFeedback, "Creating the pdf file.");

                    Latekick.PDF.BrisPdf pdf = new Latekick.PDF.BrisPdf(diLatekick.FullName, coursecode + "_" + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "_bris.pdf");
                    pdf.UserName = Program.ThisUser.UserName;
                    XDocument xd2 = XDocument.Load(diLatekick.FullName + "\\" + coursecode + "_" + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + ".xml");
                    pdf.CreateBRISPdf(xd2);

                    Utility.SendFeedbackMessage(lvFeedback, "Succesfully converted " + coursecode_bris + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip");
                }
                catch (Exception e4)
                {
                    string BalanceMessage2 = "";
                    Latekick.BLL.AccountManagement.User.RefundOne(Program.ThisUser, out BalanceMessage2);
                    throw e4;
                }
            }
            else
            {
                Utility.SendFeedbackMessage(lvFeedback, "Insufficient funds in your account");
            }
        }

        public static void ProcessTrackmasterFile(DateTime dRaceDate, string coursecode, ListView lvFeedback)
        {
            if (Program.ThisUser.Balance >= 1)
            {
                try
                {
                    string BalanceMessage = "";
                    Latekick.BLL.AccountManagement.User.PurchaseOne(Program.ThisUser, out BalanceMessage);

                    Utility.SendFeedbackMessage(lvFeedback, "Unzipping the Trackmaster archive.");

                    DirectoryInfo diTrackmaster = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Trackmaster\\" + dRaceDate.ToString("ddMMMyyyy"));
                    DirectoryInfo diLatekick = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Latekick\\" + dRaceDate.ToString("ddMMMyyyy"));
                    DirectoryInfo diUnzip = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Unzip");

                    //Latekick.Forms.Utility.UnpackArchive(Application.StartupPath + "\\BRIS\\" + dRaceDate.ToString("ddMMMyyyy") + "\\" + coursecode + ".zip", Application.StartupPath + "\\Unzip");
                    Latekick.Forms.Utility.UnpackArchive(diTrackmaster.FullName + "\\" + coursecode + ".zip", diUnzip.FullName);

                    Utility.SendFeedbackMessage(lvFeedback, "Loading the Trackmaster file into memory.");
                    XDocument xdTrackmaster = XDocument.Load(diUnzip.FullName + "\\" + coursecode + dRaceDate.ToString("yyyyMMdd") + "ppsXML.xml");
                    Array.ForEach(Directory.GetFiles(diUnzip.FullName), delegate(string path) { File.Delete(path); });

                    Utility.SendFeedbackMessage(lvFeedback, "Converting Trackmaster data to Latekick (this step takes about 20 seconds).");
                    Latekick.BLL.Conversion.TrackMaster2Latekick t2l = new Latekick.BLL.Conversion.TrackMaster2Latekick();
                    t2l.Convert(xdTrackmaster);
                    //b2l.ConvertHorses(brishorses);
                    //b2l.ConvertPastPerformances(brispps);
                    //b2l.ConvertStats(brisstats);

                    Latekick.BLL.Conversion.LatekickExtras lkextra = new Latekick.BLL.Conversion.LatekickExtras();
                    lkextra.LatekickCard = t2l.LK;
                    lkextra.UpdateRaces();
                    lkextra.UpdateProjectedRatings();
                    lkextra.UpdatePastPerformances();
                    lkextra.UpdateWorkouts();
                    Utility.SendFeedbackMessage(lvFeedback, "Storing the converted data.");

                    string retVal = string.Empty;
                    TextWriter writer = new StringWriter();
                    XmlSerializer serializer = new XmlSerializer(lkextra.LatekickCard.GetType());
                    serializer.Serialize(writer, lkextra.LatekickCard);
                    retVal = writer.ToString();


                    if (!diLatekick.Exists)
                        diLatekick.Create();

                    XmlDocument xd = new XmlDocument();
                    xd.InnerXml = retVal;
                    xd.Save(diLatekick.FullName + "\\" + coursecode + "_" + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + ".xml");

                    Utility.SendFeedbackMessage(lvFeedback, "Creating the pdf file.");

                    Latekick.PDF.TrackmasterPdf pdf = new Latekick.PDF.TrackmasterPdf(diLatekick.FullName, coursecode + "_" + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "_trackmaster.pdf");
                    pdf.UserName = Program.ThisUser.UserName;
                    XDocument xd2 = XDocument.Load(diLatekick.FullName + "\\" + coursecode + "_" + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + ".xml");
                    pdf.CreateTrackmasterPdf(xd2);

                    Utility.SendFeedbackMessage(lvFeedback, "Succesfully converted " + coursecode + (dRaceDate.Month < 10 ? "0" : "") + dRaceDate.Month + (dRaceDate.Day < 10 ? "0" : "") + dRaceDate.Day + "n.zip");

                }
                catch (Exception e4)
                {
                    string BalanceMessage2 = "";
                    Latekick.BLL.AccountManagement.User.RefundOne(Program.ThisUser, out BalanceMessage2);
                    throw e4;
                }
            }
            else
            {
                Utility.SendFeedbackMessage(lvFeedback, "Insufficient funds in your account");
            }
        }

        public static void UnpackArchive(string archiveFile, string unziplocation)
        {
            SevenZipBase.SetLibraryPath(@"_lib\7z.dll");
            SevenZipExtractor extractor = new SevenZipExtractor(archiveFile);
            extractor.ExtractArchive(unziplocation);
        }
    }
}