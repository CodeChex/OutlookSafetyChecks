using CheccoSafetyTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtRoutesCheck : dtTemplate
    {
        private static readonly String logArea = Properties.Resources.Title_Routing + " (Check)";
        public dtRoutesCheck()
        {
            this.Columns.Add("Host/IP", Type.GetType("System.String"));
            this.Columns.Add("Owner", Type.GetType("System.String"));
            this.Columns.Add("Notes", Type.GetType("System.String"));
        }

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
			List<String> dctSVRs = new List<String>(); // SERVERNAME --> IP
			List<String> dctIPs = new List<String>(); // IP --> ARIN Owner                                                            // parse received lines
            dtRouteList arrRoutes = parent.findTableClass<dtRouteList>() as dtRouteList;
            if (arrRoutes != null )
            {
                if (arrRoutes.Rows.Count == 0) 
                { 
                    arrRoutes.populate(false); 
                }
                if (arrRoutes.Rows.Count == 0)
                {
                    String tReason = "Route List is EMPTY";
                    parent.logFinding(Properties.Resources.Title_Routing, "4", "ROUTE LIST", tReason);
                }
                foreach ( DataRow tRow in arrRoutes.Rows)
                {
					int i = 0;
                    String tHop = tRow.ItemArray[i++] as String;
                    String tRaw = tRow.ItemArray[i++] as String; ;
                    String tFROM = tRow.ItemArray[i++] as String; ;
					String tFROM_HOST = tRow.ItemArray[i++] as String; ;
					String tFROM_IP = tRow.ItemArray[i++] as String; ;
					String tBY = tRow.ItemArray[i++] as String; ;
					String tBY_HOST = tRow.ItemArray[i++] as String; ;
					String tBY_APP = tRow.ItemArray[i++] as String; ;
					String tWITH = tRow.ItemArray[i++] as String; ;
					String tID = tRow.ItemArray[i++] as String; ;
					String tFOR = tRow.ItemArray[i++] as String; ;
					String tTIMESTAMP = tRow.ItemArray[i++] as String;
                    if (cst_Util.isValidString(tBY_HOST))
                    {
                        if (instance.mWebUtil.isValidIPAddress(tBY_HOST))
                            dctIPs.Add(tBY_HOST.ToLower().Trim());
                        else
                            dctSVRs.Add(tBY_HOST.ToLower().Trim());
                    }
                    if (cst_Util.isValidString(tFROM_HOST))
                    {
                        if (instance.mWebUtil.isValidIPAddress(tFROM_HOST))
                            dctIPs.Add(tFROM_HOST.ToLower().Trim());
                        else
                            dctSVRs.Add(tFROM_HOST.ToLower().Trim());
                    }
                    if (instance.mWebUtil.isValidIPAddress(tFROM_IP))
                    {
                        dctIPs.Add(tFROM_IP.ToLower().Trim());
                    }
				}
			}
            // list all hosts used here
            if (mLogger != null)
                mLogger.logInfo("Inspecting [" + dctSVRs.Count + "] Routing Hosts", logArea);
            foreach (String tHost in dctSVRs.Distinct())
            {
                // New Row
                String tDomain = instance.mWebUtil.pullDomain(tHost);
                String tOwner = "[not checked]";
                String tNotes = "";
                if (Uri.CheckHostName(tHost) == UriHostNameType.Dns && !tHost.Equals("localhost"))
                {
                    // start checks
                    String tReason = instance.suspiciousHost(tHost);
                    if (cst_Util.isValidString(tReason))
                    {
                        tNotes += tReason;
						parent.logFinding(Properties.Resources.Title_Routing, "4", "HOST", tReason);
					}
					if (Properties.Settings.Default.opt_Lookup_WHOIS)
                    {
                        tOwner = instance.mWHOIS.whoisOwner(tDomain, Properties.Settings.Default.opt_Use_CACHE);
 					}
					// display
					String[] rowData = new[] { tHost, tOwner, tNotes };
					this.addDataRow(rowData);
				}
			}
            // list all IPs used here
            if (mLogger != null)
                mLogger.logInfo("Inspecting [" + dctIPs.Count + "] Routing IPs", logArea);
            foreach (String tIPAddr in dctIPs.Distinct())
			{
				String tOwner = "[not checked]";
				String tNotes = "";
				if (Uri.CheckHostName(tIPAddr) == UriHostNameType.IPv4)
                {
                    if (!tIPAddr.StartsWith("127.") && !tIPAddr.StartsWith("10.") && !tIPAddr.StartsWith("172."))
                    {
                        // start checks
                        String tReason = instance.suspiciousIP(tIPAddr);
                        if (cst_Util.isValidString(tReason))
                        {
                            tNotes += tReason;
							parent.logFinding(Properties.Resources.Title_Routing, "4", "IP-ADDRESS", tReason);
						}
						if (Properties.Settings.Default.opt_Lookup_WHOIS)
                        {
                            tOwner = instance.mWHOIS.whoisOwner(tIPAddr, Properties.Settings.Default.opt_Use_CACHE);
						}
						// display
						String[] rowData = new[] { tIPAddr, tOwner, tNotes };
						this.addDataRow(rowData);
					}
				}
            }
            return this.Rows.Count;
        }
    } // class
} // namespace
