
namespace portal_demo_essentials.Forms
{
    partial class SettingAboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingAboutForm));
            this.gSettings = new System.Windows.Forms.GroupBox();
            this.tabSettings = new System.Windows.Forms.TableLayoutPanel();
            this.boxMapOrderFile = new portal_demo_essentials.Forms.Components.BrowseControl();
            this.chkZerothTick = new System.Windows.Forms.CheckBox();
            this.gAbout = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labVer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gSettings.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.gAbout.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gSettings
            // 
            this.gSettings.Controls.Add(this.tabSettings);
            this.gSettings.Location = new System.Drawing.Point(12, 12);
            this.gSettings.Name = "gSettings";
            this.gSettings.Size = new System.Drawing.Size(610, 261);
            this.gSettings.TabIndex = 0;
            this.gSettings.TabStop = false;
            this.gSettings.Text = "Settings";
            // 
            // tabSettings
            // 
            this.tabSettings.ColumnCount = 1;
            this.tabSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabSettings.Controls.Add(this.boxMapOrderFile, 0, 1);
            this.tabSettings.Controls.Add(this.chkZerothTick, 0, 0);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Location = new System.Drawing.Point(3, 16);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.RowCount = 3;
            this.tabSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabSettings.Size = new System.Drawing.Size(604, 242);
            this.tabSettings.TabIndex = 0;
            // 
            // boxMapOrderFile
            // 
            this.boxMapOrderFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.boxMapOrderFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.boxMapOrderFile.Filter = null;
            this.boxMapOrderFile.Location = new System.Drawing.Point(3, 30);
            this.boxMapOrderFile.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.boxMapOrderFile.Name = "boxMapOrderFile";
            this.boxMapOrderFile.Path = "";
            this.boxMapOrderFile.PathName = "Map Order File";
            this.boxMapOrderFile.Size = new System.Drawing.Size(500, 30);
            this.boxMapOrderFile.TabIndex = 0;
            // 
            // chkZerothTick
            // 
            this.chkZerothTick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkZerothTick.AutoSize = true;
            this.chkZerothTick.Checked = true;
            this.chkZerothTick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkZerothTick.Location = new System.Drawing.Point(3, 6);
            this.chkZerothTick.Name = "chkZerothTick";
            this.chkZerothTick.Size = new System.Drawing.Size(112, 17);
            this.chkZerothTick.TabIndex = 1;
            this.chkZerothTick.Text = "Count Zeroth Tick";
            this.chkZerothTick.UseVisualStyleBackColor = true;
            // 
            // gAbout
            // 
            this.gAbout.Controls.Add(this.label8);
            this.gAbout.Controls.Add(this.groupBox1);
            this.gAbout.Controls.Add(this.labVer);
            this.gAbout.Controls.Add(this.label1);
            this.gAbout.Controls.Add(this.pictureBox1);
            this.gAbout.Location = new System.Drawing.Point(12, 279);
            this.gAbout.Name = "gAbout";
            this.gAbout.Size = new System.Drawing.Size(610, 152);
            this.gAbout.TabIndex = 1;
            this.gAbout.TabStop = false;
            this.gAbout.Text = "About";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(223, 26);
            this.label8.TabIndex = 4;
            this.label8.Text = "A tool for all your essential Portal demo needs.\r\nCreated in March 2022";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(334, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 127);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credits";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 108);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Special Thanks";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "alatreph, xeonic";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "2838";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Creator";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Testers";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 39);
            this.label7.TabIndex = 5;
            this.label7.Text = "Livesplit Team for Livesplit.Core\r\nUncraftedName for UntitledParser\r\nFatalis for " +
    "Portal Demo Timer";
            // 
            // labVer
            // 
            this.labVer.AutoSize = true;
            this.labVer.Location = new System.Drawing.Point(66, 56);
            this.labVer.Name = "labVer";
            this.labVer.Size = new System.Drawing.Size(44, 13);
            this.labVer.TabIndex = 2;
            this.labVer.Text = "version:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Portal Demo Essentials";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SettingAboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.gAbout);
            this.Controls.Add(this.gSettings);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "SettingAboutForm";
            this.Size = new System.Drawing.Size(634, 443);
            this.gSettings.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.gAbout.ResumeLayout(false);
            this.gAbout.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gSettings;
        private System.Windows.Forms.TableLayoutPanel tabSettings;
        private System.Windows.Forms.GroupBox gAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labVer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private Components.BrowseControl boxMapOrderFile;
        private System.Windows.Forms.CheckBox chkZerothTick;
    }
}