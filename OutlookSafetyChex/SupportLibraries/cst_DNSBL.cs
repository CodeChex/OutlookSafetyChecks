using OutlookSafetyChex;
using System;
using System.Collections.Generic;

namespace CheccoSafetyTools
{
    public class cst_DNSBL
    {
        private static Dictionary<String, String> dnsblCache = new Dictionary<String, String>();

        public List<String> arrDNSBL = null;
        private cst_Log mLogger = null;

        public cst_DNSBL(cst_Log tLogger)
        {
            mLogger = tLogger;
        }

        public void clearCaches()
		{
            cst_DNSBL.dnsblCache.Clear();
		}

 		public String checkDNSBL(String ipaddr, bool use_CACHE)
		{
			String rc = null;
            try
            {
                String tKey = ipaddr.Trim().ToLower();
                bool isCached = cst_DNSBL.dnsblCache.TryGetValue(tKey, out rc);
                if (!use_CACHE || !isCached)
                {
                    SpamListlookup.VerifyIP IP = new SpamListlookup.VerifyIP(tKey, arrDNSBL.ToArray());
                    if (IP.IPAddr.Valid)
                    {
                        if (IP.BlackList.IsListed)
                        {
                            rc = IP.BlackList.VerifiedOnServer;
                        }
                        if (!isCached) cst_DNSBL.dnsblCache.Add(tKey, rc);
                    }
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "cst_DNSBL::checkDNSBL(" + ipaddr + ")");
            }
            return rc;
		}

	} // class
} // namespace
