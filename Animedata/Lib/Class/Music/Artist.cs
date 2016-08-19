using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Music
{
    /// <summary>
    /// 艺术家
    /// </summary>
    public class Artist
    {
        #region 变量
        /// <summary>
        /// 艺术家编号
        /// </summary>
        public string Id;

        /// <summary>
        /// 艺术家名
        /// </summary>
        public string Name;

        /// <summary>
        /// 性别编号
        /// 1：男 2：女 3：团体 9：其他
        /// </summary>
        public int Gender;

        /// <summary>
        /// 角色艺术家Flag
        /// </summary>
        public bool IsCharacter = false;

        /// <summary>
        /// 声优艺术家Flag
        /// </summary>
        public bool IsCV = false;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description;
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public Artist()
        {
        }

        /// <summary>
        /// 构造
        /// ！！！空壳
        /// </summary>
        /// <param name="ArtistID"></param>
        public Artist(string ArtistID)
        {
            Id = ArtistID;
        }
        #endregion
    }
}
