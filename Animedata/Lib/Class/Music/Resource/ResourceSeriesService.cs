using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class ResourceSeriesService : MusicManageService
    {
        ResourceSeriesDao dao = new ResourceSeriesDao();

        /// <summary>
        /// 获取下一个资源编号
        /// </summary>
        /// <returns></returns>
        public int GetNextResourceID()
        {
            return dao.GetNextResourceID();
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public bool Insert(ResourceSeries resource)
        {
            return dao.Insert(resource);
        }
    }
}
