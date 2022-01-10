using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookSafetyChecks
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.groupTests = new System.Windows.Forms.GroupBox();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.cbTabAttachments = new System.Windows.Forms.CheckBox();
            this.cbTabLinks = new System.Windows.Forms.CheckBox();
            this.cbTabRoutes = new System.Windows.Forms.CheckBox();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.cbTabContacts = new System.Windows.Forms.CheckBox();
            this.cbForceDataRefresh = new System.Windows.Forms.CheckBox();
            this.cbUseCACHE = new System.Windows.Forms.CheckBox();
            this.groupOptions = new System.Windows.Forms.GroupBox();
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
            this.logGridView = new System.Windows.Forms.DataGridView();
            this.textBoxProgress = new System.Windows.Forms.TextBox();
            this.infoTab = new System.Windows.Forms.TabPage();
            this.infoGridView = new System.Windows.Forms.DataGridView();
            this.headerTab = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.headerGridView = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rawHeaderTextBox = new System.Windows.Forms.TextBox();
            this.contactTab = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.senderGridView = new System.Windows.Forms.DataGridView();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.recipientsGridView = new System.Windows.Forms.DataGridView();
            this.routeTab = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.routeCheckGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.routeListGridView = new System.Windows.Forms.DataGridView();
            this.linksTab = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkCheckGridView = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkListGridView = new System.Windows.Forms.DataGridView();
            this.attachmentsTab = new System.Windows.Forms.TabPage();
            this.attachmentsGridView = new System.Windows.Forms.DataGridView();
            this.loggingTab = new System.Windows.Forms.TabPage();
            this.textDebug = new System.Windows.Forms.TextBox();
            this.myTabControl.SuspendLayout();
            this.optionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.groupTests.SuspendLayout();
            this.groupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).BeginInit();
            this.infoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGridView)).BeginInit();
            this.headerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGridView)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.contactTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.senderGridView)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipientsGridView)).BeginInit();
            this.routeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routeCheckGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routeListGridView)).BeginInit();
            this.linksTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkCheckGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
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
            this.myTabControl.Controls.Add(this.linksTab);
            this.myTabControl.Controls.Add(this.attachmentsTab);
            this.myTabControl.Controls.Add(this.loggingTab);
            this.myTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl.Location = new System.Drawing.Point(0, 0);
            this.myTabControl.Name = "myTabControl";
            this.myTabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.myTabControl.SelectedIndex = 0;
            this.myTabControl.Size = new System.Drawing.Size(512, 512);
            this.myTabControl.TabIndex = 2;
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.splitContainer1);
            this.optionsTab.Location = new System.Drawing.Point(4, 22);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Size = new System.Drawing.Size(504, 486);
            this.optionsTab.TabIndex = 0;
            this.optionsTab.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Main;
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxProgress);
            this.splitContainer1.Size = new System.Drawing.Size(504, 486);
            this.splitContainer1.SplitterDistance = 452;
            this.splitContainer1.TabIndex = 29;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.splitContainer7);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.logGridView);
            this.splitContainer6.Size = new System.Drawing.Size(504, 452);
            this.splitContainer6.SplitterDistance = 231;
            this.splitContainer6.TabIndex = 0;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.groupTests);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.groupOptions);
            this.splitContainer7.Size = new System.Drawing.Size(504, 231);
            this.splitContainer7.SplitterDistance = 234;
            this.splitContainer7.TabIndex = 0;
            // 
            // groupTests
            // 
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
            this.groupTests.MinimumSize = new System.Drawing.Size(160, 175);
            this.groupTests.Name = "groupTests";
            this.groupTests.Size = new System.Drawing.Size(234, 231);
            this.groupTests.TabIndex = 26;
            this.groupTests.TabStop = false;
            this.groupTests.Text = "Analysis / Tests";
            // 
            // btnRunTests
            // 
            this.btnRunTests.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnRunTests.FlatAppearance.BorderSize = 3;
            this.btnRunTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunTests.Image = global::OutlookSafetyChecks.Properties.Resources.Run_16x;
            this.btnRunTests.Location = new System.Drawing.Point(64, 201);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(108, 24);
            this.btnRunTests.TabIndex = 10;
            this.btnRunTests.Text = global::OutlookSafetyChecks.Properties.Resources.Action_Run;
            this.btnRunTests.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // cbTabAttachments
            // 
            this.cbTabAttachments.AutoSize = true;
            this.cbTabAttachments.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabAttachments.Location = new System.Drawing.Point(20, 94);
            this.cbTabAttachments.Name = "cbTabAttachments";
            this.cbTabAttachments.Size = new System.Drawing.Size(85, 17);
            this.cbTabAttachments.TabIndex = 24;
            this.cbTabAttachments.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Attachments;
            this.cbTabAttachments.UseVisualStyleBackColor = true;
            this.cbTabAttachments.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTabLinks
            // 
            this.cbTabLinks.AutoSize = true;
            this.cbTabLinks.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabLinks.Location = new System.Drawing.Point(20, 71);
            this.cbTabLinks.Name = "cbTabLinks";
            this.cbTabLinks.Size = new System.Drawing.Size(51, 17);
            this.cbTabLinks.TabIndex = 23;
            this.cbTabLinks.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Links;
            this.cbTabLinks.UseVisualStyleBackColor = true;
            this.cbTabLinks.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTabRoutes
            // 
            this.cbTabRoutes.AutoSize = true;
            this.cbTabRoutes.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabRoutes.Location = new System.Drawing.Point(20, 48);
            this.cbTabRoutes.Name = "cbTabRoutes";
            this.cbTabRoutes.Size = new System.Drawing.Size(63, 17);
            this.cbTabRoutes.TabIndex = 22;
            this.cbTabRoutes.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Routing;
            this.cbTabRoutes.UseVisualStyleBackColor = true;
            this.cbTabRoutes.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCache.Location = new System.Drawing.Point(143, 151);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(79, 23);
            this.btnClearCache.TabIndex = 11;
            this.btnClearCache.Text = global::OutlookSafetyChecks.Properties.Resources.Action_ClearCache;
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // cbTabContacts
            // 
            this.cbTabContacts.AutoSize = true;
            this.cbTabContacts.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTabContacts.Location = new System.Drawing.Point(20, 25);
            this.cbTabContacts.Name = "cbTabContacts";
            this.cbTabContacts.Size = new System.Drawing.Size(68, 17);
            this.cbTabContacts.TabIndex = 20;
            this.cbTabContacts.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Contacts;
            this.cbTabContacts.UseVisualStyleBackColor = true;
            this.cbTabContacts.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbForceDataRefresh
            // 
            this.cbForceDataRefresh.AutoSize = true;
            this.cbForceDataRefresh.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbForceDataRefresh.Location = new System.Drawing.Point(20, 132);
            this.cbForceDataRefresh.Name = "cbForceDataRefresh";
            this.cbForceDataRefresh.Size = new System.Drawing.Size(119, 17);
            this.cbForceDataRefresh.TabIndex = 13;
            this.cbForceDataRefresh.Text = global::OutlookSafetyChecks.Properties.Resources.Option_ForceRefresh;
            this.cbForceDataRefresh.UseVisualStyleBackColor = true;
            this.cbForceDataRefresh.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbUseCACHE
            // 
            this.cbUseCACHE.AutoSize = true;
            this.cbUseCACHE.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbUseCACHE.Location = new System.Drawing.Point(20, 155);
            this.cbUseCACHE.Name = "cbUseCACHE";
            this.cbUseCACHE.Size = new System.Drawing.Size(123, 17);
            this.cbUseCACHE.TabIndex = 16;
            this.cbUseCACHE.Text = global::OutlookSafetyChecks.Properties.Resources.Option_UseCache;
            this.cbUseCACHE.UseVisualStyleBackColor = true;
            this.cbUseCACHE.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // groupOptions
            // 
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
            this.groupOptions.MinimumSize = new System.Drawing.Size(200, 175);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(266, 231);
            this.groupOptions.TabIndex = 25;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // btnSaveOptions
            // 
            this.btnSaveOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOptions.Image = global::OutlookSafetyChecks.Properties.Resources.Save_16x_32;
            this.btnSaveOptions.Location = new System.Drawing.Point(79, 201);
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
            this.cbInspectLinks.Location = new System.Drawing.Point(13, 109);
            this.cbInspectLinks.Name = "cbInspectLinks";
            this.cbInspectLinks.Size = new System.Drawing.Size(96, 17);
            this.cbInspectLinks.TabIndex = 27;
            this.cbInspectLinks.Text = "Inpsect Links *";
            this.cbInspectLinks.UseVisualStyleBackColor = true;
            this.cbInspectLinks.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // btnEdit_Blacklist
            // 
            this.btnEdit_Blacklist.Image = global::OutlookSafetyChecks.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_Blacklist.Location = new System.Drawing.Point(170, 128);
            this.btnEdit_Blacklist.Name = "btnEdit_Blacklist";
            this.btnEdit_Blacklist.Size = new System.Drawing.Size(75, 23);
            this.btnEdit_Blacklist.TabIndex = 26;
            this.btnEdit_Blacklist.Text = "Edit";
            this.btnEdit_Blacklist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_Blacklist.UseVisualStyleBackColor = true;
            this.btnEdit_Blacklist.Click += new System.EventHandler(this.editBlacklist_Dialog);
            // 
            // btnEdit_Whitelist
            // 
            this.btnEdit_Whitelist.Image = global::OutlookSafetyChecks.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_Whitelist.Location = new System.Drawing.Point(170, 151);
            this.btnEdit_Whitelist.Name = "btnEdit_Whitelist";
            this.btnEdit_Whitelist.Size = new System.Drawing.Size(75, 23);
            this.btnEdit_Whitelist.TabIndex = 25;
            this.btnEdit_Whitelist.Text = "Edit";
            this.btnEdit_Whitelist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit_Whitelist.UseVisualStyleBackColor = true;
            this.btnEdit_Whitelist.Click += new System.EventHandler(this.editWhitelist_Dialog);
            // 
            // btnEdit_SpamList
            // 
            this.btnEdit_SpamList.Image = global::OutlookSafetyChecks.Properties.Resources.ASX_Edit_blue_16x;
            this.btnEdit_SpamList.Location = new System.Drawing.Point(170, 38);
            this.btnEdit_SpamList.Name = "btnEdit_SpamList";
            this.btnEdit_SpamList.Size = new System.Drawing.Size(75, 23);
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
            this.cbInspectAttachents.Location = new System.Drawing.Point(13, 88);
            this.cbInspectAttachents.Name = "cbInspectAttachents";
            this.cbInspectAttachents.Size = new System.Drawing.Size(134, 17);
            this.cbInspectAttachents.TabIndex = 23;
            this.cbInspectAttachents.Text = global::OutlookSafetyChecks.Properties.Resources.Option_InspectAttachments;
            this.cbInspectAttachents.UseVisualStyleBackColor = true;
            this.cbInspectAttachents.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbFlagUnknownContacts
            // 
            this.cbFlagUnknownContacts.AutoSize = true;
            this.cbFlagUnknownContacts.ForeColor = System.Drawing.Color.Black;
            this.cbFlagUnknownContacts.Location = new System.Drawing.Point(137, 178);
            this.cbFlagUnknownContacts.Name = "cbFlagUnknownContacts";
            this.cbFlagUnknownContacts.Size = new System.Drawing.Size(89, 17);
            this.cbFlagUnknownContacts.TabIndex = 22;
            this.cbFlagUnknownContacts.Text = global::OutlookSafetyChecks.Properties.Resources.Option_FlagUknownContacts;
            this.cbFlagUnknownContacts.UseVisualStyleBackColor = true;
            this.cbFlagUnknownContacts.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTLD_Blacklist
            // 
            this.cbTLD_Blacklist.AutoSize = true;
            this.cbTLD_Blacklist.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTLD_Blacklist.Location = new System.Drawing.Point(13, 132);
            this.cbTLD_Blacklist.Name = "cbTLD_Blacklist";
            this.cbTLD_Blacklist.Size = new System.Drawing.Size(94, 17);
            this.cbTLD_Blacklist.TabIndex = 21;
            this.cbTLD_Blacklist.Text = global::OutlookSafetyChecks.Properties.Resources.Option_TLDBlacklist;
            this.cbTLD_Blacklist.UseVisualStyleBackColor = true;
            this.cbTLD_Blacklist.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbTLD_Whitelist
            // 
            this.cbTLD_Whitelist.AutoSize = true;
            this.cbTLD_Whitelist.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbTLD_Whitelist.Location = new System.Drawing.Point(13, 155);
            this.cbTLD_Whitelist.Name = "cbTLD_Whitelist";
            this.cbTLD_Whitelist.Size = new System.Drawing.Size(95, 17);
            this.cbTLD_Whitelist.TabIndex = 20;
            this.cbTLD_Whitelist.Text = global::OutlookSafetyChecks.Properties.Resources.Option_TLDWhitelist;
            this.cbTLD_Whitelist.UseVisualStyleBackColor = true;
            this.cbTLD_Whitelist.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // cbVerifyContacts
            // 
            this.cbVerifyContacts.AutoSize = true;
            this.cbVerifyContacts.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbVerifyContacts.Location = new System.Drawing.Point(13, 178);
            this.cbVerifyContacts.Name = "cbVerifyContacts";
            this.cbVerifyContacts.Size = new System.Drawing.Size(118, 17);
            this.cbVerifyContacts.TabIndex = 18;
            this.cbVerifyContacts.Text = global::OutlookSafetyChecks.Properties.Resources.Option_VerifyContacts;
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
            this.cbLookupHIBP.Text = global::OutlookSafetyChecks.Properties.Resources.Option_LookupHIBP;
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
            this.cbLookupWHOIS.Text = global::OutlookSafetyChecks.Properties.Resources.Option_LookupWHOIS;
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
            this.cbLookupDNSBL.Text = global::OutlookSafetyChecks.Properties.Resources.Option_LookupDNSBL;
            this.cbLookupDNSBL.UseVisualStyleBackColor = true;
            this.cbLookupDNSBL.CheckedChanged += new System.EventHandler(this.onChange_CheckBox);
            // 
            // logGridView
            // 
            this.logGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logGridView.Location = new System.Drawing.Point(0, 0);
            this.logGridView.Name = "logGridView";
            this.logGridView.ReadOnly = true;
            this.logGridView.Size = new System.Drawing.Size(504, 217);
            this.logGridView.TabIndex = 0;
            // 
            // textBoxProgress
            // 
            this.textBoxProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProgress.Location = new System.Drawing.Point(0, 0);
            this.textBoxProgress.Name = "textBoxProgress";
            this.textBoxProgress.ReadOnly = true;
            this.textBoxProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProgress.Size = new System.Drawing.Size(504, 20);
            this.textBoxProgress.TabIndex = 28;
            // 
            // infoTab
            // 
            this.infoTab.Controls.Add(this.infoGridView);
            this.infoTab.Location = new System.Drawing.Point(4, 22);
            this.infoTab.Name = "infoTab";
            this.infoTab.Padding = new System.Windows.Forms.Padding(3);
            this.infoTab.Size = new System.Drawing.Size(504, 486);
            this.infoTab.TabIndex = 1;
            this.infoTab.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Envelope;
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // infoGridView
            // 
            this.infoGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoGridView.Location = new System.Drawing.Point(3, 3);
            this.infoGridView.Name = "infoGridView";
            this.infoGridView.ReadOnly = true;
            this.infoGridView.Size = new System.Drawing.Size(498, 480);
            this.infoGridView.TabIndex = 0;
            // 
            // headerTab
            // 
            this.headerTab.Controls.Add(this.splitContainer2);
            this.headerTab.Location = new System.Drawing.Point(4, 22);
            this.headerTab.Name = "headerTab";
            this.headerTab.Padding = new System.Windows.Forms.Padding(3);
            this.headerTab.Size = new System.Drawing.Size(504, 486);
            this.headerTab.TabIndex = 3;
            this.headerTab.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Headers;
            this.headerTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer2.Size = new System.Drawing.Size(498, 480);
            this.splitContainer2.SplitterDistance = 286;
            this.splitContainer2.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.headerGridView);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(498, 286);
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
            this.headerGridView.Size = new System.Drawing.Size(492, 267);
            this.headerGridView.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rawHeaderTextBox);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(498, 190);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "SMTP Headers (Raw)";
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
            this.rawHeaderTextBox.Size = new System.Drawing.Size(492, 171);
            this.rawHeaderTextBox.TabIndex = 0;
            this.rawHeaderTextBox.WordWrap = false;
            // 
            // contactTab
            // 
            this.contactTab.Controls.Add(this.splitContainer3);
            this.contactTab.Location = new System.Drawing.Point(4, 22);
            this.contactTab.Name = "contactTab";
            this.contactTab.Padding = new System.Windows.Forms.Padding(3);
            this.contactTab.Size = new System.Drawing.Size(504, 486);
            this.contactTab.TabIndex = 4;
            this.contactTab.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Contacts;
            this.contactTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox7);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox8);
            this.splitContainer3.Size = new System.Drawing.Size(498, 480);
            this.splitContainer3.SplitterDistance = 214;
            this.splitContainer3.TabIndex = 3;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.senderGridView);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(498, 214);
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
            this.senderGridView.Size = new System.Drawing.Size(492, 195);
            this.senderGridView.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.recipientsGridView);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(498, 262);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Recipients(s)";
            // 
            // recipientsGridView
            // 
            this.recipientsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipientsGridView.Location = new System.Drawing.Point(3, 16);
            this.recipientsGridView.Name = "recipientsGridView";
            this.recipientsGridView.ReadOnly = true;
            this.recipientsGridView.Size = new System.Drawing.Size(492, 243);
            this.recipientsGridView.TabIndex = 3;
            // 
            // routeTab
            // 
            this.routeTab.Controls.Add(this.splitContainer4);
            this.routeTab.Location = new System.Drawing.Point(4, 22);
            this.routeTab.Name = "routeTab";
            this.routeTab.Padding = new System.Windows.Forms.Padding(3);
            this.routeTab.Size = new System.Drawing.Size(504, 486);
            this.routeTab.TabIndex = 6;
            this.routeTab.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Routing;
            this.routeTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer4.Size = new System.Drawing.Size(498, 480);
            this.splitContainer4.SplitterDistance = 234;
            this.splitContainer4.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.routeCheckGridView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 234);
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
            this.routeCheckGridView.Size = new System.Drawing.Size(492, 215);
            this.routeCheckGridView.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.routeListGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 242);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Route List";
            // 
            // routeListGridView
            // 
            this.routeListGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeListGridView.Location = new System.Drawing.Point(3, 16);
            this.routeListGridView.Name = "routeListGridView";
            this.routeListGridView.ReadOnly = true;
            this.routeListGridView.Size = new System.Drawing.Size(492, 223);
            this.routeListGridView.TabIndex = 0;
            // 
            // linksTab
            // 
            this.linksTab.Controls.Add(this.splitContainer5);
            this.linksTab.Location = new System.Drawing.Point(4, 22);
            this.linksTab.Name = "linksTab";
            this.linksTab.Padding = new System.Windows.Forms.Padding(3);
            this.linksTab.Size = new System.Drawing.Size(504, 486);
            this.linksTab.TabIndex = 7;
            this.linksTab.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Links;
            this.linksTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(3, 3);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer5.Size = new System.Drawing.Size(498, 480);
            this.splitContainer5.SplitterDistance = 265;
            this.splitContainer5.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.linkCheckGridView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(498, 265);
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
            this.linkCheckGridView.Size = new System.Drawing.Size(492, 246);
            this.linkCheckGridView.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.linkListGridView);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(498, 211);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Link List";
            // 
            // linkListGridView
            // 
            this.linkListGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkListGridView.Location = new System.Drawing.Point(3, 16);
            this.linkListGridView.Name = "linkListGridView";
            this.linkListGridView.ReadOnly = true;
            this.linkListGridView.Size = new System.Drawing.Size(492, 192);
            this.linkListGridView.TabIndex = 0;
            // 
            // attachmentsTab
            // 
            this.attachmentsTab.Controls.Add(this.attachmentsGridView);
            this.attachmentsTab.Location = new System.Drawing.Point(4, 22);
            this.attachmentsTab.Name = "attachmentsTab";
            this.attachmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.attachmentsTab.Size = new System.Drawing.Size(504, 486);
            this.attachmentsTab.TabIndex = 8;
            this.attachmentsTab.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Attachments;
            this.attachmentsTab.UseVisualStyleBackColor = true;
            // 
            // attachmentsGridView
            // 
            this.attachmentsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachmentsGridView.Location = new System.Drawing.Point(3, 3);
            this.attachmentsGridView.Name = "attachmentsGridView";
            this.attachmentsGridView.ReadOnly = true;
            this.attachmentsGridView.Size = new System.Drawing.Size(498, 480);
            this.attachmentsGridView.TabIndex = 2;
            // 
            // loggingTab
            // 
            this.loggingTab.Controls.Add(this.textDebug);
            this.loggingTab.Location = new System.Drawing.Point(4, 22);
            this.loggingTab.Name = "loggingTab";
            this.loggingTab.Padding = new System.Windows.Forms.Padding(3);
            this.loggingTab.Size = new System.Drawing.Size(504, 486);
            this.loggingTab.TabIndex = 9;
            this.loggingTab.Text = global::OutlookSafetyChecks.Properties.Resources.Title_Logging;
            this.loggingTab.UseVisualStyleBackColor = true;
            // 
            // textDebug
            // 
            this.textDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textDebug.Location = new System.Drawing.Point(3, 3);
            this.textDebug.Multiline = true;
            this.textDebug.Name = "textDebug";
            this.textDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textDebug.Size = new System.Drawing.Size(498, 480);
            this.textDebug.TabIndex = 0;
            this.textDebug.WordWrap = false;
            // 
            // dlgSafetyCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.myTabControl);
            this.MinimumSize = new System.Drawing.Size(512, 512);
            this.Name = "dlgSafetyCheck";
            this.Text = "✓ Checco\'s Safety Checks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgSafetyCheck_FormClosing);
            this.myTabControl.ResumeLayout(false);
            this.optionsTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.groupTests.ResumeLayout(false);
            this.groupTests.PerformLayout();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).EndInit();
            this.infoTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoGridView)).EndInit();
            this.headerTab.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGridView)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.contactTab.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.senderGridView)).EndInit();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recipientsGridView)).EndInit();
            this.routeTab.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.routeCheckGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.routeListGridView)).EndInit();
            this.linksTab.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.linkCheckGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
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
		private GroupBox groupBox2;
		private GroupBox groupBox1;
		private GroupBox groupBox4;
		private GroupBox groupBox3;
		private GroupBox groupBox6;
		private GroupBox groupBox5;
		private GroupBox groupBox8;
		private GroupBox groupBox7;
        //
		private SplitContainer splitContainer2;
		private SplitContainer splitContainer3;
		private SplitContainer splitContainer4;
		private SplitContainer splitContainer5;
		private SplitContainer splitContainer1;
		private SplitContainer splitContainer6;
		private SplitContainer splitContainer7;
        //
        public TextBox rawHeaderTextBox;
        public TextBox textDebug;
        public TextBox textBoxProgress;
        private Button btnSaveOptions;
    }
}
