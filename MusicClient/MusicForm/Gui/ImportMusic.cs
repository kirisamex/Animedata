using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicClient.MusicClientDataSet;
using MusicClient.MusicForm.Service;
using Lib.Lib;
using Lib.Lib.Class.Musics;
using Lib.Lib.Const;
using Lib.Lib.Format;
using Lib.Lib.Message;
using Lib.Lib.Tools;
using UILib.Style;
using UILib.AbstractForm;

namespace MusicClient.MusicForm.Gui
{
    public partial class ImportMusic : Form
    {
        #region 常量

        #region 信息
        /// <summary> 系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary> 指定的路径：{0} 不存在！\n{0}</summary>
        const string MSG_IMPORTMUSIC_001 = "MSG-IMPORTMUSIC-001";
        /// <summary> 修改标签时，必须仅选择一个单元格进行修改，请勿多选。</summary>
        const string MSG_IMPORTMUSIC_002 = "MSG-IMPORTMUSIC-002";
        /// <summary> 专辑 {0} 内曲目编号为 {1} 的曲目标题为空，请补充。</summary>
        const string MSG_IMPORTMUSIC_003 = "MSG-IMPORTMUSIC-003";
        /// <summary> 专辑编号 {0} 的专辑标题为空，请补充。</summary>
        const string MSG_IMPORTMUSIC_004 = "MSG-IMPORTMUSIC-004";
        /// <summary> 专辑 {0} 内曲目 {1} 的碟号为空，请补充。</summary>
        const string MSG_IMPORTMUSIC_005 = "MSG-IMPORTMUSIC-005";
        /// <summary> 专辑 {0} 内曲目 {1} 的碟号格式不正确，必须为半角数字！</summary>
        const string MSG_IMPORTMUSIC_006 = "MSG-IMPORTMUSIC-006";
        /// <summary> 专辑 {0} 内曲目 {1} 的音轨为空，请补充。</summary>
        const string MSG_IMPORTMUSIC_007 = "MSG-IMPORTMUSIC-007";
        /// <summary> 专辑 {0} 内曲目 {1} 的音轨格式不正确，必须为半角数字！</summary>
        const string MSG_IMPORTMUSIC_008 = "MSG-IMPORTMUSIC-008";
        /// <summary> 专辑 {0} 内曲目 {1} 的发售年份格式不正确，必须为半角数字年份。</summary>
        const string MSG_IMPORTMUSIC_009 = "MSG-IMPORTMUSIC-009";
        /// <summary> 专辑 {0} 内曲目 {1} 的专辑类型未选择，请补充。</summary>
        const string MSG_IMPORTMUSIC_010 = "MSG-IMPORTMUSIC-010";
        /// <summary> 专辑 {0} 内曲目 {1} 的曲目类型未选择，请补充。</summary>
        const string MSG_IMPORTMUSIC_011 = "MSG-IMPORTMUSIC-011";
        /// <summary> 专辑 {0} 内曲目 {1} 的艺术家内容未编辑完成，请补充。</summary>
        const string MSG_IMPORTMUSIC_012 = "MSG-IMPORTMUSIC-012";
        /// <summary> 专辑 {0} 内曲目 {1} 的所属动画未选择，请补充。 </summary>
        const string MSG_IMPORTMUSIC_013 = "MSG-IMPORTMUSIC-013";
        /// <summary> 文件{0}不存在！</summary>
        const string MSG_IMPORTMUSIC_014 = "MSG-IMPORTMUSIC-014";
        const string MSG_IMPORTMUSIC_015 = "MSG-IMPORTMUSIC-015";
        const string MSG_IMPORTMUSIC_016 = "MSG-IMPORTMUSIC-016";
        const string MSG_IMPORTMUSIC_017 = "MSG-IMPORTMUSIC-017";
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
        /// <summary>专辑类型 </summary>
        const string ALBUMTYPECLN = "AlbumAnimeType";
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

        DataGridViewStyle dgvStyle = new DataGridViewStyle();
        ImportMusicService service = new ImportMusicService();
        MainFormat format = new MainFormat();
        #endregion

        #region 变量
        /// <summary>
        /// 新增艺术家匹配
        /// </summary>
        Dictionary<string, DataMappingType.Type> newArtistDic = new Dictionary<string, DataMappingType.Type>();

        /// <summary>
        /// 导入数据类型
        /// </summary>
        private ImportMusicType.ImportType importType;

        #endregion

        #region 方法
        /// <summary>
        /// 导入音乐
        /// </summary>
        /// <param name="type">导入方式</param>
        /// <param name="musicPath">音乐路径数组</param>
        public ImportMusic(ImportMusicType.ImportType type, string[] musicPath)
        {
            InitializeComponent();
            importType = type;

            if (importType == ImportMusicType.ImportType.ByOldMP3)
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
            //导入列表
            MusicDataSet.ImportMusicListDataTable importList = new MusicDataSet.ImportMusicListDataTable();

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

            DataView dv = importList.DefaultView;
            dv.Sort = "AlbumID asc , DiscNo asc , TrackNo asc";
            MusicDataSet.ImportMusicListDataTable newImportList = new MusicDataSet.ImportMusicListDataTable();
            newImportList.Merge(dv.ToTable());

            foreach (MusicDataSet.ImportMusicListRow ir in newImportList.Rows)
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

                //MusicDataGridView.Sort(MusicDataGridView.Columns[ALBUMIDCLN], ListSortDirection.Ascending);
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
            this.MusicDataGridView.Rows[MusicDataGridView.CurrentCell.RowIndex].Cells[ALBUMTYPECLN].Value = AlbumTypeName;
            
            //同名专辑一并设定
            foreach (DataGridViewRow dr in MusicDataGridView.Rows)
            {
                if (dr.Cells[ALBUMNAMECLN].Value.ToString().Equals(AlbumName))
                {
                    dr.Cells[ALBUMTYPEIDCLN].Value = targetkey.ToString();
                    dr.Cells[ALBUMTYPECLN].Value = AlbumTypeName;
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
                service.GetTrackTypeNameByTrackTypeID(Convert.ToInt32(targetkey));
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
                    service.GetTrackTypeNameByTrackTypeID(Convert.ToInt32(targetkey));
            }


        }

        /// <summary>
        /// 接受作成的艺术家
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectArtistAccept(object sender, EventArgs e)
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

        private void OnImportMusic()
        {
            if (ImportMusicToDB())
            {
                //Todo:主界面操作
                this.Close();
            }
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

        /// <summary>
        /// 插入音乐信息
        /// </summary>
        /// <returns></returns>
        private bool ImportMusicToDB()
        {
            try
            {
                //格式检查
                if (!FormatCheck())
                {
                    return false;
                }

                //导入列表
                MusicDataSet.ImportMusicListDataTable resultList = new MusicDataSet.ImportMusicListDataTable();
                
                #region resultList作成
                foreach (DataGridViewRow dr in MusicDataGridView.Rows)
                {
                    //------做成需要导入的曲目 开始------
                    MusicDataSet.ImportMusicListRow resRow = resultList.NewImportMusicListRow();

                    //曲号
                    resRow.TrackID = dr.Cells[TRACKIDCLN].Value.ToString();
                    //曲名
                    resRow.TrackTitleName = dr.Cells[TRACKNAMECLN].Value.ToString().Trim();
                    //曲目类型
                    resRow.TrackTypeId = Convert.ToInt32(dr.Cells[TRACKTYPEIDCLN].Value);
                    //专辑号
                    resRow.AlbumID = dr.Cells[ALBUMIDCLN].Value.ToString();
                    //专辑名
                    resRow.AlbumTitleName = dr.Cells[ALBUMNAMECLN].Value.ToString().Trim();
                    //专辑类型
                    resRow.AlbumTypeID = Convert.ToInt32(dr.Cells[ALBUMTYPEIDCLN].Value);
                    //艺术家编号
                    resRow.ArtistID = Convert.ToInt32(dr.Cells[ARTISTIDCLN].Value);
                    //碟号
                    resRow.DiscNo = dr.Cells[DISCNOCLN].Value.ToString().Trim();
                    //音轨
                    resRow.TrackNo = dr.Cells[TRACKNOCLN].Value.ToString().Trim();
                    //发售年份
                    if (dr.Cells[YEARCLN].Value != null)
                    {
                        resRow.SalesYear = dr.Cells[YEARCLN].Value.ToString().Trim();
                    }
                    //资源路径
                    resRow.FilePath = dr.Cells[RESOURCEPATHCLN].Value.ToString();
                    //描述
                    if (dr.Cells[DESCRIPTIONCLN].Value != null)
                    {
                        resRow.Description = dr.Cells[DESCRIPTIONCLN].Value.ToString();
                    }
                    //动画编号
                    if (dr.Cells[ANIMENOCLN].Value != null)
                    {
                        resRow.AnimeNo = dr.Cells[ANIMENOCLN].Value.ToString();
                    }
                    //专辑类型编号
                    resRow.AlbumTypeID = Convert.ToInt32(dr.Cells[ALBUMTYPEIDCLN].Value);
                    //曲目类型编号
                    resRow.TrackTypeId = Convert.ToInt32(dr.Cells[TRACKTYPEIDCLN].Value);
                    //比特率
                    resRow.BitRate = dr.Cells[BITRATECLN].Value.ToString();
                    //歌曲长度
                    resRow.TrackLength = dr.Cells[TRACKTIMELENGTHCLN].Value.ToString();
                    //艺术家姓名
                    resRow.ArtistName = dr.Cells[ARTISTNAMECLN].Value.ToString();

                    resultList.Rows.Add(resRow);
                }

                resultList.AcceptChanges();
                #endregion

                //所有需要插入数据物理表对应的List
                List<AlbumSeries> AlbumSeriesList = new List<AlbumSeries>();
                //所有需要复制的资源，考虑到以后的专辑封面图预留
                List<ResourceSeries> ResourceToCopy = new List<ResourceSeries>();
                
                #region 所有信息作成

                var targetAlbum = (from v in resultList
                                   select new
                                   {
                                       v.AlbumID,
                                       v.AlbumTitleName,
                                       v.AlbumTypeID,
                                       v.AnimeNo
                                   }).Distinct().ToList();

                foreach (var albumInfo in targetAlbum)
                {
                    //专辑信息作成
                    AlbumSeries album = new AlbumSeries();

                    album.ID = albumInfo.AlbumID;
                    album.AlbumTitleName = albumInfo.AlbumTitleName;
                    album.AlbumTypeId = albumInfo.AlbumTypeID;
                    album.AnimeNo = albumInfo.AnimeNo;
                    album.InAnimeNo = service.GetNextInAnimeAlbumNo(album.ID, album.AlbumTypeId);

                    //计算总碟数：maxdiscno
                    var countdisc = (from discc in resultList
                                     select discc.DiscNo).Max();
                    album.TotalDiscCount = Convert.ToInt32(countdisc);

                    //计算总曲数：count
                    var counttrack = (from discc in resultList
                                      select discc.TrackID).Count();
                    album.TotalTrackCount = Convert.ToInt32(counttrack);

                    //曲目信息作成
                    var targetTrack = from v in resultList
                                      where v.AlbumID.Equals(album.ID)
                                      select v;
                    foreach (MusicDataSet.ImportMusicListRow ir in targetTrack)
                    {
                        //曲目基本信息
                        TrackSeries track = new TrackSeries();

                        track.ID = ir.TrackID;
                        track.PAlbumID = ir.AlbumID;
                        track.TrackTypeId = ir.TrackTypeId;
                        track.TrackTitleName = ir.TrackTitleName;
                        track.ArtistID = ir.ArtistID;
                        track.AnimeNo = ir.AnimeNo;
                        if (!string.IsNullOrEmpty(ir.SalesYear))
                        {
                            track.SalesYear = Convert.ToInt32(ir.SalesYear);
                        }
                        if (!string.IsNullOrEmpty(track.Description))
                        {
                            track.Description = ir.Description;
                        }

                        if (!string.IsNullOrEmpty(ir.DiscNo))
                        {
                            track.DiscNo = Convert.ToInt32(ir.DiscNo);
                        }
                        else
                        {
                            track.DiscNo = 0;
                        }
                        if (!string.IsNullOrEmpty(ir.TrackNo))
                        {
                            track.TrackNo = Convert.ToInt32(ir.TrackNo);
                        }
                        else
                        {
                            track.TrackNo = 0;
                        }

                        //既存音源文件
                        FileInfo MusicResource = new FileInfo(ir.FilePath);

                        if (!MusicResource.Exists)
                        {
                            MsgBox.Show(MSG_IMPORTMUSIC_014, MusicResource.FullName);
                        }

                        //曲目资源信息
                        //1.备份音源
                        ResourceSeries bakMusic = new ResourceSeries();

                        bakMusic.GetNewID();
                        bakMusic.TypeID = ResourceFile.Type.MUSIC_MP3_1;
                        bakMusic.StorageID = StorageID.Path.BAK_RESOURCE_BUCKET_101;
                        //sound.FilePath = null;
                        bakMusic.FileName = format.FileNameFormat(bakMusic.ID.ToString());
                        bakMusic.Suffix = ".mp3";
                        bakMusic.TrackBitRate = ir.BitRate;
                        bakMusic.TrackLength = format.GetSecondFromTime(ir.TrackLength);
                        bakMusic.objectFilePath = ir.FilePath;
                        track.AddResource(bakMusic);
                        ResourceToCopy.Add(bakMusic);

                        TrackResource bakMusicMap = new TrackResource();
                        bakMusicMap.ResourceID = bakMusic.ID;
                        bakMusicMap.TrackID = ir.TrackID;
                        track.AddMapping(bakMusicMap);

                        //2.主要音源
                        ResourceSeries mainMusic = new ResourceSeries();
                        mainMusic.GetNewID();
                        mainMusic.TypeID = ResourceFile.Type.MUSIC_MP3_1;
                        mainMusic.StorageID = StorageID.Path.MAIN_RESOURCE_BUCKET_201;
                        //..\@anime_no\@album_type_name\@album_title_name\@artistname_@tracktitlename.mp3
                        mainMusic.FilePath = format.FilePathFormat(ir.AnimeNo + "\\" + service.GetAlbumTypeNameByAlbumTypeID(ir.AlbumTypeID) + "\\" + ir.AlbumTitleName);
                        mainMusic.FileName = format.FileNameFormat(ir.ArtistName + "_" + ir.TrackTitleName);
                        mainMusic.Suffix = ".mp3";
                        mainMusic.TrackBitRate = ir.BitRate;
                        mainMusic.TrackLength = format.GetSecondFromTime(ir.TrackLength);
                        mainMusic.objectFilePath = ir.FilePath;
                        track.AddResource(mainMusic);
                        ResourceToCopy.Add(mainMusic);

                        TrackResource mainMusicMap = new TrackResource();
                        mainMusicMap.ResourceID = mainMusic.ID;
                        mainMusicMap.TrackID = ir.TrackID;
                        track.AddMapping(mainMusicMap);

                        //歌词文件存否判断
                        string Directory = MusicResource.DirectoryName;
                        string ResourceName = Path.GetFileNameWithoutExtension(MusicResource.Name);
                        string LrcFullPath = Directory + "\\" + ResourceName + ".lrc";
                        FileInfo LrcResource = new FileInfo(LrcFullPath);

                        if (LrcResource.Exists)
                        {
                            //3.备份歌词
                            ResourceSeries bakLrc = new ResourceSeries();

                            bakLrc.GetNewID();
                            bakLrc.TypeID = ResourceFile.Type.LYRIC_LRC_201;
                            bakLrc.StorageID = StorageID.Path.BAK_RESOURCE_BUCKET_101;
                            //sound.FilePath = null;
                            bakLrc.FileName = format.FileNameFormat(bakLrc.ID.ToString());
                            bakLrc.Suffix = ".lrc";
                            bakLrc.objectFilePath = ir.FilePath;
                            track.AddResource(bakLrc);
                            ResourceToCopy.Add(bakLrc);

                            TrackResource bakLrcMap = new TrackResource();
                            bakLrcMap.ResourceID = bakLrc.ID;
                            bakLrcMap.TrackID = LrcFullPath;
                            track.AddMapping(bakLrcMap);

                            //4.主要歌词
                            ResourceSeries mainLrc = new ResourceSeries();
                            mainLrc.GetNewID();
                            mainLrc.TypeID = ResourceFile.Type.LYRIC_LRC_201;
                            mainLrc.StorageID = StorageID.Path.MAIN_RESOURCE_BUCKET_201;
                            //..\@anime_no\@album_type_name\@album_title_name\@artistname_@tracktitlename.lrc
                            mainLrc.FilePath = format.FilePathFormat(ir.AnimeNo + "\\" + service.GetAlbumTypeNameByAlbumTypeID(ir.AlbumTypeID) + "\\" + ir.AlbumTitleName);
                            mainLrc.FileName = format.FileNameFormat(ir.ArtistName + "_" + ir.TrackTitleName);
                            mainLrc.objectFilePath = LrcFullPath;
                            track.AddResource(mainLrc);
                            ResourceToCopy.Add(mainLrc);

                            TrackResource mainLrcMap = new TrackResource();
                            mainLrcMap.ResourceID = mainLrc.ID;
                            mainLrcMap.TrackID = ir.TrackID;
                            track.AddMapping(mainLrcMap);
                        }

                        album.AddTracks(track);
                    }
                    AlbumSeriesList.Add(album);
                }
                #endregion

                #region DB操作

                foreach (AlbumSeries album in AlbumSeriesList)
                {
                    album.Insert();
                }

                #endregion

                #region 文件操作

                foreach (ResourceSeries resource in ResourceToCopy)
                {
                    string DirPath = service.GetResourceDirectoryPath(resource.StorageID, resource.FilePath);
                    if (!Directory.Exists(DirPath))
                    {
                        Directory.CreateDirectory(DirPath);
                    }

                    string targetPath = service.GetResourcePath(resource.StorageID, resource.FilePath, resource.FileName, resource.Suffix);
                    File.Copy(resource.objectFilePath, targetPath);
                }

                #endregion
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
                return false;
            }
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
                if(dr.Cells[TRACKIDCLN].Value == null ||string.IsNullOrEmpty(dr.Cells[TRACKIDCLN].Value.ToString()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKIDCLN];
                    MsgBox.Show(MSG_COMMON_001,"INFO:TRACK_ID IS NULL OR EMPTY");
                    return false;
                }

                //ALBUM_ID非空
                if(dr.Cells[ALBUMIDCLN].Value == null ||string.IsNullOrEmpty(dr.Cells[ALBUMIDCLN].Value.ToString()))
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
                    MsgBox.Show(MSG_IMPORTMUSIC_003, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKIDCLN].Value.ToString());
                    return false;
                }

                //AlbumName
                if (dr.Cells[ALBUMNAMECLN].Value == null || string.IsNullOrEmpty(dr.Cells[ALBUMNAMECLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[ALBUMNAMECLN];
                    MsgBox.Show(MSG_IMPORTMUSIC_004, dr.Cells[ALBUMNAMECLN].Value.ToString());
                    return false;
                }

                //AnimeName
                if (dr.Cells[ANIMENAMECLN].Value == null || string.IsNullOrEmpty(dr.Cells[ANIMENAMECLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[ANIMENAMECLN];
                    MsgBox.Show(MSG_IMPORTMUSIC_013, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //DiscNo
                if (dr.Cells[DISCNOCLN].Value == null || string.IsNullOrEmpty(dr.Cells[DISCNOCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[DISCNOCLN];
                    MsgBox.Show(MSG_IMPORTMUSIC_005, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }
                else if (!format.IsNumber(dr.Cells[DISCNOCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[DISCNOCLN];
                    MsgBox.Show(MSG_IMPORTMUSIC_006, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //TrackNo
                if (dr.Cells[TRACKNOCLN].Value == null || string.IsNullOrEmpty(dr.Cells[TRACKNOCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKNOCLN];
                    MsgBox.Show(MSG_IMPORTMUSIC_007, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }
                else if (!format.IsNumber(dr.Cells[TRACKNOCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKNOCLN];
                    MsgBox.Show(MSG_IMPORTMUSIC_008, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //Year
                if (dr.Cells[YEARCLN].Value != null && !service.YYYYFormatCheck(dr.Cells[YEARCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[YEARCLN];
                    MsgBox.Show(MSG_IMPORTMUSIC_008, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
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
                    MsgBox.Show(MSG_IMPORTMUSIC_010, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //TrackTypeID
                if (dr.Cells[TRACKTYPEIDCLN].Value == null || string.IsNullOrEmpty(dr.Cells[TRACKTYPEIDCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[TRACKTYPECLN];
                    MsgBox.Show(MSG_IMPORTMUSIC_011, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //ArtistID
                if (dr.Cells[ARTISTIDCLN].Value == null || string.IsNullOrEmpty(dr.Cells[ARTISTIDCLN].Value.ToString().Trim()))
                {
                    MusicDataGridView.CurrentCell = dr.Cells[ARTISTNAMECLN];
                    MsgBox.Show(MSG_IMPORTMUSIC_012, dr.Cells[ALBUMNAMECLN].Value.ToString(), dr.Cells[TRACKNAMECLN].Value.ToString());
                    return false;
                }

                //放送时间格式检查
                //目前放送时间不可编辑，直接从文件Shell32中取出，不做检查

            }
            return true;
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
                        AbstractSelect animes = new AbstractSelect(CommonConst.TableName.T_ANIME_TBL, CommonConst.ColumnName.ANIME_NO, CommonConst.ColumnName.ANIME_CHN_NAME, true
                            , new string[] { CommonConst.ColumnName.ANIME_NO, CommonConst.ColumnName.ANIME_CHN_NAME, CommonConst.ColumnName.ANIME_JPN_NAME, CommonConst.ColumnName.ANIME_NN });
                        animes.accept += new EventHandler(SelectAnimeAccept);
                        animes.ShowDialog(this);
                    }
                    else if (MusicDataGridView.SelectedCells.Count > 1)
                    {
                        //动画名称
                        AbstractSelect animes = new AbstractSelect(CommonConst.TableName.T_ANIME_TBL, CommonConst.ColumnName.ANIME_NO, CommonConst.ColumnName.ANIME_CHN_NAME, true
                            , new string[] { CommonConst.ColumnName.ANIME_NO, CommonConst.ColumnName.ANIME_CHN_NAME, CommonConst.ColumnName.ANIME_JPN_NAME, CommonConst.ColumnName.ANIME_NN });
                        animes.accept += new EventHandler(SelectAllAnimeAccept);
                        animes.ShowDialog(this);
                    }
                }
                else if (e.ColumnIndex == MusicDataGridView.Columns[ALBUMTYPECLN].Index)
                {
                    //专辑种类
                    AbstractSelect albumtype = new AbstractSelect(CommonConst.TableName.T_ALBUM_TYPE_MST, CommonConst.ColumnName.ALBUM_TYPE_ID, CommonConst.ColumnName.ALBUM_TYPE_NAME, false,
                        new string[] { CommonConst.ColumnName.ALBUM_TYPE_NAME, CommonConst.ColumnName.DESCRIPTION });
                    albumtype.accept += new EventHandler(SelectAlbumTypeAccept);
                    albumtype.ShowDialog(this);
                }
                else if (e.ColumnIndex == MusicDataGridView.Columns[TRACKTYPECLN].Index)
                {
                    if (MusicDataGridView.SelectedCells.Count == 1)
                    {
                        //曲目种类
                        AbstractSelect trackType = new AbstractSelect(CommonConst.TableName.T_TRACK_TYPE_MST, CommonConst.ColumnName.TRACK_TYPE_ID, CommonConst.ColumnName.TRACK_TYPE_NAME, false,
                            new string[] { CommonConst.ColumnName.TRACK_TYPE_NAME, CommonConst.ColumnName.DESCRIPTION });
                        trackType.accept += new EventHandler(SelectTrackTypeAccept);
                        trackType.ShowDialog(this);
                    }
                    else if (MusicDataGridView.SelectedCells.Count > 1)
                    {
                        //曲目种类
                        AbstractSelect trackType = new AbstractSelect(CommonConst.TableName.T_TRACK_TYPE_MST, CommonConst.ColumnName.TRACK_TYPE_ID, CommonConst.ColumnName.TRACK_TYPE_NAME, false,
                            new string[] { CommonConst.ColumnName.TRACK_TYPE_NAME, CommonConst.ColumnName.DESCRIPTION });
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
                    artSelForm.accept += new EventHandler(SelectArtistAccept);
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
