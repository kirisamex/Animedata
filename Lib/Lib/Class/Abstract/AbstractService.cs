using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Lib.Lib.Class.Animes;
using Lib.Lib.Model;
using Lib.Lib.Message;

namespace Lib.Lib.Class.Abstract
{
    public class AbstractService
    {
        #region 常量

        AbstractDao dao = new AbstractDao();

        public const string DELETEANIMEINFO = "删除动画信息";

        public const string ERRORINFO = "错误";

        public const string WARNING = "警告";

        public const string Info = "提示";

        /// <summary>系统错误，请联系开发者。\n{0}</summary>
        const string MSG_COMMON_001 = "MSG-COMMON-001";
        /// <summary>[ {0} ]的年月格式不正确！时间格式：yyyyMM。</summary>
        const string MSG_COMMON_006 = "MSG-COMMON-006";
        /// <summary>[ {0} ]的年份格式不正确！时间格式：yyyy。</summary>
        const string MSG_COMMON_009 = "MSG-COMMON-009";

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
            comp.ID = dao.GetMaxInt(2) + 1;
            comp.Name = companyName;

            //company表插入
            try
            {
                dao.InsertCompanyInfo(comp);
                return comp.ID;
            }
            catch (Exception ex)
            {
                throw ex;
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
        /// 根据YYYY转换为日期
        /// </summary>
        /// <param name="YYYYMM"></param>
        /// <returns></returns>
        public DateTime ConvertToDateTimeFromYYYY(string YYYY)
        {
            DateTime dt;
            DateTime.TryParseExact(YYYY, "yyyy", null, DateTimeStyles.None, out dt);
            return dt;
        }

        /// <summary>
        /// YYYYMM格式检查
        /// </summary>
        /// <param name="YYYYMM"></param>
        /// <returns>null-true;YYYYMM-false</returns>
        public bool YYYYMMFormatCheck(string YYYYMM)
        {
            //六位数字，年月
            Regex yyyymm = new Regex(@"^(19[5-9][0-9]|20[0-9]{2})((0[1-9])|(1[0-2]))$");
            Match ymmatch = yyyymm.Match(YYYYMM);
            if (!ymmatch.Success)
            {
                MsgBox.Show(MSG_COMMON_006, YYYYMM);
                return false;
            }

            return true;
        }


        /// <summary>
        /// YYYY格式检查
        /// </summary>
        /// <param name="YYYYMM"></param>
        /// <returns>null-true;YYYYMM-false</returns>
        public bool YYYYFormatCheck(string YYYY)
        {
            //四位数字，年
            Regex yyyy = new Regex(@"^(19[5-9][0-9]|20[0-9]{2})$");
            Match yatch = yyyy.Match(YYYY);
            if (!yatch.Success)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 动画编号格式检查
        /// </summary>
        /// <param name="AnimeNo">动画编号</param>
        /// <returns></returns>
        public bool AnimeNoCheck(string AnimeNo)
        {
            //编号格式：大写英文字母开头+3位阿拉伯数字
            Regex rg = new Regex(@"^[A-Z][0-9]{3}$");
            Match mt = rg.Match(AnimeNo);

            if (!mt.Success)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 动画简写格式检查
        /// </summary>
        /// <param name="AnimeNN">动画简写</param>
        /// <returns></returns>
        public bool AnimeNNCheck(string AnimeNN)
        {
            //简写格式：大写英文字母开头+若干位字母
            Regex rg = new Regex(@"^[A-Z]+[a-zA-Z]+$");
            Match mt = rg.Match(AnimeNN);

            if (!mt.Success)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获得主角标记字符
        /// </summary>
        /// <param name="IsMain"></param>
        /// <returns></returns>
        public string GetMainCharaStringByBool(bool IsMain)
        {
            if (IsMain)
                return "○";
            return string.Empty;
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

        /// <summary>
        /// 去空格后两文字是否完全相等
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public bool IsFormattenStringEquals(string str1, string str2)
        {
            if (str1.Replace(" ", string.Empty).Replace("　", string.Empty).Trim().Equals(str2.Replace(" ", string.Empty).Replace("　", string.Empty).Trim(), StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
