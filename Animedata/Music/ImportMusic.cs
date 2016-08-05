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

namespace Main.Music
{
    public partial class ImportMusic : Form
    {
        #region 信息
        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>指定的路径：{0} 不存在！\n{0}</summary>
        const string MSG_IMPORTMUSIC_001 = "MSG-IMPORTMUSIC-001";
        #endregion 

        MusicManageService service = new MusicManageService();
        MusicDataSet.ImportMusicListDataTable importList = new MusicDataSet.ImportMusicListDataTable();

        #region 列名
        /// <summary>既有编号 </summary>
        const string OLDTRACKNOCLN = "OldTrackNo";
        /// <summary>曲名 </summary>
        const string TRACKNAMECLN = "TrackName";
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
        #endregion

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="musicPath"></param>
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
        /// 
        /// </summary>
        /// <param name="musicPath"></param>
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
                
                //TrackTitleName
                importRow.TrackTitleName = tag.TrackTitleName;
                //ArtistID
                importRow.ArtistID = service.GetArtistIDFromArtistName(tag.ArtistName);
                //AnimeNo

                //SalesYear
                importRow.SalesYear = tag.SalesYear;
                //Descrtiption

                //专辑
                //AlbumNameTextBox.Text = tag.AlbumName;
                //TrackNoTextBox.Text = tag.TrackNo;
                //DiscNoTextBox.Text = tag.DiscNo;
            }
        }
    }
}
