using OutlookSafetyChex;
using System;
using System.Collections.Generic;

namespace CheccoSafetyTools
{
    abstract class cst_DNSBL
    {
        private static Dictionary<String, String> dnsblCache = new Dictionary<String, String>();

        static cst_DNSBL()
        {
        }

        public static void clearCaches()
		{
			dnsblCache.Clear();
		}

		public static String checkDNSBL(String ipaddr, bool use_CACHE)
		{
			String rc = null;
            List<String> spamLists = AddInSafetyCheck.getLocalDNSBL();
            if (!cst_Util.isValidCollection(spamLists))
                spamLists = AddInSafetyCheck.getCommonDNSBLsites();
            try
            {
                String tKey = ipaddr.Trim().ToLower();
                bool isCached = dnsblCache.TryGetValue(tKey, out rc);
                if (!use_CACHE || !isCached)
                {
                    SpamListlookup.VerifyIP IP = new SpamListlookup.VerifyIP(tKey, spamLists.ToArray());
                    if (IP.IPAddr.Valid)
                    {
                        if (IP.BlackList.IsListed)
                        {
                            rc = IP.BlackList.VerifiedOnServer;
                        }
                        if (!isCached) dnsblCache.Add(tKey, rc);
                    }
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "cst_DNSBL::checkDNSBL(" + ipaddr + ")");
            }
            return rc;
		}

	} // class
} // namespace
