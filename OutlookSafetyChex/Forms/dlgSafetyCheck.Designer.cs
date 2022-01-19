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
            this.findingsTab = new System.Windows.Forms.TabPage();
            this.findingsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.logGridView = new System.Windows.Forms.DataGridView();
            this.textBoxProgress = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.envelopeTab = new System.Windows.Forms.TabPage();
            this.envelopeGridView = new System.Windows.Forms.DataGridView();
            this.headerTab = new System.Windows.Forms.TabPage();
            this.splitHeaders = new System.Windows.Forms.SplitContainer();
            this.groupBoxParsedHeaders = new System.Windows.Forms.GroupBox();
            this.headerGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxRawHeaders = new System.Windows.Forms.GroupBox();
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
            this.headerCheckGridView = new System.Windows.Forms.DataGridView();
            this.myTabControl.SuspendLayout();
            this.findingsTab.SuspendLayout();
            this.findingsTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).BeginInit();
            this.envelopeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.envelopeGridView)).BeginInit();
            this.headerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitHeaders)).BeginInit();
            this.splitHeaders.Panel1.SuspendLayout();
            this.splitHeaders.Panel2.SuspendLayout();
            this.splitHeaders.SuspendLayout();
            this.groupBoxParsedHeaders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGridView)).BeginInit();
            this.groupBoxRawHeaders.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.headerCheckGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // myTabControl
            // 
            this.myTabControl.Controls.Add(this.findingsTab);
            this.myTabControl.Controls.Add(this.envelopeTab);
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
            // findingsTab
            // 
            this.findingsTab.Controls.Add(this.findingsTableLayout);
            this.findingsTab.Location = new System.Drawing.Point(4, 22);
            this.findingsTab.Name = "findingsTab";
            this.findingsTab.Size = new System.Drawing.Size(874, 486);
            this.findingsTab.TabIndex = 11;
            this.findingsTab.Text = "Findings";
            this.findingsTab.UseVisualStyleBackColor = true;
            // 
            // findingsTableLayout
            // 
            this.findingsTableLayout.ColumnCount = 4;
            this.findingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.findingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.findingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.findingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.findingsTableLayout.Controls.Add(this.logGridView, 0, 2);
            this.findingsTableLayout.Controls.Add(this.textBoxProgress, 0, 1);
            this.findingsTableLayout.Controls.Add(this.btnCancel, 2, 0);
            this.findingsTableLayout.Controls.Add(this.btnSettings, 1, 0);
            this.findingsTableLayout.Controls.Add(this.btnAbout, 3, 0);
            this.findingsTableLayout.Controls.Add(this.btnRunTests, 0, 0);
            this.findingsTableLayout.Location = new System.Drawing.Point(3, 3);
            this.findingsTableLayout.Name = "findingsTableLayout";
            this.findingsTableLayout.RowCount = 3;
            this.findingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.findingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.findingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.findingsTableLayout.Size = new System.Drawing.Size(875, 480);
            this.findingsTableLayout.TabIndex = 0;
            // 
            // logGridView
            // 
            this.logGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findingsTableLayout.SetColumnSpan(this.logGridView, 4);
            this.logGridView.Location = new System.Drawing.Point(3, 60);
            this.logGridView.Name = "logGridView";
            this.logGridView.ReadOnly = true;
            this.logGridView.Size = new System.Drawing.Size(869, 417);
            this.logGridView.TabIndex = 32;
            // 
            // textBoxProgress
            // 
            this.textBoxProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findingsTableLayout.SetColumnSpan(this.textBoxProgress, 4);
            this.textBoxProgress.Location = new System.Drawing.Point(3, 34);
            this.textBoxProgress.Name = "textBoxProgress";
            this.textBoxProgress.ReadOnly = true;
            this.textBoxProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProgress.Size = new System.Drawing.Size(869, 20);
            this.textBoxProgress.TabIndex = 31;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 3;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::OutlookSafetyChex.Properties.Resources.stop_16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(511, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 25);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "&Stop Inspection";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnSettings.FlatAppearance.BorderSize = 3;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Image = global::OutlookSafetyChex.Properties.Resources.settings_16x16;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(282, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(90, 25);
            this.btnSettings.TabIndex = 35;
            this.btnSettings.Text = "&Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnAbout.FlatAppearance.BorderSize = 3;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Image = global::OutlookSafetyChex.Properties.Resources.info_16x16;
            this.btnAbout.Location = new System.Drawing.Point(797, 3);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 25);
            this.btnAbout.TabIndex = 36;
            this.btnAbout.Text = "&About";
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnRunTests
            // 
            this.btnRunTests.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnRunTests.FlatAppearance.BorderSize = 3;
            this.btnRunTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunTests.Image = global::OutlookSafetyChex.Properties.Resources.Run_16x;
            this.btnRunTests.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunTests.Location = new System.Drawing.Point(3, 3);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(125, 25);
            this.btnRunTests.TabIndex = 11;
            this.btnRunTests.Text = "&Inspect Email";
            this.btnRunTests.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // envelopeTab
            // 
            this.envelopeTab.Controls.Add(this.envelopeGridView);
            this.envelopeTab.Location = new System.Drawing.Point(4, 22);
            this.envelopeTab.Name = "envelopeTab";
            this.envelopeTab.Padding = new System.Windows.Forms.Padding(3);
            this.envelopeTab.Size = new System.Drawing.Size(874, 486);
            this.envelopeTab.TabIndex = 1;
            this.envelopeTab.Text = global::OutlookSafetyChex.Properties.Resources.Title_Envelope;
            this.envelopeTab.UseVisualStyleBackColor = true;
            // 
            // envelopeGridView
            // 
            this.envelopeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.envelopeGridView.Location = new System.Drawing.Point(3, 3);
            this.envelopeGridView.Name = "envelopeGridView";
            this.envelopeGridView.ReadOnly = true;
            this.envelopeGridView.Size = new System.Drawing.Size(868, 480);
            this.envelopeGridView.TabIndex = 0;
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
            this.splitHeaders.Panel1.Controls.Add(this.groupBoxParsedHeaders);
            // 
            // splitHeaders.Panel2
            // 
            this.splitHeaders.Panel2.Controls.Add(this.groupBoxRawHeaders);
            this.splitHeaders.Size = new System.Drawing.Size(868, 480);
            this.splitHeaders.SplitterDistance = 286;
            this.splitHeaders.TabIndex = 3;
            // 
            // groupBoxParsedHeaders
            // 
            this.groupBoxParsedHeaders.Controls.Add(this.headerGridView);
            this.groupBoxParsedHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxParsedHeaders.Location = new System.Drawing.Point(0, 0);
            this.groupBoxParsedHeaders.Name = "groupBoxParsedHeaders";
            this.groupBoxParsedHeaders.Size = new System.Drawing.Size(868, 286);
            this.groupBoxParsedHeaders.TabIndex = 1;
            this.groupBoxParsedHeaders.TabStop = false;
            this.groupBoxParsedHeaders.Text = "SMTP Headers (Parsed)";
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
            // groupBoxRawHeaders
            // 
            this.groupBoxRawHeaders.Controls.Add(this.rawHeaderTextBox);
            this.groupBoxRawHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRawHeaders.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRawHeaders.Name = "groupBoxRawHeaders";
            this.groupBoxRawHeaders.Size = new System.Drawing.Size(868, 190);
            this.groupBoxRawHeaders.TabIndex = 2;
            this.groupBoxRawHeaders.TabStop = false;
            this.groupBoxRawHeaders.Text = "SMTP Headers (Raw)";
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
            this.loggingTab.TabIndex = 10;
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
            // headerCheckGridView
            // 
            this.headerCheckGridView.Location = new System.Drawing.Point(0, 0);
            this.headerCheckGridView.Name = "headerCheckGridView";
            this.headerCheckGridView.Size = new System.Drawing.Size(240, 150);
            this.headerCheckGridView.TabIndex = 0;
            // 
            // dlgSafetyCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(882, 512);
            this.Controls.Add(this.myTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(512, 512);
            this.Name = "dlgSafetyCheck";
            this.Text = "✓ CodeChex Outlook Email Safety Checks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgSafetyCheck_FormClosing);
            this.myTabControl.ResumeLayout(false);
            this.findingsTab.ResumeLayout(false);
            this.findingsTableLayout.ResumeLayout(false);
            this.findingsTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGridView)).EndInit();
            this.envelopeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.envelopeGridView)).EndInit();
            this.headerTab.ResumeLayout(false);
            this.splitHeaders.Panel1.ResumeLayout(false);
            this.splitHeaders.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitHeaders)).EndInit();
            this.splitHeaders.ResumeLayout(false);
            this.groupBoxParsedHeaders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGridView)).EndInit();
            this.groupBoxRawHeaders.ResumeLayout(false);
            this.groupBoxRawHeaders.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.headerCheckGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public TabControl myTabControl;
        //
        public TabPage envelopeTab;
        public TabPage headerTab;
        public TabPage contactTab;
        public TabPage routeTab;
        public TabPage bodyTab;
        public TabPage linksTab;
        public TabPage attachmentsTab;
        public TabPage loggingTab;
        //
        public DataGridView envelopeGridView;
        public DataGridView headerGridView;
        public DataGridView senderGridView;
        public DataGridView linkCheckGridView;
		public DataGridView linkListGridView;
		public DataGridView routeCheckGridView;
        public DataGridView headerCheckGridView;
        public DataGridView routeListGridView;
        public DataGridView bodyGridView;
        public DataGridView attachmentsGridView;
		public DataGridView recipientsGridView;
		private GroupBox groupBoxRoutes;
		private GroupBox groupBox1;
		private GroupBox groupBoxLinks;
		private GroupBox groupBox3;
		private GroupBox groupBoxRawHeaders;
		private GroupBox groupBoxParsedHeaders;
		private GroupBox groupBoxContacts;
		private GroupBox groupBox7;
        //
		private SplitContainer splitHeaders;
		private SplitContainer splitContacts;
		private SplitContainer splitRouting;
		private SplitContainer splitLinks;
        //
        public TextBox rawHeaderTextBox;
        public TextBox textDebug;
        private TabPage findingsTab;
        private TableLayoutPanel findingsTableLayout;
        public DataGridView logGridView;
        public TextBox textBoxProgress;
        private Button btnRunTests;
        private Button btnCancel;
        private Button btnSettings;
        private Button btnAbout;
    }
}
