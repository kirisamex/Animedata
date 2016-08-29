using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class TrackResource
    {
        #region 变量
        /// <summary>
        /// 曲目编号
        /// </summary>
        public string TrackID;

        /// <summary>
        /// 资源编号
        /// </summary>
        public int ResourceID;
        #endregion

        TrackResourceService service = new TrackResourceService();

        #region 方法
        /// <summary>
        /// 数据插入
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            return service.Insert(this);
        }
        #endregion
    }
}
