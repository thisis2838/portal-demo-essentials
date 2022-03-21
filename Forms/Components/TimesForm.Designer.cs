
namespace portal_demo_essentials.Forms.Components
{
    partial class TimesForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panTimeHuman = new System.Windows.Forms.Panel();
            this.labTimeHuman = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panTimeTicks = new System.Windows.Forms.Panel();
            this.labTimeTicks = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panTimeHuman.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panTimeTicks.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(590, 91);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Times";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panTimeHuman);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(295, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(286, 66);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "In Human-friendly Time";
            // 
            // panTimeHuman
            // 
            this.panTimeHuman.Controls.Add(this.labTimeHuman);
            this.panTimeHuman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTimeHuman.Location = new System.Drawing.Point(3, 16);
            this.panTimeHuman.Name = "panTimeHuman";
            this.panTimeHuman.Size = new System.Drawing.Size(280, 47);
            this.panTimeHuman.TabIndex = 2;
            // 
            // labTimeHuman
            // 
            this.labTimeHuman.AutoSize = true;
            this.labTimeHuman.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTimeHuman.Location = new System.Drawing.Point(122, 0);
            this.labTimeHuman.Name = "labTimeHuman";
            this.labTimeHuman.Size = new System.Drawing.Size(45, 32);
            this.labTimeHuman.TabIndex = 1;
            this.labTimeHuman.Text = "--";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panTimeTicks);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(286, 66);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "In Ticks";
            // 
            // panTimeTicks
            // 
            this.panTimeTicks.Controls.Add(this.labTimeTicks);
            this.panTimeTicks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTimeTicks.Location = new System.Drawing.Point(3, 16);
            this.panTimeTicks.Name = "panTimeTicks";
            this.panTimeTicks.Size = new System.Drawing.Size(280, 47);
            this.panTimeTicks.TabIndex = 2;
            // 
            // labTimeTicks
            // 
            this.labTimeTicks.AutoSize = true;
            this.labTimeTicks.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTimeTicks.Location = new System.Drawing.Point(116, 0);
            this.labTimeTicks.Name = "labTimeTicks";
            this.labTimeTicks.Size = new System.Drawing.Size(45, 32);
            this.labTimeTicks.TabIndex = 1;
            this.labTimeTicks.Text = "--";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 72);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // TimesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(590, 91);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimesForm";
            this.Text = "TimesForm";
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.panTimeHuman.ResumeLayout(false);
            this.panTimeHuman.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panTimeTicks.ResumeLayout(false);
            this.panTimeTicks.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panTimeTicks;
        private System.Windows.Forms.Label labTimeTicks;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panTimeHuman;
        private System.Windows.Forms.Label labTimeHuman;
    }
}