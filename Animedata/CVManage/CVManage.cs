using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Main;
using Main.ClientDataSet;
using Main.Lib.Message;

namespace Main
{
    public partial class CVManage : Form
    {
        public CVManage(MainForm mainfm)
        {
            InitializeComponent();
            mainform = mainfm;
        }

        #region 常量
        //全局变量
        private MainForm mainform;
        cmdtype cmd = new cmdtype();

        //实例化
        CVManageService service = new CVManageService();

        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>操作成功！</summary>
        const string MSG_COMMON_003 = "MSG-COMMON-003";

        /// <summary>[ {0} ]的年月日格式或日期不正确！时间格式：yyyyMMdd。</summary>
        const string MSG_CVMANAGE_001 = "MSG-CVMANAGE-001";
        /// <summary>[ {0} ]日期超过了当前时间，请检查是否填写错误或系统时间不正确！</summary>
        const string MSG_CVMANAGE_002 = "MSG-CVMANAGE-002";
        /// <summary>{0}\n若需要删除该声优请先删除上述角色信息。</summary>
        const string MSG_CVMANAGE_003 = "MSG-CVMANAGE-003";
        /// <summary>确认要删除选中的声优信息吗？如果有该声优有记录的配音角色，请先删除该角色。</summary>
        const string MSG_CVMANAGE_004 = "MSG-CVMANAGE-004";
        /// <summary>有未填写的声优编号！</summary>
        const string MSG_CVMANAGE_005 = "MSG-CVMANAGE-005";
        /// <summary>有未填写的声优姓名！</summary>
        const string MSG_CVMANAGE_006 = "MSG-CVMANAGE-006";
        /// <summary>[ {0} ]的格式不正确。编号必须为半角数字!</summary>
        const string MSG_CVMANAGE_007 = "MSG-CVMANAGE-007";
        /// <summary>声优编号与现有编号重复，操作失败！\n重复声优编号:{0} \n姓名:{1}</summary>
        const string MSG_CVMANAGE_008 = "MSG-CVMANAGE-008";
        /// <summary>未选中声优！</summary>
        const string MSG_CVMANAGE_009 = "MSG-CVMANAGE-009";

        /// <summary>
        /// 操作种类
        /// </summary>
        enum cmdtype : byte
        {
            //增加
            Add, //增加
            //修改
            Change//修改
        };

        #endregion

        #region 方法

        /// <summary>
        /// 展示声优信息
        /// </summary>
        public void ShowCVInfo()
        {
            DataSet ds = service.LoadCVInfo();
            LoadCVInfo(ds);
        }

        /// <summary>
        /// 展示声优信息
        /// 简易搜索
        /// </summary>
        /// <param name="target"></param>
        public void ShowCVInfo(string target)
        {
            DataSet ds = service.LoadCVInfo(target);
            LoadCVInfo(ds);
        }

        /// <summary>
        /// 载入声优信息
        /// </summary>
        private void LoadCVInfo(DataSet ds)
        {
            cvdataGridView.Rows.Clear();

            //格式设置
            foreach (DataGridViewColumn dc in cvdataGridView.Columns)
            {
                //dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cvdataGridView.Rows.Add();
                    DataGridViewRow dr = cvdataGridView.Rows[i];

                    dr.Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                    dr.Cells[1].Value = ds.Tables[0].Rows[i][1].ToString();

                    if (ds.Tables[0].Rows[i][2] != DBNull.Value)
                    {
                        dr.Cells[2].Value = service.GetGenderStringFromGenderChar(ds.Tables[0].Rows[i][2].ToString());
                    }

                    if (ds.Tables[0].Rows[i][3] != DBNull.Value)
                    {
                        DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[i][3]);
                        dr.Cells[3].Value = service.ConvertToYYYYNianMMYueDDRiFromDatetime(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 修改声优信息
        /// </summary>
        /// <returns></returns>
        private bool ChangeCVInfo()
        {
            //Null检查
            if (!CVInfoRowNullCheck())
                return false;

            //格式检查
            if (!CVInfoFormatCheck())
                return false;

            //信息作成
            List<CV> cvInfoList = new List<CV>();

            foreach (DataGridViewRow dr in cvdataGridView.Rows)
            {
                CV cvInfo = new CV();
                cvInfo.ID = Convert.ToInt32(dr.Cells[0].Value);
                cvInfo.Name = dr.Cells[1].Value.ToString();
                if (dr.Cells[2].Value != null)
                {
                    cvInfo.Gender = service.GetGenderCharFromGenderString(dr.Cells[2].Value.ToString());
                }
                if (dr.Cells[3].Value != null)
                {
                    cvInfo.Brithday = service.ConvertToDateTimeFromYYYYMMdd(dr.Cells[3].Value.ToString());
                }

                cvInfoList.Add(cvInfo);
            }

            //修改信息
            foreach (CV cvInfo in cvInfoList)
            {
                try
                {
                    service.UpdateCVInfo(cvInfo);
                }
                catch (Exception ex)
                {
                    MsgBox.Show(MSG_COMMON_001, ex.ToString());
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 添加声优信息
        /// </summary>
        /// <returns></returns>
        private bool AddCVInfo()
        {
            //Null检查
            if (!CVInfoRowNullCheck())
                return false;

            //格式检查
            if (!CVInfoFormatCheck())
                return false;

            DataGridViewRow dr = cvdataGridView.Rows[cvdataGridView.Rows.Count - 1];
            CV cvInfo = new CV();

            cvInfo.ID = Convert.ToInt32(dr.Cells[0].Value);
            cvInfo.Name = dr.Cells[1].Value.ToString();
            if (dr.Cells[2].Value != null)
            {
                cvInfo.Gender = service.GetGenderCharFromGenderString(dr.Cells[2].Value.ToString());
            }
            if (dr.Cells[3].Value != null)
            {
                cvInfo.Brithday = service.ConvertToDateTimeFromYYYYMMdd(dr.Cells[3].Value.ToString());
            }

            //声优编号重复检查
            if (!CVIDRepeatCheck(cvInfo.ID))
                return false;

            try
            {
                cvInfo.Insert();
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除声优信息
        /// </summary>
        /// <returns></returns>
        private bool DeleteCVInfo()
        {
            if (MsgBox.Show(MSG_CVMANAGE_004)==DialogResult.Yes)
            {
                List<CV> selectCVList = GetChooseCVs();
                string errorstring = string.Empty;
                try
                {
                    if (service.DeleteCVInfo(selectCVList, out errorstring))
                    {
                        MsgBox.Show(MSG_COMMON_003);
                        FormReset();
                        return true;
                    }
                    else
                    {
                        MsgBox.Show(MSG_CVMANAGE_003, errorstring);
                        return false;
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
        /// 声优信息Null检查
        /// </summary>
        /// <returns></returns>
        private bool CVInfoRowNullCheck()
        {
            foreach (DataGridViewRow dr in cvdataGridView.Rows)
            {
                //编号空检查
                if (dr.Cells[0].Value == null || string.IsNullOrEmpty(dr.Cells[0].Value.ToString()))
                {
                    MsgBox.Show(MSG_CVMANAGE_005);
                    return false;
                }

                //姓名空检查
                if (dr.Cells[1].Value == null || string.IsNullOrEmpty(dr.Cells[1].Value.ToString()))
                {
                    MsgBox.Show(MSG_CVMANAGE_006);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 声优信息格式检查
        /// </summary>
        /// <returns></returns>
        private bool CVInfoFormatCheck()
        {
            foreach (DataGridViewRow dr in cvdataGridView.Rows)
            {
                //编号数字检查
                if (dr.Cells[0].Value != null)
                {
                    string nonum = dr.Cells[0].Value.ToString();
                    if (string.IsNullOrEmpty(nonum))
                    {
                        for (int j = 0; j < nonum.Length; j++)
                        {
                            byte tmpbyte = Convert.ToByte(nonum[j]);
                            if (tmpbyte < 48 || tmpbyte > 57)
                            {
                                MsgBox.Show(MSG_CVMANAGE_007, nonum);
                                return false;
                            }
                        }
                    }
                }

                //日期格式检查
                if (dr.Cells[3].Value != null)
                {
                    string ymd = dr.Cells[3].Value.ToString();
                    int errortype = 0;
                    if (!string.IsNullOrEmpty(ymd))
                    {
                        if (!service.YYYYMMDDFormatCheck(ymd,out errortype))
                        {
                            switch (errortype)
                            {
                                case 1:
                                    MsgBox.Show(MSG_CVMANAGE_001, ymd);
                                    break;
                                case 2:
                                    MsgBox.Show(MSG_CVMANAGE_002, ymd);
                                    break;
                            }
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 声优编号重复检查
        /// </summary>
        /// <param name="cvid"></param>
        /// <returns></returns>
        private bool CVIDRepeatCheck(int cvid)
        {            
            //编号重复检查
            if (!service.CVIDRepeatCheck(cvid))
            {
                string cvName = service.GetCVNameByCVID(cvid);
                MsgBox.Show(MSG_CVMANAGE_008, cvid, cvName);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获得选中行声优ID列表
        /// </summary>
        /// <returns></returns>
        private List<CV> GetChooseCVs()
        {
            List<CV> selectedCV = new List<CV>();

            foreach (DataGridViewCell sdc in cvdataGridView.SelectedCells)
            {
                CV cvInfo = new CV();
                cvInfo.ID = Convert.ToInt32(cvdataGridView.Rows[sdc.RowIndex].Cells[0].Value);
                cvInfo.Name = service.GetCVNameByCVID(cvInfo.ID);

                if (!selectedCV.Contains(cvInfo))
                {
                    selectedCV.Add(cvInfo);
                }
            }

            return selectedCV;
        }

        #endregion

        #region 窗体
        /// <summary>
        /// 载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seiyuu_Load(object sender, EventArgs e)
        {
            ShowCVInfo();
        }

        /// <summary>
        /// 恢复窗体设置
        /// </summary>
        private void FormReset()
        {
            cvdataGridView.Rows.Clear();
            cvdataGridView.ReadOnly = true;
            okbutton.Visible = false;
            cancelbutton.Visible = false;
            addbutton.Enabled = true;
            changebutton.Enabled = true;
            ShowCVInfo();
        }

        /// <summary>
        /// 简易搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchBox.Text != null && SearchBox.Text.ToString() != string.Empty)
            {
                ShowCVInfo(SearchBox.Text.ToString());
            }
        }

        /// <summary>
        /// 简易搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (SearchBox.Text != null && SearchBox.Text.ToString() != string.Empty)
                {
                    ShowCVInfo(SearchBox.Text.ToString());
                }
                e.Handled = true;
            }
        }

        #endregion

        #region 按钮
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchbutton_Click(object sender, EventArgs e)
        {
            List<CV> choosedCV = GetChooseCVs();

            //未选择则返回
            if (choosedCV == null || choosedCV.Count == 0)
            {
                MsgBox.Show(MSG_CVMANAGE_009);
                return;
            }

            try
            {
                DataSet ds = service.Getanime(choosedCV);
                mainform.LoadAnimeMain(ds);
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addbutton_Click(object sender, EventArgs e)
        {
            //控件状态改变
            okbutton.Visible = true;
            cancelbutton.Visible = true;

            addbutton.Enabled = false;
            changebutton.Enabled = false;

            cvdataGridView.ReadOnly = false;
            foreach (DataGridViewRow dr in cvdataGridView.Rows)
            {
                if (dr.Cells[3].Value != null)
                {
                    dr.Cells[3].Value = service.ConvertToYYYYMMDDFromYYYYNianMMYueDDRi(dr.Cells[3].Value.ToString());
                }
                dr.ReadOnly = true;
            }
            cvdataGridView.Rows.Add();
            int newrownum = cvdataGridView.Rows.Count - 1;
            cvdataGridView.Rows[newrownum].Cells[0].Value = service.GetNextCVCount().ToString();
            cvdataGridView.Rows[newrownum].ReadOnly = false;
            
            //操作种类设置
            cmd = cmdtype.Add;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changebutton_Click(object sender, EventArgs e)
        {
            //控件状态改变
            cvdataGridView.ReadOnly = false;
            cvdataGridView.Columns[0].ReadOnly = true;
            okbutton.Visible = true;
            cancelbutton.Visible = true;
            foreach (DataGridViewRow dr in cvdataGridView.Rows)
            {
                if (dr.Cells[3].Value != null)
                {
                    dr.Cells[3].Value = service.ConvertToYYYYMMDDFromYYYYNianMMYueDDRi(dr.Cells[3].Value.ToString());
                }
            }

            this.addbutton.Enabled = false;
            this.changebutton.Enabled = false;

            //操作种类设置
            cmd = cmdtype.Change;
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okbutton_Click(object sender, EventArgs e)
        {
            bool result = false;
            switch (cmd)
            {
                case cmdtype.Add:
                    result = AddCVInfo();
                    break;
                case cmdtype.Change:
                    result = ChangeCVInfo();
                    break;
            }

            if (result == true)
            {
                FormReset();
            }
        }
        
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            FormReset();
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletebutton_Click(object sender, EventArgs e)
        {
            DeleteCVInfo();
        }
        #endregion


    }

}
