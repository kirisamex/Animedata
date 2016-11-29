using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Lib.Const
{
    public class AnimeCommand
    {
        /// <summary>
        /// 操作种类
        /// </summary>
        public enum Command
        {
            /// <summary>
            /// 添加
            /// </summary>
            Add = 0,
            /// <summary>
            /// 修改
            /// </summary>
            Update = 1,
            /// <summary>
            /// 删除
            /// </summary>
            Delete = 2,
        };
    }
}
