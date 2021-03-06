﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Lib.Const
{
    public class DataMappingType
    {
        /// <summary>
        /// 数据是否既存
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// 新数据
            /// </summary>
            New = 0,
            /// <summary>
            /// 已在DB中存在
            /// </summary>
            ExistInDB = 1,
            /// <summary>
            /// 在DB中存在类似
            /// </summary>
            LikeInDB = 2,
            /// <summary>
            /// 在DB中复数存在
            /// </summary>
            MultiExistInDB = 3,

        };
    }
}
