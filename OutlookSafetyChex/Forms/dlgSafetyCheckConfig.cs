using CheccoSafetyTools;
using OutlookSafetyChex.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OutlookSafetyChex
{
    public partial class dlgSafetyCheckConfig : Form
    {
        private Properties.Settings orig = Properties.Settings.Default;
        AddInSafetyCheck instance = Globals.AddInSafetyCheck;
        cst_Log mLogger = Globals.AddInSafetyCheck.mLogger;

        public dlgSafetyCheckConfig()
        {
            InitializeComponent();
            initializePane();
        }

        private bool settingsChanged()
        {
            return (Properties.Settings.Default != orig);
        }

        private void dlgSafetyCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (settingsChanged())
            {
                DialogResult rc = MessageBox.Show("Unsaved Changes!"
                                    + "\n\nPress [YES] to SAVE changes"
                                    + "\n\n[NO] to USE changes temporarily"
                                    + "\n\n[CANCEL] to REVERT to SAVED version",
                    "Unsaved Changed",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                switch (rc)
                {
                    case DialogResult.Yes:
                        Properties.Settings.Default.Save();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        Properties.Settings.Default.Reload();
                        break;
                }
            }
        }

#region application customizations

        void initializePane()
        {
            try
            {
                // options
                this.initializeOptionState();
             }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "initializePane()");
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
                    if (mLogger != null) mLogger.logException(ex, "initializeGridView(" + myGridView.Name + ")");
                }
                myGridView.ResumeLayout(true);
            }
        }

#endregion
        private void btnClearCache_Click(object sender, EventArgs ev)
        {
            Button myControl = sender as Button;
            if (myControl == this.btnClearCache)
            {
                instance.mWHOIS.clearCaches();
                instance.mDNSBL.clearCaches();
                instance.mHIBP.clearCaches();
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
            updateCheckBox(this.cb_Cultures, Properties.Settings.Default.opt_Lookup_Cultures);
            updateCheckBox(this.cbHiliteSpam, Properties.Settings.Default.opt_ShowSpamHeaders);
            updateCheckBox(this.cbThreading, Properties.Settings.Default.opt_ThreadedProcessing);
            // special case
            this.cbFlagUnknownContacts.Enabled = Properties.Settings.Default.opt_Lookup_CONTACTS;
            // update logging level (radio checkbox)
            this.rbLogNone.Checked = false;
            this.rbLogInfo.Checked = false;
            this.rbLogError.Checked = false;
            this.rbLogVerbose.Checked = false;
            switch (Properties.Settings.Default.log_Level)
            {
                case cst_Log.LOG_NONE: 
                    this.rbLogNone.Checked = true;
                    break;
                case cst_Log.LOG_INFO:
                    this.rbLogInfo.Checked = true;
                    break;
                case cst_Log.LOG_ERROR:
                    this.rbLogError.Checked = true;
                    break;
                case cst_Log.LOG_VERBOSE:
                    this.rbLogVerbose.Checked = true;
                    break;
                case cst_Log.LOG_ALL:
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
            else if (myControl == this.cbTabHeaders)
            {
                Properties.Settings.Default.test_Headers = isChecked;
            }
            else if (myControl == this.cbShowLog)
            {
                Properties.Settings.Default.opt_ShowLog = isChecked;
            }
            else if (myControl == this.cb_Cultures)
            {
                Properties.Settings.Default.opt_Lookup_Cultures = isChecked;
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
            else if (myControl == this.cbThreading)
            {
                Properties.Settings.Default.opt_ThreadedProcessing = isChecked;
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
                                instance.getCommonDNSBLsites(),
                                instance.getLocalDNSBL(), 
                                null );
                if ( dlg.ShowDialog() == DialogResult.OK )
                {
                    instance.saveDNSBLsites(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "editSpamlist");
            }
            this.Visible = true;
        }

        private void editWhitelist_Dialog(object sender, EventArgs ev)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Local Whitelist",
                                    instance.getCacheTLDs(),
                                    instance.getLocalWhitelist(),
                                    instance.getBaseWhitelist());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    instance.saveLocalWhitelist(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "editLocalWhitelist");
            }
            this.Visible = true;
        }

        private void rbLogNone_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log_Level = cst_Log.LOG_NONE;
        }

        private void rbLogError_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log_Level = cst_Log.LOG_ERROR;
        }

        private void rbLogInfo_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log_Level = cst_Log.LOG_INFO;
        }

        private void rbLogVerbose_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.log_Level = cst_Log.LOG_VERBOSE;
        }

        private void btnSaveOptions_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void editBlacklist_Dialog(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Local Blacklist",
                                    instance.getCacheTLDs(),
                                    instance.getLocalBlacklist(),
                                    instance.getBaseBlacklist());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    instance.saveLocalBlacklist(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "editLocalBlacklist");
            }
            this.Visible = true;
        }

        private void editMIMEtypes_Dialog(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Allowed MIMETYPEs",
                                    instance.getCacheMIMETYPEs(),
                                    instance.getLocalMIMETYPEs(),
                                    instance.getCommonMIMETYPEs());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    instance.saveLocalMIMETYPEs(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "Edit Allowed MIMETYPEs");
            }
            this.Visible = true;
        }

        private void editCodepages_Dialog(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Allowed CODEPAGEs",
                                    instance.getCacheCODEPAGEs(),
                                    instance.getLocalCODEPAGEs(),
                                    instance.getCommonCODEPAGEs());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    instance.saveLocalCODEPAGEs(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "Edit Allowed CODEPAGEs");
            }
            this.Visible = true;

        }

        private void editCULTUREs_Dialog(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                templateOptionList dlg = new templateOptionList("Edit Allowed CULTUREs",
                                    instance.getCacheCULTUREs(),
                                    instance.getLocalCULTUREs(),
                                    instance.getCommonCULTUREs());
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    instance.saveLocalCULTUREs(dlg.listBoxSelected.Items.Cast<String>().ToList());
                }
            }
            catch (Exception ex)
            {
                if (mLogger != null) mLogger.logException(ex, "Edit Allowed CULTUREs");
            }
            this.Visible = true;
        }

     } // class
} // namespace
