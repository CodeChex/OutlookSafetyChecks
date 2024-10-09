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
            panelLeft = new System.Windows.Forms.Panel();
            listBoxAvailable = new System.Windows.Forms.ListBox();
            panelBottomLeft = new System.Windows.Forms.Panel();
            labelLeft = new System.Windows.Forms.Label();
            btnAddNew = new System.Windows.Forms.Button();
            textInputNew = new System.Windows.Forms.TextBox();
            panelRight = new System.Windows.Forms.Panel();
            listBoxSelected = new System.Windows.Forms.ListBox();
            panelRightBottom = new System.Windows.Forms.Panel();
            labelRight = new System.Windows.Forms.Label();
            btnSave = new System.Windows.Forms.Button();
            btnRevert = new System.Windows.Forms.Button();
            panelMid = new System.Windows.Forms.Panel();
            btnSuggested = new System.Windows.Forms.Button();
            btnMoveAllRight = new System.Windows.Forms.Button();
            btnMoveAllLeft = new System.Windows.Forms.Button();
            btnMoveLeft = new System.Windows.Forms.Button();
            btnMoveRight = new System.Windows.Forms.Button();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            panelRightBottom.SuspendLayout();
            panelMid.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(listBoxAvailable);
            panelLeft.Controls.Add(panelBottomLeft);
            panelLeft.Controls.Add(labelLeft);
            panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            panelLeft.Location = new System.Drawing.Point(0, 0);
            panelLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(257, 582);
            panelLeft.TabIndex = 0;
            // 
            // listBoxAvailable
            // 
            listBoxAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            listBoxAvailable.FormattingEnabled = true;
            listBoxAvailable.ItemHeight = 15;
            listBoxAvailable.Location = new System.Drawing.Point(0, 35);
            listBoxAvailable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listBoxAvailable.Name = "listBoxAvailable";
            listBoxAvailable.Size = new System.Drawing.Size(257, 463);
            listBoxAvailable.TabIndex = 3;
            // 
            // panelBottomLeft
            // 
            panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottomLeft.Location = new System.Drawing.Point(0, 498);
            panelBottomLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelBottomLeft.Name = "panelBottomLeft";
            panelBottomLeft.Size = new System.Drawing.Size(257, 84);
            panelBottomLeft.TabIndex = 4;
            // 
            // labelLeft
            // 
            labelLeft.Dock = System.Windows.Forms.DockStyle.Top;
            labelLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelLeft.Location = new System.Drawing.Point(0, 0);
            labelLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelLeft.Name = "labelLeft";
            labelLeft.Size = new System.Drawing.Size(257, 35);
            labelLeft.TabIndex = 0;
            labelLeft.Text = "Available";
            labelLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddNew
            // 
            btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnAddNew.Image = Properties.Resources.add_16x16;
            btnAddNew.Location = new System.Drawing.Point(26, 43);
            btnAddNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new System.Drawing.Size(96, 28);
            btnAddNew.TabIndex = 5;
            btnAddNew.Text = "&Add New";
            btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += addNew_Click;
            // 
            // textInputNew
            // 
            textInputNew.Location = new System.Drawing.Point(26, 14);
            textInputNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textInputNew.Name = "textInputNew";
            textInputNew.Size = new System.Drawing.Size(233, 23);
            textInputNew.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(listBoxSelected);
            panelRight.Controls.Add(panelRightBottom);
            panelRight.Controls.Add(labelRight);
            panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelRight.Location = new System.Drawing.Point(373, 0);
            panelRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(273, 582);
            panelRight.TabIndex = 1;
            // 
            // listBoxSelected
            // 
            listBoxSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            listBoxSelected.FormattingEnabled = true;
            listBoxSelected.ItemHeight = 15;
            listBoxSelected.Location = new System.Drawing.Point(0, 35);
            listBoxSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listBoxSelected.Name = "listBoxSelected";
            listBoxSelected.Size = new System.Drawing.Size(273, 460);
            listBoxSelected.TabIndex = 2;
            // 
            // panelRightBottom
            // 
            panelRightBottom.Controls.Add(btnAddNew);
            panelRightBottom.Controls.Add(textInputNew);
            panelRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelRightBottom.Location = new System.Drawing.Point(0, 495);
            panelRightBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelRightBottom.MinimumSize = new System.Drawing.Size(262, 87);
            panelRightBottom.Name = "panelRightBottom";
            panelRightBottom.Size = new System.Drawing.Size(273, 87);
            panelRightBottom.TabIndex = 3;
            // 
            // labelRight
            // 
            labelRight.Dock = System.Windows.Forms.DockStyle.Top;
            labelRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelRight.Location = new System.Drawing.Point(0, 0);
            labelRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelRight.Name = "labelRight";
            labelRight.Size = new System.Drawing.Size(273, 35);
            labelRight.TabIndex = 1;
            labelRight.Text = "Selected";
            labelRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSave.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            btnSave.Image = Properties.Resources.Save_16x_32;
            btnSave.Location = new System.Drawing.Point(7, 538);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(103, 30);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRevert
            // 
            btnRevert.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnRevert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnRevert.Image = Properties.Resources.reload_16x16;
            btnRevert.Location = new System.Drawing.Point(7, 470);
            btnRevert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRevert.Name = "btnRevert";
            btnRevert.Size = new System.Drawing.Size(103, 28);
            btnRevert.TabIndex = 5;
            btnRevert.Text = "Revert";
            btnRevert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnRevert.UseVisualStyleBackColor = true;
            btnRevert.Click += btnRevert_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(btnSuggested);
            panelMid.Controls.Add(btnRevert);
            panelMid.Controls.Add(btnSave);
            panelMid.Controls.Add(btnMoveAllRight);
            panelMid.Controls.Add(btnMoveAllLeft);
            panelMid.Controls.Add(btnMoveLeft);
            panelMid.Controls.Add(btnMoveRight);
            panelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMid.Location = new System.Drawing.Point(257, 0);
            panelMid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelMid.MinimumSize = new System.Drawing.Size(117, 577);
            panelMid.Name = "panelMid";
            panelMid.Size = new System.Drawing.Size(117, 582);
            panelMid.TabIndex = 2;
            // 
            // btnSuggested
            // 
            btnSuggested.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnSuggested.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnSuggested.Location = new System.Drawing.Point(7, 3);
            btnSuggested.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSuggested.Name = "btnSuggested";
            btnSuggested.Size = new System.Drawing.Size(103, 54);
            btnSuggested.TabIndex = 6;
            btnSuggested.Text = "Suggested Selections";
            btnSuggested.UseVisualStyleBackColor = true;
            btnSuggested.Click += btnSuggested_Click;
            // 
            // btnMoveAllRight
            // 
            btnMoveAllRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnMoveAllRight.Image = Properties.Resources.chevron_right_16x16;
            btnMoveAllRight.Location = new System.Drawing.Point(7, 111);
            btnMoveAllRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveAllRight.Name = "btnMoveAllRight";
            btnMoveAllRight.Size = new System.Drawing.Size(103, 44);
            btnMoveAllRight.TabIndex = 3;
            btnMoveAllRight.Text = "Add All";
            btnMoveAllRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnMoveAllRight.UseVisualStyleBackColor = true;
            btnMoveAllRight.Click += addAll_Click;
            // 
            // btnMoveAllLeft
            // 
            btnMoveAllLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnMoveAllLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnMoveAllLeft.Image = Properties.Resources.trash_16x16;
            btnMoveAllLeft.Location = new System.Drawing.Point(7, 370);
            btnMoveAllLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveAllLeft.Name = "btnMoveAllLeft";
            btnMoveAllLeft.Size = new System.Drawing.Size(103, 44);
            btnMoveAllLeft.TabIndex = 2;
            btnMoveAllLeft.Text = "Remove All";
            btnMoveAllLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            btnMoveAllLeft.UseVisualStyleBackColor = true;
            btnMoveAllLeft.Click += removeAll_Click;
            // 
            // btnMoveLeft
            // 
            btnMoveLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnMoveLeft.Image = Properties.Resources.remove_16x16;
            btnMoveLeft.Location = new System.Drawing.Point(7, 269);
            btnMoveLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveLeft.Name = "btnMoveLeft";
            btnMoveLeft.Size = new System.Drawing.Size(103, 44);
            btnMoveLeft.TabIndex = 1;
            btnMoveLeft.Text = "Remove Selected";
            btnMoveLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            btnMoveLeft.UseVisualStyleBackColor = true;
            btnMoveLeft.Click += removeSelected_Click;
            // 
            // btnMoveRight
            // 
            btnMoveRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnMoveRight.Image = Properties.Resources.arrow_right_16x16;
            btnMoveRight.Location = new System.Drawing.Point(7, 205);
            btnMoveRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveRight.Name = "btnMoveRight";
            btnMoveRight.Size = new System.Drawing.Size(103, 44);
            btnMoveRight.TabIndex = 0;
            btnMoveRight.Text = "Add Selected";
            btnMoveRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnMoveRight.UseVisualStyleBackColor = true;
            btnMoveRight.Click += addSelected_Click;
            // 
            // templateOptionList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(646, 582);
            Controls.Add(panelMid);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "templateOptionList";
            Text = "Option List Editor";
            panelLeft.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelRightBottom.ResumeLayout(false);
            panelRightBottom.PerformLayout();
            panelMid.ResumeLayout(false);
            ResumeLayout(false);
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