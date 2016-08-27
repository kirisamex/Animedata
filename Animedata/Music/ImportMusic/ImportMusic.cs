using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main.ClientDataSet;
using Main.Lib.Const;
using Main.Lib.Message;
using Main.Lib.Style;
using Main.UILib;

namespace Main.Music
{
    public partial class ImportMusic : Form
    {
        #region 信息
        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>指定的路径：{0} 不存在！\n{0}</summary>
        const string MSG_IMPORTMUSIC_001 = "MSG-IMPORTMUSIC-001";
        /// <summary>修改标签时，必须仅选择一个单元格进行修改，请勿多选。</summary>
        const string MSG_IMPORTMUSIC_002 = "MSG-IMPORTMUSIC-002";
        #endregion 
  
        #region 列名
        /// <summary>既有编号 </summary>
        const string OLDTRACKNOCLN = "OldTrackNo";
        /// <summary>曲名 </summary>
        const string TRACKNAMECLN = "TrackName";
        /// <summary>曲目类型 </summary>
        const string TRACKTYPECLN = "TrackType";
        /// <summary>专辑号 </summary>
        const string ALBUMIDCLN = "AlbumID";
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
        /// <summary>动画编号 </summary>
        const string ANIMENOCLN = "AnimeNO";
        /// <summary>专辑类型编号 </summary>
        const string ALBUMTYPEIDCLN = "AlbumTypeID";
        /// <summary>曲目类型编号 </summary>
        const string TRACKTYPEIDCLN = "TrackTypeID";
        /// <summary>艺术家编号 </summary>
        const string ARTISTIDCLN = "ArtistID";
        /// <summary>比特率 </summary>
        const string BITRATECLN = "BitRate";
        /// <summary>歌曲长度 </summary>
        const string TRACKTIMELENGTHCLN = "TrackTimeLength";
        #endregion

        #region 常量
        private ImportType importType;

        public enum ImportType
        {
            /// <summary>通过新下载的MP3 </summary>
            ByNewMP3,
            /// <summary>通过既有的MP3 </summary>
            ByOldMP3,
            /// <summary>通过Excel </summary>
            ByExcel,
        }

        DataGridViewStyle dgvStyle = new DataGridViewStyle();
        ImportMusicService service = new ImportMusicService();
        #endregion

        #region 变量
        /// <summary>
        /// Dataset
        /// </summary>
        MusicDataSet.ImportMusicListDataTable importList = new MusicDataSet.ImportMusicListDataTable();

        /// <summary>
        /// 新增艺术家匹配
        /// </summary>
        Dictionary<string, DataMappingType.Type> newArtistDic = new Dictionary<string, DataMappingType.Type>();
        #endregion

        #region 方法
        /// <summary>
        /// 导入音乐
        /// </summary>
        /// <param name="type">导入方式</param>
        /// <param name="musicPath">音乐路径数组</param>
        public ImportMusic(ImportType type, string[] musicPath)
        {
            InitializeComponent();
            importType = type;

            if (importType == ImportType.ByOldMP3)
            {
                MusicDataGridView.Columns[OLDTRACKNOCLN].Visible = true;
            }

            ShowMusicInfo(musicPath);
        }

        /// <summary>
        /// 展示导入的音乐
        /// </summary>
        /// <param name="musicPath">音乐路径数组</param>
        private void ShowMusicInfo(string[] musicPath)
        {
            for (int i = 0; i < musicPath.Length; i++)
            {
                if (!System.IO.File.Exists(musicPath[i]))
                {
                    MsgBox.Show(MSG_IMPORTMUSIC_001, musicPath[i]);
                    continue;
                }

                //------做成新曲目 开始------
                MusicDataSet.ImportMusicListRow importRow = importList.NewImportMusicListRow();

                //FilePath
                importRow.FilePath = musicPath[i];

                ID3V2Tag tag = new ID3V2Tag(importRow.FilePath);

                //TrackID 仮采番
                importRow.TrackID = service.GetNextTrackID();
                //AlbumID 仮采番
                importRow.AlbumID = service.GetAlbumIDFromAlbumTitleName(tag.AlbumName);
                //TrackTypeID
                //DiscNo
                importRow.DiscNo = tag.DiscNo;
                //TrackNo
                importRow.TrackNo = tag.TrackNo;
                //OldTrackNo

                //AlbumTitleName
                importRow.AlbumTitleName = tag.AlbumName;
                //TrackTitleName
                importRow.TrackTitleName = tag.TrackTitleName;
                //ArtistName
                importRow.ArtistName = tag.ArtistName;
                //ArtistID               
                //AnimeNo
                //SalesYear
                importRow.SalesYear = tag.SalesYear;
                //TrackLength
                importRow.TrackLength = tag.TrackLength;
                //BitRate
                importRow.BitRate = tag.BitRate;


                importList.AddImportMusicListRow(importRow);
            }

            importList.AcceptChanges();

            foreach (MusicDataSet.ImportMusicListRow ir in importList.Rows)
            {
                DataGridViewRow dr = MusicDataGridView.Rows[MusicDataGridView.Rows.Add()];

                dr.Cells[TRACKIDCLN].Value = ir.TrackID;
                if (ir.TrackTitleName != null)
                {
                    dr.Cells[TRACKNAMECLN].Value = ir.TrackTitleName;
                }
                dr.Cells[ALBUMIDCLN].Value = ir.AlbumID;
                if (ir.AlbumTitleName != null)
                {
                    dr.Cells[ALBUMNAMECLN].Value = ir.AlbumTitleName;
                }
                if (ir.ArtistName != null)
                {
                    dr.Cells[ARTISTNAMECLN].Value = ir.ArtistName;
                }
                if (ir.DiscNo != null)
                {
                    dr.Cells[DISCNOCLN].Value = ir.DiscNo;
                }
                if (ir.TrackNo != null)
                {
                    dr.Cells[TRACKNOCLN].Value = ir.TrackNo;
                }
                if (!ir.IsSalesYearNull())
                {
                    dr.Cells[YEARCLN].Value = ir.SalesYear;
                }
                if (!ir.IsDescriptionNull())
                {
                    dr.Cells[DESCRIPTIONCLN].Value = ir.Description;
                }
                if (!ir.IsBitRateNull())
                {
                    dr.Cells[BITRATECLN].Value = ir.BitRate;
                }
                if (!ir.IsTrackLengthNull())
                {
                    dr.Cells[TRACKTIMELENGTHCLN].Value = ir.TrackLength;
                }
                dr.Cells[RESOURCEPATHCLN].Value = ir.FilePath;

                //艺术家处理             
                //Todo：预留同名artist处理机制：复数artist
                int artistID = service.GetArtistIDFromArtistName(ir.ArtistName);
                if (artistID > 0)
                {
                    //不在dic,在DB中存在名称完全相同,加入dic
                    dr.Cells[ARTISTIDCLN].Value = artistID;
                }

                SetArtistCellStyle(dr.Cells[ARTISTNAMECLN], ir.ArtistName);

            }

            dgvStyle.SetDataGridViewColumnWidch(MusicDataGridView, new int[] { 
                120,    //OldTrackNo
                100,    //TrackNo
                200,    //TrackName
                80,    //TrackType
                100,    //AlbumNo
                200,    //AlbumName
                80,     //AlbumType
                200,    //ArtistName
                120,    //AnimeCHNName
                80,     //BitRate
                70,     //DiscNo
                70,     //TrackNo
                120,    //Year
                100,    //TrackLength
                300,    //ResourcePath
                200     //Description
            });

            string firstRowPath = null;

            if (MusicDataGridView.Rows.Count != 0)
            {
                firstRowPath = MusicDataGridView.Rows[0].Cells[RESOURCEPATHCLN].Value.ToString();

                ShowMP3TagInfo(firstRowPath);
            }
        }

        /// <summary>
        /// 接受选择框内选择动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectAnimeAccept(object sender, EventArgs e)
        {
            AbstractSelect target = (AbstractSelect)sender;       //接收到Form2的textBox1.Text     
            object targetkey = target.ReturnResult;

            this.MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[ANIMENOCLN].Value = (string)targetkey;
            this.MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[ANIMENAMECLN].Value =
                service.GetAnimeFromAnimeNo((string)targetkey).CNName;
        }

        /// <summary>
        /// 接受选择框内一并选择动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectAllAnimeAccept(object sender, EventArgs e)
        {
            AbstractSelect target = (AbstractSelect)sender;       //接收到Form2的textBox1.Text     
            object targetkey = target.ReturnResult;

            foreach (DataGridViewCell dc in MusicDataGridView.SelectedCells)
            {
                this.MusicDataGridView.Rows[dc.RowIndex].Cells[ANIMENOCLN].Value = (string)targetkey;
                this.MusicDataGridView.Rows[dc.RowIndex].Cells[ANIMENAMECLN].Value =
                    service.GetAnimeFromAnimeNo((string)targetkey).CNName;
            }
        }

        /// <summary>
        /// 接受选择框内选择专辑种类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectAlbumTypeAccept(object sender, EventArgs e)
        {
            AbstractSelect target = (AbstractSelect)sender;       
            object targetkey = target.ReturnResult;

            string AlbumName = MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[ALBUMNAMECLN].Value.ToString();
            string AlbumTypeName = service.GetAlbumTypeNameByAlbumTypeID(Convert.ToInt32(targetkey));

            this.MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[ALBUMTYPEIDCLN].Value = targetkey.ToString();
            this.MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[ALBUMANIMETYPECLN].Value = AlbumTypeName;
            
            //同名专辑一并设定
            foreach (DataGridViewRow dr in MusicDataGridView.Rows)
            {
                if (dr.Cells[ALBUMNAMECLN].Value.ToString().Equals(AlbumName))
                {
                    dr.Cells[ALBUMTYPEIDCLN].Value = targetkey.ToString();
                    dr.Cells[ALBUMANIMETYPECLN].Value = AlbumTypeName;
                }
            }
        }

        /// <summary>
        /// 接受选择框内选择曲目种类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectTrackTypeAccept(object sender, EventArgs e)
        {
            AbstractSelect target = (AbstractSelect)sender;       //接收到Form2的textBox1.Text     
            object targetkey = target.ReturnResult;

            this.MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[TRACKTYPEIDCLN].Value = targetkey.ToString();
            this.MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[TRACKTYPECLN].Value =
                service.GetTrackTypeNameByAlbumTypeID(Convert.ToInt32(targetkey));
        }

        /// <summary>
        /// 接受选择框内一并选择曲目种类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectAllTrackTypeAccept(object sender, EventArgs e)
        {
            AbstractSelect target = (AbstractSelect)sender;       //接收到Form2的textBox1.Text     
            object targetkey = target.ReturnResult;

            foreach (DataGridViewCell dc in MusicDataGridView.SelectedCells)
            {
                this.MusicDataGridView.Rows[dc.RowIndex].Cells[TRACKTYPEIDCLN].Value = targetkey.ToString();
                this.MusicDataGridView.Rows[dc.RowIndex].Cells[TRACKTYPECLN].Value =
                    service.GetTrackTypeNameByAlbumTypeID(Convert.ToInt32(targetkey));
            }


        }

        /// <summary>
        /// 接受作成的艺术家
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectArtistTypeAccept(object sender, EventArgs e)
        {
            SelectArtist target = (SelectArtist)sender;       //接收到Form2的textBox1.Text     
            object targetkey = target.ReturnResult;

            //正常返回
            if (Convert.ToInt32(targetkey.ToString()) > 0)
            {
                string oldArtistName = MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[ARTISTNAMECLN].Value.ToString();
                string artistName = service.GetArtistNameFromArtistID(Convert.ToInt32(targetkey.ToString()));

                this.MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[ARTISTIDCLN].Value = targetkey.ToString();
                this.MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[ARTISTNAMECLN].Value = artistName;

                if (newArtistDic.ContainsKey(artistName))
                {
                    newArtistDic[artistName] = DataMappingType.Type.ExistInDB;
                }
                else
                {
                    newArtistDic.Add(artistName, DataMappingType.Type.ExistInDB);
                }

                foreach (DataGridViewRow dr in MusicDataGridView.Rows)
                {
                    if (dr.Cells[ARTISTNAMECLN].Value.ToString().Equals(oldArtistName))
                    {
                        dr.Cells[ARTISTNAMECLN].Value = artistName;
                        dr.Cells[ARTISTIDCLN].Value = targetkey.ToString();
                    }

                    SetArtistCellStyle(dr.Cells[ARTISTNAMECLN], dr.Cells[ARTISTNAMECLN].Value.ToString());
                }
            }
                
        }

        /// <summary>
        /// 显示MP3Tag信息
        /// </summary>
        private void ShowMP3TagInfo()
        {
            if (GetSelectedRow() == null)
            {
                return;
            }

            int? selectedRowNo = GetSelectedRow().Index;

            if (selectedRowNo == null)
            {
                return;
            }
            string filePath = MusicDataGridView.Rows[(int)selectedRowNo].Cells[RESOURCEPATHCLN].Value.ToString();

            ShowMP3TagInfo(filePath);
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
        /// 显示指定路径的MP3Tag信息
        /// </summary>
        /// <param name="filePath">文件路径</param>
        private void ShowMP3TagInfo(string filePath)
        {
            if (filePath == null || filePath.ToString().Equals(string.Empty))
            {
                TrackNameTextBox.Text = string.Empty;
                ArtistTextBox.Text = string.Empty;
                AlbumNameTextBox.Text = string.Empty;
                TrackNoTextBox.Text = string.Empty;
                DiscNoTextBox.Text = string.Empty;
                coverPictureBox.Image = null;
                return;
            }

            try
            {
                ID3V2Tag tag = new ID3V2Tag(filePath);

                //封面
                foreach (Image img in tag.TrackImages)
                {
                    coverPictureBox.Image = img;
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
        /// 设置艺术家单元格样式
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="artistName"></param>
        private void SetArtistCellStyle(DataGridViewCell cell,string artistName)
        {
            if (newArtistDic.ContainsKey(artistName))
                {
                    //在dic中存在
                    switch (newArtistDic[artistName])
                    {
                        case DataMappingType.Type.New:
                            dgvStyle.SetMappingTypeBackColor(cell, DataMappingType.Type.New);
                            break;
                        case DataMappingType.Type.ExistInDB:
                            dgvStyle.SetMappingTypeBackColor(cell, DataMappingType.Type.ExistInDB);
                            break;
                        case DataMappingType.Type.LikeInDB:
                            dgvStyle.SetMappingTypeBackColor(cell, DataMappingType.Type.LikeInDB);
                            break;
                    }
                }
                else
                {
                    ArtistSeries artist = new ArtistSeries(artistName);
                    if (artist.Id > 0)
                    {
                        //不在dic,在DB中存在名称完全相同,加入dic
                        dgvStyle.SetMappingTypeBackColor(cell, DataMappingType.Type.ExistInDB);
                        newArtistDic.Add(artist.Name, DataMappingType.Type.ExistInDB);
                    }
                    else if (artist.IsFormattedNameExists() > 0)
                    {
                        //不在dic,在DB中存在名称整形后相同，需要匹配
                        dgvStyle.SetMappingTypeBackColor(cell, DataMappingType.Type.LikeInDB);
                        newArtistDic.Add(artist.Name, DataMappingType.Type.LikeInDB);
                    }
                    else
                    {
                        //不在DB->发番，加入dic
                        newArtistDic.Add(artist.Name, DataMappingType.Type.New);
                        dgvStyle.SetMappingTypeBackColor(cell, DataMappingType.Type.New);
                    }
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
                SetLabel();
                return;
            }

            MsgBox.Show(MSG_IMPORTMUSIC_002);
        }

        /// <summary>
        /// 保存成功信息可见
        /// </summary>
        private void SetLabel()
        {
            timer1.Enabled = false;
            tagsavesuccesslabel.Visible = true; 
            timer1.Interval = 3000;
            timer1.Enabled = true;
        }

        private void OnImportMusic()
        {
            List<AlbumSeries> AlbumSeries = new List<AlbumSeries>();
            List<TrackSeries> TrackSeries = new List<TrackSeries>();


            #region 专辑作成
            
            #endregion

            #region 曲目作成
            #endregion

            #region 资源作成
            #endregion
        }



        #endregion

        #region 事件
        /// <summary>
        /// 改变选中行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MusicDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowMP3TagInfo();
        }

        /// <summary>
        /// 单元格单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MusicDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == MusicDataGridView.Columns[ANIMENAMECLN].Index)
                {
                    if (MusicDataGridView.SelectedCells.Count == 1)
                    {
                        //动画名称
                        AbstractSelect animes = new AbstractSelect(CommonConst.TableName.T_ANIME_TBL, "ANIME_NO", "ANIME_CHN_NAME", true
                            , new string[] { "ANIME_NO", "ANIME_CHN_NAME", "ANIME_JPN_NAME", "ANIME_NN" });
                        animes.accept += new EventHandler(SelectAnimeAccept);
                        animes.ShowDialog(this);
                    }
                    else if (MusicDataGridView.SelectedCells.Count > 1)
                    {
                        //动画名称
                        AbstractSelect animes = new AbstractSelect(CommonConst.TableName.T_ANIME_TBL, "ANIME_NO", "ANIME_CHN_NAME", true
                            , new string[] { "ANIME_NO", "ANIME_CHN_NAME", "ANIME_JPN_NAME", "ANIME_NN" });
                        animes.accept += new EventHandler(SelectAllAnimeAccept);
                        animes.ShowDialog(this);
                    }
                }
                else if (e.ColumnIndex == MusicDataGridView.Columns[ALBUMANIMETYPECLN].Index)
                {
                    //专辑种类
                    AbstractSelect albumtype = new AbstractSelect(CommonConst.TableName.T_ALBUM_TYPE_MST, "ALBUM_TYPE_ID", "ALBUM_TYPE_NAME", false,
                        new string[] { "ALBUM_TYPE_NAME", "DESCRIPTION" });
                    albumtype.accept += new EventHandler(SelectAlbumTypeAccept);
                    albumtype.ShowDialog(this);
                }
                else if (e.ColumnIndex == MusicDataGridView.Columns[TRACKTYPECLN].Index)
                {
                    if (MusicDataGridView.SelectedCells.Count == 1)
                    {
                        //曲目种类
                        AbstractSelect trackType = new AbstractSelect(CommonConst.TableName.T_TRACK_TYPE_MST, "TRACK_TYPE_ID", "TRACK_TYPE_NAME", false,
                            new string[] { "TRACK_TYPE_NAME", "DESCRIPTION" });
                        trackType.accept += new EventHandler(SelectTrackTypeAccept);
                        trackType.ShowDialog(this);
                    }
                    else if (MusicDataGridView.SelectedCells.Count > 1)
                    {
                        //曲目种类
                        AbstractSelect trackType = new AbstractSelect(CommonConst.TableName.T_TRACK_TYPE_MST, "TRACK_TYPE_ID", "TRACK_TYPE_NAME", false,
                            new string[] { "TRACK_TYPE_NAME", "DESCRIPTION" });
                        trackType.accept += new EventHandler(SelectAllTrackTypeAccept);
                        trackType.ShowDialog(this);
                    }
                }
                else if (e.ColumnIndex == MusicDataGridView.Columns[ARTISTNAMECLN].Index)
                {
                    //艺术家
                    int currentRowIndex = MusicDataGridView.CurrentRow.Index;
                    DataGridViewRow dr = MusicDataGridView.Rows[currentRowIndex];
                    SelectArtist artSelForm = new SelectArtist(Convert.ToInt32(dr.Cells[ARTISTIDCLN].Value), dr.Cells[ARTISTNAMECLN].Value.ToString());
                    artSelForm.accept += new EventHandler(SelectArtistTypeAccept);
                    artSelForm.ShowDialog(this);
                }

            }
            catch(Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }

        }

        /// <summary>
        /// 保存成功信息不可见
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            tagsavesuccesslabel.Visible = false;
            timer1.Enabled = false;
        }

        #endregion

        #region 窗体

        /// <summary>
        /// 获取选中单元格所在行
        /// </summary>
        /// <returns></returns>
        public DataGridViewRow GetSelectedRow()
        {
            if (MusicDataGridView.SelectedCells.Count > 0)
            {
                DataGridViewRow dr = new DataGridViewRow();
                dr = MusicDataGridView.Rows[MusicDataGridView.SelectedCells[0].RowIndex];
                return dr;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 按键
        /// <summary>
        /// 导入音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportMusicButton_Click(object sender, EventArgs e)
        {
            OnImportMusic();
        }

        /// <summary>
        /// 保存ID3TAG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveID3TagButton_Click(object sender, EventArgs e)
        {
           OnSaveID3Tag();
        }
        #endregion

        

        

    }
}
