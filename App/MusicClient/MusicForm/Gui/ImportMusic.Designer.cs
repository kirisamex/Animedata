namespace MusicClient.MusicForm.Gui{
    partial class ImportMusic
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.musicDataSet1 = new MusicClientDataSet.MusicDataSet();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tagsavesuccesslabel = new System.Windows.Forms.Label();
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
            this.coverPictureBox = new System.Windows.Forms.PictureBox();
            this.ImportMusicButton = new System.Windows.Forms.Button();
            this.saveID3TagButton = new System.Windows.Forms.Button();
            this.MusicDataGridView = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.OldTrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumAnimeType = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TrackID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackType = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ArtistName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AnimeName = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackTimeLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResourcePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtistID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.musicDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // musicDataSet1
            // 
            this.musicDataSet1.DataSetName = "MusicDataSet";
            this.musicDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.MusicDataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(1350, 729);
            this.splitContainer2.SplitterDistance = 210;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tagsavesuccesslabel);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            this.splitContainer3.Panel1.Controls.Add(this.DiscNoTextBox);
            this.splitContainer3.Panel1.Controls.Add(this.TrackNoTextBox);
            this.splitContainer3.Panel1.Controls.Add(this.AlbumNameTextBox);
            this.splitContainer3.Panel1.Controls.Add(this.ArtistTextBox);
            this.splitContainer3.Panel1.Controls.Add(this.TrackNameTextBox);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.vocalortypelabel);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.coverPictureBox);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ImportMusicButton);
            this.splitContainer3.Panel2.Controls.Add(this.saveID3TagButton);
            this.splitContainer3.Size = new System.Drawing.Size(210, 729);
            this.splitContainer3.SplitterDistance = 485;
            this.splitContainer3.TabIndex = 0;
            // 
            // tagsavesuccesslabel
            // 
            this.tagsavesuccesslabel.AutoSize = true;
            this.tagsavesuccesslabel.Location = new System.Drawing.Point(22, 347);
            this.tagsavesuccesslabel.Name = "tagsavesuccesslabel";
            this.tagsavesuccesslabel.Size = new System.Drawing.Size(113, 12);
            this.tagsavesuccesslabel.TabIndex = 13;
            this.tagsavesuccesslabel.Text = "标签信息保存成功！";
            this.tagsavesuccesslabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label2.Location = new System.Drawing.Point(124, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "音轨";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label3.Location = new System.Drawing.Point(19, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "专辑";
            // 
            // DiscNoTextBox
            // 
            this.DiscNoTextBox.Font = new System.Drawing.Font("SimSun", 11F);
            this.DiscNoTextBox.Location = new System.Drawing.Point(62, 310);
            this.DiscNoTextBox.Name = "DiscNoTextBox";
            this.DiscNoTextBox.Size = new System.Drawing.Size(56, 24);
            this.DiscNoTextBox.TabIndex = 8;
            // 
            // TrackNoTextBox
            // 
            this.TrackNoTextBox.Font = new System.Drawing.Font("SimSun", 11F);
            this.TrackNoTextBox.Location = new System.Drawing.Point(166, 310);
            this.TrackNoTextBox.Name = "TrackNoTextBox";
            this.TrackNoTextBox.Size = new System.Drawing.Size(56, 24);
            this.TrackNoTextBox.TabIndex = 9;
            // 
            // AlbumNameTextBox
            // 
            this.AlbumNameTextBox.Font = new System.Drawing.Font("SimSun", 11F);
            this.AlbumNameTextBox.Location = new System.Drawing.Point(62, 280);
            this.AlbumNameTextBox.Name = "AlbumNameTextBox";
            this.AlbumNameTextBox.Size = new System.Drawing.Size(160, 24);
            this.AlbumNameTextBox.TabIndex = 10;
            // 
            // ArtistTextBox
            // 
            this.ArtistTextBox.Font = new System.Drawing.Font("SimSun", 11F);
            this.ArtistTextBox.Location = new System.Drawing.Point(62, 250);
            this.ArtistTextBox.Name = "ArtistTextBox";
            this.ArtistTextBox.Size = new System.Drawing.Size(160, 24);
            this.ArtistTextBox.TabIndex = 11;
            // 
            // TrackNameTextBox
            // 
            this.TrackNameTextBox.Font = new System.Drawing.Font("SimSun", 11F);
            this.TrackNameTextBox.Location = new System.Drawing.Point(62, 220);
            this.TrackNameTextBox.Name = "TrackNameTextBox";
            this.TrackNameTextBox.Size = new System.Drawing.Size(160, 24);
            this.TrackNameTextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label4.Location = new System.Drawing.Point(19, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "碟号";
            // 
            // vocalortypelabel
            // 
            this.vocalortypelabel.AutoSize = true;
            this.vocalortypelabel.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.vocalortypelabel.Location = new System.Drawing.Point(19, 253);
            this.vocalortypelabel.Name = "vocalortypelabel";
            this.vocalortypelabel.Size = new System.Drawing.Size(37, 15);
            this.vocalortypelabel.TabIndex = 6;
            this.vocalortypelabel.Text = "演唱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.label1.Location = new System.Drawing.Point(19, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "曲名";
            // 
            // coverPictureBox
            // 
            this.coverPictureBox.BackColor = System.Drawing.Color.White;
            this.coverPictureBox.Location = new System.Drawing.Point(22, 14);
            this.coverPictureBox.Name = "coverPictureBox";
            this.coverPictureBox.Size = new System.Drawing.Size(200, 200);
            this.coverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.coverPictureBox.TabIndex = 0;
            this.coverPictureBox.TabStop = false;
            // 
            // ImportMusicButton
            // 
            this.ImportMusicButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.ImportMusicButton.Location = new System.Drawing.Point(22, 205);
            this.ImportMusicButton.Name = "ImportMusicButton";
            this.ImportMusicButton.Size = new System.Drawing.Size(200, 23);
            this.ImportMusicButton.TabIndex = 13;
            this.ImportMusicButton.Text = "导入音乐(&A)";
            this.ImportMusicButton.UseVisualStyleBackColor = true;
            this.ImportMusicButton.Click += new System.EventHandler(this.ImportMusicButton_Click);
            // 
            // saveID3TagButton
            // 
            this.saveID3TagButton.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.saveID3TagButton.Location = new System.Drawing.Point(22, 176);
            this.saveID3TagButton.Name = "saveID3TagButton";
            this.saveID3TagButton.Size = new System.Drawing.Size(200, 23);
            this.saveID3TagButton.TabIndex = 13;
            this.saveID3TagButton.Text = "保存ID3Tag(&S)";
            this.saveID3TagButton.UseVisualStyleBackColor = true;
            this.saveID3TagButton.Click += new System.EventHandler(this.saveID3TagButton_Click);
            // 
            // MusicDataGridView
            // 
            this.MusicDataGridView.AllowUserToAddRows = false;
            this.MusicDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 11F);
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
            this.AlbumAnimeType,
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
            this.AnimeNo,
            this.AlbumTypeID,
            this.TrackTypeID,
            this.ArtistID});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("SimSun", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MusicDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.MusicDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MusicDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.MusicDataGridView.Location = new System.Drawing.Point(0, 0);
            this.MusicDataGridView.Name = "MusicDataGridView";
            this.MusicDataGridView.RowTemplate.Height = 25;
            this.MusicDataGridView.Size = new System.Drawing.Size(1136, 729);
            this.MusicDataGridView.TabIndex = 1;
            this.MusicDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MusicDataGridView_CellContentClick);
            this.MusicDataGridView.CurrentCellChanged += new System.EventHandler(this.MusicDataGridView_CurrentCellChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OldTrackNo
            // 
            this.OldTrackNo.HeaderText = "既有曲号";
            this.OldTrackNo.Name = "OldTrackNo";
            this.OldTrackNo.Visible = false;
            // 
            // AlbumID
            // 
            this.AlbumID.HeaderText = "专辑编号";
            this.AlbumID.Name = "AlbumID";
            // 
            // AlbumName
            // 
            this.AlbumName.HeaderText = "专辑";
            this.AlbumName.Name = "AlbumName";
            // 
            // AlbumAnimeType
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.AlbumAnimeType.DefaultCellStyle = dataGridViewCellStyle2;
            this.AlbumAnimeType.HeaderText = "专辑类型";
            this.AlbumAnimeType.Name = "AlbumAnimeType";
            // 
            // TrackID
            // 
            this.TrackID.HeaderText = "曲目编号";
            this.TrackID.Name = "TrackID";
            // 
            // TrackName
            // 
            this.TrackName.HeaderText = "曲名";
            this.TrackName.Name = "TrackName";
            // 
            // TrackType
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TrackType.DefaultCellStyle = dataGridViewCellStyle3;
            this.TrackType.HeaderText = "曲目类型";
            this.TrackType.Name = "TrackType";
            // 
            // ArtistName
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ArtistName.DefaultCellStyle = dataGridViewCellStyle4;
            this.ArtistName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ArtistName.HeaderText = "艺术家";
            this.ArtistName.Name = "ArtistName";
            // 
            // AnimeName
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.AnimeName.DefaultCellStyle = dataGridViewCellStyle5;
            this.AnimeName.HeaderText = "所属动画";
            this.AnimeName.Name = "AnimeName";
            // 
            // BitRate
            // 
            this.BitRate.HeaderText = "比特率";
            this.BitRate.Name = "BitRate";
            this.BitRate.ReadOnly = true;
            // 
            // DiscNo
            // 
            this.DiscNo.HeaderText = "碟号";
            this.DiscNo.Name = "DiscNo";
            // 
            // TrackNo
            // 
            this.TrackNo.HeaderText = "音轨";
            this.TrackNo.Name = "TrackNo";
            // 
            // Year
            // 
            this.Year.HeaderText = "发售年份";
            this.Year.Name = "Year";
            // 
            // TrackTimeLength
            // 
            this.TrackTimeLength.HeaderText = "歌曲长度";
            this.TrackTimeLength.Name = "TrackTimeLength";
            this.TrackTimeLength.ReadOnly = true;
            // 
            // ResourcePath
            // 
            this.ResourcePath.HeaderText = "资源地址";
            this.ResourcePath.Name = "ResourcePath";
            this.ResourcePath.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "描述";
            this.Description.Name = "Description";
            // 
            // AnimeNo
            // 
            this.AnimeNo.HeaderText = "动画编号";
            this.AnimeNo.Name = "AnimeNo";
            this.AnimeNo.Visible = false;
            // 
            // AlbumTypeID
            // 
            this.AlbumTypeID.HeaderText = "专辑类型编号";
            this.AlbumTypeID.Name = "AlbumTypeID";
            this.AlbumTypeID.Visible = false;
            // 
            // TrackTypeID
            // 
            this.TrackTypeID.HeaderText = "曲目类型编号";
            this.TrackTypeID.Name = "TrackTypeID";
            this.TrackTypeID.Visible = false;
            // 
            // ArtistID
            // 
            this.ArtistID.HeaderText = "艺术家编号";
            this.ArtistID.Name = "ArtistID";
            this.ArtistID.Visible = false;
            // 
            // ImportMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.splitContainer2);
            this.Name = "ImportMusic";
            this.Text = "导入音乐";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.musicDataSet1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MusicClientDataSet.MusicDataSet musicDataSet1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DiscNoTextBox;
        private System.Windows.Forms.TextBox TrackNoTextBox;
        private System.Windows.Forms.TextBox AlbumNameTextBox;
        private System.Windows.Forms.TextBox ArtistTextBox;
        private System.Windows.Forms.TextBox TrackNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label vocalortypelabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox coverPictureBox;
        private System.Windows.Forms.Button ImportMusicButton;
        private System.Windows.Forms.Button saveID3TagButton;
        private System.Windows.Forms.DataGridView MusicDataGridView;
        private System.Windows.Forms.Label tagsavesuccesslabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldTrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumName;
        private System.Windows.Forms.DataGridViewButtonColumn AlbumAnimeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackName;
        private System.Windows.Forms.DataGridViewButtonColumn TrackType;
        private System.Windows.Forms.DataGridViewButtonColumn ArtistName;
        private System.Windows.Forms.DataGridViewButtonColumn AnimeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackTimeLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResourcePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistID;
    }
}