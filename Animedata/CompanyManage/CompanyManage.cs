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

        #region 列名
        const string COMIDCLN = "CompanyID";
        const string COMNAMECLN = "CompanyName";
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

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataGridViewRow dgr = CompanyDataGridView.Rows[CompanyDataGridView.Rows.Add()];

                    dgr.Cells[COMIDCLN].Value = dr[0].ToString();
                    dgr.Cells[COMNAMECLN].Value = dr[1].ToString();

                }

                //格式
                int colwit = 0;
                foreach (DataGridViewColumn col in CompanyDataGridView.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    colwit += col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                }
                splitContainer1.SplitterDistance = colwit;
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
            int idx = CompanyDataGridView.CurrentRow.Index;
            string name = CompanyDataGridView.Rows[idx].Cells[0].Value.ToString();
            Company comp = new Company();
            comp.Name = name;
            comp.ID = service.GetCompanyIdByCompanyName(name);
            return comp;
        }

        /// <summary>
        /// 开启修改公司功能
        /// </summary>
        private void LoadChangeCompany()
        {
            okbutton.Visible = true;
            cancelbutton.Visible = true;
            changebuttom.Visible = false;
            CompanyDataGridView.ReadOnly = false;
        }

        /// <summary>
        /// 修改公司
        /// </summary>
        /// <returns></returns>
        private bool ChangeCompany()
        {
            Company comp = GetChooseCompany();
            string newname = changetextbox.Text.ToString();

            foreach (DataGridViewRow dr in CompanyDataGridView.Rows)
            {
                //
            }


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
                changebuttom.Visible = true;
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
            changebuttom.Visible = true;
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
            okbutton.Visible = false;
            cancelbutton.Visible = false;
            Loadcompany();
        }
        #endregion


    }
}
