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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyManage));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CompanyDataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.refreshbutton = new System.Windows.Forms.Button();
            this.deletebuttom = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.okbutton = new System.Windows.Forms.Button();
            this.changebuttom = new System.Windows.Forms.Button();
            this.changetextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.CompanyDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(928, 483);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 0;
            // 
            // CompanyDataGridView
            // 
            this.CompanyDataGridView.AllowUserToAddRows = false;
            this.CompanyDataGridView.AllowUserToDeleteRows = false;
            this.CompanyDataGridView.AllowUserToResizeColumns = false;
            this.CompanyDataGridView.AllowUserToResizeRows = false;
            this.CompanyDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CompanyDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CompanyDataGridView.ColumnHeadersVisible = false;
            this.CompanyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyID,
            this.CompanyName});
            this.CompanyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.CompanyDataGridView.Location = new System.Drawing.Point(0, 0);
            this.CompanyDataGridView.Name = "CompanyDataGridView";
            this.CompanyDataGridView.ReadOnly = true;
            this.CompanyDataGridView.RowHeadersVisible = false;
            this.CompanyDataGridView.RowTemplate.Height = 23;
            this.CompanyDataGridView.Size = new System.Drawing.Size(170, 483);
            this.CompanyDataGridView.TabIndex = 5;
            // 
            // CompanyID
            // 
            this.CompanyID.HeaderText = "公司编号";
            this.CompanyID.Name = "CompanyID";
            this.CompanyID.ReadOnly = true;
            this.CompanyID.Visible = false;
            this.CompanyID.Width = 78;
            // 
            // CompanyName
            // 
            this.CompanyName.HeaderText = "公司名称";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            this.CompanyName.Width = 78;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(754, 483);
            this.splitContainer2.SplitterDistance = 445;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.refreshbutton);
            this.flowLayoutPanel1.Controls.Add(this.deletebuttom);
            this.flowLayoutPanel1.Controls.Add(this.cancelbutton);
            this.flowLayoutPanel1.Controls.Add(this.okbutton);
            this.flowLayoutPanel1.Controls.Add(this.changebuttom);
            this.flowLayoutPanel1.Controls.Add(this.changetextbox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(754, 34);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // refreshbutton
            // 
            this.refreshbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.refreshbutton.Location = new System.Drawing.Point(651, 3);
            this.refreshbutton.Name = "refreshbutton";
            this.refreshbutton.Size = new System.Drawing.Size(100, 25);
            this.refreshbutton.TabIndex = 2;
            this.refreshbutton.Text = "刷新(&R)";
            this.refreshbutton.UseVisualStyleBackColor = true;
            this.refreshbutton.Click += new System.EventHandler(this.refreshbutton_Click);
            // 
            // deletebuttom
            // 
            this.deletebuttom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deletebuttom.Location = new System.Drawing.Point(545, 3);
            this.deletebuttom.Name = "deletebuttom";
            this.deletebuttom.Size = new System.Drawing.Size(100, 25);
            this.deletebuttom.TabIndex = 1;
            this.deletebuttom.Text = "删除信息(&D)";
            this.deletebuttom.UseVisualStyleBackColor = true;
            this.deletebuttom.Click += new System.EventHandler(this.deletebuttom_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelbutton.Location = new System.Drawing.Point(439, 3);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(100, 25);
            this.cancelbutton.TabIndex = 5;
            this.cancelbutton.Text = "取消";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // okbutton
            // 
            this.okbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okbutton.Location = new System.Drawing.Point(333, 3);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(100, 25);
            this.okbutton.TabIndex = 4;
            this.okbutton.Text = "确定";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // changebuttom
            // 
            this.changebuttom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changebuttom.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.changebuttom.Location = new System.Drawing.Point(227, 3);
            this.changebuttom.Name = "changebuttom";
            this.changebuttom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.changebuttom.Size = new System.Drawing.Size(100, 25);
            this.changebuttom.TabIndex = 0;
            this.changebuttom.Text = "修改信息(&X)";
            this.changebuttom.UseVisualStyleBackColor = true;
            this.changebuttom.Click += new System.EventHandler(this.changebuttom_Click);
            // 
            // changetextbox
            // 
            this.changetextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changetextbox.Location = new System.Drawing.Point(93, 6);
            this.changetextbox.Name = "changetextbox";
            this.changetextbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.changetextbox.Size = new System.Drawing.Size(128, 19);
            this.changetextbox.TabIndex = 3;
            // 
            // CompanyManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(928, 483);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDataGridView)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView CompanyDataGridView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button refreshbutton;
        private System.Windows.Forms.Button deletebuttom;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button changebuttom;
        private System.Windows.Forms.TextBox changetextbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
    }
}