using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Main.Lib.Model;

namespace Main
{
    public class MainService
    {
        #region 常量
        public string selectedRowID;
        
        Maindao dao = new Maindao();

        public const string DELETEANIMEINFO = "删除动画信息";

        public const string ERRORINFO = "错误";

        public const string WARNING = "警告";

        public const string Info = "提示";

        #endregion

        #region 共通

        /// <summary>
        /// 根据状态值返回文字描述
        /// </summary>
        /// <param name="status">状态：[1]放送中 [2]完结 [3]新企划 [9]弃置</param>
        /// <returns></returns>
        public string GetStatusTextFromStatusInt(int status)
        {
            switch (status)
            {
                case 1:
                    return "放送中";
                case 2:
                    return "完结";
                case 3:
                    return "新企划";
                case 9:
                    return "弃置";
                default:
                    return null;
            }
        }

        /// <summary>
        /// 根据状态文字描述返回状态值
        /// </summary>
        /// <param name="status">状态：[1]放送中 [2]完结 [3]新企划 [9]弃置</param>
        /// <returns></returns>
        public int GetStatusIntFromStatusText(string status)
        {
            switch (status)
            {
                case "放送中": return 1;
                case "完结": return 2;
                case "新企划": return 3;
                case "弃置": return 9;
                default: return -1;
            }
        }

        /// <summary>
        /// 根据原作值返回文字描述
        /// </summary>
        /// <param name="original">原作：[1]漫画 [2]小说 [3]原创 [4]影视 [5]游戏 [9]其他</param>
        /// <returns></returns>
        public string GetOriginalTextFromOriginalInt(int original)
        {
            switch (original)
            {
                case 1: return "漫画";
                case 2: return "小说";
                case 3: return "原创";
                case 4: return "影视";
                case 5: return "游戏";
                case 9: return "其他";
                default: return null;
            }
        }

        /// <summary>
        /// 根据原作文字描述返回原作值
        /// </summary>
        /// <param name="original">原作：[1]漫画 [2]小说 [3]原创 [4]影视 [5]游戏 [9]其他</param>
        /// <returns></returns>
        public int GetOriginalIntFromOriginalText(string original)
        {
            switch (original)
            {
                case "漫画": return 1;
                case "小说": return 2;
                case "原创": return 3;
                case "影视": return 4;
                case "游戏": return 5;
                case "其他": return 9;
                default: return -1;
            }
        }

        /// <summary>
        /// 根据日期转换为YYYY年MM月格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ConvertToYYYYNianMMYueFromDatetime(DateTime dt)
        {
            string YYYYMM = dt.ToString("yyyy年MM月");
            return YYYYMM;
        }

        /// <summary>
        /// 根据日期转换为YYYYMM格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ConvertToYYYYMMFromDatetime(DateTime dt)
        {
            string YYYYMM = dt.ToString("yyyyMM");
            return YYYYMM;
        }

        /// <summary>
        /// 根据日期转换为YYYYMMDD格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ConvertToYYYYMMDDFromDatetime(DateTime dt)
        {
            string YYYYMMDD = dt.ToString("yyyyMMdd");
            return YYYYMMDD;
        }

        /// <summary>
        /// 根据动画编号获得动画信息
        /// </summary>
        /// <param name="animeID"></param>
        /// <returns></returns>       
        public Animation GetAnimeFromAnimeNo(string animeNo)
        {
            return dao.GetAnimeFromAnimeNo(animeNo);
        }

        /// <summary>
        /// 根据公司名返回公司ID、新规公司信息
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public int SetCompanyIDByCompanyName(string companyName)
        {
            int companyID = dao.GetCompanyIdByCompanyName(companyName);

            if (companyID >= 0)
            {
                return companyID;
            }

            //新规company作成
            Company comp = new Company();
            comp.ID = dao.GetMaxInt("COMPANY") + 1;
            comp.Name = companyName;

            //company表插入
            try
            {
                dao.InsertCompanyInfo(comp);
                return comp.ID;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
                return -99;
            }
        }

        /// <summary>
        /// 根据公司名返回公司ID
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public int GetCompanyIdByCompanyName(string companyName)
        {
            return dao.GetCompanyIdByCompanyName(companyName);
        }

        /// <summary>
        /// 根据声优名返回声优ID
        /// </summary>
        /// <param name="CVName"></param>
        /// <returns></returns>
        public int GetCVIDByCVName(string CVName)
        {
            return dao.GetCVIDByCVName(CVName);
        }

        /// <summary>
        /// 根据声优ID返回声优名
        /// </summary>
        /// <param name="CVID"></param>
        /// <returns></returns>
        public string GetCVNameByCVID(int CVID)
        {
            return dao.GetCVNameByCVID(CVID);
        }

        /// <summary>
        /// 根据公司ID返回公司名
        /// </summary>
        /// <param name="companyNo"></param>
        /// <returns></returns>
        public string GetCompanyNameByCompanyNo(int companyNo)
        {
            return dao.GetCompanyNameByCompanyId(companyNo);
        }

                /// <summary>
        /// 根据YYYYMM转换为日期
        /// </summary>
        /// <param name="YYYYMM"></param>
        /// <returns></returns>
        public DateTime ConvertToDateTimeFromYYYYMM(string YYYYMM)
        {
            DateTime dt;
            DateTime.TryParseExact(YYYYMM, "yyyyMM", null, DateTimeStyles.None, out dt);            
            return dt;
        }

        /// <summary>
        /// YYYYMM格式检查
        /// </summary>
        /// <param name="YYYYMM"></param>
        /// <returns></returns>
        public bool YYYYMMFormatCheck(string YYYYMM)
        {
            //六位数字，年月
            Regex yyyymm = new Regex(@"^(19[5-9][0-9]|20[0-9]{2})((0[1-9])|(1[0-2]))$");
            Match ymmatch = yyyymm.Match(YYYYMM);
            if (!ymmatch.Success)
            {
                ShowErrorMessage("\n[ " + YYYYMM + " ]的年月格式不正确！时间格式：yyyyMM。", ERRORINFO);
                return false;
            }

            //▼#3_考虑到登记新企划以及搜索的需要，不使用该检查
            //是否超过今天
            //if (ConvertToDateTimeFromYYYYMM(YYYYMM) > DateTime.Today)
            //{
            //    ShowErrorMessage("\n[ " + YYYYMM + " ]日期超过了当前时间，请检查是否填写错误或系统时间不正确！",ERRORINFO);
            //    return false;
            //}
            //▲#3

            return true;
        }

        #endregion

        #region 信息
        /// <summary>
        /// 显示错误信息对话框
        /// </summary>
        /// <param name="ErrorMessage">错误内容</param>
        public void ShowErrorMessage(string ErrorMessage)
        {
            MessageBox.Show( ErrorMessage, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示错误信息对话框
        /// </summary>
        /// <param name="ErrorMessage">错误内容</param>
        /// <param name="ErrorTitle">错误框标题</param>
        public void ShowErrorMessage(string ErrorMessage, string ErrorTitle)
        {
            MessageBox.Show( ErrorMessage, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// 显示错误信息对话框
        /// </summary>
        public void ShowErrorMessage()
        {
            MessageBox.Show( "未预料的错误。",
                        ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// 显示警告信息对话框
        /// </summary>
        /// <param name="WarningMessage"></param>
        public void ShowWarningMessage(string WarningMessage)
        {
            MessageBox.Show(WarningMessage, WARNING, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示信息对话框
        /// </summary>
        /// <param name="InfoMessage"></param>
        public void ShowInfoMessage(string InfoMessage)
        {
            MessageBox.Show(InfoMessage, Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示信息对话框
        /// </summary>
        /// <param name="InfoMessage">对话框内容</param>
        /// <param name="Title">对话框标题</param>
        public void ShowInfoMessage(string InfoMessage,string Title)
        {
            MessageBox.Show(InfoMessage, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示确认对话框
        /// </summary>
        /// <param name="InfoMessage">对话框信息</param>
        /// <param name="Title">对话框标题</param>
        /// <returns></returns>
        public bool ShowYesNoMessage(string InfoMessage, string Title)
        {
            DialogResult res = MessageBox.Show(InfoMessage, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Main
        /// <summary>
        /// 载入动画
        /// </summary>
        /// <returns></returns>
        public DataSet Getanime()
        {
            return dao.Getanime();
        }

        /// <summary>
        /// 载入动画
        /// 指定公司制作
        /// </summary>
        /// <param name="comp">制作公司</param>
        /// <returns></returns>
        public DataSet Getanime(Company comp)
        {
            return dao.Getanime(comp);
        }

        /// <summary>
        /// 载入动画
        /// 指定声优
        /// </summary>
        /// <param name="cvList">声优列表</param>
        /// <returns></returns>
        public DataSet Getanime(List<CV> cvList)
        {
            return dao.Getanime(cvList);
        }

        /// <summary>
        /// 载入动画
        /// 搜索
        /// </summary>
        /// <param name="search">搜索窗体</param>
        /// <returns></returns>
        public DataSet Getanime(SearchModule search)
        {
            return dao.Getanime(search);
        }

        /// <summary>
        /// 载入动画
        /// 简易搜索
        /// </summary>
        /// <param name="searchText">搜索字符</param>
        /// <returns></returns>
        public DataSet Getanime(string searchText)
        {
            return dao.Getanime(searchText);
        }

        /// <summary>
        /// 载入角色信息
        /// </summary>
        /// <param name="animeNo"></param>
        /// <returns></returns>
        public DataSet LoadCharacterInfo(string animeNo)
        {
            return dao.LoadCharacterInfo(animeNo);
        }
        #endregion

        #region MainSearch
        /// <summary>
        /// 字符型格式检查
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool StringFormatCheck(MainSearch search)
        {
            if (!string.IsNullOrEmpty(search.AnimeNoBox.Text.ToString()))
            {
                //动画编号格式
                Regex r1 = new Regex(@"^[A-Z][0-9]{3}$");
                Match m1 = r1.Match(search.AnimeNoBox.Text.ToString());

                if (!m1.Success)
                {
                    ShowErrorMessage("格式错误,动画编号格式不正确！\n目前允许的编号格式为：大写字母+3位数字。");
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(search.AnimeNNBox.Text.ToString()))
            {
                Regex r2 = new Regex(@"^[A-Z]+[a-zA-Z]");
                Match m2 = r2.Match(search.AnimeNNBox.Text.ToString());
                if (!m2.Success)
                {
                    ShowErrorMessage("动画简写格式不正确！\n简写需要是英文半角字母，且首字母大写。");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 日期格式检查
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool DateTimeFormatCheck(MainSearch search)
        {
            if ((!string.IsNullOrEmpty(search.PlaytimeFromBox.Text.ToString()) && !YYYYMMFormatCheck(search.PlaytimeFromBox.Text.ToString())) ||
                (!string.IsNullOrEmpty(search.PlaytimeToBox.Text.ToString()) && !YYYYMMFormatCheck(search.PlaytimeToBox.Text.ToString()))||
                (!string.IsNullOrEmpty(search.WatchtimeFromBox.Text.ToString())&&!YYYYMMFormatCheck(search.WatchtimeFromBox.Text.ToString()))||
                (!string.IsNullOrEmpty(search.WatchtimeToBox.Text.ToString())&&!YYYYMMFormatCheck(search.WatchtimeToBox.Text.ToString()))
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
        public bool CheckedListBoxCheck(MainSearch search)
        {
            if (search.StatusCheckedListBox.CheckedItems.Count == 0)
            {
                ShowInfoMessage("至少选择一个播放状态进行搜索！");
                return false;
            }

            if (search.OriginalCheckedListBox.CheckedItems.Count == 0)
            {
                ShowInfoMessage("至少选择一个原作种类进行搜索！");
                return false;
            }
            return true;
        }
        #endregion

    }
}
