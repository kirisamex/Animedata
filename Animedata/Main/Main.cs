using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Main.Lib.Style;
using Main.Lib.Message;
using Main.Music;


namespace Main
{
    public partial class Main : Form
    {
        #region 常量
        //实例
        MainService service = new MainService();
        StatusStyle style = new StatusStyle();

        /// <summary>Ver.</summary>
        const string VERSION = "Ver. "; 

        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>未选中任何一行数据！</summary>
        const string MSG_COMMON_002 = "MSG-COMMON-002";
        /// <summary>操作成功！</summary>
        const string MSG_COMMON_003 = "MSG-COMMON-003";
        /// <summary>未搜索到对应结果。</summary>
        const string MSG_COMMON_007 = "MSG-COMMON-007";

        /// <summary>确定删除选中行信息吗？\n注意：这些信息对应的播放信息与角色信息将一并被删除。</summary>
        const string MSG_MAIN_001 = "MSG-MAIN-001";
        /// <summary>请输入需要搜索的内容！</summary>
        const string MSG_MAIN_003 = "MSG-MAIN-003";
        /// <summary>请先选择需要修改的动画信息！</summary>
        const string MSG_MAIN_004 = "MSG-MAIN-004";
        #endregion

        #region 载入

        /// <summary>
        /// 主窗口载入动画操作
        /// </summary>
        public void ShowAnime()
        {
            try
            {
                //获取动画信息
                DataSet ds = service.Getanime();

                LoadAnimeMain(ds);         
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.Message);
                Application.Exit();
            }
        }

        /// <summary>
        /// 载入动画主要内容
        /// </summary>
        /// <param name="ds"></param>
        public void LoadAnimeMain(DataSet ds)
        {
            AnimeDataGridview.Rows.Clear();

            DataTable animedt = ds.Tables[0];

            for (int i = 0; i < animedt.Rows.Count; i++)
            {
                AnimeDataGridview.Rows.Add();

                DataGridViewRow dgvrow = AnimeDataGridview.Rows[i];

                //编号
                dgvrow.Cells[0].Value = animedt.Rows[i][0].ToString();

                //中文名
                dgvrow.Cells[1].Value = animedt.Rows[i][1].ToString();

                //日文名
                dgvrow.Cells[2].Value = animedt.Rows[i][2].ToString();

                //简称
                dgvrow.Cells[3].Value = animedt.Rows[i][3].ToString();

                //状态
                dgvrow.Cells[4].Value = service.GetStatusTextFromStatusInt(Convert.ToInt32(animedt.Rows[i][4].ToString()));

                //原作
                dgvrow.Cells[5].Value = service.GetOriginalTextFromOriginalInt(Convert.ToInt32(animedt.Rows[i][5].ToString()));
            }

            //动画窗口格式设置
            for (int i = 0; i < AnimeDataGridview.ColumnCount; i++)
            {
                AnimeDataGridview.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                AnimeDataGridview.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //状态格式
            foreach (DataGridViewRow dr in AnimeDataGridview.Rows)
            {
                int status = service.GetStatusIntFromStatusText(dr.Cells[4].Value.ToString());
                
                dr.Cells[4].Style = style.GetStatusRowStyle(status);
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

        /// <summary>
        /// 获得动画播放信息
        /// </summary>
        /// <param name="animeNo"></param>
        public void ShowAnimeInfo(string animeNo)
        {
            try
            {
                PlayInfodataGridView.Rows.Clear();

                //获得动画播放信息
                Animation anime = service.GetAnimeFromAnimeNo(animeNo);

                try
                {
                    if (anime.playInfoList != null)
                    {
                        for (int i = 0; i < anime.playInfoList.Count; i++)
                        {
                            PlayInfo pInfo = anime.playInfoList[i];

                            PlayInfodataGridView.Rows.Add();

                            DataGridViewRow dgvrow = PlayInfodataGridView.Rows[i];

                            dgvrow.Cells[0].Value = pInfo.info;

                            if (pInfo.parts != 0)
                            {
                                dgvrow.Cells[1].Value = pInfo.parts.ToString();
                            }

                            if (pInfo.companyID != 0)
                            {
                                dgvrow.Cells[2].Value = service.GetCompanyNameByCompanyNo(pInfo.companyID);
                            }

                            dgvrow.Cells[3].Value = service.GetStatusTextFromStatusInt(pInfo.status);

                            if (pInfo.startTime != DateTime.MinValue && pInfo.startTime != DateTime.MaxValue)
                            {
                                dgvrow.Cells[4].Value = service.ConvertToYYYYNianMMYueFromDatetime(pInfo.startTime);
                            }

                            if (pInfo.watchedTime != DateTime.MinValue && pInfo.watchedTime != DateTime.MaxValue)
                            {
                                dgvrow.Cells[5].Value = service.ConvertToYYYYNianMMYueFromDatetime(pInfo.watchedTime);
                            }
                        }

                        //状态格式
                        foreach (DataGridViewRow dr in PlayInfodataGridView.Rows)
                        {
                            int status = service.GetStatusIntFromStatusText(dr.Cells[3].Value.ToString());
                            //dr.Cells[0].Style = style.GetStatusRowStyle(status);
                            dr.Cells[3].Style = style.GetStatusRowStyle(status);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MSG_COMMON_001, ex.Message);
                }

                foreach(DataGridViewColumn dc in PlayInfodataGridView.Columns)
                {
                    dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }



            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.Message);
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
                DataSet ds = service.LoadCharacterInfo(animeNo);

                //DGV3格式设置
                CVdataGridView.DataSource = ds.Tables[0].DefaultView;
                for (int i = 0; i < CVdataGridView.ColumnCount; i++)
                {
                    CVdataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    CVdataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.Message);
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
            if (AnimeDataGridview.SelectedCells.Count > 0)
            {
                DataGridViewRow dr = AnimeDataGridview.Rows[AnimeDataGridview.SelectedCells[0].RowIndex];
                return dr;
            }

            return null;
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
                string currentrowalbumNo = AnimeDataGridview.Rows[AnimeDataGridview.SelectedCells[i].RowIndex].Cells["AnimeNo"].Value.ToString();

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
                MsgBox.Show(MSG_COMMON_002);
                return;
            }

            DialogResult res = MsgBox.Show(MSG_MAIN_001);

            if (res == DialogResult.Yes)
            {
                try
                {
                    List<string> SelectedRowsAnimeNoList = GetSelectedRowsAnimeNoList();
                    foreach (string animeNo in SelectedRowsAnimeNoList)
                    {
                        Animation anime = new Animation(animeNo);
                        anime.Delete();
                    }

                    MsgBox.Show(MSG_COMMON_003);
                    DataGridViewReload();
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MSG_COMMON_001, ex.Message);
                }
            }
        }

        /// <summary>
        /// 简易搜索
        /// </summary>
        private void SimpleSearch()
        {
            if(simpleSearchTextBox.Text==null ||string.IsNullOrEmpty(simpleSearchTextBox.Text.ToString()))
            {
                MsgBox.Show(MSG_MAIN_003);
                return;
            }

            try
            {
                DataSet ds = service.Getanime(simpleSearchTextBox.Text.ToString());
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MsgBox.Show(MSG_COMMON_007);
                    return;
                }

                LoadAnimeMain(ds);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.Message);
            }
        }

        #endregion

        #region 窗体

        /// <summary>
        /// 主窗体
        /// </summary>
        public Main()
        {
            InitializeComponent();
            this.Text += VERSION + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.ShowAnime();
        }

        /// <summary>
        /// 主窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAnime();
        }

        /// <summary>
        /// 重新载入动画窗体
        /// </summary>
        public void DataGridViewReload()
        {
            this.ShowAnime();
        }

        /// <summary>
        /// 主窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 菜单
        private void 音乐管理MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Music.MusicManage music = new Music.MusicManage();
            music.Show();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAnime();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 添加动画信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAnime fm = new AddAnime(AddAnime.command.Add, null, this);
            fm.Show();
            //对应：添加动画后不刷新 2016/02/19
            //this.LoadAnime();
        }

        private void 修改动画信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetSelectedRow() != null)
            {
                AddAnime cgem = new AddAnime(AddAnime.command.Update, GetSelectedRow(), this);
                cgem.Show();
            }
            else
            {
                MsgBox.Show(MSG_MAIN_004);
            }
        }

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
            CVManage fm = new CVManage(this);
            fm.Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void 查询动画ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainSearch search = new MainSearch(this);
            search.Show();
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

        private void simpleSearchButton_Click(object sender, EventArgs e)
        {
            SimpleSearch();
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
                case Keys.F1:
                    关于ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F6:
                    添加动画信息ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F3:
                    声优列表SF3ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F4:
                    动画制作企业列表ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F5:
                    ShowAnime();
                    break;
                case Keys.F2:
                    查询动画ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F7:
                    //音乐管理MToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
            }
        }

        #endregion

    }
}
