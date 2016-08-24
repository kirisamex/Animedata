using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
using Main.Lib.Const;

namespace Main
{
    public class AddanimeDao : Maindao
    {
        public AddanimeDao()
            : base()
        {
        }

        #region SELECT系

        /// <summary>
        /// 载入所有制作公司名
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCompanyName()
        {
            string sqlcmd = @"SELECT COMPANY_NAME
                                    FROM {0}
 									WHERE ENABLE_FLG = 1 
                                    ORDER BY COMPANY_NAME";
            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_COMPANY_TBL));
        }

        /// <summary>
        /// 载入所有声优名
        /// </summary>
        /// <returns></returns>
        public DataSet LoadCVName()
        {
            string sqlcmd = @"SELECT CV_NAME
                                    FROM {0}
                                    WHERE ENABLE_FLG = 1
									ORDER BY CV_NAME";

            return DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_CV_TBL));
        }

        /// <summary>
        /// 根据角色信息获得最大角色编号
        /// </summary>
        /// <param name="chara"></param>
        /// <returns></returns>
        public string GetMaxCharacterIDByCharacterInfo(Character chara)
        {
            string sqlcmd = @"SELECT 
                                    MAX(CHARACTER_NO)
                                    FROM {0}
                                    WHERE ANIME_NO = @animeNo
                                    AND LEADING_FLG = @leadingflg";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", chara.animeNo));
            paras.Add(new SqlParameter("@leadingflg", chara.leadingFLG));

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd, CommonConst.TableName.T_CHARACTER_TBL), paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                string maxNo = ds.Tables[0].Rows[0][0].ToString();
                return maxNo;
            }
        }

        /// <summary>
        /// 查询是否有重复的动画信息
        /// </summary>
        /// <param name="anime"></param>
        /// <returns>重复的动画信息，如无则为null</returns>
        public Animation SearchRepeatAnimeInfo(Animation anime, AddAnime.command ctr)
        {
            string sqlcmd = @"SELECT *
                                FROM {0}
                                WHERE ANIME_NO = @animeNo
	                                OR ANIME_CHN_NAME = @animeCNName
	                                OR ANIME_JPN_NAME = @animeJPName
	                                OR ANIME_NN = @nickname";

            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@animeNo", anime.No));
            paras.Add(new SqlParameter("@animeCNName", anime.CNName));
            paras.Add(new SqlParameter("@animeJPName", anime.JPName));
            paras.Add(new SqlParameter("@nickname", anime.Nickname));

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd,CommonConst.TableName.T_ANIME_TBL), paras);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            if (ctr == AddAnime.command.Update && ds.Tables[0].Rows[0][0].ToString().Equals(anime.No))
            {
                return null;
            }

            Animation repeatAnime = new Animation();
            repeatAnime.No = ds.Tables[0].Rows[0][0].ToString();
            repeatAnime.CNName = ds.Tables[0].Rows[0][1].ToString();
            repeatAnime.JPName = ds.Tables[0].Rows[0][2].ToString();
            repeatAnime.Nickname = ds.Tables[0].Rows[0][3].ToString();
            return repeatAnime;
        }

        #endregion

        #region INSERT系
        #endregion

        #region UPDATE系
        #endregion

        #region DELETE系
        #endregion

    }
}
