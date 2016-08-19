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
using Main.Lib.Const;
using Main.Lib.Message;

namespace Main.Music
{
    public partial class MusicManage : Form
    {
        #region 常量
        //实例
        MusicManageService service = new MusicManageService();

        #region 信息

        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        #endregion 
        
        #region 列名
        /// <summary>既有编号 </summary>
        const string OLDTRACKNOCLN = "OldTrackNo";
        /// <summary>曲名 </summary>
        const string TRACKNAMECLN = "TrackName";
        /// <summary>专辑名 </summary>
        const string ALBUMNAMECLN = "AlbumName";
        /// <summary>专辑动画类型 </summary>
        const string ALBUMANIMETYPECLN = "AlbumAnimeType";
        /// <summary>艺术家 </summary>
        const string ARTISTNAMECLN = "ArtistName";
        /// <summary>动画名 </summary>
        const string ANIMENAMECLN = "AnimeName";
        /// <summary>曲号 </summary>
        const string TRACKIDCLN = "TrackID";
        /// <summary>碟号 </summary>
        const string DISCNOCLN = "DiscNo";
        /// <summary>音轨 </summary>
        const string TRACKNOCLN = "TrackNo";
        /// <summary>发售年份 </summary>
        const string YEARCLN = "Year";
        /// <summary>资源路径 </summary>
        const string RESOURCEPATHCLN = "ResourcePath";
        /// <summary>描述 </summary>
        const string DESCRIPTIONCLN = "Description";
        #endregion

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
            try
            {
                DataSet ds = service.GetTracks();
                LoadTrackMain(ds);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
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
                //dgvrow.Cells[OLDTRACKNOCLN].Value = musicdt.Rows[i]["ANIME_NO"].ToString() +
                //    "_" + musicdt.Rows[i]["ALBUM_ANIME_TYPE"].ToString().Trim() +
                //    musicdt.Rows[i]["ALBUM_INANIME_NO"].ToString().PadLeft(2, '0') +
                //    "_" + musicdt.Rows[i]["TRACK_NO"].ToString().PadLeft(3, '0');

                //曲名
                dgvrow.Cells[TRACKNAMECLN].Value = musicdt.Rows[i]["TRACK_TITLE_NAME"].ToString();

                //专辑
                dgvrow.Cells[ALBUMNAMECLN].Value = musicdt.Rows[i]["ALBUM_TITLE_NAME"].ToString().Trim();

                //专辑动画类型
                dgvrow.Cells[ALBUMANIMETYPECLN].Value = service.GetAlbumAnimeTypeStringByID(musicdt.Rows[i]["ANIME_TYPE_ID"].ToString());

                //演唱者
                dgvrow.Cells[ARTISTNAMECLN].Value = musicdt.Rows[i]["ARTIST_NAME"].ToString();

                //所属动画
                dgvrow.Cells[ANIMENAMECLN].Value = musicdt.Rows[i]["ANIME_JPN_NAME"].ToString();

                //曲目ID
                dgvrow.Cells[TRACKIDCLN].Value = musicdt.Rows[i]["TRACK_ID"].ToString();

                //碟号
                dgvrow.Cells[DISCNOCLN].Value = musicdt.Rows[i]["DISC_NO"].ToString();

                //音轨
                dgvrow.Cells[TRACKNOCLN].Value = musicdt.Rows[i]["TRACK_NO"].ToString();

                //发售年份
                dgvrow.Cells[YEARCLN].Value = musicdt.Rows[i]["SALES_YEAR"].ToString();

                //资源地址
                #region //资源地址
                string fpath = string.Empty, fname = string.Empty, respath = string.Empty;
                int storageid = 0;
                if (musicdt.Rows[i]["RESOURCE_FILEPATH"] != null && !musicdt.Rows[i]["RESOURCE_FILEPATH"].ToString().Equals(string.Empty))
                {
                    fpath = musicdt.Rows[i]["RESOURCE_FILEPATH"].ToString();
                }
                if (musicdt.Rows[i]["RESOURCE_FILENAME"] != null && !musicdt.Rows[i]["RESOURCE_FILENAME"].ToString().Equals(string.Empty))
                {
                    fname = musicdt.Rows[i]["RESOURCE_FILENAME"].ToString();
                }
                if (musicdt.Rows[i]["STORAGE_ID"] != null && !musicdt.Rows[i]["STORAGE_ID"].ToString().Equals(string.Empty))
                {
                    storageid=Convert.ToInt32(musicdt.Rows[i]["STORAGE_ID"]);
                }
                respath = service.GetResourcePath(storageid,
                    fpath, fname);

                #endregion

                dgvrow.Cells[RESOURCEPATHCLN].Value = respath;

                //描述
                dgvrow.Cells[DESCRIPTIONCLN].Value = musicdt.Rows[i]["DESCRIPTION"].ToString();
            }

            //动画窗口格式设置
            for (int i = 0; i < MusicDataGridView.ColumnCount; i++)
            {
                MusicDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                MusicDataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //初始显示TAG3
            if (MusicDataGridView.Rows.Count > 0
                && MusicDataGridView.Rows[0].Cells[RESOURCEPATHCLN].Value != null
                && !MusicDataGridView.Rows[0].Cells[RESOURCEPATHCLN].ToString().Equals(string.Empty))
            {
                ShowMP3TagInfo(MusicDataGridView.Rows[0].Cells[RESOURCEPATHCLN].Value.ToString());
            }

            //test
            ShowMP3TagInfo(null);

        }

        #endregion

        #region 窗体
        private void MusicManage_Load(object sender, EventArgs e)
        {
            ShowTracks();
        }

        private void MusicDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowCurrentTrackTag();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 显示指定路径的MP3Tag信息
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public void ShowMP3TagInfo(string filePath)
        {
            //text
            filePath = "C:\\Users\\Public\\Music\\Sample Music\\Kalimba.mp3";
            if (filePath == null || filePath.ToString().Equals(string.Empty))
            {
                TrackNameTextBox.Text = string.Empty;
                ArtistTextBox.Text = string.Empty;
                AlbumNameTextBox.Text = string.Empty;
                TrackNoTextBox.Text = string.Empty;
                DiscNoTextBox.Text = string.Empty;
                AlbumPictureBox.Image = null;
                return;
            }

            try
            {
                ID3V2Tag tag = new ID3V2Tag(filePath);
                
                //封面
                foreach (Image img in tag.TrackImages)
                {
                    AlbumPictureBox.Image = img;
                }
                //曲名
                TrackNameTextBox.Text = tag.TrackTitleName;
                //艺术家
                ArtistTextBox.Text = tag.ArtistName;
                //专辑
                AlbumNameTextBox.Text = tag.AlbumName;
                //音轨
                TrackNoTextBox.Text = tag.TrackNo;
                //碟号
                DiscNoTextBox.Text = tag.DiscNo;
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 获得当前单元格所在行的曲目
        /// </summary>
        /// <returns></returns>
        private TrackSeries GetCurrentTrack()
        {
            TrackSeries track = new TrackSeries(GetCurrentRow().Cells[TRACKIDCLN].Value.ToString());
            return track;
        }

        /// <summary>
        /// 获得当前行
        /// </summary>
        /// <returns></returns>
        private DataGridViewRow GetCurrentRow()
        {
            return MusicDataGridView.CurrentRow;
        }

        /// <summary>
        /// 显示当前选中曲目的TAG信息
        /// </summary>
        private void ShowCurrentTrackTag()
        {
            try
            {
                TrackSeries track = GetCurrentTrack();
                MusicResource res = new MusicResource(track.ID, 1); //音源

                string respath = service.GetResourcePath(res.StorageID,
                    res.FilePath, res.FileName);

                ShowMP3TagInfo(respath);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
                
        }

        /// <summary>
        /// 自MP3文件导入曲目信息
        /// </summary>
        private void ImportMusicFromMP3File(ImportMusic.ImportType importType)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MP3文件|*.mp3";
            dialog.Title = "选择MP3文件";
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<TrackSeries> Tracks = new List<TrackSeries>();
                string[] trackPaths = dialog.FileNames;

                ImportMusic import = new ImportMusic(importType, trackPaths);
                import.Show();
            }
        }

        #endregion

        #region 菜单
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

        private void 从MP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 导入新下载的MP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportMusicFromMP3File(ImportMusic.ImportType.ByNewMP3);
        }

        private void 导入既有的MP3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportMusicFromMP3File(ImportMusic.ImportType.ByOldMP3);
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
                case Keys.F3:
                    ImportMusicFromMP3File(ImportMusic.ImportType.ByNewMP3);
                    break;
                case Keys.F5:
                    ShowTracks();
                    break;
                case Keys.F11:
                    ImportMusicFromMP3File(ImportMusic.ImportType.ByOldMP3);
                    break;
                case Keys.F12:
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// 键盘功能键控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MusicDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            main_KeyDown(this, e);
        }

        #endregion









        

        
    }
}
