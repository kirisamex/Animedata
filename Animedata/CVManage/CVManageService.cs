﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Main
{
    public class CVManageService:MainService
    {
        CVManageDao dao = new CVManageDao();

        /// <summary>
        /// 载入声优信息
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCVInfo()
        {
            return dao.LoadCVInfo();
        }

        /// <summary>
        /// 插入声优信息
        /// </summary>
        /// <param name="cvInfo"></param>
        public void InsertCVInfo(CV cvInfo)
        {
            dao.InsertCVInfo(cvInfo);
        }

        /// <summary>
        /// 更新声优信息
        /// </summary>
        /// <param name="cvInfo"></param>
        public void UpdateCVInfo(CV cvInfo)
        {
            dao.UpdateCVInfo(cvInfo);
        }

        /// <summary>
        /// 删除声优信息
        /// </summary>
        /// <param name="cvList"></param>
        /// <returns></returns>
        public bool DeleteCVInfo(List<CV> cvList)
        {
            string errorMessage = string.Empty;
            bool repeatflg = false;

            //检查是否使用
            foreach (CV cvInfo in cvList)
            {
                List<Character> repeatCharacerInfo = cvInfo.UsedCheck();
                
                if (repeatCharacerInfo != null)
                {
                    string errorString = string.Empty;
                    foreach (Character cInfo in repeatCharacerInfo)
                    {
                        errorString += "出自 " + GetAnimeFromAnimeNo(cInfo.animeNo).CNName + " 的 " + cInfo.name + ";\n";
                        errorMessage += "声优:" + cvInfo.Name + " 为以下角色配音\n" + errorString + "";
                    }
                    repeatflg = true;
                    
                }
                errorMessage += "\n";
            }

            if (repeatflg)
            {
                errorMessage += "若需要删除该声优请先删除上述角色信息。";
                ShowErrorMessage(errorMessage);
                return false;
            }

            //删除实行
            foreach (CV cvInfo in cvList)
            {
                cvInfo.Delete();
            }

            return true;
        }

        /// <summary>
        /// 获得最大CV编号的下一编号
        /// </summary>
        /// <returns></returns>
        public int GetNextCVCount()
        {
            return dao.GetMaxInt("CV") + 1;
        }

        #region 格式处理

        /// <summary>
        /// 通过性别字符获得性别代号
        /// </summary>
        /// <param name="genderString"></param>
        /// <returns></returns>
        public string GetGenderCharFromGenderString(string genderString)
        {
            switch(genderString)
            {
                case "男":
                    return "M";
                case "女":
                    return "F";
                default:
                    return null;
            }
        }

        /// <summary>
        /// 通过性别代号获得性别字符
        /// </summary>
        /// <param name="GenderChar"></param>
        /// <returns></returns>
        public string GetGenderStringFromGenderChar(string GenderChar)
        {
            switch (GenderChar)
            {
                case "M":
                    return "男";
                case "F":
                    return "女";
                default:
                    return null;
            }
        }

        /// <summary>
        /// 根据日期转换为YYYY年M月D日格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ConvertToYYYYNianMMYueDDRiFromDatetime(DateTime dt)
        {
            return dt.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// 根据YYYYMMDD转换为日期
        /// </summary>
        /// <param name="YYYYMMDD"></param>
        /// <returns></returns>
        public DateTime ConvertToDateTimeFromYYYYMMdd(string YYYYMMDD)
        {
            DateTime dt;
            DateTime.TryParseExact(YYYYMMDD, "yyyyMMdd", null, DateTimeStyles.None, out dt);
            return dt;
        }

        /// <summary>
        /// 根据YYYY年MM月DD日转化为YYYYMMDD
        /// </summary>
        /// <param name="YYYYNianMMYueDDRi"></param>
        /// <returns></returns>
        public string ConvertToYYYYMMDDFromYYYYNianMMYueDDRi(string YYYYNianMMYueDDRi)
        {
            DateTime dt;
            DateTime.TryParseExact(YYYYNianMMYueDDRi, "yyyy年MM月dd日", null, DateTimeStyles.None, out dt);
            return ConvertToYYYYMMDDFromDatetime(dt);
        }

        #endregion

        #region 规则检查
        /// <summary>
        /// YYYYMMDD格式检查
        /// </summary>
        /// <param name="YYYYMMDD"></param>
        /// <returns></returns>
        public bool YYYYMMDDFormatCheck(string YYYYMMDD)
        {
            //8位数字，年月日，考虑闰年
            Regex yyyymmdd = new Regex(@"^([12]\d{3}((0[1-9]|1[012])(0[1-9]|1\d|2[0-8])|(0[13456789]|1[012])(29|30)|(0[13578]|1[02])31)|(([12]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00))0229)$");
            Match ymdmatch = yyyymmdd.Match(YYYYMMDD);
            if (!ymdmatch.Success)
            {
                ShowErrorMessage("\n[ " + YYYYMMDD + " ]的年月日格式或日期不正确！时间格式：yyyyMMdd。");
                return false;
            }

            //是否超过今天
            if (ConvertToDateTimeFromYYYYMMdd(YYYYMMDD) > DateTime.Today)
            {
                ShowErrorMessage("\n[ " + YYYYMMDD + " ]日期超过了当前时间，请检查是否填写错误或系统时间不正确！");
                return false;
            }

            return true;
        }

        /// <summary>
        /// CVID重复检查
        /// </summary>
        /// <param name="CVID"></param>
        /// <returns></returns>
        public bool CVIDRepeatCheck(int CVID)
        {
            return dao.CVIDRepeatCheck(CVID);
        }
        #endregion

    }
}
