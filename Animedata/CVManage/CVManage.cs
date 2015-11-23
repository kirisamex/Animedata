using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Main;

namespace Main
{
    public partial class CVManage : Form
    {
        public CVManage()
        {
            InitializeComponent();
        }

        #region 常量

        /// <summary>
        /// 主窗口传递
        /// </summary>
        private Main mainform;

        /// <summary>
        /// 服务传递
        /// </summary>
        CVManageService service = new CVManageService();

        string ERROR = "错误：";

        string ERRORINFO = "错误信息";

        /// <summary>
        /// 操作种类
        /// </summary>
        enum cmdtype : byte
        {
            Add, Change
        };

        cmdtype cmd = new cmdtype();

        #endregion

        #region 方法

        /// <summary>
        /// 载入声优信息
        /// </summary>
        public void LoadCVInfo()
        {
            DataSet ds = service.LoadCVInfo();

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
                MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
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
                    service.ShowErrorMessage(ex.ToString());
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
                service.InsertCVInfo(cvInfo);
            }
            catch (Exception ex)
            {
                service.ShowErrorMessage(ex.Message);
                return false;
            }
            return true;
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
                    service.ShowErrorMessage("有未填写的声优编号！");
                    return false;
                }

                //姓名空检查
                if (dr.Cells[1].Value == null || string.IsNullOrEmpty(dr.Cells[1].Value.ToString()))
                {
                    service.ShowErrorMessage("有未填写的声优姓名！");
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
                                service.ShowErrorMessage("编号必须为半角数字!");
                                return false;
                            }
                        }
                    }
                }

                //日期格式检查
                if (dr.Cells[3].Value != null)
                {
                    string ymd = dr.Cells[3].Value.ToString();
                    if (!string.IsNullOrEmpty(ymd))
                    {
                        if (!service.YYYYMMDDFormatCheck(ymd))
                        {
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
            //编号空检查
            if (!service.CVIDRepeatCheck(cvid))
            {
                service.ShowErrorMessage("声优编号与现有编号重复！");
                return false;
            }

            return true;
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
            LoadCVInfo();
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
            LoadCVInfo();
        }


        #endregion

        #region 按钮
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
            this.Close();
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletebutton_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }

}
