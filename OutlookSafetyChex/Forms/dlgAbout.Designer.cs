namespace OutlookSafetyChex.Forms
{
    partial class dlgAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            logoPictureBox = new System.Windows.Forms.PictureBox();
            labelProductName = new System.Windows.Forms.Label();
            labelVersion = new System.Windows.Forms.Label();
            labelCopyright = new System.Windows.Forms.Label();
            labelAuthor = new System.Windows.Forms.Label();
            okButton = new System.Windows.Forms.Button();
            linkProjectSite = new System.Windows.Forms.LinkLabel();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.21103F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.78897F));
            tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(labelProductName, 1, 0);
            tableLayoutPanel.Controls.Add(labelVersion, 1, 1);
            tableLayoutPanel.Controls.Add(labelCopyright, 1, 3);
            tableLayoutPanel.Controls.Add(labelAuthor, 1, 2);
            tableLayoutPanel.Controls.Add(okButton, 1, 5);
            tableLayoutPanel.Controls.Add(linkProjectSite, 1, 4);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel.Size = new System.Drawing.Size(487, 204);
            tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.BackColor = System.Drawing.Color.White;
            logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            logoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            logoPictureBox.Image = Properties.Resources.EmailCheck_Banner1;
            logoPictureBox.Location = new System.Drawing.Point(4, 3);
            logoPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            logoPictureBox.Name = "logoPictureBox";
            tableLayoutPanel.SetRowSpan(logoPictureBox, 5);
            logoPictureBox.Size = new System.Drawing.Size(168, 164);
            logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 12;
            logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            labelProductName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelProductName.AutoSize = true;
            labelProductName.Location = new System.Drawing.Point(183, 0);
            labelProductName.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            labelProductName.MaximumSize = new System.Drawing.Size(0, 20);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new System.Drawing.Size(300, 20);
            labelProductName.TabIndex = 19;
            labelProductName.Text = "Product Name";
            labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelVersion.AutoSize = true;
            labelVersion.Location = new System.Drawing.Point(183, 34);
            labelVersion.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            labelVersion.MaximumSize = new System.Drawing.Size(0, 20);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new System.Drawing.Size(300, 20);
            labelVersion.TabIndex = 0;
            labelVersion.Text = "Version";
            labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            labelCopyright.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelCopyright.AutoSize = true;
            labelCopyright.Location = new System.Drawing.Point(180, 102);
            labelCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new System.Drawing.Size(303, 34);
            labelCopyright.TabIndex = 26;
            labelCopyright.Text = "Copyright";
            labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAuthor
            // 
            labelAuthor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new System.Drawing.Point(183, 68);
            labelAuthor.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            labelAuthor.MaximumSize = new System.Drawing.Size(0, 20);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new System.Drawing.Size(300, 20);
            labelAuthor.TabIndex = 21;
            labelAuthor.Text = "Author";
            labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            okButton.Location = new System.Drawing.Point(395, 174);
            okButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(88, 27);
            okButton.TabIndex = 24;
            okButton.Text = "&OK";
            // 
            // linkProjectSite
            // 
            linkProjectSite.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            linkProjectSite.AutoSize = true;
            linkProjectSite.Location = new System.Drawing.Point(180, 136);
            linkProjectSite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkProjectSite.Name = "linkProjectSite";
            linkProjectSite.Size = new System.Drawing.Size(303, 34);
            linkProjectSite.TabIndex = 25;
            linkProjectSite.TabStop = true;
            linkProjectSite.Text = "Project Website";
            linkProjectSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            linkProjectSite.LinkClicked += linkProjectSite_LinkClicked;
            // 
            // dlgAbout
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(507, 224);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "dlgAbout";
            Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "About OutlookSafetyChecks";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.LinkLabel linkProjectSite;
        private System.Windows.Forms.Label labelCopyright;
    }
}
