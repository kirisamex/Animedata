using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using Main.Lib.Message;

namespace Main
{
    public partial class CompanyManage : Form
    {
        #region 常量
        //传递
        private MainForm mainform;

        //实例
        CompanyManageService service = new CompanyManageService();

        #region 信息
        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>操作成功！</summary>
        const string MSG_COMMON_003 = "MSG-COMMON-003";

        /// <summary>企业名称未修改！</summary>
        const string MSG_COMPANYMANAGE_001 = "MSG-COMPANYMANAGE-001";
        /// <summary>企业名称不能为空！</summary>
        const string MSG_COMPANYMANAGE_002 = "MSG-COMPANYMANAGE-002";
        /// <summary>确定将名为 {0} 的企业名称修改为 {1} 吗？</summary>
        const string MSG_COMPANYMANAGE_003 = "MSG-COMPANYMANAGE-003";
        /// <summary>删除动画制作企业前需要先在动画列表中删除所有该企业制作的动画。确定要删除企业 {0} 吗？</summary>
        const string MSG_COMPANYMANAGE_004 = "MSG-COMPANYMANAGE-004";
        /// <summary>该制作公司正被以下动画使用\n{0}</summary>
        const string MSG_COMPANYMANAGE_005 = "MSG-COMPANYMANAGE-005";
        #endregion

        #endregion

        #region 构析
        /// <summary>
        /// 构析函数
        /// </summary>
        /// <param name="mainfm"></param>
        public CompanyManage(MainForm mainfm)
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
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
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
            string name = dataGridView1.Rows[idx].Cells[0].Value.ToString();
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
                MsgBox.Show(MSG_COMPANYMANAGE_001);
                return false;
            }

            if (newname == string.Empty)
            {
                MsgBox.Show(MSG_COMPANYMANAGE_002);
                return false;
            }
            if(MsgBox.Show(MSG_COMPANYMANAGE_003,comp.Name,newname)==DialogResult.Yes)
            {
                try
                {
                    if (service.UpdateCompanyInfo(newname, comp))
                    {
                        MsgBox.Show(MSG_COMMON_003);
                        Loadcompany();
                        mainform.DataGridViewReload();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MSG_COMMON_001, ex.ToString());
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
            string errorString = string.Empty;

            if (MsgBox.Show(MSG_COMPANYMANAGE_004, comp.Name) == DialogResult.Yes)
            {
                try
                {
                    if (service.DeleteCompanyByCompanyID(comp.ID, out errorString))
                    {
                        MsgBox.Show(MSG_COMMON_003);
                        Loadcompany();
                        return true;
                    }
                    else
                    {
                        MsgBox.Show(MSG_COMPANYMANAGE_005, errorString);
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MSG_COMMON_001, ex.ToString());
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

            try
            {
                DataSet ds = service.Getanime(comp);

                mainform.LoadAnimeMain(ds);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
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
