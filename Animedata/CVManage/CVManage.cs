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
using Main.Lib.Style;

namespace Main
{
    public partial class CVManage : Form
    {
        public static CVManage CVManageFm = null;

        public CVManage()
        {
            CVManageFm = this;
            InitializeComponent();
        }

        #region 常量
        //全局变量
        cmdtype cmd = new cmdtype();

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

        //实例化
        CVManageService service = new CVManageService();
        DataGridViewStyle dgvStyle = new DataGridViewStyle();

        ClientDS.CVListDataTable cvList = new ClientDS.CVListDataTable();
        ClientDS.CVHistDataTable cvHist = new ClientDS.CVHistDataTable();
     
        #region 列名
        const string NOCLN = "CVID";
        const string NAMECLN = "CVName";
        const string GENDERCLN = "CVGender";
        const string BIRTHCLN = "CVBirthday";

        const string CHARACLN = "Character";
        const string ANIMECLN="Anime";
        const string ANIMENOCLN = "AnimeNo";
        const string ISMAINCLN = "IsMain";
        #endregion

        #region 信息
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
        /// <summary>没有任何信息被修改！ </summary>
        const string MSG_CVMANAGE_010 = "MSG-CVMANAGE-010";
        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 展示声优信息
        /// </summary>
        public void LoadCVInfo()
        {
            DataSet ds = service.LoadCVInfo();
            ShowCVInfo(ds);
        }

        /// <summary>
        /// 展示声优信息
        /// 简易搜索
        /// </summary>
        /// <param name="target"></param>
        public void LoadCVInfo(string target)
        {
            DataSet ds = service.LoadCVInfo(target);
            ShowCVInfo(ds);
        }

        /// <summary>
        /// 载入声优DataSet
        /// </summary>
        /// <param name="ds"></param>
        private void LoadCVDataSet(DataSet ds)
        {
            try
            {
                //CVList
                cvList.Clear();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ClientDS.CVListRow cvRow = cvList.NewCVListRow();

                    cvRow.CVID = Convert.ToInt32(dr[0]);
                    cvRow.CVName = dr[1].ToString();

                    if (dr[2] != DBNull.Value)
                    {
                        cvRow.CVGender = dr[2].ToString();
                    }
                    else
                    {
                        cvRow.CVGender = string.Empty;
                    }

                    if (dr[3] != DBNull.Value)
                    {
                        cvRow.CVBirth = Convert.ToDateTime(dr[3]);
                    }
                    else
                    {
                        cvRow.CVBirth = DateTime.MinValue;
                    }

                    cvList.Rows.Add(cvRow);
                }
                cvList.AcceptChanges();

                //CVHist
                cvHist.Clear();

                //取得对象CVID
                List<int> cvids = new List<int>();
                foreach (ClientDS.CVListRow dr in cvList)
                {
                    cvids.Add(dr.CVID);
                }

                if (cvids.Count != 0)
                {
                    DataSet Histds = service.GetCVHist(cvids);

                    foreach (DataRow dr in Histds.Tables[0].Rows)
                    {
                        ClientDS.CVHistRow cvRow = cvHist.NewCVHistRow();
                        cvRow.CVName = dr[0].ToString();
                        cvRow.CVID = Convert.ToInt32(dr[1]);
                        cvRow.CharacterNo = dr[2].ToString();
                        cvRow.CharacterName = dr[3].ToString();
                        cvRow.IsMainCharacter = Convert.ToBoolean(dr[4]);
                        cvRow.AnimeNo = dr[5].ToString();
                        cvRow.AnimeCNName = dr[6].ToString();
                        cvRow.AnimeJPName = dr[7].ToString();
                        cvHist.Rows.Add(cvRow);
                    }
                }
                cvHist.AcceptChanges();
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
        }


        /// <summary>
        /// 载入声优信息
        /// </summary>
        private void ShowCVInfo(DataSet ds)
        {
            cvdataGridView.Rows.Clear();

            DataSet ListDS = ds;
            LoadCVDataSet(ds);

            try
            {
                foreach (ClientDS.CVListRow dr in cvList.Rows)
                {
                    DataGridViewRow dgvr = cvdataGridView.Rows[cvdataGridView.Rows.Add()];

                    dgvr.Cells[NOCLN].Value = dr.CVID;
                    dgvr.Cells[NAMECLN].Value = dr.CVName;

                    if (dr.CVGender != string.Empty)
                    {
                        dgvr.Cells[GENDERCLN].Value = service.GetGenderStringFromGenderChar(dr.CVGender);
                    }

                    if (dr.CVBirth != DateTime.MinValue)
                    {
                        dgvr.Cells[BIRTHCLN].Value = service.ConvertToYYYYNianMMYueDDRiFromDatetime(Convert.ToDateTime(dr.CVBirth));
                    }
                }

                //设置格式
                dgvStyle.SetDataGridViewAndSplit(splitContainer2, cvdataGridView);

                ShowCVHistInfo();
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
            List<CV> NeedUpdateCVList = new List<CV>();

            foreach (DataGridViewRow dr in cvdataGridView.Rows)
            {
                CV newCvInfo = new CV();
                newCvInfo.ID = Convert.ToInt32(dr.Cells[0].Value);
                newCvInfo.Name = dr.Cells[1].Value.ToString();
                if (dr.Cells[2].Value != null)
                {
                    newCvInfo.Gender = service.GetGenderCharFromGenderString(dr.Cells[2].Value.ToString());
                }
                if (dr.Cells[3].Value != null)
                {
                    newCvInfo.Brithday = service.ConvertToDateTimeFromYYYYMMdd(dr.Cells[3].Value.ToString());
                }

                var targetCV = from cvs in this.cvList
                               where cvs.CVID == newCvInfo.ID 
                               select cvs;

                
                foreach (ClientDS.CVListRow cvr in targetCV)
                {
                    if (!cvr.CVName.Equals(newCvInfo.Name) || !cvr.CVGender.Trim().Equals(newCvInfo.Gender??string.Empty) || !cvr.CVBirth.Equals(newCvInfo.Brithday))
                    {
                        NeedUpdateCVList.Add(newCvInfo);
                    }
                }
            }

            if (NeedUpdateCVList.Count == 0)
            {
                MsgBox.Show(MSG_CVMANAGE_010);
                return false;
            }

            //修改信息
            foreach (CV cvInfo in NeedUpdateCVList)
            {
                service.UpdateCVInfo(cvInfo);
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

            //既存CVID
            List<int> OldCVIDs = new List<int>();
            var CVs = from cvs in this.cvList
                      select cvs;
            foreach (ClientDS.CVListRow i in CVs)
            {
                OldCVIDs.Add(i.CVID);
            }

            foreach (DataGridViewRow dr in cvdataGridView.Rows)
            {
                if (!OldCVIDs.Contains(Convert.ToInt32(dr.Cells[NOCLN].Value)))
                {
                    //DataGridViewRow dr = cvdataGridView.Rows[cvdataGridView.Rows.Count - 1];
                    CV cvInfo = new CV();

                    cvInfo.ID = Convert.ToInt32(dr.Cells[NOCLN].Value);
                    cvInfo.Name = dr.Cells[NAMECLN].Value.ToString();
                    if (dr.Cells[GENDERCLN].Value != null)
                    {
                        cvInfo.Gender = service.GetGenderCharFromGenderString(dr.Cells[2].Value.ToString());
                    }
                    if (dr.Cells[BIRTHCLN].Value != null)
                    {
                        cvInfo.Brithday = service.ConvertToDateTimeFromYYYYMMdd(dr.Cells[3].Value.ToString());
                    }

                    //声优编号重复检查 #8:目前CVID不可见，增加方法里移除该检查
                    //if (!CVIDRepeatCheck(cvInfo.ID))
                    //    return false;

                    try
                    {
                        cvInfo.Insert();
                    }
                    catch (Exception ex)
                    {
                        MsgBox.Show(MSG_COMMON_001, ex.ToString());
                        return false;
                    }

                    //目前每次只能新增一名CV
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除声优信息
        /// </summary>
        /// <returns></returns>
        private bool DeleteCVInfo()
        {
            if (MsgBox.Show(MSG_CVMANAGE_004)==DialogResult.Yes)
            {
                List<CV> selectCVList = GetSelectedCVs();
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
        /// 展示声优履历信息
        /// </summary>
        private void ShowCVHistInfo()
        {
            CV curCV = GetSelectedCV();

            if (curCV != null)
            {
                ShowCVHistInfo(curCV);
            }
        }

        /// <summary>
        /// 载入声优履历DataSet
        /// </summary>
        /// <param name="ds"></param>
        private void LoadCVHistDataSet(DataSet ds)
        {
            cvHist.Clear();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ClientDS.CVHistRow cvRow = cvHist.NewCVHistRow();
                cvRow.CVName = dr[0].ToString();
                cvRow.CVID = Convert.ToInt32(dr[1]);
                cvRow.CharacterNo = dr[2].ToString();
                cvRow.CharacterName = dr[3].ToString();
                cvRow.IsMainCharacter = Convert.ToBoolean(dr[4]);
                cvRow.AnimeNo = dr[5].ToString();
                cvRow.AnimeCNName = dr[6].ToString();
                cvRow.AnimeJPName = dr[7].ToString();
                cvHist.Rows.Add(cvRow);
            }
            cvHist.AcceptChanges();
        }

        /// <summary>
        /// 载入声优履历
        /// </summary>
        /// <param name="cvInfo"></param>
        private void ShowCVHistInfo(CV cvInfo)
        {
            try
            {
                CVHistdataGridView.Rows.Clear();

                var targetList = from cvhist in this.cvHist
                                 where cvhist.CVID == cvInfo.ID
                                 orderby cvhist.AnimeNo,cvhist.CharacterName
                                 select cvhist;

                foreach (ClientDS.CVHistRow dr in targetList)
                {
                    DataGridViewRow dgvr = CVHistdataGridView.Rows[CVHistdataGridView.Rows.Add()];

                    dgvr.Cells[CHARACLN].Value = dr.CharacterName;
                    dgvr.Cells[ANIMECLN].Value = dr.AnimeCNName;
                    dgvr.Cells[ANIMENOCLN].Value = dr.AnimeNo;
                    dgvr.Cells[ISMAINCLN].Value = service.GetMainCharaStringByBool(dr.IsMainCharacter);
                }

                for (int i = 0; i < CVHistdataGridView.ColumnCount; i++)
                {
                    CVHistdataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    CVHistdataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
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
                if (dr.Cells[NOCLN].Value == null || string.IsNullOrEmpty(dr.Cells[0].Value.ToString()))
                {
                    MsgBox.Show(MSG_CVMANAGE_005);
                    return false;
                }

                //姓名空检查
                if (dr.Cells[NAMECLN].Value == null || string.IsNullOrEmpty(dr.Cells[1].Value.ToString()))
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
                if (dr.Cells[NOCLN].Value != null)
                {
                    string nonum = dr.Cells[NOCLN].Value.ToString();
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
                if (dr.Cells[BIRTHCLN].Value != null)
                {
                    string ymd = dr.Cells[BIRTHCLN].Value.ToString();
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
        private List<CV> GetSelectedCVs()
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

        /// <summary>
        /// 获得焦点格所在行声优信息
        /// </summary>
        /// <returns></returns>
        private CV GetSelectedCV()
        {
            if (cvdataGridView.CurrentCell != null)
            {
                CV cvInfo = new CV();
                try
                {
                    cvInfo.ID = Convert.ToInt32(cvdataGridView.Rows[cvdataGridView.CurrentCell.RowIndex].Cells[NOCLN].Value);
                }
                catch (Exception ex) { MsgBox.Show(MSG_COMMON_001, ex.ToString()); }
                return cvInfo;
            }
            return null;
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

        /// <summary>
        /// 简易搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchBox.Text != null && SearchBox.Text.ToString() != string.Empty)
            {
                LoadCVInfo(SearchBox.Text.ToString());
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
                    LoadCVInfo(SearchBox.Text.ToString());
                }
                e.Handled = true;
            }
        }

        /// <summary>
        /// 变更选中单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cvdataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowCVHistInfo();
        }
        #endregion

        #region 按钮
        /// <summary>
        /// 搜索 =! 暂时未使用 != 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchbutton_Click(object sender, EventArgs e)
        {
            List<CV> choosedCV = GetSelectedCVs();

            //未选择则返回
            if (choosedCV == null || choosedCV.Count == 0)
            {
                MsgBox.Show(MSG_CVMANAGE_009);
                return;
            }

            try
            {
                DataSet ds = service.Getanime(choosedCV);
                MainForm.Mainfm.ShowAnime(ds);
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

            //添加新行
            int newrownum = cvdataGridView.Rows.Add();
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
            okbutton.Visible = true;
            cancelbutton.Visible = true;

            addbutton.Enabled = false;
            changebutton.Enabled = false;

            cvdataGridView.ReadOnly = false;
            cvdataGridView.Columns[0].ReadOnly = true;

            foreach (DataGridViewRow dr in cvdataGridView.Rows)
            {
                if (dr.Cells[3].Value != null)
                {
                    dr.Cells[3].Value = service.ConvertToYYYYMMDDFromYYYYNianMMYueDDRi(dr.Cells[3].Value.ToString());
                }
            }

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

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            FormReset();
        }
        #endregion

        #region 键盘
        private void CVManage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    FormReset();
                    break;
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 双击动画名称显示动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CVHistdataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == CVHistdataGridView.Columns[ANIMECLN].Index || e.ColumnIndex == CVHistdataGridView.Columns[ANIMENOCLN].Index)
            {
                MainForm.Mainfm.SimpleSearch(CVHistdataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                MainForm.Mainfm.Focus();
            }
        }
        #endregion
    }

}
