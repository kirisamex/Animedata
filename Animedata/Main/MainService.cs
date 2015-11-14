using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Main
{
    public class MainService
    {
        #region 常量
        public string selectedRowID;
        
        Maindao dao = new Maindao();

        public const string DELETEANIMEINFO = "删除动画信息";

        public const string ERROR = "错误：";

        public const string ERRORINFO = "错误信息";

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
        public string ConvertToYYYYMMFromDatetime(DateTime dt)
        {
            string YYYYMM = dt.ToString("yyyyMM");
            return YYYYMM;
        }

        #endregion

    }
}
