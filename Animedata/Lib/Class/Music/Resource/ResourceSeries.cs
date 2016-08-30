using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    /// <summary>
    /// 资源
    /// </summary>
    public class ResourceSeries
    {
        #region 变量
        /// <summary>
        /// 资源ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 资源类型ID
        /// </summary>
        public int TypeID;

        /// <summary>
        /// 存储目录ID
        /// </summary>
        public int StorageID;

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath;

        /// <summary>
        /// 文件名(不含后缀名)
        /// </summary>
        public string FileName;

        /// <summary>
        /// 后缀名
        /// </summary>
        public string Suffix;

        /// <summary>
        /// 音源比特率
        /// </summary>
        public string TrackBitRate;

        /// <summary>
        /// 音源长度
        /// </summary>
        public int TrackLength;

        /// <summary>
        /// 原文件绝对路径
        /// </summary>
        public string objectFilePath;
        #endregion

        #region 常量与构造
        ResourceSeriesService service = new ResourceSeriesService();

        public ResourceSeries()
        {
        }

        public ResourceSeries(int ResourceID)
        {
            this.ID = ResourceID;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 预取下一ID
        /// </summary>
        public void GetNewID()
        {
            ID = service.GetNextResourceID();
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert()
        {
            return service.Insert(this);
        }
        #endregion
    }
}
