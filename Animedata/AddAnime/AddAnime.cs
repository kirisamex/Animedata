﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Main
{
    public partial class AddAnime : Form
    {
        #region 常量与构造

        /// <summary>
        /// 状态FLAG:0-添加;1-修改;2-删除
        /// </summary>
        public int ctr;

        /// <summary>
        /// 
        /// </summary>
        public DataGridViewRow sdr;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="control">状态FLAG:0-添加;1-修改;2-删除</param>
        /// <param name="rownum">选中行动画ID</param>
        /// <param name="mainfm"></param>
        public AddAnime(int control, DataGridViewRow selecteddr, Main mainfm)
        {
            InitializeComponent();
            ctr = control;
            sdr = selecteddr;
            mainform = mainfm;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="control">状态FLAG:0-添加;1-修改;2-删除</param>
        public AddAnime(int control)
        {
            InitializeComponent();
            ctr = control;
        }

        string ERROR = "错误：";

        string ERRORINFO = "错误信息";


        Main mainform = new Main();
        AddanimeDao dao = new AddanimeDao();
        AddAnimeService service = new AddAnimeService();

        #endregion 

        #region 载入
        /// <summary>
        /// 主窗口载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAnime_Load(object sender, EventArgs e)
        {
            //选择控件载入
            this.PlayInfoDataGridView.Controls.Add(this.dateTimePicker1);
            this.CharacterInfoDataGridView.Controls.Add(this.CVbox);

            //根据操作种类进行窗口内容调整
            LoadFormWithAdd(ctr);
        }

        /// <summary>
        /// 文本框信息设定
        /// </summary>
        public void LoadFormWithAdd(int ctr)
        {
            switch (ctr)
            {
                case 0:
                    Animation newAnime = new Animation(null);
                    this.numbox.Text = newAnime.No;
                    break;
                case 1:
                    Animation toChangeAnime = service.GetAnimeFromAnimeNo(sdr.Cells[0].ToString());
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            
        }
        #endregion

        #region 按键
        /// <summary>
        /// 确定按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            switch (ctr)
            {
                case 0:
                    if (AddAnimeInfo() == true)
                    {
                        this.Close();
                        mainform.DataGridViewReload();
                    }
                    break;
                case 1:
                    if (UpdateAnimeInfo() == true)
                    {
                        this.Close();
                        mainform.DataGridViewReload();
                    }
                    break;
            }
        }

        /// <summary>
        /// 取消按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确定并添加下一条按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (AddAnimeInfo() == true)
            {
                mainform.DataGridViewReload();

                foreach (Control c in this.basicinfotab.Controls)
                {
                    if ((c is TextBox) && !string.IsNullOrEmpty(c.Text))
                    {
                        c.Text = string.Empty;
                    }
                }
                

                DataTable dt1=(DataTable)PlayInfoDataGridView.DataSource;
                if (dt1 != null)
                {
                    dt1.Rows.Clear();
                    PlayInfoDataGridView.DataSource = dt1;
                }
                
                DataTable dt2 = (DataTable)CharacterInfoDataGridView.DataSource;
                if (dt2 != null)
                {
                    dt2.Rows.Clear();
                    CharacterInfoDataGridView.DataSource = dt2;
                }

                Animation anime = new Animation(null);
                numbox.Text = anime.No;
                numbox.Focus();
            }
        }

        /// <summary>
        /// 键盘事件预留
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAnime_KeyDown(object sender, KeyEventArgs e)
        {

        }

        #endregion

        #region 信息作成
        /// <summary>
        /// 添加动画信息
        /// </summary>
        /// <returns></returns>
        private bool AddAnimeInfo()
        {
            //填写完整性检查以及格式检查
            if (!AllFillAndFormatCheck())
            {
                return false;
            }

            Animation anime = new Animation(numbox.Text.ToString());
            anime.CNName = cnnamebox.Text.ToString();
            anime.JPName = jpnamebox.Text.ToString();
            anime.Nickname = nnbox.Text.ToString();
            anime.No = numbox.Text.ToString();
            anime.status = service.GetStatusIntFromStatusText(statescbox.Text.ToString());
            anime.original=service.GetOriginalIntFromOriginalText(originalbox.Text.ToString());

            //动画信息规则检查
            if (this.AnimeInfoFormatAndRuleCheck(anime))
            {
                return false;
            }

            anime.playInfoList = this.PlayInfoSeries(anime.No);
            anime.characterList = this.CharacterInfoSeries(anime.No);

            try
            {
                anime.Insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool UpdateAnimeInfo()
        {
            return true;
        }

        /// <summary>
        /// 放送信息作成
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        private List<playinfo> PlayInfoSeries(string animeNo)
        {
            List<playinfo> pInfoList = new List<playinfo>();

            if (PlayInfoDataGridView.RowCount == 1)
            {
                DialogResult diares = MessageBox.Show("动画放送信息未填写，是否继续？", "放送信息未填写",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (diares == DialogResult.No)
                {
                    return pInfoList;
                }
            }

            int nextPlayInfoID = dao.GetMaxInt("PLAYINFO", animeNo) + 1;

            //信息作成
            for (int i = 0; i < PlayInfoDataGridView.RowCount - 1; i++)
            {
                playinfo pInfo = new playinfo();

                pInfo.ID = nextPlayInfoID + i;
                pInfo.animeNo = animeNo;

                if (PlayInfoDataGridView.Rows[i].Cells[0].Value != null)
                {
                    pInfo.info = PlayInfoDataGridView.Rows[i].Cells[0].Value.ToString();
                }

                if (PlayInfoDataGridView.Rows[i].Cells[1].Value != null)
                {
                    pInfo.parts = Convert.ToInt32(PlayInfoDataGridView.Rows[i].Cells[1].Value);
                }

                if (PlayInfoDataGridView.Rows[i].Cells[2].Value != null)
                {
                    string companyName = PlayInfoDataGridView.Rows[i].Cells[2].Value.ToString();
                    pInfo.companyID = service.SetCompanyIDByCompanyName(companyName);
                    if (pInfo.companyID < 0)
                    {
                        MessageBox.Show(ERROR + "未预料的COMPANY_ID", ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (PlayInfoDataGridView.Rows[i].Cells[3].Value != null)
                {
                    pInfo.status=service.GetStatusIntFromStatusText(PlayInfoDataGridView.Rows[i].Cells[3].Value.ToString());
                }

                if (PlayInfoDataGridView.Rows[i].Cells[4].Value != null)
                {
                    string startTimeString = PlayInfoDataGridView.Rows[i].Cells[4].Value.ToString();
                    pInfo.startTime = service.ConvertToDateTimeFromYYYYMM(startTimeString);
                }

                if (PlayInfoDataGridView.Rows[i].Cells[5].Value != null)
                {
                    string watchedTimeString = PlayInfoDataGridView.Rows[i].Cells[5].Value.ToString();
                    pInfo.watchedTime = service.ConvertToDateTimeFromYYYYMM(watchedTimeString);
                }

                pInfoList.Add(pInfo);
            }
            return pInfoList;

        }

        /// <summary>
        /// 角色信息作成
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        private List<character> CharacterInfoSeries(string animeNo)
        {
            List<character> cInfoList = new List<character>();

            if (CharacterInfoDataGridView.RowCount == 1)
            {
                return cInfoList;
            }

            //信息作成
            bool setLeadingNoFromDbFlg = false;
            bool setNonLeadingNoFromDbFlg = false;

            string lastLeadingCharaNo = null;
            string lastNonLeadingCharaNo = null;

            for (int i = 0; i < CharacterInfoDataGridView.RowCount - 1; i++)
            {
                character chara = new character();
                chara.animeNo = animeNo;

                if (CharacterInfoDataGridView.Rows[i].Cells[0].Value != null)
                {
                    chara.name = CharacterInfoDataGridView.Rows[i].Cells[0].Value.ToString();
                }

                if (CharacterInfoDataGridView.Rows[i].Cells[1].Value != null)
                {
                    string CVName = CharacterInfoDataGridView.Rows[i].Cells[1].Value.ToString();
                    chara.CVID = service.SetCVIDByCVName(CVName);
                }

                chara.leadingFLG = Convert.ToBoolean(CharacterInfoDataGridView.Rows[i].Cells[2].Value);

                //设定编号
                try
                {
                    if (chara.leadingFLG)
                    {
                        if (!setLeadingNoFromDbFlg)
                        {
                            chara.No = service.SetCharacterNoFromDB(chara);
                            setLeadingNoFromDbFlg = true;
                            lastLeadingCharaNo = chara.No;
                        }
                        else
                        {
                            chara.No = service.SetCharacterNoFromLastNo(lastLeadingCharaNo);
                        }
                    }
                    else
                    {
                        if (!setNonLeadingNoFromDbFlg)
                        {
                            chara.No = service.SetCharacterNoFromDB(chara);
                            setNonLeadingNoFromDbFlg = true;
                            lastNonLeadingCharaNo = chara.No;
                        }
                        else
                        {
                            chara.No = service.SetCharacterNoFromLastNo(lastNonLeadingCharaNo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                cInfoList.Add(chara);
            }
            return cInfoList;
        }

        #endregion

        #region 填写检查

        /// <summary>
        /// 所有的填写内容完整性与格式检查
        /// </summary>
        /// <returns>true:通过 false:不通过</returns>
        public bool AllFillAndFormatCheck()
        {
            //动画信息完整性检查
            if (!AnimeInfoFullCheck())
            {
                return false;
            }

            //角色、声优信息0行检查
            if (!PlayInfoAndCharacterInfoFullChekc())
            {
                return false;
            }

            //放送信息null以及格式检查
            if (!PlayInfoNullAndFormatCheck())
            {
                return false;
            }

            //角色信息null检查
            if (!CharacterInfoNullAndFormatCheck())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 动画基本信息填写检查
        /// </summary>
        /// <returns>true:完整 false:不完整</returns>
        public bool AnimeInfoFullCheck()
        {
            foreach (Control c in this.tabControl1.TabPages[0].Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    if (c.Text == string.Empty)
                    {
                        MessageBox.Show("基本信息填写不完整，请补充。", "基本信息不完整", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            return true;
        }

        /// <summary>
        /// 放送信息与角色信息填写检查
        /// </summary>
        /// <returns>false:继续添加 true:返回</returns>
        private bool PlayInfoAndCharacterInfoFullChekc()
        {
            if (this.PlayInfoDataGridView.Rows.Count == 1 || CharacterInfoDataGridView.Rows.Count == 1)
            {
                DialogResult res = MessageBox.Show("放送信息或声优信息未填写，是否继续添加？",
                    "信息不完整", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 放送信息完整性检查
        /// </summary>
        /// <returns>false:不完整 true:完整</returns>
        private bool PlayInfoNullAndFormatCheck()
        {
            int rowscount = PlayInfoDataGridView.Rows.Count;

            //除最后一行新规行以外检查
            for (int i = 0; i < rowscount - 1; i++)
            {
                //放送内容Check
                if (string.IsNullOrEmpty(PlayInfoDataGridView.Rows[i].Cells[0].ToString()))
                {
                    MessageBox.Show("放送信息不完整：请填写第" + i + 1.ToString() + "行的放送内容！",
                        "放送信息错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //话数check
                if (string.IsNullOrEmpty(PlayInfoDataGridView.Rows[i].Cells[1].ToString()))
                {
                    MessageBox.Show("放送信息不完整：请填写第" + i + 1.ToString() + "行的话数！",
                        "放送信息错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //制作公司check
                if (string.IsNullOrEmpty(PlayInfoDataGridView.Rows[i].Cells[2].ToString()))
                {
                    MessageBox.Show("放送信息不完整：请填写第" + i + 1.ToString() + "行的制作公司！",
                        "放送信息错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //状态check
                if (string.IsNullOrEmpty(PlayInfoDataGridView.Rows[i].Cells[3].ToString()))
                {
                    MessageBox.Show("放送信息不完整：请填写第" + i + 1.ToString() + "行的状态！",
                        "放送信息错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //话数int Format Check
                string seriesnum = PlayInfoDataGridView.Rows[i].Cells[1].Value.ToString();
                for (int j = 0; j < seriesnum.Length; j++)
                {
                    byte tmpbyte = Convert.ToByte(seriesnum[j]);
                    if (tmpbyte < 48 || tmpbyte > 57)
                    {
                        MessageBox.Show("放送信息中的话数必须为数字!",
                       "放送信息错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 角色信息完整性检查
        /// </summary>
        /// <returns>false:不完整 true:完整</returns>
        private bool CharacterInfoNullAndFormatCheck()
        {
            int rowscount = CharacterInfoDataGridView.Rows.Count;

            if (rowscount == 1)
            {
                return true;
            }

            //除最后一行新规行以外检查
            for (int i = 0; i < rowscount - 1; i++)
            {
                //放送内容Check
                if (string.IsNullOrEmpty(CharacterInfoDataGridView.Rows[i].Cells[0].ToString()))
                {
                    MessageBox.Show("角色信息不完整：请填写第" + i + 1.ToString() + "行的角色！",
                        "角色信息错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //放送内容Check
                if (string.IsNullOrEmpty(CharacterInfoDataGridView.Rows[i].Cells[1].ToString()))
                {
                    MessageBox.Show("角色信息不完整：请填写第" + i + 1.ToString() + "行的声优！",
                        "角色信息错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 格式与规则检查
        /// </summary>
        /// <returns></returns>
        public bool AnimeInfoFormatAndRuleCheck(Animation anime)
        {
            //动画编号格式
            Regex r1 = new Regex(@"^[A-Z][0-9]{3}$");
            Match m1 = r1.Match(anime.No);

            if (!m1.Success)
            {
                MessageBox.Show("警告：动画编号格式不正确！", "格式错误"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            Regex r2 = new Regex(@"^[A-Z]+[a-zA-Z]");
            Match m2 = r2.Match(anime.Nickname);
            if (!m2.Success)
            {
                MessageBox.Show("警告：动画简写格式不正确！\n简写需要是英文半角字母，且首字母大写。", "格式错误"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //动画信息唯一性
            if (!AnimationRepeatCheck(anime, ctr))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 动画是否重复
        /// </summary>
        /// <param name="anime"></param>
        /// <param name="ctr"></param>
        /// <returns>true:不重复 false:重复</returns>
        private bool AnimationRepeatCheck(Animation anime, int ctr)
        {
            Animation repeatAnime = new Animation();
            switch (ctr)
            {
                case 0:
                    repeatAnime = dao.SearchRepeatAnimeInfo(anime);
                    break;
                case 1:
                    //repcmd = "SELECT id,animename,animenickname FROM (SELECT * FROM animation WHERE id <> '" + id + "') WHERE id='" + anime.animeid + "' OR animename='" + anime.name + "'OR animenickname='" + anime.nickname + "'";
                    break;
            }

            if (repeatAnime == null)
            {
                return true;
            }
            else
            {
                MessageBox.Show(ERROR + "填写的部分动画信息与以下信息重复，操作失败！" +
                    "\n动画编号:" + repeatAnime.No + "; 中文名称:" + repeatAnime.CNName +
                    "; 日文名称:" + repeatAnime.JPName + "; 动画简称:" + repeatAnime.Nickname + "",
                    "信息重复", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region 窗体

        /// <summary>
        /// DGV1格式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewCell CurrnetCell = this.PlayInfoDataGridView.CurrentCell;

            //时间选择框
            if ((CurrnetCell != null && CurrnetCell.OwningColumn.Name == "playstarttime") || (CurrnetCell != null && CurrnetCell.OwningColumn.Name == "watchtime"))
            {
                Rectangle TmpRect = this.PlayInfoDataGridView.GetCellDisplayRectangle(CurrnetCell.ColumnIndex, CurrnetCell.RowIndex, true);
               if (CurrnetCell.Value != null)
                {
                    this.dateTimePicker1.Value = Convert.ToDateTime(CurrnetCell.Value);
                }
                this.dateTimePicker1.Size = TmpRect.Size;
                this.dateTimePicker1.Top = TmpRect.Top;
                this.dateTimePicker1.Left = TmpRect.Left;
                this.dateTimePicker1.Visible = true;
                this.dateTimePicker1.MaxDate = System.DateTime.Today;
                this.dateTimePicker1.Value = System.DateTime.Today;
           }
           else            
            {
                this.dateTimePicker1.Visible = false;
            }

            //制作公司选择框
            if (CurrnetCell != null && CurrnetCell.OwningColumn.Name == "company")
            {
                Rectangle TmpRect = this.PlayInfoDataGridView.GetCellDisplayRectangle(CurrnetCell.ColumnIndex, CurrnetCell.RowIndex, true);
                if (CurrnetCell.Value != null)
                {
                    this.companybox.Text = CurrnetCell.Value.ToString();
                }
                this.companybox.Size = TmpRect.Size;
                this.companybox.Top = TmpRect.Top+2;
                this.companybox.Left = TmpRect.Left+2;
                this.companybox.Visible = true;

                DataTable dt = new DataTable();
                try
                {
                    DataSet ds = dao.LoadCompanyName();
                    dt = ds.Tables[0];
                    DataRow dr = dt.NewRow();
                    dr["COMPANY_NAME"] = string.Empty;
                    dt.Rows.InsertAt(dr, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                companybox.DisplayMember = "COMPANY_NAME";
                companybox.ValueMember = "COMPANY_NAME";
                companybox.DataSource = dt.DefaultView;
            }
            else
            {
                this.companybox.Visible = false;
            }
        }

        /// <summary>
        /// 显示选择的时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {   
            string dtp = service.ConvertToYYYYMMFromDatetime(this.dateTimePicker1.Value);
            this.PlayInfoDataGridView.CurrentCell.Value = dtp;
        }

        /// <summary>
        /// DGV2格式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewCell CurrnetCell = this.CharacterInfoDataGridView.CurrentCell;

            //声优名称选择框
            if (CurrnetCell != null && CurrnetCell.OwningColumn.Name == "seiyuuname")
            {
                Rectangle TmpRect = this.CharacterInfoDataGridView.GetCellDisplayRectangle(CurrnetCell.ColumnIndex, CurrnetCell.RowIndex, true);
                if (CurrnetCell.Value != null)
                {
                    this.CVbox.Text = CurrnetCell.Value.ToString();
                }
                this.CVbox.Size = TmpRect.Size;
                this.CVbox.Top = TmpRect.Top;
                this.CVbox.Left = TmpRect.Left;
                this.CVbox.Visible = true;
            }
            else
            {
                this.CVbox.Visible = false;
            }

            DataTable dt = new DataTable();

            try
            {
                DataSet ds = dao.LoadCVName();
                dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["CV_NAME"] = string.Empty;
                dt.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            CVbox.DisplayMember = "CV_NAME";
            CVbox.ValueMember = "CV_NAME";
            CVbox.DataSource = dt.DefaultView;
        }

        /// <summary>
        /// 离开声优选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seiyuubox_Leave(object sender, EventArgs e)
        {
            this.CharacterInfoDataGridView.CurrentCell.Value = this.CVbox.Text.ToString();
        }
       
        /// <summary>
        /// 离开制作公司选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void companybox_Leave(object sender, EventArgs e)
        {
            this.PlayInfoDataGridView.CurrentCell.Value = this.companybox.Text.ToString();
        }

        /// <summary>
        /// 修改窗体内容设置
        /// </summary>
        /// <param name="anime"></param>
        private void SetAnimeWindowWithAnime(Animation anime)
        {
            this.Text = "修改动画信息";
            this.numbox.ReadOnly = true;
            this.button3.Visible = false;
            this.AcceptButton = button1;

            numbox.Text = anime.No;
            cnnamebox.Text = anime.CNName;
            jpnamebox.Text=anime.JPName;
            nnbox.Text = anime.Nickname;
            statescbox.Text = service.GetStatusTextFromStatusInt(anime.status);
            originalbox.Text = service.GetOriginalTextFromOriginalInt(anime.original);

            foreach(playinfo pInfo in anime.playInfoList)
            {
                DataGridViewRow dgvrow =new DataGridViewRow();
                dgvrow.Cells[0].Value=pInfo.info;
                dgvrow.Cells[1].Value=pInfo.parts.ToString();
                dgvrow.Cells[2].Value=service.GetCompanyNameByCompanyNo(pInfo.companyID);
                dgvrow.Cells[3].Value=service.GetStatusTextFromStatusInt(pInfo.status);
                dgvrow.Cells[4].Value=service.ConvertToYYYYMMFromDatetime(pInfo.startTime);
                dgvrow.Cells[5].Value=service.ConvertToYYYYMMFromDatetime(pInfo.watchedTime);;

                PlayInfoDataGridView.Rows.Add(dgvrow);
            }

            foreach(character cInfo in anime.characterList)
            {
            }
            
        }
 

        
        #endregion
    }
}
