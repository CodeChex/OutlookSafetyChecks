using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheccoSafetyTools
{
    abstract class cst_DNSBL
    {
        private static Dictionary<String, String> dnsblCache = new Dictionary<String, String>();

        public static readonly String[] defaultSpamLists = new[] { "sbl-xbl.spamhaus.org", "bl.spamcop.net" };
        public static String[] spamLists = new String[] { };

        static cst_DNSBL()
        {
            cst_DNSBL.spamLists = cst_DNSBL.defaultSpamLists;
        }

        public static void clearCaches()
		{
			dnsblCache.Clear();
		}

		public static String checkDNSBL(String ipaddr, bool use_CACHE)
		{
			String rc = null;
            try
            {
                String tKey = ipaddr.Trim().ToLower();
                bool isCached = dnsblCache.TryGetValue(tKey, out rc);
                if (!use_CACHE || !isCached)
                {
                    SpamListlookup.VerifyIP IP = new SpamListlookup.VerifyIP(tKey, spamLists);
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
