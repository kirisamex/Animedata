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
using Main.Lib.Style;
using Main.Lib.Message;
using Main.UILib;

namespace Main.Music
{
    public partial class EditMusic : Form
    {
        #region 常量

        #region 列名
        /// <summary>既有编号 </summary>
        const string OLDTRACKNOCLN = "OldTrackNo";
        /// <summary>曲号 </summary>
        const string TRACKIDCLN = "TrackID";
        /// <summary>曲名 </summary>
        const string TRACKNAMECLN = "TrackTitleName";
        /// <summary>曲目类型 </summary>
        const string TRACKTYPECLN = "TrackTypeName";
        /// <summary>艺术家 </summary>
        const string ARTISTNAMECLN = "ArtistName";
        /// <summary>动画名 </summary>
        const string ANIMENAMECLN = "AnimeName";
        /// <summary>碟号 </summary>
        const string DISCNOCLN = "DiscNo";
        /// <summary>音轨 </summary>
        const string TRACKNOCLN = "TrackNo";
        /// <summary>发售年份 </summary>
        const string YEARCLN = "Year";
        /// <summary>描述 </summary>
        const string DESCRIPTIONCLN = "Description";
        /// <summary>动画编号 </summary>
        const string ANIMENOCLN = "AnimeNO";
        /// <summary>曲目类型编号 </summary>
        const string TRACKTYPEIDCLN = "TrackTypeID";
        /// <summary>艺术家编号 </summary>
        const string ARTISTIDCLN = "ArtistID";
        #endregion

        #region 信息
        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        #endregion

        #endregion

        #region 构造
        public EditMusic(string AlbumID)
        {
            this.AlbumID = AlbumID;
            InitializeComponent();
        }
        #endregion

        #region 变量
        /// <summary>
        /// 对象专辑ID
        /// </summary>
        private string AlbumID;

        /// <summary>
        /// 服务
        /// </summary>
        EditMusicService service = new EditMusicService();

        /// <summary>
        /// 格式
        /// </summary>
        DataGridViewStyle style = new DataGridViewStyle();

        //MusicDataSet.AlbumInfoDataTable AlbumInfo = new MusicDataSet.AlbumInfoDataTable();
        MusicDataSet.TrackInfoDataTable TrackInfo = new MusicDataSet.TrackInfoDataTable();
        MusicDataSet.ArtistInfoDataTable ArtistInfo = new MusicDataSet.ArtistInfoDataTable();
        MusicDataSet.ResourceInfoDataTable ResourceInfo = new MusicDataSet.ResourceInfoDataTable();
        MusicDataSet.TrackResourceInfoDataTable TrackResourceInfo = new MusicDataSet.TrackResourceInfoDataTable();

        MusicDataSet.AlbumInfoDataTable AlbumCurInfo = new MusicDataSet.AlbumInfoDataTable();
        MusicDataSet.TrackInfoDataTable TrackCurInfo = new MusicDataSet.TrackInfoDataTable();
        MusicDataSet.ArtistInfoDataTable ArtistCurInfo = new MusicDataSet.ArtistInfoDataTable();
        MusicDataSet.ResourceInfoDataTable ResourceCurInfo = new MusicDataSet.ResourceInfoDataTable();
        #endregion

        #region 载入
        private void OnLoad()
        {
            try
            {
                TrackInfo.Clear();
                ArtistInfo.Clear();
                ResourceInfo.Clear();
                TrackResourceInfo.Clear();

                AlbumCurInfo.Clear();
                TrackCurInfo.Clear();
                ArtistCurInfo.Clear();
                ResourceCurInfo.Clear();

                //专辑信息
                DataTable album = service.GetAlbumInfo(AlbumID);
                foreach (DataRow dr in album.Rows)
                {
                    AlbumCurInfo.ImportRow(dr);
                }

                //曲目信息
                DataTable tracks = service.GetTrackInfoInAlbum(AlbumID);
                foreach (DataRow dr in tracks.Rows)
                {
                    TrackInfo.ImportRow(dr);
                }

                //艺术家信息
                DataTable artists = service.GetArtistInfoInAlbum(AlbumID);
                foreach (DataRow dr in artists.Rows)
                {
                    ArtistInfo.ImportRow(dr);
                }

                //资源信息
                DataTable resources = service.GetResourceInfoInAlbum(AlbumID);
                foreach (DataRow dr in resources.Rows)
                {
                    ResourceInfo.ImportRow(dr);
                }

                //资源匹配信息
                DataTable trackResources = service.GetTrackResourceInfoInAlbum(AlbumID);
                foreach (DataRow dr in trackResources.Rows)
                {
                    TrackResourceInfo.ImportRow(dr);
                }

                #region 绑定
                editMusicListBindingSource.DataSource = TrackInfo;

                resourceInfoBindingSource.DataSource = ResourceCurInfo;
                #endregion

                ShowDicDataGridViewInfo();

                #region 格式

                style.SetButtonSelectedColor(AlbumInfoButton, true);

                albumInfoDataGridView.Dock = DockStyle.Fill;
                trackInfoDataGridView.Dock = DockStyle.Fill;
                artistInfoDataGridView.Dock = DockStyle.Fill;
                resourceInfoDataGridView.Dock = DockStyle.Fill;
                LRCRichTextBox.Dock = DockStyle.Fill;

                albumInfoDataGridView.Visible = true;
                trackInfoDataGridView.Visible = false;
                artistInfoDataGridView.Visible = false;
                resourceInfoDataGridView.Visible = false;
                LRCRichTextBox.Visible = false;
                #endregion
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        private void OnCurrentCellChanged()
        {
            if (TrackDataGridView.CurrentCell != null && TrackDataGridView.Rows.Count > 0)
            {
                string targetTrackID = TrackDataGridView.Rows[TrackDataGridView.CurrentCell.RowIndex].Cells[TRACKIDCLN].Value.ToString();              

                ShowCurrentInfo(targetTrackID);
            }
        }

        private void OnUpdate()
        {
            //修改检查
            //格式检查
            //更新专辑
            //更新曲目
            
        }
        #endregion

        #region 方法

        /// <summary>
        /// 显示当前曲目信息
        /// </summary>
        /// <param name="TrackID"></param>
        private void ShowCurrentInfo(string TrackID)
        {
            TrackCurInfo.Clear();
            ArtistCurInfo.Clear();
            ResourceCurInfo.Clear();

            trackInfoDataGridView.Rows.Clear();
            artistInfoDataGridView.Rows.Clear();
            
            //选中曲目
            var targetTrack = from track in this.TrackInfo
                              where track.TrackID.Equals(TrackID)
                              select track;

            foreach (MusicDataSet.TrackInfoRow trackRow in targetTrack)
            {
                TrackCurInfo.ImportRow(trackRow);
            }

            //选中艺术家
            var targetArtist = from artist in this.ArtistInfo
                               join track in this.TrackInfo on artist.ArtistID equals track.ArtistID
                               where track.TrackID.Equals(TrackID)
                              select artist;

            foreach (MusicDataSet.ArtistInfoRow artistRow in targetArtist)
            {
                ArtistCurInfo.ImportRow(artistRow);
            }

            //选中资源
            var targetResource = from resource in this.ResourceInfo
                                 join trackresource in this.TrackResourceInfo on resource.ResourceID equals trackresource.ResourceID
                                 join track in this.TrackInfo on trackresource.TrackID equals track.TrackID
                                 where track.TrackID.Equals(TrackID) 
                                 select resource;

            foreach (MusicDataSet.ResourceInfoRow resourceRow in targetResource)
            {
                ResourceCurInfo.ImportRow(resourceRow);
            }
            
            //封面
            var targetMusic = from resource in this.ResourceCurInfo
                              where resource.ResourceTypeID.Equals("1")
                              select resource;

            foreach (MusicDataSet.ResourceInfoRow music in targetMusic)
            {
                ID3V2Tag tag = new ID3V2Tag(music.ResourcePath);

                foreach (Image img in tag.TrackImages)
                {
                    AlbumJacketBox.Image = img;
                    break;
                }
                break;
            }

            ShowDicDataGridViewInfo();
        }

        /// <summary>
        /// 显示列表匹配项内容
        /// </summary>
        private void ShowDicDataGridViewInfo()
        {
            albumInfoDataGridView.Rows.Clear();
            trackInfoDataGridView.Rows.Clear();
            artistInfoDataGridView.Rows.Clear();

            foreach (MusicDataSet.AlbumInfoRow adr in AlbumCurInfo)
            {
                style.AddDicDataGridView(albumInfoDataGridView, "Album", "AlbumID", "专辑编号", adr.AlbumID, true, true);
                style.AddDicDataGridView(albumInfoDataGridView, "Album", "AlbumTitleName", "专辑名", adr.AlbumTitleName, false, true);
                style.AddDicDataGridView(albumInfoDataGridView, "Album", "AlbumTypeID", "专辑种类ID", adr.AlbumTypeID, true, false);
                style.AddDicDataGridView(albumInfoDataGridView, "Album", "AlbumTypeName", "专辑种类", adr.AlbumTypeName, true, true, true);
                style.AddDicDataGridView(albumInfoDataGridView, "Album", "AnimeNo", "动画编号", adr.AnimeNo, true, false);
                style.AddDicDataGridView(albumInfoDataGridView, "Album", "AnimeName", "动画", adr.AnimeName, true, true, true);
                style.AddDicDataGridView(albumInfoDataGridView, "Album", "TotalDiscCount", "总碟数", adr.TotalDiscCount, false, true);
                style.AddDicDataGridView(albumInfoDataGridView, "Album", "TotalTrackCount", "总曲数", adr.TotalTrackCount, false, true);
                style.AddDicDataGridView(albumInfoDataGridView, "Album", "Description", "描述", adr.Description, false, true);

            }

            foreach (MusicDataSet.TrackInfoRow tdr in TrackCurInfo)
            {
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "TrackID", "曲目编号", tdr.TrackID, true, true);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "TrackTitleName", "曲名", tdr.TrackTitleName, false, true);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "TrackTypeId", "曲目类型ID", tdr.TrackTypeId, false, false);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "TrackTypeName", "曲目类型", tdr.TrackTypeName, true, true, true);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "ArtistID", "艺术家ID", tdr.ArtistID, false, false);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "ArtistName", "艺术家", tdr.ArtistName, true, true, true);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "AnimeNo", "动画编号", tdr.AnimeNo, false, false);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "AnimeName", "动画", tdr.AnimeName, true, true, true);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "DiscNo", "碟号", tdr.DiscNo, false, true);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "TrackNo", "曲号", tdr.TrackNo, false, true);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "SalesYear", "发售年", tdr.SalesYear, false, true);
                style.AddDicDataGridView(trackInfoDataGridView, "Track", "Description", "描述", tdr.Description, false, true);

            }

            foreach (MusicDataSet.ArtistInfoRow adr in ArtistCurInfo)
            {
                style.AddDicDataGridView(artistInfoDataGridView, "Artist", "ArtistID", "编号", adr.ArtistID, true, true);
                style.AddDicDataGridView(artistInfoDataGridView, "Artist", "ArtistName", "艺术家", adr.ArtistName, true, true);
                style.AddDicDataGridView(artistInfoDataGridView, "Artist", "Gender", "性别", adr.GenderName, true, true);
                style.AddDicDataGridView(artistInfoDataGridView, "Artist", "Members", "成员", adr.Members, true, true);
                style.AddDicDataGridView(artistInfoDataGridView, "Artist", "Description", "描述", adr.Description, true, true);
            }

        }

        /// <summary>
        /// 接受选择的艺术家
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectArtistAccept(object sender, EventArgs e)
        {
            SelectArtist target = (SelectArtist)sender;
            object targetkey = target.ReturnResult;

            //正常返回
            if (Convert.ToInt32(targetkey.ToString()) > 0)
            {
                ArtistSeries newartist = new ArtistSeries((int)targetkey);
                string oldArtistId = string.Empty;

                foreach (MusicDataSet.ArtistInfoRow oldartist in ArtistCurInfo.Rows)
                {
                    oldArtistId = oldartist.ArtistID;
                }

                //艺术家未变化
                if (oldArtistId.Equals(newartist.Id.ToString()))
                {
                    return;
                }
                //新艺术家不在DB中：错误，应在确认时即加入DB    
                else if (!newartist.IsIDExists())
                {
                    throw new Exception("未预料的艺术家编号：艺术家编号在数据库中不存在。");
                }
                //选中的艺术家原本即在DB中，或已加入DB
                else 
                {
                    bool isExistInArtistInfoFlg = false;
                    foreach (MusicDataSet.ArtistInfoRow artistRow in ArtistInfo.Rows)
                    {
                        if(artistRow.ArtistID.Contains(newartist.Id.ToString()))
                        {
                            isExistInArtistInfoFlg = true;
                        }
                    }

                    //未在ArtistInfo中
                    if (!isExistInArtistInfoFlg)
                    {
                        DataTable artists = service.GetArtistInfoInArtist(newartist.Id);
                        foreach (DataRow dr in artists.Rows)
                        {
                            ArtistInfo.ImportRow(dr);
                            ArtistInfo.AcceptChanges();
                            break;
                        }
                    }


                    var targetArtist = from artist in this.ArtistInfo
                                       where artist.ArtistID.Equals(newartist.Id.ToString())
                                       select artist;

                    foreach (MusicDataSet.ArtistInfoRow artistRow in targetArtist)
                    {
                        ArtistCurInfo.Clear();
                        ArtistCurInfo.ImportRow(artistRow);
                        ArtistCurInfo.AcceptChanges();
                        break;
                    }

                }

                //载入修改列表过程
                //1.获取当前曲目ID
                string curTrackId = string.Empty;

                foreach (MusicDataSet.TrackInfoRow track in TrackCurInfo.Rows)
                {
                    curTrackId = track.TrackID;
                    break;
                }

                //2.修改TrackInfo中对应信息
                foreach (MusicDataSet.TrackInfoRow track in TrackInfo.Rows)
                {
                    if (track.TrackID.Equals(curTrackId))
                    {
                        track.ArtistID = newartist.Id.ToString();
                        track.ArtistName = newartist.Name;
                        track.UpdateFlg = true;
                        break;
                    }
                }
                TrackInfo.AcceptChanges();

                //3.从TrackInfo获取当前曲目
                var targetTrack = from track in this.TrackInfo
                                  where track.TrackID.Equals(curTrackId)
                                  select track;

                TrackCurInfo.Clear();

                foreach (MusicDataSet.TrackInfoRow trackRow in targetTrack)
                {
                    TrackCurInfo.ImportRow(trackRow);
                    break;
                }
                TrackCurInfo.AcceptChanges();

                ShowDicDataGridViewInfo();
            }

        }

        /// <summary>
        /// 接受选择的曲目种类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectTrackTypeAccept(object sender, EventArgs e)
        {
            AbstractSelect target = (AbstractSelect)sender;
            object targetkey = target.ReturnResult;

            if (Convert.ToInt32(targetkey.ToString()) > 0)
            {
                //1.获取当前曲目ID
                string curTrackID = string.Empty;

                foreach (MusicDataSet.TrackInfoRow track in TrackCurInfo.Rows)
                {
                    curTrackID = track.TrackID;
                    break;
                }

                //2.修改TrackInfo中对应信息
                foreach (MusicDataSet.TrackInfoRow track in TrackInfo.Rows)
                {
                    if (track.TrackID.Equals(curTrackID))
                    {
                        track.TrackTypeId = targetkey.ToString();
                        track.TrackTypeName = service.GetTrackTypeNameByTrackTypeID(Convert.ToInt32(track.TrackTypeId));
                        track.UpdateFlg = true;
                        break;
                    }
                }
                TrackInfo.AcceptChanges();

                //3.从TrackInfo获取当前曲目
                var targetTrack = from track in this.TrackInfo
                                  where track.TrackID.Equals(curTrackID)
                                  select track;

                TrackCurInfo.Clear();

                foreach (MusicDataSet.TrackInfoRow trackRow in targetTrack)
                {
                    TrackCurInfo.ImportRow(trackRow);
                    break;
                }
                TrackCurInfo.AcceptChanges();

                ShowDicDataGridViewInfo();
            }

        }

        /// <summary>
        /// 接受选择的专辑种类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectAlbumTypeAccept(object sender, EventArgs e)
        {
            AbstractSelect target = (AbstractSelect)sender;
            object targetkey = target.ReturnResult;

            if (Convert.ToInt32(targetkey.ToString()) > 0)
            {
                //1.修改AlbumCurInfo中对应信息
                foreach (MusicDataSet.AlbumInfoRow album in AlbumCurInfo.Rows)
                {
                    album.AlbumTypeID = targetkey.ToString();
                    album.AlbumTypeName = service.GetAlbumTypeNameByAlbumTypeID(Convert.ToInt32(album.AlbumTypeID));
                    album.UpdateFlg = true;
                    break;
                }
                AlbumCurInfo.AcceptChanges();

                ShowDicDataGridViewInfo();
            }

        }

        /// <summary>
        /// 接受选择框内选择动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectAlbumAnimeAccept(object sender, EventArgs e)
        {
            AbstractSelect target = (AbstractSelect)sender;
            object targetkey = target.ReturnResult;

            foreach (MusicDataSet.AlbumInfoRow album in AlbumCurInfo.Rows)
            {
                album.AnimeNo = targetkey.ToString();
                album.AnimeName = service.GetAnimeFromAnimeNo(album.AnimeNo).CNName;
                album.UpdateFlg = true;
                break;
            }

            AlbumCurInfo.AcceptChanges();

            ShowDicDataGridViewInfo();

        }

        /// <summary>
        /// 接受选择框内选择动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectTrackAnimeAccept(object sender, EventArgs e)
        {
            AbstractSelect target = (AbstractSelect)sender;
            object targetkey = target.ReturnResult;

            //1.获取当前曲目ID
            string curTrackID = string.Empty;

            foreach (MusicDataSet.TrackInfoRow track in TrackCurInfo.Rows)
            {
                curTrackID = track.TrackID;
                break;
            }

            //2.修改TrackInfo中对应信息
            foreach (MusicDataSet.TrackInfoRow track in TrackInfo.Rows)
            {
                if (track.TrackID.Equals(curTrackID))
                {
                    track.AnimeNo = targetkey.ToString();
                    track.AnimeName = service.GetAnimeFromAnimeNo(track.AnimeNo).CNName;
                    track.UpdateFlg = true;
                    break;
                }
            }
            TrackInfo.AcceptChanges();

            //3.从TrackInfo获取当前曲目
            var targetTrack = from track in this.TrackInfo
                              where track.TrackID.Equals(curTrackID)
                              select track;

            TrackCurInfo.Clear();

            foreach (MusicDataSet.TrackInfoRow trackRow in targetTrack)
            {
                TrackCurInfo.ImportRow(trackRow);
                break;
            }
            TrackCurInfo.AcceptChanges();

            ShowDicDataGridViewInfo();

        }

        #endregion

        #region 事件
        private void EditMusic_Load(object sender, EventArgs e)
        {
            OnLoad();
        }
        
        private void AlbumInfoButton_Click(object sender, EventArgs e)
        {
            style.SetButtonSelectedColor(AlbumInfoButton, true);
            style.SetButtonSelectedColor(TrackInfoButton, false);
            style.SetButtonSelectedColor(ArtistInfoButton, false);
            style.SetButtonSelectedColor(ResourceInfoButton, false);
            style.SetButtonSelectedColor(LrcInfoButton, false);

            albumInfoDataGridView.Visible = true;
            trackInfoDataGridView.Visible = false;
            artistInfoDataGridView.Visible = false;
            resourceInfoDataGridView.Visible = false;
            LRCRichTextBox.Visible = false;
        }

        private void TrackInfoButton_Click(object sender, EventArgs e)
        {
            style.SetButtonSelectedColor(AlbumInfoButton, false);
            style.SetButtonSelectedColor(TrackInfoButton, true);
            style.SetButtonSelectedColor(ArtistInfoButton, false);
            style.SetButtonSelectedColor(ResourceInfoButton, false);
            style.SetButtonSelectedColor(LrcInfoButton, false);

            albumInfoDataGridView.Visible = false;
            trackInfoDataGridView.Visible = true;
            artistInfoDataGridView.Visible = false;
            resourceInfoDataGridView.Visible = false;
            LRCRichTextBox.Visible = false;
        }

        private void ArtistInfoButton_Click(object sender, EventArgs e)
        {
            style.SetButtonSelectedColor(AlbumInfoButton, false);
            style.SetButtonSelectedColor(TrackInfoButton, false);
            style.SetButtonSelectedColor(ArtistInfoButton, true);
            style.SetButtonSelectedColor(ResourceInfoButton, false);
            style.SetButtonSelectedColor(LrcInfoButton, false);

            albumInfoDataGridView.Visible = false;
            trackInfoDataGridView.Visible = false;
            artistInfoDataGridView.Visible = true;
            resourceInfoDataGridView.Visible = false;
            LRCRichTextBox.Visible = false;
        }

        private void ResourceInfoButton_Click(object sender, EventArgs e)
        {
            style.SetButtonSelectedColor(AlbumInfoButton, false);
            style.SetButtonSelectedColor(TrackInfoButton, false);
            style.SetButtonSelectedColor(ArtistInfoButton, false);
            style.SetButtonSelectedColor(ResourceInfoButton, true);
            style.SetButtonSelectedColor(LrcInfoButton, false);

            albumInfoDataGridView.Visible = false;
            trackInfoDataGridView.Visible = false;
            artistInfoDataGridView.Visible = false;
            resourceInfoDataGridView.Visible = true;
            LRCRichTextBox.Visible = false;
        }

        private void LrcInfoButton_Click(object sender, EventArgs e)
        {
            style.SetButtonSelectedColor(AlbumInfoButton, false);
            style.SetButtonSelectedColor(TrackInfoButton, false);
            style.SetButtonSelectedColor(ArtistInfoButton, false);
            style.SetButtonSelectedColor(ResourceInfoButton, false);
            style.SetButtonSelectedColor(LrcInfoButton, true);

            albumInfoDataGridView.Visible = false;
            trackInfoDataGridView.Visible = false;
            artistInfoDataGridView.Visible = false;
            resourceInfoDataGridView.Visible = false;
            LRCRichTextBox.Visible = true;
        }
        
        private void TrackDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            OnCurrentCellChanged();
        }
        
        private void trackInfoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == trackInfoDataGridView.Columns["Trackvalue"].Index)
            {
                int currentRowIndex = trackInfoDataGridView.CurrentRow.Index;
                DataGridViewRow dr = trackInfoDataGridView.Rows[currentRowIndex];
                if (dr.Cells["Trackkey"].Value.Equals("ArtistName"))
                {
                    foreach (MusicDataSet.ArtistInfoRow artist in ArtistCurInfo.Rows)
                    {
                        SelectArtist artSelForm = new SelectArtist(Convert.ToInt32(artist.ArtistID), artist.ArtistName);
                        artSelForm.accept += new EventHandler(SelectArtistAccept);
                        artSelForm.ShowDialog(this);
                        return;
                    }
                    
                }

                if (dr.Cells["Trackkey"].Value.Equals("TrackTypeName"))
                {
                    AbstractSelect trackType = new AbstractSelect(CommonConst.TableName.T_TRACK_TYPE_MST, CommonConst.ColumnName.TRACK_TYPE_ID, CommonConst.ColumnName.TRACK_TYPE_NAME, false,
                        new string[] { CommonConst.ColumnName.TRACK_TYPE_NAME, CommonConst.ColumnName.DESCRIPTION });
                    trackType.accept += new EventHandler(SelectTrackTypeAccept);
                    trackType.ShowDialog(this);
                    return;
                }

                if (dr.Cells["Trackkey"].Value.Equals("AnimeName"))
                {
                    AbstractSelect animes = new AbstractSelect(CommonConst.TableName.T_ANIME_TBL, CommonConst.ColumnName.ANIME_NO, CommonConst.ColumnName.ANIME_CHN_NAME, true
                            , new string[] { CommonConst.ColumnName.ANIME_NO, CommonConst.ColumnName.ANIME_CHN_NAME, CommonConst.ColumnName.ANIME_JPN_NAME, CommonConst.ColumnName.ANIME_NN });
                    animes.accept += new EventHandler(SelectTrackAnimeAccept);
                    animes.ShowDialog(this);
                    return;
                }
            }
        }

        private void albumInfoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == albumInfoDataGridView.Columns["Albumvalue"].Index)
            {
                int currentRowIndex = albumInfoDataGridView.CurrentRow.Index;
                DataGridViewRow dr = albumInfoDataGridView.Rows[currentRowIndex];

                if (dr.Cells["Albumkey"].Value.Equals("AlbumTypeName"))
                {
                    AbstractSelect albumtype = new AbstractSelect(CommonConst.TableName.T_ALBUM_TYPE_MST, CommonConst.ColumnName.ALBUM_TYPE_ID, CommonConst.ColumnName.ALBUM_TYPE_NAME, false,
                        new string[] { CommonConst.ColumnName.ALBUM_TYPE_NAME, CommonConst.ColumnName.DESCRIPTION });
                    albumtype.accept += new EventHandler(SelectAlbumTypeAccept);
                    albumtype.ShowDialog(this);
                    return;
                }

                if (dr.Cells["Albumkey"].Value.Equals("AnimeName"))
                {
                    AbstractSelect animes = new AbstractSelect(CommonConst.TableName.T_ANIME_TBL, CommonConst.ColumnName.ANIME_NO, CommonConst.ColumnName.ANIME_CHN_NAME, true
                            , new string[] { CommonConst.ColumnName.ANIME_NO, CommonConst.ColumnName.ANIME_CHN_NAME, CommonConst.ColumnName.ANIME_JPN_NAME, CommonConst.ColumnName.ANIME_NN });
                    animes.accept += new EventHandler(SelectAlbumAnimeAccept);
                    animes.ShowDialog(this);
                    return;
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            OnUpdate();
        }

        private void albumInfoDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == albumInfoDataGridView.Columns["Albumvalue"].Index)
            {
                int currentRowIndex = albumInfoDataGridView.CurrentRow.Index;
                DataGridViewRow dr = albumInfoDataGridView.Rows[currentRowIndex];

                if (dr.Cells["Albumkey"].Value.Equals("AlbumTitleName"))
                {

                    return;
                }
                else if (dr.Cells["Albumkey"].Value.Equals("TotalDiscCount"))
                {

                    return;
                }
                else if (dr.Cells["Albumkey"].Value.Equals("TotalTrackCount"))
                {

                    return;
                }
                else if (dr.Cells["Albumkey"].Value.Equals("Description"))
                {

                    return;
                }

                return;
                
            }
        }
        #endregion
    }
}
