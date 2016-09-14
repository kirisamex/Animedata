using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main.Lib.Style;

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
        #endregion

        #region 方法
        private void OnLoad()
        {
            DataTable TrackInfo = service.GetTrackInfoInAlbum(AlbumID);

            editMusicListBindingSource.DataSource = TrackInfo;
            style.SetButtonSelectedColor(AlbumInfoButton, true);
            
        }

        private void OnCurrentCellChanged()
        {
            if(TrackDataGridView.CurrentCell!=null)
            {
                string targetTrackID = TrackDataGridView.Rows[TrackDataGridView.CurrentCell.RowIndex].Cells[TRACKIDCLN].Value.ToString();

                //Artist todo :1.artistds 列整合; 2 其余三个dgv
                DataSet artistDs
            }
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
        }

        private void TrackInfoButton_Click(object sender, EventArgs e)
        {
            style.SetButtonSelectedColor(AlbumInfoButton, false);
            style.SetButtonSelectedColor(TrackInfoButton, true);
            style.SetButtonSelectedColor(ArtistInfoButton, false);
            style.SetButtonSelectedColor(ResourceInfoButton, false);
            style.SetButtonSelectedColor(LrcInfoButton, false);
        }

        private void ArtistInfoButton_Click(object sender, EventArgs e)
        {
            style.SetButtonSelectedColor(AlbumInfoButton, false);
            style.SetButtonSelectedColor(TrackInfoButton, false);
            style.SetButtonSelectedColor(ArtistInfoButton, true);
            style.SetButtonSelectedColor(ResourceInfoButton, false);
            style.SetButtonSelectedColor(LrcInfoButton, false);
        }

        private void ResourceInfoButton_Click(object sender, EventArgs e)
        {
            style.SetButtonSelectedColor(AlbumInfoButton, false);
            style.SetButtonSelectedColor(TrackInfoButton, false);
            style.SetButtonSelectedColor(ArtistInfoButton, false);
            style.SetButtonSelectedColor(ResourceInfoButton, true);
            style.SetButtonSelectedColor(LrcInfoButton, false);
        }

        private void LrcInfoButton_Click(object sender, EventArgs e)
        {
            style.SetButtonSelectedColor(AlbumInfoButton, false);
            style.SetButtonSelectedColor(TrackInfoButton, false);
            style.SetButtonSelectedColor(ArtistInfoButton, false);
            style.SetButtonSelectedColor(ResourceInfoButton, false);
            style.SetButtonSelectedColor(LrcInfoButton, true);
        }
        
        private void TrackDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
