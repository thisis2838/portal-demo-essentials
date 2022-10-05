namespace portal_demo_essentials.Forms
{
    partial class PrintToConsoleForm
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
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDemoParser = new System.Windows.Forms.ComboBox();
            this.boxPath = new portal_demo_essentials.Forms.Components.BrowseControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chkEnabled, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbDemoParser, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.boxPath, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(614, 405);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(3, 6);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.chkEnabled.Size = new System.Drawing.Size(68, 17);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Demo Parser";
            // 
            // cmbDemoParser
            // 
            this.cmbDemoParser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbDemoParser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDemoParser.FormattingEnabled = true;
            this.cmbDemoParser.Location = new System.Drawing.Point(103, 34);
            this.cmbDemoParser.Name = "cmbDemoParser";
            this.cmbDemoParser.Size = new System.Drawing.Size(200, 21);
            this.cmbDemoParser.TabIndex = 2;
            this.cmbDemoParser.SelectedIndexChanged += new System.EventHandler(this.cmbDemoParser_SelectedIndexChanged);
            // 
            // boxPath
            // 
            this.boxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.boxPath.Filter = "Demo Parser (*.exe)|*.exe";
            this.boxPath.Location = new System.Drawing.Point(103, 63);
            this.boxPath.Name = "boxPath";
            this.boxPath.Path = "";
            this.boxPath.PathName = "File Path";
            this.boxPath.Size = new System.Drawing.Size(508, 30);
            this.boxPath.TabIndex = 3;
            // 
            // PrintToConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PrintToConsoleForm";
            this.Size = new System.Drawing.Size(614, 405);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDemoParser;
        private Components.BrowseControl boxPath;
    }
}
