using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
using Main.Lib.Const;

namespace Main.Music
{
    class ResourceSeriesDao : MusicManageDAO
    {
        /// <summary>
        /// 获取下一资源ID
        /// </summary>
        /// <returns></returns>
        public int GetNextResourceID()
        {
            string sqlcmd = @"INSERT INTO {0} (LAST_UPDATE_DATETIME) VALUES (GETDATE()) ";
            return DbCmd.DoCommandGetKey(string.Format(sqlcmd, CommonConst.TableName.T_RESOURCE_ID_TBL));
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(ResourceSeries resource)
        {
            StringBuilder cmd1 = new StringBuilder();
            StringBuilder cmd2 = new StringBuilder();
            StringBuilder sqlcmd = new StringBuilder();

            Collection<DbParameter> paras = new Collection<DbParameter>();

            if (resource.FilePath != null && !resource.FilePath.Trim().Equals(string.Empty))
            {
                cmd1.Append(",RESOURCE_FILEPATH");
                cmd2.Append(",@ResourceFilePath");
                paras.Add(new SqlParameter("@ResourceFilePath", resource.FilePath));
            }

            if (resource.TrackBitRate != null && !resource.TrackBitRate.Trim().Equals(string.Empty))
            {
                cmd1.Append(",TRACK_BITRATE");
                cmd2.Append(",@TrackBitRate");
                paras.Add(new SqlParameter("@TrackBitRate", resource.TrackBitRate));
            }

            if (resource.TrackLength > 0 )
            {
                cmd1.Append(",TRACK_LENGTH");
                cmd2.Append(",@TrackLength");
                paras.Add(new SqlParameter("@TrackLength", resource.TrackLength));
            }

            sqlcmd.Append(@"INSERT INTO {0} (
                                  RESOURCE_ID
                                 ,RESOURCE_TYPE_ID
                                 ,STORAGE_ID
                                 ,RESOURCE_FILENAME
                                 ,RESOURCE_SUFFIX
	                             ,ENABLE_FLG
	                             ,LAST_UPDATE_DATETIME
	                             ");
            sqlcmd.Append(cmd1);
            sqlcmd.Append(@")
                            VALUES (
                                    @ID
		                            ,@TypeID
		                            ,@StorageID
		                            ,@FileName
		                            ,@Suffix
	                                ,1
	                                ,GETDATE() ");
            sqlcmd.Append(cmd2);
            sqlcmd.Append(@")");
            paras.Add(new SqlParameter("@ID", resource.ID));
            paras.Add(new SqlParameter("@TypeID", resource.TypeID));
            paras.Add(new SqlParameter("@StorageID", resource.StorageID));
            paras.Add(new SqlParameter("@FileName", resource.FileName));
            paras.Add(new SqlParameter("@Suffix", resource.Suffix));

            DbCmd.DoCommand(string.Format(sqlcmd.ToString(), CommonConst.TableName.T_RESOURCE_TBL), paras);

            return true;

        }
    }
}
