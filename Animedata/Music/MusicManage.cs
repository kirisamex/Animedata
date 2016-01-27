using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ID3;
using ID3.ID3v2Frames.BinaryFrames;
using Shell32;

namespace Main.Music
{
    public partial class MusicManage : Form
    {
        #region 常量
        MusicManageService service = new MusicManageService();

        public MusicManage()
        {
            InitializeComponent();
        }

        #endregion

        #region 载入
        /// <summary>
        /// 默认载入曲目
        /// </summary>
        private void ShowTracks()
        {
            DataSet ds = service.GetTracks();
            LoadTrackMain(ds);
        }

        /// <summary>
        /// 曲目部分载入
        /// </summary>
        /// <param name="ds"></param>
        public void LoadTrackMain(DataSet ds)
        {
            MusicDataGridView.Rows.Clear();

            DataTable musicdt = ds.Tables[0];

            for (int i = 0; i < musicdt.Rows.Count; i++)
            {
                MusicDataGridView.Rows.Add();

                DataGridViewRow dgvrow = MusicDataGridView.Rows[i];

                //既有编号
                dgvrow.Cells["OldTrackNoColumn"].Value = musicdt.Rows[i]["ANIME_NO"].ToString() +
                    "_" + musicdt.Rows[i]["ALBUM_ANIME_TYPE"].ToString().Trim() +
                    musicdt.Rows[i]["ALBUM_INANIME_NO"].ToString().PadLeft(2, '0') +
                    "_" + musicdt.Rows[i]["TRACK_NO"].ToString().PadLeft(3, '0');

                //曲名
                dgvrow.Cells["TrackNameColumn"].Value = musicdt.Rows[i]["TRACK_TITLE_NAME"].ToString();

                //专辑
                dgvrow.Cells["AlbumNameColumn"].Value = musicdt.Rows[i]["ALBUM_TITLE_NAME"].ToString().Trim();

                //演唱者
                dgvrow.Cells["VocalColumn"].Value = musicdt.Rows[i]["ARTIST_NAME"].ToString();

                //所属动画
                dgvrow.Cells["AnimeColumn"].Value = musicdt.Rows[i]["ANIME_JPN_NAME"].ToString();

                //曲目ID
                dgvrow.Cells["TrackIDColumn"].Value = musicdt.Rows[i]["TRACK_ID"].ToString();

                //碟号
                dgvrow.Cells["DiscNoColumn"].Value = musicdt.Rows[i]["DISC_NO"].ToString();

                //音轨
                dgvrow.Cells["TrackNoColumn"].Value = musicdt.Rows[i]["TRACK_NO"].ToString();

                //发售年份
                dgvrow.Cells["YearColumn"].Value = musicdt.Rows[i]["SALES_YEAR"].ToString();

                //资源地址
                dgvrow.Cells["ResourcePathColumn"].Value = musicdt.Rows[i]["RESOURCE_FILE_PATH"].ToString();

                //描述
                dgvrow.Cells["DescriptionColumn"].Value = musicdt.Rows[i]["DESCRIPTION"].ToString();
            }

            //动画窗口格式设置
            for (int i = 0; i < MusicDataGridView.ColumnCount; i++)
            {
                MusicDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                MusicDataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //TEST
            ShowMP3TagInfo(@"C:\Users\huangyh.HYRON-JS\Downloads\smileY inc. - 花雪.mp3");

        }

        #endregion

        #region 窗体
        private void MusicManage_Load(object sender, EventArgs e)
        {
            ShowTracks();
        }
        #endregion

        #region 服务
        /// <summary>
        /// 显示指定路径的MP3Tag信息
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public void ShowMP3TagInfo(string filePath)
        {
            ID3Info info = new ID3Info(filePath, true);
            foreach (AttachedPictureFrame AP in info.ID3v2Info.AttachedPictureFrames.Items)
            {
                AlbumPircureBox.Image = Image.FromStream(AP.Data);
            }
            
            //曲名
            TrackNameTextBox.Text = info.ID3v2Info.GetTextFrame("TIT2");
            //艺术家
            ArtistTextBox.Text = info.ID3v2Info.GetTextFrame("TPE1");
            //专辑
            AlbumNameTextBox.Text = info.ID3v2Info.GetTextFrame("TALB");
            //音轨
            TrackNoTextBox.Text = info.ID3v2Info.GetTextFrame("TRCK");
            //碟号
            DiscNoTextBox.Text = info.ID3v2Info.GetTextFrame("TPOS");
        }
        #endregion

        #region 按键
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTracks();
        }

        private void 查询SＦ６ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关闭CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 键盘

        /// <summary>
        /// 键盘功能键控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    ShowTracks();
                    break;
                case Keys.F12:
                    this.Close();
                    break;
            }
        }

        #endregion

        

        
    }
}
