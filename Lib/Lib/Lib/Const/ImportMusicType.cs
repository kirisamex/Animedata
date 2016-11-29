using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Lib.Const
{
    public class ImportMusicType
    {
        /// <summary>
        /// 导入数据类型
        /// </summary>
        public enum ImportType
        {
            /// <summary>通过新下载的MP3 </summary>
            ByNewMP3,
            /// <summary>通过既有的MP3 </summary>
            ByOldMP3,
            /// <summary>通过Excel </summary>
            ByExcel,
        }
    }
}




