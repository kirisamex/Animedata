using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client.MainForm.Service;
using Lib.Lib.Model;
using Lib.Lib.Message;

namespace Client.MainForm.Gui
{
    public partial class MainSearch : Form
    {
        public MainSearch()
        {
            InitializeComponent();
        }

        #region 常量
        //实例
        MainService service = new MainService();

        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>动画编号 {0} 格式不正确！\n目前允许的编号格式为：大写字母+3位数字。</summary>
        const string MSG_COMMON_004 = "MSG-COMMON-004";
        /// <summary>动画简写 {0} 格式不正确！\n简写需要是英文半角字母，且首字母大写。</summary>
        const string MSG_COMMON_005 = "MSG-COMMON-005";
        /// <summary>[ {0} ]的年月格式不正确！时间格式：yyyyMM。</summary>
        const string MSG_COMMON_006 = "MSG-COMMON-006";
        /// <summary>未搜索到对应结果。</summary>
        const string MSG_COMMON_007 = "MSG-COMMON-007";

        /// <summary>至少选择一个播放状态进行搜索！</summary>
        const string MSG_MAINSEARCH_001 = "MSG-MAINSEARCH-001";
        /// <summary>至少选择一个原作种类进行搜索！</summary>
        const string MSG_MAINSEARCH_002 = "MSG-MAINSEARCH-002";
        #endregion

        #region 方法
        /// <summary>
        /// 数据作成
        /// </summary>
        /// <param name="mainSearch"></param>
        private void SetSearchModule(SearchModule mainSearch)
        {
            //动画编号
            if (!string.IsNullOrEmpty(AnimeNoBox.Text.ToString()))
            {
                mainSearch.animeNo = AnimeNoBox.Text.ToString();
            }

            //中文名及搜索方式
            if (!string.IsNullOrEmpty(AnimeCNNamebox.Text.ToString()))
            {
                mainSearch.animeCNName = AnimeCNNamebox.Text.ToString();
                mainSearch.animeCNNameSearchWay = mainSearch.GetStringSearchWay(AnimeCNNameSearchTypeButton.Text.ToString());
            }

            //日文名及搜索方式
            if (!string.IsNullOrEmpty(AnimeJPNameBox.Text.ToString()))
            {
                mainSearch.animeJPName = AnimeJPNameBox.Text.ToString();
                mainSearch.animeJPNameSearchWay = mainSearch.GetStringSearchWay(AnimeJPNameSearcyTypeButton.Text.ToString());
            }

            //简写
            if (!string.IsNullOrEmpty(AnimeNNBox.Text.ToString()))
            {
                mainSearch.animeNN = AnimeNNBox.Text.ToString();
            }

            //放送时间
            if (!string.IsNullOrEmpty(PlaytimeFromBox.Text.ToString()) || !string.IsNullOrEmpty(PlaytimeToBox.Text.ToString()))
            {
                mainSearch.animePlaytimeSearchWay = mainSearch.GetDateTimeSearchWay(PlaytimeSearchTypeButton.Text.ToString());

                //FROMTO
                if (!string.IsNullOrEmpty(PlaytimeFromBox.Text.ToString()) && !string.IsNullOrEmpty(PlaytimeToBox.Text.ToString()))
                {
                    mainSearch.animePlaytimeFrom = service.ConvertToDateTimeFromYYYYMM(PlaytimeFromBox.Text.ToString());
                    mainSearch.animePlaytimeTo = service.ConvertToDateTimeFromYYYYMM(PlaytimeToBox.Text.ToString());
                    mainSearch.animePlaytimeSearchRule = SearchModule.DateTimeSearchRule.FromTo;
                }
                else
                {
                    //FROM
                    if (!string.IsNullOrEmpty(PlaytimeFromBox.Text.ToString()))
                    {
                        mainSearch.animePlaytimeFrom = service.ConvertToDateTimeFromYYYYMM(PlaytimeFromBox.Text.ToString());
                        mainSearch.animePlaytimeSearchRule = SearchModule.DateTimeSearchRule.From;
                    }
                    //TO
                    else
                    {
                        mainSearch.animePlaytimeTo = service.ConvertToDateTimeFromYYYYMM(PlaytimeToBox.Text.ToString());
                        mainSearch.animePlaytimeSearchRule = SearchModule.DateTimeSearchRule.To;
                    }

                }
            }

            //声优
            if (!string.IsNullOrEmpty(seiyuuBox.Text.ToString()))
            {
                mainSearch.CVName = seiyuuBox.Text.ToString();
                mainSearch.CVNameSearchWay = mainSearch.GetStringSearchWay(CVNameSearchTypeButton.Text.ToString());
            }

            //制作公司
            if (!string.IsNullOrEmpty(companyBox.Text.ToString()))
            {
                mainSearch.Company=companyBox.Text.ToString();
                mainSearch.CompanyNameSearchWay = mainSearch.GetStringSearchWay(CompanySearchTypeButton.Text.ToString());
            }

            //状态
            #region //状态
            if (StatusCheckedListBox.GetItemChecked(0))
            {
                mainSearch.animeStatue.playing = true;
            }
            else
            {
                mainSearch.animeStatue.playing = false;
            }

            if (StatusCheckedListBox.GetItemChecked(1))
            {
                mainSearch.animeStatue.finished = true;
            }
            else
            {
                mainSearch.animeStatue.finished = false;
            }

            if (StatusCheckedListBox.GetItemChecked(2))
            {
                mainSearch.animeStatue.newproject = true;
            }
            else
            {
                mainSearch.animeStatue.newproject = false;
            }


            if (StatusCheckedListBox.GetItemChecked(3))
            {
                mainSearch.animeStatue.discare = true;
            }
            else
            {
                mainSearch.animeStatue.discare = false;
            }
            #endregion


            //原作
            #region //原作
            if (OriginalCheckedListBox.GetItemChecked(0))
            {
                mainSearch.animeOriginal.fromComic = true;
            }
            else
            {
                mainSearch.animeOriginal.fromComic = false;
            }

            if (OriginalCheckedListBox.GetItemChecked(1))
            {
                mainSearch.animeOriginal.fromNovel = true;
            }
            else
            {
                mainSearch.animeOriginal.fromNovel = false;
            }

            if (OriginalCheckedListBox.GetItemChecked(2))
            {
                mainSearch.animeOriginal.isoriginal = true;
            }
            else
            {
                mainSearch.animeOriginal.isoriginal = false;
            }

            if (OriginalCheckedListBox.GetItemChecked(3))
            {
                mainSearch.animeOriginal.fromgame = true;
            }
            else
            {
                mainSearch.animeOriginal.fromgame = false;
            }

            if (OriginalCheckedListBox.GetItemChecked(4))
            {
                mainSearch.animeOriginal.fromvideo = true;
            }
            else
            {
                mainSearch.animeOriginal.fromvideo = false;
            }

            if (OriginalCheckedListBox.GetItemChecked(5))
            {
                mainSearch.animeOriginal.fromothers = true;
            }
            else
            {
                mainSearch.animeOriginal.fromothers = false;
            }
            #endregion
        }

        /// <summary>
        /// 日期格式检查
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool DateTimeFormatCheck()
        {
            if ((!string.IsNullOrEmpty(PlaytimeFromBox.Text.ToString()) && !service.YYYYMMFormatCheck(PlaytimeFromBox.Text.ToString())) ||
                (!string.IsNullOrEmpty(PlaytimeToBox.Text.ToString()) && !service.YYYYMMFormatCheck(PlaytimeToBox.Text.ToString()))||
                (!string.IsNullOrEmpty(WatchtimeFromBox.Text.ToString())&&!service.YYYYMMFormatCheck(WatchtimeFromBox.Text.ToString()))||
                (!string.IsNullOrEmpty(WatchtimeToBox.Text.ToString())&&!service.YYYYMMFormatCheck(WatchtimeToBox.Text.ToString()))
                )
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 复选列表检查
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool CheckedListBoxCheck()
        {
            if (StatusCheckedListBox.CheckedItems.Count == 0)
            {
                MsgBox.Show(MSG_MAINSEARCH_001);
                return false;
            }

            if (OriginalCheckedListBox.CheckedItems.Count == 0)
            {
                MsgBox.Show(MSG_MAINSEARCH_002);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 字符格式检查
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public int StringFormatCheck()
        {
            if (!string.IsNullOrEmpty(AnimeNoBox.Text.ToString()))
            {
                if (!service.AnimeNoCheck(AnimeNoBox.Text.ToString()))
                {
                    return -1;
                }
            }

            if (!string.IsNullOrEmpty(AnimeNNBox.Text.ToString()))
            {
                if (!service.AnimeNNCheck(AnimeNNBox.Text.ToString()))
                {
                    return -2;
                }
            }

            return 0;
        }

        /// <summary>
        /// 更改搜索方式按键显示内容
        /// </summary>
        /// <param name="test">更改前内容</param>
        /// <returns></returns>
        private string ButtonTextChange(string test)
        {
            switch (test)
            {
                case "部分一致":
                    return "完全一致";
                case "完全一致":
                    return "前方一致";
                case "前方一致":
                    return "部分一致";
                case "在此期间":
                    return "包括此期间";
                case "包括此期间":
                    return "在此期间";
                default:
                    return null;
            }
        }

        #endregion

        #region 按钮
        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            //字符格式检查
            int StrCheckRes = StringFormatCheck();
            
            if (StrCheckRes == -1)//编号格式不正
            {
                MsgBox.Show(MSG_COMMON_004, AnimeNoBox.Text.ToString());
                return;
            }
            else if (StrCheckRes == -2)//简写格式不正
            {
                MsgBox.Show(MSG_COMMON_005, AnimeNNBox.Text.ToString());
                return;
            }

            //格式检查
            if ( !DateTimeFormatCheck() || !CheckedListBoxCheck())
            {
                return;
            }

            SearchModule search = new SearchModule();

            SetSearchModule(search);

            try
            {
                DataSet ds = service.Getanime(search);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MsgBox.Show(MSG_COMMON_007);
                    return;
                }

                Main.Mainfm.ShowAnime(ds);
                Main.Mainfm.Focus();
            }
            catch (Exception ex)
            {
                MsgBox.Show(MSG_COMMON_001, ex.Message);
            }
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.AnimeNoBox.Text = string.Empty;
            this.AnimeCNNamebox.Text = string.Empty;
            this.AnimeJPNameBox.Text = string.Empty;
            this.AnimeNNBox.Text = string.Empty;
            this.PlaytimeFromBox.Text = string.Empty;
            this.PlaytimeToBox.Text = string.Empty;
            this.WatchtimeFromBox.Text = string.Empty;
            this.WatchtimeToBox.Text = string.Empty;
            this.seiyuuBox.Text = string.Empty;
            this.companyBox.Text = string.Empty;

            this.AnimeCNNameSearchTypeButton.Text = "部分一致";
            this.AnimeJPNameSearcyTypeButton.Text = "部分一致";
            this.CVNameSearchTypeButton.Text = "部分一致"; 
            this.CompanySearchTypeButton.Text = "部分一致";

            PlaytimeSearchTypeButton.Text = "在此期间";
            WatchtimeSearchTypeButton.Text = "在此期间";


            for (int j = 0; j < StatusCheckedListBox.Items.Count; j++)
            {
                StatusCheckedListBox.SetItemChecked(j, true);
            }
            for (int j = 0; j < OriginalCheckedListBox.Items.Count; j++)
            {
                OriginalCheckedListBox.SetItemChecked(j, true);
            }
        }

        /// <summary>
        /// 中文名检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimeCNNameSearchTypeButton_Click(object sender, EventArgs e)
        {
            AnimeCNNameSearchTypeButton.Text = ButtonTextChange(AnimeCNNameSearchTypeButton.Text.ToString());
        }

        /// <summary>
        /// 日文名检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimeJPNameSearcyTypeButton_Click(object sender, EventArgs e)
        {
            AnimeJPNameSearcyTypeButton.Text = ButtonTextChange(AnimeJPNameSearcyTypeButton.Text.ToString());
        }

        /// <summary>
        /// 声优名检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CVNameSearchTypeButton_Click(object sender, EventArgs e)
        {
            CVNameSearchTypeButton.Text = ButtonTextChange(CVNameSearchTypeButton.Text.ToString());
        }

        /// <summary>
        /// 公司名检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanySearchTypeButton_Click(object sender, EventArgs e)
        {
            CompanySearchTypeButton.Text = ButtonTextChange(CompanySearchTypeButton.Text.ToString());
        }

        /// <summary>
        /// 播放时间检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaytimeSearchTypeButton_Click(object sender, EventArgs e)
        {
            PlaytimeSearchTypeButton.Text = ButtonTextChange(PlaytimeSearchTypeButton.Text.ToString());
        }

        /// <summary>
        /// 收看时间检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatchtimeSearchTypeButton_Click(object sender, EventArgs e)
        {
            WatchtimeSearchTypeButton.Text = ButtonTextChange(WatchtimeSearchTypeButton.Text.ToString());
        }

        /// <summary>
        /// 状态全部选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusAllCheckedButton_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < StatusCheckedListBox.Items.Count; j++)
            {
                StatusCheckedListBox.SetItemChecked(j, true);
            }
        }

        /// <summary>
        /// 状态全部除外
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusAllNotCheckedButton_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < StatusCheckedListBox.Items.Count; j++)
            {
                StatusCheckedListBox.SetItemChecked(j, false);
            }
        }

        /// <summary>
        /// 原作全部选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OriginalAllCheckButton_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < OriginalCheckedListBox.Items.Count; j++)
            {
                OriginalCheckedListBox.SetItemChecked(j, true);
            }
        }

        /// <summary>
        /// 原作全部除外
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OriginalAllNotCheckedButton_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < OriginalCheckedListBox.Items.Count; j++)
            {
                OriginalCheckedListBox.SetItemChecked(j, false);
            }
        }

        #endregion

        #region 键盘
        /// <summary>
        /// 键盘功能键控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        
        #endregion

        #region 界面
        /// <summary>
        /// 载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainSearch_Load(object sender, EventArgs e)
        {
            //选择框全选
            for (int i = 0; i < StatusCheckedListBox.Items.Count; i++)
                StatusCheckedListBox.SetItemChecked(i, true);

            for (int j = 0; j < OriginalCheckedListBox.Items.Count; j++)
                OriginalCheckedListBox.SetItemChecked(j, true);
        }

        #endregion

    }
}
