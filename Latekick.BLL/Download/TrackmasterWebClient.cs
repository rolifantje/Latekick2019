using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Latekick.BLL.Download
{
    public class TrackmasterWebClient : WebClient
    {
        /// <summary>
        /// Backing field to hold the <see cref="T:System.Net.CookieContainer"/> used by the instance.
        /// </summary>
        private CookieContainer cookieContainer;

        private string userName, password;

        public TrackmasterWebClient(string username, string pass)
        {
            this.userName = username;
            this.password = pass;
            this.Credentials = new NetworkCredential(username, pass);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="T:System.Net.CookieContainer"/> to be used 
        /// with this instance.
        /// </summary>
        public CookieContainer CookieContainer
        {
            get
            {
                // Create an instance of CookieContainer if one hasn't been created yet.
                if (this.cookieContainer == null)
                {
                    this.CookieContainer = new CookieContainer();
                }

                return this.cookieContainer;
            }

            set
            {
                this.cookieContainer = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Net.WebRequest"/> object for the specified resource.
        /// </returns>
        /// <param name="address">A <see cref="T:System.Uri"/> that identifies the resource to request.</param>
        protected override WebRequest GetWebRequest(System.Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;

            if (request != null)
            {
                request.CookieContainer = this.CookieContainer;
            }

            return request;
        }

        public void DownloadEntries(string address, string referer, string filelocation)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            //request.Accept = "text/html, application/xhtml+xml, */*";
            //request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Referer = referer;
            request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            request.Host = "www.trackmaster.com";
            request.Headers.Add("DNT: 1");

            request.CookieContainer = this.CookieContainer;
            try
            {
                var httpWebResponse = (HttpWebResponse)request.GetResponse();

                using (var streampje = httpWebResponse.GetResponseStream())
                {
                    var streamReader = new StreamReader(streampje);
                    string filename = filelocation;

                    byte[] buffer = new byte[1024];
                    FileStream outFile = new FileStream(filename, FileMode.Create);

                    int bytesRead;
                    while ((bytesRead = streampje.Read(buffer, 0, buffer.Length)) != 0)
                        outFile.Write(buffer, 0, bytesRead);

                    outFile.Close();
                }
            }
            catch (Exception e4)
            {
                System.Diagnostics.Debug.WriteLine(e4.Message);
            }
        }

        public void Login()
        {
            //var values = new NameValueCollection
            //    {
            //        { "_token", "JL4IgSUMr0MbC5AlJwZCg0sKuqSXwLHKdtVzctsH" },
            //        { "custom_id", ConfigurationManager.AppSettings.Get("TM_Username")  },
            //        { "password", ConfigurationManager.AppSettings.Get("TM_Password") }
            //    };

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "custom_id=" + this.userName + "&password=" + this.password;

            HttpWebRequest requestInit = (HttpWebRequest)WebRequest.Create("https://www.trackmaster.com");
            requestInit.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            //requestInit.Headers["Accept-Encoding"] = "gzip, deflate, br";
            requestInit.Method = "GET";
            requestInit.Host = "www.trackmaster.com";

            Cookie cx = null, la = null, rw = null;
            CookieCollection cc = new CookieCollection();
            using (var httpWebResponse = (HttpWebResponse)requestInit.GetResponse())
            {
                String setCookieHeader = httpWebResponse.Headers[HttpResponseHeader.SetCookie];
                ArrayList al = ConvertCookieHeaderToArrayList(setCookieHeader);
                cc = ConvertCookieArraysToCookieCollection(al, "trackmaster.com");
                cx = cc["XSRF-TOKEN"];
                la = cc["laravel_session"];

                using (var stream = httpWebResponse.GetResponseStream())
                {
                    var reader = new StreamReader(stream, encoding);
                    var responseString = reader.ReadToEnd();
                    string token = Regex.Match(responseString, "_token.+?value=\"(.+?)\"").Groups[1].Value;
                    postData = "_token=" + token + "&" + postData;
                }
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.trackmaster.com/login");
            request.Method = "POST";
            request.AllowAutoRedirect = false;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "en-GB,en;q=0.9,en-US;q=0.8,nl;q=0.7,de;q=0.6,fr;q=0.5";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            request.Headers["Cache-Control"] = "max-age=0";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] postDataBytes = encoding.GetBytes(postData);

            request.ContentLength = postDataBytes.Length;
            request.Host = "www.trackmaster.com";
            request.Referer = "https://www.trackmaster.com/login";
            //request.Headers["Origin"] = "https://www.trackmaster.com";

            //request.Headers.Add("XSRF-TOKEN", cx.Value);
            //request.Headers.Add("laravel_session", la.Value);

            //cc.Add()

            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cc);

            using (var stream = request.GetRequestStream())
            {
                stream.Write(postDataBytes, 0, postDataBytes.Length);
                stream.Close();
            }

            using (var httpWebResponse = (HttpWebResponse)request.GetResponse())
            {
                using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    foreach (Cookie cookie in httpWebResponse.Cookies)
                    {
                        this.CookieContainer.Add(cookie);
                    }

                    String setCookieHeader = httpWebResponse.Headers[HttpResponseHeader.SetCookie];
                    ArrayList al = ConvertCookieHeaderToArrayList(setCookieHeader);

                    CookieCollection cc3 = ConvertCookieArraysToCookieCollection(al, "trackmaster.com");
                    this.CookieContainer.Add(cc3);

                    //this.CookieContainer.SetCookies(new Uri("http://localhost"), setCookieHeader);
                    //if (setCookieHeader != null)
                    //{
                    //    try
                    //    {
                    //        Match match = Regex.Match(setCookieHeader, "(.*?)=(.*?)($|;|,(?! ))");
                    //        if (match.Captures.Count > 0)
                    //        {
                    //            CookieContainer.Add(new Cookie(match.Groups[1].Value, match.Groups[2].Value, "/", "trackmaster.com"));
                    //            CookieContainer.Add(new Cookie("user_name", "topspeed", "/", "trackmaster.com"));
                    //            System.Diagnostics.Debug.Write("GGG");
                    //        }
                    //        //Cookie cookie = new Cookie("www.trackmaster.com", setCookieHeader);
                    //        //this.CookieContainer.Add(cookie);
                    //    }
                    //    catch(Exception e3)
                    //    {
                    //        System.Diagnostics.Debug.WriteLine(e3.Message);
                    //    }
                    //}
                }
            }
        }

        private ArrayList ConvertCookieHeaderToArrayList(string strCookHeader)
        {
            strCookHeader = strCookHeader.Replace("\r", "");
            strCookHeader = strCookHeader.Replace("\n", "");
            string[] strCookTemp = strCookHeader.Split(',');
            ArrayList al = new ArrayList();
            int i = 0;
            int n = strCookTemp.Length;
            while (i < n)
            {
                if (strCookTemp[i].IndexOf("expires=", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    al.Add(strCookTemp[i] + "," + strCookTemp[i + 1]);
                    i = i + 1;
                }
                else
                {
                    al.Add(strCookTemp[i]);
                }
                i = i + 1;
            }
            return al;
        }

        private CookieCollection ConvertCookieArraysToCookieCollection(ArrayList al, string strHost)
        {
            CookieCollection cc = new CookieCollection();

            int alcount = al.Count;
            string strEachCook;
            string[] strEachCookParts;
            for (int i = 0; i < alcount; i++)
            {
                strEachCook = al[i].ToString();
                strEachCookParts = strEachCook.Split(';');
                int intEachCookPartsCount = strEachCookParts.Length;
                string strCNameAndCValue = string.Empty;
                string strPNameAndPValue = string.Empty;
                string strDNameAndDValue = string.Empty;
                string[] NameValuePairTemp;
                Cookie cookTemp = new Cookie();

                for (int j = 0; j < intEachCookPartsCount; j++)
                {
                    if (j == 0)
                    {
                        strCNameAndCValue = strEachCookParts[j];
                        if (strCNameAndCValue != string.Empty)
                        {
                            int firstEqual = strCNameAndCValue.IndexOf("=");
                            string firstName = strCNameAndCValue.Substring(0, firstEqual);
                            string allValue = strCNameAndCValue.Substring(firstEqual + 1, strCNameAndCValue.Length - (firstEqual + 1));
                            cookTemp.Name = firstName;
                            cookTemp.Value = allValue;
                        }
                        continue;
                    }
                    if (strEachCookParts[j].IndexOf("path", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        strPNameAndPValue = strEachCookParts[j];
                        if (strPNameAndPValue != string.Empty)
                        {
                            NameValuePairTemp = strPNameAndPValue.Split('=');
                            if (NameValuePairTemp[1] != string.Empty)
                            {
                                cookTemp.Path = NameValuePairTemp[1];
                            }
                            else
                            {
                                cookTemp.Path = "/";
                            }
                        }
                        continue;
                    }

                    if (strEachCookParts[j].IndexOf("domain", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        strPNameAndPValue = strEachCookParts[j];
                        if (strPNameAndPValue != string.Empty)
                        {
                            NameValuePairTemp = strPNameAndPValue.Split('=');

                            if (NameValuePairTemp[1] != string.Empty)
                            {
                                cookTemp.Domain = NameValuePairTemp[1];
                            }
                            else
                            {
                                cookTemp.Domain = strHost;
                            }
                        }
                        continue;
                    }
                }

                if (cookTemp.Path == string.Empty)
                {
                    cookTemp.Path = "/";
                }
                if (cookTemp.Domain == string.Empty)
                {
                    cookTemp.Domain = strHost;
                }
                cc.Add(cookTemp);
            }
            return cc;
        }
        #endregion
    }
}