namespace Client.MainForm.Gui
{
    partial class AddAnime
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statescbox = new System.Windows.Forms.ComboBox();
            this.nnbox = new System.Windows.Forms.TextBox();
            this.cnnamebox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.originalbox = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.basicinfotab = new System.Windows.Forms.TabPage();
            this.jpnamebox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.playinfotab = new System.Windows.Forms.TabPage();
            this.companybox = new System.Windows.Forms.ComboBox();
            this.PlayInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.charainfotab = new System.Windows.Forms.TabPage();
            this.CVbox = new System.Windows.Forms.ComboBox();
            this.CharacterInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.RemoveRowButton = new System.Windows.Forms.Button();
            this.playinfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playcounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.playstarttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.watchtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayinfoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charactername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seiyuuname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ismaincharacter = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.characterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.basicinfotab.SuspendLayout();
            this.playinfotab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayInfoDataGridView)).BeginInit();
            this.charainfotab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterInfoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // statescbox
            // 
            this.statescbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statescbox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statescbox.FormattingEnabled = true;
            this.statescbox.Items.AddRange(new object[] {
            "放送中",
            "完结",
            "新企划",
            "弃置"});
            this.statescbox.Location = new System.Drawing.Point(130, 175);
            this.statescbox.Name = "statescbox";
            this.statescbox.Size = new System.Drawing.Size(112, 23);
            this.statescbox.TabIndex = 15;
            // 
            // nnbox
            // 
            this.nnbox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nnbox.Location = new System.Drawing.Point(130, 135);
            this.nnbox.MaxLength = 4;
            this.nnbox.Name = "nnbox";
            this.nnbox.Size = new System.Drawing.Size(112, 22);
            this.nnbox.TabIndex = 14;
            // 
            // cnnamebox
            // 
            this.cnnamebox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cnnamebox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cnnamebox.Location = new System.Drawing.Point(130, 55);
            this.cnnamebox.MaxLength = 255;
            this.cnnamebox.Name = "cnnamebox";
            this.cnnamebox.Size = new System.Drawing.Size(151, 22);
            this.cnnamebox.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(237, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 42;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(114, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 41;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(29, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "放送状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(29, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "动画简写";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(29, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "中文名称";
            // 
            // numbox
            // 
            this.numbox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numbox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.numbox.Location = new System.Drawing.Point(130, 15);
            this.numbox.MaxLength = 4;
            this.numbox.Name = "numbox";
            this.numbox.Size = new System.Drawing.Size(112, 22);
            this.numbox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(29, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "动画编号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(29, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "原作";
            // 
            // originalbox
            // 
            this.originalbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originalbox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.originalbox.Items.AddRange(new object[] {
            "漫画",
            "小说",
            "游戏",
            "影视",
            "原创",
            "其他"});
            this.originalbox.Location = new System.Drawing.Point(130, 215);
            this.originalbox.Name = "originalbox";
            this.originalbox.Size = new System.Drawing.Size(151, 23);
            this.originalbox.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.basicinfotab);
            this.tabControl1.Controls.Add(this.playinfotab);
            this.tabControl1.Controls.Add(this.charainfotab);
            this.tabControl1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 296);
            this.tabControl1.TabIndex = 31;
            // 
            // basicinfotab
            // 
            this.basicinfotab.Controls.Add(this.jpnamebox);
            this.basicinfotab.Controls.Add(this.cnnamebox);
            this.basicinfotab.Controls.Add(this.originalbox);
            this.basicinfotab.Controls.Add(this.label6);
            this.basicinfotab.Controls.Add(this.label1);
            this.basicinfotab.Controls.Add(this.label5);
            this.basicinfotab.Controls.Add(this.label2);
            this.basicinfotab.Controls.Add(this.label3);
            this.basicinfotab.Controls.Add(this.numbox);
            this.basicinfotab.Controls.Add(this.nnbox);
            this.basicinfotab.Controls.Add(this.label4);
            this.basicinfotab.Controls.Add(this.statescbox);
            this.basicinfotab.Location = new System.Drawing.Point(4, 25);
            this.basicinfotab.Name = "basicinfotab";
            this.basicinfotab.Padding = new System.Windows.Forms.Padding(3);
            this.basicinfotab.Size = new System.Drawing.Size(782, 267);
            this.basicinfotab.TabIndex = 0;
            this.basicinfotab.Text = "基本信息";
            this.basicinfotab.UseVisualStyleBackColor = true;
            // 
            // jpnamebox
            // 
            this.jpnamebox.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.jpnamebox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.jpnamebox.Location = new System.Drawing.Point(130, 95);
            this.jpnamebox.MaxLength = 255;
            this.jpnamebox.Name = "jpnamebox";
            this.jpnamebox.Size = new System.Drawing.Size(151, 22);
            this.jpnamebox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(29, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "日文名称";
            // 
            // playinfotab
            // 
            this.playinfotab.Controls.Add(this.companybox);
            this.playinfotab.Controls.Add(this.PlayInfoDataGridView);
            this.playinfotab.Location = new System.Drawing.Point(4, 25);
            this.playinfotab.Name = "playinfotab";
            this.playinfotab.Padding = new System.Windows.Forms.Padding(3);
            this.playinfotab.Size = new System.Drawing.Size(782, 267);
            this.playinfotab.TabIndex = 1;
            this.playinfotab.Text = "放送信息";
            this.playinfotab.UseVisualStyleBackColor = true;
            // 
            // companybox
            // 
            this.companybox.FormattingEnabled = true;
            this.companybox.Location = new System.Drawing.Point(254, 23);
            this.companybox.Name = "companybox";
            this.companybox.Size = new System.Drawing.Size(105, 23);
            this.companybox.TabIndex = 21;
            this.companybox.Visible = false;
            this.companybox.Leave += new System.EventHandler(this.companybox_Leave);
            // 
            // PlayInfoDataGridView
            // 
            this.PlayInfoDataGridView.AllowUserToAddRows = false;
            this.PlayInfoDataGridView.AllowUserToResizeRows = false;
            this.PlayInfoDataGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PlayInfoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.PlayInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playinfo,
            this.playcounts,
            this.company,
            this.status,
            this.playstarttime,
            this.watchtime,
            this.PlayinfoID});
            this.PlayInfoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayInfoDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.PlayInfoDataGridView.Location = new System.Drawing.Point(3, 3);
            this.PlayInfoDataGridView.Name = "PlayInfoDataGridView";
            this.PlayInfoDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.PlayInfoDataGridView.RowTemplate.Height = 23;
            this.PlayInfoDataGridView.Size = new System.Drawing.Size(776, 261);
            this.PlayInfoDataGridView.TabIndex = 21;
            this.PlayInfoDataGridView.CurrentCellChanged += new System.EventHandler(this.PlayInfoDataGridView_CurrentCellChanged);
            // 
            // charainfotab
            // 
            this.charainfotab.Controls.Add(this.CVbox);
            this.charainfotab.Controls.Add(this.CharacterInfoDataGridView);
            this.charainfotab.Location = new System.Drawing.Point(4, 25);
            this.charainfotab.Name = "charainfotab";
            this.charainfotab.Padding = new System.Windows.Forms.Padding(3);
            this.charainfotab.Size = new System.Drawing.Size(782, 267);
            this.charainfotab.TabIndex = 2;
            this.charainfotab.Text = "角色信息";
            this.charainfotab.UseVisualStyleBackColor = true;
            // 
            // CVbox
            // 
            this.CVbox.FormattingEnabled = true;
            this.CVbox.Location = new System.Drawing.Point(258, 25);
            this.CVbox.Name = "CVbox";
            this.CVbox.Size = new System.Drawing.Size(204, 23);
            this.CVbox.TabIndex = 31;
            this.CVbox.Visible = false;
            this.CVbox.Leave += new System.EventHandler(this.seiyuubox_Leave);
            // 
            // CharacterInfoDataGridView
            // 
            this.CharacterInfoDataGridView.AllowUserToAddRows = false;
            this.CharacterInfoDataGridView.AllowUserToResizeRows = false;
            this.CharacterInfoDataGridView.BackgroundColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CharacterInfoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CharacterInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.charactername,
            this.seiyuuname,
            this.ismaincharacter,
            this.characterNo});
            this.CharacterInfoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharacterInfoDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.CharacterInfoDataGridView.Location = new System.Drawing.Point(3, 3);
            this.CharacterInfoDataGridView.MultiSelect = false;
            this.CharacterInfoDataGridView.Name = "CharacterInfoDataGridView";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CharacterInfoDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.CharacterInfoDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.CharacterInfoDataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CharacterInfoDataGridView.RowTemplate.Height = 23;
            this.CharacterInfoDataGridView.Size = new System.Drawing.Size(776, 261);
            this.CharacterInfoDataGridView.TabIndex = 31;
            this.CharacterInfoDataGridView.CurrentCellChanged += new System.EventHandler(this.CharacterInfoDataGridView_CurrentCellChanged);
            this.CharacterInfoDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CharacterInfoDataGridView_KeyDown);
            // 
            // AddRowButton
            // 
            this.AddRowButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AddRowButton.Location = new System.Drawing.Point(384, 314);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(20, 25);
            this.AddRowButton.TabIndex = 43;
            this.AddRowButton.Text = "＋";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // RemoveRowButton
            // 
            this.RemoveRowButton.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RemoveRowButton.Location = new System.Drawing.Point(410, 314);
            this.RemoveRowButton.Name = "RemoveRowButton";
            this.RemoveRowButton.Size = new System.Drawing.Size(20, 25);
            this.RemoveRowButton.TabIndex = 44;
            this.RemoveRowButton.Text = "－";
            this.RemoveRowButton.UseVisualStyleBackColor = true;
            this.RemoveRowButton.Click += new System.EventHandler(this.RemoveRowButton_Click);
            // 
            // playinfo
            // 
            this.playinfo.FillWeight = 24.74438F;
            this.playinfo.HeaderText = "放送内容";
            this.playinfo.Name = "playinfo";
            this.playinfo.Width = 150;
            // 
            // playcounts
            // 
            this.playcounts.FillWeight = 18.6631F;
            this.playcounts.HeaderText = "话数";
            this.playcounts.Name = "playcounts";
            this.playcounts.Width = 50;
            // 
            // company
            // 
            this.company.FillWeight = 523.8579F;
            this.company.HeaderText = "制作公司";
            this.company.Name = "company";
            this.company.Width = 250;
            // 
            // status
            // 
            this.status.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.status.FillWeight = 10.10737F;
            this.status.HeaderText = "状态";
            this.status.Items.AddRange(new object[] {
            "放送中",
            "完结",
            "新企划",
            "弃置"});
            this.status.Name = "status";
            this.status.Width = 80;
            // 
            // playstarttime
            // 
            this.playstarttime.FillWeight = 10.86612F;
            this.playstarttime.HeaderText = "放送时间";
            this.playstarttime.Name = "playstarttime";
            // 
            // watchtime
            // 
            this.watchtime.FillWeight = 11.76117F;
            this.watchtime.HeaderText = "收看时间";
            this.watchtime.Name = "watchtime";
            // 
            // PlayinfoID
            // 
            this.PlayinfoID.HeaderText = "PLAYINFO_ID";
            this.PlayinfoID.Name = "PlayinfoID";
            this.PlayinfoID.Visible = false;
            this.PlayinfoID.Width = 119;
            // 
            // charactername
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.charactername.DefaultCellStyle = dataGridViewCellStyle3;
            this.charactername.FillWeight = 152.2843F;
            this.charactername.HeaderText = "角色";
            this.charactername.Name = "charactername";
            this.charactername.Width = 200;
            // 
            // seiyuuname
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.seiyuuname.DefaultCellStyle = dataGridViewCellStyle4;
            this.seiyuuname.FillWeight = 73.85786F;
            this.seiyuuname.HeaderText = "声优";
            this.seiyuuname.Name = "seiyuuname";
            this.seiyuuname.Width = 150;
            // 
            // ismaincharacter
            // 
            this.ismaincharacter.FillWeight = 73.85786F;
            this.ismaincharacter.HeaderText = "主角";
            this.ismaincharacter.Name = "ismaincharacter";
            this.ismaincharacter.Width = 50;
            // 
            // characterNo
            // 
            this.characterNo.HeaderText = "CHARACTER_NO";
            this.characterNo.Name = "characterNo";
            this.characterNo.Visible = false;
            // 
            // AddAnime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 347);
            this.Controls.Add(this.RemoveRowButton);
            this.Controls.Add(this.AddRowButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAnime";
            this.ShowIcon = false;
            this.Text = "添加动画";
            this.Load += new System.EventHandler(this.AddAnime_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddAnime_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.basicinfotab.ResumeLayout(false);
            this.basicinfotab.PerformLayout();
            this.playinfotab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlayInfoDataGridView)).EndInit();
            this.charainfotab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CharacterInfoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox statescbox;
        private System.Windows.Forms.TextBox nnbox;
        private System.Windows.Forms.TextBox cnnamebox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox originalbox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage basicinfotab;
        private System.Windows.Forms.TabPage playinfotab;
        private System.Windows.Forms.TabPage charainfotab;
        private System.Windows.Forms.DataGridView PlayInfoDataGridView;
        private System.Windows.Forms.DataGridView CharacterInfoDataGridView;
        private System.Windows.Forms.ComboBox CVbox;
        private System.Windows.Forms.ComboBox companybox;
        private System.Windows.Forms.TextBox jpnamebox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button AddRowButton;
        private System.Windows.Forms.Button RemoveRowButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn playinfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn playcounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn company;
        private System.Windows.Forms.DataGridViewComboBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn playstarttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn watchtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayinfoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn charactername;
        private System.Windows.Forms.DataGridViewTextBoxColumn seiyuuname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ismaincharacter;
        private System.Windows.Forms.DataGridViewTextBoxColumn characterNo;
    }
}