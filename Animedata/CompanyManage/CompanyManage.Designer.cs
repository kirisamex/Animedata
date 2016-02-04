namespace Main
{
    partial class CompanyManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.searchbuttom = new System.Windows.Forms.Button();
            this.refreshbutton = new System.Windows.Forms.Button();
            this.deletebuttom = new System.Windows.Forms.Button();
            this.changebuttom = new System.Windows.Forms.Button();
            this.changetextbox = new System.Windows.Forms.TextBox();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.okbutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(559, 303);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.searchbuttom);
            this.flowLayoutPanel1.Controls.Add(this.refreshbutton);
            this.flowLayoutPanel1.Controls.Add(this.deletebuttom);
            this.flowLayoutPanel1.Controls.Add(this.changebuttom);
            this.flowLayoutPanel1.Controls.Add(this.changetextbox);
            this.flowLayoutPanel1.Controls.Add(this.cancelbutton);
            this.flowLayoutPanel1.Controls.Add(this.okbutton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(177, 303);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // searchbuttom
            // 
            this.searchbuttom.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.searchbuttom.Location = new System.Drawing.Point(6, 3);
            this.searchbuttom.Name = "searchbuttom";
            this.searchbuttom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchbuttom.Size = new System.Drawing.Size(168, 23);
            this.searchbuttom.TabIndex = 1;
            this.searchbuttom.Text = "选定企业动画(&S)";
            this.searchbuttom.UseVisualStyleBackColor = true;
            this.searchbuttom.Click += new System.EventHandler(this.searchbuttom_Click);
            // 
            // refreshbutton
            // 
            this.refreshbutton.Location = new System.Drawing.Point(6, 32);
            this.refreshbutton.Name = "refreshbutton";
            this.refreshbutton.Size = new System.Drawing.Size(168, 23);
            this.refreshbutton.TabIndex = 2;
            this.refreshbutton.Text = "刷新(&R)";
            this.refreshbutton.UseVisualStyleBackColor = true;
            this.refreshbutton.Click += new System.EventHandler(this.refreshbutton_Click);
            // 
            // deletebuttom
            // 
            this.deletebuttom.Location = new System.Drawing.Point(6, 61);
            this.deletebuttom.Name = "deletebuttom";
            this.deletebuttom.Size = new System.Drawing.Size(168, 23);
            this.deletebuttom.TabIndex = 1;
            this.deletebuttom.Text = "删除选中企业(&D)";
            this.deletebuttom.UseVisualStyleBackColor = true;
            this.deletebuttom.Click += new System.EventHandler(this.deletebuttom_Click);
            // 
            // changebuttom
            // 
            this.changebuttom.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.changebuttom.Location = new System.Drawing.Point(6, 90);
            this.changebuttom.Name = "changebuttom";
            this.changebuttom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.changebuttom.Size = new System.Drawing.Size(168, 23);
            this.changebuttom.TabIndex = 0;
            this.changebuttom.Text = "修改企业名称(&C)";
            this.changebuttom.UseVisualStyleBackColor = true;
            this.changebuttom.Click += new System.EventHandler(this.changebuttom_Click);
            // 
            // changetextbox
            // 
            this.changetextbox.Location = new System.Drawing.Point(8, 119);
            this.changetextbox.Name = "changetextbox";
            this.changetextbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.changetextbox.Size = new System.Drawing.Size(166, 19);
            this.changetextbox.TabIndex = 3;
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(94, 144);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(80, 23);
            this.cancelbutton.TabIndex = 5;
            this.cancelbutton.Text = "取消";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(8, 144);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(80, 23);
            this.okbutton.TabIndex = 4;
            this.okbutton.Text = "确定";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(378, 303);
            this.dataGridView1.TabIndex = 0;
            // 
            // CompanyManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(559, 303);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyManage";
            this.Text = "动画制作企业";
            this.Load += new System.EventHandler(this.company_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.company_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button changebuttom;
        private System.Windows.Forms.Button searchbuttom;
        private System.Windows.Forms.Button deletebuttom;
        private System.Windows.Forms.Button refreshbutton;
        private System.Windows.Forms.TextBox changetextbox;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button cancelbutton;
    }
}