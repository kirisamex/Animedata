using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Main.Lib.Message;
using Main.Lib.Const;

namespace Main
{
    public partial class AddAnime : Form
    {
        #region 常量

        //全局变量
        public command cmd;
        public DataGridViewRow sdr;

        //实例
        MainForm mainform = new MainForm();
        AddanimeDao dao = new AddanimeDao();
        AddAnimeService service = new AddAnimeService();

        #region 信息框
        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>动画编号 {0} 格式不正确！\n目前允许的编号格式为：大写字母+3位数字。</summary>
        const string MSG_COMMON_004 = "MSG-COMMON-004";
        /// <summary>动画简写 {0} 格式不正确！\n简写需要是英文半角字母，且首字母大写。</summary>
        const string MSG_COMMON_005 = "MSG-COMMON-005";

        /// <summary>基本信息填写不完整，请补充。</summary>
        const string MSG_ADDANIME_001 = "MSG-ADDANIME-001";
        /// <summary>放送信息不完整：请填写第{0}行的放送内容！</summary>
        const string MSG_ADDANIME_002 = "MSG-ADDANIME-002";
        /// <summary>放送信息不完整：请填写第{0}行的状态！</summary>
        const string MSG_ADDANIME_003 = "MSG-ADDANIME-003";
        /// <summary>第{0}行的话数格式不正确，话数必须为半角数字！</summary>
        const string MSG_ADDANIME_004 = "MSG-ADDANIME-004";
        /// <summary>请填写第{0}行的角色！</summary>
        const string MSG_ADDANIME_005 = "MSG-ADDANIME-005";
        /// <summary>请填写第{0}行的声优！</summary>
        const string MSG_ADDANIME_006 = "MSG-ADDANIME-006";
        /// <summary>填写的部分动画基本信息与以下信息重复，操作失败！\n动画编号:{0} \n中文名称:{1} \n日文名称:{2} \n动画简称:{3}</summary>
        const string MSG_ADDANIME_007 = "MSG-ADDANIME-007";
        /// <summary>放送信息或声优信息未填写，是否继续？</summary>
        const string MSG_ADDANIME_008 = "MSG-ADDANIME-008";
        #endregion

        #region 列名
        /// <summary>放送内容 </summary>
        const string PLAYINFOCLN = "playinfo";
        /// <summary>话数 </summary>
        const string PLAYCOUNTSCLN = "playcounts";
        /// <summary>制作公司 </summary>
        const string COMPANYCLN = "company";
        /// <summary>状态 </summary>
        const string STATUSCLN = "status";
        /// <summary>播放时间 </summary>
        const string PLAYSTARTTIMECLN = "playstarttime";
        /// <summary>收看时间 </summary>
        const string WATCHEDTIMECLN = "watchtime";
        /// <summary>播放信息ID </summary>
        const string PLAYINFOIDCLN = "PlayInfoID";
        /// <summary>角色名 </summary>
        const string CHARACTERNAMECLN = "charactername";
        /// <summary>声优名 </summary>
        const string SEIYUUNAMECLN = "seiyuuname";
        /// <summary>是否主角 </summary>
        const string ISMAINCHARACTERCLN = "ismaincharacter";
        /// <summary>角色编号 </summary>
        const string CHARACTERNOCLN = "characterNo";
        #endregion

        /// <summary>
        /// 操作种类
        /// </summary>
        public enum command
        {
            /// <summary>
            /// 添加
            /// </summary>
            Add = 0,
            /// <summary>
            /// 修改
            /// </summary>
            Update = 1,
            /// <summary>
            /// 删除
            /// </summary>
            Delete = 2,
        };

        #endregion

        #region 构造

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="control">操作种类</param>
        /// <param name="rownum">选中行动画ID</param>
        /// <param name="mainfm"></param>
        public AddAnime(command command, DataGridViewRow selecteddr, MainForm mainfm)
        {
            InitializeComponent();
            cmd = command;
            sdr = selecteddr;
            mainform = mainfm;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="control">操作种类</param>
        public AddAnime(command control)
        {
            InitializeComponent();
            cmd = control;
        }

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
            this.CharacterInfoDataGridView.Controls.Add(this.CVbox);

            //根据操作种类进行窗口内容调整
            LoadFormWithAdd(cmd);
        }

        /// <summary>
        /// 文本框信息设定
        /// </summary>
        public void LoadFormWithAdd(command ctr)
        {
            switch (ctr)
            {
                case command.Add:
                    Animation newAnime = new Animation(null);
                    this.numbox.Text = newAnime.No;
                    break;
                case command.Update:
                    Animation toChangeAnime = service.GetAnimeFromAnimeNo(sdr.Cells[0].Value.ToString());
                    this.SetAnimeWindowWithAnime(toChangeAnime);
                    break;
                case command.Delete:
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
            if (CommandAnimeInfo(cmd) == true)
            {
                this.Close();
                //mainform.DataGridViewReload();
                //ToDO:静态修改数据
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
            if (CommandAnimeInfo(cmd) == true)
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
        /// 移除当前行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveRowButton_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Text)
            {
                case FormText.BASIC_INFO:
                    break;
                case FormText.PLAY_INFO:
                    if (PlayInfoDataGridView.CurrentRow != null)
                    {
                        PlayInfoDataGridView.Rows.RemoveAt(PlayInfoDataGridView.CurrentRow.Index);
                    }
                    break;
                case FormText.CHARACTER_INFO:
                    if (CharacterInfoDataGridView.CurrentRow != null)
                    {
                        CharacterInfoDataGridView.Rows.RemoveAt(CharacterInfoDataGridView.CurrentRow.Index);
                    }
                    break;
            }
        }

        /// <summary>
        /// 增加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRowButton_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Text)
            {
                case FormText.BASIC_INFO:
                    break;
                case FormText.PLAY_INFO:
                    PlayInfoDataGridView.Rows.Add();
                    break;
                case FormText.CHARACTER_INFO:
                    CharacterInfoDataGridView.Rows.Add();
                    break;
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

        private void CharacterInfoDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (CharacterInfoDataGridView.CurrentCell.ColumnIndex == CharacterInfoDataGridView.Columns[ISMAINCHARACTERCLN].Index)
                    {
                    }
                    break;
            }
        }

        #endregion

        #region 信息作成
        /// <summary>
        /// 操作动画信息(添加或修改)
        /// </summary>
        /// <param name="ctr">操作类型</param>
        /// <returns></returns>
        private bool CommandAnimeInfo(command ctr)
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
            if (!AnimeInfoFormatAndRuleCheck(ctr,anime))
            {
                return false;
            }

            try
            {
                anime.playInfoList = this.PlayInfoSeries(anime.No);
                anime.characterList = this.CharacterInfoSeries(anime.No);

                if (ctr == command.Add)
                {
                    if (anime.Insert())
                    {
                        return true;
                    }
                }
                else if (ctr == command.Update)
                {
                    if (anime.Update())
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 放送信息作成
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        private List<PlayInfo> PlayInfoSeries(string animeNo)
        {
            List<PlayInfo> pInfoList = new List<PlayInfo>();

            if (PlayInfoDataGridView.Rows.Count == 0)
            {
                return pInfoList;
            }

            //信息作成
            int NextPlayinfoID = dao.GetMaxInt(FormText.PLAYINFO, animeNo) + 1;
            int NewplayinfoCount = 0;
            for (int i = 0; i < PlayInfoDataGridView.RowCount; i++)
            {
                //空行则不处理
                if (PlayInfoDataGridView.Rows[i].IsNewRow ||
                    PlayInfoDataGridView.Rows[i].Cells[PLAYINFOCLN].Value == null)
                {
                    continue;
                }
                
                PlayInfo pInfo = new PlayInfo();
                //命令为新增 或 命令为增加&(id为空||id为0)
                if ((cmd == command.Add)
                    || (PlayInfoDataGridView.Rows[i].Cells[PLAYINFOIDCLN].Value == null
                    || (Convert.ToInt32(PlayInfoDataGridView.Rows[i].Cells[PLAYINFOIDCLN].Value) == 0)
                    && cmd == command.Update)
                       )
                {
                    pInfo.ID = NextPlayinfoID + NewplayinfoCount;
                    NewplayinfoCount++;
                }
                else if (PlayInfoDataGridView.Rows[i].Cells[PLAYINFOIDCLN].Value != null && cmd == command.Update)
                {
                    pInfo.ID = Convert.ToInt32(PlayInfoDataGridView.Rows[i].Cells[PLAYINFOIDCLN].Value);
                }

                pInfo.animeNo = animeNo;

                if (PlayInfoDataGridView.Rows[i].Cells[PLAYINFOCLN].Value != null)
                {
                    pInfo.info = PlayInfoDataGridView.Rows[i].Cells[PLAYINFOCLN].Value.ToString();
                }

                if (PlayInfoDataGridView.Rows[i].Cells[PLAYCOUNTSCLN].Value != null)
                {
                    pInfo.parts = Convert.ToInt32(PlayInfoDataGridView.Rows[i].Cells[PLAYCOUNTSCLN].Value);
                }

                if (PlayInfoDataGridView.Rows[i].Cells[COMPANYCLN].Value != null)
                {
                    string companyName = PlayInfoDataGridView.Rows[i].Cells[COMPANYCLN].Value.ToString();
                    try
                    {
                        pInfo.companyID = service.SetCompanyIDByCompanyName(companyName);
                    }
                    catch(Exception ex)
                    {
                        MsgBox.Show(MSG_COMMON_001, ex.ToString());
                    }
                }

                if (PlayInfoDataGridView.Rows[i].Cells[STATUSCLN].Value != null)
                {
                    pInfo.status=service.GetStatusIntFromStatusText(PlayInfoDataGridView.Rows[i].Cells[STATUSCLN].Value.ToString());
                }

                if (PlayInfoDataGridView.Rows[i].Cells[PLAYSTARTTIMECLN].Value != null)
                {
                    string startTimeString = PlayInfoDataGridView.Rows[i].Cells[PLAYSTARTTIMECLN].Value.ToString();
                    pInfo.startTime = service.ConvertToDateTimeFromYYYYMM(startTimeString);
                }

                if (PlayInfoDataGridView.Rows[i].Cells[WATCHEDTIMECLN].Value != null)
                {
                    string watchedTimeString = PlayInfoDataGridView.Rows[i].Cells[WATCHEDTIMECLN].Value.ToString();
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
        private List<Character> CharacterInfoSeries(string animeNo)
        {
            List<Character> cInfoList = new List<Character>();

            if (CharacterInfoDataGridView.RowCount == 0)
            {
                return cInfoList;
            }

            //信息作成
            bool setLeadingNoFromDbFlg = false;
            bool setNonLeadingNoFromDbFlg = false;

            string lastLeadingCharaNo = null;
            string lastNonLeadingCharaNo = null;

            for (int i = 0; i < CharacterInfoDataGridView.RowCount; i++)
            {
                //空行则不处理
                if (CharacterInfoDataGridView.Rows[i].IsNewRow ||
                    CharacterInfoDataGridView.Rows[i].Cells[CHARACTERNAMECLN].Value == null)
                {
                    continue;
                }

                Character chara = new Character();
                chara.animeNo = animeNo;

                if (CharacterInfoDataGridView.Rows[i].Cells[CHARACTERNAMECLN].Value != null)
                {
                    chara.name = CharacterInfoDataGridView.Rows[i].Cells[CHARACTERNAMECLN].Value.ToString();
                }

                if (CharacterInfoDataGridView.Rows[i].Cells[SEIYUUNAMECLN].Value != null)
                {
                    string CVName = CharacterInfoDataGridView.Rows[i].Cells[SEIYUUNAMECLN].Value.ToString();
                    try
                    {
                        chara.CVID = service.SetCVIDByCVName(CVName);
                    }
                    catch(Exception ex)
                    {
                        MsgBox.Show(MSG_COMMON_001, ex.ToString());
                    }
                }

                chara.leadingFLG = Convert.ToBoolean(CharacterInfoDataGridView.Rows[i].Cells[ISMAINCHARACTERCLN].Value);

                //设定编号
                if (CharacterInfoDataGridView.Rows[i].Cells[CHARACTERNOCLN].Value != null && cmd == command.Update)
                {
                    chara.No = CharacterInfoDataGridView.Rows[i].Cells[CHARACTERNOCLN].Value.ToString();
                }
                else try
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
                            lastLeadingCharaNo = chara.No;
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
                            lastNonLeadingCharaNo = chara.No;
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
                        MsgBox.Show(MSG_ADDANIME_001);
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
            if (this.PlayInfoDataGridView.Rows.Count == 0 || CharacterInfoDataGridView.Rows.Count == 0)
            {
                if (MsgBox.Show(MSG_ADDANIME_008) == DialogResult.Yes)
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
        /// 放送信息完整性与规则检查
        /// </summary>
        /// <returns>false:不完整 true:完整</returns>
        private bool PlayInfoNullAndFormatCheck()
        {
            int rowscount = PlayInfoDataGridView.Rows.Count;

            //新规行检查
            for (int i = 0; i < rowscount; i++)
            {
                //空行则跳过
                if (PlayInfoDataGridView.Rows[i].IsNewRow)
                {
                    continue;
                }   

                //放送内容Check
                if (string.IsNullOrEmpty(PlayInfoDataGridView.Rows[i].Cells["playinfo"].ToString()))
                {
                    MsgBox.Show(MSG_ADDANIME_002, (i + 1).ToString());
                    return false;
                }

                //状态check
                if (string.IsNullOrEmpty(PlayInfoDataGridView.Rows[i].Cells["status"].ToString()))
                {
                    MsgBox.Show(MSG_ADDANIME_003, (i + 1).ToString());
                    return false;
                }

                //规则检查：话数必须为数字
                if (PlayInfoDataGridView.Rows[i].Cells["playcounts"].Value != null)
                {
                    string seriesnum = PlayInfoDataGridView.Rows[i].Cells["playcounts"].Value.ToString();
                    if (!string.IsNullOrEmpty(seriesnum))
                    {
                        Regex reg = new Regex(@"^[0-9]+$");
                        Match mth = reg.Match(seriesnum);

                        if (!mth.Success)
                        {
                            MsgBox.Show(MSG_ADDANIME_004, (i + 1).ToString());
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                //规则检查：播放时间与收看时间不能超过本月
                if (PlayInfoDataGridView.Rows[i].Cells[4].Value != null)
                {
                    if (!service.YYYYMMFormatCheck(PlayInfoDataGridView.Rows[i].Cells["playstarttime"].Value.ToString()))
                    {
                        PlayInfoDataGridView.CurrentCell = PlayInfoDataGridView.Rows[i].Cells["playstarttime"];
                        return false;
                    }
                }
                if (PlayInfoDataGridView.Rows[i].Cells["watchtime"].Value != null)
                {
                    if (!service.YYYYMMFormatCheck(PlayInfoDataGridView.Rows[i].Cells["watchtime"].Value.ToString()))
                    {
                        PlayInfoDataGridView.CurrentCell = PlayInfoDataGridView.Rows[i].Cells["watchtime"];
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

            //新规行检查
            for (int i = 0; i < rowscount; i++)
            {
                //空行跳过
                if (CharacterInfoDataGridView.Rows[i].IsNewRow)
                {
                    continue;
                }

                //放送内容Check
                if (string.IsNullOrEmpty(CharacterInfoDataGridView.Rows[i].Cells[CHARACTERNAMECLN].ToString()))
                {
                    MsgBox.Show(MSG_ADDANIME_005, (i + 1).ToString());
                    return false;
                }

                //放送内容Check
                if (string.IsNullOrEmpty(CharacterInfoDataGridView.Rows[i].Cells[SEIYUUNAMECLN].ToString()))
                {
                    MsgBox.Show(MSG_ADDANIME_006, (i + 1).ToString());
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 动画格式与规则检查
        /// </summary>
        /// <returns></returns>
        public bool AnimeInfoFormatAndRuleCheck(command ctr, Animation anime)
        {
            //动画编号格式
            if (!service.AnimeNoCheck(anime.No))
            {
                MsgBox.Show(MSG_COMMON_004, anime.No);
                return false;
            }

            if (!service.AnimeNNCheck(anime.Nickname))
            {
                MsgBox.Show(MSG_COMMON_005, anime.Nickname);
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
        private bool AnimationRepeatCheck(Animation anime, command ctr)
        {
            //重复性检查
            Animation repeatAnime = service.SearchRepeatAnimeInfo(anime, ctr);

            if (repeatAnime == null)
            {
                return true;
            }
            else
            {
                MsgBox.Show(MSG_ADDANIME_007, repeatAnime.No, repeatAnime.CNName, repeatAnime.JPName, repeatAnime.Nickname);
                return false;
            }
        }

        #endregion

        #region 窗体

        /// <summary>
        /// 播放信息选项卡格式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayInfoDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewCell CurrnetCell = this.PlayInfoDataGridView.CurrentCell;

            string selectedcompany = string.Empty;

            //制作公司选择框
            if (CurrnetCell != null && CurrnetCell.OwningColumn.Name == "company")
            {
                Rectangle TmpRect = this.PlayInfoDataGridView.GetCellDisplayRectangle(CurrnetCell.ColumnIndex, CurrnetCell.RowIndex, true);
                if (PlayInfoDataGridView.Rows[PlayInfoDataGridView.CurrentRow.Index].Cells[2].Value != null)
                {
                    selectedcompany = PlayInfoDataGridView.Rows[PlayInfoDataGridView.CurrentRow.Index].Cells[2].Value.ToString();
                }

                companybox.Size = TmpRect.Size;
                companybox.Top = TmpRect.Top+2;
                companybox.Left = TmpRect.Left+2;
                companybox.Visible = true;
                

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
                    MsgBox.Show(MSG_COMMON_001, ex.ToString());
                }

                companybox.DisplayMember = "COMPANY_NAME";
                companybox.ValueMember = "COMPANY_NAME";
                companybox.DataSource = dt.DefaultView;
                companybox.SelectedText = selectedcompany;
                companybox.Focus();
            }
            else
            {
                this.companybox.Visible = false;
            }
        }

        /// <summary>
        /// 角色选项卡格式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterInfoDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewCell CurrnetCell = this.CharacterInfoDataGridView.CurrentCell;

            string selectextest = string.Empty;

            //声优名称选择框
            if (CurrnetCell != null && CurrnetCell.OwningColumn.Name == "seiyuuname")
            {
                Rectangle TmpRect = this.CharacterInfoDataGridView.GetCellDisplayRectangle(CurrnetCell.ColumnIndex, CurrnetCell.RowIndex, true);
                
                if (CharacterInfoDataGridView.Rows[CharacterInfoDataGridView.CurrentRow.Index].Cells[SEIYUUNAMECLN].Value != null)
                {
                    selectextest = CharacterInfoDataGridView.Rows[CharacterInfoDataGridView.CurrentRow.Index].Cells[SEIYUUNAMECLN].Value.ToString();
                }
                this.CVbox.Size = TmpRect.Size;
                this.CVbox.Top = TmpRect.Top;
                this.CVbox.Left = TmpRect.Left;
                this.CVbox.Visible = true;
                this.CVbox.Focus();
            }
            else if (CurrnetCell != null && CurrnetCell.OwningColumn.Name == "ismaincharacter")
            {
                CharacterInfoDataGridView.Focus();
                this.CVbox.Visible = false;
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
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }

            CVbox.DisplayMember = "CV_NAME";
            CVbox.ValueMember = "CV_NAME";
            CVbox.DataSource = dt.DefaultView;
            CVbox.SelectedText = selectextest;
        }

        /// <summary>
        /// 离开声优选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seiyuubox_Leave(object sender, EventArgs e)
        {
            this.CharacterInfoDataGridView.Rows[CharacterInfoDataGridView.CurrentCell.RowIndex].Cells[1].Value = this.CVbox.Text.ToString();
        }
       
        /// <summary>
        /// 离开制作公司选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void companybox_Leave(object sender, EventArgs e)
        {
            this.PlayInfoDataGridView.Rows[PlayInfoDataGridView.CurrentCell.RowIndex].Cells[2].Value = this.companybox.Text.ToString();
        }

        /// <summary>
        /// 修改窗体内容设置
        /// </summary>
        /// <param name="anime"></param>
        private void SetAnimeWindowWithAnime(Animation anime)
        {
            this.Text = "修改动画信息";
            this.numbox.ReadOnly = true;
            this.AcceptButton = button1;

            //基本信息
            numbox.Text = anime.No;
            cnnamebox.Text = anime.CNName;
            jpnamebox.Text=anime.JPName;
            nnbox.Text = anime.Nickname;
            statescbox.Text = service.GetStatusTextFromStatusInt(anime.status);
            originalbox.Text = service.GetOriginalTextFromOriginalInt(anime.original);

            //播放信息
            try
            {
                if (anime.playInfoList != null)
                {
                    for (int i = 0; i < anime.playInfoList.Count; i++)
                    {
                        PlayInfo pInfo = anime.playInfoList[i];
                        PlayInfoDataGridView.Rows.Add();

                        DataGridViewRow dgvrow = PlayInfoDataGridView.Rows[i];

                        dgvrow.Cells[PLAYINFOCLN].Value = pInfo.info;

                        if (pInfo.parts != 0)
                        {
                            dgvrow.Cells[PLAYCOUNTSCLN].Value = pInfo.parts.ToString();
                        }

                        if (pInfo.companyID != 0)
                        {
                            dgvrow.Cells[COMPANYCLN].Value = service.GetCompanyNameByCompanyNo(pInfo.companyID);
                        }

                        dgvrow.Cells[STATUSCLN].Value = service.GetStatusTextFromStatusInt(pInfo.status);

                        if (pInfo.startTime != DateTime.MinValue && pInfo.startTime != DateTime.MaxValue)
                        {
                            dgvrow.Cells[PLAYSTARTTIMECLN].Value = service.ConvertToYYYYMMFromDatetime(pInfo.startTime);
                        }

                        if (pInfo.watchedTime != DateTime.MinValue && pInfo.watchedTime != DateTime.MaxValue)
                        {
                            dgvrow.Cells[WATCHEDTIMECLN].Value = service.ConvertToYYYYMMFromDatetime(pInfo.watchedTime);
                        }

                        dgvrow.Cells[PLAYINFOIDCLN].Value = pInfo.ID.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }

            //角色信息
            try
            {
                if (anime.characterList != null)
                {
                    for (int i = 0; i < anime.characterList.Count; i++)
                    {
                        Character cInfo = anime.characterList[i];
                        CharacterInfoDataGridView.Rows.Add();

                        DataGridViewRow dgvrow = CharacterInfoDataGridView.Rows[i];

                        dgvrow.Cells[CHARACTERNAMECLN].Value = cInfo.name.ToString();

                        if (cInfo.CVID != 0)
                        {
                            dgvrow.Cells[SEIYUUNAMECLN].Value = service.GetCVNameByCVID(cInfo.CVID);
                        }

                        dgvrow.Cells[ISMAINCHARACTERCLN].Value = Convert.ToBoolean(cInfo.leadingFLG);

                        dgvrow.Cells[CHARACTERNOCLN].Value = cInfo.No.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.ToString());
            }
            
        }
  
        #endregion



    }
}
