using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChex
{
    partial class dlgSafetyCheck
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
            this.myTabControl = new System.Windows.Forms.TabControl();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitMainTopHalf = new System.Windows.Forms.SplitContainer();
            this.splitMainTestsOptions = new System.Windows.Forms.SplitContainer();
            this.groupTests = new System.Windows.Forms.GroupBox();
            this.groupLogLevel = new System.Windows.Forms.GroupBox();
            this.cbShowLog = new System.Windows.Forms.CheckBox();
            this.rbLogVerbose = new System.Windows.Forms.RadioButton();
            this.rbLogInfo = new System.Windows.Forms.RadioButton();
            this.rbLogError = new System.Windows.Forms.RadioButton();
            this.rbLogNone = new System.Windows.Forms.RadioButton();
            this.cbTabBody = new System.Windows.Forms.CheckBox();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.cbTabAttachments = new System.Windows.Forms.CheckBox();
            this.cbTabLinks = new System.Windows.Forms.CheckBox();
            this.cbTabRoutes = new System.Windows.Forms.CheckBox();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.cbTabContacts = new System.Windows.Forms.CheckBox();
            this.cbForceDataRefresh = new System.Windows.Forms.CheckBox();
            this.cbUseCACHE = new System.Windows.Forms.CheckBox();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.labelVersion = new System.Windows.Forms.LinkLabel();
            this.btnSaveOptions = new System.Windows.Forms.Button();
            this.cbInspectLinks = new System.Windows.Forms.CheckBox();
            this.btnEdit_Blacklist = new System.Windows.Forms.Button();
            this.btnEdit_Whitelist = new System.Windows.Forms.Button();
            this.btnEdit_SpamList = new System.Windows.Forms.Button();
            this.cbInspectAttachents = new System.Windows.Forms.CheckBox();
            this.cbFlagUnknownContacts = new System.Windows.Forms.CheckBox();
            this.cbTLD_Blacklist = new System.Windows.Forms.CheckBox();
            this.cbTLD_Whitelist = new System.Windows.Forms.CheckBox();
            this.cbVerifyContacts = new System.Windows.Forms.CheckBox();
            this.cbLookupHIBP = new System.Windows.Forms.CheckBox();
            this.cbLookupWHOIS = new System.Windows.Forms.CheckBox();
            this.cbLookupDNSBL = new System.Windows.Forms.CheckBox();
            this.textBoxProgress = new System.Windows.Forms.TextBox();
            this.logGridView = new System.Windows.Forms.DataGridView();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.infoGridView = new System.Windows.Forms.DataGridView();
            this.headerTab = new System.Windows.Forms.TabPage();
            this.splitHeaders = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.headerGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxHeaders = new System.Windows.Forms.GroupBox();
            this.rawHeaderTextBox = new System.Windows.Forms.TextBox();
            this.contactTab = new System.Windows.Forms.TabPage();
            this.splitContacts = new System.Windows.Forms.SplitContainer();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.senderGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxContacts = new System.Windows.Forms.GroupBox();
            this.recipientsGridView = new System.Windows.Forms.DataGridView();
            this.routeTab = new System.Windows.Forms.TabPage();
            this.splitRouting = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.routeCheckGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxRoutes = new System.Windows.Forms.GroupBox();
            this.routeListGridView = new System.Windows.Forms.DataGridView();
            this.bodyTab = new System.Windows.Forms.TabPage();
            this.bodyGridView = new System.Windows.Forms.DataGridView();
            this.linksTab = new System.Windows.Forms.TabPage();
            this.splitLinks = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkCheckGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxLinks = new System.Windows.Forms.GroupBox();
            this.linkListGridView = new System.Windows.Forms.DataGridView();
            this.attachmentsTab = new System.Windows.Forms.TabPage();
            this.attachmentsGridView = new System.Windows.Forms.DataGridView();
            this.loggingTab = new System.Windows.Forms.TabPage();
            this.textDebug = new System.Windows.Forms.TextBox();
            this.myTabControl.SuspendLayout();
            this.optionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMainTopHalf)).BeginInit();
            this.splitMainTopHalf.Panel1.SuspendLayout();
            this.splitMainTopHalf.Panel2.SuspendLayout();
            this.splitMainTopHalf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMainTestsOptions)).BeginInit();
            this.splitMainTestsOptions.Panel1.SuspendLayout();
            this.splitMainTestsOptions.Panel2.SuspendLayout();
            this.splitMainTestsOptions.SuspendLayout();
            this.groupTests.SuspendLayout();
            this.groupLogLevel.SuspendLayout();
            this.groupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).BeginInit();
            this.infoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGridView)).BeginInit();
            this.headerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitHeaders)).BeginInit();
            this.splitHeaders.Panel1.SuspendLayout();
            this.splitHeaders.Panel2.SuspendLayout();
            this.splitHeaders.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGridView)).BeginInit();
            this.groupBoxHeaders.SuspendLayout();
            this.contactTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContacts)).BeginInit();
            this.splitContacts.Panel1.SuspendLayout();
            this.splitContacts.Panel2.SuspendLayout();
            this.splitContacts.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.senderGridView)).BeginInit();
            this.groupBoxContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipientsGridView)).BeginInit();
            this.routeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRouting)).BeginInit();
            this.splitRouting.Panel1.SuspendLayout();
            this.splitRouting.Panel2.SuspendLayout();
            this.splitRouting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routeCheckGridView)).BeginInit();
            this.groupBoxRoutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routeListGridView)).BeginInit();
            this.bodyTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodyGridView)).BeginInit();
            this.linksTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLinks)).BeginInit();
            this.splitLinks.Panel1.SuspendLayout();
            this.splitLinks.Panel2.SuspendLayout();
            this.splitLinks.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkCheckGridView)).BeginInit();
            this.groupBoxLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkListGridView)).BeginInit();
            this.attachmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentsGridView)).BeginInit();
            this.loggingTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // myTabControl
            // 
            this.myTabControl.Controls.Add(this.optionsTab);
            this.myTabControl.Controls.Add(this.infoTab);
            this.myTabControl.Controls.Add(this.headerTab);
            this.myTabControl.Controls.Add(this.contactTab);
            this.myTabControl.Controls.Add(this.routeTab);
            this.myTabControl.Controls.Add(this.bodyTab);
            this.myTabControl.Controls.Add(this.linksTab);
            this.myTabControl.Controls.Add(this.attachmentsTab);
            this.myTabControl.Controls.Add(this.loggingTab);
            this.myTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl.Location = new System.Drawing.Point(0, 0);
            this.myTabControl.Name = "myTabControl";
            this.myTabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.myTabControl.SelectedIndex = 0;
            this.myTabControl.Size = new System.Drawing.Size(882, 512);
            this.myTabControl.TabIndex = 2;
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.splitMain);
            this.optionsTab.Location = new System.Drawing.Point(4, 22);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Size = new System.Drawing.Size(874, 486);
            this.optionsTab.TabIndex = 0;
            this.optionsTab.Text = global::OutlookSafetyChex.Properties.Resources.Title_Main;
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitMainTopHalf);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.logGridView);
            this.splitMain.Size = new System.Drawing.Size(874, 486);
            this.splitMain.SplitterDistance = 200;
            this.splitMain.TabIndex = 29;
            // 
            // splitMainTopHalf
            // 
            this.splitMainTopHalf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMainTopHalf.Location = new System.Drawing.Point(0, 0);
            this.splitMainTopHalf.Name = "splitMainTopHalf";
            this.splitMainTopHalf.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMainTopHalf.Panel1
            // 
            this.splitMainTopHalf.Panel1.Controls.Add(this.splitMainTestsOptions);
            // 
            // splitMainTopHalf.Panel2
            // 
            this.splitMainTopHalf.Panel2.Controls.Add(this.textBoxProgress);
            this.splitMainTopHalf.Size = new System.Drawing.Size(874, 200);
            this.splitMainTopHalf.SplitterDistance = 167;
            this.splitMainTopHalf.TabIndex = 0;
            // 
            // splitMainTestsOptions
            // 
            this.splitMainTestsOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMainTestsOptions.Location = new System.Drawing.Point(0, 0);
            this.splitMainTestsOptions.Name = "splitMainTestsOptions";
            // 
            // splitMainTestsOptions.Panel1
            // 
            this.splitMainTestsOptions.Panel1.Controls.Add(this.groupTests);
            // 
            // splitMainTestsOptions.Panel2
            // 
            this.splitMainTestsOptions.Panel2.Controls.Add(this.groupOptions);
            this.splitMainTestsOptions.Size = new System.Drawing.Size(874, 167);
            this.splitMainTestsOptions.SplitterDistance = 405;
            this.splitMainTestsOptions.TabIndex = 0;
            // 
            // groupTests
            // 
            this.groupTests.Controls.Add(this.groupLogLevel);
            this.groupTests.Controls.Add(this.cbTabBody);
            this.groupTests.Controls.Add(this.btnRunTests);
            this.groupTests.Controls.Add(this.cbTabAttachments);
            this.groupTests.Controls.Add(this.cbTabLinks);
            this.groupTests.Controls.Add(this.cbTabRoutes);
            this.groupTests.Controls.Add(this.btnClearCache);
            this.groupTests.Controls.Add(this.cbTabContacts);
            this.groupTests.Controls.Add(this.cbForceDataRefresh);
            this.groupTests.Controls.Add(this.cbUseCACHE);
            this.groupTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTests.Location = new System.Drawing.Point(0, 0);
            this.groupTests.MinimumSize = new System.Drawing.Size(400, 150);
            this.groupTests.Name = "groupTests";
            this.groupTests.Size = new System.Drawing.Size(405, 167);
            this.groupTests.TabIndex = 26;
            this.groupTests.TabStop = false;
            this.groupTests.Text = "Analysis / Tests";
            // 
            // groupLogLevel
            // 
            this.groupLogLevel.Controls.Add(this.cbShowLog);
            this.groupLogLevel.Controls.Add(this.rbLogVerbose);
            this.groupLogLevel.Controls.Add(this.rbLogInfo);
            this.groupLogLevel.Controls.Add(this.rbLogError);
            this.groupLogLevel.Controls.Add(this.rbLogNone);
            this.groupLogLevel.Location = new System.Drawing.Point(291, 13);
            this.groupLogLevel.Name = "groupLogLevel";
            this.groupLogLevel.Size = new System.Drawing.Size(108, 137);
            this.groupLogLevel.TabIndex = 26;
            this.groupLogLevel.TabStop = false;
            this.groupLogLevel.Text = "Logging Options";
            // 
            // cbShowLog
            // 
            this.cbShowLog.AutoSize = true;
            this.cbShowLog.Location = new System.Drawing.Point(15, 114);
            this.cbShowLog.Name = "cbShowLog";
            this.cbShowLog.Size = new System.Drawing.Size(74, 17);
            this.cbShowLog.TabIndex = 4;
            this.cbShowLog.Text = "Show Log";
            this.cbShowLog.UseVisualStyleBackColor = true;
            this.cbShowLog.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
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
            this.cbTabBody.Location = new System.Drawing.Point(94, 25);
            this.cbTabBody.Name = "cbTabBody";
            this.cbTabBody.Size = new System.Drawing.Size(50, 17);
            this.cbTabBody.TabIndex = 25;
            this.cbTabBody.Text = global::OutlookSafetyChex.Properties.Resources.Title_Body;
            this.cbTabBody.UseVisualStyleBackColor = true;
            this.cbTabBody.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnRunTests
            // 
            this.btnRunTests.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnRunTests.FlatAppearance.BorderSize = 3;
            this.btnRunTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunTests.Image = global::OutlookSafetyChex.Properties.Resources.Run_16x;
            this.btnRunTests.Location = new System.Drawing.Point(14, 126);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(108, 24);
            this.btnRunTests.TabIndex = 10;
            this.btnRunTests.Text = global::OutlookSafetyChex.Properties.Resources.Action_Run;
            this.btnRunTests.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // cbTabAttachments
            // 
            this.cbTabAttachments.AutoSize = true;
            this.cbTabAttachments.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabAttachments.Location = new System.Drawing.Point(94, 71);
            this.cbTabAttachments.Name = "cbTabAttachments";
            this.cbTabAttachments.Size = new System.Drawing.Size(85, 17);
            this.cbTabAttachments.TabIndex = 24;
            this.cbTabAttachments.Text = global::OutlookSafetyChex.Properties.Resources.Title_Attachments;
            this.cbTabAttachments.UseVisualStyleBackColor = true;
            this.cbTabAttachments.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTabLinks
            // 
            this.cbTabLinks.AutoSize = true;
            this.cbTabLinks.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabLinks.Location = new System.Drawing.Point(94, 48);
            this.cbTabLinks.Name = "cbTabLinks";
            this.cbTabLinks.Size = new System.Drawing.Size(51, 17);
            this.cbTabLinks.TabIndex = 23;
            this.cbTabLinks.Text = global::OutlookSafetyChex.Properties.Resources.Title_Links;
            this.cbTabLinks.UseVisualStyleBackColor = true;
            this.cbTabLinks.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTabRoutes
            // 
            this.cbTabRoutes.AutoSize = true;
            this.cbTabRoutes.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabRoutes.Location = new System.Drawing.Point(14, 48);
            this.cbTabRoutes.Name = "cbTabRoutes";
            this.cbTabRoutes.Size = new System.Drawing.Size(63, 17);
            this.cbTabRoutes.TabIndex = 22;
            this.cbTabRoutes.Text = global::OutlookSafetyChex.Properties.Resources.Title_Routing;
            this.cbTabRoutes.UseVisualStyleBackColor = true;
            this.cbTabRoutes.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCache.Location = new System.Drawing.Point(204, 66);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(78, 23);
            this.btnClearCache.TabIndex = 11;
            this.btnClearCache.Text = "Clear Cache";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // cbTabContacts
            // 
            this.cbTabContacts.AutoSize = true;
            this.cbTabContacts.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabContacts.Location = new System.Drawing.Point(14, 25);
            this.cbTabContacts.Name = "cbTabContacts";
            this.cbTabContacts.Size = new System.Drawing.Size(68, 17);
            this.cbTabContacts.TabIndex = 20;
            this.cbTabContacts.Text = global::OutlookSafetyChex.Properties.Resources.Title_Contacts;
            this.cbTabContacts.UseVisualStyleBackColor = true;
            this.cbTabContacts.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbForceDataRefresh
            // 
            this.cbForceDataRefresh.AutoSize = true;
            this.cbForceDataRefresh.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbForceDataRefresh.Location = new System.Drawing.Point(186, 25);
            this.cbForceDataRefresh.Name = "cbForceDataRefresh";
            this.cbForceDataRefresh.Size = new System.Drawing.Size(93, 17);
            this.cbForceDataRefresh.TabIndex = 13;
            this.cbForceDataRefresh.Text = "Force Refresh";
            this.cbForceDataRefresh.UseVisualStyleBackColor = true;
            this.cbForceDataRefresh.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbUseCACHE
            // 
            this.cbUseCACHE.AutoSize = true;
            this.cbUseCACHE.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbUseCACHE.Location = new System.Drawing.Point(186, 48);
            this.cbUseCACHE.Name = "cbUseCACHE";
            this.cbUseCACHE.Size = new System.Drawing.Size(79, 17);
            this.cbUseCACHE.TabIndex = 16;
            this.cbUseCACHE.Text = "Use Cache";
            this.cbUseCACHE.UseVisualStyleBackColor = true;
            this.cbUseCACHE.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.labelVersion);
            this.groupOptions.Controls.Add(this.btnSaveOptions);
            this.groupOptions.Controls.Add(this.cbInspectLinks);
            this.groupOptions.Controls.Add(this.btnEdit_Blacklist);
            this.groupOptions.Controls.Add(this.btnEdit_Whitelist);
            this.groupOptions.Controls.Add(this.btnEdit_SpamList);
            this.groupOptions.Controls.Add(this.cbInspectAttachents);
            this.groupOptions.Controls.Add(this.cbFlagUnknownContacts);
            this.groupOptions.Controls.Add(this.cbTLD_Blacklist);
            this.groupOptions.Controls.Add(this.cbTLD_Whitelist);
            this.groupOptions.Controls.Add(this.cbVerifyContacts);
            this.groupOptions.Controls.Add(this.cbLookupHIBP);
            this.groupOptions.Controls.Add(this.cbLookupWHOIS);
            this.groupOptions.Controls.Add(this.cbLookupDNSBL);
            this.groupOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupOptions.Location = new System.Drawing.Point(0, 0);
            this.groupOptions.MinimumSize = new System.Drawing.Size(460, 150);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(465, 167);
            this.groupOptions.TabIndex = 25;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.BackColor = System.Drawing.Color.White;
            this.labelVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelVersion.Location = new System.Drawing.Point(258, 120);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(200, 42);
            this.labelVersion.TabIndex = 28;
            this.labelVersion.TabStop = true;
            this.labelVersion.Text = "Outlook Safety Chex";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelVersion_LinkClicked);
            // 
            // btnSaveOptions
            // 
            this.btnSaveOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOptions.Image = global::OutlookSafetyChex.Properties.Resources.Save_16x_32;
            this.btnSaveOptions.Location = new System.Drawing.Point(13, 127);
            this.btnSaveOptions.Name = "btnSaveOptions";
            this.btnSaveOptions.Size = new System.Drawing.Size(118, 24);
            this.btnSaveOptions.TabIndex = 25;
            this.btnSaveOptions.Text = "Save Options";
            this.btnSaveOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveOptions.UseVisualStyleBackColor = true;
            this.btnSaveOptions.Click += new System.EventHandler(this.btnSaveOptions_Click);
            // 
            // cbInspectLinks
            // 
            this.cbInspectLinks.AutoSize = true;
            this.cbInspectLinks.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbInspectLinks.Location = new System.Drawing.Point(262, 40);
            this.cbInspectLinks.Name = "cbInspectLinks";
            this.cbInspectLinks.Size = new System.Drawing.Size(96, 17);
            this.cbInspectLinks.TabIndex = 27;
            this.cbInspectLinks.Text = "Inpsect Links *";
            this.cbInspectLinks.UseVisualStyleBackColor = true;
            this.cbInspectLinks.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnEdit_Blacklist
            // 
            this.btnEdit_Blacklist.Image = global::OutlookSafetyChex.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_Blacklist.Location = new System.Drawing.Point(369, 59);
            this.btnEdit_Blacklist.Name = "btnEdit_Blacklist";
            this.btnEdit_Blacklist.Size = new System.Drawing.Size(56, 23);
            this.btnEdit_Blacklist.TabIndex = 26;
            this.btnEdit_Blacklist.Text = "Edit";
            this.btnEdit_Blacklist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_Blacklist.UseVisualStyleBackColor = true;
            this.btnEdit_Blacklist.Click += new System.EventHandler(this.editBlacklist_Dialog);
            // 
            // btnEdit_Whitelist
            // 
            this.btnEdit_Whitelist.Image = global::OutlookSafetyChex.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_Whitelist.Location = new System.Drawing.Point(369, 82);
            this.btnEdit_Whitelist.Name = "btnEdit_Whitelist";
            this.btnEdit_Whitelist.Size = new System.Drawing.Size(56, 23);
            this.btnEdit_Whitelist.TabIndex = 25;
            this.btnEdit_Whitelist.Text = "Edit";
            this.btnEdit_Whitelist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_Whitelist.UseVisualStyleBackColor = true;
            this.btnEdit_Whitelist.Click += new System.EventHandler(this.editWhitelist_Dialog);
            // 
            // btnEdit_SpamList
            // 
            this.btnEdit_SpamList.Image = global::OutlookSafetyChex.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_SpamList.Location = new System.Drawing.Point(170, 38);
            this.btnEdit_SpamList.Name = "btnEdit_SpamList";
            this.btnEdit_SpamList.Size = new System.Drawing.Size(56, 23);
            this.btnEdit_SpamList.TabIndex = 24;
            this.btnEdit_SpamList.Text = "Edit";
            this.btnEdit_SpamList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_SpamList.UseVisualStyleBackColor = true;
            this.btnEdit_SpamList.Click += new System.EventHandler(this.editSpamList_Dialog);
            // 
            // cbInspectAttachents
            // 
            this.cbInspectAttachents.AutoSize = true;
            this.cbInspectAttachents.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbInspectAttachents.Location = new System.Drawing.Point(262, 19);
            this.cbInspectAttachents.Name = "cbInspectAttachents";
            this.cbInspectAttachents.Size = new System.Drawing.Size(134, 17);
            this.cbInspectAttachents.TabIndex = 23;
            this.cbInspectAttachents.Text = global::OutlookSafetyChex.Properties.Resources.Option_InspectAttachments;
            this.cbInspectAttachents.UseVisualStyleBackColor = true;
            this.cbInspectAttachents.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbFlagUnknownContacts
            // 
            this.cbFlagUnknownContacts.AutoSize = true;
            this.cbFlagUnknownContacts.ForeColor = System.Drawing.Color.Black;
            this.cbFlagUnknownContacts.Location = new System.Drawing.Point(137, 88);
            this.cbFlagUnknownContacts.Name = "cbFlagUnknownContacts";
            this.cbFlagUnknownContacts.Size = new System.Drawing.Size(89, 17);
            this.cbFlagUnknownContacts.TabIndex = 22;
            this.cbFlagUnknownContacts.Text = global::OutlookSafetyChex.Properties.Resources.Option_FlagUknownContacts;
            this.cbFlagUnknownContacts.UseVisualStyleBackColor = true;
            this.cbFlagUnknownContacts.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTLD_Blacklist
            // 
            this.cbTLD_Blacklist.AutoSize = true;
            this.cbTLD_Blacklist.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTLD_Blacklist.Location = new System.Drawing.Point(262, 63);
            this.cbTLD_Blacklist.Name = "cbTLD_Blacklist";
            this.cbTLD_Blacklist.Size = new System.Drawing.Size(94, 17);
            this.cbTLD_Blacklist.TabIndex = 21;
            this.cbTLD_Blacklist.Text = global::OutlookSafetyChex.Properties.Resources.Option_TLDBlacklist;
            this.cbTLD_Blacklist.UseVisualStyleBackColor = true;
            this.cbTLD_Blacklist.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTLD_Whitelist
            // 
            this.cbTLD_Whitelist.AutoSize = true;
            this.cbTLD_Whitelist.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTLD_Whitelist.Location = new System.Drawing.Point(262, 86);
            this.cbTLD_Whitelist.Name = "cbTLD_Whitelist";
            this.cbTLD_Whitelist.Size = new System.Drawing.Size(95, 17);
            this.cbTLD_Whitelist.TabIndex = 20;
            this.cbTLD_Whitelist.Text = global::OutlookSafetyChex.Properties.Resources.Option_TLDWhitelist;
            this.cbTLD_Whitelist.UseVisualStyleBackColor = true;
            this.cbTLD_Whitelist.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbVerifyContacts
            // 
            this.cbVerifyContacts.AutoSize = true;
            this.cbVerifyContacts.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbVerifyContacts.Location = new System.Drawing.Point(13, 88);
            this.cbVerifyContacts.Name = "cbVerifyContacts";
            this.cbVerifyContacts.Size = new System.Drawing.Size(118, 17);
            this.cbVerifyContacts.TabIndex = 18;
            this.cbVerifyContacts.Text = global::OutlookSafetyChex.Properties.Resources.Option_VerifyContacts;
            this.cbVerifyContacts.UseVisualStyleBackColor = true;
            this.cbVerifyContacts.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbLookupHIBP
            // 
            this.cbLookupHIBP.AutoSize = true;
            this.cbLookupHIBP.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbLookupHIBP.Location = new System.Drawing.Point(13, 65);
            this.cbLookupHIBP.Name = "cbLookupHIBP";
            this.cbLookupHIBP.Size = new System.Drawing.Size(150, 17);
            this.cbLookupHIBP.TabIndex = 17;
            this.cbLookupHIBP.Text = global::OutlookSafetyChex.Properties.Resources.Option_LookupHIBP;
            this.cbLookupHIBP.UseVisualStyleBackColor = true;
            this.cbLookupHIBP.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbLookupWHOIS
            // 
            this.cbLookupWHOIS.AutoSize = true;
            this.cbLookupWHOIS.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbLookupWHOIS.Location = new System.Drawing.Point(13, 19);
            this.cbLookupWHOIS.Name = "cbLookupWHOIS";
            this.cbLookupWHOIS.Size = new System.Drawing.Size(149, 17);
            this.cbLookupWHOIS.TabIndex = 14;
            this.cbLookupWHOIS.Text = global::OutlookSafetyChex.Properties.Resources.Option_LookupWHOIS;
            this.cbLookupWHOIS.UseVisualStyleBackColor = true;
            this.cbLookupWHOIS.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbLookupDNSBL
            // 
            this.cbLookupDNSBL.AutoSize = true;
            this.cbLookupDNSBL.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbLookupDNSBL.Location = new System.Drawing.Point(13, 42);
            this.cbLookupDNSBL.Name = "cbLookupDNSBL";
            this.cbLookupDNSBL.Size = new System.Drawing.Size(151, 17);
            this.cbLookupDNSBL.TabIndex = 15;
            this.cbLookupDNSBL.Text = global::OutlookSafetyChex.Properties.Resources.Option_LookupDNSBL;
            this.cbLookupDNSBL.UseVisualStyleBackColor = true;
            this.cbLookupDNSBL.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // textBoxProgress
            // 
            this.textBoxProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProgress.Location = new System.Drawing.Point(0, 0);
            this.textBoxProgress.Name = "textBoxProgress";
            this.textBoxProgress.ReadOnly = true;
            this.textBoxProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProgress.Size = new System.Drawing.Size(874, 20);
            this.textBoxProgress.TabIndex = 28;
            // 
            // logGridView
            // 
            this.logGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logGridView.Location = new System.Drawing.Point(0, 0);
            this.logGridView.Name = "logGridView";
            this.logGridView.ReadOnly = true;
            this.logGridView.Size = new System.Drawing.Size(874, 282);
            this.logGridView.TabIndex = 0;
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.infoGridView);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(874, 486);
            this.infoTab.TabIndex = 1;
            this.infoTab.Text = global::OutlookSafetyChex.Properties.Resources.Title_Envelope;
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // infoGridView
            // 
            this.infoGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoGridView.Location = new System.Drawing.Point(3, 3);
            this.infoGridView.Name = "infoGridView";
            this.infoGridView.ReadOnly = true;
            this.infoGridView.Size = new System.Drawing.Size(868, 480);
            this.infoGridView.TabIndex = 0;
            // 
            // headerTab
            // 
            this.headerTab.Controls.Add(this.splitHeaders);
            this.headerTab.Location = new System.Drawing.Point(4, 22);
            this.headerTab.Name = "headerTab";
            this.headerTab.Padding = new System.Windows.Forms.Padding(3);
            this.headerTab.Size = new System.Drawing.Size(874, 486);
            this.headerTab.TabIndex = 3;
            this.headerTab.Text = global::OutlookSafetyChex.Properties.Resources.Title_Headers;
            this.headerTab.UseVisualStyleBackColor = true;
            // 
            // splitHeaders
            // 
            this.splitHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitHeaders.Location = new System.Drawing.Point(3, 3);
            this.splitHeaders.Name = "splitHeaders";
            this.splitHeaders.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitHeaders.Panel1
            // 
            this.splitHeaders.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitHeaders.Panel2
            // 
            this.splitHeaders.Panel2.Controls.Add(this.groupBoxHeaders);
            this.splitHeaders.Size = new System.Drawing.Size(868, 480);
            this.splitHeaders.SplitterDistance = 286;
            this.splitHeaders.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.headerGridView);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(868, 286);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SMTP Headers (Parsed)";
            // 
            // headerGridView
            // 
            this.headerGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGridView.Location = new System.Drawing.Point(3, 16);
            this.headerGridView.Name = "headerGridView";
            this.headerGridView.ReadOnly = true;
            this.headerGridView.Size = new System.Drawing.Size(862, 267);
            this.headerGridView.TabIndex = 0;
            // 
            // groupBoxHeaders
            // 
            this.groupBoxHeaders.Controls.Add(this.rawHeaderTextBox);
            this.groupBoxHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHeaders.Location = new System.Drawing.Point(0, 0);
            this.groupBoxHeaders.Name = "groupBoxHeaders";
            this.groupBoxHeaders.Size = new System.Drawing.Size(868, 190);
            this.groupBoxHeaders.TabIndex = 2;
            this.groupBoxHeaders.TabStop = false;
            this.groupBoxHeaders.Text = "SMTP Headers (Raw)";
            // 
            // rawHeaderTextBox
            // 
            this.rawHeaderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawHeaderTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rawHeaderTextBox.Location = new System.Drawing.Point(3, 16);
            this.rawHeaderTextBox.Multiline = true;
            this.rawHeaderTextBox.Name = "rawHeaderTextBox";
            this.rawHeaderTextBox.ReadOnly = true;
            this.rawHeaderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rawHeaderTextBox.Size = new System.Drawing.Size(862, 171);
            this.rawHeaderTextBox.TabIndex = 0;
            this.rawHeaderTextBox.WordWrap = false;
            // 
            // contactTab
            // 
            this.contactTab.Controls.Add(this.splitContacts);
            this.contactTab.Location = new System.Drawing.Point(4, 22);
            this.contactTab.Name = "contactTab";
            this.contactTab.Padding = new System.Windows.Forms.Padding(3);
            this.contactTab.Size = new System.Drawing.Size(874, 486);
            this.contactTab.TabIndex = 4;
            this.contactTab.Text = global::OutlookSafetyChex.Properties.Resources.Title_Contacts;
            this.contactTab.UseVisualStyleBackColor = true;
            // 
            // splitContacts
            // 
            this.splitContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContacts.Location = new System.Drawing.Point(3, 3);
            this.splitContacts.Name = "splitContacts";
            this.splitContacts.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContacts.Panel1
            // 
            this.splitContacts.Panel1.Controls.Add(this.groupBox7);
            // 
            // splitContacts.Panel2
            // 
            this.splitContacts.Panel2.Controls.Add(this.groupBoxContacts);
            this.splitContacts.Size = new System.Drawing.Size(868, 480);
            this.splitContacts.SplitterDistance = 214;
            this.splitContacts.TabIndex = 3;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.senderGridView);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(868, 214);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Sender(s)";
            // 
            // senderGridView
            // 
            this.senderGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.senderGridView.Location = new System.Drawing.Point(3, 16);
            this.senderGridView.Name = "senderGridView";
            this.senderGridView.ReadOnly = true;
            this.senderGridView.Size = new System.Drawing.Size(862, 195);
            this.senderGridView.TabIndex = 0;
            // 
            // groupBoxContacts
            // 
            this.groupBoxContacts.Controls.Add(this.recipientsGridView);
            this.groupBoxContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxContacts.Location = new System.Drawing.Point(0, 0);
            this.groupBoxContacts.Name = "groupBoxContacts";
            this.groupBoxContacts.Size = new System.Drawing.Size(868, 262);
            this.groupBoxContacts.TabIndex = 2;
            this.groupBoxContacts.TabStop = false;
            this.groupBoxContacts.Text = "Recipients(s)";
            // 
            // recipientsGridView
            // 
            this.recipientsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipientsGridView.Location = new System.Drawing.Point(3, 16);
            this.recipientsGridView.Name = "recipientsGridView";
            this.recipientsGridView.ReadOnly = true;
            this.recipientsGridView.Size = new System.Drawing.Size(862, 243);
            this.recipientsGridView.TabIndex = 3;
            // 
            // routeTab
            // 
            this.routeTab.Controls.Add(this.splitRouting);
            this.routeTab.Location = new System.Drawing.Point(4, 22);
            this.routeTab.Name = "routeTab";
            this.routeTab.Padding = new System.Windows.Forms.Padding(3);
            this.routeTab.Size = new System.Drawing.Size(874, 486);
            this.routeTab.TabIndex = 6;
            this.routeTab.Text = global::OutlookSafetyChex.Properties.Resources.Title_Routing;
            this.routeTab.UseVisualStyleBackColor = true;
            // 
            // splitRouting
            // 
            this.splitRouting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRouting.Location = new System.Drawing.Point(3, 3);
            this.splitRouting.Name = "splitRouting";
            this.splitRouting.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRouting.Panel1
            // 
            this.splitRouting.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitRouting.Panel2
            // 
            this.splitRouting.Panel2.Controls.Add(this.groupBoxRoutes);
            this.splitRouting.Size = new System.Drawing.Size(868, 480);
            this.splitRouting.SplitterDistance = 234;
            this.splitRouting.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.routeCheckGridView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 234);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Route Checks";
            // 
            // routeCheckGridView
            // 
            this.routeCheckGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeCheckGridView.Location = new System.Drawing.Point(3, 16);
            this.routeCheckGridView.Name = "routeCheckGridView";
            this.routeCheckGridView.ReadOnly = true;
            this.routeCheckGridView.Size = new System.Drawing.Size(862, 215);
            this.routeCheckGridView.TabIndex = 0;
            // 
            // groupBoxRoutes
            // 
            this.groupBoxRoutes.Controls.Add(this.routeListGridView);
            this.groupBoxRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRoutes.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRoutes.Name = "groupBoxRoutes";
            this.groupBoxRoutes.Size = new System.Drawing.Size(868, 242);
            this.groupBoxRoutes.TabIndex = 2;
            this.groupBoxRoutes.TabStop = false;
            this.groupBoxRoutes.Text = "Route List";
            // 
            // routeListGridView
            // 
            this.routeListGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeListGridView.Location = new System.Drawing.Point(3, 16);
            this.routeListGridView.Name = "routeListGridView";
            this.routeListGridView.ReadOnly = true;
            this.routeListGridView.Size = new System.Drawing.Size(862, 223);
            this.routeListGridView.TabIndex = 0;
            // 
            // bodyTab
            // 
            this.bodyTab.Controls.Add(this.bodyGridView);
            this.bodyTab.Location = new System.Drawing.Point(4, 22);
            this.bodyTab.Name = "bodyTab";
            this.bodyTab.Padding = new System.Windows.Forms.Padding(3);
            this.bodyTab.Size = new System.Drawing.Size(874, 486);
            this.bodyTab.TabIndex = 10;
            this.bodyTab.Text = "Body";
            this.bodyTab.UseVisualStyleBackColor = true;
            // 
            // bodyGridView
            // 
            this.bodyGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyGridView.Location = new System.Drawing.Point(3, 3);
            this.bodyGridView.Name = "bodyGridView";
            this.bodyGridView.ReadOnly = true;
            this.bodyGridView.Size = new System.Drawing.Size(868, 480);
            this.bodyGridView.TabIndex = 3;
            // 
            // linksTab
            // 
            this.linksTab.Controls.Add(this.splitLinks);
            this.linksTab.Location = new System.Drawing.Point(4, 22);
            this.linksTab.Name = "linksTab";
            this.linksTab.Padding = new System.Windows.Forms.Padding(3);
            this.linksTab.Size = new System.Drawing.Size(874, 486);
            this.linksTab.TabIndex = 7;
            this.linksTab.Text = global::OutlookSafetyChex.Properties.Resources.Title_Links;
            this.linksTab.UseVisualStyleBackColor = true;
            // 
            // splitLinks
            // 
            this.splitLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLinks.Location = new System.Drawing.Point(3, 3);
            this.splitLinks.Name = "splitLinks";
            this.splitLinks.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLinks.Panel1
            // 
            this.splitLinks.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitLinks.Panel2
            // 
            this.splitLinks.Panel2.Controls.Add(this.groupBoxLinks);
            this.splitLinks.Size = new System.Drawing.Size(868, 480);
            this.splitLinks.SplitterDistance = 265;
            this.splitLinks.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkCheckGridView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(868, 265);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Link Checks";
            // 
            // linkCheckGridView
            // 
            this.linkCheckGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkCheckGridView.Location = new System.Drawing.Point(3, 16);
            this.linkCheckGridView.Name = "linkCheckGridView";
            this.linkCheckGridView.ReadOnly = true;
            this.linkCheckGridView.Size = new System.Drawing.Size(862, 246);
            this.linkCheckGridView.TabIndex = 0;
            // 
            // groupBoxLinks
            // 
            this.groupBoxLinks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxLinks.Controls.Add(this.linkListGridView);
            this.groupBoxLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLinks.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLinks.Name = "groupBoxLinks";
            this.groupBoxLinks.Size = new System.Drawing.Size(868, 211);
            this.groupBoxLinks.TabIndex = 2;
            this.groupBoxLinks.TabStop = false;
            this.groupBoxLinks.Text = "Link List";
            // 
            // linkListGridView
            // 
            this.linkListGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkListGridView.Location = new System.Drawing.Point(3, 16);
            this.linkListGridView.Name = "linkListGridView";
            this.linkListGridView.ReadOnly = true;
            this.linkListGridView.Size = new System.Drawing.Size(862, 192);
            this.linkListGridView.TabIndex = 0;
            // 
            // attachmentsTab
            // 
            this.attachmentsTab.Controls.Add(this.attachmentsGridView);
            this.attachmentsTab.Location = new System.Drawing.Point(4, 22);
            this.attachmentsTab.Name = "attachmentsTab";
            this.attachmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.attachmentsTab.Size = new System.Drawing.Size(874, 486);
            this.attachmentsTab.TabIndex = 8;
            this.attachmentsTab.Text = global::OutlookSafetyChex.Properties.Resources.Title_Attachments;
            this.attachmentsTab.UseVisualStyleBackColor = true;
            // 
            // attachmentsGridView
            // 
            this.attachmentsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachmentsGridView.Location = new System.Drawing.Point(3, 3);
            this.attachmentsGridView.Name = "attachmentsGridView";
            this.attachmentsGridView.ReadOnly = true;
            this.attachmentsGridView.Size = new System.Drawing.Size(868, 480);
            this.attachmentsGridView.TabIndex = 2;
            // 
            // loggingTab
            // 
            this.loggingTab.Controls.Add(this.textDebug);
            this.loggingTab.Location = new System.Drawing.Point(4, 22);
            this.loggingTab.Name = "loggingTab";
            this.loggingTab.Padding = new System.Windows.Forms.Padding(3);
            this.loggingTab.Size = new System.Drawing.Size(874, 486);
            this.loggingTab.TabIndex = 9;
            this.loggingTab.Text = global::OutlookSafetyChex.Properties.Resources.Title_Logging;
            this.loggingTab.UseVisualStyleBackColor = true;
            // 
            // textDebug
            // 
            this.textDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textDebug.Location = new System.Drawing.Point(3, 3);
            this.textDebug.Multiline = true;
            this.textDebug.Name = "textDebug";
            this.textDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textDebug.Size = new System.Drawing.Size(868, 480);
            this.textDebug.TabIndex = 0;
            this.textDebug.WordWrap = false;
            // 
            // dlgSafetyCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(882, 512);
            this.Controls.Add(this.myTabControl);
            this.MinimumSize = new System.Drawing.Size(512, 512);
            this.Name = "dlgSafetyCheck";
            this.Text = "✓ CodeChex Outlook Email Safety Checks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgSafetyCheck_FormClosing);
            this.myTabControl.ResumeLayout(false);
            this.optionsTab.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitMainTopHalf.Panel1.ResumeLayout(false);
            this.splitMainTopHalf.Panel2.ResumeLayout(false);
            this.splitMainTopHalf.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMainTopHalf)).EndInit();
            this.splitMainTopHalf.ResumeLayout(false);
            this.splitMainTestsOptions.Panel1.ResumeLayout(false);
            this.splitMainTestsOptions.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMainTestsOptions)).EndInit();
            this.splitMainTestsOptions.ResumeLayout(false);
            this.groupTests.ResumeLayout(false);
            this.groupTests.PerformLayout();
            this.groupLogLevel.ResumeLayout(false);
            this.groupLogLevel.PerformLayout();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).EndInit();
            this.infoTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoGridView)).EndInit();
            this.headerTab.ResumeLayout(false);
            this.splitHeaders.Panel1.ResumeLayout(false);
            this.splitHeaders.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitHeaders)).EndInit();
            this.splitHeaders.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGridView)).EndInit();
            this.groupBoxHeaders.ResumeLayout(false);
            this.groupBoxHeaders.PerformLayout();
            this.contactTab.ResumeLayout(false);
            this.splitContacts.Panel1.ResumeLayout(false);
            this.splitContacts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContacts)).EndInit();
            this.splitContacts.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.senderGridView)).EndInit();
            this.groupBoxContacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recipientsGridView)).EndInit();
            this.routeTab.ResumeLayout(false);
            this.splitRouting.Panel1.ResumeLayout(false);
            this.splitRouting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRouting)).EndInit();
            this.splitRouting.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.routeCheckGridView)).EndInit();
            this.groupBoxRoutes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.routeListGridView)).EndInit();
            this.bodyTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bodyGridView)).EndInit();
            this.linksTab.ResumeLayout(false);
            this.splitLinks.Panel1.ResumeLayout(false);
            this.splitLinks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLinks)).EndInit();
            this.splitLinks.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.linkCheckGridView)).EndInit();
            this.groupBoxLinks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.linkListGridView)).EndInit();
            this.attachmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attachmentsGridView)).EndInit();
            this.loggingTab.ResumeLayout(false);
            this.loggingTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public TabControl myTabControl;
        //
        public TabPage infoTab;
        public TabPage headerTab;
        public TabPage contactTab;
        public TabPage routeTab;
        public TabPage bodyTab;
        public TabPage linksTab;
        public TabPage attachmentsTab;
        public TabPage optionsTab;
        public TabPage loggingTab;
        //
        public DataGridView infoGridView;
        public DataGridView headerGridView;
        public DataGridView senderGridView;
        public DataGridView linkCheckGridView;
		public DataGridView linkListGridView;
		public DataGridView routeCheckGridView;
		public DataGridView routeListGridView;
        public DataGridView bodyGridView;
        public DataGridView attachmentsGridView;
		public DataGridView recipientsGridView;
		public DataGridView logGridView;
        //
        private Button btnRunTests;
        private Button btnClearCache;
        private Button btnEdit_SpamList;
        private Button btnEdit_Whitelist;
        private Button btnEdit_Blacklist;
        //
        private CheckBox cbUseCACHE;
		private CheckBox cbLookupDNSBL;
		private CheckBox cbLookupWHOIS;
		private CheckBox cbForceDataRefresh;
		private CheckBox cbTabAttachments;
		private CheckBox cbTabLinks;
		private CheckBox cbTabRoutes;
        private CheckBox cbTabBody;
        private CheckBox cbTabContacts;
		private CheckBox cbLookupHIBP;
		private CheckBox cbVerifyContacts;
		private CheckBox cbTLD_Blacklist;
		private CheckBox cbTLD_Whitelist;
        private CheckBox cbFlagUnknownContacts;
        private CheckBox cbInspectAttachents;
        private CheckBox cbInspectLinks; 
        //
        private GroupBox groupTests;
		private GroupBox groupOptions;
		private GroupBox groupBoxRoutes;
		private GroupBox groupBox1;
		private GroupBox groupBoxLinks;
		private GroupBox groupBox3;
		private GroupBox groupBoxHeaders;
		private GroupBox groupBox5;
		private GroupBox groupBoxContacts;
		private GroupBox groupBox7;
        //
		private SplitContainer splitHeaders;
		private SplitContainer splitContacts;
		private SplitContainer splitRouting;
		private SplitContainer splitLinks;
		private SplitContainer splitMain;
		private SplitContainer splitMainTopHalf;
		private SplitContainer splitMainTestsOptions;
        //
        public TextBox rawHeaderTextBox;
        public TextBox textDebug;
        public TextBox textBoxProgress;
        private Button btnSaveOptions;
        private GroupBox groupLogLevel;
        private RadioButton rbLogNone;
        private RadioButton rbLogVerbose;
        private RadioButton rbLogInfo;
        private RadioButton rbLogError;
        private CheckBox cbShowLog;
        private LinkLabel labelVersion;
    }
}
