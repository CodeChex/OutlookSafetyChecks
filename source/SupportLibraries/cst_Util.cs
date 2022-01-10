using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheccoSafetyTools
{
	abstract class cst_Util
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static IdnMapping idnMapping = new IdnMapping();
        public static Control ctlLogger = null;

        #region  Array/list utils
        public static bool isValidArray(dynamic[] tArr)
        {
            if (tArr == null) return false;
            return (tArr.Length > 0);
        }

        public static bool isValidCollection(IEnumerable<dynamic> tArr)
        {
            if (tArr == null) return false;
            return (tArr.Count() > 0);
        }

        #endregion

        #region string utils
        public static bool isValidString(String tStr, bool trimFirst = true)
        {
            if (tStr == null) return false;
            String chk = trimFirst ? tStr.Trim() : tStr;
            return (chk.Length > 0);
        }

        public static String pullDomain(String fqdn)
		{
			String rc = getHonestString(fqdn);
            try
            { 
			    String[] parts = fqdn.Split('.');
			    int Z = parts.Length - 1;
			    if (Z > 1) rc = parts[Z - 1] + "." + parts[Z];
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_Util::pullDomain(" + fqdn + ")");
            }
			// trying to be safe
			return rc;
		}

		public static String pullTLD(String fqdn)
		{
			String rc = getHonestString(fqdn);
            try
            {
                String[] parts = fqdn.Split('.');
			    int Z = parts.Length - 1;
			    if (Z > 0) rc = parts[Z];
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_Util::pullTLD(" + fqdn + ")");
            }
            // trying to be safe
            return rc;
		}

        public static bool isIPaddress(String tStr)
        {
            bool rc = false;
            try
            {
                if (isValidString(tStr))
                {
                    String rgxStr = "(\\d+\\.\\d+\\.\\d+\\.\\d+)";
                    Regex rgx = new Regex(rgxStr);
                    Match m = rgx.Match(tStr.Trim());
                    rc = (m.Groups.Count > 1);
                }
            }
			catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_Util::isIPaddress(" + tStr + ")");
			}
            return rc;
        }

        public static String getHonestString(String testString)
		{
			String rc = testString;
			try
			{
                if (cst_Util.isValidString(testString))
                {
                    rc = idnMapping.GetAscii(testString);
                }
			}
			catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_Util::getHonestString(" + testString + ")");
			}
			return rc;
		}

        #endregion

        #region web queries
        public static String wgetContentType(String tURL, Dictionary<String, String> arrHeaders = null)
        {
            String rc = null;
            WebHeaderCollection arr = wgetHead(tURL,arrHeaders);
            if (arr != null)
            {
                rc = arr.Get("Content-Type");
                if ( !cst_Util.isValidString(rc) ) rc = arr.Get("[Exception]");
            }
            return rc;
        }

        public static WebHeaderCollection wgetHead(String tURL, Dictionary<String,String> arrHeaders = null)
        {
            WebHeaderCollection rc = null;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                HttpWebRequest tReq = WebRequest.CreateHttp(tURL);
                tReq.Timeout = 2000;
                tReq.AllowAutoRedirect = true;
                tReq.Method = "HEAD";
                if (arrHeaders != null)
                {
                    foreach (String t in arrHeaders.Keys)
                    {
                        tReq.Headers.Add(t, arrHeaders[t]);
                    }
                }
                WebResponse tResp = tReq.GetResponse();
                if ( tResp != null )
                {
                    rc = tResp.Headers;
                }
            }
            catch (WebException we)
            {
                cst_Util.logException(we, "cst_Util::wgetHead(" + tURL + ")");
                rc.Add("[Exception]",we.Message);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_Util::wgetHead(" + tURL + ")");
                rc.Add("[Exception]", ex.Message);
            }
            return rc;
        }

        public static byte[] wgetBinary(String tURL, String[] allowableContentTypes = null, Dictionary<String, String> arrHeaders = null)
		{
			byte[] rc = null;
			try
			{
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                using (WebClient tClient = new WebClient())
				{
                    if (arrHeaders != null)
                    {
                        foreach (String t in arrHeaders.Keys)
                        {
                            tClient.Headers.Add(t,arrHeaders[t]);
                        }
                    }
                    rc = tClient.DownloadData(tURL);
                    // do we need to validate allowable content type?
                    if (allowableContentTypes != null && allowableContentTypes.Length > 0)
                    {
                        int foundContent = 0;
                        // Obtain the WebHeaderCollection instance containing the header name/value pair from the response.
                        WebHeaderCollection tResponseHeaders = tClient.ResponseHeaders;
                        // Loop through the ResponseHeaders and display the header name/value pairs.
                        String[] arrResp = tResponseHeaders.GetValues("Content-Type");
                        foreach (String tVal in arrResp)
                        {
                            foreach (String tContentType in allowableContentTypes)
                            {
                                if (tVal.StartsWith(tContentType, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    foundContent++;
                                }
                            }
                        }
                        if (foundContent == 0)
                        {
                            cst_Util.logInfo("No Allowable Content-Type Found", "cst_Util::wgetBinary(" + tURL + ")");
                            rc = null;
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                cst_Util.logException(webEx, "cst_Util::wgetData(" + tURL + ")");
            }
            catch (Exception ex)
			{
				cst_Util.logException(ex, "cst_Util::wgetData(" + tURL+")");
            }
			return rc;
		}

        public static String wgetString(String tURL, String[] allowableContentTypes = null, Dictionary<String, String> arrHeaders = null)
       {
            String rc = null;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                using (WebClient tClient = new WebClient())
                {
                    if (arrHeaders != null)
                    {
                        foreach (String t in arrHeaders.Keys)
                        {
                            tClient.Headers.Add(t,arrHeaders[t]);
                        }
                    }
                    rc = tClient.DownloadString(tURL);
                    // do we need to validate allowable content type?
                    if (allowableContentTypes != null && allowableContentTypes.Length > 0)
                    {
                        int foundContent = 0;
                        // Obtain the WebHeaderCollection instance containing the header name/value pair from the response.
                        WebHeaderCollection tResponseHeaders = tClient.ResponseHeaders;
                        // Loop through the ResponseHeaders and display the header name/value pairs.
                        String[] arrResp = tResponseHeaders.GetValues("Content-Type");
                        foreach ( String tVal in arrResp)
                        {
                            foreach ( String tContentType in allowableContentTypes )
                            {
                                if (tVal.StartsWith(tContentType, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    foundContent ++;
                                }
                            }
                        }
                        if ( foundContent == 0 )
                        {
                            cst_Util.logInfo("No Allowable Content-Type Found", "cst_Util::wgetString(" + tURL + ")");
                            rc = null;
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                cst_Util.logException(webEx, "cst_Util::wgetString(" + tURL + ")");
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_Util::wgetString(" + tURL + ")");
            }
            return rc;
        }

        public static HtmlAgilityPack.HtmlDocument wgetHTML(String tURL, Dictionary<String, String> arrHeaders = null)
        {
            HtmlAgilityPack.HtmlDocument rc = null;
            try
            {
                String results = cst_Util.wgetString(tURL, 
                                                     new[] { MediaTypeNames.Text.Html },
                                                     arrHeaders);
                if (cst_Util.isValidString(results))
                {
                    rc = new HtmlAgilityPack.HtmlDocument();
                    rc.LoadHtml(results);
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_Util::wgetHTML(" + tURL + ")");
            }
            return rc;
        }

        public static JToken wgetJSON(String tURL, Dictionary<String, String> arrHeaders = null)
        {
            JToken rc = null;
            try
            {
                String results = cst_Util.wgetString(tURL,
                                                     new[] { MediaTypeNames.Text.Plain, "application/json" },
                                                     arrHeaders);
                if (cst_Util.isValidString(results))
                {
                    rc = JToken.Parse(results);
                    /*
                    if ( results.StartsWith("{") ) rc = JObject.Parse(results);
                    else if (results.StartsWith("[") ) rc = JArray.Parse(results);
                    */
                 }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_Util::wgetJSON(" + tURL + ")");
            }
            return rc;
        }
        #endregion

        #region logging
        private static void prependLogUI(String s, bool erase = false)
        {
            if (ctlLogger != null)
            {
                try
                {
                    if (erase) ctlLogger.Text = "";
                    if (cst_Util.isValidString(s))
                    {
                        ctlLogger.Text = DateTime.Now + " - " + s.Trim() + "\r\n" + ctlLogger.Text;
                    }
                    ctlLogger.Refresh();
                }
                catch (Exception ex)
                {
                    log.Error("cst_Util::prependLogUI(...)", ex);
                }
            }
        }

        private static String prepareLogMsg(String details, String context)
        {
            String rc = "";
            if (cst_Util.isValidString(context))
            {
                rc += context.Trim();
            }
            if (cst_Util.isValidString(details))
            {
                rc += "\r\n\t" + details.Trim();
            }
            return rc;
        }

        public static void logInfo(String details, String context, bool erase = false)
        {
            if (cst_Util.isValidString(details))
            {
                String msg = cst_Util.prepareLogMsg(details,context);
                log.Info(msg);
                cst_Util.prependLogUI("[INFO]: " + msg, erase);
            }

        }
        public static void logException(Exception ex, String context, bool erase = false)
        {
            if (ex != null)
            {
                String msg = cst_Util.prepareLogMsg(ex.Message, context);
                log.Error(context,ex);
                cst_Util.prependLogUI("[EXCEPTION]: " + msg, erase);
            }

        }
        
        public static void setLoggingUI(Control n)
        {
            ctlLogger = n;
        }
        #endregion

    } // class
} // namespace
