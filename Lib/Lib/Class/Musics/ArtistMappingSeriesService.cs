using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Class.Abstract;

namespace Lib.Lib.Class.Musics
{
    class ArtistMappingSeriesService : MusicAbstractService
    {
        ArtistMappingSeriesDao dao = new ArtistMappingSeriesDao();

        /// <summary>
        /// 插入数据
        /// </summary>
        public bool Insert(ArtistMappingSeries mapping)
        {
            return dao.Insert(mapping);
        }
    }
}
