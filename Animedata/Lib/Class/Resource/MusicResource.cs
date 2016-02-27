using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    public class MusicResource
    {
        #region 常量
        /// <summary>
        /// 资源编号
        /// </summary>
        public int ID = 0;

        /// <summary>
        /// 资源类型
        /// 1：mp3  11:lrc 21：专辑封面
        /// </summary>
        public int Type;

        /// <summary>
        /// 存储路径编号
        /// </summary>
        public int StorageID;

        /// <summary>
        /// 存储路径
        /// </summary>
        public string FilePath;

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName;
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public MusicResource()
        {
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="ResourceID"></param>
        public MusicResource(int ResourceID)
        {
            ID = ResourceID;
        }

        /// <summary>
        /// 通过曲目编号与资源类型获得资源
        /// </summary>
        /// <param name="TrackID"></param>
        /// <param name="ResourceType"></param>
        public MusicResource(string TrackID, int ResourceType)
        {
            DataSet ds = dao.GetResource(TrackID, ResourceType);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            if (ds.Tables[0].Rows[0]["RESOURCE_ID"] != null)
            {
                ID = Convert.ToInt32(ds.Tables[0].Rows[0]["RESOURCE_ID"]);
            }

            Type = ResourceType;

            if (ds.Tables[0].Rows[0]["STORAGE_ID"] != null)
            {
                StorageID = Convert.ToInt32(ds.Tables[0].Rows[0]["STORAGE_ID"]);
            }
            if (ds.Tables[0].Rows[0]["RESOURCE_FILEPATH"] != null)
            {
                FilePath = ds.Tables[0].Rows[0]["RESOURCE_FILEPATH"].ToString();
            }
            if (ds.Tables[0].Rows[0]["RESOURCE_FILENAME"] != null)
            {
                FileName = ds.Tables[0].Rows[0]["RESOURCE_FILENAME"].ToString();
            }
        }
        #endregion

        //实例化
        MusicResourceDao dao = new MusicResourceDao();
    }
}
