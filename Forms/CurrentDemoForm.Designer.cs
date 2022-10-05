
namespace portal_demo_essentials.Forms
{
    partial class CurrentDemoForm
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
            this.gCurDemo = new System.Windows.Forms.GroupBox();
            this.gPrevDemo = new System.Windows.Forms.GroupBox();
            this.panDeny = new System.Windows.Forms.Panel();
            this.labDeny = new System.Windows.Forms.Label();
            this.panDeny.SuspendLayout();
            this.SuspendLayout();
            // 
            // gCurDemo
            // 
            this.gCurDemo.Location = new System.Drawing.Point(12, 12);
            this.gCurDemo.Name = "gCurDemo";
            this.gCurDemo.Size = new System.Drawing.Size(593, 182);
            this.gCurDemo.TabIndex = 0;
            this.gCurDemo.TabStop = false;
            this.gCurDemo.Text = "Current Demo";
            // 
            // gPrevDemo
            // 
            this.gPrevDemo.Location = new System.Drawing.Point(12, 206);
            this.gPrevDemo.Name = "gPrevDemo";
            this.gPrevDemo.Size = new System.Drawing.Size(593, 182);
            this.gPrevDemo.TabIndex = 1;
            this.gPrevDemo.TabStop = false;
            this.gPrevDemo.Text = "Previous Demo";
            // 
            // panDeny
            // 
            this.panDeny.Controls.Add(this.labDeny);
            this.panDeny.Location = new System.Drawing.Point(18, 31);
            this.panDeny.Name = "panDeny";
            this.panDeny.Size = new System.Drawing.Size(581, 157);
            this.panDeny.TabIndex = 2;
            // 
            // labDeny
            // 
            this.labDeny.AutoSize = true;
            this.labDeny.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labDeny.Location = new System.Drawing.Point(125, 66);
            this.labDeny.Name = "labDeny";
            this.labDeny.Size = new System.Drawing.Size(323, 25);
            this.labDeny.TabIndex = 0;
            this.labDeny.Text = "You must run Portal first to continue!";
            // 
            // CurrentDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(617, 400);
            this.Controls.Add(this.panDeny);
            this.Controls.Add(this.gCurDemo);
            this.Controls.Add(this.gPrevDemo);
            this.Name = "CurrentDemoForm";
            this.Text = "Form1";
            this.panDeny.ResumeLayout(false);
            this.panDeny.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gCurDemo;
        private System.Windows.Forms.GroupBox gPrevDemo;
        private System.Windows.Forms.Panel panDeny;
        private System.Windows.Forms.Label labDeny;
    }
}