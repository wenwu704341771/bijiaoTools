using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace SoftwarerAchitecture.DBUtility.BaseWork
{
    public class CommonController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="returnxml">返回xml字符串</param>
        /// <param name="jrBehavior"></param>
        /// <returns></returns>
        public new ActionResult Json(object obj, bool returnxml = false, JsonRequestBehavior jrBehavior = JsonRequestBehavior.AllowGet)
        {
            Newtonsoft.Json.Converters.IsoDateTimeConverter jsonsettingconvert = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            jsonsettingconvert.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            Newtonsoft.Json.JsonSerializerSettings jsonsetting = new Newtonsoft.Json.JsonSerializerSettings();
            jsonsetting.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            jsonsetting.Converters.Add(jsonsettingconvert);

            var str = Newtonsoft.Json.JsonConvert.SerializeObject(obj, jsonsetting);
            return Content(str, "text/json", UTF8Encoding.UTF8);//base.Json(obj, jrBehavior);
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            // Always accept
            //Debug.Print("accept" + certificate.GetName())
            return true;
            //总是接受
        }
        /// <summary>
        /// 获取页面数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postPara"></param>
        /// <param name="cookies"></param>
        /// <param name="hasCookie"></param>
        /// <param name="encType"></param>
        /// <param name="refer"></param>
        /// <param name="Host"></param>
        /// <param name="Origin"></param>
        /// <param name="ContentType"></param>
        /// <returns></returns>
        public static string GetPage(string url, string postPara, CookieCollection cookies, bool hasCookie, string encType = "GB2312", string refer = "", string Host = "", string Origin = "", string ContentType = "")
        {
            try
            {
                System.GC.Collect();
                string functionReturnValue = null;
                //if ((url.StartsWith("http://") == false))
                //{
                //    url = "http://" + url;
                //}
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                HttpWebRequest hRqst = (HttpWebRequest)(HttpWebRequest.Create(url));
                hRqst.AllowAutoRedirect = false;
                if ((hasCookie == true && ((cookies != null))))
                {
                    hRqst.CookieContainer = new CookieContainer(500, 50, 4096);
                    hRqst.CookieContainer.Add(cookies);
                }
                //string x =ServicePointManager.SecurityProtocol.ToString();

                if (!string.IsNullOrEmpty(ContentType))
                {
                    hRqst.ContentType = ContentType;
                }
                else
                {

                    hRqst.ContentType = "application/x-www-form-urlencoded";

                }

                hRqst.Headers.Add("Accept-Language", "zh-cn");
                hRqst.Headers.Add("Accept-Encoding", "gzip, deflate");
                hRqst.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
                hRqst.Referer = refer;
                if (!string.IsNullOrEmpty(Host))
                {
                    hRqst.Host = Host;
                }
                if (!string.IsNullOrEmpty(Origin))
                {
                    hRqst.Headers.Add("Origin", Origin);
                }
                hRqst.KeepAlive = true;
                hRqst.Timeout = 15000;
                if (url.Contains(".do"))
                {
                    hRqst.Headers.Add("shy-invoke", "true");
                }
                Stream streamData = default(Stream);
                byte[] bt = null;
                if ((string.IsNullOrEmpty(postPara)))
                {
                    hRqst.Method = "GET";
                }
                else
                {
                    hRqst.Method = "POST";
                    hRqst.AllowWriteStreamBuffering = true;
                    bt = System.Text.Encoding.ASCII.GetBytes(postPara);
                    hRqst.ContentLength = bt.Length;
                    streamData = hRqst.GetRequestStream();
                    streamData.Write(bt, 0, bt.Length);
                    streamData.Close();
                }

                HttpWebResponse hRsp = default(HttpWebResponse);
                hRsp = (System.Net.HttpWebResponse)(hRqst.GetResponse());
                if ((hasCookie == true && ((hRsp.Cookies != null))))
                {
                    cookies.Add(hRsp.Cookies);
                }

                //if (hRsp.StatusCode == HttpStatusCode.Redirect)
                //{
                string redurl = hRsp.Headers["Location"];
                if (redurl != null)
                {
                    if (!redurl.StartsWith("http"))
                    {
                        int ins = url.IndexOf("/", 8);
                        redurl = url.Substring(0, ins) + redurl;
                    }
                    return GetPage(redurl, "", cookies, hasCookie, encType, refer);
                }
                //}
                functionReturnValue = GetResponseBody(hRsp, encType);

                //streamData = hRsp.GetResponseStream();
                //System.IO.StreamReader readStream = new System.IO.StreamReader(streamData, System.Text.Encoding.GetEncoding(encType));
                //functionReturnValue = readStream.ReadToEnd();
                //streamData.Close(); 
                streamData = null;
                //readStream.Close(); readStream = null;
                hRsp.Close(); hRsp = null;
                hRqst.Abort(); hRqst = null;
                return functionReturnValue;
            }
            catch (Exception ex)
            {
                return ("Err " + ex.Message);
            }
        }

        private static string GetResponseBody(HttpWebResponse response, string encType)
        {
            string responseBody = string.Empty;
            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                using (GZipStream stream = new GZipStream(
                    response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader =
                        new StreamReader(stream, Encoding.GetEncoding(encType)))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            else if (response.ContentEncoding.ToLower().Contains("deflate"))
            {
                using (DeflateStream stream = new DeflateStream(
                    response.GetResponseStream(), CompressionMode.Decompress))
                {
                    using (StreamReader reader =
                        new StreamReader(stream, Encoding.GetEncoding(encType)))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            else
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader =
                        new StreamReader(stream, Encoding.GetEncoding(encType)))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }
            }
            return responseBody;
        }

        public static string CutString(int StartPoint, string OriginalString, string StartString, string EndString, ref int ine)
        {
            try
            {
                string returnValue = "";
                int ins = 0;
                if (StartPoint == 0)
                {
                    returnValue = "";
                    return returnValue;
                }
                ins = OriginalString.IndexOf(StartString, StartPoint - 1) + 1;
                ine = OriginalString.IndexOf(EndString, ins + StartString.Length - 1) + 1;
                if (ins == 0 || ine == 0 || StartPoint == 0)
                {
                    returnValue = "";
                    return returnValue;
                }
                returnValue = OriginalString.Substring(ins + StartString.Length - 1, System.Convert.ToInt32(ine - ins) - StartString.Length);
                return returnValue;
            }
            catch
            {
                return "";
            }
        }

        public static string CutString(string StartFindString, string OriginalString, string StartString, string EndString, ref int ine)
        {
            string returnValue = "";
            int ins = 0;
            int StartPoint = OriginalString.IndexOf(StartFindString) + 1;
            if (StartPoint == 0)
            {
                returnValue = "";
                return returnValue;
            }
            ins = OriginalString.IndexOf(StartString, StartPoint - 1) + 1;
            ine = OriginalString.IndexOf(EndString, ins + StartString.Length - 1) + 1;
            if (ins == 0 || ine == 0 || StartPoint == 0)
            {
                returnValue = "";
                return returnValue;
            }
            returnValue = OriginalString.Substring(ins + StartString.Length - 1, System.Convert.ToInt32(ine - ins) - StartString.Length);
            return returnValue;
        }
    }
}
