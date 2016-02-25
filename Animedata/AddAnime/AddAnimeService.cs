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
        /// 查询是否有重复的动画信息（新规）
        /// </summary>
        /// <param name="anime"></param>
        /// <returns></returns>
        public Animation SearchRepeatAnimeInfo(Animation anime, AddAnime.command ctr)
        {
            return dao.SearchRepeatAnimeInfo(anime, ctr);
        }

        /// <summary>
        /// 查询是否有重复的动画信息（修改）
        /// </summary>
        /// <param name="anime"></param>
        /// <param name="ctr"></param>
        /// <returns></returns>
        public Animation SearchChangedAnimeInfo(Animation anime, AddAnime.command ctr)
        {
            return dao.SearchRepeatAnimeInfo(anime,ctr);
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
            cvc.ID = dao.GetMaxInt("CV") + 1;
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
 
    }


}
