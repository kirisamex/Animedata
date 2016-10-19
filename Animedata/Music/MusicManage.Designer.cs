namespace Main.Music
{
    partial class MusicManage
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.基本操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存标签信息TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存曲目信息MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存全部ACtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.查询EF6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.关闭CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入曲目IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从MP3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入新下载的MP3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入既有的MP3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标签操作TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从MP3ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.从曲目信息保存至MPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.saveID3TagButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DiscNoTextBox = new System.Windows.Forms.TextBox();
            this.TrackNoTextBox = new System.Windows.Forms.TextBox();
            this.AlbumNameTextBox = new System.Windows.Forms.TextBox();
            this.ArtistTextBox = new System.Windows.Forms.TextBox();
            this.TrackNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vocalortypelabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AlbumPictureBox = new System.Windows.Forms.PictureBox();
            this.MusicDataGridView = new System.Windows.Forms.DataGridView();
            this.OldTrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumType = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TrackID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackType = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ArtistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackTimeLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResourcePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtistID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isModified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本操作ToolStripMenuItem,
            this.导入曲目IToolStripMenuItem,
            this.标签操作TToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1350, 26);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 基本操作ToolStripMenuItem
            // 
            this.基本操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.查询EF6ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.关闭CToolStripMenuItem});
            this.基本操作ToolStripMenuItem.Name = "基本操作ToolStripMenuItem";
            this.基本操作ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.基本操作ToolStripMenuItem.Text = "基本操作(&B)";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.刷新ToolStripMenuItem.Text = "刷新(&R)　　　　　　　　F5";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存标签信息TToolStripMenuItem,
            this.保存曲目信息MToolStripMenuItem,
            this.保存全部ACtrlSToolStripMenuItem});
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.保存ToolStripMenuItem.Text = "保存(&S)";
            // 
            // 保存标签信息TToolStripMenuItem
            // 
            this.保存标签信息TToolStripMenuItem.Name = "保存标签信息TToolStripMenuItem";
            this.保存标签信息TToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.保存标签信息TToolStripMenuItem.Text = "保存标签信息(&T)";
            // 
            // 保存曲目信息MToolStripMenuItem
            // 
            this.保存曲目信息MToolStripMenuItem.Name = "保存曲目信息MToolStripMenuItem";
            this.保存曲目信息MToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.保存曲目信息MToolStripMenuItem.Text = "保存曲目信息(&M)";
            // 
            // 保存全部ACtrlSToolStripMenuItem
            // 
            this.保存全部ACtrlSToolStripMenuItem.Name = "保存全部ACtrlSToolStripMenuItem";
            this.保存全部ACtrlSToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.保存全部ACtrlSToolStripMenuItem.Text = "保存全部(&A)　　　Ctrl+S";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(225, 6);
            // 
            // 查询EF6ToolStripMenuItem
            // 
            this.查询EF6ToolStripMenuItem.Name = "查询EF6ToolStripMenuItem";
            this.查询EF6ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.查询EF6ToolStripMenuItem.Text = "查询(&E)　　　　　　　　F6";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // 关闭CToolStripMenuItem
            // 
            this.关闭CToolStripMenuItem.Name = "关闭CToolStripMenuItem";
            this.关闭CToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.关闭CToolStripMenuItem.Text = "关闭(&C)　　　　　　　 F12";
            this.关闭CToolStripMenuItem.Click += new System.EventHandler(this.关闭CToolStripMenuItem_Click);
            // 
            // 导入曲目IToolStripMenuItem
            // 
            this.导入曲目IToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.从MP3ToolStripMenuItem,
            this.从ExcelToolStripMenuItem});
            this.导入曲目IToolStripMenuItem.Name = "导入曲目IToolStripMenuItem";
            this.导入曲目IToolStripMenuItem.Size = new System.Drawing.Size(83, 22);
            this.导入曲目IToolStripMenuItem.Text = "导入曲目(&I)";
            // 
            // 从MP3ToolStripMenuItem
            // 
            this.从MP3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入新下载的MP3ToolStripMenuItem,
            this.导入既有的MP3ToolStripMenuItem});
            this.从MP3ToolStripMenuItem.Name = "从MP3ToolStripMenuItem";
            this.从MP3ToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.从MP3ToolStripMenuItem.Text = "自MP3导入曲目信息(&M)";
            this.从MP3ToolStripMenuItem.Click += new System.EventHandler(this.从MP3ToolStripMenuItem_Click);
            // 
            // 导入新下载的MP3ToolStripMenuItem
            // 
            this.导入新下载的MP3ToolStripMenuItem.Name = "导入新下载的MP3ToolStripMenuItem";
            this.导入新下载的MP3ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.导入新下载的MP3ToolStripMenuItem.Text = "导入新下载的MP3(&N)      F3";
            this.导入新下载的MP3ToolStripMenuItem.Click += new System.EventHandler(this.导入新下载的MP3ToolStripMenuItem_Click);
            // 
            // 导入既有的MP3ToolStripMenuItem
            // 
            this.导入既有的MP3ToolStripMenuItem.Name = "导入既有的MP3ToolStripMenuItem";
            this.导入既有的MP3ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.导入既有的MP3ToolStripMenuItem.Text = "导入既有的MP3(&O)       F11";
            this.导入既有的MP3ToolStripMenuItem.Click += new System.EventHandler(this.导入既有的MP3ToolStripMenuItem_Click);
            // 
            // 从ExcelToolStripMenuItem
            // 
            this.从ExcelToolStripMenuItem.Name = "从ExcelToolStripMenuItem";
            this.从ExcelToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.从ExcelToolStripMenuItem.Text = "自Excel导入曲目信息(&E)";
            // 
            // 标签操作TToolStripMenuItem
            // 
            this.标签操作TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.从MP3ToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.从曲目信息保存至MPToolStripMenuItem});
            this.标签操作TToolStripMenuItem.Name = "标签操作TToolStripMenuItem";
            this.标签操作TToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.标签操作TToolStripMenuItem.Text = "标签操作(&T)";
            // 
            // 从MP3ToolStripMenuItem1
            // 
            this.从MP3ToolStripMenuItem1.Name = "从MP3ToolStripMenuItem1";
            this.从MP3ToolStripMenuItem1.Size = new System.Drawing.Size(245, 22);
            this.从MP3ToolStripMenuItem1.Text = "自MP3标签插入曲目(&M)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(242, 6);
            // 
            // 从曲目信息保存至MPToolStripMenuItem
            // 
            this.从曲目信息保存至MPToolStripMenuItem.Name = "从曲目信息保存至MPToolStripMenuItem";
            this.从曲目信息保存至MPToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.从曲目信息保存至MPToolStripMenuItem.Text = "自曲目信息保存至MP3标签（&R)";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 640);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1350, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 26);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.UpdateButton);
            this.splitContainer1.Panel1.Controls.Add(this.saveID3TagButton);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.DiscNoTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.TrackNoTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.AlbumNameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.ArtistTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.TrackNameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.vocalortypelabel);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.AlbumPictureBox);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MusicDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1350, 614);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 2;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(15, 538);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(197, 23);
            this.UpdateButton.TabIndex = 30;
            this.UpdateButton.Text = "更新曲目(&D)";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // saveID3TagButton
            // 
            this.saveID3TagButton.Location = new System.Drawing.Point(15, 509);
            this.saveID3TagButton.Name = "saveID3TagButton";
            this.saveID3TagButton.Size = new System.Drawing.Size(197, 23);
            this.saveID3TagButton.TabIndex = 30;
            this.saveID3TagButton.Text = "保存MP3Tag(&S)";
            this.saveID3TagButton.UseVisualStyleBackColor = true;
            this.saveID3TagButton.Click += new System.EventHandler(this.saveID3TagButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label2.Location = new System.Drawing.Point(12, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "音轨";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label3.Location = new System.Drawing.Point(12, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "专辑";
            // 
            // DiscNoTextBox
            // 
            this.DiscNoTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.DiscNoTextBox.Location = new System.Drawing.Point(130, 385);
            this.DiscNoTextBox.Name = "DiscNoTextBox";
            this.DiscNoTextBox.Size = new System.Drawing.Size(82, 22);
            this.DiscNoTextBox.TabIndex = 29;
            // 
            // TrackNoTextBox
            // 
            this.TrackNoTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.TrackNoTextBox.Location = new System.Drawing.Point(14, 385);
            this.TrackNoTextBox.Name = "TrackNoTextBox";
            this.TrackNoTextBox.Size = new System.Drawing.Size(82, 22);
            this.TrackNoTextBox.TabIndex = 27;
            // 
            // AlbumNameTextBox
            // 
            this.AlbumNameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.AlbumNameTextBox.Location = new System.Drawing.Point(14, 335);
            this.AlbumNameTextBox.Name = "AlbumNameTextBox";
            this.AlbumNameTextBox.Size = new System.Drawing.Size(198, 22);
            this.AlbumNameTextBox.TabIndex = 25;
            // 
            // ArtistTextBox
            // 
            this.ArtistTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ArtistTextBox.Location = new System.Drawing.Point(14, 285);
            this.ArtistTextBox.Name = "ArtistTextBox";
            this.ArtistTextBox.Size = new System.Drawing.Size(198, 22);
            this.ArtistTextBox.TabIndex = 23;
            // 
            // TrackNameTextBox
            // 
            this.TrackNameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.TrackNameTextBox.Location = new System.Drawing.Point(14, 235);
            this.TrackNameTextBox.Name = "TrackNameTextBox";
            this.TrackNameTextBox.Size = new System.Drawing.Size(198, 22);
            this.TrackNameTextBox.TabIndex = 21;
            this.TrackNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrackNameTextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label4.Location = new System.Drawing.Point(128, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "碟号";
            // 
            // vocalortypelabel
            // 
            this.vocalortypelabel.AutoSize = true;
            this.vocalortypelabel.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.vocalortypelabel.Location = new System.Drawing.Point(12, 265);
            this.vocalortypelabel.Name = "vocalortypelabel";
            this.vocalortypelabel.Size = new System.Drawing.Size(37, 15);
            this.vocalortypelabel.TabIndex = 22;
            this.vocalortypelabel.Text = "演唱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label1.Location = new System.Drawing.Point(12, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "曲名";
            // 
            // AlbumPictureBox
            // 
            this.AlbumPictureBox.BackColor = System.Drawing.Color.White;
            this.AlbumPictureBox.Location = new System.Drawing.Point(12, 12);
            this.AlbumPictureBox.Name = "AlbumPictureBox";
            this.AlbumPictureBox.Size = new System.Drawing.Size(200, 200);
            this.AlbumPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AlbumPictureBox.TabIndex = 0;
            this.AlbumPictureBox.TabStop = false;
            // 
            // MusicDataGridView
            // 
            this.MusicDataGridView.AllowUserToAddRows = false;
            this.MusicDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MusicDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MusicDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MusicDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OldTrackNo,
            this.AlbumID,
            this.AlbumName,
            this.AlbumType,
            this.TrackID,
            this.TrackName,
            this.TrackType,
            this.ArtistName,
            this.AnimeName,
            this.BitRate,
            this.DiscNo,
            this.TrackNo,
            this.Year,
            this.TrackTimeLength,
            this.ResourcePath,
            this.Description,
            this.AnimeNO,
            this.AlbumTypeID,
            this.TrackTypeID,
            this.ArtistID,
            this.isModified});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MusicDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.MusicDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MusicDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.MusicDataGridView.Location = new System.Drawing.Point(0, 0);
            this.MusicDataGridView.Name = "MusicDataGridView";
            this.MusicDataGridView.RowTemplate.Height = 23;
            this.MusicDataGridView.Size = new System.Drawing.Size(1126, 614);
            this.MusicDataGridView.TabIndex = 10;
            this.MusicDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MusicDataGridView_CellContentDoubleClick);
            this.MusicDataGridView.CurrentCellChanged += new System.EventHandler(this.MusicDataGridView_CurrentCellChanged);
            this.MusicDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MusicDataGridView_KeyDown);
            // 
            // OldTrackNo
            // 
            this.OldTrackNo.DataPropertyName = "OldTrackNo";
            this.OldTrackNo.HeaderText = "既有曲号";
            this.OldTrackNo.Name = "OldTrackNo";
            this.OldTrackNo.Visible = false;
            this.OldTrackNo.Width = 150;
            // 
            // AlbumID
            // 
            this.AlbumID.DataPropertyName = "AlbumID";
            this.AlbumID.HeaderText = "专辑编号";
            this.AlbumID.Name = "AlbumID";
            this.AlbumID.ReadOnly = true;
            // 
            // AlbumName
            // 
            this.AlbumName.DataPropertyName = "AlbumName";
            this.AlbumName.HeaderText = "专辑";
            this.AlbumName.Name = "AlbumName";
            this.AlbumName.Width = 200;
            // 
            // AlbumType
            // 
            this.AlbumType.DataPropertyName = "AlbumType";
            this.AlbumType.HeaderText = "专辑类型";
            this.AlbumType.Name = "AlbumType";
            this.AlbumType.Width = 80;
            // 
            // TrackID
            // 
            this.TrackID.DataPropertyName = "TrackID";
            this.TrackID.HeaderText = "曲目编号";
            this.TrackID.Name = "TrackID";
            this.TrackID.ReadOnly = true;
            // 
            // TrackName
            // 
            this.TrackName.DataPropertyName = "TrackName";
            this.TrackName.HeaderText = "曲名";
            this.TrackName.Name = "TrackName";
            this.TrackName.Width = 200;
            // 
            // TrackType
            // 
            this.TrackType.DataPropertyName = "TrackType";
            this.TrackType.HeaderText = "曲目类型";
            this.TrackType.Name = "TrackType";
            this.TrackType.Width = 80;
            // 
            // ArtistName
            // 
            this.ArtistName.DataPropertyName = "ArtistName";
            this.ArtistName.HeaderText = "艺术家";
            this.ArtistName.Name = "ArtistName";
            this.ArtistName.ReadOnly = true;
            this.ArtistName.Width = 200;
            // 
            // AnimeName
            // 
            this.AnimeName.DataPropertyName = "AnimeName";
            this.AnimeName.HeaderText = "动画";
            this.AnimeName.Name = "AnimeName";
            this.AnimeName.Width = 120;
            // 
            // BitRate
            // 
            this.BitRate.DataPropertyName = "BitRate";
            this.BitRate.HeaderText = "比特率";
            this.BitRate.Name = "BitRate";
            this.BitRate.ReadOnly = true;
            this.BitRate.Width = 80;
            // 
            // DiscNo
            // 
            this.DiscNo.DataPropertyName = "DiscNo";
            this.DiscNo.HeaderText = "碟号";
            this.DiscNo.Name = "DiscNo";
            this.DiscNo.Width = 60;
            // 
            // TrackNo
            // 
            this.TrackNo.DataPropertyName = "TrackNo";
            this.TrackNo.HeaderText = "音轨";
            this.TrackNo.Name = "TrackNo";
            this.TrackNo.Width = 60;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "发售年份";
            this.Year.Name = "Year";
            // 
            // TrackTimeLength
            // 
            this.TrackTimeLength.DataPropertyName = "TrackTimeLength";
            this.TrackTimeLength.HeaderText = "歌曲长度";
            this.TrackTimeLength.Name = "TrackTimeLength";
            this.TrackTimeLength.ReadOnly = true;
            // 
            // ResourcePath
            // 
            this.ResourcePath.DataPropertyName = "ResourcePath";
            this.ResourcePath.HeaderText = "资源地址";
            this.ResourcePath.Name = "ResourcePath";
            this.ResourcePath.ReadOnly = true;
            this.ResourcePath.Width = 200;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "描述";
            this.Description.Name = "Description";
            this.Description.Width = 200;
            // 
            // AnimeNO
            // 
            this.AnimeNO.DataPropertyName = "AnimeNO";
            this.AnimeNO.HeaderText = "动画编号";
            this.AnimeNO.Name = "AnimeNO";
            this.AnimeNO.Visible = false;
            // 
            // AlbumTypeID
            // 
            this.AlbumTypeID.DataPropertyName = "AlbumTypeID";
            this.AlbumTypeID.HeaderText = "专辑类型编号";
            this.AlbumTypeID.Name = "AlbumTypeID";
            this.AlbumTypeID.Visible = false;
            // 
            // TrackTypeID
            // 
            this.TrackTypeID.DataPropertyName = "TrackTypeID";
            this.TrackTypeID.HeaderText = "曲目类型编号";
            this.TrackTypeID.Name = "TrackTypeID";
            this.TrackTypeID.Visible = false;
            // 
            // ArtistID
            // 
            this.ArtistID.DataPropertyName = "ArtistID";
            this.ArtistID.HeaderText = "艺术家编号";
            this.ArtistID.Name = "ArtistID";
            this.ArtistID.Visible = false;
            // 
            // isModified
            // 
            this.isModified.HeaderText = "是否变化";
            this.isModified.Name = "isModified";
            this.isModified.Visible = false;
            // 
            // MusicManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 662);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MusicManage";
            this.Text = "MusicManage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MusicManage_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlbumPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView MusicDataGridView;
        private System.Windows.Forms.PictureBox AlbumPictureBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label vocalortypelabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AlbumNameTextBox;
        private System.Windows.Forms.TextBox ArtistTextBox;
        private System.Windows.Forms.TextBox TrackNameTextBox;
        private System.Windows.Forms.TextBox DiscNoTextBox;
        private System.Windows.Forms.TextBox TrackNoTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 基本操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关闭CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存标签信息TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存曲目信息MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存全部ACtrlSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入曲目IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从MP3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从ExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标签操作TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从MP3ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 从曲目信息保存至MPToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 查询EF6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入新下载的MP3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入既有的MP3ToolStripMenuItem;
        private System.Windows.Forms.Button saveID3TagButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldTrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumName;
        private System.Windows.Forms.DataGridViewButtonColumn AlbumType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackName;
        private System.Windows.Forms.DataGridViewButtonColumn TrackType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistName;
        private System.Windows.Forms.DataGridViewButtonColumn AnimeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackTimeLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResourcePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isModified;
        private System.Windows.Forms.Button UpdateButton;

    }
}