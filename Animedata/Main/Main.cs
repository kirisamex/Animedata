using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Main
{
    public partial class Main : Form
    {
        #region 常量
        /// <summary>
        /// 版本号设置
        /// </summary>
        string Version =  "Ver. " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// 选中行
        /// </summary>
        public string selectedRowID;

        /// <summary>
        /// DAO
        /// </summary>
        Maindao dao = new Maindao();

        MainService service = new MainService();

        AddAnimeService addanimeservice = new AddAnimeService();

        /// <summary>
        /// 文字
        /// </summary>
        const string DELETEANIMEINFO = "删除动画信息";

        /// <summary>
        /// 文字
        /// </summary>
        const string ERROR = "错误：";

        /// <summary>
        /// 文字
        /// </summary>
        const string ERRORINFO = "错误信息";

        #endregion

        #region 载入
        /// <summary>
        /// 主窗口载入动画操作
        /// </summary>
        public void LoadAnime()
        {
            try
            {
                //获取动画信息
                DataSet ds = service.LoadAnime();

                AnimeDataGridview.DataSource = ds.Tables[0].DefaultView;

                //动画窗口格式设置
                for (int i = 0; i < AnimeDataGridview.ColumnCount; i++)
                {
                    AnimeDataGridview.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    AnimeDataGridview.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                foreach (DataGridViewRow dr in AnimeDataGridview.Rows)
                {
                    int status = service.GetStatusIntFromStatusText(dr.Cells[4].Value.ToString());

                    switch(status)
                    {
                        case 1:
                            dr.DefaultCellStyle.ForeColor = Color.Green;
                            break;
                        case 2:
                            dr.DefaultCellStyle.ForeColor = Color.Green;
                            break;
                        case 9:
                            dr.DefaultCellStyle.BackColor = Color.Green;
                            break;
                    }
                }


                string firstRowAnimeNo = null;

                if (ds.Tables[0].Rows.Count != 0)
                {
                    firstRowAnimeNo = ds.Tables[0].Rows[0][0].ToString();

                    //获取播放信息
                    ShowAnimeInfo(firstRowAnimeNo);

                    //获取角色信息
                    ShowCharacterInfo(firstRowAnimeNo);
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// 获得动画播放信息
        /// </summary>
        /// <param name="animeNo"></param>
        public void ShowAnimeInfo(string animeNo)
        {
            try
            {
                dataGridView2.Rows.Clear();

                //获得动画播放信息
                Animation anime = addanimeservice.GetAnimeFromAnimeNo(animeNo);

                try
                {
                    if (anime.playInfoList != null)
                    {
                        for (int i = 0; i < anime.playInfoList.Count; i++)
                        {
                            PlayInfo pInfo = anime.playInfoList[i];

                            dataGridView2.Rows.Add();

                            DataGridViewRow dgvrow = dataGridView2.Rows[i];

                            dgvrow.Cells[0].Value = pInfo.info;

                            if (pInfo.parts != 0)
                            {
                                dgvrow.Cells[1].Value = pInfo.parts.ToString();
                            }

                            if (pInfo.companyID != 0)
                            {
                                dgvrow.Cells[2].Value = addanimeservice.GetCompanyNameByCompanyNo(pInfo.companyID);
                            }

                            dgvrow.Cells[3].Value = addanimeservice.GetStatusTextFromStatusInt(pInfo.status);

                            if (pInfo.startTime != DateTime.MinValue && pInfo.startTime != DateTime.MaxValue)
                            {
                                dgvrow.Cells[4].Value = addanimeservice.ConvertToYYYYNianMMYueFromDatetime(pInfo.startTime);
                            }

                            if (pInfo.watchedTime != DateTime.MinValue && pInfo.watchedTime != DateTime.MaxValue)
                            {
                                dgvrow.Cells[5].Value = addanimeservice.ConvertToYYYYNianMMYueFromDatetime(pInfo.watchedTime);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //DGV2格式设置
                //dataGridView2.DataSource = ds.Tables[0].DefaultView;

                foreach(DataGridViewColumn dc in dataGridView2.Columns)
                {
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// 获得动画角色信息
        /// </summary>
        /// <param name="animeNo"></param>
        public void ShowCharacterInfo(string animeNo)
        {
            try
            {
                DataSet ds = dao.LoadCharacterInfo(animeNo);

                //DGV3格式设置
                dataGridView3.DataSource = ds.Tables[0].DefaultView;
                for (int i = 0; i < dataGridView3.ColumnCount; i++)
                {
                    dataGridView3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView3.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        #endregion

        #region 服务

        /// <summary>
        /// 获取选中单元格所在行
        /// </summary>
        /// <returns></returns>
        public DataGridViewRow GetSelectedRow()
        {
            DataGridViewRow dr = AnimeDataGridview.Rows[AnimeDataGridview.SelectedCells[0].RowIndex];

            return dr;
        }

        /// <summary>
        /// 获得选中单元格所在行的AnimeNo列表，用于删除
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelectedRowsAnimeNoList()
        {

            List<string> selectedAnimeNoList = new List<string>();

            for (int i = 0; i < AnimeDataGridview.SelectedCells.Count; i++)
            {
                string currentrowalbumNo = AnimeDataGridview.Rows[AnimeDataGridview.SelectedCells[i].RowIndex].Cells["编号"].Value.ToString();

                if (selectedAnimeNoList.Contains(currentrowalbumNo))
                {
                    continue;
                }
                selectedAnimeNoList.Add(currentrowalbumNo);
            }

            return selectedAnimeNoList;
        }

        /// <summary>
        /// 删除选中单元格所在行的动画、角色、播放信息
        /// </summary>
        public void DeleteSelectedRowsAnimeInfo()
        {
            if (AnimeDataGridview.SelectedCells.Count == 0)
            {
                MessageBox.Show("没有选中任何一行数据！", DELETEANIMEINFO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult res = MessageBox.Show("确定删除选中行信息吗？\n注意：这些信息对应的播放信息与角色信息将一并被删除。",
                                                          DELETEANIMEINFO, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (res == DialogResult.OK)
            {
                try
                {
                    List<string> SelectedRowsAnimeNoList = GetSelectedRowsAnimeNoList();
                    foreach (string animeNo in SelectedRowsAnimeNoList)
                    {
                        Animation anime = new Animation(animeNo);
                        anime.Delete();
                    }

                    MessageBox.Show("删除成功！", DELETEANIMEINFO, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DataGridViewReload();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region 窗体

        /// <summary>
        /// 
        /// </summary>
        public Main()
        {
            InitializeComponent();
            this.Text += Version;
            this.LoadAnime();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAnime();
        }

        /// <summary>
        /// 重新载入动画窗体
        /// </summary>
        public void DataGridViewReload()
        {
            this.LoadAnime();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 菜单

        /// <summary>
        /// 菜单栏：刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAnime();
        }

        /// <summary>
        /// 菜单栏：退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 菜单栏：添加动画信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加动画信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAnime fm = new AddAnime(0, null, this);
            fm.Show();
            //this.LoadAnime();
        }

        /// <summary>
        /// 菜单栏：修改动画信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改动画信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAnime cgem = new AddAnime(1, GetSelectedRow(), this);
            cgem.Show();
        }

        /// <summary>
        /// 菜单栏：删除动画信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除动画信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedRowsAnimeInfo();
        }

        private void 动画制作企业列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyManage fm = new CompanyManage(this);
            fm.Show();
        }

        private void 声优列表SF3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CVManage fm = new CVManage();
            fm.Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }
        #endregion

        #region 按键

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowNo = GetSelectedRow().Index;
            string animeID = AnimeDataGridview.Rows[selectedRowNo].Cells[0].Value.ToString();
            ShowAnimeInfo(animeID);
            ShowCharacterInfo(animeID);
        }

        private void changeanimebutton_Click(object sender, EventArgs e)
        {

            修改动画信息ToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void addanimebutton_Click(object sender, EventArgs e)
        {
            添加动画信息ToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void deleteanimebutton_Click(object sender, EventArgs e)
        {

            删除动画信息ToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        #endregion

        #region 键盘

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    关于ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F2:
                    添加动画信息ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F3:
                    声优列表SF3ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F4:
                    动画制作企业列表ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F5:
                    LoadAnime();
                    break;

            }
        }



        #endregion


    }
}
