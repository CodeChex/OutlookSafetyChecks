using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CheccoSafetyTools
{
    abstract class cst_WHOISXML_API
	{
        private static String API_KEY = OutlookSafetyChex.Properties.Settings.Default.WhoisXml_ApiKey;

        private readonly static String WHOIS_URL = "https://www.whoisxmlapi.com/whoisserver/WhoisService?outputFormat=JSON&apiKey=" + API_KEY +"&";
		private readonly static String GEOIP_URL = "https://ip-geolocation.whoisxmlapi.com/api/v1?outputFormat=JSON&apiKey=" + API_KEY + "&";

		private readonly static Dictionary<String, JToken> whoisCache = new Dictionary<String, JToken>();
		private readonly static Dictionary<String, JToken> geoCache = new Dictionary<String, JToken>();

		public static void clearCaches()
		{
			whoisCache.Clear();
			geoCache.Clear();
		}

		private static List<String> lookupHost(String tHost, out List<String> arrGEO)
		{
			List<String> arrOWNER = null;
			arrGEO = null;
			try
			{
				String inStr = tHost.ToLower().Trim();
				switch ( Uri.CheckHostName(inStr) )
				{
					case UriHostNameType.Dns:
						if (!inStr.Equals("localhost"))
						{
							arrOWNER = checkWHOIS(inStr);
						}
						break;
					case UriHostNameType.IPv4:
					case UriHostNameType.IPv6:
						if (!inStr.StartsWith("127.") && !inStr.StartsWith("10.") && !inStr.StartsWith("172."))
						{
							arrOWNER = checkWHOIS(inStr);
							arrGEO = geoLocateIP(inStr);
						}
						break;
				}
			}
			catch (Exception ex)
			{
				cst_Util.logException(ex, "cst_WHOISXML_API::lookupHost(" + tHost+")");
			}
			return arrOWNER;
		}

		/* WHOISXML_API output
		{
		 "WhoisRecord": {
			"registryData": {  ?????
				  "createdDate": "1996-05-28T04:00:00Z",
				  "updatedDate": "1996-05-28T04:00:00Z",
				  "expiresDate": "2020-05-27T04:00:00Z",
				  "registrant": {
					 "name": "John Checco",
					 "organization": "Checco Services",
					 "street1": "33 Capt Faldermeyer Dr",
					 "city": "Stony Point",
					 "state": "NY",
					 "postalCode": "10980",
					 "country": "UNITED STATES",
					 "countryCode": "US",
					 "email": "john.checco@checco.com",
					 "telephone": "18459424246",
					 "rawText": "Registrant Name: John Checco\nRegistrant Organization: Checco Services\nRegistrant Street: 33 Capt Faldermeyer Dr\nRegistrant City: Stony Point\nRegistrant State/Province: NY\nRegistrant Postal Code: 10980\nRegistrant Country: US\nRegistrant Phone: +1.8459424246\nRegistrant Email: john.checco@checco.com"
				  },
				  "domainName": "checco.com",
				  "status": "clientTransferProhibited",
				  "parseCode": 3579,
				  "header": "",
				  "footer": "\n",
				  "registrarName": "Register.com, Inc.",
				  "registrarIANAID": "9",
				  "whoisServer": "whois.register.com",
				  "createdDateNormalized": "1996-05-28 04:00:00 UTC",
				  "updatedDateNormalized": "1996-05-28 04:00:00 UTC",
				  "expiresDateNormalized": "2020-05-27 04:00:00 UTC",
				  "contactEmail": "john.checco@checco.com",
				  "domainNameExt": ".com",
				  "estimatedDomainAge": 7967
			   }
			}
		}
 		*/
		private static KeyValuePair<String, String> parseWhoisJSON(JToken json)
		{
			KeyValuePair<String, String> rc = new KeyValuePair<String, String>();
			try
			{
				if (json != null)
				{
					String tDomain = null;
					foreach (JToken tTok in json.SelectTokens("..domainName"))
					{
						tDomain = tTok.Value<String>();
						// stop at the first instance
						if (cst_Util.isValidString(tDomain)) break;
					}
					if (cst_Util.isValidString(tDomain))
					{
						String tOrganization = "[unknown]";
						String tCountry = "-";
						foreach (JToken tRegistrant in json.SelectTokens("..registrant"))
						{
							tOrganization = tRegistrant.Value<String>("organization");
							if (!cst_Util.isValidString(tOrganization))
							{
								tOrganization = tRegistrant.Value<String>("name");
							}
							tCountry = tRegistrant.Value<String>("countryCode");
							// stop at the first instance
							if (cst_Util.isValidString(tOrganization)) break;
						}
						String tDesc = tOrganization + " (" + tCountry + ")";
						rc = new KeyValuePair<String, String>(tDomain, tDesc);
					}
				}
			}
			catch (Exception ex)
			{
				cst_Util.logException(ex, "cst_WHOISXML_API::parseWhoisJSON");

            }
			return rc;
		}

		public static List<String> checkWHOIS(String tHost)
		{
			List<String> rc = new List<String>();
			try
			{
				String inStr = tHost.ToLower().Trim();
                JToken json = null;
				if (!whoisCache.TryGetValue(inStr, out json) || json == null)
				{
					String tURL = WHOIS_URL + "domainName=" + inStr;
					json = cst_Util.wgetJSON(tURL);
					if (json != null) whoisCache.Add(inStr, json);
				}
				rc.Add(parseWhoisJSON(json).Value);
			}
			catch (Exception ex)
			{
                cst_Util.logException(ex, "cst_WHOISXML_API::checkWHOIS(" + tHost + ")");
            }
            return rc;
		}

		#region geoIP
		/* example GEOIP output
			{
			   "ip": "8.8.8.8",
			   "location": {
				  "country": "US",
				  "region": "California",
				  "city": "Mountain View",
				  "lat": 37.40599,
				  "lng": -122.078514,
				  "postalCode": "94043",
				  "timezone": "-08:00"
			   }
			}
		*/
		private static KeyValuePair<String, String> parseGeoipJSON(JToken json)
		{
			KeyValuePair<String, String> rc = new KeyValuePair<String, String>();
			try
			{
				if (json != null)
				{
					String tIPAddr = null;
					foreach (JToken tRec in json.SelectTokens("..ip")) { 
						tIPAddr = tRec.Value<String>();
						if ( cst_Util.isValidString(tIPAddr)) break; // stop at the first instance
					}
					if (cst_Util.isValidString(tIPAddr))
					{
						String tCountry = "[unknown]";
						String tRegion = "-";
						String tCity = "-";
						foreach ( JToken tLocation in json.SelectTokens("..location"))
						{
							tCountry = tLocation.Value<String>("country");
							tRegion = tLocation.Value<String>("region");
							tCity = tLocation.Value<String>("city");
							if (cst_Util.isValidString(tCountry)) break; // stop at the first good instance
						}
						String tDesc = tCountry + " / " + tRegion + " / " + tCity;
						rc= new KeyValuePair<String,String>(tIPAddr, tDesc);
					}
				}
			}
			catch (Exception ex)
			{
                cst_Util.logException(ex, "cst_WHOISXML_API::parseGeoipJSON()");
            }
            return rc;
		}

		public static List<String> geoLocateIP(String tIPAddr)
		{
			List<String> rc = new List<String>();
			try
			{
				String inStr = tIPAddr.ToLower().Trim();
                JToken json = null;
				if (!geoCache.TryGetValue(inStr, out json) || json == null)
				{
					String tURL = GEOIP_URL + "ipAddress=" + inStr;
					json = cst_Util.wgetJSON(tURL);
					if (json != null) geoCache.Add(inStr, json);
				}
				rc.Add(parseGeoipJSON(json).Value);
			}
			catch (Exception ex)
			{
                cst_Util.logException(ex, "cst_WHOISXML_API::geoLocateIP(" + tIPAddr + ")");
            }
            return rc;
		}
		#endregion

		public static String whoisOwner(String fqdn,bool use_CACHE)
		{
			String rc = null;
			String tKey = fqdn.ToLower();
			try
			{
				List<String> arrOWNER, arrGEO;
				arrOWNER = lookupHost(tKey, out arrGEO);
				if ( arrOWNER != null )
				{
					rc = "";
					foreach (String t in arrOWNER)
					{
						rc += "ORGANIZATION: " + t + "\r\n";
					}
				}
				if ( arrGEO!= null )
				{
					foreach (String t in arrGEO)
					{
						rc += "GEO-LOCATION: " + t + "\r\n";
					}
				}
			}
			catch (Exception ex)
			{
                cst_Util.logException(ex, "cst_WHOISXML_API::whoisOwner(" + fqdn + ")");
            }
            return rc;
		}

	} // class
} // namespace
