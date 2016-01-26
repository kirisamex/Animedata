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
using Shell32;

namespace Main.Music
{
    public partial class MusicManage : Form
    {
        MusicManageService service = new MusicManageService();

        public MusicManage()
        {
            InitializeComponent();
        }

        private void MusicManage_Load(object sender, EventArgs e)
        {
            ShowMusic();
        }

        private void ShowMusic()
        {
            DataSet ds = service.GetMusic();
            LoadMusicMain(ds);
        }

        public void LoadMusicMain(DataSet ds)
        {
            MusicDataGridView.Rows.Clear();

            DataTable musicdt = ds.Tables[0];

            for (int i = 0; i < musicdt.Rows.Count; i++)
            {
                MusicDataGridView.Rows.Add();

                DataGridViewRow dgvrow = MusicDataGridView.Rows[i];

                //曲名
                dgvrow.Cells[0].Value = musicdt.Rows[i][0].ToString();

                //专辑
                dgvrow.Cells[1].Value = musicdt.Rows[i][1].ToString().Trim();

                //演唱者
                dgvrow.Cells[2].Value = musicdt.Rows[i][2].ToString();

                //所属动画
                dgvrow.Cells[3].Value = musicdt.Rows[i][3].ToString();

                //碟号
                dgvrow.Cells[4].Value = musicdt.Rows[i][4].ToString();

                //音轨
                dgvrow.Cells[5].Value = musicdt.Rows[i][5].ToString();

                //发售年份
                dgvrow.Cells[6].Value = musicdt.Rows[i][6].ToString();

                //资源地址
                dgvrow.Cells[7].Value = musicdt.Rows[i][7].ToString();

                //描述
                dgvrow.Cells[8].Value = musicdt.Rows[i][8].ToString();
            }

            //动画窗口格式设置
            for (int i = 0; i < MusicDataGridView.ColumnCount; i++)
            {
                MusicDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                MusicDataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            //----test
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MP3 Files(.mp3)|*.mp3|WMA Files(*.wma)|*.WMA|ALL Files(*.*)|*.*";
            ofd.Multiselect = true;         //允许多选  
            ofd.RestoreDirectory = true;    //记住上一次的文件路径  
            ofd.ShowDialog();               //显示打开文件的窗口  
            string filePath = ofd.FileName;        //获取文件的完整的路径  

            FileInfo fInfo = new FileInfo(filePath);

            ShellClass sh = new ShellClass();
            Folder dir = sh.NameSpace(Path.GetDirectoryName(filePath));
            FolderItem item = dir.ParseName(Path.GetFileName(filePath));
            StringBuilder sb = new StringBuilder();

            TrackNameTextBox.Text = dir.GetDetailsOf(item, 21);
            ArtistTextBox.Text = dir.GetDetailsOf(item, 13);
            AlbumNameTextBox.Text = dir.GetDetailsOf(item, 14);
            TrackNoTextBox.Text = dir.GetDetailsOf(item, 26);
        }
    }
}
