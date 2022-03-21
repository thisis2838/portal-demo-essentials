
namespace portal_demo_essentials.Forms.Components
{
    partial class DemoDisplayForm
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
            this.labDemoName = new System.Windows.Forms.Label();
            this.panTimer = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labDemoName);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // labDemoName
            // 
            this.labDemoName.AutoSize = true;
            this.labDemoName.Location = new System.Drawing.Point(7, 20);
            this.labDemoName.Name = "labDemoName";
            this.labDemoName.Size = new System.Drawing.Size(13, 13);
            this.labDemoName.TabIndex = 0;
            this.labDemoName.Text = "--";
            // 
            // panTimer
            // 
            this.panTimer.Location = new System.Drawing.Point(6, 54);
            this.panTimer.Name = "panTimer";
            this.panTimer.Size = new System.Drawing.Size(575, 100);
            this.panTimer.TabIndex = 1;
            // 
            // DemoDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(593, 162);
            this.Controls.Add(this.panTimer);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DemoDisplayForm";
            this.Text = "DemoMainDisplay";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labDemoName;
        private System.Windows.Forms.Panel panTimer;
    }
}