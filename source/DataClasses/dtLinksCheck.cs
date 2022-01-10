using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using DCSoft.RTF;
using CheccoSafetyTools;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;
using cst_WHOIS = CheccoSafetyTools.cst_WHOISNET_API;

namespace OutlookSafetyChecks
{
    public class dtLinksCheck : dtTemplate
    {
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
                List<String> listHosts = new List<String>();
                List<MailAddress> listEmails = new List<MailAddress>();
                foreach (DataRow tRow in listLinks.Rows)
                {
                    String tName = tRow.ItemArray[0] as String;
                    String tLink = tRow.ItemArray[1] as String;
                    try
                    {
                        Uri tUri = new Uri(tLink);
                        if (tUri.Scheme == Uri.UriSchemeMailto)
                        {
                            listEmails.Add(new MailAddress(tUri.UserInfo + "@" + tUri.Host, tName));
                        }
                        listHosts.Add(tUri.DnsSafeHost);
                    }
                    catch (Exception ex)
                    {
                        // DO NOTHING HERE
                    }
                }
                foreach (String tHost in listHosts.Distinct())
                {
                    String tDomain = cst_Util.pullDomain(tHost);
                    String tOwner = "[not checked]";
                    String tNotes = "";
                    // start checks
                    String tReason = Globals.AddInSafetyCheck.suspiciousHost(tHost);
                    if (cst_Util.isValidString(tReason))
                    {
                        tNotes += tReason;
                        parent.log(Properties.Resources.Title_Links, "4", "HOST", tReason);
                    }
                    if (Properties.Settings.Default.opt_Lookup_WHOIS)
                    {
                        tOwner = cst_WHOIS.whoisOwner(tDomain, Properties.Settings.Default.opt_Use_CACHE);
                    }
                    String[] rowData = new[] { tHost, tOwner, tNotes };
                    this.Rows.Add(rowData);
                }
                foreach (MailAddress tMailAddress in listEmails.Distinct())
                {
                    String tOwner = "[not checked]";
                    String tNotes = "";
                    // start checks
                    if (Properties.Settings.Default.opt_Lookup_WHOIS)
                    {
                        tOwner = cst_WHOIS.whoisOwner(tMailAddress.Host, Properties.Settings.Default.opt_Use_CACHE);
                    }
                    tNotes = checkEmail(tMailAddress, Properties.Resources.Title_Links + " / Checks");
                    String[] rowData = new[] { tMailAddress.Address, tOwner, tNotes };
                    this.Rows.Add(rowData);
                }
            }
            return this.Rows.Count;
        }
    } // class
} // namespace
