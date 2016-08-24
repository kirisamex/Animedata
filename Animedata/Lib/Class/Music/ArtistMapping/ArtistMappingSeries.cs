using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    public class ArtistMappingSeries
    {
        /// <summary>
        /// 艺术家匹配表
        /// </summary>
        public ArtistMappingSeries()
        {
        }

        /// <summary>
        /// 艺术家匹配表
        /// </summary>
        /// <param name="artistID">艺术家ID</param>
        public ArtistMappingSeries(int artistID)
        {
            this.ArtistId = artistID;
        }

        /// <summary>
        /// 艺术家ID
        /// </summary>
        public int ArtistId;

        /// <summary>
        /// 匹配种类
        /// </summary>
        public int MappingTypeID;

        /// <summary>
        /// 子角色编号
        /// </summary>
        public string ChildCharacterNo;

        /// <summary>
        /// 子声优编号
        /// </summary>
        public int ChildCVNo;

        /// <summary>
        /// 子艺术家编号
        /// </summary>
        public int ChildArtistNo;
    }
}
