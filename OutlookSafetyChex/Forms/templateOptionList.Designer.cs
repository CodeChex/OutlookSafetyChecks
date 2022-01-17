namespace OutlookSafetyChex.Forms
{
    partial class templateOptionList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.listBoxAvailable = new System.Windows.Forms.ListBox();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.labelLeft = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.textInputNew = new System.Windows.Forms.TextBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.listBoxSelected = new System.Windows.Forms.ListBox();
            this.panelRightBottom = new System.Windows.Forms.Panel();
            this.labelRight = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.panelMid = new System.Windows.Forms.Panel();
            this.btnSuggested = new System.Windows.Forms.Button();
            this.btnMoveAllRight = new System.Windows.Forms.Button();
            this.btnMoveAllLeft = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelRightBottom.SuspendLayout();
            this.panelMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.listBoxAvailable);
            this.panelLeft.Controls.Add(this.panelBottomLeft);
            this.panelLeft.Controls.Add(this.labelLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(220, 504);
            this.panelLeft.TabIndex = 0;
            // 
            // listBoxAvailable
            // 
            this.listBoxAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAvailable.FormattingEnabled = true;
            this.listBoxAvailable.Location = new System.Drawing.Point(0, 30);
            this.listBoxAvailable.Name = "listBoxAvailable";
            this.listBoxAvailable.Size = new System.Drawing.Size(220, 401);
            this.listBoxAvailable.TabIndex = 3;
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomLeft.Location = new System.Drawing.Point(0, 431);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(220, 73);
            this.panelBottomLeft.TabIndex = 4;
            // 
            // labelLeft
            // 
            this.labelLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeft.Location = new System.Drawing.Point(0, 0);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(220, 30);
            this.labelLeft.TabIndex = 0;
            this.labelLeft.Text = "Available";
            this.labelLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(22, 37);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(68, 24);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "Add";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.addNew_Click);
            // 
            // textInputNew
            // 
            this.textInputNew.Location = new System.Drawing.Point(22, 12);
            this.textInputNew.Name = "textInputNew";
            this.textInputNew.Size = new System.Drawing.Size(200, 20);
            this.textInputNew.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.listBoxSelected);
            this.panelRight.Controls.Add(this.panelRightBottom);
            this.panelRight.Controls.Add(this.labelRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(320, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(234, 504);
            this.panelRight.TabIndex = 1;
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.Location = new System.Drawing.Point(0, 30);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.Size = new System.Drawing.Size(234, 399);
            this.listBoxSelected.TabIndex = 2;
            // 
            // panelRightBottom
            // 
            this.panelRightBottom.Controls.Add(this.btnAddNew);
            this.panelRightBottom.Controls.Add(this.textInputNew);
            this.panelRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRightBottom.Location = new System.Drawing.Point(0, 429);
            this.panelRightBottom.MinimumSize = new System.Drawing.Size(225, 75);
            this.panelRightBottom.Name = "panelRightBottom";
            this.panelRightBottom.Size = new System.Drawing.Size(234, 75);
            this.panelRightBottom.TabIndex = 3;
            // 
            // labelRight
            // 
            this.labelRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRight.Location = new System.Drawing.Point(0, 0);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(234, 30);
            this.labelRight.TabIndex = 1;
            this.labelRight.Text = "Selected";
            this.labelRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSave.Image = global::OutlookSafetyChex.Properties.Resources.Save_16x_32;
            this.btnSave.Location = new System.Drawing.Point(6, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 26);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnRevert
            // 
            this.btnRevert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevert.Location = new System.Drawing.Point(6, 407);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(88, 24);
            this.btnRevert.TabIndex = 5;
            this.btnRevert.Text = "Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // panelMid
            // 
            this.panelMid.Controls.Add(this.btnSuggested);
            this.panelMid.Controls.Add(this.btnRevert);
            this.panelMid.Controls.Add(this.btnSave);
            this.panelMid.Controls.Add(this.btnMoveAllRight);
            this.panelMid.Controls.Add(this.btnMoveAllLeft);
            this.panelMid.Controls.Add(this.btnMoveLeft);
            this.panelMid.Controls.Add(this.btnMoveRight);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMid.Location = new System.Drawing.Point(220, 0);
            this.panelMid.MinimumSize = new System.Drawing.Size(100, 500);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(100, 504);
            this.panelMid.TabIndex = 2;
            // 
            // btnSuggested
            // 
            this.btnSuggested.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuggested.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuggested.Location = new System.Drawing.Point(6, 3);
            this.btnSuggested.Name = "btnSuggested";
            this.btnSuggested.Size = new System.Drawing.Size(88, 47);
            this.btnSuggested.TabIndex = 6;
            this.btnSuggested.Text = "Suggested Selections";
            this.btnSuggested.UseVisualStyleBackColor = true;
            this.btnSuggested.Click += new System.EventHandler(this.btnSuggested_Click);
            // 
            // btnMoveAllRight
            // 
            this.btnMoveAllRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveAllRight.Location = new System.Drawing.Point(6, 96);
            this.btnMoveAllRight.Name = "btnMoveAllRight";
            this.btnMoveAllRight.Size = new System.Drawing.Size(88, 38);
            this.btnMoveAllRight.TabIndex = 3;
            this.btnMoveAllRight.Text = "---->>";
            this.btnMoveAllRight.UseVisualStyleBackColor = true;
            this.btnMoveAllRight.Click += new System.EventHandler(this.addAll_Click);
            // 
            // btnMoveAllLeft
            // 
            this.btnMoveAllLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveAllLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAllLeft.Location = new System.Drawing.Point(6, 321);
            this.btnMoveAllLeft.Name = "btnMoveAllLeft";
            this.btnMoveAllLeft.Size = new System.Drawing.Size(88, 38);
            this.btnMoveAllLeft.TabIndex = 2;
            this.btnMoveAllLeft.Text = "<<----";
            this.btnMoveAllLeft.UseVisualStyleBackColor = true;
            this.btnMoveAllLeft.Click += new System.EventHandler(this.removeAll_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveLeft.Location = new System.Drawing.Point(6, 233);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(88, 38);
            this.btnMoveLeft.TabIndex = 1;
            this.btnMoveLeft.Text = "<----";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.removeSelected_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveRight.Location = new System.Drawing.Point(6, 178);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(88, 38);
            this.btnMoveRight.TabIndex = 0;
            this.btnMoveRight.Text = "---->";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.addSelected_Click);
            // 
            // templateOptionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 504);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "templateOptionList";
            this.Text = "Option List Editor";
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRightBottom.ResumeLayout(false);
            this.panelRightBottom.PerformLayout();
            this.panelMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.Panel panelRightBottom;
        public System.Windows.Forms.Button btnMoveAllRight;
        public System.Windows.Forms.Button btnMoveAllLeft;
        public System.Windows.Forms.Button btnMoveLeft;
        public System.Windows.Forms.Button btnMoveRight;
        public System.Windows.Forms.Label labelLeft;
        public System.Windows.Forms.Label labelRight;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnAddNew;
        public System.Windows.Forms.TextBox textInputNew;
        public System.Windows.Forms.ListBox listBoxAvailable;
        public System.Windows.Forms.ListBox listBoxSelected;
        public System.Windows.Forms.Button btnRevert;
        public System.Windows.Forms.Button btnSuggested;
    }
}