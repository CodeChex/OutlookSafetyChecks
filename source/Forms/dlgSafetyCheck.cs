using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using CheccoSafetyTools;
using cst_WHOIS = CheccoSafetyTools.cst_WHOISNET_API;
using OutlookSafetyChecks.Forms;

namespace OutlookSafetyChecks
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
            // Data
            cst_Util.setLoggingUI(this.textDebug);
            initializePane();
        }

        private void dlgSafetyCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            // reset logger
            cst_Util.setLoggingUI(null);
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
                this.infoTab.Text = Properties.Resources.Title_Envelope;
                initializeGridView(this.infoGridView, myVSTO.findTableClass<dtEnvelope>());
                // Parsed Header TAB
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
                this.myTabControl.SelectedTab = this.loggingTab;
                cst_Util.logInfo("Executing Selected Tests ...", null);
                if (myControl == this.btnRunTests)
                {
                    this.Cursor = Cursors.WaitCursor;
                    bool refresh = Properties.Settings.Default.opt_Force_REFRESH;
                    Globals.AddInSafetyCheck.resetLog(refresh);
                    // always parse headers
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Envelope + "] ...", null);
                        Globals.AddInSafetyCheck.ParseEnvelope(refresh);
                    }
                    // always parse headers
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Headers + "] ...", null);
                        Globals.AddInSafetyCheck.ParseHeaders(refresh);
                    }
                    if (this.cbTabContacts.CheckState == CheckState.Checked)
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Contacts + "] ...", null);
                        Globals.AddInSafetyCheck.AnalyzeContacts(refresh);
                    }
                    if (this.cbTabRoutes.CheckState == CheckState.Checked)
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Routing + "] ...", null);
                        Globals.AddInSafetyCheck.AnalyzeRoutes(refresh);
                    }
                    if (this.cbTabLinks.CheckState == CheckState.Checked)
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Links + "] ...", null);
                        Globals.AddInSafetyCheck.AnalyzeLinks(refresh);
                    }
                    if (this.cbTabAttachments.CheckState == CheckState.Checked)
                    {
                        cst_Util.logInfo("[" + Properties.Resources.Title_Attachments + "] ...", null);
                        Globals.AddInSafetyCheck.AnalyzeAttachments(refresh);
                    }
                    cst_Util.logInfo("Selected Tests Completed", null);
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
            updateCheckBox(this.cbTabLinks, Properties.Settings.Default.test_Links);
            updateCheckBox(this.cbTabAttachments, Properties.Settings.Default.test_Attachments);
            // options
            updateCheckBox(this.cbForceDataRefresh, Properties.Settings.Default.opt_Force_REFRESH);
            updateCheckBox(this.cbLookupWHOIS, Properties.Settings.Default.opt_Lookup_WHOIS);
            updateCheckBox(this.cbLookupDNSBL, Properties.Settings.Default.opt_Lookup_DNSBL);
            updateCheckBox(this.cbLookupHIBP, Properties.Settings.Default.opt_Lookup_HIBP);
            updateCheckBox(this.cbUseCACHE, Properties.Settings.Default.opt_Use_CACHE);
            updateCheckBox(this.cbVerifyContacts, Properties.Settings.Default.opt_Lookup_CONTACTS);
            updateCheckBox(this.cbTLD_Blacklist, Properties.Settings.Default.opt_Local_BLACKLIST);
            updateCheckBox(this.cbTLD_Whitelist, Properties.Settings.Default.opt_Local_WHITELIST);
            updateCheckBox(this.cbFlagUnknownContacts, Properties.Settings.Default.opt_Flag_UNKNOWN_CONTACTS);
            updateCheckBox(this.cbInspectAttachents, Properties.Settings.Default.opt_DeepInspect_ATTACHMENTS);
            updateCheckBox(this.cbInspectLinks, Properties.Settings.Default.opt_DeepInspect_LINKS);
            // special case
            this.cbFlagUnknownContacts.Enabled = Properties.Settings.Default.opt_Lookup_CONTACTS;
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
            else if (myControl == this.cbTLD_Blacklist)
            {
                Properties.Settings.Default.opt_Local_BLACKLIST = isChecked;
            }
            else if (myControl == this.cbTLD_Whitelist)
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
            else if (myControl == this.cbTabLinks)
            {
                Properties.Settings.Default.test_Links = isChecked;
            }
            else if (myControl == this.cbTabAttachments)
            {
                Properties.Settings.Default.test_Attachments = isChecked;
            }
            else
            {
                MessageBox.Show("Unknown CheckBox: [" + myControl.Text + "]");
            }
        }

        private void editSpamList_Dialog(object sender, EventArgs ev)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit DNSBL Sources",
                                cst_DNSBL.defaultSpamLists, cst_DNSBL.spamLists, null );
                if ( dlg.ShowDialog() == DialogResult.OK )
                {
                    cst_DNSBL.spamLists = dlg.listBoxSelected.Items.Cast<String>().ToArray();
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
                                    AddInSafetyCheck.getTLDs(), 
                                    AddInSafetyCheck.getLocalWhitelist(),
                                    AddInSafetyCheck.getBaseWhitelist());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AddInSafetyCheck.saveLocalWhitelist(dlg.listBoxSelected.Items.Cast<String>().ToArray());
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "editLocalWhitelist");
            }
            this.Visible = true;
        }

        private void editBlacklist_Dialog(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Local Blacklist",
                                    AddInSafetyCheck.getTLDs(),
                                    AddInSafetyCheck.getLocalBlacklist(),
                                    AddInSafetyCheck.getBaseBlacklist());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AddInSafetyCheck.saveLocalBlacklist(dlg.listBoxSelected.Items.Cast<String>().ToArray());
                }
            }
            catch (Exception ex)
            {
                cst_Util.logException(ex, "editLocalBlacklist");
            }
            this.Visible = true;
        }

        private void btnSaveOptions_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    } // class
} // namespace
