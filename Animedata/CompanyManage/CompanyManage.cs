using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Main
{
    public partial class CompanyManage : Form
    {
        #region 常量

        /// <summary>
        /// 主窗口传递
        /// </summary>
        private Main mainform;

        /// <summary>
        /// 服务传递
        /// </summary>
        CompanyManageService service = new CompanyManageService();

        string ERROR = "错误：";

        string ERRORINFO = "错误信息";

        #endregion

        #region 构析
        /// <summary>
        /// 构析函数
        /// </summary>
        /// <param name="mainfm"></param>
        public CompanyManage(Main mainfm)
        {
            InitializeComponent();
            mainform = mainfm;
        }
        #endregion

        #region 方法

        /// <summary>
        /// 载入公司界面
        /// </summary>
        public void Loadcompany()
        {
            try
            {
                DataSet ds = service.LoadCompany();
                dataGridView1.DataSource = ds.Tables[0].DefaultView;

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    //dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                service.ShowErrorMessage(ex.Message);
                this.Close();
            }
        }

        /// <summary>
        /// 获得选中行公司
        /// </summary>
        /// <returns></returns>
        private Company GetChooseCompany()
        {
            int idx = dataGridView1.CurrentRow.Index;
            string name = dataGridView1.Rows[idx].Cells[1].Value.ToString();
            Company comp = new Company();
            comp.Name = name;
            comp.ID = service.GetCompanyIdByCompanyName(name);
            return comp;
        }

        /// <summary>
        /// 开启修改公司功能，并将选中行公司名称载入textbox
        /// </summary>
        private void LoadChangeCompany()
        {
            changetextbox.Visible = true;
            okbutton.Visible = true;
            cancelbutton.Visible = true;
            Company comp = GetChooseCompany();
            changetextbox.Text = comp.Name.ToString();
            changetextbox.Focus();
        }

        /// <summary>
        /// 修改公司
        /// </summary>
        /// <returns></returns>
        private bool ChangeCompany()
        {
            Company comp = GetChooseCompany();
            string newname = changetextbox.Text.ToString();

            if (newname == comp.Name)
            {
                service.ShowWarningMessage("企业名称未修改!");
                return false;
            }

            if (newname == string.Empty)
            {
                service.ShowWarningMessage("企业名称不能为空！");
                return false;
            }

            if (service.ShowYesNoMessage("确定将名为 " + comp.Name + " 的企业名称修改为 " + newname + "吗？", "修改企业名称"))
            {
                try
                {
                    if (service.UpdateCompanyInfo(newname, comp))
                    {
                        service.ShowInfoMessage("修改成功！", "完成");
                        Loadcompany();
                        mainform.DataGridViewReload();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    service.ShowErrorMessage(ex.Message);
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// 删除选定公司
        /// </summary>
        /// <returns></returns>
        private bool DeleteCompany()
        {
            Company comp = GetChooseCompany();

            if (service.ShowYesNoMessage("删除动画制作企业前需要先在动画列表中删除所有该企业制作的动画。确定要删除该企业吗？", "确定删除"))
            {
                try
                {
                    if (service.DeleteCompanyByCompanyID(comp.ID))
                    {
                        service.ShowInfoMessage("删除企业成功！", "完成");
                        Loadcompany();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    service.ShowErrorMessage(ex.Message);
                    return false;
                }
            }
            return false;
        }

        #endregion

        #region 按键
        /// <summary>
        /// 查询指定公司制作动画按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchbuttom_Click(object sender, EventArgs e)
        {
            Company comp = GetChooseCompany();
            try {
                DataSet ds = service.LoadAnime(comp);
                mainform.AnimeDataGridview.DataSource = ds.Tables[0].DefaultView;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    mainform.AnimeDataGridview.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    mainform.AnimeDataGridview.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                //mainform.ShowAnimeInfo(ds.Tables[0].Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                service.ShowErrorMessage(ex.Message);
                Application.Exit();
            }
        }

        /// <summary>
        /// 删除按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletebuttom_Click(object sender, EventArgs e)
        {
            DeleteCompany();
        }

        /// <summary>
        /// 刷新按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshbutton_Click(object sender, EventArgs e)
        {
            Loadcompany();
        }

        /// <summary>
        /// 修改按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changebuttom_Click(object sender, EventArgs e)
        {
            LoadChangeCompany();
        }

        /// <summary>
        /// 确定按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okbutton_Click(object sender, EventArgs e)
        {
            if (ChangeCompany() == true)
            {
                changetextbox.Visible = false;
                okbutton.Visible = false;
                cancelbutton.Visible = false;
            }
        }

        /// <summary>
        /// 取消按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            changetextbox.Visible = false;
            okbutton.Visible = false;
            cancelbutton.Visible = false;
        }
        #endregion

        #region 键盘
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void company_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    Loadcompany();
                    break;
            }
        }
        #endregion

        #region 窗体
        /// <summary>
        /// 载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void company_Load(object sender, EventArgs e)
        {
            changetextbox.Visible = false;
            okbutton.Visible = false;
            cancelbutton.Visible = false;
            Loadcompany();
        }
        #endregion


    }
}
