using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Class.Abstract;

namespace Lib.Lib.Class.Musics
{
    class TrackResourceService : MusicAbstractService
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
