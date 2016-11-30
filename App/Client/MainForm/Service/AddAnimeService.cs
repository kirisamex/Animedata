using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Client.MainForm.Dao;
using Lib.Lib.Class.Animes;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Const;

namespace Client.MainForm.Service
{
    public class AddAnimeService : AbstractService
    {
        public AddAnimeService() : base() { }

        AddanimeDao dao = new AddanimeDao();

        /// <summary>
        /// 查询是否有重复的动画信息
        /// </summary>
        /// <param name="anime"></param>
        /// <returns></returns>
        public Animation SearchRepeatAnimeInfo(Animation anime, string oldNo, AnimeCommand.Command ctr)
        {
            DataTable dt = dao.SearchRepeatAnimeInfo(anime, oldNo, ctr).Tables[0];

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            return GetAnimeFromAnimeNo(dt.Rows[0][0].ToString());
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
            CV cvc = new CV();
            cvc.ID = dao.GetMaxInt(1) + 1;
            cvc.Name = CVName;

            //CV表插入
            try
            {
                cvc.Insert();
                return cvc.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从数据库中设定角色ID
        /// </summary>
        /// <param name="chara"></param>
        /// <returns></returns>
        public string SetCharacterNoFromDB(Character chara)
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
        /// 返回最大ID，用于PLAYINFO表
        /// </summary>
        /// <param name="tableType">表种类 3:PLAYINFO表</param>
        /// <param name="animeNo">动画No</param>
        /// <returns></returns>
        public int GetMaxInt(int tableType, string animeNo)
        {
            return dao.GetMaxInt(tableType, animeNo);
        }

        /// <summary>
        /// 载入所有制作公司名
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompanyName()
        {
            return dao.LoadCompanyName();
        }

        /// <summary>
        /// 载入所有CV名
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCVName()
        {
            return dao.LoadCVName();
        }
    }
}
