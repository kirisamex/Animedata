using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class TrackResourceService:MusicManageService
    {
        TrackResourceDao dao = new TrackResourceDao();

        /// <summary>
        /// 数据插入
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public bool Insert(TrackResource map)
        {
            return dao.Insert(map);
        }
    }
}
