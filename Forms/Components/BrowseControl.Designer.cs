namespace portal_demo_essentials.Forms.Components
{
    partial class BrowseControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labName = new System.Windows.Forms.Label();
            this.BoxPath = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.labName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BoxPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.butBrowse, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 30);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labName
            // 
            this.labName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(0, 8);
            this.labName.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(45, 13);
            this.labName.TabIndex = 0;
            this.labName.Text = "<name>";
            // 
            // BoxPath
            // 
            this.BoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxPath.Location = new System.Drawing.Point(103, 5);
            this.BoxPath.Name = "BoxPath";
            this.BoxPath.Size = new System.Drawing.Size(319, 20);
            this.BoxPath.TabIndex = 1;
            // 
            // butBrowse
            // 
            this.butBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.butBrowse.AutoSize = true;
            this.butBrowse.Location = new System.Drawing.Point(428, 3);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(69, 24);
            this.butBrowse.TabIndex = 2;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // BrowseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BrowseControl";
            this.Size = new System.Drawing.Size(500, 30);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Button butBrowse;
        public System.Windows.Forms.TextBox BoxPath;
    }
}
