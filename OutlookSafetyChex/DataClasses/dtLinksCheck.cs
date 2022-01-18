using CheccoSafetyTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public class dtLinksCheck : dtTemplate
    {
        static String logArea = Properties.Resources.Title_Links + " (Check)";
        public dtLinksCheck()
        {
            this.Columns.Add("Host", Type.GetType("System.String"));
            this.Columns.Add("Owner", Type.GetType("System.String"));
            this.Columns.Add("Notes", Type.GetType("System.String"));
        }

        public override int buildData(dsMailItem parent, Outlook.MailItem myItem)
        {
		    dtLinkList listLinks = parent.findTableClass<dtLinkList>() as dtLinkList;
            if (listLinks != null)
            {
                if (listLinks.Rows.Count == 0) listLinks.populate(false);
                if (mLogger != null)
                    mLogger.logInfo("Inspecting [" + listLinks.Rows.Count + "] Link References", logArea);
                List<String> listHosts = new List<String>();
                List<MailAddress> listEmails = new List<MailAddress>();
                foreach (DataRow tRow in listLinks.Rows)
                {
                    // IMPORTANT: must follow order of field in dtLinkList
                    String tType = tRow.ItemArray[0] as String;
                    String tName = tRow.ItemArray[1] as String;
                    String tLink = tRow.ItemArray[2] as String;
                    try
                    {
                        // start checks
                        cst_URL tURL = cst_URL.parseURL(tLink);
                        if (tURL.mUri.Scheme == Uri.UriSchemeMailto)
                        {
                            listEmails.Add(new MailAddress(tURL.mUri.UserInfo + "@" + tURL.mUri.Host, tName));
                        }
                        listHosts.Add(tURL.mUri.DnsSafeHost);
                    }
                    catch // (Exception ex)
                    {
                        // DO NOTHING HERE
                    }
                }
                if (mLogger != null)
                    mLogger.logInfo("Inspecting [" + listHosts.Count + "] Host References", logArea);
                foreach (String tHost in listHosts.Distinct())
                {
                    String tDomain = instance.mWebUtil.pullDomain(tHost);
                    String tOwner = "[not checked]";
                    String tNotes = "";
                    // start checks
                    String tReason = instance.suspiciousHost(tHost);
                    if (cst_Util.isValidString(tReason))
                    {
                        tNotes += tReason;
                        parent.logFinding(logArea, "4", "HOST", tReason);
                    }
                    if (Properties.Settings.Default.opt_Lookup_WHOIS)
                    {
                        tOwner = instance.mWHOIS.whoisOwner(tDomain, Properties.Settings.Default.opt_Use_CACHE);
                    }
                    String[] rowData = new[] { tHost, tOwner, tNotes };
                    this.addDataRow(rowData);
                }
                if (mLogger != null)
                    mLogger.logInfo("Inspecting [" + listEmails.Count + "] Email References", logArea);
                foreach (MailAddress tMailAddress in listEmails.Distinct())
                {
                    // start checks
                    String tNotes = checkEmail(tMailAddress, Properties.Resources.Title_Links + " / Checks");
                    if (cst_Util.isValidString(tNotes))
                    {
                        String[] rowData = new[] { "Email <" + tMailAddress.Address + ">", "[N/A]", tNotes };
                        this.addDataRow(rowData);
                    }
                }
            }
            return this.Rows.Count;
        }
    } // class
} // namespace
