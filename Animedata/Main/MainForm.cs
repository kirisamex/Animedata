using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Main.ClientDataSet;
using Main.Lib.Style;
using Main.Lib.Message;
using Main.Music;


namespace Main
{
    public partial class MainForm : Form
    {
        #region 常量及全局变量
        //实例
        MainService service = new MainService();
        StatusStyle statusStyle = new StatusStyle();
        DataGridViewStyle dgvStyle = new DataGridViewStyle();

        //数据集
        ClientDS.AnimeHistDataTable AnimeHist = new ClientDS.AnimeHistDataTable();
        ClientDS.AnimeListDataTable AnimeList = new ClientDS.AnimeListDataTable();
        ClientDS.PlayInfoHistDataTable PlayInfoHist = new ClientDS.PlayInfoHistDataTable();
        ClientDS.PlayInfoListDataTable PlayInfoList = new ClientDS.PlayInfoListDataTable();
        ClientDS.CVHistDataTable CVHist = new ClientDS.CVHistDataTable();
        ClientDS.CVListDataTable CVList = new ClientDS.CVListDataTable();

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

        #region 列名
        const string ANIMENOCLN = "AnimeNo";
        const string ANIMECNNAMECLN = "AnimeCNName";
        const string ANIMEJPNAMECLN = "AnimeJPName";
        const string ANIMENICKNAMECLN = "AnimeNiceName";
        const string ANIMESTATUSCLN = "AnimeStatus";
        const string ANIMEORIGINALCLN = "AnimeOriginal";

        const string PLAYINFOCLN = "PlayInfoColumn";
        const string STATUSCLN ="StatusColumn";
        const string PARTSCLN ="PartsColumn";
        const string COMPANYCLN ="CompanyColumn";
        const string STARTTIMECLN ="STTimeColumn";
        const string WATCHTIMECLN ="WTimeColumn";
        #endregion
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
                DataSet ds = service.Getanime();

                ShowAnime(ds);         
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
        public void ShowAnime(DataSet ds)
        {
            AnimationDataGridview.Rows.Clear();

            #region #7 修改SQL后动画重复对应
            DataTable tmpdt = ds.Tables[0];

            string[] straColumn = new string[tmpdt.Columns.Count];

            for (int LoopIndex = 0; LoopIndex < tmpdt.Columns.Count; LoopIndex++)
            {
                straColumn[LoopIndex] = tmpdt.Columns[LoopIndex].ColumnName;
            }

            DataTable dt = tmpdt.DefaultView.ToTable(true, straColumn);
            #endregion

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string AnimeNo = dt.Rows[i][0].ToString();

                AnimationDataGridview.Rows.Add();
                DataGridViewRow dgvrow = AnimationDataGridview.Rows[AnimationDataGridview.RowCount - 1];
                //编号
                dgvrow.Cells[0].Value = AnimeNo;

                //中文名
                dgvrow.Cells[1].Value = dt.Rows[i][1].ToString();

                //日文名
                dgvrow.Cells[2].Value = dt.Rows[i][2].ToString();

                //简称
                dgvrow.Cells[3].Value = dt.Rows[i][3].ToString();

                //状态
                dgvrow.Cells[4].Value = service.GetStatusTextFromStatusInt(Convert.ToInt32(dt.Rows[i][4].ToString()));

                //原作
                dgvrow.Cells[5].Value = service.GetOriginalTextFromOriginalInt(Convert.ToInt32(dt.Rows[i][5].ToString()));
            }

            //动画窗口格式设置
            dgvStyle.SetDataGridViewAndSplit(splitContainer2, AnimationDataGridview, 19);

            //状态格式
            foreach (DataGridViewRow dr in AnimationDataGridview.Rows)
            {
                int status = service.GetStatusIntFromStatusText(dr.Cells[4].Value.ToString());
                
                dr.Cells[4].Style = statusStyle.GetStatusRowStyle(status);
            }

            string firstRowAnimeNo = null;

            if (ds.Tables[0].Rows.Count != 0)
            {
                firstRowAnimeNo = ds.Tables[0].Rows[0][0].ToString();

                //获取播放信息
                ShowPlayInfo(firstRowAnimeNo);

                //获取角色信息
                ShowCharacterInfo(firstRowAnimeNo);
            }

        }

        /// <summary>
        /// 获得动画播放信息
        /// </summary>
        /// <param name="animeNo"></param>
        public void ShowPlayInfo(string animeNo)
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

                            dgvrow.Cells[PLAYINFOCLN].Value = pInfo.info;

                            if (pInfo.parts != 0)
                            {
                                dgvrow.Cells[PARTSCLN].Value = pInfo.parts.ToString();
                            }

                            if (pInfo.companyID != 0)
                            {
                                dgvrow.Cells[COMPANYCLN].Value = service.GetCompanyNameByCompanyNo(pInfo.companyID);
                            }

                            dgvrow.Cells[STATUSCLN].Value = service.GetStatusTextFromStatusInt(pInfo.status);

                            if (pInfo.startTime != DateTime.MinValue && pInfo.startTime != DateTime.MaxValue)
                            {
                                dgvrow.Cells[STARTTIMECLN].Value = service.ConvertToYYYYNianMMYueFromDatetime(pInfo.startTime);
                            }

                            if (pInfo.watchedTime != DateTime.MinValue && pInfo.watchedTime != DateTime.MaxValue)
                            {
                                dgvrow.Cells[WATCHTIMECLN].Value = service.ConvertToYYYYNianMMYueFromDatetime(pInfo.watchedTime);
                            }
                        }

                        //状态格式
                        foreach (DataGridViewRow dr in PlayInfodataGridView.Rows)
                        {
                            int status = service.GetStatusIntFromStatusText(dr.Cells[STATUSCLN].Value.ToString());
                            dr.Cells[STATUSCLN].Style = statusStyle.GetStatusRowStyle(status);
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
            if (AnimationDataGridview.SelectedCells.Count > 0)
            {
                DataGridViewRow dr = new DataGridViewRow();
                dr = AnimationDataGridview.Rows[AnimationDataGridview.SelectedCells[0].RowIndex];
                return dr;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得选中单元格所在行的AnimeNo列表，用于删除
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelectedRowsAnimeNoList()
        {

            List<string> selectedAnimeNoList = new List<string>();

            for (int i = 0; i < AnimationDataGridview.SelectedCells.Count; i++)
            {
                string currentrowalbumNo = AnimationDataGridview.Rows[AnimationDataGridview.SelectedCells[i].RowIndex].Cells["AnimeNo"].Value.ToString();

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
            if (AnimationDataGridview.SelectedCells.Count == 0)
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
            if (simpleSearchTextBox.Text == null || string.IsNullOrEmpty(simpleSearchTextBox.Text.ToString()))
            {
                MsgBox.Show(MSG_MAIN_003);
                return;
            }

            SimpleSearch(simpleSearchTextBox.Text.ToString());
        }

        /// <summary>
        /// 简易搜索
        /// </summary>
        /// <param name="target"></param>
        public void SimpleSearch(string target)
        {
            try
            {
                DataSet ds = service.Getanime(target);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MsgBox.Show(MSG_COMMON_007);
                    return;
                }

                ShowAnime(ds);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.Message);
            }
        }

        /// <summary>
        /// 显示播放信息以及角色信息
        /// </summary>
        private void ShowPlayinfoAndCharacterInfo()
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
            string animeID = AnimationDataGridview.Rows[(int)selectedRowNo].Cells[0].Value.ToString();
            ShowPlayInfo(animeID);
            ShowCharacterInfo(animeID);
        }

        /// <summary>
        /// 检测是否有重复窗体打开
        /// </summary>
        /// <param name="FormName">窗体名</param>
        /// <returns>True:有重复 False:没有重复</returns>
        public bool IsFormOpened(string FormName)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name.Equals(FormName))
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                    }

                    frm.Activate();
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 窗体

        public static MainForm Mainfm = null;
        /// <summary>
        /// 主窗体
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Mainfm = this;
            this.Text += VERSION + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.LoadAnime();
        }

        /// <summary>
        /// 主窗体加载
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
            if (!IsFormOpened("MusicManage"))
            {
                Music.MusicManage music = new Music.MusicManage();
                music.Show();
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAnime();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 添加动画信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsFormOpened("AddAnime"))
            {
                AddAnime fm = new AddAnime(AddAnime.command.Add, null);
                fm.Show();
                //对应：添加动画后不刷新 2016/02/19
                //this.LoadAnime();
            }
        }

        private void 修改动画信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetSelectedRow() != null)
            {
                if (!IsFormOpened("AddAnime"))
                {
                    AddAnime cgem = new AddAnime(AddAnime.command.Update, GetSelectedRow());
                    cgem.Show();
                }
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
            if (!IsFormOpened("CompanyManage"))
            {
                CompanyManage fm = new CompanyManage();
                fm.Show();
            }
        }

        private void 声优列表SF3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsFormOpened("CVManage"))
            {
                CVManage fm = new CVManage();
                fm.Show();
            }           
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsFormOpened("AboutBox"))
            {
                AboutBox about = new AboutBox();
                about.Show();
            }
        }

        private void 查询动画ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsFormOpened("MainSearch"))
            {
                MainSearch search = new MainSearch();
                search.Show();
            }
        }
        #endregion

        #region 按键

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //#7_键盘操作对应，改为CurrentCellChange
            //ShowPlayinfoAndCharacterInfo();
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

        #region 事件
        private void AnimationDataGridview_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowPlayinfoAndCharacterInfo();
        }

        /// <summary>
        /// 双击制作公司显示制作公司履历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayInfodataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == PlayInfodataGridView.Columns[COMPANYCLN].Index)
            {
                if (IsFormOpened("CompanyManage"))
                {
                    CompanyManage.CompManageeFm.LoadCompany(PlayInfodataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    CompanyManage.CompManageeFm.Focus();
                }
                else
                {
                    CompanyManage fm = new CompanyManage();
                    fm.Show();
                    fm.LoadCompany(PlayInfodataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
        }

        /// <summary>
        /// 双击声优名显示声优履历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CVdataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (IsFormOpened("CVManage"))
                {
                    CVManage.CVManageFm.LoadCVInfo(CVdataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    CVManage.CVManageFm.Focus();
                }
                else
                {
                    CVManage fm = new CVManage();
                    fm.Show();
                    fm.LoadCVInfo(CVdataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
        }

        //简易搜索获取焦点
        private void simpleSearchTextBox_Enter(object sender, EventArgs e)
        {

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
                    动画制作企业列表ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F3:
                    声优列表SF3ToolStripMenuItem_Click(this, EventArgs.Empty);
                    break;
                case Keys.F5:
                    LoadAnime();
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
