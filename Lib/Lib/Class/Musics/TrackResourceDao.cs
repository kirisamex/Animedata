using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using MySql.Data.MySqlClient;
using Lib.Lib.Class.Abstract;
using Lib.Lib.Const;

namespace Lib.Lib.Class.Musics
{
    class TrackResourceDao : MusicAbstractDao
    {
        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(TrackResource map)
        {
            try
            {
                StringBuilder sqlcmd = new StringBuilder();

                sqlcmd.Append(@"INSERT INTO {0} (
                                  TRACK_ID
                                 ,RESOURCE_ID
	                             ,ENABLE_FLG
	                             ,LAST_UPDATE_DATETIME
	                             )
                            VALUES (
                                    @TrackID
		                            ,@ResourceID
	                                ,1
	                                ,NOW())");

                Collection<DbParameter> paras = new Collection<DbParameter>();
                paras.Add(new MySqlParameter("@TrackID", map.TrackID));
                paras.Add(new MySqlParameter("@ResourceID", map.ResourceID));

                DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_TRACK_RESOURCE_TBL), paras);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }
    }
}
