
namespace portal_demo_essentials.Forms
{
    partial class CurrentRunForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panRuns = new System.Windows.Forms.Panel();
            this.panTimer = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panRuns);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 279);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Finished Demos";
            // 
            // panRuns
            // 
            this.panRuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRuns.Location = new System.Drawing.Point(3, 16);
            this.panRuns.Name = "panRuns";
            this.panRuns.Size = new System.Drawing.Size(587, 260);
            this.panRuns.TabIndex = 0;
            // 
            // panTimer
            // 
            this.panTimer.Location = new System.Drawing.Point(12, 297);
            this.panTimer.Name = "panTimer";
            this.panTimer.Size = new System.Drawing.Size(590, 91);
            this.panTimer.TabIndex = 5;
            // 
            // CurrentRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(617, 400);
            this.Controls.Add(this.panTimer);
            this.Controls.Add(this.groupBox1);
            this.Name = "CurrentRunForm";
            this.Text = "CurrentRunForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panRuns;
        private System.Windows.Forms.Panel panTimer;
    }
}