using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

using Latekick.BOL;

namespace Latekick.BLL.Download
{
    public class TrackmasterDownloader
    {
        TrackmasterWebClient TMC;
        string downloadLocation;

        public TrackmasterDownloader(string user, string pass)
        {
            TMC = new TrackmasterWebClient(user, pass);
            TMC.Login();
        }

        public void DownloadRaceCard(DateTime racedate, string coursecode)
        {
            DirectoryInfo diTrackmaster = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LKData" + "\\Trackmaster\\" + racedate.ToString("ddMMMyyyy"));
            if (diTrackmaster.Exists)
                diTrackmaster.Create();
            downloadLocation = diTrackmaster.FullName; 
            try
            {
                string filename = coursecode.ToLower() + racedate.Year + (racedate.Month < 10 ? "0" : "") + racedate.Month + (racedate.Day < 10 ? "0" : "") + racedate.Day + "ppsxml.zip";
                string url = String.Format(@"https://www.trackmaster.com/products/tpp/access/TM_WEB/{0}", filename);

                try
                {
                    //TMC.Headers["Referer"] = String.Format(@"https://www.trackmaster.com/products/tpp/message/TM_WEB/{0}", racecards[i]);
                    //TMC.Headers["UserAgent"] = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                    //TMC.Headers["Host"] = "www.trackmaster.com";
                    //TMC.Headers["DNT"] = "1";

                    //byte[] tt = TMC.DownloadData(url);
                    //File.WriteAllBytes(downloadfilepath, tt);
                    //TMC.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                    //TMC.Headers["Accept-Encoding"] = "gzip, deflate";
                    //string ffs = TMC.DownloadString(url);

                    TMC.DownloadEntries(url, String.Format(@"https://www.trackmaster.com/products/tpp/message/TM_WEB/{0}", filename), downloadLocation + "\\" + coursecode + ".zip");
                    //Program.PR.SendProgressMessage("File " + racecards[i] + " was downloaded.");
                }
                catch(Exception e2)
                {
                    //Program.PR.SendProgressMessage("File " + racecards[i] + " could not be downloaded.");
                }
            }
            catch (Exception e2)
            {
                throw e2;
            }
        }
    }
}