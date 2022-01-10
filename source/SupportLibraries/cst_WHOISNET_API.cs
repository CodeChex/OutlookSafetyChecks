using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Whois.NET;

namespace CheccoSafetyTools
{
	abstract class cst_WHOISNET_API
	{
		public static Dictionary<String, String> whoisCache = new Dictionary<String, String>();

		public static void clearCaches()
		{
			whoisCache.Clear();
		}

		public static String whoisOwner(String fqdn,bool use_CACHE)
		{
			String rc = null;
            try
            {
                String tKey = cst_Util.getHonestString(fqdn).ToLower();
                bool isCached = whoisCache.TryGetValue(tKey, out rc);
                if (!use_CACHE || !isCached)
                {
                    Dictionary<String, String> rcData = queryWHOIS(tKey);
                    // find next best thing
                    foreach (String fld in new[] { "_OWNER", "REGISTRANT", "REGISTRANT ORGANIZATION", "ORGANISATION", "REGISTRANT NAME", "NAME", "RESELLER", "REGISTRAR" })
                    {
                        if (rcData.ContainsKey(fld)) rc = rcData[fld];
                        if (cst_Util.isValidString(rc)) break;
                    }
                    if (!isCached) whoisCache.Add(tKey, rc);
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_WHOISNET_API::whoisOwner(" + fqdn + ")");
            }
            return rc;
		}

		private static Dictionary<String,String> queryWHOIS(String tDomain, int nest = 0, String useRegistrar = null)
		{
			Dictionary<String,String> rc = null;
			try
			{
				WhoisResponse whois = WhoisClient.Query(tDomain, useRegistrar);
				rc = parseRawWHOIS(whois.Raw);
				if (nest < 5)
				{
					String tRegistrar = null;
					rc.TryGetValue("REGISTRAR WHOIS SERVER", out tRegistrar);
					if (cst_Util.isValidString(tRegistrar))
					{
						if (!tRegistrar.Equals(useRegistrar) && !whois.RespondedServers.Contains(tRegistrar))
						{
							// retry with this registrar
							rc = queryWHOIS(tDomain, nest + 1, tRegistrar);
						}
					}
				}
				if (cst_Util.isValidString(whois.OrganizationName))
				{
					rc["_OWNER"] = whois.OrganizationName;
				}
			}
			catch (Exception ex)
			{
				cst_Util.logException(ex, "cst_WHOISNET_API::queryWHOIS(" + tDomain + ")");
			}
			return rc;
		}

		private static Dictionary<String,String> parseRawWHOIS(String rawData)
		{
			 Dictionary<String,String> rc = new  Dictionary<String,String>();
			// splitting the headers into parseable lines
			String[] hdrDelims = { "\r\n", "\n\r", "\n", "\r", "\0" };
			String[] arrHeader = rawData.Split(hdrDelims, StringSplitOptions.None);
			// aggregating Received entries (may have multple lines)
			List<String> arrRECVD = new List<string>();
			String tName = null;
			foreach (String tHeader in arrHeader)
			{
				try
				{
					String[] arrT = tHeader.Trim().Split(new[] { ':' }, 2);
					if (arrT.Length > 1)
					{
						tName = arrT[0].Trim().ToUpper();
						String tValue = arrT[1].Trim();
						if (!rc.ContainsKey(tName))
						{
							rc.Add(tName, tValue);
						}
						else
						{
							if (rc[tName].Length > 0) rc[tName] += ", ";
							rc[tName] += " " + tValue;
						}
					}
					else if (cst_Util.isValidString(tName))
					{
						if (rc[tName].Length > 0) rc[tName] += ", ";
						rc[tName] += " " + tHeader.Trim();
					}
				}
				catch (Exception ex)
				{
					cst_Util.logException(ex, "cst_WHOISNET_API::parseRawDataBlock(" + tHeader + ")");
				}
			}
			return rc;
		}
	} // class
} // namespace
