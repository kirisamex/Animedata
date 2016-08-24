using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Lib.Const;
using Main.Lib.Model;

namespace Main.Music
{
    class SelectArtistDao : MusicManageDAO
    {
        /// <summary>
        /// 获得声优数据DataSet
        /// </summary>
        /// <returns></returns>
        public DataSet GetCVListData()
        {
            StringBuilder sqlcmd = new StringBuilder();

            sqlcmd.Append(@"SELECT CV_ID,CV_NAME  FROM {0} ");
                sqlcmd.Append(" WHERE ENABLE_FLG = 1 ");


            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_CV_TBL));

            return ds;
        }

        /// <summary>
        /// 获得角色数据DataSet
        /// </summary>
        /// <returns></returns>
        public DataSet GetCharacterListData()
        {
            StringBuilder sqlcmd = new StringBuilder();

            sqlcmd.Append(@"SELECT CCT.CHARACTER_NO , CCT.CHARACTER_NAME , AT.ANIME_CHN_NAME
                                FROM {0} CCT
                                INNER JOIN {1} AT ON CCT.ANIME_NO = AT.ANIME_NO AND AT.ENABLE_FLG = 1
                                WHERE CCT.ENABLE_FLG = 1 ");

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_CHARACTER_TBL, CommonConst.TableName.T_ANIME_TBL));

            return ds;
        }

        /// <summary>
        /// 获得歌手数据DataSet
        /// </summary>
        /// <param name="tableName">目标表名</param>
        /// <param name="idColName">主键列名</param>
        /// <param name="displayColName">显示列名</param>
        /// <param name="enableFlgUsed">是否使用ENABLE_FLG = 1</param>
        /// <returns></returns>
        public DataSet GetSingerListData(int artistID)
        {
            StringBuilder sqlcmd = new StringBuilder();

            sqlcmd.Append(@"SELECT ART.ARTIST_ID , ART.ARTIST_NAME
                                FROM {0}  ART
                                LEFT JOIN {1} MAP ON ART.ARTIST_ID = MAP.ARTIST_ID AND MAP.ENABLE_FLG = 1
                                LEFT JOIN {0} ART2 ON MAP.CHILD_ARTIST_ID = ART2.ARTIST_ID AND ART2.ENABLE_FLG = 1
                                WHERE ART.ENABLE_FLG = 1 
                                    AND ART.ARTIST_ID <> @artistID 
                                    AND ART2.ARTIST_ID <> @artistID ");

            Collection<DbParameter> paras = new Collection<DbParameter>();
            SqlParameter para = new SqlParameter("@artistID", artistID);
            paras.Add(para);

            DataSet ds = DbCmd.DoSelect(string.Format(sqlcmd.ToString(),
                CommonConst.TableName.T_ARTIST_TBL, CommonConst.TableName.T_ARTIST_MAPPING_TBL), paras);

            return ds;
        }
    }
}
