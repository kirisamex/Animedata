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

        MusicManageService service = new MusicManageService();
        MusicDataSet.ImportMusicListDataTable importList = new MusicDataSet.ImportMusicListDataTable();

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
                importRow.ArtistName=tag.ArtistName;
                //ArtistID
                //importRow.ArtistID = service.GetArtistIDFromArtistName(tag.ArtistName);
                //AnimeNo

                //SalesYear
                importRow.SalesYear = tag.SalesYear;
                //Descrtiption

                importList.AddImportMusicListRow(importRow);
            }

            importList.AcceptChanges();

            foreach (MusicDataSet.ImportMusicListRow ir in importList.Rows)
            {
                DataGridViewRow dr = MusicDataGridView.Rows[MusicDataGridView.Rows.Add()];

                dr.Cells[TRACKIDCLN].Value = ir.TrackID;
                dr.Cells[TRACKNAMECLN].Value = ir.TrackTitleName;
                dr.Cells[ALBUMIDCLN].Value = ir.AlbumID;
                dr.Cells[ALBUMNAMECLN].Value = ir.AlbumTitleName;
                dr.Cells[ARTISTNAMECLN].Value = ir.ArtistName;
                dr.Cells[DISCNOCLN].Value = ir.DiscNo;
                dr.Cells[TRACKNOCLN].Value = ir.TrackNo;
                if (!ir.IsSalesYearNull())
                {
                    dr.Cells[YEARCLN].Value = ir.SalesYear;
                }
                if (!ir.IsDescriptionNull())
                {
                    dr.Cells[DESCRIPTIONCLN].Value = ir.Description;
                }
                dr.Cells[RESOURCEPATHCLN].Value = ir.FilePath;
            }

            dgvStyle.SetDataGridViewColumnWidch(MusicDataGridView, new int[] { 80, 80, 160, 80, 160, 80, 160, 120, 40, 40, 80, 300, 150 });

            string firstRowPath = null;

            if (MusicDataGridView.Rows.Count != 0)
            {
                firstRowPath = MusicDataGridView.Rows[0].Cells[RESOURCEPATHCLN].Value.ToString();

                ShowMP3TagInfo(firstRowPath);
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

        #endregion

        #region 事件
        private void MusicDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowMP3TagInfo();
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
    }
}
