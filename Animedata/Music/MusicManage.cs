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
using Main.ClientDataSet;
using Main.Lib;
using Main.Lib.Const;
using Main.Lib.Message;
using Main.Lib.Style;

namespace Main.Music
{
    partial class MusicManage : Form
    {
        #region 常量与变量

        #region 实例
        MusicManageService service = new MusicManageService();
        MainFormat format = new MainFormat();
        DataGridViewStyle dgvStyle = new DataGridViewStyle();
        #endregion

        #region 信息

        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";

        /// <summary>修改标签时，必须仅选择一个单元格进行修改，请勿多选。</summary>
        const string MSG_MUSICMANAGE_001 = "MSG-MUSICMANAGE-001";

        /// <summary>专辑 {0} 内曲目 {1} 的碟号为空，请补充。</summary>
        const string MSG_MUSICMANAGE_002 = "MSG-MUSICMANAGE-002";

        /// <summary>专辑 {0} 内曲目 {1} 的碟号格式不正确，必须为半角数字！</summary>
        const string MSG_MUSICMANAGE_003 = "MSG-MUSICMANAGE-003";

        /// <summary>专辑 {0} 内曲目 {1} 的音轨为空，请补充。</summary>
        const string MSG_MUSICMANAGE_004 = "MSG-MUSICMANAGE-004";

        /// <summary>专辑 {0} 内曲目 {1} 的音轨格式不正确，必须为半角数字！</summary>
        const string MSG_MUSICMANAGE_005 = "MSG-MUSICMANAGE-005";

        /// <summary>专辑 {0} 内曲目 {1} 的发售年份格式不正确，必须为半角数字年份。</summary>
        const string MSG_MUSICMANAGE_006 = "MSG-MUSICMANAGE-006";

        /// <summary>专辑 {0} 内曲目 {1} 的专辑类型未选择，请补充。</summary>
        const string MSG_MUSICMANAGE_007 = "MSG-MUSICMANAGE-007";

        /// <summary>专辑 {0} 内曲目 {1} 的曲目类型未选择，请补充。</summary>
        const string MSG_MUSICMANAGE_008 = "MSG-MUSICMANAGE-008";

        /// <summary>专辑 {0} 内曲目 {1} 的艺术家内容未编辑完成，请补充。</summary>
        const string MSG_MUSICMANAGE_009 = "MSG-MUSICMANAGE-009";

        /// <summary>专辑 {0} 内曲目 {1} 的所属动画未选择，请补充。</summary>
        const string MSG_MUSICMANAGE_010 = "MSG-MUSICMANAGE-010";

        /// <summary>文件{0}不存在！" caption="文件不存在</summary>
        const string MSG_MUSICMANAGE_011 = "MSG-MUSICMANAGE-011";
        /// <summary>专辑 {0} 内曲目编号为 {1} 的曲目标题为空，请补充。</summary>
        const string MSG_MUSICMANAGE_012 = "MSG-MUSICMANAGE-012";
        /// <summary>专辑编号 {0} 的专辑标题为空，请补充。</summary>
        const string MSG_MUSICMANAGE_013 = "MSG-MUSICMANAGE-013";
        #endregion

        #region 变量
        /// <summary>
        /// 
        /// </summary>
        DataTable trackDataTable = new DataTable();

        /// <summary>
        /// 当前时间
        /// </summary>
        string TimeNow = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");

        /// <summary>
        /// 当前单元格文本
        /// </summary>
        string curCellText = string.Empty;
        #endregion

        #region 列名
        /// <summary>既有编号 </summary>
        const string OLDTRACKNOCLN = "OldTrackNo";
        /// <summary>曲号 </summary>
        const string TRACKIDCLN = "TrackID";
        /// <summary>曲名 </summary>
        const string TRACKNAMECLN = "TrackName";
        /// <summary>曲目类型 </summary>
        const string TRACKTYPECLN = "TrackType";
        /// <summary>专辑号 </summary>
        const string ALBUMIDCLN = "AlbumID";
        /// <summary>专辑名 </summary>
        const string ALBUMNAMECLN = "AlbumName";
        /// <summary>专辑类型 </summary>
        const string ALBUMTYPECLN = "AlbumType";
        /// <summary>艺术家 </summary>
        const string ARTISTNAMECLN = "ArtistName";
        /// <summary>动画名 </summary>
        const string ANIMENAMECLN = "AnimeName";
        /// <summary>比特率 </summary>
        const string BITRATECLN = "BitRate";
        /// <summary>歌曲长度 </summary>
        const string TRACKTIMELENGTHCLN = "TrackTimeLength";
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
        /// <summary>动画编号 </summary>
        const string ANIMENOCLN = "AnimeNO";
        /// <summary>专辑类型编号 </summary>
        const string ALBUMTYPEIDCLN = "AlbumTypeID";
        /// <summary>曲目类型编号 </summary>
        const string TRACKTYPEIDCLN = "TrackTypeID";
        /// <summary>艺术家编号 </summary>
        const string ARTISTIDCLN = "ArtistID";
        #endregion

        #region 构析
        public MusicManage()
        {
            InitializeComponent();
        }
        #endregion

        #endregion

        #region 载入
        /// <summary>
        /// 默认载入曲目
        /// </summary>
        public void ShowTracks()
        {
            try
            {
                List<AlbumSeries> albumList = service.GetAlbums();
                LoadTrackMain(albumList);
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
        public void LoadTrackMain(List<AlbumSeries> albumList)
        {
            trackDataTable = service.GetTracks();

            MusicDataGridView.DataSource = trackDataTable;

            #region 旧方法

            //MusicDataGridView.Rows.Clear();

            //foreach (AlbumSeries album in albumList)
            //{
            //    foreach (TrackSeries track in album.Tracks)
            //    {

            //        DataGridViewRow dgvrow = MusicDataGridView.Rows[MusicDataGridView.Rows.Add()];

            //        //主要音乐资源:MP3格式，主资源库
            //        ResourceSeries soundResource = track.Resource.Find(p => p.TypeID == ResourceFile.Type.MUSIC_MP3_1
            //            && p.StorageID == StorageID.Path.MAIN_RESOURCE_BUCKET_201);

            //        ////既有编号
            //        //dgvrow.Cells[OLDTRACKNOCLN].Value = musicdt.Rows[i]["ANIME_NO"].ToString() +
            //        //    "_" + musicdt.Rows[i]["ALBUM_ANIME_TYPE"].ToString().Trim() +
            //        //    musicdt.Rows[i]["ALBUM_INANIME_NO"].ToString().PadLeft(2, '0') +
            //        //    "_" + musicdt.Rows[i]["TRACK_NO"].ToString().PadLeft(3, '0');

            //        //专辑ID
            //        dgvrow.Cells[ALBUMIDCLN].Value = album.ID;

            //        //专辑
            //        dgvrow.Cells[ALBUMNAMECLN].Value = album.AlbumTitleName;

            //        //专辑类型
            //        dgvrow.Cells[ALBUMTYPECLN].Value = service.GetAlbumTypeNameByAlbumTypeID(album.AlbumTypeId);

            //        //专辑类型编号
            //        dgvrow.Cells[ALBUMTYPEIDCLN].Value = album.AlbumTypeId.ToString();

            //        //曲目ID
            //        dgvrow.Cells[TRACKIDCLN].Value = track.ID;

            //        //曲名
            //        dgvrow.Cells[TRACKNAMECLN].Value = track.TrackTitleName;

            //        //曲目类型
            //        dgvrow.Cells[TRACKTYPECLN].Value = service.GetTrackTypeNameByAlbumTypeID(track.TrackTypeId);

            //        //曲目类型编号
            //        dgvrow.Cells[TRACKTYPEIDCLN].Value = track.TrackTypeId;

            //        //艺术家   
            //        dgvrow.Cells[ARTISTNAMECLN].Value = service.GetArtistNameFromArtistID(track.ArtistID);

            //        //艺术家编号
            //        dgvrow.Cells[ARTISTIDCLN].Value = track.ArtistID.ToString();

            //        if (!string.IsNullOrEmpty(track.AnimeNo))
            //        {
            //            //所属动画
            //            dgvrow.Cells[ANIMENAMECLN].Value = service.GetAnimeFromAnimeNo(track.AnimeNo);
            //            //动画编号
            //            dgvrow.Cells[ANIMENOCLN].Value = track.AnimeNo;
            //        }

            //        //比特率
            //        dgvrow.Cells[BITRATECLN].Value = soundResource.TrackBitRate;

            //        //歌曲长度
            //        dgvrow.Cells[TRACKTIMELENGTHCLN].Value = format.GetTimeFromSecond(soundResource.TrackLength);

            //        //碟号
            //        dgvrow.Cells[DISCNOCLN].Value = track.DiscNo.ToString();

            //        //音轨
            //        dgvrow.Cells[TRACKNOCLN].Value = track.TrackNo.ToString();

            //        //发售年份
            //        if (track.SalesYear > 0)
            //        {
            //            dgvrow.Cells[YEARCLN].Value = track.SalesYear.ToString();
            //        }

            //        //资源地址
            //        if (soundResource != null)
            //        {
            //            string fpath = service.GetResourcePath(soundResource.StorageID, soundResource.FilePath, soundResource.FileName, soundResource.Suffix);
            //            dgvrow.Cells[RESOURCEPATHCLN].Value = fpath;
            //        }
                    
            //        //描述
            //        if (!string.IsNullOrEmpty(track.Description))
            //        {
            //            dgvrow.Cells[DESCRIPTIONCLN].Value = track.Description;
            //        }
            //    }
            //}

            //dgvStyle.SetDataGridViewColumnWidch(MusicDataGridView, new int[] { 
            //    //120,    //OldTrackNo
            //    100,    //TrackID
            //    200,    //TrackName
            //    80,    //TrackType
            //    100,    //AlbumID
            //    200,    //AlbumName
            //    80,     //AlbumType

            //    200,    //ArtistName
            //    120,    //AnimeCHNName

            //    80,     //BitRate

            //    70,     //DiscNo
            //    70,     //TrackNo

            //    120,    //Year
            //    100,    //TrackLength
                

            //    300,    //ResourcePath
            //    200     //Description
            //});

            #endregion

            //初始显示TAG3
            if (MusicDataGridView.Rows.Count > 0
                && MusicDataGridView.Rows[0].Cells[RESOURCEPATHCLN].Value != null
                && !MusicDataGridView.Rows[0].Cells[RESOURCEPATHCLN].ToString().Equals(string.Empty))
            {
                ShowMP3TagInfo(MusicDataGridView.Rows[0].Cells[RESOURCEPATHCLN].Value.ToString());
            }

            //MusicDataGridView.Focus();

            
        }

        #endregion

        #region 方法
        /// <summary>
        /// 显示指定路径的MP3Tag信息
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public void ShowMP3TagInfo(string filePath)
        {
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
        private string GetCurrentTrackPath()
        {
            DataGridViewRow dr = GetCurrentRow();
            if (dr != null && DBNull.Value != dr.Cells[RESOURCEPATHCLN].Value)
            {
                string trackPath = dr.Cells[RESOURCEPATHCLN].Value.ToString();
                return trackPath;
            }

            return null;
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
                string curTrackPath = GetCurrentTrackPath();

                ShowMP3TagInfo(curTrackPath);
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

        /// <summary>
        /// 保存MP3ID3V2TAG
        /// </summary>
        /// <param name="filePath"></param>
        private void SaveMP3TagInfo(string filePath)
        {
            try
            {
                ID3V2Tag tag = new ID3V2Tag(filePath);

                //曲名
                tag.TrackTitleName = TrackNameTextBox.Text;
                //艺术家
                tag.ArtistName = ArtistTextBox.Text;
                //专辑
                tag.AlbumName = AlbumNameTextBox.Text;
                //音轨
                tag.TrackNo = TrackNoTextBox.Text;
                //碟号
                tag.DiscNo = DiscNoTextBox.Text;

                tag.Save(filePath);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 保存ID3Tag
        /// </summary>
        private void OnSaveID3Tag()
        {
            //ToDo：复选行可以修改相同的TAG
            if (MusicDataGridView.SelectedCells.Count == 1)
            {
                SaveMP3TagInfo(MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[RESOURCEPATHCLN].Value.ToString());
                toolStripStatusLabel.Text = TimeNow + "保存成功";
                return;
            }

            MsgBox.Show(MSG_MUSICMANAGE_001);
        }

        /// <summary>
        /// 格式检查 
        /// </summary>
        /// <returns></returns>
        private bool FormatCheck()
        {
            foreach (DataGridViewRow dr in MusicDataGridView.Rows)
            {
                //TRACK_ID非空
                if (dr.Cells[TRACKIDCLN].Value == null || string.IsNullOrEmpty(dr.Cells[TRACKIDCLN].Value.ToString()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKIDCLN];
                    MsgBox.Show(MSG_COMMON_001, "INFO:TRACK_ID IS NULL OR EMPTY");
                    return false;
                }

                //ALBUM_ID非空
                if (dr.Cells[ALBUMIDCLN].Value == null || string.IsNullOrEmpty(dr.Cells[ALBUMIDCLN].Value.ToString()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[ALBUMIDCLN];
                    MsgBox.Show(MSG_COMMON_001, "INFO:ALBUM_ID IS NULL OR EMPTY");
                    return false;
                }

                //BITRATE非空
                if (dr.Cells[BITRATECLN].Value == null || string.IsNullOrEmpty(dr.Cells[BITRATECLN].Value.ToString()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[BITRATECLN];
                    MsgBox.Show(MSG_COMMON_001, "INFO:BITRATE IS NULL OR EMPTY");
                    return false;
                }

                //TRACKTIMELENGTH非空
                if (dr.Cells[TRACKTIMELENGTHCLN].Value == null || string.IsNullOrEmpty(dr.Cells[TRACKTIMELENGTHCLN].Value.ToString()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKTIMELENGTHCLN];
                    MsgBox.Show(MSG_COMMON_001, "INFO:TRACKTIMELENGTH IS NULL OR EMPTY");
                    return false;
                }

                //TrackName
                if (dr.Cells[TRACKNAMECLN].Value == null || string.IsNullOrEmpty(dr.Cells[TRACKNAMECLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKTIMELENGTHCLN];
                    MsgBox.Show(MSG_MUSICMANAGE_012, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKIDCLN].Value.ToString());
                    return false;
                }

                //AlbumName
                if (dr.Cells[ALBUMNAMECLN].Value == null || string.IsNullOrEmpty(dr.Cells[ALBUMNAMECLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[ALBUMNAMECLN];
                    MsgBox.Show(MSG_MUSICMANAGE_013, dr.Cells[ALBUMNAMECLN].Value.ToString());
                    return false;
                }

                //AnimeName
                if (dr.Cells[ANIMENAMECLN].Value == null || string.IsNullOrEmpty(dr.Cells[ANIMENAMECLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[ANIMENAMECLN];
                    MsgBox.Show(MSG_MUSICMANAGE_013, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //DiscNo
                if (dr.Cells[DISCNOCLN].Value == null || string.IsNullOrEmpty(dr.Cells[DISCNOCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[DISCNOCLN];
                    MsgBox.Show(MSG_MUSICMANAGE_002, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }
                else if (!format.IsNumber(dr.Cells[DISCNOCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[DISCNOCLN];
                    MsgBox.Show(MSG_MUSICMANAGE_003, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //TrackNo
                if (dr.Cells[TRACKNOCLN].Value == null || string.IsNullOrEmpty(dr.Cells[TRACKNOCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKNOCLN];
                    MsgBox.Show(MSG_MUSICMANAGE_004, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }
                else if (!format.IsNumber(dr.Cells[TRACKNOCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKNOCLN];
                    MsgBox.Show(MSG_MUSICMANAGE_005, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //Year
                if (dr.Cells[YEARCLN].Value != null && !service.YYYYFormatCheck(dr.Cells[YEARCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[YEARCLN];
                    MsgBox.Show(MSG_MUSICMANAGE_006, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //ResourcePath非空
                if (dr.Cells[RESOURCEPATHCLN].Value == null || string.IsNullOrEmpty(dr.Cells[RESOURCEPATHCLN].Value.ToString()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[RESOURCEPATHCLN];
                    MsgBox.Show(MSG_COMMON_001, "INFO:RESOURCEPATHCLN IS NULL OR EMPTY");
                    return false;
                }

                //ANIME_NO
                if (dr.Cells[ANIMENOCLN] != null && service.AnimeNoCheck(dr.Cells[ANIMENOCLN].ToString()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[ANIMENAMECLN];
                    MsgBox.Show(MSG_COMMON_001, "INFO:ANIMENOCLN FORMAT ERROR");
                    return false;
                }

                //AlbumTypeID
                if (dr.Cells[ALBUMTYPEIDCLN].Value == null || string.IsNullOrEmpty(dr.Cells[ALBUMTYPEIDCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[ALBUMTYPECLN];
                    MsgBox.Show(MSG_MUSICMANAGE_007, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //TrackTypeID
                if (dr.Cells[TRACKTYPEIDCLN].Value == null || string.IsNullOrEmpty(dr.Cells[TRACKTYPEIDCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKTYPECLN];
                    MsgBox.Show(MSG_MUSICMANAGE_008, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //ArtistID
                if (dr.Cells[ARTISTIDCLN].Value == null || string.IsNullOrEmpty(dr.Cells[ARTISTIDCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[ARTISTNAMECLN];
                    MsgBox.Show(MSG_MUSICMANAGE_009, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //放送时间格式检查
                //目前放送时间不可编辑，直接从文件Shell32中取出，不做检查

            }
            return true;
        }

        private void OnUpdate()
        {
            string targetAlbumID = GetCurrentRow().Cells[ALBUMIDCLN].Value.ToString();
            EditMusic edit = new EditMusic(targetAlbumID);
            edit.Show();
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

        

        private void TrackNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            main_KeyDown(this, e);
        }
        #endregion

        #region 按钮
        private void saveID3TagButton_Click(object sender, EventArgs e)
        {
            OnSaveID3Tag();
        }
        #endregion


        #region 事件
        /// <summary>
        /// 载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MusicManage_Load(object sender, EventArgs e)
        {
            ShowTracks();
        }     

        private void MusicDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowCurrentTrackTag();             
        }
        
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            OnUpdate();
        }
        #endregion







    }
}
