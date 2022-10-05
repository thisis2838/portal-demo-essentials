
namespace portal_demo_essentials.Forms.Components
{
    partial class RunListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDemos = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvMaps = new System.Windows.Forms.DataGridView();
            this.colDemoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTicks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDemos
            // 
            this.dgvDemos.AllowUserToAddRows = false;
            this.dgvDemos.AllowUserToDeleteRows = false;
            this.dgvDemos.AllowUserToResizeColumns = false;
            this.dgvDemos.AllowUserToResizeRows = false;
            this.dgvDemos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDemos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDemoName,
            this.colMaps,
            this.colTicks,
            this.colTime});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDemos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDemos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDemos.Location = new System.Drawing.Point(3, 3);
            this.dgvDemos.Name = "dgvDemos";
            this.dgvDemos.ReadOnly = true;
            this.dgvDemos.RowHeadersVisible = false;
            this.dgvDemos.Size = new System.Drawing.Size(590, 154);
            this.dgvDemos.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 186);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDemos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 160);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Demos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvMaps);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 160);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Maps";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvMaps
            // 
            this.dgvMaps.AllowUserToAddRows = false;
            this.dgvMaps.AllowUserToDeleteRows = false;
            this.dgvMaps.AllowUserToResizeColumns = false;
            this.dgvMaps.AllowUserToResizeRows = false;
            this.dgvMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaps.Location = new System.Drawing.Point(3, 3);
            this.dgvMaps.Name = "dgvMaps";
            this.dgvMaps.ReadOnly = true;
            this.dgvMaps.RowHeadersVisible = false;
            this.dgvMaps.Size = new System.Drawing.Size(590, 154);
            this.dgvMaps.TabIndex = 1;
            // 
            // colDemoName
            // 
            this.colDemoName.HeaderText = "Name";
            this.colDemoName.MinimumWidth = 200;
            this.colDemoName.Name = "colDemoName";
            this.colDemoName.ReadOnly = true;
            this.colDemoName.Width = 200;
            // 
            // colMaps
            // 
            this.colMaps.HeaderText = "Map";
            this.colMaps.Name = "colMaps";
            this.colMaps.ReadOnly = true;
            // 
            // colTicks
            // 
            this.colTicks.HeaderText = "Ticks";
            this.colTicks.Name = "colTicks";
            this.colTicks.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Ticks";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Time";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // RunListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(604, 186);
            this.Controls.Add(this.tabControl1);
            this.Name = "RunListForm";
            this.Text = "RunListForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDemos;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvMaps;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDemoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaps;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTicks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}