using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lib.Lib.Format
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
        /// 由秒数转换成mm:ss
        /// </summary>
        /// <param name="sec"></param>
        /// <returns></returns>
        public string GetTimeFromSecond(int sec)
        {
            int mm = sec / 60;
            int ss = (sec % 60) % 60;

            string res = mm.ToString() + ":" + ss.ToString().PadLeft(2, '0');
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

        /// <summary>
        /// 判断文字列是否曲号或碟号格式
        /// 允许格式 ①纯数字 ②1/1 1/2（取前半）
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool IsDiscNoOrTrackNo(string target)
        {
            if (IsNumber(target))
            {
                return true;
            }
            else 
            {
                Regex reg = new Regex(@"^[0-9]+(/[0-9]+)?$");
                Match mth = reg.Match(target);

                if (mth.Success)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 返回曲号或碟号的整形
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int GetDiscNoOrTrackNo(string target)
        {
            if (!IsNumber(target))
            {
                target = target.Substring(0, target.IndexOf('/'));
            }

            return Convert.ToInt32(target);
        }

        /// <summary>
        /// 返回曲号或碟号的总碟/曲数部分
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int GetAllDiscNoOrTrackNo(string target)
        {
            if (!IsNumber(target))
            {
                int i = target.IndexOf('/');
                int j = target.Length-1;
                target = target.Substring(target.IndexOf('/')+1);
            }

            return Convert.ToInt32(target);
        }

        /// <summary>
        /// 路径名非法字符转化为全角
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string FilePathFormat(string target)
        {
            string rPath = target;
            StringBuilder path = new StringBuilder(target);
            foreach (char rInvalidChar in Path.GetInvalidPathChars())
            {
                path.Replace(rInvalidChar.ToString(), ((char)(rInvalidChar + 65248)).ToString());
            }
            
            return path.ToString();
        }

        /// <summary>
        /// 文件名非法字符转化为全角
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string FileNameFormat(string target)
        {
            string rPath = target;
            StringBuilder path = new StringBuilder(target);
            foreach (char rInvalidChar in Path.GetInvalidFileNameChars())
            {
                path.Replace(rInvalidChar.ToString(), ((char)(rInvalidChar + 65248)).ToString());
            }

            return path.ToString();
        }
    }
}
