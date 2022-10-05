
namespace portal_demo_essentials.Forms.Components
{
    partial class MinimalTimesForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labTimeTicks = new System.Windows.Forms.Label();
            this.panTimeTicks = new System.Windows.Forms.Panel();
            this.labTimeHuman = new System.Windows.Forms.Label();
            this.panTimeHuman = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panTimeTicks.SuspendLayout();
            this.panTimeHuman.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panTimeHuman, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panTimeTicks, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labTimeTicks
            // 
            this.labTimeTicks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labTimeTicks.AutoSize = true;
            this.labTimeTicks.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTimeTicks.Location = new System.Drawing.Point(9, 6);
            this.labTimeTicks.Name = "labTimeTicks";
            this.labTimeTicks.Size = new System.Drawing.Size(45, 32);
            this.labTimeTicks.TabIndex = 2;
            this.labTimeTicks.Text = "--";
            // 
            // panTimeTicks
            // 
            this.panTimeTicks.Controls.Add(this.labTimeTicks);
            this.panTimeTicks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTimeTicks.Location = new System.Drawing.Point(3, 3);
            this.panTimeTicks.Name = "panTimeTicks";
            this.panTimeTicks.Size = new System.Drawing.Size(194, 44);
            this.panTimeTicks.TabIndex = 3;
            // 
            // labTimeHuman
            // 
            this.labTimeHuman.AutoSize = true;
            this.labTimeHuman.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTimeHuman.Location = new System.Drawing.Point(62, 6);
            this.labTimeHuman.Name = "labTimeHuman";
            this.labTimeHuman.Size = new System.Drawing.Size(45, 32);
            this.labTimeHuman.TabIndex = 1;
            this.labTimeHuman.Text = "--";
            // 
            // panTimeHuman
            // 
            this.panTimeHuman.Controls.Add(this.labTimeHuman);
            this.panTimeHuman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTimeHuman.Location = new System.Drawing.Point(203, 3);
            this.panTimeHuman.Name = "panTimeHuman";
            this.panTimeHuman.Size = new System.Drawing.Size(194, 44);
            this.panTimeHuman.TabIndex = 4;
            // 
            // MinimalTimesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(400, 50);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MinimalTimesForm";
            this.Text = "MinimalTimesForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panTimeTicks.ResumeLayout(false);
            this.panTimeTicks.PerformLayout();
            this.panTimeHuman.ResumeLayout(false);
            this.panTimeHuman.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labTimeTicks;
        private System.Windows.Forms.Panel panTimeTicks;
        private System.Windows.Forms.Panel panTimeHuman;
        private System.Windows.Forms.Label labTimeHuman;
    }
}