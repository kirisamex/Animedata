using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Main.Lib
{
    /// <summary>
    /// 公共格式类
    /// </summary>
    public class MainFormat
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
        /// 由秒数转换成hh:mm:ss
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

        /// <summary>
        /// 判断文字列是否为纯数字
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool IsNumber(string target)
        {
            if (!string.IsNullOrEmpty(target))
            {
                Regex reg = new Regex(@"^[0-9]+$");
                Match mth = reg.Match(target);

                if (mth.Success)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
