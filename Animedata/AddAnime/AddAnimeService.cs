using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Main
{
    public class AddAnimeService : MainService
    {
        public AddAnimeService() : base() { }

        AddanimeDao dao = new AddanimeDao();
       
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
            CompanyClass comp = new CompanyClass();
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
                MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 根据公司ID返回公司名
        /// </summary>
        /// <param name="companyNo"></param>
        /// <returns></returns>
        public string GetCompanyNameByCompanyNo(int companyNo)
        {
            return dao.GetCompanyNameByCompanyNo(companyNo);
        }

        /// <summary>
        /// 根据声优名返回声优ID、新规声优信息
        /// </summary>
        /// <param name="CVName"></param>
        /// <returns></returns>
        public int SetCVIDByCVName(string CVName)
        {
            int CVID = dao.GetCVIDByCVName(CVName);

            if (CVID >= 0)
            {
                return CVID;
            }

            //新规声优作成
            CVClass cvc = new CVClass();
            cvc.ID = dao.GetMaxInt("CV") + 1;
            cvc.Name = CVName;

            //CV表插入
            try
            {
                dao.InsertCVInfo(cvc);
                return cvc.ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ERROR + ex.Message, ERRORINFO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -99;
            }
        }

        /// <summary>
        /// 从数据库中设定角色ID
        /// </summary>
        /// <param name="chara"></param>
        /// <returns></returns>
        public string SetCharacterNoFromDB(character chara)
        {
            string maxCharaNo = dao.GetMaxCharacterIDByCharacterInfo(chara);
            int leadingFlg = 0;
            if (chara.leadingFLG)
                leadingFlg = 1;

            string nextCharaNo;

            //数据库内未找到，新发番
            if (string.IsNullOrEmpty(maxCharaNo))
            {
                nextCharaNo = chara.animeNo + "_" + leadingFlg.ToString() + "_001";
            }
            //数据库内找到，接续
            else
            {
                int maxCharaNumber = Convert.ToInt32(maxCharaNo.Substring(7, 3));
                nextCharaNo = chara.animeNo + "_" + leadingFlg.ToString() + "_" + (maxCharaNumber + 1).ToString("D3");
            }
            return nextCharaNo;
        }

        /// <summary>
        /// 通过上一个角色No返回下一个角色No
        /// </summary>
        /// <param name="lastCharaNo">上一个角色No</param>
        /// <returns></returns>
        public string SetCharacterNoFromLastNo(string lastCharaNo)
        {
            int lastCharaNumber = Convert.ToInt32(lastCharaNo.Substring(7, 3));
            string nextCharaNo = lastCharaNo.Substring(0, 7) + (lastCharaNumber + 1).ToString("D3");
            return nextCharaNo;
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
        /// 根据日期转换为YYYY年MM月格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ConvertToYYYYMMFromDatetime(DateTime dt)
        {
            string YYYYMM = dt.Year + "年" + dt.Month + "月";
            return YYYYMM;
        }

        /// <summary>
        /// 根据YYYY年MM月转换为日期
        /// </summary>
        /// <param name="YYYYMM"></param>
        /// <returns></returns>
        public DateTime ConvertToDateTimeFromYYYYMM(string YYYYMM)
        {
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy年MM月";
            return Convert.ToDateTime(YYYYMM, dtFormat);
        }


 
        /// <summary>
        /// 修改功能：更新动画信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        /*
        public bool UpdateAnimeInfo(string id)//
        {
            if (IsAnimeInfoFull() == true)
            {
                return false;
            }

            Animation anime = new Animation();
            anime.name = cnnamebox.Text.ToString();
            anime.nickname = nnbox.Text.ToString();
            anime.status = statescbox.Text.ToString();
            anime.animeid = numbox.Text.ToString();
            anime.fromwhat = originalbox.Text.ToString();

            
            try
            {
                OleDbConnection conn = GetConn();
                if (AnimationRepeatCheck(anime, conn, 1, id) == true)
                {
                    return false;
                }
                conn.Open();
                string sqlcmd = "UPDATE animation SET id = '" + anime.animeid + "',animename='" + anime.name + "',animenickname='" + anime.nickname + "',status='" + anime.status + "',fromwhat='" + anime.fromwhat + "' WHERE ID='" + anime.animeid + "'";
                OleDbCommand cmd = new OleDbCommand(sqlcmd, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        */
    }


}
