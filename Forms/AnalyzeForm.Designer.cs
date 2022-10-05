
namespace portal_demo_essentials.Forms
{
    partial class AnalyzeForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.labPlayerName = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.labMapName = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.labFilePath = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panLists = new System.Windows.Forms.Panel();
            this.butOpen = new System.Windows.Forms.Button();
            this.panTimer = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panTimer);
            this.groupBox3.Controls.Add(this.groupBox9);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Location = new System.Drawing.Point(12, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(610, 208);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.labPlayerName);
            this.groupBox9.Location = new System.Drawing.Point(308, 65);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(296, 40);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Player Name";
            // 
            // labPlayerName
            // 
            this.labPlayerName.AutoSize = true;
            this.labPlayerName.Location = new System.Drawing.Point(6, 16);
            this.labPlayerName.Name = "labPlayerName";
            this.labPlayerName.Size = new System.Drawing.Size(13, 13);
            this.labPlayerName.TabIndex = 1;
            this.labPlayerName.Text = "--";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.labMapName);
            this.groupBox8.Location = new System.Drawing.Point(7, 65);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(296, 40);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Map Name";
            // 
            // labMapName
            // 
            this.labMapName.AutoSize = true;
            this.labMapName.Location = new System.Drawing.Point(6, 16);
            this.labMapName.Name = "labMapName";
            this.labMapName.Size = new System.Drawing.Size(13, 13);
            this.labMapName.TabIndex = 0;
            this.labMapName.Text = "--";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.labFilePath);
            this.groupBox7.Location = new System.Drawing.Point(7, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(597, 40);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "File Path";
            // 
            // labFilePath
            // 
            this.labFilePath.AutoSize = true;
            this.labFilePath.Location = new System.Drawing.Point(6, 16);
            this.labFilePath.Name = "labFilePath";
            this.labFilePath.Size = new System.Drawing.Size(13, 13);
            this.labFilePath.TabIndex = 1;
            this.labFilePath.Text = "--";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butOpen);
            this.groupBox1.Controls.Add(this.panLists);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 205);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files";
            // 
            // panLists
            // 
            this.panLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLists.Location = new System.Drawing.Point(3, 16);
            this.panLists.Name = "panLists";
            this.panLists.Size = new System.Drawing.Size(604, 186);
            this.panLists.TabIndex = 0;
            // 
            // butOpen
            // 
            this.butOpen.Location = new System.Drawing.Point(531, 11);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(75, 23);
            this.butOpen.TabIndex = 1;
            this.butOpen.Text = "Open Files";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // panTimer
            // 
            this.panTimer.Location = new System.Drawing.Point(6, 111);
            this.panTimer.Name = "panTimer";
            this.panTimer.Size = new System.Drawing.Size(598, 91);
            this.panTimer.TabIndex = 4;
            // 
            // AnalyzeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(634, 443);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "AnalyzeForm";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label labPlayerName;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label labMapName;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label labFilePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panLists;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Panel panTimer;
    }
}