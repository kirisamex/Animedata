using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Lib
{
    class MainFormat
    {
        /// <summary>
        /// 由hh:mm:ss:格式获得秒数
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int GetSecondFromTime(string time)
        {
            string[] res = time.Split(new char[] { ':' });
            int hh = Convert.ToInt32( res[0] )* 3600;
            int mm = Convert.ToInt32(res[1]) * 60;
            int ss = Convert.ToInt32(res[2]);

            return hh + mm + ss;
        }

        /// <summary>
        /// 由
        /// </summary>
        /// <param name="sec"></param>
        /// <returns></returns>
        public string GetTimeFromSecond(int sec)
        {
            int hh = sec / 3600;
            int mm = (sec % 3600) / 60;
            int ss = (sec % 3600) % 60;

            string res = hh.ToString() + ":" + mm.ToString().PadLeft(2, '0') + ss.ToString().PadLeft(2, '0');
            return res;
        }
    }
}
