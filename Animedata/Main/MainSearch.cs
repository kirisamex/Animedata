using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Main.Lib.Model;

namespace Main
{
    public partial class MainSearch : Form
    {
        public MainSearch(Main mainfm)
        {
            InitializeComponent();
            mainform = mainfm;
        }

        #region 常量
        /// <summary>
        /// Service
        /// </summary>
        MainService service = new MainService();

        /// <summary>
        /// 主窗口传递
        /// </summary>
        private Main mainform;
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
                mainSearch.animeStatue.newproject= true;
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
                mainSearch.animeOriginal.fromgame= true;
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

        #endregion

        #region 按钮
        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            //格式检查
            if (!service.StringFormatCheck(this) || !service.DateTimeFormatCheck(this) || !service.CheckedListBoxCheck(this))
            {
                return;
            }

            SearchModule search = new SearchModule();

            SetSearchModule(search);

            try
            {
                DataSet ds = service.Getanime(search);
                mainform.LoadAnimeMain(ds);
            }
            catch (Exception ex)
            {
                service.ShowErrorMessage(ex.Message);
                Application.Exit();
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
        /// 中文名检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimeCNNameSearchTypeButton_Click(object sender, EventArgs e)
        {
            string searchtext = AnimeCNNameSearchTypeButton.Text.ToString();

            switch (searchtext)
            {
                case "部分一致":
                    AnimeCNNameSearchTypeButton.Text = "完全一致";
                    break;
                case "完全一致":
                    AnimeCNNameSearchTypeButton.Text = "前方一致";
                    break;
                case "前方一致":
                    AnimeCNNameSearchTypeButton.Text = "部分一致";
                    break;
            }
        }

        /// <summary>
        /// 日文名检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimeJPNameSearcyTypeButton_Click(object sender, EventArgs e)
        {
            string searchtext = AnimeJPNameSearcyTypeButton.Text.ToString();

            switch (searchtext)
            {
                case "部分一致":
                    AnimeJPNameSearcyTypeButton.Text = "完全一致";
                    break;
                case "完全一致":
                    AnimeJPNameSearcyTypeButton.Text = "前方一致";
                    break;
                case "前方一致":
                    AnimeJPNameSearcyTypeButton.Text = "部分一致";
                    break;
            }
        }

        /// <summary>
        /// 播放时间检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaytimeSearchTypeButton_Click(object sender, EventArgs e)
        {
            string searchtext = PlaytimeSearchTypeButton.Text.ToString();

            switch (searchtext)
            {
                case "在此期间":
                    PlaytimeSearchTypeButton.Text = "包括此期间";
                    break;
                case "包括此期间":
                    PlaytimeSearchTypeButton.Text = "在此期间";
                    break;

            }
        }

        /// <summary>
        /// 收看时间检索方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatchtimeSearchTypeButton_Click(object sender, EventArgs e)
        {
            string searchtext = WatchtimeSearchTypeButton.Text.ToString();
            
            switch (searchtext)
            {
                case "在此期间":
                    WatchtimeSearchTypeButton.Text = "包括此期间";
                    break;
                case "包括此期间":
                    WatchtimeSearchTypeButton.Text = "在此期间";
                    break;

            }
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
