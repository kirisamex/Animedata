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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyManage));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CompanyDataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.companyHistDataGridView = new System.Windows.Forms.DataGridView();
            this.AnimeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeCNName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayinfoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Playinfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.refreshbutton = new System.Windows.Forms.Button();
            this.deletebuttom = new System.Windows.Forms.Button();
            this.okbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.changebuttom = new System.Windows.Forms.Button();
            this.searchtextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.companyHistDataGridView)).BeginInit();
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
            this.CompanyDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.CompanyDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.CompanyDataGridView.Location = new System.Drawing.Point(0, 0);
            this.CompanyDataGridView.Name = "CompanyDataGridView";
            this.CompanyDataGridView.ReadOnly = true;
            this.CompanyDataGridView.RowHeadersVisible = false;
            this.CompanyDataGridView.RowTemplate.Height = 23;
            this.CompanyDataGridView.Size = new System.Drawing.Size(170, 483);
            this.CompanyDataGridView.TabIndex = 1;
            this.CompanyDataGridView.CurrentCellChanged += new System.EventHandler(this.CompanyDataGridView_CurrentCellChanged);
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
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.companyHistDataGridView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(754, 483);
            this.splitContainer2.SplitterDistance = 445;
            this.splitContainer2.TabIndex = 0;
            // 
            // companyHistDataGridView
            // 
            this.companyHistDataGridView.AllowUserToAddRows = false;
            this.companyHistDataGridView.AllowUserToDeleteRows = false;
            this.companyHistDataGridView.AllowUserToResizeColumns = false;
            this.companyHistDataGridView.AllowUserToResizeRows = false;
            this.companyHistDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.companyHistDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.companyHistDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.companyHistDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companyHistDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnimeNo,
            this.AnimeCNName,
            this.PlayinfoID,
            this.Playinfo,
            this.Status,
            this.Parts,
            this.StartTime});
            this.companyHistDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.companyHistDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.companyHistDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.companyHistDataGridView.Location = new System.Drawing.Point(0, 0);
            this.companyHistDataGridView.Name = "companyHistDataGridView";
            this.companyHistDataGridView.ReadOnly = true;
            this.companyHistDataGridView.RowHeadersVisible = false;
            this.companyHistDataGridView.RowTemplate.Height = 23;
            this.companyHistDataGridView.Size = new System.Drawing.Size(754, 445);
            this.companyHistDataGridView.TabIndex = 11;
            this.companyHistDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.companyHistDataGridView_CellContentDoubleClick);
            // 
            // AnimeNo
            // 
            this.AnimeNo.HeaderText = "动画编号";
            this.AnimeNo.Name = "AnimeNo";
            this.AnimeNo.ReadOnly = true;
            // 
            // AnimeCNName
            // 
            this.AnimeCNName.HeaderText = "动画名称";
            this.AnimeCNName.Name = "AnimeCNName";
            this.AnimeCNName.ReadOnly = true;
            // 
            // PlayinfoID
            // 
            this.PlayinfoID.HeaderText = "内容编号";
            this.PlayinfoID.Name = "PlayinfoID";
            this.PlayinfoID.ReadOnly = true;
            this.PlayinfoID.Visible = false;
            // 
            // Playinfo
            // 
            this.Playinfo.HeaderText = "内容";
            this.Playinfo.Name = "Playinfo";
            this.Playinfo.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Parts
            // 
            this.Parts.HeaderText = "话数";
            this.Parts.Name = "Parts";
            this.Parts.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "播放时间";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.refreshbutton);
            this.flowLayoutPanel1.Controls.Add(this.deletebuttom);
            this.flowLayoutPanel1.Controls.Add(this.okbutton);
            this.flowLayoutPanel1.Controls.Add(this.cancelbutton);
            this.flowLayoutPanel1.Controls.Add(this.changebuttom);
            this.flowLayoutPanel1.Controls.Add(this.searchtextbox);
            this.flowLayoutPanel1.Controls.Add(this.label1);
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
            this.refreshbutton.TabIndex = 27;
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
            this.deletebuttom.TabIndex = 26;
            this.deletebuttom.Text = "删除信息(&D)";
            this.deletebuttom.UseVisualStyleBackColor = true;
            this.deletebuttom.Click += new System.EventHandler(this.deletebuttom_Click);
            // 
            // okbutton
            // 
            this.okbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okbutton.Location = new System.Drawing.Point(439, 3);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(100, 25);
            this.okbutton.TabIndex = 25;
            this.okbutton.Text = "确定(&E)";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Visible = false;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelbutton.Location = new System.Drawing.Point(333, 3);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(100, 25);
            this.cancelbutton.TabIndex = 24;
            this.cancelbutton.Text = "取消(&Q)";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Visible = false;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // changebuttom
            // 
            this.changebuttom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changebuttom.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.changebuttom.Location = new System.Drawing.Point(227, 3);
            this.changebuttom.Name = "changebuttom";
            this.changebuttom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.changebuttom.Size = new System.Drawing.Size(100, 25);
            this.changebuttom.TabIndex = 23;
            this.changebuttom.Text = "修改信息(&X)";
            this.changebuttom.UseVisualStyleBackColor = true;
            this.changebuttom.Click += new System.EventHandler(this.changebuttom_Click);
            // 
            // searchtextbox
            // 
            this.searchtextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchtextbox.Location = new System.Drawing.Point(93, 6);
            this.searchtextbox.Name = "searchtextbox";
            this.searchtextbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.searchtextbox.Size = new System.Drawing.Size(128, 19);
            this.searchtextbox.TabIndex = 22;
            this.searchtextbox.Click += new System.EventHandler(this.searchtextbox_Click);
            this.searchtextbox.TextChanged += new System.EventHandler(this.searchtextbox_TextChanged);
            this.searchtextbox.Enter += new System.EventHandler(this.searchtextbox_Enter);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "搜索(&Z)";
            // 
            // CompanyManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(928, 483);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
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
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.companyHistDataGridView)).EndInit();
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
        private System.Windows.Forms.TextBox searchtextbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView companyHistDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeCNName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayinfoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Playinfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parts;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
    }
}