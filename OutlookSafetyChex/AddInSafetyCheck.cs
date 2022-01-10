// non-standard libraries
using CheccoSafetyTools;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using TrID;
using MessageBox = System.Windows.Forms.MessageBox;
// shortcuts
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public partial class AddInSafetyCheck
    {

        #region Class Variables
        Outlook.Explorer myExplorer;

        public static readonly AssemblyInfo metaData = new AssemblyInfo();
 
        private static StringCollection cacheTLDs = Properties.Settings.Default.TLD_cache;

        public readonly static String listDelimiter = Properties.Settings.Default.list_Delimiter;

        private readonly static String[] baseLocalWhitelist = Properties.Settings.Default.base_Whitelist.Split(new[] { listDelimiter }, StringSplitOptions.RemoveEmptyEntries);
        private readonly static String[] baseLocalBlacklist = Properties.Settings.Default.base_Blacklist.Split(new[] { listDelimiter }, StringSplitOptions.RemoveEmptyEntries);

        private static String[] myLocalWhitelist = Properties.Settings.Default.local_Whitelist.Split(new[] { listDelimiter }, StringSplitOptions.RemoveEmptyEntries);
        private static String[] myLocalBlacklist = Properties.Settings.Default.local_Blacklist.Split(new[] { listDelimiter }, StringSplitOptions.RemoveEmptyEntries);

        public static TrIDEngine fileInspector = new TrIDEngine();

        // non-static
        public dsMailItem currentDataSet = null;
        public dlgSafetyCheck dialogWindow = null;

        #endregion

        #region Setup
        private void AddInSafetyCheck_Startup(object sender, System.EventArgs args)
        {
            // selection handler
            myExplorer = this.Application.ActiveExplorer();
        }

        private void AddInSafetyCheck_Shutdown(object sender, System.EventArgs args)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
            selectMailItem(null);
            dsMailItem.RemoveAll();
        }

        ~AddInSafetyCheck()
        {
            selectMailItem(null);
            dsMailItem.RemoveAll();
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new CustomUI_Handler();
        }
        #endregion

        #region mailItem helpers
        public Outlook.MailItem getSelectedMailItem()
        {
            Outlook.MailItem myMail = null;
            try
            {
                Outlook.Selection t = Globals.AddInSafetyCheck.Application.ActiveExplorer().Selection;
                if (t != null && t.Count > 0 && t[1] is Outlook.MailItem)
                {
                    myMail = t[1] as Outlook.MailItem;
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::getSelectedMailItem()");
            }
            return myMail;
        }

        public Outlook.MailItem getOpenMailItem()
        {
            Outlook.MailItem myMail = null;
            try
            {
                Outlook.Inspector t = Globals.AddInSafetyCheck.Application.ActiveInspector();
                if (t != null && t is Outlook.MailItem)
                {
                    myMail = t.CurrentItem as Outlook.MailItem;
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::getOpenMailItem()");
            }
            return myMail;
        }

        #endregion

        #region custom pane

        public void loadDialog(Outlook.MailItem myItem)
        {
            try
            {
                if (selectMailItem(myItem) )
                {
                    dialogWindow = new dlgSafetyCheck(myItem);
                    dialogWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Cannot Load Safety Check for INVALID Mail Item");
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::loadDialog()");
            }
        }

        public bool isCurrentMailItem(Outlook.MailItem myItem)
        {
            bool rc = false;
			try
			{
				rc = (currentDataSet != null
                    && cst_Outlook.isValidMailItem(currentDataSet.mailItem)
                    && cst_Outlook.isValidMailItem(myItem)
                    && currentDataSet.mailItem.EntryID == myItem.EntryID);
			}
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::isCurrentMailItem()");
            }
            return rc;
        }

        public bool selectMailItem(Outlook.MailItem myItem)
        {
            bool rc = false;
            currentDataSet = null;
            try
            {
                if (cst_Outlook.isValidMailItem(myItem))
                {
                    currentDataSet = dsMailItem.Find(myItem.EntryID);
                    if (currentDataSet == null) currentDataSet = new dsMailItem(myItem);
                    rc = (currentDataSet != null);
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::selectMailItem()");
            }
            return rc;
        }

        public DataTable findTableName(String tableName)
        {
            try
            {
                if (currentDataSet != null) return currentDataSet.findTableName(tableName);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::findTableName(" + tableName + ")");
            }
            return null;
        }

        public DataTable findTableClass<T>()
        {
            try
            {
                if (currentDataSet != null) return currentDataSet.findTableClass<T>();
            }
            catch (Exception ex)
            {
               cst_Util.logException(ex, "AddInSafetyCheck::findTableName(" + typeof(T).Name + ")");
            }
            return null;
        }

        public int populateTableName(String tableName, bool refresh)
        {
            int rc = -1;
            try
            {
                dtTemplate myTable = findTableName(tableName) as dtTemplate;
                if (myTable != null) rc = myTable.populate(refresh);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::populateTableName(" + tableName + ")");
            }
            return rc;
        }

        public int populateTable<T>(bool refresh)
        {
            int rc = -1;
            try
            {
                dtTemplate myTable = findTableClass<T>() as dtTemplate;
                if (myTable != null) rc = myTable.populate(refresh);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::populateTable(" + typeof(T).Name + ")");
            }
            return rc;
        }

#endregion

#region Main Actions
		public void resetLog(bool refresh = false)
		{
			try
			{
                Globals.AddInSafetyCheck.dialogWindow.logGridView.Refresh();
                populateTable<dtWarnings>(refresh);
			}
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::resetLog()");
            }
        }

		public void ParseEnvelope(bool refresh = false)
        {
            try
            {
                populateTable<dtEnvelope>(refresh);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::ParseEnvelope()");
            }
        }

        public void ParseHeaders(bool refresh = false)
        {
            try
            {
				populateTable<dtHeaders>(refresh);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::ParseHeaders()");
            }
        }
 
        public void AnalyzeContacts(bool refresh = false)
        {
            try
            { 
                populateTable<dtSender>(refresh);       // verifies [From:] [Reply-To:] [Return-Path:]
                populateTable<dtRecipients>(refresh);   // verifies [To:] recipients
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::AnalyzeContacts()");
            }
        }

        public void AnalyzeBody(bool refresh = false)
        {
            try
            {
				populateTable<dtBody>(refresh);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::AnalyzeBody()");
            }
        }
        public void AnalyzeLinks(bool refresh = false)
        {
            try
            {
                populateTable<dtLinkList>(refresh);
                populateTable<dtLinksCheck>(refresh);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::AnalyzeLinks()");
            }
        }


        public void AnalyzeRoutes(bool refresh = false)
        {
            try
			{
				populateTable<dtRouteList>(refresh);
				populateTable<dtRoutesCheck>(refresh);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::AnalyzeRoutes()");
            }
        }

        public void AnalyzeAttachments(bool refresh = false)
        {
            try
            { 
                populateTable<dtAttachments>(refresh);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::AnalyzeAttachments()");
            }
        }

        #endregion

        #region helper utilities

        public static String[] getBaseBlacklist()
        {
            return baseLocalBlacklist;
        }
        public static String[] getLocalBlacklist()
        {
            return myLocalBlacklist;
        }
        public static void saveLocalBlacklist(String[] newList)
        {
            myLocalBlacklist = newList;
            Properties.Settings.Default.local_Blacklist = String.Join(listDelimiter, myLocalBlacklist);
            Properties.Settings.Default.Save();
        }

        public static String[] getBaseWhitelist()
        {
            return baseLocalWhitelist;
        }
        public static String[] getLocalWhitelist()
        {
            return myLocalWhitelist;
        }

        public static void saveLocalWhitelist(String[] newList)
        {
            myLocalWhitelist = newList;
            Properties.Settings.Default.local_Whitelist = String.Join(listDelimiter, myLocalWhitelist);
            Properties.Settings.Default.Save();
        }
        public static List<String> getTLDcache()
        {
            if (cacheTLDs == null)
            {
                cacheTLDs = new StringCollection();
            }
            // read TLDs from IANA
            if (cacheTLDs.Count == 0)
            {
                String t = cst_Util.wgetString("https://data.iana.org/TLD/tlds-alpha-by-domain.txt");
                String[] res = t.Split('\n');
                for (int i = 0; i < res.Length; i++)
                {
                    if (cst_Util.isValidString(res[i]) && !res[i].StartsWith("#"))
                    {
                        cacheTLDs.Add("." + res[i].Trim().ToLower());
                    }
                }
                // store cache
                Properties.Settings.Default.Save();
            }
            return cacheTLDs.Cast<String>().ToList();
        }
        public static void saveTLDcache(List<String> newList)
        {
           Properties.Settings.Default.TLD_cache.Clear();
           Properties.Settings.Default.TLD_cache.AddRange(newList.ToArray());
           Properties.Settings.Default.Save();
        }

        public static void saveDNSBLsites(String[] newList)
        {
            cst_DNSBL.spamLists = newList;
            Properties.Settings.Default.DNSBL_sites.Clear();
            Properties.Settings.Default.DNSBL_sites.AddRange(newList.ToArray());
            Properties.Settings.Default.Save();
        }

        public static List<String> getCommonMIMETYPEs()
        {
            List<String> rc = null;
            try
            {
                rc = Properties.Settings.Default.common_MIMETYPEs.Cast<String>().ToList();
            }
            catch { }
            return rc;
        }

        public static void saveCommonMIMETYPEs(List<String> newList)
        {
            Properties.Settings.Default.common_MIMETYPEs.Clear();
            Properties.Settings.Default.common_MIMETYPEs.AddRange(newList.ToArray());
            Properties.Settings.Default.Save();
        }

        public static List<String> getCommonCODEPAGEs()
        {
            List<String> rc = null;
            try
            {
                rc = Properties.Settings.Default.common_CODEPAGEs.Cast<String>().ToList();
            }
            catch { }
            return rc;
        }
        public static void saveCommonCODEPAGEs(List<String> newList)
        {
            Properties.Settings.Default.common_CODEPAGEs.Clear();
            Properties.Settings.Default.common_CODEPAGEs.AddRange(newList.ToArray());
            Properties.Settings.Default.Save();
        }

        public static List<String> getCommonENCODINGs()
        {
            List<String> rc = null;
            try
            {
                rc = Properties.Settings.Default.common_ENCODINGs.Cast<String>().ToList();
            }
            catch { }
            return rc;
        }
        public static void saveCommonENCODINGs(List<String> newList)
        {
            Properties.Settings.Default.common_ENCODINGs.Clear();
            Properties.Settings.Default.common_ENCODINGs.AddRange(newList.ToArray());
            Properties.Settings.Default.Save();
        }

        #endregion

        #region internal utilities
        String expandURL(Uri tinyURL)
        {
            // TODO: expand URL (find redirects?)
            return null;
        }

        List<String> getWordList(String tStr)
        {
            List<String> rc = new List<String>();
            String rgxWordPattern = @"\W(\w+)\W"; // @"\b(\w+)\b";
            Regex rgxWord = new Regex(rgxWordPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            try
            {
                // looking for strings that display leetspeak
                if (cst_Util.isValidString(tStr))
                {
                    // foreach word in the string:
                    MatchCollection mWords = rgxWord.Matches(tStr);
                    foreach (Match match in mWords)
                    {
                        String word = match.Value.Trim();
                        if (cst_Util.isValidString(word) && word.Length > 1)
                        {
                            rc.Add(word);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::getWordList(" + tStr + ")");
            }
            return rc;
        }
        #endregion

        #region sanity checks
        public String checkPUNYcode(String fqdn)
        {
            String rc = "";
            try
            {
                if (cst_Util.isValidString(fqdn) && fqdn.Contains("xn--"))
                {
                    String tReason = "\"" + fqdn + "\" uses PUNYcode";
                    rc += "[PUNYcode misdirection]: " + tReason + "\r\n";
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::checkPUNYcode(" + fqdn + ")");
            }
            return rc;
        }
        public String checkIDNchars(String fqdn)
        {
            String rc = "";
            try
            {
                String aStr = cst_Util.idnMapping.GetAscii(fqdn);
                if (aStr != fqdn)
                {
                    String tReason = "\"" + aStr + "\" masquerading as \"" + fqdn + "\"";
                    rc += "[IDN misdirection]: " + tReason + "\r\n";
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::checkPUNYcode(" + fqdn + ")");
            }
            return rc;
        }

        public String chkBufferOverflow(String tStr, uint maxLen = 1024)
        {
            String rc = "";
            try
            {
                // check original string
                if (tStr.Length > maxLen)
                {
                    rc += "[Potential Buffer Overflow]: " + tStr.Length + " > " + maxLen + "\r\n";
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::chkBufferOverflow(" + maxLen + ")");
            }
            return rc;
        }

        public String checkASCII(String tStr)
        {
            String rc = "";
            try
            {
                List<String> arrWords = getWordList(tStr);
                // foreach word in the string:
                foreach (String word in arrWords)
                {
                    String aStr = cst_Util.toAscii(word);
                    if (aStr != word)
                    {
                        String tReason = "\"" + word + "\"";
                        rc += "[Non-ASCII Text Detected]: " + tReason + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::checkIDN(" + tStr + ")");
            }
            return rc;
        }

        public String checkDynaSub(String tStr)
        {
            String rc = "";
            try
            {
                // looking for dynamic substitution markers like "${jndi:...}"
                if (cst_Util.isValidString(tStr))
                {
                    String rgxStr = "(\\$\\{.+\\})";
                    Regex rgx = new Regex(rgxStr);
                    Match m = rgx.Match(tStr.Trim());
                    if (m.Groups.Count > 1)
                    {
                        String tFound = m.Groups[1].Value.Trim();
                        rc += "[Dynamic Substitution]: " + tFound + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::checkSubstitution(" + tStr + ")");
            }
            return rc;
        }

        public String checkLeetSpeak(String tStr)
        {
            String rc = "";
            String rgxLeetPattern = @"([a-z,A-Z]+\d+[a-z,A-Z]+)";
            Regex rgxLeet = new Regex(rgxLeetPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Determine Leet substitutions (O=0, I=1, Z=2, E=3, H=4, S=5, ...)
            try
            {
                List<String> arrWords = getWordList(tStr);
                // looking for strings that display leetspeak
                foreach (String word in arrWords)
                {
                    if (cst_Util.isValidString(word) && word.Length > 1)
                    {
                        // check if a number is surrounded by alpha characters
                        Match mLeet = rgxLeet.Match(word);
                        if (mLeet.Groups.Count > 1)
                        {
                            rc += "[Possible L33TSPEAK]: " + word + "\r\n";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::checkLeetSpeak(" + tStr + ")");
            }
            return rc;
        }

        public String suspiciousAttachment(Outlook.Attachment tAttachment, out String tMimeType, out String tFileSig)
        {
            String tNotes = "";
            tMimeType = "[not checked]";
            tFileSig = "[not checked]";
            try
            { 
                if ( tAttachment != null && cst_Util.isValidString(tAttachment.FileName))
                {
                    String tReason = Globals.AddInSafetyCheck.chkBufferOverflow(tAttachment.FileName, 1024);
                    if (cst_Util.isValidString(tReason))
                    {
                        tNotes += tReason + "\r\n";
                    }
                    String tFileExt = Path.GetExtension(tAttachment.FileName).ToLower();
                    tMimeType = HeyRed.Mime.MimeTypesMap.GetMimeType(tFileExt);
                    tFileSig = System.Web.MimeMapping.GetMimeMapping(tAttachment.FileName);
                    if (tFileExt.Equals("exe") || tFileExt.Equals("dll") || tFileExt.Equals("ocx"))
                    {
                        tNotes += "[EXECUTABLE BINARY]: ext = " + tFileExt + "\r\n";
                    }
                    if (tFileExt.Equals("msi") || tFileExt.Equals("cab"))
                    {
                        tNotes += "[EXECUTABLE INSTALLER]: ext = " + tFileExt + "\r\n";
                    }
                    else if (tFileExt.Equals("cmd") || tFileExt.Equals("bat")
                        || tFileExt.StartsWith("ps") || tFileExt.StartsWith("vb"))
                    {
                        tNotes += "[EXECUTABLE SCRIPT]: ext = " + tFileExt + "\r\n";
                    }
                    if (Properties.Settings.Default.opt_DeepInspect_ATTACHMENTS)
                    {
                        // attempt to read MIME type
                        String tTemp = Path.GetTempFileName();
                        tAttachment.SaveAsFile(tTemp);
                        FileInfo tFI = new FileInfo(tTemp);
                        if ( tFI != null )
                        {
                            try
                            {
                                String tFileType = TrIDEngine.GetExtensionByFileContent(tTemp).ToLower();
                                tFileSig = HeyRed.Mime.MimeTypesMap.GetMimeType(tFileType);
                            }
                            catch (Exception ex)
                            {
                                cst_Util.logException(ex, "AddInSafetyCheck::MimeGuesser(\"" + tAttachment.FileName + "\")");
                            }
                            if (!tFileSig.Equals(tMimeType, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tNotes += "[MISMATCHED File Signature] " + tFileSig + " <> "+ tMimeType + "\r\n";
                            }
                        }
                        // complete
                        File.Delete(tTemp);
                    }
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::suspiciousAttachment(" + tAttachment.FileName + ")");
            }
            return tNotes;
		}

        public String checkLocalHostLists(String inHost)
        {
            String rc = "";
            String tHost = inHost;
            try {
                // check Local Black/White-LISTS
                if (cst_Util.isValidString(tHost))
                {
                    List<String> blacklists = new List<String>();
                    List<String> whitelists = new List<String>();
                    if (Properties.Settings.Default.opt_Local_BLACKLIST)
                    {
                        foreach (String t in myLocalBlacklist)
                        {
                            bool found = false;
                            if (t.StartsWith(".")) found = tHost.EndsWith(t, StringComparison.CurrentCultureIgnoreCase);
                            else found = tHost.Equals(t, StringComparison.CurrentCultureIgnoreCase)
                                            || tHost.EndsWith("." + t, StringComparison.CurrentCultureIgnoreCase);
                            if (found)
                            {
                                rc += "[Local BLACKLIST]: " + tHost + " (" + t + ")\n";
                                blacklists.Add(t);
                            }
                        }
                    }
                    if (Properties.Settings.Default.opt_Local_WHITELIST)
                    {
                        foreach (String t in myLocalWhitelist)
                        {
                            bool found = false;
                            if (t.StartsWith(".")) found = tHost.EndsWith(t, StringComparison.CurrentCultureIgnoreCase);
                            else found = tHost.Equals(t, StringComparison.CurrentCultureIgnoreCase)
                                            || tHost.EndsWith("." + t, StringComparison.CurrentCultureIgnoreCase);
                            if (found)
                            {
                                // cst_Util.logInfo("[Local WHITELIST]: " + t, "AddInSafetyCheck::checkLocalHostLists(" + tHost + ")");
                                whitelists.Add(t);
                            }
                        }
                        if (whitelists.Count == 0)
                        {
                            rc += "[Not Found - Local WHITELIST]: " + tHost + "\r\n";
                        }
                    }
                    // ambiguity ???
                    if (whitelists.Count > 0 && blacklists.Count > 0)
                    {
                        String tConflict = "[Match in BOTH lists]: " + tHost;
                        tConflict += "\nBLACKLIST: ";
                        foreach (String t in blacklists) tConflict += "[" + t + "] ";
                        tConflict += "\nWHITELIST: ";
                        foreach (String t in whitelists) tConflict += "[" + t + "] ";
                        rc += tConflict + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::checkLocalHostLists(" + tHost + ")");
            }
            return rc;
        }

        public String suspiciousEmail(MailAddress tMailAddress)
        {
            String rc = "";
            if (tMailAddress != null)
            {
                String tName = cst_Util.sanitizeEmail(tMailAddress.DisplayName);
                String tAddr = cst_Util.sanitizeEmail(tMailAddress.Address);
                String tHost = tMailAddress.Host;
                try
                {
                    rc += checkIDNchars(tAddr);
                    rc += checkPUNYcode(tAddr);
                    String myDomain = cst_Util.pullDomain(tHost);
                    String tReason = null;
                    if (Properties.Settings.Default.opt_Lookup_HIBP)
                    {
                        Dictionary<String, String> map = cst_HIBP.wasEmailPasted(tAddr, Properties.Settings.Default.opt_Use_CACHE);
                        foreach (String t in map.Values)
                        {
                            if (cst_Util.isValidString(t))
                            {
                                rc += "[EMAIL PASTED]: " + t + "\r\n";
                            }
                        }
                        map = cst_HIBP.wasEmailBreached(tAddr, Properties.Settings.Default.opt_Use_CACHE);
                        foreach (String t in map.Values)
                        {
                            if (cst_Util.isValidString(t))
                            {
                                rc += "[EMAIL LEAKED]: " + t + "\r\n";
                            }
                        }
                        map = cst_HIBP.wasDomainBreached(myDomain, Properties.Settings.Default.opt_Use_CACHE);
                        foreach (String t in map.Values)
                        {
                            if (cst_Util.isValidString(t))
                            {
                                rc += "[HOST/DOMAIN BREACHED]: " + t + "\r\n";
                            }
                        }
                    }
                    if (Properties.Settings.Default.opt_Lookup_DNSBL)
                    {
                        tReason = cst_DNSBL.checkDNSBL(tHost, Properties.Settings.Default.opt_Use_CACHE);
                        if (cst_Util.isValidString(tReason))
                        {
                            rc += "[HOST BLACKLISTED]: " + tReason + "\r\n";
                        }
                    }
                    rc += checkLocalHostLists(tHost);
                    if (Properties.Settings.Default.opt_Lookup_CONTACTS)
                    {
                        List<Outlook.ContactItem> arrEmails = cst_Outlook.FindContactByEmail(this.Application, tAddr);
                        int knownEmails = (arrEmails == null) ? 0 : arrEmails.Count;
                        // if email is not already known, check against names
                        if (knownEmails == 0)
                        {
                            int knownNames = 0;
                            if (cst_Util.isValidString(tName))
                            {
                                List<Outlook.ContactItem> arrNames = cst_Outlook.FindContactByDisplayName(this.Application, tName);
                                knownNames = (arrNames == null) ? 0 : arrNames.Count;
                            }
                            // wait a minute, if the email wasn't known
                            if (knownNames > 0)
                            {
                                // log error here
                                tReason = "<" + tAddr + "> does not match contact \"" + tName + "\"";
                                rc += "[SPOOFED? EMAIL]: " + tReason + "\r\n";
                            }
                            else if (Properties.Settings.Default.opt_Flag_UNKNOWN_CONTACTS)
                            {
                                // unknown email
                                tReason = "<" + tAddr + "> is not in your contact list";
                                rc += "[UNKNOWN EMAIL]: " + tReason + "\r\n";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cst_Util.logException(ex, "AddInSafetyCheck::suspiciousEmail(" + tMailAddress.Address + ")");
                }
            }
            return rc;
		}

		public String suspiciousHost(String fqdn)
		{
            String rc = "";
            try
            {
                rc += checkIDNchars(fqdn);
                rc += checkPUNYcode(fqdn);
                rc += checkLeetSpeak(fqdn);
                if (Properties.Settings.Default.opt_Lookup_HIBP)
                {
                    String myDomain = cst_Util.pullDomain(fqdn);
                    Dictionary<String, String> map = cst_HIBP.wasDomainBreached(myDomain, Properties.Settings.Default.opt_Use_CACHE);
                    foreach (String t in map.Values)
                    {
                        rc += "[HOST PWNeD]: " + t + "\r\n";
                    }
                }
                if (Properties.Settings.Default.opt_Lookup_DNSBL)
                {
                    String tReason = cst_DNSBL.checkDNSBL(fqdn, Properties.Settings.Default.opt_Use_CACHE);
                    if (cst_Util.isValidString(tReason))
                    {
                        rc += "[HOST BLACKLISTED]: " + tReason + "\r\n";
                    }
                }
                rc += checkLocalHostLists(fqdn);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::suspiciousHost(" + fqdn + ")");
            }
            return rc;
		}

        public String suspiciousIP(String ipAddr)
        {
            String rc = "";
            try
            {
                if (Properties.Settings.Default.opt_Lookup_HIBP)
                {
                    Dictionary<String, String> map = cst_HIBP.wasDomainBreached(ipAddr, Properties.Settings.Default.opt_Use_CACHE);
                    foreach (String t in map.Values)
                    {
                        if (cst_Util.isValidString(t))
                        {
                            rc += "[IPADDR PWNeD]: " + t + "\r\n";
                        }
                    }
                }
                if (Properties.Settings.Default.opt_Lookup_DNSBL)
                {
                    String tReason = cst_DNSBL.checkDNSBL(ipAddr, Properties.Settings.Default.opt_Use_CACHE);
                    if (cst_Util.isValidString(tReason))
                    {
                        rc += "[BLACKLISTED]: " + tReason + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::suspiciousIP(" + ipAddr + ")");
            }
            return rc;
        }

        public String suspiciousText(String tStr)
        {
            String rc = "";
            try
            {
                // check original string
                String tReason = checkASCII(tStr);
                if (cst_Util.isValidString(tReason))
                {
                    rc += tReason + "\r\n";
                }
                tReason = checkLeetSpeak(tStr);
                if (cst_Util.isValidString(tReason))
                {
                    rc += tReason + "\r\n";
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::suspiciousText(" + tStr + ")");
            }
            return rc;
        }

        public String suspiciousValue(String tStr, uint maxLen=256)
        {
            String rc = "";
            try
            {
                // check parameter string
                String tReason = chkBufferOverflow(tStr,maxLen);
                if (cst_Util.isValidString(tReason))
                {
                    rc += tReason + "\r\n";
                }
                tReason = checkDynaSub(tStr);
                if (cst_Util.isValidString(tReason))
                {
                    rc += tReason + "\r\n";
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::suspiciousValue(" + tStr + ")");
            }
            return rc;
        }

        public String suspiciousLink(String tLink, String tDisplayName = null, bool allowQueryString=true)
        {
            String tNotes = "";
            try
            {
                Uri tLinkUri = null;
                if (cst_Util.isValidString(tDisplayName))
                {
                    tDisplayName = tDisplayName.Trim();
                    String tReason = suspiciousText(tDisplayName);
                    if (cst_Util.isValidString(tReason))
                    {
                        tNotes += tReason + "\r\n";
                    }
                }
                if (cst_Util.isValidString(tLink))
                {
                    tLink = tLink.Trim();
                    String tReason = Globals.AddInSafetyCheck.chkBufferOverflow(tLink, 1024);
                    if (cst_Util.isValidString(tReason))
                    {
                        tNotes += tReason + "\r\n";
                    }
                    tLinkUri = new Uri(tLink);
                    // check supported link protocols
                    if (tLinkUri.Scheme == Uri.UriSchemeMailto)
                    {
                        // if an email, check for consistency
                        if (cst_Util.isValidString(tDisplayName) && tDisplayName.Contains("@"))
                        {
                            if (!tDisplayName.Equals(tLinkUri.UserInfo + "@" + tLinkUri.Host, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tNotes += "[EMAIL MISDIRECTION]: Displayed Link does not match Actual Link\r\n";
                            }
                        }
                    }
                    else if (tLinkUri.Scheme == Uri.UriSchemeHttp || tLinkUri.Scheme == Uri.UriSchemeHttps)
                    {
                        if (cst_Util.isValidString(tDisplayName) && tDisplayName.StartsWith("http", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (!tDisplayName.Equals(tLinkUri.OriginalString, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tNotes += "[WEB MISDIRECTION]: Displayed Link does not match Actual Link\r\n";
                            }
                        }
                    }
                    else if (tLinkUri.IsFile || tLinkUri.IsUnc)
                    {
                        tNotes += "[FILE ACCESS]: Link accesses a file\r\n";
                    }
                    else
                    {
                        tNotes += "[NON-COMMON PROTOCOL]: Link uses protocol \"" + tLinkUri.Scheme + "\"\r\n";
                    }
                    // checks against all link protocols
                    if (cst_Util.isIPaddress(tLinkUri.Host))
                    {
                        tNotes += "[EXPLICIT IP]: Link specifies a hardcoded IP Address\r\n";
                    }
                    if (tLinkUri.IsLoopback)
                    {
                        tNotes += "[LOCAL ACCESS]: Link accesses your local computer\r\n";
                    }
                    if (!tLinkUri.IsDefaultPort)
                    {
                        tNotes += "[NON-COMMON PORT]: Link uses protocol:port \"" + tLinkUri.Scheme + ":" + tLinkUri.Port + "\"\r\n";
                    }
                    if (!allowQueryString && cst_Util.isValidString(tLinkUri.Query))
                    {
                        tNotes += "[POTENTIAL BEACON]: Link should not have Paramters\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "AddInSafetyCheck::suspiciousLink(" + tLink + ")");
            }
            return tNotes;
        }
 
#endregion

#region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(AddInSafetyCheck_Startup);
            this.Shutdown += new System.EventHandler(AddInSafetyCheck_Shutdown);
        }
        
#endregion
    } // class
} // namespace
