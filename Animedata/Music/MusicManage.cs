using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
