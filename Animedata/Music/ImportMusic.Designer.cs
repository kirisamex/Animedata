namespace Main.Music
{
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
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
            this.MusicDataGridView = new System.Windows.Forms.DataGridView();
            this.OldTrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumAnimeType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ArtistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResourcePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.musicDataSet1 = new Main.ClientDataSet.MusicDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1148, 645);
            this.splitContainer1.SplitterDistance = 612;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Size = new System.Drawing.Size(1148, 612);
            this.splitContainer2.SplitterDistance = 220;
            this.splitContainer2.TabIndex = 0;
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
            this.splitContainer3.Size = new System.Drawing.Size(220, 612);
            this.splitContainer3.SplitterDistance = 304;
            this.splitContainer3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(103, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "音轨";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(10, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "专辑";
            // 
            // DiscNoTextBox
            // 
            this.DiscNoTextBox.Location = new System.Drawing.Point(45, 262);
            this.DiscNoTextBox.Name = "DiscNoTextBox";
            this.DiscNoTextBox.Size = new System.Drawing.Size(52, 19);
            this.DiscNoTextBox.TabIndex = 8;
            // 
            // TrackNoTextBox
            // 
            this.TrackNoTextBox.Location = new System.Drawing.Point(138, 262);
            this.TrackNoTextBox.Name = "TrackNoTextBox";
            this.TrackNoTextBox.Size = new System.Drawing.Size(58, 19);
            this.TrackNoTextBox.TabIndex = 9;
            // 
            // AlbumNameTextBox
            // 
            this.AlbumNameTextBox.Location = new System.Drawing.Point(45, 232);
            this.AlbumNameTextBox.Name = "AlbumNameTextBox";
            this.AlbumNameTextBox.Size = new System.Drawing.Size(151, 19);
            this.AlbumNameTextBox.TabIndex = 10;
            // 
            // ArtistTextBox
            // 
            this.ArtistTextBox.Location = new System.Drawing.Point(45, 202);
            this.ArtistTextBox.Name = "ArtistTextBox";
            this.ArtistTextBox.Size = new System.Drawing.Size(151, 19);
            this.ArtistTextBox.TabIndex = 11;
            // 
            // TrackNameTextBox
            // 
            this.TrackNameTextBox.Location = new System.Drawing.Point(45, 172);
            this.TrackNameTextBox.Name = "TrackNameTextBox";
            this.TrackNameTextBox.Size = new System.Drawing.Size(151, 19);
            this.TrackNameTextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(10, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "碟号";
            // 
            // vocalortypelabel
            // 
            this.vocalortypelabel.AutoSize = true;
            this.vocalortypelabel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.vocalortypelabel.Location = new System.Drawing.Point(10, 205);
            this.vocalortypelabel.Name = "vocalortypelabel";
            this.vocalortypelabel.Size = new System.Drawing.Size(29, 12);
            this.vocalortypelabel.TabIndex = 6;
            this.vocalortypelabel.Text = "演唱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(10, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "曲名";
            // 
            // coverPictureBox
            // 
            this.coverPictureBox.Location = new System.Drawing.Point(45, 12);
            this.coverPictureBox.Name = "coverPictureBox";
            this.coverPictureBox.Size = new System.Drawing.Size(150, 150);
            this.coverPictureBox.TabIndex = 0;
            this.coverPictureBox.TabStop = false;
            // 
            // MusicDataGridView
            // 
            this.MusicDataGridView.AllowUserToAddRows = false;
            this.MusicDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MusicDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MusicDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MusicDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OldTrackNo,
            this.TrackID,
            this.TrackName,
            this.AlbumID,
            this.AlbumName,
            this.AlbumAnimeType,
            this.ArtistName,
            this.AnimeName,
            this.DiscNo,
            this.TrackNo,
            this.Year,
            this.ResourcePath,
            this.Description});
            this.MusicDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MusicDataGridView.Location = new System.Drawing.Point(0, 0);
            this.MusicDataGridView.MultiSelect = false;
            this.MusicDataGridView.Name = "MusicDataGridView";
            this.MusicDataGridView.RowTemplate.Height = 21;
            this.MusicDataGridView.Size = new System.Drawing.Size(924, 612);
            this.MusicDataGridView.TabIndex = 1;
            // 
            // OldTrackNo
            // 
            this.OldTrackNo.HeaderText = "既有曲号";
            this.OldTrackNo.Name = "OldTrackNo";
            this.OldTrackNo.Visible = false;
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
            this.AlbumAnimeType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.AlbumAnimeType.HeaderText = "专辑类型";
            this.AlbumAnimeType.Items.AddRange(new object[] {
            "OP/ED",
            "角色歌",
            "OST",
            "其他"});
            this.AlbumAnimeType.Name = "AlbumAnimeType";
            this.AlbumAnimeType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AlbumAnimeType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ArtistName
            // 
            this.ArtistName.HeaderText = "艺术家";
            this.ArtistName.Name = "ArtistName";
            // 
            // AnimeName
            // 
            this.AnimeName.HeaderText = "所属动画";
            this.AnimeName.Name = "AnimeName";
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
            // ResourcePath
            // 
            this.ResourcePath.HeaderText = "资源地址";
            this.ResourcePath.Name = "ResourcePath";
            // 
            // Description
            // 
            this.Description.HeaderText = "描述";
            this.Description.Name = "Description";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1148, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // musicDataSet1
            // 
            this.musicDataSet1.DataSetName = "MusicDataSet";
            this.musicDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ImportMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 645);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ImportMusic";
            this.Text = "导入音乐";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PictureBox coverPictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
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
        private System.Windows.Forms.DataGridView MusicDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldTrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumName;
        private System.Windows.Forms.DataGridViewComboBoxColumn AlbumAnimeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResourcePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private ClientDataSet.MusicDataSet musicDataSet1;
    }
}