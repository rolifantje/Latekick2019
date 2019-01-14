using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Latekick.BOL.Base;
using Latekick.BLL.Base;

namespace Latekick.PDF
{
    public class TrackmasterPdf : BasePdf
    {
        #region Variables
        int nullalias = -99;
        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        iTextSharp.text.Font lkmaxfont;
        iTextSharp.text.Font racetitlefont;
        iTextSharp.text.Font largefont;
        iTextSharp.text.Font largeboldfont;
        iTextSharp.text.Font defaultfont;
        iTextSharp.text.Font smallwhitefont;
        iTextSharp.text.Font smallcyanboldfont;
        iTextSharp.text.Font defaultbluefont;
        iTextSharp.text.Font defaultblueboldfont;
        iTextSharp.text.Font defaultcyanfont;
        iTextSharp.text.Font defaultcyanboldfont;
        iTextSharp.text.Font smallbluefont;
        iTextSharp.text.Font smalllightbluefont;
        iTextSharp.text.Font defaultboldfont;
        iTextSharp.text.Font verysmallfont;
        iTextSharp.text.Font smallfont;
        iTextSharp.text.Font smallunderlinedfont;
        iTextSharp.text.Font smallestfont;
        iTextSharp.text.Font smallboldfont;
        iTextSharp.text.Font smallitalicboldfont;
        iTextSharp.text.Font smallblueboldfont;

        float[] pdfColumnSizes = new float[23] { 0.05f, 0.025f, 0.02f, 0.02f, 0.015f, 0.045f, 0.035f, 0.025f, 0.035f, 0.03f, 0.025f, 0.005f, 0.03f, 0.03f, 0.03f, 0.035f, 0.035f, 0.08f, 0.12f, 0.18f, 0.07f, 0.11f, 0.11f };


        string outputDirectory;
        string outputFileName;
        #endregion

        #region Properties
        public string OutputDirectory
        {
            get { return outputDirectory; }
            set { outputDirectory = value; }
        }

        public string OutputFileName
        {
            get { return outputFileName; }
            set { outputFileName = value; }
        }
        #endregion

        #region Constructors
        public TrackmasterPdf(string directoryname, string filename)
        {
            this.outputDirectory = directoryname;
            this.outputFileName = filename;
            InitFormat();
        }
        #endregion

        #region Methods
        private void InitFormat()
        {
            lkmaxfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.BOLD, new BaseColor(System.Drawing.Color.LightGreen));
            racetitlefont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

            verysmallfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            smallfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            smallunderlinedfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.UNDERLINE, BaseColor.BLACK);
            smallestfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            smallboldfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            smallitalicboldfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.BOLDITALIC, BaseColor.BLACK);
            smallbluefont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
            smallblueboldfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
            smallcyanboldfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.BOLD, BaseColor.LIGHT_GRAY);
            smalllightbluefont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.NORMAL, new BaseColor(System.Drawing.Color.LightBlue));
            smallwhitefont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            defaultfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            defaultboldfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            defaultbluefont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
            defaultblueboldfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
            defaultcyanfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.CYAN);
            defaultcyanboldfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.CYAN);
            largefont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 7.5f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            largeboldfont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 7.5f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            //string sEvtSource = "PdfRider";
            //if (!EventLog.SourceExists(sEvtSource))
            //    EventLog.CreateEventSource(sEvtSource,sEvtLog);
            //EventLog.WriteEntry(sEvtSource,"A testevent", EventLogEntryType.Information, 2001);
        }

        public bool CreateTrackmasterPdf(XDocument xd)
        {
            DateTime racedate = DateTime.Parse(xd.Element("Latekick_Card").Attributes("RaceDate").First().Value);
            string coursecode = xd.Root.Descendants("CourseCode").ElementAt(0).Value;

            RaceCard racecard = new RaceCard(racedate, coursecode);
            RaceCardBL.CompileObject(xd, ref racecard);

            Document document = new Document(PageSize.A4.Rotate(), 0, 0, 10, 10);
            PdfWriter writer;

            try
            {
                if (racecard.NumberOfRaces > 0)
                {
                    writer = PdfWriter.GetInstance(document, new FileStream(OutputDirectory + "\\" + OutputFileName, FileMode.Create));
                    document.Open();
                }
                else
                {
                    Console.WriteLine("No races for " + coursecode + " on " + racedate.ToString("dd-MMM-yyyy"));
                    return false;
                }

                for (int r = 0; r < racecard.NumberOfRaces; r++)
                {
                    Race CurrentRace = racecard.Races[r];

                    document.NewPage();
                    ColumnText ct = new ColumnText(writer.DirectContent);
                    ct.SetSimpleColumn(document.Left, document.Bottom, document.Right, document.Top);
                    int status = 0;

                    #region Page Header
                    ct.AddElement(CreatePageHeader(CurrentRace));
                    status = ct.Go(false);
                    #endregion

                    #region RaceDescription
                    ct.AddElement(CreateRaceHeader(CurrentRace));
                    status = ct.Go();
                    #endregion RaceDescription

                    #region Horses

                    for (int h = 0; h < CurrentRace.Entries.Length; h++)
                    {
                        Entry entry = CurrentRace.Entries[h];

                        #region Add Horse to PDF
                        PdfPTable HorsesTable = new PdfPTable(23);
                        HorsesTable = CreateHorseHeader(entry, CurrentRace);

                        PdfPTable PPTable = new PdfPTable(23);
                        PPTable = CreatePPTable(entry, CurrentRace);
                        PdfPCell ppcell = new PdfPCell(PPTable);
                        ppcell.Colspan = 23;
                        ppcell.BorderWidth = 0;

                        HorsesTable.AddCell(ppcell);
                        #endregion

                        #region Add Workouts
                        PdfPCell cWorksHeaderSpacer = new PdfPCell();
                        cWorksHeaderSpacer.FixedHeight = 3;
                        cWorksHeaderSpacer.AddElement(new Phrase("", smallfont));
                        cWorksHeaderSpacer.Colspan = 23;
                        cWorksHeaderSpacer.BorderWidth = 0;
                        cWorksHeaderSpacer.PaddingTop = 20;

                        PdfPCell cWorksFooterSpacer = new PdfPCell();
                        cWorksFooterSpacer.FixedHeight = 3;
                        cWorksFooterSpacer.AddElement(new Phrase("", smallfont));
                        cWorksFooterSpacer.Colspan = 23;
                        cWorksFooterSpacer.BorderWidth = 0;
                        cWorksFooterSpacer.PaddingTop = 3;

                        PdfPCell WorkoutsCell = CreateWorkoutsCell(entry);
                        WorkoutsCell.FixedHeight = 10;
                        HorsesTable.AddCell(cWorksHeaderSpacer);
                        HorsesTable.AddCell(WorkoutsCell);                        
                        //HorsesTable.AddCell(cWorksFooterSpacer);

                        #endregion

                        #region Add BrisStatsCell
                        //PdfPCell BrisStatsCell = CreateBrisStatsCell(entry);
                        //BrisStatsCell.FixedHeight = 10;
                        //HorsesTable.AddCell(BrisStatsCell);

                        //PdfPCell cBrisStatsSpacer = new PdfPCell();
                        //cBrisStatsSpacer.FixedHeight = 3;
                        //cBrisStatsSpacer.AddElement(new Phrase("", smallfont));
                        //cBrisStatsSpacer.Colspan = 23;
                        //cBrisStatsSpacer.BorderWidth = 0;
                        //cBrisStatsSpacer.PaddingTop = 0;
                        //HorsesTable.AddCell(cBrisStatsSpacer);

                        #endregion


                        float y = ct.YLine;
                        ct.AddElement(HorsesTable);

                        status = ct.Go(true);
                        bool startingnewpage = false;
                        if (ColumnText.HasMoreText(status))
                        {
                            startingnewpage = true;
                            document.NewPage();
                            ct.SetText(null);
                            ct.SetSimpleColumn(document.Left, document.Bottom, document.Right, document.Top);
                            y = document.Top;
                        }
                        ct.YLine = y;
                        if (startingnewpage)
                        {
                            ct.AddElement(CreatePageHeader(CurrentRace));
                        }

                        ct.AddElement(HorsesTable);
                        status = ct.Go(false);
                    }
                    #endregion Horses
                }
            }
            #region Exceptions
            catch (DocumentException de)
            {
                EventLog el = new EventLog();
                el.Source = "Pdf Rider";
                el.WriteEntry(de.Message, EventLogEntryType.Error, 312);
            }
            catch (IOException ioe)
            {
                EventLog el = new EventLog();
                el.Source = "Pdf Rider";
                el.WriteEntry(ioe.Message, EventLogEntryType.Error, 312);
            }
            catch (Exception e)
            {
                EventLog el = new EventLog();
                el.Source = "Pdf Rider";
                el.WriteEntry(e.Message, EventLogEntryType.Error, 312);
            }
            #endregion

            document.Close();
            Console.WriteLine("PDF created for " + coursecode + " on " + racedate.ToString("dd-MMM-yyyy"));
            return true;
        }

        private PdfPTable CreatePageHeader(Latekick.BOL.Base.Race CurrentRace)
        {
            PdfPTable DocHeaderTable = new PdfPTable(3);
            DocHeaderTable.KeepTogether = true;
            DocHeaderTable.WidthPercentage = 100;

            Phrase phPageCourseDate = new Phrase(CurrentRace.CourseName + " -- " + CurrentRace.RaceDate.ToLongDateString() + " -- Race " + CurrentRace.RaceNumber.ToString() + " (Post time " + CurrentRace.Posttime + ") ", largeboldfont);
            Phrase phPageHeaderRaceDetails = new Phrase(CurrentRace.Distance + "F" + " (" + CurrentRace.Surface + ")" + " -- $" + CurrentRace.Purse + " -- " + CurrentRace.RaceTypeLong + " -- Class " + CurrentRace.RaceClass, largeboldfont);

            PdfPCell cHeaderCourseDate = new PdfPCell(phPageCourseDate);
            cHeaderCourseDate.BorderWidth = 0;
            cHeaderCourseDate.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cHeaderCourseDate.PaddingBottom = 5f;
            cHeaderCourseDate.BorderWidthBottom = 0.5f;

            PdfPCell cPdfDetails = new PdfPCell(new Phrase("Produced for " + this.UserName, smallwhitefont));
            cPdfDetails.BorderWidth = 0;
            cPdfDetails.BorderWidthBottom = 0.5f;
            cPdfDetails.PaddingBottom = 5f;
            cPdfDetails.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cPdfDetails.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;


            PdfPCell cHeaderRaceDetails = new PdfPCell(phPageHeaderRaceDetails);
            cHeaderRaceDetails.BorderWidth = 0;
            cHeaderRaceDetails.BorderWidthBottom = 0.5f;
            cHeaderRaceDetails.PaddingBottom = 5f;
            cHeaderRaceDetails.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

            DocHeaderTable.AddCell(cHeaderCourseDate);
            DocHeaderTable.AddCell(cPdfDetails);
            DocHeaderTable.AddCell(cHeaderRaceDetails);

            PdfPCell cHeaderSpacer = new PdfPCell();
            cHeaderSpacer.AddElement(new Phrase(""));
            cHeaderSpacer.BorderWidth = 0;
            return DocHeaderTable;
        }

        private PdfPTable CreateRaceHeader(Latekick.BOL.Base.Race CurrentRace)
        {
            PdfPTable RaceHeaderTable = new PdfPTable(3);
            RaceHeaderTable.WidthPercentage = 100;
            RaceHeaderTable.DefaultCell.Padding = 3;
            RaceHeaderTable.ElementComplete = true;
            RaceHeaderTable.HorizontalAlignment = 0;
            RaceHeaderTable.SetWidths(new float[3] { 0.06f, 0.79f, 0.29f });

            #region Race Number
            PdfPCell cRace = new PdfPCell(new Phrase("# " + CurrentRace.RaceNumber, racetitlefont));
            cRace.BackgroundColor = BaseColor.BLACK;
            cRace.HorizontalAlignment = 1;
            cRace.PaddingBottom = 5;
            #endregion

            #region Race Description
            PdfPCell cRaceDescription = new PdfPCell();
            Phrase phRaceDescription = new Phrase(String.Format(Utility.GetNFI(), "{0:c0}", CurrentRace.RaceDescription.Substring(CurrentRace.RaceDescription.IndexOf("THOROUGHBRED") + 12, CurrentRace.RaceDescription.Length - CurrentRace.RaceDescription.IndexOf("THOROUGHBRED") - 12)), smallfont);
            Phrase phBetOptions = new Phrase(CurrentRace.Betting, smallboldfont);
            phRaceDescription.Leading = 10;
            phBetOptions.Leading = 10;

            Paragraph pRaceDescription = new Paragraph();
            pRaceDescription.Leading = 10;
            pRaceDescription.Add(phRaceDescription);
            pRaceDescription.Add("\n");
            pRaceDescription.Add(phBetOptions);

            //racedescriptioncell.BorderWidth = 1;
            cRaceDescription.HorizontalAlignment = 0;
            cRaceDescription.PaddingBottom = 5;
            cRaceDescription.BorderWidth = 0;
            cRaceDescription.AddElement(pRaceDescription);
            #endregion

            #region CD Profile

            PdfPTable tCDProfile = new PdfPTable(4);
            tCDProfile.SetWidths(new float[4] { 0.08f, 0.07f, 0.07f, 0.07f });

            PdfPCell cEmpty = new PdfPCell(new Phrase(""));
            PdfPCell cPaceAvgTitle = new PdfPCell(new Phrase("Pace", smallwhitefont));
            PdfPCell cStalkTitle = new PdfPCell(new Phrase("Stalkers", smallwhitefont));
            PdfPCell cCloseTitle = new PdfPCell(new Phrase("Closers", smallwhitefont));
            PdfPCell cLast365Title = new PdfPCell(new Phrase("Last 365 days", smallboldfont));
            PdfPCell cLast365Pace = new PdfPCell(new Phrase(Math.Round((double)(100*CurrentRace.CD_Profile.PaceWins_All/Math.Max(1,CurrentRace.CD_Profile.Runs_All))) + "% (" + CurrentRace.CD_Profile.PaceWins_All.ToString() + "/" + CurrentRace.CD_Profile.Runs_All.ToString() + ")", smallfont));
            PdfPCell cLast365Stalk = new PdfPCell(new Phrase(Math.Round((double)(100 * CurrentRace.CD_Profile.StalkWins_All / Math.Max(1, CurrentRace.CD_Profile.Runs_All))) + "% (" + CurrentRace.CD_Profile.StalkWins_All.ToString() + "/" + CurrentRace.CD_Profile.Runs_All.ToString() + ")", smallfont));
            PdfPCell cLast365Close = new PdfPCell(new Phrase(Math.Round((double)(100 * CurrentRace.CD_Profile.CloseWins_All / Math.Max(1, CurrentRace.CD_Profile.Runs_All))) + "% (" + CurrentRace.CD_Profile.CloseWins_All.ToString() + "/" + CurrentRace.CD_Profile.Runs_All.ToString() + ")", smallfont));
            PdfPCell cLast14Title = new PdfPCell(new Phrase("Last 14 days", smallboldfont));
            PdfPCell cLast14Pace = new PdfPCell(new Phrase(Math.Round((double)(100 * CurrentRace.CD_Profile.PaceWins_Recent / Math.Max(1, CurrentRace.CD_Profile.Runs_Recent))) + "% (" + CurrentRace.CD_Profile.Runs_Recent.ToString() + "/" + CurrentRace.CD_Profile.Runs_All.ToString() + ")", smallfont));
            PdfPCell cLast14Stalk = new PdfPCell(new Phrase(Math.Round((double)(100 * CurrentRace.CD_Profile.StalkWins_Recent / Math.Max(1, CurrentRace.CD_Profile.Runs_Recent))) + "% (" + CurrentRace.CD_Profile.StalkWins_Recent.ToString() + "/" + CurrentRace.CD_Profile.Runs_All.ToString() + ")", smallfont));
            PdfPCell cLast14Close = new PdfPCell(new Phrase(Math.Round((double)(100 * CurrentRace.CD_Profile.CloseWins_Recent / Math.Max(1, CurrentRace.CD_Profile.Runs_Recent))) + "% (" + CurrentRace.CD_Profile.CloseWins_Recent.ToString() + "/" + CurrentRace.CD_Profile.Runs_All.ToString() + ")", smallfont));

            PdfPCell cEmpty2 = new PdfPCell(new Phrase(""));
            cEmpty2.Colspan = 4;

            #region CD Profile formatting

            cLast365Title.BorderWidth = 0;
            cLast365Title.BorderWidthBottom = 0.25f;
            cLast14Title.BorderWidth = 0;

            cPaceAvgTitle.BackgroundColor = BaseColor.BLACK;
            cStalkTitle.BackgroundColor = BaseColor.BLACK;
            cCloseTitle.BackgroundColor = BaseColor.BLACK;

            cLast365Pace.BackgroundColor = BaseColor.LIGHT_GRAY;
            cLast365Stalk.BackgroundColor = BaseColor.LIGHT_GRAY;
            cLast365Close.BackgroundColor = BaseColor.LIGHT_GRAY;
            cLast14Pace.BackgroundColor = BaseColor.LIGHT_GRAY;
            cLast14Stalk.BackgroundColor = BaseColor.LIGHT_GRAY;
            cLast14Close.BackgroundColor = BaseColor.LIGHT_GRAY;

            cPaceAvgTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cStalkTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cCloseTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLast365Title.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cLast365Pace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLast365Stalk.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLast365Close.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLast14Title.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cLast14Pace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLast14Stalk.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLast14Close.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            cPaceAvgTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cStalkTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cCloseTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cLast365Title.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cLast365Pace.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cLast365Stalk.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cLast365Close.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cLast14Title.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cLast14Pace.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cLast14Stalk.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cLast14Close.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            cEmpty.BorderWidth = 0;
            cEmpty2.BorderWidth = 0;
            #endregion

            tCDProfile.AddCell(cEmpty);
            tCDProfile.AddCell(cPaceAvgTitle);
            tCDProfile.AddCell(cStalkTitle);
            tCDProfile.AddCell(cCloseTitle);
            tCDProfile.AddCell(cLast365Title);
            tCDProfile.AddCell(cLast365Pace);
            tCDProfile.AddCell(cLast365Stalk);
            tCDProfile.AddCell(cLast365Close);
            tCDProfile.AddCell(cLast14Title);
            tCDProfile.AddCell(cLast14Pace);
            tCDProfile.AddCell(cLast14Stalk);
            tCDProfile.AddCell(cLast14Close);
            tCDProfile.AddCell(cEmpty2);

            PdfPCell cCDProfile = new PdfPCell(tCDProfile);
            cCDProfile.BorderWidth = 0;
            #endregion CD Profile

            RaceHeaderTable.AddCell(cRace);
            RaceHeaderTable.AddCell(cRaceDescription);
            RaceHeaderTable.AddCell(cCDProfile);

            return RaceHeaderTable;
        }
        private PdfPTable CreateHorseHeader(Latekick.BOL.Base.Entry CurrentEntry, Latekick.BOL.Base.Race CurrentRace)
        {

            PdfPTable NewTable = new PdfPTable(23);

            NewTable.DefaultCell.Padding = 0;
            NewTable.WidthPercentage = 100;

            NewTable.SetWidths(pdfColumnSizes);
            NewTable.HorizontalAlignment = 0;

            #region Horse
            Phrase phHorse = new Phrase((CurrentEntry.SaddleClothNo == "" ? "" : CurrentEntry.SaddleClothNo + ".  ") + CurrentEntry.ThisHorse.Name + (CurrentEntry.WeightCarried == null ? "" : " (" + CurrentEntry.WeightCarried + ") \n"), largeboldfont);
            Phrase phMLOddsTitle = new Phrase("m/l: ", defaultboldfont);
            Phrase phMLOdds = new Phrase(CurrentEntry.ML.ToString(), defaultblueboldfont);
            Phrase phEmpty = new Phrase("    ", defaultboldfont);
            Phrase phLKOdds = new Phrase(CurrentEntry.TrueOdds.ToString() == "" ? "" : "                           t/o: " + CurrentEntry.TrueOdds.ToString() + "   m/l: " + CurrentEntry.ML.ToString(), defaultblueboldfont);


            Phrase phSaddle = new Phrase(CurrentEntry.SaddleClothNo, largeboldfont);
            Phrase phDraw = new Phrase((CurrentEntry.Draw == null ? "" : "PP-") + CurrentEntry.Draw, defaultbluefont);
            Phrase phEquip = new Phrase((CurrentEntry.Medication == "None" ? " " : "med: " + CurrentEntry.Medication) + "  " + (CurrentEntry.Equip == "No Change" ? " " : " equip: " + CurrentEntry.Equip), defaultbluefont);

            //phHorse.Add(phSaddle);
            phHorse.Add("\n");
            phHorse.Add(phDraw);
            phHorse.Add(phLKOdds);
            phHorse.Add("\n");
            phHorse.Add(phEquip);
            //phHorse.Add(phMLOdds);

            Paragraph pHorse = new Paragraph(phHorse);

            PdfPCell cHorseName = new PdfPCell(pHorse);
            cHorseName.Colspan = 7;
            cHorseName.BorderWidth = 0;
            cHorseName.VerticalAlignment = PdfPCell.ALIGN_TOP;
            #endregion Horse

            #region Table Projected+Style

            PdfPTable tProjStyle = new PdfPTable(10);
            tProjStyle.SetWidths(new float[10] { 0.025f, 0.035f, 0.03f, 0.025f, 0.005f, 0.03f, 0.03f, 0.03f, 0.035f, 0.035f });

            PdfPCell cStylePaceTitle = new PdfPCell(new Phrase("RunStyle", smallwhitefont));
            cStylePaceTitle.Colspan = 2;
            PdfPCell cStyleOffPaceTitle = new PdfPCell(new Phrase("OffPace", smallwhitefont));
            PdfPCell cPaceAvgTitle = new PdfPCell(new Phrase("Pace", smallwhitefont));
            PdfPCell cEarlyTitle = new PdfPCell(new Phrase("Early", smallwhitefont));
            PdfPCell cMiddleTitle = new PdfPCell(new Phrase("Middle", smallwhitefont));
            PdfPCell cLateTitle = new PdfPCell(new Phrase("Late", smallwhitefont));
            PdfPCell cAverageGMRTitle = new PdfPCell(new Phrase("Speed", smalllightbluefont));
            PdfPCell cRecentGMRTitle = new PdfPCell(new Phrase("Recent", smalllightbluefont));
            PdfPCell cPerfRatingTitle = new PdfPCell(new Phrase("--", smalllightbluefont));

            PdfPCell cStylePace = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.RunStyle.RunStyle_BRIS, smallfont));
            cStylePace.Colspan = 2;
            PdfPCell cStyleOffPace = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.RunStyle.OffPaceRuns == 0 || CurrentEntry.ThisHorse.RunStyle.OffPaceRuns == null ? "" : CurrentEntry.ThisHorse.RunStyle.OffPaceWins + "/" + CurrentEntry.ThisHorse.RunStyle.OffPaceRuns, smallfont));
            PdfPCell cPaceAvg = new PdfPCell(new Phrase(CurrentEntry.ProjRatings.Quirin == nullalias ? "-" : CurrentEntry.ProjRatings.Quirin.ToString(), smallboldfont));
            PdfPCell cEarly = new PdfPCell(new Phrase(CurrentEntry.ProjRatings.Early == nullalias ? "-" : CurrentEntry.ProjRatings.Early.ToString(), smallfont));
            PdfPCell cMiddle = new PdfPCell(new Phrase(CurrentEntry.ProjRatings.Middle == nullalias ? "-" : CurrentEntry.ProjRatings.Middle.ToString(), smallfont));
            PdfPCell cLate = new PdfPCell(new Phrase(CurrentEntry.ProjRatings.Late == nullalias ? "-" : CurrentEntry.ProjRatings.Late.ToString(), smallfont));
            PdfPCell cAverageGMR = new PdfPCell(new Phrase(CurrentEntry.ProjRatings.Average == nullalias ? "-" : CurrentEntry.ProjRatings.Average.ToString(), smallboldfont));
            PdfPCell cRecentGMR = new PdfPCell(new Phrase(CurrentEntry.ProjRatings.Recent == nullalias ? "-" : CurrentEntry.ProjRatings.Recent.ToString(), smallboldfont));
            PdfPCell cPerfRat = new PdfPCell(new Phrase("", smallboldfont));

            string strOdds = "";
            string strWeight = "";
            string strPaceCall = "";
            if (CurrentEntry.Horse_LifeTime_Stats.Runs.ToString() != "0")
            {
                strOdds = "odds";
                strWeight = "lbs";
                strPaceCall = "";
            }

            PdfPCell cStyleSpacer = new PdfPCell();
            cStyleSpacer.AddElement(new Phrase(""));
            cStyleSpacer.BorderWidth = 0;
            cStyleSpacer.Colspan = 4;

            PdfPCell cStyleSpacer2 = new PdfPCell();
            cStyleSpacer2.AddElement(new Phrase(""));
            cStyleSpacer2.BorderWidth = 0;
            cStyleSpacer2.Colspan = 1;

            PdfPCell cOddsTitle = new PdfPCell();
            cOddsTitle.AddElement(new Phrase(strOdds, smallboldfont));
            PdfPCell cWeightTitle = new PdfPCell();
            cWeightTitle.AddElement(new Phrase(strWeight, smallboldfont));
            PdfPCell cPaceCallTitle = new PdfPCell();
            cPaceCallTitle.AddElement(new Phrase(strPaceCall, smallboldfont));

            PdfPCell cFSTitle = new PdfPCell();
            string strLateSpeed = "";
            if (CurrentEntry.Horse_LifeTime_Stats.Runs > 0)
                strLateSpeed = "kick";
            cFSTitle.AddElement(new Phrase(strLateSpeed, smallboldfont));
            cFSTitle.BorderWidth = 0;
            cFSTitle.PaddingLeft = 7;
            cFSTitle.Colspan = 2;
            cFSTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cFSTitle.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            #region Cell formatting
            cStylePaceTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cStyleOffPaceTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cPaceAvgTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cEarlyTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cMiddleTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLateTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cPerfRatingTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cAverageGMRTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cAverageGMRTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cRecentGMRTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            cPaceAvgTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cEarlyTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cMiddleTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cLateTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cPerfRatingTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cAverageGMRTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cAverageGMRTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cRecentGMRTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cOddsTitle.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
            cWeightTitle.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
            cPaceCallTitle.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;

            cStylePaceTitle.BackgroundColor = BaseColor.BLACK;
            cStyleOffPaceTitle.BackgroundColor = BaseColor.BLACK;
            cPaceAvgTitle.BackgroundColor = BaseColor.BLACK;
            cEarlyTitle.BackgroundColor = BaseColor.BLACK;
            cMiddleTitle.BackgroundColor = BaseColor.BLACK;
            cLateTitle.BackgroundColor = BaseColor.BLACK;
            cPerfRatingTitle.BackgroundColor = BaseColor.BLACK;
            cAverageGMRTitle.BackgroundColor = BaseColor.BLACK;
            cRecentGMRTitle.BackgroundColor = BaseColor.BLACK;

            cStylePaceTitle.BackgroundColor = BaseColor.BLACK;
            cStyleOffPaceTitle.BackgroundColor = BaseColor.BLACK;
            cPaceAvgTitle.BackgroundColor = BaseColor.BLACK;
            cEarlyTitle.BackgroundColor = BaseColor.BLACK;
            cMiddleTitle.BackgroundColor = BaseColor.BLACK;
            cLateTitle.BackgroundColor = BaseColor.BLACK;
            cPerfRatingTitle.BackgroundColor = BaseColor.BLACK;
            cAverageGMRTitle.BackgroundColor = BaseColor.BLACK;
            cRecentGMRTitle.BackgroundColor = BaseColor.BLACK;

            cStyleOffPace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cStylePace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cPaceAvg.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cEarly.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cMiddle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLate.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cPerfRat.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cAverageGMR.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cRecentGMR.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cOddsTitle.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            cWeightTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cPaceCallTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            cOddsTitle.BorderWidth = 0;
            cWeightTitle.BorderWidth = 0;
            cPaceCallTitle.BorderWidth = 0;

            cStylePaceTitle.PaddingTop = 1;
            cStyleOffPaceTitle.PaddingTop = 1;
            cPaceAvgTitle.PaddingTop = 1;
            cEarlyTitle.PaddingTop = 1;
            cMiddleTitle.PaddingTop = 1;
            cLateTitle.PaddingTop = 1;
            cPerfRatingTitle.PaddingTop = 1;
            cAverageGMRTitle.PaddingTop = 1;
            cRecentGMRTitle.PaddingTop = 1;

            cStylePaceTitle.PaddingBottom = 3;
            cStyleOffPaceTitle.PaddingBottom = 3;
            cPaceAvgTitle.PaddingBottom = 3;
            cEarlyTitle.PaddingBottom = 3;
            cMiddleTitle.PaddingBottom = 3;
            cLateTitle.PaddingBottom = 3;
            cPerfRatingTitle.PaddingBottom = 3;
            cAverageGMRTitle.PaddingBottom = 3;
            cRecentGMRTitle.PaddingBottom = 3;

            cOddsTitle.PaddingLeft = 9;
            cWeightTitle.PaddingLeft = 8;
            cPaceCallTitle.PaddingLeft = 4;

            cStylePace.PaddingTop = 1;
            cStyleOffPace.PaddingTop = 1;
            cPaceAvg.PaddingTop = 1;
            cEarly.PaddingTop = 1;
            cMiddle.PaddingTop = 1;
            cLate.PaddingTop = 1;
            cPerfRat.PaddingTop = 1;
            cAverageGMR.PaddingTop = 1;
            cRecentGMR.PaddingTop = 1;

            cPaceAvg.PaddingBottom = 3;
            cEarly.PaddingBottom = 3;
            cMiddle.PaddingBottom = 3;
            cLate.PaddingBottom = 3;
            cPerfRat.PaddingBottom = 3;
            cAverageGMR.PaddingBottom = 3;
            cRecentGMR.PaddingBottom = 3;

            cStylePace.BackgroundColor = BaseColor.LIGHT_GRAY;
            cStyleOffPace.BackgroundColor = BaseColor.LIGHT_GRAY;

            if (CurrentEntry.ProjRatings.Quirin == CurrentRace.MaxPace)
                cPaceAvg.BackgroundColor = new BaseColor(System.Drawing.Color.LightGreen);
            else
                cPaceAvg.BackgroundColor = BaseColor.ORANGE;

            if (CurrentEntry.ProjRatings.Early == CurrentRace.MaxEarly)
                cEarly.BackgroundColor = new BaseColor(System.Drawing.Color.LightGreen);
            else
                cEarly.BackgroundColor = BaseColor.LIGHT_GRAY;

            if (CurrentEntry.ProjRatings.Middle == CurrentRace.MaxMiddle)
                cMiddle.BackgroundColor = BaseColor.LIGHT_GRAY;
            else
                cMiddle.BackgroundColor = BaseColor.LIGHT_GRAY;

            if (CurrentEntry.ProjRatings.Late == CurrentRace.MaxLate)
                cLate.BackgroundColor = new BaseColor(System.Drawing.Color.LightGreen);
            else
                cLate.BackgroundColor = BaseColor.LIGHT_GRAY;

            if (CurrentEntry.ProjRatings.Quirin == CurrentRace.MaxPace)
                cPerfRat.BackgroundColor = new BaseColor(System.Drawing.Color.LightGreen);
            else
                cPerfRat.BackgroundColor = new BaseColor(System.Drawing.Color.LightBlue);

            if (CurrentEntry.ProjRatings.Average == CurrentRace.MaxAverage)
                cAverageGMR.BackgroundColor = new BaseColor(System.Drawing.Color.LightGreen);
            else
                cAverageGMR.BackgroundColor = new BaseColor(System.Drawing.Color.LightBlue);

            if (CurrentEntry.ProjRatings.Recent == CurrentRace.MaxRecent)
                cRecentGMR.BackgroundColor = new BaseColor(System.Drawing.Color.LightGreen);
            else
                cRecentGMR.BackgroundColor = new BaseColor(System.Drawing.Color.Beige);

            #endregion Cell formatting

            tProjStyle.AddCell(cStyleSpacer2);
            tProjStyle.AddCell(cStylePaceTitle);
            //tProjStyle.AddCell(cStyleOffPaceTitle);
            tProjStyle.AddCell(cPaceAvgTitle);
            tProjStyle.AddCell(cStyleSpacer2);
            tProjStyle.AddCell(cEarlyTitle);
            tProjStyle.AddCell(cMiddleTitle);
            tProjStyle.AddCell(cLateTitle);
            tProjStyle.AddCell(cAverageGMRTitle);
            tProjStyle.AddCell(cRecentGMRTitle);

            tProjStyle.AddCell(cStyleSpacer2);
            tProjStyle.AddCell(cStylePace);
            //tProjStyle.AddCell(cStyleOffPace);
            tProjStyle.AddCell(cPaceAvg);
            tProjStyle.AddCell(cStyleSpacer2);
            tProjStyle.AddCell(cEarly);
            tProjStyle.AddCell(cMiddle);
            tProjStyle.AddCell(cLate);
            tProjStyle.AddCell(cAverageGMR);
            tProjStyle.AddCell(cRecentGMR);

            tProjStyle.AddCell(cStyleSpacer2);
            tProjStyle.AddCell(cOddsTitle);
            tProjStyle.AddCell(cWeightTitle);
            tProjStyle.AddCell(cPaceCallTitle);
            tProjStyle.AddCell(cStyleSpacer);
            tProjStyle.AddCell(cStyleSpacer2);
            tProjStyle.AddCell(cFSTitle);

            PdfPCell cLateStyle = new PdfPCell(tProjStyle);
            cLateStyle.Colspan = 10;
            cLateStyle.BorderWidth = 0;
            //cLateStyle.BorderWidthLeft = 0.25f;
            cLateStyle.VerticalAlignment = PdfPCell.ALIGN_TOP;

            #endregion Table Projected+Style

            #region Jockey Trainer Owner
            Phrase phJTitle = new Phrase(CurrentEntry.JockeyName.ToLower() == "" ? "" : " J: ", smallboldfont);
            string jockstats = CurrentEntry.Jockey_Meet.Runs.ToString() + " " + CurrentEntry.Jockey_Meet.Win.ToString() + " " + CurrentEntry.Jockey_Meet.Place.ToString() + " " + CurrentEntry.Jockey_Meet.Show.ToString();
            string trainerstats = CurrentEntry.Trainer_Meet.Runs.ToString() + " " + CurrentEntry.Trainer_Meet.Win.ToString() + " " + CurrentEntry.Trainer_Meet.Place.ToString() + " " + CurrentEntry.Trainer_Meet.Show.ToString();
            Phrase phJName = new Phrase(Utility.ti.ToTitleCase(CurrentEntry.JockeyName.ToLower()).Replace("Ii", "II").Replace("IIi", "III") + (CurrentEntry.ApprenticeAllowance == 0 ? "" : " (" + CurrentEntry.ApprenticeAllowance + ")").ToString() + " (" + Math.Round((double)(100 * CurrentEntry.Jockey_30Days.Win / Math.Max(1, CurrentEntry.Jockey_30Days.Runs))) + "%, " + CurrentEntry.Jockey_30Days.Win + "/" + CurrentEntry.Jockey_30Days.Runs + ")", smallbluefont);
            Phrase phTTitle = new Phrase(CurrentEntry.TrainerName.ToLower() == "" ? "" : " T: ", smallboldfont);
            Phrase phTName = new Phrase(Utility.ti.ToTitleCase(CurrentEntry.TrainerName.ToLower()).Replace("Ii", "II").Replace("IIi", "III") + " (" + Math.Round((double)(100 * CurrentEntry.Trainer_30Days.Win / Math.Max(1, CurrentEntry.Trainer_30Days.Runs))) + "%, " + CurrentEntry.Trainer_30Days.Win + "/" + CurrentEntry.Trainer_30Days.Runs + ")", smallbluefont);
            Phrase phOTitle = new Phrase(CurrentEntry.JockeyName.ToLower() == "" ? "" : " O: ", smallboldfont);
            Phrase phOName = new Phrase(Utility.ti.ToTitleCase(CurrentEntry.OwnerName.ToLower()).Replace("Ii", "II").Replace("IIi", "III"), smallbluefont);
            Paragraph pJT = new Paragraph();
            pJT.Add(phJTitle);
            pJT.Add(phJName);
            pJT.Add("\n");
            pJT.Add(phTTitle);
            pJT.Add(phTName);
            pJT.Add("\n");
            pJT.Add(phOTitle);
            pJT.Add(phOName);

            PdfPCell cJT = new PdfPCell(pJT);
            //cJT.Colspan = 1;
            cJT.BorderWidth = 0;
            cJT.PaddingBottom = 15;
            //cJT.VerticalAlignment = PdfPCell.ALIGN_TOP;

            #endregion Jockey Trainer

            #region Pedigree

            Phrase phATitle = new Phrase("Gender: ", smallboldfont);
            Phrase phAName = new Phrase(CurrentEntry.ThisHorse.Gender + ".", smallbluefont);
            Phrase phSTitle = new Phrase("Sire: ", smallboldfont);
            Phrase phSName = new Phrase(Utility.ti.ToTitleCase(CurrentEntry.ThisHorse.Sire), smallbluefont);
            Phrase phDTitle = new Phrase("Dam: ", smallboldfont);
            Phrase phDName = new Phrase(Utility.ti.ToTitleCase(CurrentEntry.ThisHorse.Dam + " (" + CurrentEntry.ThisHorse.DamSire + ")"), smallbluefont);
            Paragraph pPedigreeInfo = new Paragraph();
            pPedigreeInfo.Add(phATitle);
            pPedigreeInfo.Add(phAName);
            pPedigreeInfo.Add("\n");
            pPedigreeInfo.Add(phSTitle);
            pPedigreeInfo.Add(phSName);
            pPedigreeInfo.Add("\n");
            pPedigreeInfo.Add(phDTitle);
            pPedigreeInfo.Add(phDName);

            PdfPCell cPedigreeInfo = new PdfPCell(pPedigreeInfo);
            cPedigreeInfo.BorderWidth = 0;
            cPedigreeInfo.Colspan = 2;
            //cPedigreeInfo.VerticalAlignment = PdfPCell.ALIGN_TOP;

            #endregion Pedigree

            #region Table Lifetime Stats
            PdfPTable tHorseStats = new PdfPTable(10);
            tHorseStats.SetWidths(new float[10] { 0.065f, 0.02f, 0.02f, 0.02f, 0.02f, 0.065f, 0.02f, 0.02f, 0.02f, 0.02f });
            tHorseStats.DefaultCell.BorderWidth = 0;

            PdfPCell cEmpty = new PdfPCell();
            cEmpty.Colspan = 4;

            PdfPCell cHLifetimeTitle = new PdfPCell(new Phrase("Lifetime", smallboldfont));
            PdfPCell cHLifetimeRuns = new PdfPCell(new Phrase(CurrentEntry.Horse_LifeTime_Stats.Runs.ToString(), smallfont));
            PdfPCell cHLifetimeWin = new PdfPCell(new Phrase(CurrentEntry.Horse_LifeTime_Stats.Win.ToString(), smallfont));
            PdfPCell cHLifetimePlace = new PdfPCell(new Phrase(CurrentEntry.Horse_LifeTime_Stats.Place.ToString(), smallfont));
            PdfPCell cHLifetimeShow = new PdfPCell(new Phrase(CurrentEntry.Horse_LifeTime_Stats.Show.ToString(), smallfont));
            PdfPCell cHLifetimeEarnings = new PdfPCell(new Phrase("$" + Math.Truncate(Double.Parse(CurrentEntry.ThisHorse.EarningsLifeTime.ToString())/1000) + "K", smallfont));

            PdfPCell cTYTitle = new PdfPCell(new Phrase(CurrentRace.ThisYear, smallboldfont));
            PdfPCell cTYRuns = new PdfPCell(new Phrase(CurrentEntry.Horse_CurrentYear_Stats.Runs.ToString(), smallfont));
            PdfPCell cTYWin = new PdfPCell(new Phrase(CurrentEntry.Horse_CurrentYear_Stats.Win.ToString(), smallfont));
            PdfPCell cTYPlace = new PdfPCell(new Phrase(CurrentEntry.Horse_CurrentYear_Stats.Place.ToString(), smallfont));
            PdfPCell cTYShow = new PdfPCell(new Phrase(CurrentEntry.Horse_CurrentYear_Stats.Show.ToString(), smallfont));

            PdfPCell cLYTitle = new PdfPCell(new Phrase(CurrentRace.LastYear, smallboldfont));
            PdfPCell cLYRuns = new PdfPCell(new Phrase(CurrentEntry.Horse_LastYear_Stats.Runs.ToString(), smallfont));
            PdfPCell cLYWin = new PdfPCell(new Phrase(CurrentEntry.Horse_LastYear_Stats.Win.ToString(), smallfont));
            PdfPCell cLYPlace = new PdfPCell(new Phrase(CurrentEntry.Horse_LastYear_Stats.Place.ToString(), smallfont));
            PdfPCell cLYShow = new PdfPCell(new Phrase(CurrentEntry.Horse_LastYear_Stats.Show.ToString(), smallfont));

            PdfPCell cCourseTitle = new PdfPCell(new Phrase(CurrentRace.CourseCode, smallboldfont));
            PdfPCell cCourseRuns = new PdfPCell(new Phrase(CurrentEntry.Horse_Track_Stats.Runs.ToString(), smallfont));
            PdfPCell cCourseWin = new PdfPCell(new Phrase(CurrentEntry.Horse_Track_Stats.Win.ToString(), smallfont));
            PdfPCell cCoursePlace = new PdfPCell(new Phrase(CurrentEntry.Horse_Track_Stats.Place.ToString(), smallfont));
            PdfPCell cCourseShow = new PdfPCell(new Phrase(CurrentEntry.Horse_Track_Stats.Show.ToString(), smallfont));

            PdfPCell cDistSurfTitle = new PdfPCell(new Phrase("Dist", smallboldfont));
            PdfPCell cDistSurfRuns = new PdfPCell(new Phrase(CurrentEntry.Horse_Distance_Stats.Runs.ToString(), smallfont));
            PdfPCell cDistSurfWin = new PdfPCell(new Phrase(CurrentEntry.Horse_Distance_Stats.Win.ToString(), smallfont));
            PdfPCell cDistSurfPlace = new PdfPCell(new Phrase(CurrentEntry.Horse_Distance_Stats.Place.ToString(), smallfont));
            PdfPCell cDistSurfShow = new PdfPCell(new Phrase(CurrentEntry.Horse_Distance_Stats.Show.ToString(), smallfont));

            PdfPCell cSurfTitle = new PdfPCell(new Phrase("Fast", smallboldfont));
            PdfPCell cSurfRuns = new PdfPCell(new Phrase(CurrentEntry.Horse_Dirt_Stats.Runs.ToString(), smallfont));
            PdfPCell cSurfWin = new PdfPCell(new Phrase(CurrentEntry.Horse_Dirt_Stats.Win.ToString(), smallfont));
            PdfPCell cSurfPlace = new PdfPCell(new Phrase(CurrentEntry.Horse_Dirt_Stats.Place.ToString(), smallfont));
            PdfPCell cSurfShow = new PdfPCell(new Phrase(CurrentEntry.Horse_Dirt_Stats.Show.ToString(), smallfont));

            PdfPCell cSurfGoodTitle = new PdfPCell(new Phrase("Wet", smallboldfont));
            PdfPCell cSurfGoodRuns = new PdfPCell(new Phrase(CurrentEntry.Horse_Wet_Stats.Runs.ToString(), smallfont));
            PdfPCell cSurfGoodWin = new PdfPCell(new Phrase(CurrentEntry.Horse_Wet_Stats.Win.ToString(), smallfont));
            PdfPCell cSurfGoodPlace = new PdfPCell(new Phrase(CurrentEntry.Horse_Wet_Stats.Place.ToString(), smallfont));
            PdfPCell cSurfGoodShow = new PdfPCell(new Phrase(CurrentEntry.Horse_Wet_Stats.Show.ToString(), smallfont));


            #region Format Cells
            cHLifetimeTitle.BorderWidth = 0;
            cHLifetimeTitle.BorderWidthBottom = 0.25f;
            cHLifetimeRuns.BorderWidth = 0;
            cHLifetimeRuns.BorderWidthBottom = 0.25f;
            cHLifetimeWin.BorderWidth = 0;
            cHLifetimeWin.BorderWidthBottom = 0.25f;
            cHLifetimePlace.BorderWidth = 0;
            cHLifetimePlace.BorderWidthBottom = 0.25f;
            cHLifetimeShow.BorderWidth = 0;
            cHLifetimeShow.BorderWidthBottom = 0.25f;
            cHLifetimeEarnings.BorderWidth = 0;
            cHLifetimeEarnings.BorderWidthBottom = 0.25f;


            cEmpty.BorderWidth = 0;
            cEmpty.BorderWidthBottom = 0.25f;

            cTYTitle.BorderWidth = 0;
            cTYRuns.BorderWidth = 0;
            cTYWin.BorderWidth = 0;
            cTYPlace.BorderWidth = 0;
            cTYShow.BorderWidth = 0;

            cLYTitle.BorderWidth = 0;
            cLYRuns.BorderWidth = 0;
            cLYWin.BorderWidth = 0;
            cLYPlace.BorderWidth = 0;
            cLYShow.BorderWidth = 0;

            cCourseTitle.BorderWidth = 0;
            cCourseRuns.BorderWidth = 0;
            cCourseWin.BorderWidth = 0;
            cCoursePlace.BorderWidth = 0;
            cCourseShow.BorderWidth = 0;

            cDistSurfTitle.BorderWidth = 0;
            cDistSurfRuns.BorderWidth = 0;
            cDistSurfWin.BorderWidth = 0;
            cDistSurfPlace.BorderWidth = 0;
            cDistSurfShow.BorderWidth = 0;


            cSurfTitle.BorderWidth = 0;
            cSurfRuns.BorderWidth = 0;
            cSurfWin.BorderWidth = 0;
            cSurfPlace.BorderWidth = 0;
            cSurfShow.BorderWidth = 0;

            cSurfGoodTitle.BorderWidth = 0;
            cSurfGoodRuns.BorderWidth = 0;
            cSurfGoodWin.BorderWidth = 0;
            cSurfGoodPlace.BorderWidth = 0;
            cSurfGoodShow.BorderWidth = 0;

            cHLifetimeTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cHLifetimeRuns.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cHLifetimeWin.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cHLifetimePlace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cHLifetimeShow.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cHLifetimeEarnings.HorizontalAlignment = PdfPCell.ALIGN_CENTER;


            cHLifetimeTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cHLifetimeRuns.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cHLifetimeWin.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cHLifetimePlace.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cHLifetimeShow.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cHLifetimeEarnings.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;

            cTYTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cTYRuns.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cTYWin.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cTYPlace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cTYShow.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            cLYTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLYRuns.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLYWin.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLYPlace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cLYShow.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            cCourseTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cCourseRuns.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cCourseWin.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cCoursePlace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cCourseShow.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            cDistSurfTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cDistSurfRuns.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cDistSurfWin.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cDistSurfPlace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cDistSurfShow.HorizontalAlignment = PdfPCell.ALIGN_CENTER;


            cSurfTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cSurfRuns.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cSurfWin.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cSurfPlace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cSurfShow.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            cSurfGoodTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cSurfGoodRuns.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cSurfGoodWin.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cSurfGoodPlace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cSurfGoodShow.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

            cHLifetimeTitle.PaddingBottom = 2;
            cHLifetimeRuns.PaddingBottom = 2;
            cHLifetimeWin.PaddingBottom = 2;
            cHLifetimePlace.PaddingBottom = 2;
            cHLifetimeShow.PaddingBottom = 2;

            cHLifetimeTitle.PaddingTop = 0.50f;
            cHLifetimeRuns.PaddingTop = 0.50f;
            cHLifetimeWin.PaddingTop = 0.50f;
            cHLifetimePlace.PaddingTop = 0.50f;
            cHLifetimeShow.PaddingTop = 0.50f;
            cHLifetimeEarnings.PaddingTop = 0.50f;
            cEmpty.PaddingBottom = 2;

            cTYTitle.Padding = 0.50f;
            cTYRuns.Padding = 0.50f;
            cTYWin.Padding = 0.50f;
            cTYPlace.Padding = 0.50f;
            cTYShow.Padding = 0.50f;

            cLYTitle.Padding = 0.50f;
            cLYRuns.Padding = 0.50f;
            cLYWin.Padding = 0.50f;
            cLYPlace.Padding = 0.50f;
            cLYShow.Padding = 0.50f;

            cCourseTitle.Padding = 0.50f;
            cCourseRuns.Padding = 0.50f;
            cCourseWin.Padding = 0.50f;
            cCoursePlace.Padding = 0.50f;
            cCourseShow.Padding = 0.50f;

            cDistSurfTitle.Padding = 0.50f;
            cDistSurfRuns.Padding = 0.50f;
            cDistSurfWin.Padding = 0.50f;
            cDistSurfPlace.Padding = 0.50f;
            cDistSurfShow.Padding = 0.50f;


            cSurfTitle.Padding = 0.50f;
            cSurfRuns.Padding = 0.50f;
            cSurfWin.Padding = 0.50f;
            cSurfPlace.Padding = 0.50f;
            cSurfShow.Padding = 0.50f;

            cSurfGoodTitle.Padding = 0.50f;
            cSurfGoodRuns.Padding = 0.50f;
            cSurfGoodWin.Padding = 0.50f;
            cSurfGoodPlace.Padding = 0.50f;
            cSurfGoodShow.Padding = 0.50f;


            #endregion Format Cells

            tHorseStats.AddCell(cHLifetimeTitle);
            tHorseStats.AddCell(cHLifetimeRuns);
            tHorseStats.AddCell(cHLifetimeWin);
            tHorseStats.AddCell(cHLifetimePlace);
            tHorseStats.AddCell(cHLifetimeShow);
            tHorseStats.AddCell(cHLifetimeEarnings);

            tHorseStats.AddCell(cEmpty);

            tHorseStats.AddCell(cTYTitle);
            tHorseStats.AddCell(cTYRuns);
            tHorseStats.AddCell(cTYWin);
            tHorseStats.AddCell(cTYPlace);
            tHorseStats.AddCell(cTYShow);

            tHorseStats.AddCell(cSurfTitle);
            tHorseStats.AddCell(cSurfRuns);
            tHorseStats.AddCell(cSurfWin);
            tHorseStats.AddCell(cSurfPlace);
            tHorseStats.AddCell(cSurfShow);

            tHorseStats.AddCell(cLYTitle);
            tHorseStats.AddCell(cLYRuns);
            tHorseStats.AddCell(cLYWin);
            tHorseStats.AddCell(cLYPlace);
            tHorseStats.AddCell(cLYShow);

            tHorseStats.AddCell(cSurfGoodTitle);
            tHorseStats.AddCell(cSurfGoodRuns);
            tHorseStats.AddCell(cSurfGoodWin);
            tHorseStats.AddCell(cSurfGoodPlace);
            tHorseStats.AddCell(cSurfGoodShow);

            tHorseStats.AddCell(cCourseTitle);
            tHorseStats.AddCell(cCourseRuns);
            tHorseStats.AddCell(cCourseWin);
            tHorseStats.AddCell(cCoursePlace);
            tHorseStats.AddCell(cCourseShow);

            tHorseStats.AddCell(cDistSurfTitle);
            tHorseStats.AddCell(cDistSurfRuns);
            tHorseStats.AddCell(cDistSurfWin);
            tHorseStats.AddCell(cDistSurfPlace);
            tHorseStats.AddCell(cDistSurfShow);

            tHorseStats.AddCell(cDistSurfTitle);
            tHorseStats.AddCell(cDistSurfRuns);
            tHorseStats.AddCell(cDistSurfWin);
            tHorseStats.AddCell(cDistSurfPlace);
            tHorseStats.AddCell(cDistSurfShow);

 
            PdfPCell cHorseStats = new PdfPCell(tHorseStats);
            cHorseStats.Colspan = 3;
            cHorseStats.BorderWidth = 0f;
            cHorseStats.VerticalAlignment = PdfPCell.ALIGN_TOP;

            #endregion Table Lifetime Stats

            #region Add all PdfPCells to Horse Header
            PdfPCell cEmpty2 = new PdfPCell();
            cEmpty2.BorderWidth = 0;

            //cSaddleDraw.BorderWidthTop = 0.25f;
            cHorseName.BorderWidthTop = 0.25f;
            cJT.BorderWidthTop = 0.25f;
            cPedigreeInfo.BorderWidthTop = 0.25f;
            cHorseStats.BorderWidthTop = 0.25f;
            cHorseStats.PaddingBottom = 2f;
            cHorseStats.BorderWidthBottom = 0.25f;
            cLateStyle.BorderWidthTop = 0.25f;

            //NewTable.AddCell(cSaddleDraw);
            NewTable.AddCell(cHorseName);
            NewTable.AddCell(cLateStyle);
            //NewTable.AddCell(cEmpty2);
            NewTable.AddCell(cPedigreeInfo);
            NewTable.AddCell(cJT);
            NewTable.AddCell(cHorseStats);
            #endregion

            return NewTable;
        }

        private PdfPTable CreatePPTable(Latekick.BOL.Base.Entry CurrentEntry, Latekick.BOL.Base.Race CurrentRace)
        {

            PdfPTable NewTable = new PdfPTable(23);

            NewTable.DefaultCell.Padding = 0;
            NewTable.WidthPercentage = 100;

            NewTable.SetWidths(pdfColumnSizes);
            NewTable.HorizontalAlignment = 0;
            string previoustrainer = CurrentEntry.TrainerName;

            #region Add PP
            for (int i = 0; i < CurrentEntry.ThisHorse.PastPerformances.Length; i++)
            {
                #region Add PPRow

                PdfPCell cDate = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].ThisRace.RaceDate.ToString("ddMMMyyyy"), smallfont));
                PdfPCell cCourse = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].ThisRace.CourseAbbreviation, smallboldfont));
                PdfPCell cGoing = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].ThisRace.Going.ToLower(), smallfont));
                PdfPCell cDistance = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].ThisRace.Distance + "f", smallfont));
                PdfPCell cSurface = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].ThisRace.Surface, smallfont));
                PdfPCell cType = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].ThisRace.RaceType + "^" + Utility.FormatNumber(CurrentEntry.ThisHorse.PastPerformances[i].ThisRace.Purse), smallfont));
                PdfPCell cFinish = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].OfficialPositionText, CurrentEntry.ThisHorse.PastPerformances[i].OfficialPosition == 1 ? smallcyanboldfont : smallboldfont));
                PdfPCell cDistanceBeaten = new PdfPCell(new Phrase(Math.Round(CurrentEntry.ThisHorse.PastPerformances[i].DistanceBeaten.Value, 1).ToString(), CurrentEntry.ThisHorse.PastPerformances[i].OfficialPosition == 1 ? smallcyanboldfont : smallfont));
                PdfPCell cOdds = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].OddsText + " ", smallfont));
                PdfPCell cWeight = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].Weight.ToString() != "" ? CurrentEntry.ThisHorse.PastPerformances[i].Weight.ToString() : "", smallfont));
                PdfPCell cPace = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].Pace.ToString() != "" ? CurrentEntry.ThisHorse.PastPerformances[i].Pace.ToString() : "", smallfont));
                PdfPCell cEarly = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].Early.ToString(), smallfont));
                PdfPCell cMiddle = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].Middle.ToString(), smallfont));
                PdfPCell cLate = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].Late.ToString(), smallfont));
                PdfPCell cAverageGMR = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].GMR.ToString(), smallboldfont));
                PdfPCell cFinKick = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].LateSpeed < 10 ? "" : String.Format("{0:0.0}", CurrentEntry.ThisHorse.PastPerformances[i].LateSpeed), smallfont));
                System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                PdfPCell cJName = new PdfPCell(new Phrase(Utility.ti.ToTitleCase(CurrentEntry.ThisHorse.PastPerformances[i].JockeyName.ToLower()).Replace("Ii", "II").Replace("IIi", "III"), smallestfont));
                PdfPCell cTName;
                //if (CurrentEntry.ThisHorse.PastPerformances[i].TrainerName != previoustrainer)
                //{
                    cTName = new PdfPCell(new Phrase(Utility.ti.ToTitleCase(CurrentEntry.ThisHorse.PastPerformances[i].TrainerName.ToLower()).Replace("Ii", "II").Replace("IIi", "III"), smallestfont));
                //}
                //else
                //    cTName = new PdfPCell(new Phrase("", smallestfont));
                previoustrainer = CurrentEntry.TrainerName;
                string[] arrTop3 = CurrentEntry.ThisHorse.PastPerformances[i].ThisRace.Finish123.Split(new Char[] { ';' });
                string[] arrTop3GMR = CurrentEntry.ThisHorse.PastPerformances[i].ThisRace.Finish123_GMR.Split(new Char[] { ';' });
                if (arrTop3GMR.Length < 3)
                    arrTop3GMR = arrTop3;
                Paragraph pTop3 = new Paragraph();
                string separator = "";
                for (int j = 1; j <= arrTop3.Length; j++)
                {
                    if (j > 1)
                        separator = "; ";
                    Phrase phTop3Horse;
                    if (CurrentRace.HorseNames.Contains(arrTop3[j - 1].ToUpper()))
                        phTop3Horse = new Phrase(separator + arrTop3GMR[j - 1].Replace("  ", " ").Replace("''", "'").ToLower().Replace(" ", " ").ToUpper(), smallitalicboldfont);
                    else
                        phTop3Horse = new Phrase(separator + Utility.ti.ToTitleCase(arrTop3GMR[j - 1].Replace("  ", " ").Replace("''", "'").ToLower().Replace(" ", " ")), smallfont);
                    pTop3.Add(phTop3Horse);
                }

                PdfPCell cResult = new PdfPCell(pTop3);
                PdfPCell cPerfComment = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.PastPerformances[i].PerformanceComment.ToLower(), smallfont));
                PdfPCell cEmpty = new PdfPCell(new Phrase(""));

                #region PPCell formatting

                cDate.BorderWidth = 0f;
                cCourse.BorderWidth = 0f;
                cType.BorderWidth = 0f;
                cSurface.BorderWidth = 0f;
                cDistance.BorderWidth = 0f;
                cGoing.BorderWidth = 0f;
                cEarly.BorderWidth = 0f;
                cMiddle.BorderWidth = 0f;
                cLate.BorderWidth = 0f;
                cAverageGMR.BorderWidth = 0f;
                cFinish.BorderWidth = 0f;
                cDistanceBeaten.BorderWidth = 0f;

                cOdds.BorderWidth = 0f;
                cJName.BorderWidth = 0f;
                cTName.BorderWidth = 0f;
                cResult.BorderWidth = 0f;
                cPerfComment.BorderWidth = 0f;
                //cTSFigs.BorderWidth = 0f;
                cFinKick.BorderWidth = 0f;
                cPace.BorderWidth = 0f;
                cWeight.BorderWidth = 0f;
                cEmpty.BorderWidth = 0f;

                cDate.PaddingBottom = 0;
                cCourse.PaddingBottom = 0;
                cType.PaddingBottom = 0;
                cSurface.PaddingBottom = 0;
                cDistance.PaddingBottom = 0;
                cGoing.PaddingBottom = 0;
                cEarly.PaddingBottom = 0;
                cMiddle.PaddingBottom = 0;
                cLate.PaddingBottom = 0;
                cAverageGMR.PaddingBottom = 0;
                cFinish.PaddingBottom = 0;
                cDistanceBeaten.PaddingBottom = 0;
                cOdds.PaddingBottom = 0;
                cJName.PaddingBottom = 0;
                cTName.PaddingBottom = 0;
                cResult.PaddingBottom = 0;
                cPerfComment.PaddingBottom = 0;
                //cTSFigs.PaddingBottom = 0;
                cFinKick.PaddingBottom = 0;
                cPace.PaddingBottom = 0;
                cWeight.PaddingBottom = 0;

                cDate.PaddingTop = 0;
                cCourse.PaddingTop = 0;
                cType.PaddingTop = 0;
                cSurface.PaddingTop = 0;
                cDistance.PaddingTop = 0;
                cGoing.PaddingTop = 0;
                cEarly.PaddingTop = 0;
                cMiddle.PaddingTop = 0;
                cLate.PaddingTop = 0;
                cAverageGMR.PaddingTop = 0;
                cFinish.PaddingTop = 0;
                cDistanceBeaten.PaddingTop = 0;
                cOdds.PaddingTop = 0;
                cJName.PaddingTop = 0;
                cTName.PaddingTop = 0;
                cResult.PaddingTop = 0;
                cPerfComment.PaddingTop = 0;
                //cTSFigs.PaddingTop = 0;
                cPace.PaddingTop = 0;
                cFinKick.PaddingTop = 0;
                cWeight.PaddingTop = 0;
                cPace.PaddingLeft = 5;
                cWeight.PaddingLeft = 5;
                cJName.PaddingLeft = 5;

                cDate.FixedHeight = 7;
                cCourse.FixedHeight = 7;
                cType.FixedHeight = 7;
                cSurface.FixedHeight = 7;
                cDistance.FixedHeight = 7;
                cGoing.FixedHeight = 7;
                cEarly.FixedHeight = 7;
                cMiddle.FixedHeight = 7;
                cLate.FixedHeight = 7;
                cAverageGMR.FixedHeight = 7;
                cFinish.FixedHeight = 7;
                cDistanceBeaten.FixedHeight = 7;
                cOdds.FixedHeight = 7;
                cJName.FixedHeight = 7;
                cTName.FixedHeight = 7;
                cResult.FixedHeight = 7;
                cPerfComment.FixedHeight = 7;
                //cTSFigs.FixedHeight = 7;
                cFinKick.FixedHeight = 7;
                cPace.FixedHeight = 7;
                cWeight.FixedHeight = 7;

                cEarly.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cMiddle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cLate.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cAverageGMR.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cFinish.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cDistanceBeaten.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cOdds.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cDistance.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cFinKick.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cOdds.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cWeight.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cPace.HorizontalAlignment = PdfPCell.ALIGN_CENTER;


                cAverageGMR.BackgroundColor = new BaseColor(System.Drawing.Color.LightBlue);
                //cFinKick.BackgroundColor = new BaseColor(System.Drawing.Color.Beige);
                #endregion PPCell formatting

                NewTable.AddCell(cDate);
                NewTable.AddCell(cCourse);
                NewTable.AddCell(cGoing);
                NewTable.AddCell(cDistance);
                NewTable.AddCell(cSurface);
                NewTable.AddCell(cType);
                NewTable.AddCell(cFinish);
                NewTable.AddCell(cDistanceBeaten);
                NewTable.AddCell(cOdds);
                NewTable.AddCell(cWeight);
                NewTable.AddCell(cEmpty);
                NewTable.AddCell(cEmpty);
                NewTable.AddCell(cEarly);
                NewTable.AddCell(cMiddle);
                NewTable.AddCell(cLate);
                NewTable.AddCell(cAverageGMR);
                NewTable.AddCell(cFinKick);
                //NewTable.AddCell(cEmpty);
                NewTable.AddCell(cJName);
                NewTable.AddCell(cTName);
                //cResult.Colspan = 2;
                cPerfComment.Colspan = 1;
                NewTable.AddCell(cPerfComment);
                cResult.Colspan = 3;
                NewTable.AddCell(cResult);
                //NewTable.AddCell(cTSFigs);
                //NewTable.AddCell(cPRFigs);
                #endregion Add PPRow
            }
            #endregion Add PP
            return NewTable;
        }

        private PdfPCell CreateWorkoutsCell(Latekick.BOL.Base.Entry CurrentEntry)
        {

            //float[] pdfColumnSizes = new float[23] { 0.05f, 0.025f, 0.02f, 0.03f, 0.005f, 0.045f, 0.035f, 0.025f, 0.035f, 0.03f, 0.025f, 0.005f, 0.03f, 0.03f, 0.03f, 0.035f, 0.035f, 0.08f, 0.12f, 0.18f, 0.07f, 0.11f, 0.11f };

            //float[] cwWorks = new float[8] { 0.05f, 0.025f, 0.02f, 0.02f, 0.015f, 0.045f, 0.035f, 0.28f };

            //PdfPTable tWorks = new PdfPTable(8);
            //tWorks.SetWidths(cwWorks);
            ////tWorks.DefaultCell.Padding = 0;
            //tWorks.HorizontalAlignment = 1;

            //PdfPCell cWorksTitle = new PdfPCell(new Phrase("Works:", smallfont));
            //PdfPCell cEmpty = new PdfPCell(new Phrase("", smallfont));

            //cWorksTitle.Padding = 0f;
            //cWorksTitle.PaddingTop = 3f;
            //cWorksTitle.BorderWidthTop = 1;
            //cEmpty.Padding = 0f;
            //cEmpty.PaddingTop = 3f;

            //cWorksTitle.BorderWidth = 0f;
            //cEmpty.BorderWidth = 0f;

            //cWorksTitle.FixedHeight = 7f;
            //cEmpty.FixedHeight = 7f;

            ////tWorks.AddCell(cWorksTitle);

            //for (int w = 0; w < 5; w++)
            //{
            //    PdfPCell cWorkDate, cWorkTrack, cWorkGoing, cWorkDistance, cWorkSurface, cWorkTime, cWorkRank, cWorkRating;
            //    if (w < CurrentEntry.ThisHorse.Workouts.Length)
            //    {
            //        cWorkDate = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.Workouts[w].WorkDate.ToString("ddMMM"), smallfont));
            //        cWorkTrack = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.Workouts[w].WorkCourse, smallfont));
            //        cWorkGoing = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.Workouts[w].WorkGoing.ToLower(), smallfont));
            //        cWorkDistance = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.Workouts[w].WorkDistance.ToString() + "f", smallfont));
            //        cWorkSurface = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.Workouts[w].WorksSurface, smallfont));
            //        cWorkTime = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.Workouts[w].WorkTime.ToString(), smallfont));
            //        cWorkRank = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.Workouts[w].WorkRank, smallfont));
            //        cWorkRating = new PdfPCell(new Phrase(CurrentEntry.ThisHorse.Workouts[w].WorkRating.Value.ToString(), smallfont));

            //    }
            //    else
            //    {
            //        cWorkDate = new PdfPCell(new Phrase("", smallfont));
            //        cWorkTrack = new PdfPCell(new Phrase("", smallfont));
            //        cWorkGoing = new PdfPCell(new Phrase("", smallfont));
            //        cWorkDistance = new PdfPCell(new Phrase("", smallfont));
            //        cWorkSurface = new PdfPCell(new Phrase("", smallfont));
            //        cWorkTime = new PdfPCell(new Phrase("", smallfont));
            //        cWorkRank = new PdfPCell(new Phrase("", smallfont));
            //        cWorkRating = new PdfPCell(new Phrase("", smallfont));
            //    }

            //    if (w > 0)
            //        //tWorks.AddCell(cEmpty);


            //    cWorkDate.Padding = 0f;
            //    cWorkTrack.Padding = 0f;
            //    cWorkGoing.Padding = 0f;
            //    cWorkDistance.Padding = 0f;
            //    cWorkSurface.Padding = 0f;
            //    cWorkTime.Padding = 0f;
            //    cWorkRank.Padding = 0f;
            //    cWorkRating.Padding = 0f;

            //    cWorkDate.BorderWidth = 0f;
            //    cWorkTrack.BorderWidth = 0f;
            //    cWorkGoing.BorderWidth = 0f;
            //    cWorkDistance.BorderWidth = 0f;
            //    cWorkSurface.BorderWidth = 0f;
            //    cWorkTime.BorderWidth = 0f;
            //    cWorkRank.BorderWidth = 0f;
            //    cWorkRating.BorderWidth = 0f;
             
            //    cWorkDate.FixedHeight = 7f;
            //    cWorkTrack.FixedHeight = 7f;
            //    cWorkGoing.FixedHeight = 7f;
            //    cWorkDistance.FixedHeight = 7f;
            //    cWorkSurface.FixedHeight = 7f;
            //    cWorkTime.FixedHeight = 7f;
            //    cWorkRank.FixedHeight = 7f;
            //    cWorkRating.FixedHeight = 7f;

            //    tWorks.AddCell(cWorkDate);
            //    tWorks.AddCell(cWorkTrack);
            //    tWorks.AddCell(cWorkGoing);
            //    tWorks.AddCell(cWorkDistance);
            //    tWorks.AddCell(cWorkSurface);
            //    tWorks.AddCell(cWorkTime);
            //    tWorks.AddCell(cWorkRank);
            //    tWorks.AddCell(cWorkRating);
            //}

            //string strWorks1 = "", strWorks2 = "                ";
            //for (int w = 0; w < Math.Min(5, CurrentEntry.ThisHorse.Workouts.Length); w++)
            //{
            //    string workraw = CurrentEntry.ThisHorse.Workouts[w].WorkDate.ToString("ddMMM") + " " + CurrentEntry.ThisHorse.Workouts[w].WorkCourse + " (" + CurrentEntry.ThisHorse.Workouts[w].WorksSurface + ") " + CurrentEntry.ThisHorse.Workouts[w].WorkDistance + "f " + CurrentEntry.ThisHorse.Workouts[w].WorkTime + " (rating: " + CurrentEntry.ThisHorse.Workouts[w].WorkRating + ", rank: " + CurrentEntry.ThisHorse.Workouts[w].WorkRank + ")" + "        ";
            //    strWorks1 += workraw + new String(' ', 60-workraw.Length);
            //}
            //for (int w = 5; w < Math.Min(10, CurrentEntry.ThisHorse.Workouts.Length); w++)
            //{
            //    string workraw = CurrentEntry.ThisHorse.Workouts[w].WorkDate.ToString("ddMMM") + " " + CurrentEntry.ThisHorse.Workouts[w].WorkCourse + " (" + CurrentEntry.ThisHorse.Workouts[w].WorksSurface + ") " + CurrentEntry.ThisHorse.Workouts[w].WorkDistance + "f " + CurrentEntry.ThisHorse.Workouts[w].WorkTime + " (rating: " + CurrentEntry.ThisHorse.Workouts[w].WorkRating + ", rank: " + CurrentEntry.ThisHorse.Workouts[w].WorkRank + ")" + "        ";
            //    strWorks2 += workraw + new String(' ', 60-workraw.Length);
            //}
            //Phrase phWorkTitle = new Phrase("Works:    ", smallboldfont);
            //Paragraph pWorks = new Paragraph();
            //pWorks.Add(phWorkTitle);
            //if (strWorks1 != "")
            //{
            //    Phrase phWorkDetails1 = new Phrase(strWorks1.Substring(0, strWorks1.Length - 8), smallfont);
            //    pWorks.Add(phWorkDetails1);
            //    pWorks.Add("\n");
            //}
            //if (strWorks2 != "")
            //{
            //    Phrase phWorkDetails2 = new Phrase(strWorks2.Substring(0, strWorks2.Length - 8), smallfont);
            //    pWorks.Add(phWorkDetails2);
            //}
            //PdfPCell cWorks = new PdfPCell(tWorks);
            //cWorks.Colspan = 17;
            //cWorks.BorderWidth = 0f;
            //cWorks.PaddingTop = 1f;
            ////cWorks.FixedHeight = 12;
            //cWorks.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
            //return cWorks;


            string strWorks = "";
            for (int w = 0; w < Math.Min(6,CurrentEntry.ThisHorse.Workouts.Length); w++)
                strWorks += /*CurrentEntry.ThisHorse.Workouts[w].WorkDate.ToString("ddMMM")*/ CurrentEntry.ThisHorse.Workouts[w].WorkDaysAgo + " days ago " + CurrentEntry.ThisHorse.Workouts[w].WorkCourse + " (" + CurrentEntry.ThisHorse.Workouts[w].WorksSurface + ") " + CurrentEntry.ThisHorse.Workouts[w].WorkDistance + "f " + CurrentEntry.ThisHorse.Workouts[w].WorkTime + (CurrentEntry.ThisHorse.Workouts[w].WorkRating > 0 ? " (rating " + CurrentEntry.ThisHorse.Workouts[w].WorkRating + ")" : "") + "        ";

            Phrase phWorkTitle = new Phrase("Works:    ", smallboldfont);
            Paragraph pWorks = new Paragraph();
            pWorks.Add(phWorkTitle);
            if (strWorks != "")
            {
                Phrase phWorkDetails = new Phrase(strWorks.Substring(0, strWorks.Length - 8), smallfont);
                pWorks.Add(phWorkDetails);
            }

            PdfPCell cWorks = new PdfPCell(pWorks);
            cWorks.Colspan = 23;
            cWorks.BorderWidth = 0f;
            cWorks.PaddingTop = 0f;
            cWorks.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
            return cWorks;
        }

        private PdfPCell CreateBrisStatsCell(Latekick.BOL.Base.Entry CurrentEntry)
        {

            string strBrisStats = "";
            for (int b = 0; b < CurrentEntry.BrisStats.Length; b++)
                strBrisStats += CurrentEntry.BrisStats[b].Category + " (" + CurrentEntry.BrisStats[b].Runs + " " + Math.Round(CurrentEntry.BrisStats[b].WinRatio) + "% $" + CurrentEntry.BrisStats[b].ROI + ")" + "        ";

            Phrase phBrisStatsTitle = new Phrase("Trainer:  ", smallboldfont);
            Paragraph pBrisStats = new Paragraph();
            pBrisStats.Add(phBrisStatsTitle);
            if (strBrisStats != "")
            {
                Phrase phWorkDetails = new Phrase(strBrisStats.Substring(0, strBrisStats.Length - 8), smallfont);
                pBrisStats.Add(phWorkDetails);
            }

            PdfPCell cBrisStats = new PdfPCell(pBrisStats);
            cBrisStats.Colspan = 23;
            cBrisStats.BorderWidth = 0f;
            cBrisStats.PaddingTop = 0f;
            cBrisStats.VerticalAlignment = PdfPCell.ALIGN_TOP;
            return cBrisStats;

            //PdfPTable tBrisStats = new PdfPTable(7);

            //PdfPCell cBrisStatsTitle = new PdfPCell(new Phrase("Trainer:", smallboldfont));
            //cBrisStatsTitle.BorderWidth = 0f;
            //cBrisStatsTitle.PaddingTop = 1f;
            //tBrisStats.AddCell(cBrisStatsTitle);

            //for (int b = 0; b < 6; b++)
            //{
            //    PdfPCell cBrisStat;
            //    if (b < CurrentEntry.BrisStats.Length)
            //        cBrisStat = new PdfPCell(new Phrase(CurrentEntry.BrisStats[b].Category + " (" + CurrentEntry.BrisStats[b].Runs + " " + CurrentEntry.BrisStats[b].WinRatio + " $" + CurrentEntry.BrisStats[b].ROI + ")", smallfont));
            //    else
            //        cBrisStat = new PdfPCell(new Phrase(""));
            //    cBrisStat.BorderWidth = 0f;
            //    cBrisStat.PaddingTop = 1f;
            //    tBrisStats.AddCell(cBrisStat);
            //}

            //PdfPCell cBrisStats = new PdfPCell(tBrisStats);
            //cBrisStats.Colspan = 23;
            //cBrisStats.BorderWidth = 0f;
            //cBrisStats.PaddingTop = 1f;
            //cBrisStats.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
            //return cBrisStats;
        }
        #endregion
    }
}
