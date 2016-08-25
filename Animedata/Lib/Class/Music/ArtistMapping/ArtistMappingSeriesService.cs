using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class ArtistMappingSeriesService : MusicManageService
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
