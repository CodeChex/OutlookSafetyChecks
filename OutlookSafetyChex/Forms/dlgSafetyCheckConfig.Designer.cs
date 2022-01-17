using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    partial class dlgSafetyCheckConfig
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerCheckGridView = new System.Windows.Forms.DataGridView();
            this.myTabControl = new System.Windows.Forms.TabControl();
            this.testTab = new System.Windows.Forms.TabPage();
            this.testTabPanel = new System.Windows.Forms.Panel();
            this.cbHiliteSpam = new System.Windows.Forms.CheckBox();
            this.cbShowLog = new System.Windows.Forms.CheckBox();
            this.cbTabHeaders = new System.Windows.Forms.CheckBox();
            this.btnSaveOptions = new System.Windows.Forms.Button();
            this.groupLogLevel = new System.Windows.Forms.GroupBox();
            this.rbLogVerbose = new System.Windows.Forms.RadioButton();
            this.rbLogInfo = new System.Windows.Forms.RadioButton();
            this.rbLogError = new System.Windows.Forms.RadioButton();
            this.rbLogNone = new System.Windows.Forms.RadioButton();
            this.cbTabBody = new System.Windows.Forms.CheckBox();
            this.cbTabAttachments = new System.Windows.Forms.CheckBox();
            this.cbTabLinks = new System.Windows.Forms.CheckBox();
            this.cbTabRoutes = new System.Windows.Forms.CheckBox();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.cbTabContacts = new System.Windows.Forms.CheckBox();
            this.cbForceDataRefresh = new System.Windows.Forms.CheckBox();
            this.cbUseCACHE = new System.Windows.Forms.CheckBox();
            this.deepTab = new System.Windows.Forms.TabPage();
            this.deeptTabPanel = new System.Windows.Forms.Panel();
            this.btnEdit_CULTUREs = new System.Windows.Forms.Button();
            this.cb_Cultures = new System.Windows.Forms.CheckBox();
            this.btnEdit_CODEPAGEs = new System.Windows.Forms.Button();
            this.cb_Codepages = new System.Windows.Forms.CheckBox();
            this.btnEdit_MIMETYPEs = new System.Windows.Forms.Button();
            this.cb_MIMEtypes = new System.Windows.Forms.CheckBox();
            this.cbFlagUnknownContacts = new System.Windows.Forms.CheckBox();
            this.cbInspectLinks = new System.Windows.Forms.CheckBox();
            this.btnEdit_Blacklist = new System.Windows.Forms.Button();
            this.btnEdit_Whitelist = new System.Windows.Forms.Button();
            this.cbVerifyContacts = new System.Windows.Forms.CheckBox();
            this.btnEdit_DNSBL = new System.Windows.Forms.Button();
            this.cbInspectAttachents = new System.Windows.Forms.CheckBox();
            this.cbHost_Blacklist = new System.Windows.Forms.CheckBox();
            this.cbHost_Whitelist = new System.Windows.Forms.CheckBox();
            this.cbLookupHIBP = new System.Windows.Forms.CheckBox();
            this.cbLookupWHOIS = new System.Windows.Forms.CheckBox();
            this.cbLookupDNSBL = new System.Windows.Forms.CheckBox();
            this.cbThreading = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.headerCheckGridView)).BeginInit();
            this.myTabControl.SuspendLayout();
            this.testTab.SuspendLayout();
            this.testTabPanel.SuspendLayout();
            this.groupLogLevel.SuspendLayout();
            this.deepTab.SuspendLayout();
            this.deeptTabPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerCheckGridView
            // 
            this.headerCheckGridView.Location = new System.Drawing.Point(0, 0);
            this.headerCheckGridView.Name = "headerCheckGridView";
            this.headerCheckGridView.Size = new System.Drawing.Size(240, 150);
            this.headerCheckGridView.TabIndex = 0;
            // 
            // myTabControl
            // 
            this.myTabControl.Controls.Add(this.testTab);
            this.myTabControl.Controls.Add(this.deepTab);
            this.myTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl.Location = new System.Drawing.Point(0, 0);
            this.myTabControl.Name = "myTabControl";
            this.myTabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.myTabControl.SelectedIndex = 0;
            this.myTabControl.Size = new System.Drawing.Size(431, 196);
            this.myTabControl.TabIndex = 2;
            // 
            // testTab
            // 
            this.testTab.Controls.Add(this.testTabPanel);
            this.testTab.Location = new System.Drawing.Point(4, 22);
            this.testTab.Name = "testTab";
            this.testTab.Size = new System.Drawing.Size(423, 170);
            this.testTab.TabIndex = 2;
            this.testTab.Text = "Analysis / Tests";
            this.testTab.UseVisualStyleBackColor = true;
            // 
            // testTabPanel
            // 
            this.testTabPanel.Controls.Add(this.cbThreading);
            this.testTabPanel.Controls.Add(this.cbHiliteSpam);
            this.testTabPanel.Controls.Add(this.cbShowLog);
            this.testTabPanel.Controls.Add(this.cbTabHeaders);
            this.testTabPanel.Controls.Add(this.btnSaveOptions);
            this.testTabPanel.Controls.Add(this.groupLogLevel);
            this.testTabPanel.Controls.Add(this.cbTabBody);
            this.testTabPanel.Controls.Add(this.cbTabAttachments);
            this.testTabPanel.Controls.Add(this.cbTabLinks);
            this.testTabPanel.Controls.Add(this.cbTabRoutes);
            this.testTabPanel.Controls.Add(this.btnClearCache);
            this.testTabPanel.Controls.Add(this.cbTabContacts);
            this.testTabPanel.Controls.Add(this.cbForceDataRefresh);
            this.testTabPanel.Controls.Add(this.cbUseCACHE);
            this.testTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testTabPanel.Location = new System.Drawing.Point(0, 0);
            this.testTabPanel.Name = "testTabPanel";
            this.testTabPanel.Size = new System.Drawing.Size(423, 170);
            this.testTabPanel.TabIndex = 0;
            // 
            // cbHiliteSpam
            // 
            this.cbHiliteSpam.AutoSize = true;
            this.cbHiliteSpam.Location = new System.Drawing.Point(185, 41);
            this.cbHiliteSpam.Name = "cbHiliteSpam";
            this.cbHiliteSpam.Size = new System.Drawing.Size(117, 17);
            this.cbHiliteSpam.TabIndex = 41;
            this.cbHiliteSpam.Text = "Log Spam Headers";
            this.cbHiliteSpam.UseVisualStyleBackColor = true;
            this.cbHiliteSpam.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbShowLog
            // 
            this.cbShowLog.AutoSize = true;
            this.cbShowLog.Location = new System.Drawing.Point(185, 63);
            this.cbShowLog.Name = "cbShowLog";
            this.cbShowLog.Size = new System.Drawing.Size(118, 17);
            this.cbShowLog.TabIndex = 29;
            this.cbShowLog.Text = "Show Log Progress";
            this.cbShowLog.UseVisualStyleBackColor = true;
            this.cbShowLog.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTabHeaders
            // 
            this.cbTabHeaders.AutoSize = true;
            this.cbTabHeaders.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabHeaders.Location = new System.Drawing.Point(19, 18);
            this.cbTabHeaders.Name = "cbTabHeaders";
            this.cbTabHeaders.Size = new System.Drawing.Size(66, 17);
            this.cbTabHeaders.TabIndex = 40;
            this.cbTabHeaders.Text = "Headers";
            this.cbTabHeaders.UseVisualStyleBackColor = true;
            this.cbTabHeaders.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnSaveOptions
            // 
            this.btnSaveOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOptions.Image = global::OutlookSafetyChex.Properties.Resources.Save_16x_32;
            this.btnSaveOptions.Location = new System.Drawing.Point(321, 130);
            this.btnSaveOptions.Name = "btnSaveOptions";
            this.btnSaveOptions.Size = new System.Drawing.Size(83, 27);
            this.btnSaveOptions.TabIndex = 37;
            this.btnSaveOptions.Text = "&Save";
            this.btnSaveOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveOptions.UseVisualStyleBackColor = true;
            this.btnSaveOptions.Click += new System.EventHandler(this.btnSaveOptions_Click);
            // 
            // groupLogLevel
            // 
            this.groupLogLevel.Controls.Add(this.rbLogVerbose);
            this.groupLogLevel.Controls.Add(this.rbLogInfo);
            this.groupLogLevel.Controls.Add(this.rbLogError);
            this.groupLogLevel.Controls.Add(this.rbLogNone);
            this.groupLogLevel.Location = new System.Drawing.Point(306, 6);
            this.groupLogLevel.Name = "groupLogLevel";
            this.groupLogLevel.Size = new System.Drawing.Size(98, 99);
            this.groupLogLevel.TabIndex = 39;
            this.groupLogLevel.TabStop = false;
            this.groupLogLevel.Text = "Logging Options";
            // 
            // rbLogVerbose
            // 
            this.rbLogVerbose.AutoSize = true;
            this.rbLogVerbose.Location = new System.Drawing.Point(15, 73);
            this.rbLogVerbose.Name = "rbLogVerbose";
            this.rbLogVerbose.Size = new System.Drawing.Size(64, 17);
            this.rbLogVerbose.TabIndex = 3;
            this.rbLogVerbose.TabStop = true;
            this.rbLogVerbose.Text = "Verbose";
            this.rbLogVerbose.UseVisualStyleBackColor = true;
            this.rbLogVerbose.CheckedChanged += new System.EventHandler(this.rbLogVerbose_CheckedChanged);
            // 
            // rbLogInfo
            // 
            this.rbLogInfo.AutoSize = true;
            this.rbLogInfo.Location = new System.Drawing.Point(15, 56);
            this.rbLogInfo.Name = "rbLogInfo";
            this.rbLogInfo.Size = new System.Drawing.Size(66, 17);
            this.rbLogInfo.TabIndex = 2;
            this.rbLogInfo.TabStop = true;
            this.rbLogInfo.Text = "Progress";
            this.rbLogInfo.UseVisualStyleBackColor = true;
            this.rbLogInfo.CheckedChanged += new System.EventHandler(this.rbLogInfo_CheckedChanged);
            // 
            // rbLogError
            // 
            this.rbLogError.AutoSize = true;
            this.rbLogError.Location = new System.Drawing.Point(15, 39);
            this.rbLogError.Name = "rbLogError";
            this.rbLogError.Size = new System.Drawing.Size(52, 17);
            this.rbLogError.TabIndex = 1;
            this.rbLogError.TabStop = true;
            this.rbLogError.Text = "Errors";
            this.rbLogError.UseVisualStyleBackColor = true;
            this.rbLogError.CheckedChanged += new System.EventHandler(this.rbLogError_CheckedChanged);
            // 
            // rbLogNone
            // 
            this.rbLogNone.AutoSize = true;
            this.rbLogNone.Location = new System.Drawing.Point(15, 22);
            this.rbLogNone.Name = "rbLogNone";
            this.rbLogNone.Size = new System.Drawing.Size(51, 17);
            this.rbLogNone.TabIndex = 0;
            this.rbLogNone.TabStop = true;
            this.rbLogNone.Text = "None";
            this.rbLogNone.UseVisualStyleBackColor = true;
            this.rbLogNone.CheckedChanged += new System.EventHandler(this.rbLogNone_CheckedChanged);
            // 
            // cbTabBody
            // 
            this.cbTabBody.AutoSize = true;
            this.cbTabBody.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabBody.Location = new System.Drawing.Point(93, 64);
            this.cbTabBody.Name = "cbTabBody";
            this.cbTabBody.Size = new System.Drawing.Size(50, 17);
            this.cbTabBody.TabIndex = 38;
            this.cbTabBody.Text = global::OutlookSafetyChex.Properties.Resources.Title_Body;
            this.cbTabBody.UseVisualStyleBackColor = true;
            this.cbTabBody.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTabAttachments
            // 
            this.cbTabAttachments.AutoSize = true;
            this.cbTabAttachments.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabAttachments.Location = new System.Drawing.Point(93, 41);
            this.cbTabAttachments.Name = "cbTabAttachments";
            this.cbTabAttachments.Size = new System.Drawing.Size(85, 17);
            this.cbTabAttachments.TabIndex = 36;
            this.cbTabAttachments.Text = global::OutlookSafetyChex.Properties.Resources.Title_Attachments;
            this.cbTabAttachments.UseVisualStyleBackColor = true;
            this.cbTabAttachments.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTabLinks
            // 
            this.cbTabLinks.AutoSize = true;
            this.cbTabLinks.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabLinks.Location = new System.Drawing.Point(93, 18);
            this.cbTabLinks.Name = "cbTabLinks";
            this.cbTabLinks.Size = new System.Drawing.Size(51, 17);
            this.cbTabLinks.TabIndex = 35;
            this.cbTabLinks.Text = global::OutlookSafetyChex.Properties.Resources.Title_Links;
            this.cbTabLinks.UseVisualStyleBackColor = true;
            this.cbTabLinks.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTabRoutes
            // 
            this.cbTabRoutes.AutoSize = true;
            this.cbTabRoutes.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabRoutes.Location = new System.Drawing.Point(19, 63);
            this.cbTabRoutes.Name = "cbTabRoutes";
            this.cbTabRoutes.Size = new System.Drawing.Size(63, 17);
            this.cbTabRoutes.TabIndex = 34;
            this.cbTabRoutes.Text = global::OutlookSafetyChex.Properties.Resources.Title_Routing;
            this.cbTabRoutes.UseVisualStyleBackColor = true;
            this.cbTabRoutes.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCache.Location = new System.Drawing.Point(120, 107);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(78, 23);
            this.btnClearCache.TabIndex = 30;
            this.btnClearCache.Text = "Clear Cache";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // cbTabContacts
            // 
            this.cbTabContacts.AutoSize = true;
            this.cbTabContacts.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabContacts.Location = new System.Drawing.Point(19, 41);
            this.cbTabContacts.Name = "cbTabContacts";
            this.cbTabContacts.Size = new System.Drawing.Size(68, 17);
            this.cbTabContacts.TabIndex = 33;
            this.cbTabContacts.Text = global::OutlookSafetyChex.Properties.Resources.Title_Contacts;
            this.cbTabContacts.UseVisualStyleBackColor = true;
            this.cbTabContacts.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbForceDataRefresh
            // 
            this.cbForceDataRefresh.AutoSize = true;
            this.cbForceDataRefresh.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbForceDataRefresh.Location = new System.Drawing.Point(185, 18);
            this.cbForceDataRefresh.Name = "cbForceDataRefresh";
            this.cbForceDataRefresh.Size = new System.Drawing.Size(93, 17);
            this.cbForceDataRefresh.TabIndex = 31;
            this.cbForceDataRefresh.Text = "Force Refresh";
            this.cbForceDataRefresh.UseVisualStyleBackColor = true;
            this.cbForceDataRefresh.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbUseCACHE
            // 
            this.cbUseCACHE.AutoSize = true;
            this.cbUseCACHE.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbUseCACHE.Location = new System.Drawing.Point(19, 111);
            this.cbUseCACHE.Name = "cbUseCACHE";
            this.cbUseCACHE.Size = new System.Drawing.Size(95, 17);
            this.cbUseCACHE.TabIndex = 32;
            this.cbUseCACHE.Text = "Cache Results";
            this.cbUseCACHE.UseVisualStyleBackColor = true;
            this.cbUseCACHE.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // deepTab
            // 
            this.deepTab.Controls.Add(this.deeptTabPanel);
            this.deepTab.Location = new System.Drawing.Point(4, 22);
            this.deepTab.Name = "deepTab";
            this.deepTab.Size = new System.Drawing.Size(423, 170);
            this.deepTab.TabIndex = 1;
            this.deepTab.Text = "Deep Inspection";
            this.deepTab.UseVisualStyleBackColor = true;
            // 
            // deeptTabPanel
            // 
            this.deeptTabPanel.Controls.Add(this.btnEdit_CULTUREs);
            this.deeptTabPanel.Controls.Add(this.cb_Cultures);
            this.deeptTabPanel.Controls.Add(this.btnEdit_CODEPAGEs);
            this.deeptTabPanel.Controls.Add(this.cb_Codepages);
            this.deeptTabPanel.Controls.Add(this.btnEdit_MIMETYPEs);
            this.deeptTabPanel.Controls.Add(this.cb_MIMEtypes);
            this.deeptTabPanel.Controls.Add(this.cbFlagUnknownContacts);
            this.deeptTabPanel.Controls.Add(this.cbInspectLinks);
            this.deeptTabPanel.Controls.Add(this.btnEdit_Blacklist);
            this.deeptTabPanel.Controls.Add(this.btnEdit_Whitelist);
            this.deeptTabPanel.Controls.Add(this.cbVerifyContacts);
            this.deeptTabPanel.Controls.Add(this.btnEdit_DNSBL);
            this.deeptTabPanel.Controls.Add(this.cbInspectAttachents);
            this.deeptTabPanel.Controls.Add(this.cbHost_Blacklist);
            this.deeptTabPanel.Controls.Add(this.cbHost_Whitelist);
            this.deeptTabPanel.Controls.Add(this.cbLookupHIBP);
            this.deeptTabPanel.Controls.Add(this.cbLookupWHOIS);
            this.deeptTabPanel.Controls.Add(this.cbLookupDNSBL);
            this.deeptTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deeptTabPanel.Location = new System.Drawing.Point(0, 0);
            this.deeptTabPanel.Name = "deeptTabPanel";
            this.deeptTabPanel.Size = new System.Drawing.Size(423, 170);
            this.deeptTabPanel.TabIndex = 0;
            // 
            // btnEdit_CULTUREs
            // 
            this.btnEdit_CULTUREs.Image = global::OutlookSafetyChex.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_CULTUREs.Location = new System.Drawing.Point(172, 124);
            this.btnEdit_CULTUREs.Name = "btnEdit_CULTUREs";
            this.btnEdit_CULTUREs.Size = new System.Drawing.Size(56, 23);
            this.btnEdit_CULTUREs.TabIndex = 52;
            this.btnEdit_CULTUREs.Text = "Edit";
            this.btnEdit_CULTUREs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_CULTUREs.UseVisualStyleBackColor = true;
            // 
            // cb_Cultures
            // 
            this.cb_Cultures.AutoSize = true;
            this.cb_Cultures.ForeColor = System.Drawing.Color.DarkBlue;
            this.cb_Cultures.Location = new System.Drawing.Point(8, 128);
            this.cb_Cultures.Name = "cb_Cultures";
            this.cb_Cultures.Size = new System.Drawing.Size(156, 17);
            this.cb_Cultures.TabIndex = 51;
            this.cb_Cultures.TabStop = false;
            this.cb_Cultures.Text = "Language-Country Whitelist";
            this.cb_Cultures.UseVisualStyleBackColor = true;
            this.cb_Cultures.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnEdit_CODEPAGEs
            // 
            this.btnEdit_CODEPAGEs.Image = global::OutlookSafetyChex.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_CODEPAGEs.Location = new System.Drawing.Point(172, 101);
            this.btnEdit_CODEPAGEs.Name = "btnEdit_CODEPAGEs";
            this.btnEdit_CODEPAGEs.Size = new System.Drawing.Size(56, 23);
            this.btnEdit_CODEPAGEs.TabIndex = 50;
            this.btnEdit_CODEPAGEs.Text = "Edit";
            this.btnEdit_CODEPAGEs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_CODEPAGEs.UseVisualStyleBackColor = true;
            // 
            // cb_Codepages
            // 
            this.cb_Codepages.AutoSize = true;
            this.cb_Codepages.ForeColor = System.Drawing.Color.DarkBlue;
            this.cb_Codepages.Location = new System.Drawing.Point(8, 105);
            this.cb_Codepages.Name = "cb_Codepages";
            this.cb_Codepages.Size = new System.Drawing.Size(119, 17);
            this.cb_Codepages.TabIndex = 49;
            this.cb_Codepages.Text = "CodePage Whitelist";
            this.cb_Codepages.UseVisualStyleBackColor = true;
            this.cb_Codepages.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnEdit_MIMETYPEs
            // 
            this.btnEdit_MIMETYPEs.Image = global::OutlookSafetyChex.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_MIMETYPEs.Location = new System.Drawing.Point(172, 78);
            this.btnEdit_MIMETYPEs.Name = "btnEdit_MIMETYPEs";
            this.btnEdit_MIMETYPEs.Size = new System.Drawing.Size(56, 23);
            this.btnEdit_MIMETYPEs.TabIndex = 48;
            this.btnEdit_MIMETYPEs.Text = "Edit";
            this.btnEdit_MIMETYPEs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_MIMETYPEs.UseVisualStyleBackColor = true;
            // 
            // cb_MIMEtypes
            // 
            this.cb_MIMEtypes.AutoSize = true;
            this.cb_MIMEtypes.ForeColor = System.Drawing.Color.DarkBlue;
            this.cb_MIMEtypes.Location = new System.Drawing.Point(8, 82);
            this.cb_MIMEtypes.Name = "cb_MIMEtypes";
            this.cb_MIMEtypes.Size = new System.Drawing.Size(124, 17);
            this.cb_MIMEtypes.TabIndex = 47;
            this.cb_MIMEtypes.Text = "MIME Type Whitelist";
            this.cb_MIMEtypes.UseVisualStyleBackColor = true;
            this.cb_MIMEtypes.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbFlagUnknownContacts
            // 
            this.cbFlagUnknownContacts.AutoSize = true;
            this.cbFlagUnknownContacts.ForeColor = System.Drawing.Color.Black;
            this.cbFlagUnknownContacts.Location = new System.Drawing.Point(300, 121);
            this.cbFlagUnknownContacts.Name = "cbFlagUnknownContacts";
            this.cbFlagUnknownContacts.Size = new System.Drawing.Size(89, 17);
            this.cbFlagUnknownContacts.TabIndex = 41;
            this.cbFlagUnknownContacts.Text = global::OutlookSafetyChex.Properties.Resources.Option_FlagUknownContacts;
            this.cbFlagUnknownContacts.UseVisualStyleBackColor = true;
            this.cbFlagUnknownContacts.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbInspectLinks
            // 
            this.cbInspectLinks.AutoSize = true;
            this.cbInspectLinks.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbInspectLinks.Location = new System.Drawing.Point(255, 29);
            this.cbInspectLinks.Name = "cbInspectLinks";
            this.cbInspectLinks.Size = new System.Drawing.Size(96, 17);
            this.cbInspectLinks.TabIndex = 46;
            this.cbInspectLinks.Text = "Inpsect Links *";
            this.cbInspectLinks.UseVisualStyleBackColor = true;
            this.cbInspectLinks.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnEdit_Blacklist
            // 
            this.btnEdit_Blacklist.Image = global::OutlookSafetyChex.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_Blacklist.Location = new System.Drawing.Point(172, 9);
            this.btnEdit_Blacklist.Name = "btnEdit_Blacklist";
            this.btnEdit_Blacklist.Size = new System.Drawing.Size(56, 23);
            this.btnEdit_Blacklist.TabIndex = 45;
            this.btnEdit_Blacklist.Text = "Edit";
            this.btnEdit_Blacklist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_Blacklist.UseVisualStyleBackColor = true;
            // 
            // btnEdit_Whitelist
            // 
            this.btnEdit_Whitelist.Image = global::OutlookSafetyChex.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_Whitelist.Location = new System.Drawing.Point(172, 32);
            this.btnEdit_Whitelist.Name = "btnEdit_Whitelist";
            this.btnEdit_Whitelist.Size = new System.Drawing.Size(56, 23);
            this.btnEdit_Whitelist.TabIndex = 44;
            this.btnEdit_Whitelist.Text = "Edit";
            this.btnEdit_Whitelist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_Whitelist.UseVisualStyleBackColor = true;
            // 
            // cbVerifyContacts
            // 
            this.cbVerifyContacts.AutoSize = true;
            this.cbVerifyContacts.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbVerifyContacts.Location = new System.Drawing.Point(255, 98);
            this.cbVerifyContacts.Name = "cbVerifyContacts";
            this.cbVerifyContacts.Size = new System.Drawing.Size(118, 17);
            this.cbVerifyContacts.TabIndex = 38;
            this.cbVerifyContacts.Text = global::OutlookSafetyChex.Properties.Resources.Option_VerifyContacts;
            this.cbVerifyContacts.UseVisualStyleBackColor = true;
            this.cbVerifyContacts.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnEdit_DNSBL
            // 
            this.btnEdit_DNSBL.Image = global::OutlookSafetyChex.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_DNSBL.Location = new System.Drawing.Point(172, 55);
            this.btnEdit_DNSBL.Name = "btnEdit_DNSBL";
            this.btnEdit_DNSBL.Size = new System.Drawing.Size(56, 23);
            this.btnEdit_DNSBL.TabIndex = 43;
            this.btnEdit_DNSBL.Text = "Edit";
            this.btnEdit_DNSBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_DNSBL.UseVisualStyleBackColor = true;
            // 
            // cbInspectAttachents
            // 
            this.cbInspectAttachents.AutoSize = true;
            this.cbInspectAttachents.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbInspectAttachents.Location = new System.Drawing.Point(255, 8);
            this.cbInspectAttachents.Name = "cbInspectAttachents";
            this.cbInspectAttachents.Size = new System.Drawing.Size(134, 17);
            this.cbInspectAttachents.TabIndex = 42;
            this.cbInspectAttachents.Text = "Inspect Attachments **";
            this.cbInspectAttachents.UseVisualStyleBackColor = true;
            this.cbInspectAttachents.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbHost_Blacklist
            // 
            this.cbHost_Blacklist.AutoSize = true;
            this.cbHost_Blacklist.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbHost_Blacklist.Location = new System.Drawing.Point(8, 13);
            this.cbHost_Blacklist.Name = "cbHost_Blacklist";
            this.cbHost_Blacklist.Size = new System.Drawing.Size(131, 17);
            this.cbHost_Blacklist.TabIndex = 40;
            this.cbHost_Blacklist.Text = "Host/Domain Blacklist";
            this.cbHost_Blacklist.UseVisualStyleBackColor = true;
            this.cbHost_Blacklist.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbHost_Whitelist
            // 
            this.cbHost_Whitelist.AutoSize = true;
            this.cbHost_Whitelist.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbHost_Whitelist.Location = new System.Drawing.Point(8, 36);
            this.cbHost_Whitelist.Name = "cbHost_Whitelist";
            this.cbHost_Whitelist.Size = new System.Drawing.Size(132, 17);
            this.cbHost_Whitelist.TabIndex = 39;
            this.cbHost_Whitelist.Text = "Host/Domain Whitelist";
            this.cbHost_Whitelist.UseVisualStyleBackColor = true;
            this.cbHost_Whitelist.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbLookupHIBP
            // 
            this.cbLookupHIBP.AutoSize = true;
            this.cbLookupHIBP.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbLookupHIBP.Location = new System.Drawing.Point(255, 75);
            this.cbLookupHIBP.Name = "cbLookupHIBP";
            this.cbLookupHIBP.Size = new System.Drawing.Size(139, 17);
            this.cbLookupHIBP.TabIndex = 37;
            this.cbLookupHIBP.Text = "Pwn\'d Lookup (HIBP) **";
            this.cbLookupHIBP.UseVisualStyleBackColor = true;
            this.cbLookupHIBP.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbLookupWHOIS
            // 
            this.cbLookupWHOIS.AutoSize = true;
            this.cbLookupWHOIS.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbLookupWHOIS.Location = new System.Drawing.Point(255, 52);
            this.cbLookupWHOIS.Name = "cbLookupWHOIS";
            this.cbLookupWHOIS.Size = new System.Drawing.Size(149, 17);
            this.cbLookupWHOIS.TabIndex = 35;
            this.cbLookupWHOIS.Text = "Owner Lookup (WHOIS) *";
            this.cbLookupWHOIS.UseVisualStyleBackColor = true;
            this.cbLookupWHOIS.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbLookupDNSBL
            // 
            this.cbLookupDNSBL.AutoSize = true;
            this.cbLookupDNSBL.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbLookupDNSBL.Location = new System.Drawing.Point(8, 59);
            this.cbLookupDNSBL.Name = "cbLookupDNSBL";
            this.cbLookupDNSBL.Size = new System.Drawing.Size(163, 17);
            this.cbLookupDNSBL.TabIndex = 36;
            this.cbLookupDNSBL.Text = "External Blacklists (DNSBL) *";
            this.cbLookupDNSBL.UseVisualStyleBackColor = true;
            this.cbLookupDNSBL.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbThreading
            // 
            this.cbThreading.AutoSize = true;
            this.cbThreading.Location = new System.Drawing.Point(19, 134);
            this.cbThreading.Name = "cbThreading";
            this.cbThreading.Size = new System.Drawing.Size(115, 17);
            this.cbThreading.TabIndex = 42;
            this.cbThreading.Text = "Multi-Thread Mode";
            this.cbThreading.UseVisualStyleBackColor = true;
            this.cbThreading.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // dlgSafetyCheckConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(431, 196);
            this.Controls.Add(this.myTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(256, 235);
            this.Name = "dlgSafetyCheckConfig";
            this.Text = "✓ Configuration: Email Safety Checks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgSafetyCheck_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.headerCheckGridView)).EndInit();
            this.myTabControl.ResumeLayout(false);
            this.testTab.ResumeLayout(false);
            this.testTabPanel.ResumeLayout(false);
            this.testTabPanel.PerformLayout();
            this.groupLogLevel.ResumeLayout(false);
            this.groupLogLevel.PerformLayout();
            this.deepTab.ResumeLayout(false);
            this.deeptTabPanel.ResumeLayout(false);
            this.deeptTabPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public DataGridView headerCheckGridView;
        public TabControl myTabControl;
        private TabPage testTab;
        private TabPage deepTab;
        private Panel testTabPanel;
        private CheckBox cbHiliteSpam;
        private CheckBox cbShowLog;
        private CheckBox cbTabHeaders;
        private Button btnSaveOptions;
        private GroupBox groupLogLevel;
        private RadioButton rbLogVerbose;
        private RadioButton rbLogInfo;
        private RadioButton rbLogError;
        private RadioButton rbLogNone;
        private CheckBox cbTabBody;
        private CheckBox cbTabAttachments;
        private CheckBox cbTabLinks;
        private CheckBox cbTabRoutes;
        private Button btnClearCache;
        private CheckBox cbTabContacts;
        private CheckBox cbForceDataRefresh;
        private CheckBox cbUseCACHE;
        private Panel deeptTabPanel;
        private Button btnEdit_CULTUREs;
        private CheckBox cb_Cultures;
        private Button btnEdit_CODEPAGEs;
        private CheckBox cb_Codepages;
        private Button btnEdit_MIMETYPEs;
        private CheckBox cb_MIMEtypes;
        private CheckBox cbFlagUnknownContacts;
        private CheckBox cbInspectLinks;
        private Button btnEdit_Blacklist;
        private Button btnEdit_Whitelist;
        private CheckBox cbVerifyContacts;
        private Button btnEdit_DNSBL;
        private CheckBox cbInspectAttachents;
        private CheckBox cbHost_Blacklist;
        private CheckBox cbHost_Whitelist;
        private CheckBox cbLookupHIBP;
        private CheckBox cbLookupWHOIS;
        private CheckBox cbLookupDNSBL;
        private CheckBox cbThreading;
    }
}
