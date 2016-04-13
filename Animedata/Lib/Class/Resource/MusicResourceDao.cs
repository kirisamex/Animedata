using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    public class MusicResourceDao : Maindao
    {
        public MusicResourceDao() : base() { }

        /// <summary>
        /// 根据曲目ID以及资源类型获得资源信息
        /// </summary>
        /// <param name="TrackID"></param>
        /// <param name="ResourceType"></param>
        /// <returns></returns>
        public DataSet GetResource(string TrackID, int ResourceType)
        {
            string cmd = @"SELECT 
                            RT.RESOURCE_ID,
                            RT.STORAGE_ID,
                            RT.RESOURCE_FILEPATH,
                            RT.RESOURCE_FILENAME
                            FROM ANIMEDATA.dbo.T_RESOURCE_TBL RT
                            INNER JOIN ANIMEDATA.dbo.T_TRACK_RESOURCE_TBL TRT ON RT.RESOURCE_ID = TRT.RESOURCE_ID AND TRT.ENABLE_FLG = 1
                            WHERE TRT.TRACK_ID = @trackid
                            AND RT.RESOURCE_TYPE = @resourcetype
                            ";
                
            Collection<DbParameter> paras = new Collection<DbParameter>();
            paras.Add(new SqlParameter("@trackid", TrackID));
            paras.Add(new SqlParameter("@resourcetype", ResourceType));

            return DbCmd.DoSelect(cmd,paras);
        }
    }
}
