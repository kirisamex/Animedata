using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using Client.MainForm;
using Client.MainForm.Service;
using Lib.Lib.Class.Animes;
using Lib.Lib.Message;
using UILib.Style;

using CompanyListDataTable = Client.ClientDataSet.ClientDataSet.CompanyListDataTable;
using CompanyHistDataTable = Client.ClientDataSet.ClientDataSet.CompanyHistDataTable;
using CompanyListRow = Client.ClientDataSet.ClientDataSet.CompanyListRow;
using CompanyHistRow = Client.ClientDataSet.ClientDataSet.CompanyHistRow;


namespace Client.MainForm.Gui
{
    public partial class CompanyManage : Form
    {
        #region 常量
        //实例
        public static CompanyManage CompManageeFm = null;

        CompanyManageService service = new CompanyManageService();
        StatusStyle statusStyle = new StatusStyle();
        DataGridViewStyle dgvStyle = new DataGridViewStyle();

        //数据集
        CompanyListDataTable companyList = new CompanyListDataTable();
        CompanyHistDataTable companyHist = new CompanyHistDataTable();

        #region 信息
        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>操作成功！</summary>
        const string MSG_COMMON_003 = "MSG-COMMON-003";
        /// <summary>确定进行操作吗？</summary>
        const string MSG_COMMON_008 = "MSG-COMMON-008";

        /// <summary>企业名称未修改！</summary>
        const string MSG_COMPANYMANAGE_001 = "MSG-COMPANYMANAGE-001";
        /// <summary>企业名称不能为空！</summary>
        const string MSG_COMPANYMANAGE_002 = "MSG-COMPANYMANAGE-002";
        /// <summary>没有任何信息被修改！</summary>
        const string MSG_COMPANYMANAGE_003 = "MSG-COMPANYMANAGE-003";
        /// <summary>删除动画制作企业前需要先在动画列表中删除所有该企业制作的动画。确定要删除企业 {0} 吗？</summary>
        const string MSG_COMPANYMANAGE_004 = "MSG-COMPANYMANAGE-004";
        /// <summary>该制作公司正被以下动画使用\n{0}</summary>
        const string MSG_COMPANYMANAGE_005 = "MSG-COMPANYMANAGE-005";
        #endregion

        #region 列名
        const string COMIDCLN = "CompanyID";
        const string COMNAMECLN = "CompanyName";

        const string ANIMENOCLN ="AnimeNo";
        const string ANIMENAMECLN ="AnimeCNName";
        const string PLAYINFOCLN = "Playinfo";
        const string STATUSCLN = "Status";
        const string PARTSCLN = "Parts";
        const string STARTTIMECLN = "StartTime";
        #endregion

        #endregion

        #region 构析
        /// <summary>
        /// 构析函数
        /// </summary>
        /// <param name="mainfm"></param>
        public CompanyManage()
        {
            CompManageeFm = this;
            InitializeComponent();
        }
        #endregion

        #region 方法

        /// <summary>
        /// 载入公司
        /// </summary>
        private void LoadCompany()
        {
            ShowCompanyInfo(service.LoadCompany());
        }

        /// <summary>
        /// 载入公司：简易搜索
        /// </summary>
        /// <param name="target"></param>
        public void LoadCompany(string target)
        {
            ShowCompanyInfo(service.LoadCompany(target));
        }

        /// <summary>
        /// 载入公司界面
        /// </summary>
        public void ShowCompanyInfo(System.Data.DataSet ds)
        {
            CompanyDataGridView.Rows.Clear();

            try
            {
                DataSet ListDS = ds;
                DataSet HistDS = service.LoadCompanyHistInfo();

                #region 数据集载入
                companyList.Clear();
                companyHist.Clear();

                foreach (DataRow dr in ListDS.Tables[0].Rows)
                {
                    CompanyListRow clr = companyList.NewCompanyListRow();
                    clr.CompanyID = Convert.ToInt32(dr[0]);
                    clr.CompanyName = dr[1].ToString();
                    companyList.Rows.Add(clr);
                }
                companyList.AcceptChanges();

                foreach(DataRow dr in HistDS.Tables[0].Rows)
                {
                    CompanyHistRow chr = companyHist.NewCompanyHistRow();

                    chr.CompanyID = Convert.ToInt32(dr[0]);
                    chr.CompanyName = dr[1].ToString();
                    chr.AnimeNo = dr[2].ToString();
                    chr.PlayinfoID = Convert.ToInt32(dr[3]);
                    chr.Playinfo = dr[4].ToString();
                    chr.PlayinfoStatus = Convert.ToInt32(dr[5]);
                    if (dr[6] != DBNull.Value)
                    {
                        chr.StartTime = Convert.ToDateTime(dr[6]);
                    }
                    else
                    {
                        chr.StartTime = DateTime.MinValue;
                    }
                    if (dr[7] != DBNull.Value)
                    {
                        chr.WatchTime = Convert.ToDateTime(dr[7]);
                    }
                    else
                    {
                        chr.WatchTime = DateTime.MinValue;
                    }
                    if (dr[8] != DBNull.Value)
                    {
                        chr.Parts = Convert.ToInt32(dr[8]);
                    }
                    else
                    {
                        chr.Parts = 0;
                    }
                    chr.AnimeCNName = dr[9].ToString();
                    chr.AnimeJPName = dr[10].ToString();
                    companyHist.Rows.Add(chr);
                }
                companyHist.AcceptChanges();
                #endregion
               

                foreach (DataRow dr in companyList.Rows)
                {
                    DataGridViewRow dgr = CompanyDataGridView.Rows[CompanyDataGridView.Rows.Add()];

                    dgr.Cells[COMIDCLN].Value = dr[0].ToString();
                    dgr.Cells[COMNAMECLN].Value = dr[1].ToString();
                }

                //格式
                dgvStyle.SetDataGridViewAndSplit(splitContainer1, CompanyDataGridView);

                ShowCompanyHistInfo(GetSelectedCompany());
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
                this.Close();
            }
        }

        /// <summary>
        /// 展示选中公司履历
        /// </summary>
        /// <param name="cmp">选中公司</param>
        private void ShowCompanyHistInfo(Company cmp)
        {
            companyHistDataGridView.Rows.Clear();

            if (cmp == null)
            {
                return;
            }          

            var targetHists = from cmpHist in this.companyHist
                              where cmpHist.CompanyID == cmp.ID
                              orderby cmpHist.AnimeNo,cmpHist.StartTime
                              select cmpHist;

            foreach (CompanyHistRow chr in targetHists)
            {

                DataGridViewRow dgr = companyHistDataGridView.Rows[companyHistDataGridView.Rows.Add()];

                dgr.Cells[ANIMENOCLN].Value = chr.AnimeNo;
                dgr.Cells[ANIMENAMECLN].Value = chr.AnimeCNName;
                dgr.Cells[PLAYINFOCLN].Value = chr.Playinfo;
                if (chr.Parts != 0)
                {
                    dgr.Cells[PARTSCLN].Value = chr.Parts.ToString();
                }

                dgr.Cells[STATUSCLN].Value = service.GetStatusTextFromStatusInt(chr.PlayinfoStatus);

                if (chr.StartTime != DateTime.MinValue && chr.StartTime != DateTime.MaxValue)
                {
                    dgr.Cells[STARTTIMECLN].Value = service.ConvertToYYYYNianMMYueFromDatetime(chr.StartTime);
                }
                
            }

            //状态格式
            foreach (DataGridViewRow dr in companyHistDataGridView.Rows)
            {
                int status = service.GetStatusIntFromStatusText(dr.Cells[STATUSCLN].Value.ToString());
                dr.Cells[STATUSCLN].Style = statusStyle.GetStatusRowStyle(status);
            }

            for (int i = 0; i < companyHistDataGridView.ColumnCount; i++)
            {
                companyHistDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                companyHistDataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        /// <summary>
        /// 获得选中行公司
        /// </summary>
        /// <returns></returns>
        private Company GetSelectedCompany()
        {
            if (CompanyDataGridView.CurrentCell == null)
                return null;
            int idx = CompanyDataGridView.CurrentRow.Index;
            DataGridViewRow currentRow = CompanyDataGridView.Rows[idx];
            if (currentRow.Cells[COMNAMECLN].Value == null)
            {
                return null;
            }
            
            Company comp = new Company();
            comp.Name = currentRow.Cells[COMNAMECLN].Value.ToString();
            comp.ID = Convert.ToInt32(currentRow.Cells[COMIDCLN].Value);
            return comp;
        }

        /// <summary>
        /// 开启修改公司功能
        /// </summary>
        private void UpdateCompanyEnable()
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
        private bool UpdateCompany()
        {
            List<Company> NeedUpdateCompanys = new List<Company>();

            foreach (DataGridViewRow dr in CompanyDataGridView.Rows)
            {
                if (dr.Cells[1].Value == null || dr.Cells[1].Value.ToString().Trim().Equals(string.Empty))
                {
                    MsgBox.Show(MSG_COMPANYMANAGE_002);
                    return false;
                }

                Company newCmpInfo = new Company();
                newCmpInfo.ID = Convert.ToInt32(dr.Cells[0].Value);
                newCmpInfo.Name = dr.Cells[1].Value.ToString();

                var targetCmp = from cmp in this.companyList
                                where cmp.CompanyID == newCmpInfo.ID
                                select cmp;

                foreach (CompanyListRow clr in targetCmp)
                {
                    if(!clr.CompanyName.Equals(newCmpInfo.Name))
                    {
                        NeedUpdateCompanys.Add(newCmpInfo);
                    }
                    
                }
            }


            if (NeedUpdateCompanys.Count == 0)
            {
                MsgBox.Show(MSG_COMPANYMANAGE_003);
                return false;
            }

            if(MsgBox.Show(MSG_COMMON_008)==DialogResult.Yes)
            {

                foreach (Company cmp in NeedUpdateCompanys)
                {
                    service.UpdateCompanyInfo(cmp.Name, cmp.ID);
                }

                MsgBox.Show(MSG_COMMON_003);
                LoadCompany();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 删除选定公司
        /// </summary>
        /// <returns></returns>
        private bool DeleteCompany()
        {
            Company comp = GetSelectedCompany();
            string errorString = string.Empty;

            if (MsgBox.Show(MSG_COMPANYMANAGE_004, comp.Name) == DialogResult.Yes)
            {
                try
                {
                    if (service.DeleteCompanyByCompanyID(comp.ID, out errorString))
                    {
                        MsgBox.Show(MSG_COMMON_003);
                        LoadCompany();
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
            Company comp = GetSelectedCompany();

            try
            {
                System.Data.DataSet ds = service.Getanime(comp);

                Main.Mainfm.ShowAnime(ds);
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
            LoadCompany();
        }

        /// <summary>
        /// 修改按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changebuttom_Click(object sender, EventArgs e)
        {
            UpdateCompanyEnable();
        }

        /// <summary>
        /// 确定按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okbutton_Click(object sender, EventArgs e)
        {
            if (UpdateCompany() == true)
            {
                CompanyDataGridView.ReadOnly = true;
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
            CompanyDataGridView.ReadOnly = true;
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
                    LoadCompany();
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
            LoadCompany();
        }
        
        /// <summary>
        /// 选中公司
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowCompanyHistInfo(GetSelectedCompany());
        }

        /// <summary>
        /// 简易搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            if (searchtextbox.Text != null && searchtextbox.Text.ToString() != string.Empty)
            {
                LoadCompany(searchtextbox.Text.ToString());
            }
        }

        #endregion

        #region 事件
        /// <summary>
        /// 双击动画名在主窗体搜索动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void companyHistDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == companyHistDataGridView.Columns[ANIMENAMECLN].Index || e.ColumnIndex == companyHistDataGridView.Columns[ANIMENOCLN].Index)
            {
                Main.Mainfm.SimpleSearch(companyHistDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                Main.Mainfm.Focus();
            }
        }

        /// <summary>
        /// 单击搜索文本框全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchtextbox_Click(object sender, EventArgs e)
        {
            searchtextbox.SelectAll();
        }

        /// <summary>
        /// 搜索文本框全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchtextbox_Enter(object sender, EventArgs e)
        {
            searchtextbox.SelectAll();
        }
        #endregion
    }
}
