using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    class ArtistSeriesService : MainService
    {
        ArtistSeriesDao dao = new ArtistSeriesDao();

        /// <summary>
        /// 根据艺术家名确定艺术家是否存在
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
        public bool isExist(string artistName)
        {
            return dao.isExist(artistName);
        }

        /// <summary>
        /// 根据整形后的艺术家名确定整形后的艺术家是否存在
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
        public int isExistFormatted(string formattedArtistName)
        {
            return dao.isExistFormatted(formattedArtistName);
        }

        /// <summary>
        /// 根据艺术家ID确定艺术家是否存在
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
        public bool isExist(int artistID)
        {
            return dao.isExist(artistID);
        }


        /// <summary>
        /// 根据艺术家姓名取艺术家ID
        /// </summary>
        /// <param name="artistName"></param>
        /// <returns></returns>
        public int GetArtistIDFromArtistName(string artistName)
        {
            return dao.GetArtistIDFromArtistName(artistName);
        }

        /// <summary>
        /// 获取下一个艺术家编号
        /// </summary>
        /// <returns></returns>
        public int GetNextArtistID()
        {
            return dao.GetNextArtistID();
        }

        /// <summary>
        /// 数据插入
        /// </summary>
        public bool Insert(ArtistSeries artist)
        {
            if (artist.Mapping.Count > 0)
            {
                foreach (ArtistMappingSeries map in artist.Mapping)
                {
                    if (!map.Insert())
                    {
                        return false;
                    }
                }
            }

            return dao.Insert(artist);
        }
    }
}
