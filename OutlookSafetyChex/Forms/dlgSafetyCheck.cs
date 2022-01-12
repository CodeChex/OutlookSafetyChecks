using CheccoSafetyTools;
using OutlookSafetyChex.Forms;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    public partial class dlgSafetyCheck : Form
    {
        AddInSafetyCheck myVSTO = Globals.AddInSafetyCheck;

        public dlgSafetyCheck(Outlook.MailItem myItem)
        {
            InitializeComponent();
            // UI
            String title = "Subject: " + myItem.Subject;
            this.textBoxProgress.Text = title;
            this.Text = Properties.Resources.ShortName + " - " + title;
            this.rawHeaderTextBox.Text = cst_Outlook.getHeaders(myItem);
            // set version info
            this.labelVersion.Text = AddInSafetyCheck.metaData.Title
                    + "\r\n" 
                    + "Version: " + AddInSafetyCheck.metaData.Version
                    + "\r\n" 
                    + AddInSafetyCheck.metaData.Copyright + ", " + AddInSafetyCheck.metaData.Company;
            // Data
            cst_Util.setLoggingUI(this.textDebug, this.textBoxProgress);
            initializePane();
        }

        private void dlgSafetyCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            // reset logger
            cst_Util.setLoggingUI(null, null);
        }

        #region application customizations

        void initializePane()
        {
            try
            {
                // options
                this.initializeOptionState();
                // Main TAB
                initializeGridView(this.logGridView, myVSTO.findTableClass<dtWarnings>());
                // Info TAB
                this.envelopeTab.Text = Properties.Resources.Title_Envelope;
                initializeGridView(this.envelopeGridView, myVSTO.findTableClass<dtEnvelope>());
                // Header TAB
                this.headerTab.Text = Properties.Resources.Title_Headers;
                initializeGridView(this.headerGridView, myVSTO.findTableClass<dtHeaders>());
                // Route TAB
                this.routeTab.Text = Properties.Resources.Title_Routing;
                initializeGridView(this.routeCheckGridView, myVSTO.findTableClass<dtRoutesCheck>());
                initializeGridView(this.routeListGridView, myVSTO.findTableClass<dtRouteList>());
                // Contact TAB
                this.contactTab.Text = Properties.Resources.Title_Contacts;
                initializeGridView(this.senderGridView, myVSTO.findTableClass<dtSender>());
                initializeGridView(this.recipientsGridView, myVSTO.findTableClass<dtRecipients>());
                // Body TAB
                this.bodyTab.Text = Properties.Resources.Title_Body;
                initializeGridView(this.bodyGridView, myVSTO.findTableClass<dtBody>());
                // Links TAB
                this.linksTab.Text = Properties.Resources.Title_Links;
                initializeGridView(this.linkCheckGridView, myVSTO.findTableClass<dtLinksCheck>());
                initializeGridView(this.linkListGridView, myVSTO.findTableClass<dtLinkList>());
                // Attachments TAB
                this.attachmentsTab.Text = Properties.Resources.Title_Attachments;
                initializeGridView(this.attachmentsGridView, myVSTO.findTableClass<dtAttachments>());
                // reset log
                cst_Util.logInfo(null, null, true);
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "initializePane()");
            }
        }

        void initializeGridView(DataGridView myGridView, DataTable myTable = null)
        {
            if (myGridView != null)
            {
                myGridView.SuspendLayout();
                try
                {
                    myGridView.DataSource = null;
                    myGridView.Rows.Clear();
                    myGridView.Columns.Clear();
                    myGridView.Dock = DockStyle.Fill;
                    myGridView.AutoGenerateColumns = true;
                    myGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    myGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    myGridView.AllowUserToAddRows = false;
                    myGridView.AllowUserToDeleteRows = false;
                    myGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    myGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    myGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    myGridView.AllowUserToResizeColumns = true;
                    myGridView.AllowUserToResizeRows = true;
                    myGridView.ScrollBars = ScrollBars.Both;
                    myGridView.ReadOnly = true;
                    myGridView.TabIndex = 0;
                    if (myTable != null) myGridView.DataSource = new DataView(myTable);
                }
                catch (Exception ex)
                {
                    cst_Util.logException(ex, "initializeGridView(" + myGridView.Name + ")");
                }
                myGridView.ResumeLayout(true);
            }
        }

        #endregion

        private void btnRunTests_Click(object sender, EventArgs ev)
        {
            Button myControl = sender as Button;
            myControl.Enabled = false;
            try
            {
                bool refresh = Properties.Settings.Default.opt_Force_REFRESH;
                Stopwatch watch = new Stopwatch();
                watch.Start(); 
                cst_Util.logMessage("BEGIN ...", "" + DateTime.Now + "",true);
                if (myControl == this.btnRunTests)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (Properties.Settings.Default.opt_ShowLog)
                    {
                        this.myTabControl.SelectedTab = this.loggingTab;
                    }
                     Globals.AddInSafetyCheck.resetLog(refresh);
                    // always parse envelope
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Envelope + "] ...",
                            "" + DateTime.Now + "");
                        Globals.AddInSafetyCheck.ParseEnvelope(refresh);
                    }
                    // always parse headers
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Headers + "] ...",
                            "" + DateTime.Now + "");
                        Globals.AddInSafetyCheck.ParseHeaders(refresh);
                    }
                    if (this.cbTabContacts.CheckState == CheckState.Checked)
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Contacts + "] ...",
                            "" + DateTime.Now + "");
                        Globals.AddInSafetyCheck.AnalyzeContacts(refresh);
                    }
                    if (this.cbTabRoutes.CheckState == CheckState.Checked)
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Routing + "] ...",
                            "" + DateTime.Now + "");
                        Globals.AddInSafetyCheck.AnalyzeRoutes(refresh);
                    }
                    if (this.cbTabBody.CheckState == CheckState.Checked)
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Body + "] ...",
                            "" + DateTime.Now + "");
                        Globals.AddInSafetyCheck.AnalyzeBody(refresh);
                    }
                    if (this.cbTabLinks.CheckState == CheckState.Checked)
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Links + "] ...",
                            "" + DateTime.Now + "");
                        Globals.AddInSafetyCheck.AnalyzeLinks(refresh);
                    }
                    if (this.cbTabAttachments.CheckState == CheckState.Checked)
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Attachments + "] ...", 
                            "" + DateTime.Now + "");
                        Globals.AddInSafetyCheck.AnalyzeAttachments(refresh);
                    }
                    watch.Stop();
                    cst_Util.logMessage("DONE", "Elapsed (" + watch.Elapsed + ")");
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "TESTS");
            }
            this.Cursor = Cursors.Default;
            myControl.Enabled = true;
            //MessageBox.Show("Tests Complete","AddInSafetyCheck");
            this.myTabControl.SelectedTab = this.optionsTab;
        }

        private void btnClearCache_Click(object sender, EventArgs ev)
        {
            Button myControl = sender as Button;
            if (myControl == this.btnClearCache)
            {
                cst_WHOIS.clearCaches();
                cst_DNSBL.clearCaches();
                cst_HIBP.clearCaches();
            }
        }

        private void updateCheckBox(CheckBox cbItem, bool optState)
        {
            CheckState chkState = optState ? CheckState.Checked : CheckState.Unchecked;
            if (cbItem != null) cbItem.CheckState = chkState;
        }

        public void initializeOptionState()
        {
            // tests
            updateCheckBox(this.cbTabContacts, Properties.Settings.Default.test_Contacts);
            updateCheckBox(this.cbTabRoutes, Properties.Settings.Default.test_Routes);
            updateCheckBox(this.cbTabBody, Properties.Settings.Default.test_Body);
            updateCheckBox(this.cbTabLinks, Properties.Settings.Default.test_Links);
            updateCheckBox(this.cbTabAttachments, Properties.Settings.Default.test_Attachments);
            updateCheckBox(this.cbTabHeaders, Properties.Settings.Default.test_Headers);
            // options
            updateCheckBox(this.cbForceDataRefresh, Properties.Settings.Default.opt_Force_REFRESH);
            updateCheckBox(this.cbLookupWHOIS, Properties.Settings.Default.opt_Lookup_WHOIS);
            updateCheckBox(this.cbLookupDNSBL, Properties.Settings.Default.opt_Lookup_DNSBL);
            updateCheckBox(this.cbLookupHIBP, Properties.Settings.Default.opt_Lookup_HIBP);
            updateCheckBox(this.cbUseCACHE, Properties.Settings.Default.opt_Use_CACHE);
            updateCheckBox(this.cbVerifyContacts, Properties.Settings.Default.opt_Lookup_CONTACTS);
            updateCheckBox(this.cbHost_Blacklist, Properties.Settings.Default.opt_Local_BLACKLIST);
            updateCheckBox(this.cbHost_Whitelist, Properties.Settings.Default.opt_Local_WHITELIST);
            updateCheckBox(this.cbFlagUnknownContacts, Properties.Settings.Default.opt_Flag_UNKNOWN_CONTACTS);
            updateCheckBox(this.cbInspectAttachents, Properties.Settings.Default.opt_DeepInspect_ATTACHMENTS);
            updateCheckBox(this.cbInspectLinks, Properties.Settings.Default.opt_DeepInspect_LINKS);
            updateCheckBox(this.cbShowLog, Properties.Settings.Default.opt_ShowLog);
            updateCheckBox(this.cb_MIMEtypes, Properties.Settings.Default.opt_Lookup_MIMEtypes);
            updateCheckBox(this.cb_Codepages, Properties.Settings.Default.opt_Lookup_Codepages);
            updateCheckBox(this.cb_Cultures, Properties.Settings.Default.opt_Lookup_Encodings);
            updateCheckBox(this.cbHiliteSpam, Properties.Settings.Default.opt_ShowSpamHeaders);
            // special case
            this.cbFlagUnknownContacts.Enabled = Properties.Settings.Default.opt_Lookup_CONTACTS;
            // update logging level (radio checkbox)
            this.rbLogNone.Checked = false;
            this.rbLogInfo.Checked = false;
            this.rbLogError.Checked = false;
            this.rbLogVerbose.Checked = false;
            switch (Properties.Settings.Default.log_Level)
            {
                case cst_Util.LOG_NONE: 
                    this.rbLogNone.Checked = true;
                    break;
                case cst_Util.LOG_INFO:
                    this.rbLogInfo.Checked = true;
                    break;
                case cst_Util.LOG_ERROR:
                    this.rbLogError.Checked = true;
                    break;
                case cst_Util.LOG_VERBOSE:
                    this.rbLogVerbose.Checked = true;
                    break;
                case cst_Util.LOG_ALL:
                default:
                    this.rbLogVerbose.Checked = true;
                    break;
            }
        }

        private void onChange_CheckBox(object sender, EventArgs ev)
        {
            CheckBox myControl = sender as CheckBox;
            bool isChecked = (myControl.CheckState == CheckState.Checked);
            if (myControl == this.cbForceDataRefresh)
            {
                Properties.Settings.Default.opt_Force_REFRESH = isChecked;
            }
            else if (myControl == this.cbLookupWHOIS)
            {
                Properties.Settings.Default.opt_Lookup_WHOIS = isChecked;
            }
            else if (myControl == this.cbLookupDNSBL)
            {
                Properties.Settings.Default.opt_Lookup_DNSBL = isChecked;
            }
            else if (myControl == this.cbLookupHIBP)
            {
                Properties.Settings.Default.opt_Lookup_HIBP = isChecked;
            }
            else if (myControl == this.cbUseCACHE)
            {
                Properties.Settings.Default.opt_Use_CACHE = isChecked;
            }
            else if (myControl == this.cbVerifyContacts)
            {
                Properties.Settings.Default.opt_Lookup_CONTACTS = isChecked;
                this.cbFlagUnknownContacts.Enabled = isChecked;
            }
            else if (myControl == this.cbHost_Blacklist)
            {
                Properties.Settings.Default.opt_Local_BLACKLIST = isChecked;
            }
            else if (myControl == this.cbHost_Whitelist)
            {
                Properties.Settings.Default.opt_Local_WHITELIST = isChecked;
            }
            else if (myControl == this.cbFlagUnknownContacts)
            {
                Properties.Settings.Default.opt_Flag_UNKNOWN_CONTACTS = isChecked;
            }
            else if (myControl == this.cbInspectAttachents)
            {
                Properties.Settings.Default.opt_DeepInspect_ATTACHMENTS = isChecked;
            }
            else if (myControl == this.cbInspectLinks)
            {
                Properties.Settings.Default.opt_DeepInspect_LINKS = isChecked;
            }
            else if (myControl == this.cbTabContacts)
            {
                Properties.Settings.Default.test_Contacts = isChecked;
            }
            else if (myControl == this.cbTabRoutes)
            {
                Properties.Settings.Default.test_Routes = isChecked;
            }
            else if (myControl == this.cbTabBody)
            {
                Properties.Settings.Default.test_Body = isChecked;
            }
            else if (myControl == this.cbTabLinks)
            {
                Properties.Settings.Default.test_Links = isChecked;
            }
            else if (myControl == this.cbTabAttachments)
            {
                Properties.Settings.Default.test_Attachments = isChecked;
            }
            else if (myControl == this.cbShowLog)
            {
                Properties.Settings.Default.opt_ShowLog = isChecked;
            }
            else if (myControl == this.cbTabHeaders)
            {
                Properties.Settings.Default.test_Headers = isChecked;
            }
            else if (myControl == this.cb_Cultures)
            {
                Properties.Settings.Default.opt_Lookup_Encodings = isChecked;
            }
            else if (myControl == this.cb_Codepages)
            {
                Properties.Settings.Default.opt_Lookup_Codepages = isChecked;
            }
            else if (myControl == this.cb_MIMEtypes)
            {
                Properties.Settings.Default.opt_Lookup_MIMEtypes = isChecked;
            }
            else if (myControl == this.cbHiliteSpam)
            {
                Properties.Settings.Default.opt_ShowSpamHeaders = isChecked;
            }
            else
            {
                MessageBox.Show("Unknown CheckBox: [" + myControl.Text + "]");
            }
        }

        private void editDNSBL_Dialog(object sender, EventArgs ev)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit DNSBL Sources",
                                AddInSafetyCheck.getCommonDNSBLsites(), 
                                AddInSafetyCheck.getLocalDNSBL(), 
                                null );
                if ( dlg.ShowDialog() == DialogResult.OK )
                {
                    AddInSafetyCheck.saveDNSBLsites(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "editSpamlist");
            }
            this.Visible = true;
        }

        private void editWhitelist_Dialog(object sender, EventArgs ev)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Local Whitelist", 
                                    AddInSafetyCheck.getCacheTLDs(), 
                                    AddInSafetyCheck.getLocalWhitelist(),
                                    AddInSafetyCheck.getBaseWhitelist());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AddInSafetyCheck.saveLocalWhitelist(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "editLocalWhitelist");
            }
            this.Visible = true;
        }

        private void rbLogNone_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log_Level = cst_Util.LOG_NONE;
        }

        private void rbLogError_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log_Level = cst_Util.LOG_ERROR;
        }

        private void rbLogInfo_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log_Level = cst_Util.LOG_INFO;
        }

        private void rbLogVerbose_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log_Level = cst_Util.LOG_VERBOSE;
        }

        private void btnSaveOptions_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void labelVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // https://github.com/CodeChex/OutlookSafetyChex
            String tUrl = AddInSafetyCheck.metaData.Description; 
            this.labelVersion.LinkVisited = true;
            System.Diagnostics.Process.Start(tUrl);
        }

        private void editBlacklist_Dialog(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Local Blacklist",
                                    AddInSafetyCheck.getCacheTLDs(),
                                    AddInSafetyCheck.getLocalBlacklist(),
                                    AddInSafetyCheck.getBaseBlacklist());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AddInSafetyCheck.saveLocalBlacklist(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "editLocalBlacklist");
            }
            this.Visible = true;
        }

        private void editMIMEtypes_Dialog(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Allowed MIMETYPEs",
                                    AddInSafetyCheck.getCacheMIMETYPEs(),
                                    AddInSafetyCheck.getLocalMIMETYPEs(),
                                    AddInSafetyCheck.getCommonMIMETYPEs());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AddInSafetyCheck.saveLocalMIMETYPEs(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "Edit Allowed MIMETYPEs");
            }
            this.Visible = true;
        }

        private void editCodepages_Dialog(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Allowed CODEPAGEs",
                                    AddInSafetyCheck.getCacheCODEPAGEs(),
                                    AddInSafetyCheck.getLocalCODEPAGEs(),
                                    AddInSafetyCheck.getCommonCODEPAGEs());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AddInSafetyCheck.saveLocalCODEPAGEs(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "Edit Allowed CODEPAGEs");
            }
            this.Visible = true;

        }

        private void editCULTUREs_Dialog(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Allowed CULTUREs",
                                    AddInSafetyCheck.getCacheCULTUREs(),
                                    AddInSafetyCheck.getLocalCULTUREs(),
                                    AddInSafetyCheck.getCommonCULTUREs());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AddInSafetyCheck.saveLocalENCODINGs(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "Edit Allowed CULTUREs");
            }
            this.Visible = true;
        }
    } // class
} // namespace
