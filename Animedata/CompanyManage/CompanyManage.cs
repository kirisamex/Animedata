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

        #region
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
                MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
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
                MessageBox.Show("企业名称未修改!", ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (newname == string.Empty)
            {
                MessageBox.Show("企业名称不能为空！", ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DialogResult res = MessageBox.Show("确定将名为 " + comp.Name +
                " 的企业名称修改为 " + newname + "吗？", "修改企业名称",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {
                try
                {
                    if (service.UpdateCompanyInfo(newname, comp))
                    {
                        MessageBox.Show("修改成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Loadcompany();
                        mainform.DataGridViewReload();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// 删除选定动画
        /// </summary>
        /// <returns></returns>
        private bool DeleteCompany()
        {
            Company comp = GetChooseCompany();
            DialogResult res = MessageBox.Show("删除动画制作企业前需要先在动画列表中删除所有该企业制作的动画。确定要删除该企业吗？", "确定删除",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            if (res == DialogResult.OK)
            {
                try
                {
                    if (service.DeleteCompanyByCompanyID(comp.ID))
                    {
                        MessageBox.Show("删除企业成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Loadcompany();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
