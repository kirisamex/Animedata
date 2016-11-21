using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace UILib.Style
{
    public class StatusStyle
    {
        /// <summary>
        /// 状态行样式
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public DataGridViewCellStyle GetStatusRowStyle(int s)
        {
            DataGridViewCellStyle dr = new DataGridViewCellStyle();

            switch (s)
            {
                case 1://放送中
                    dr.ForeColor = Color.White;
                    dr.BackColor = Color.Navy;

                    break;
                case 2://完结
                    dr.ForeColor = Color.FromArgb(0, 97, 0);
                    dr.BackColor = Color.FromArgb(198, 239, 206);
                    break;
                case 3://新企划
                    dr.ForeColor = Color.DarkRed;
                    dr.BackColor = Color.LightPink;
                    break;
                case 9://弃置
                    dr.ForeColor = Color.Black;
                    dr.BackColor = Color.LightGray;
                    break;
            }
            return dr;
        }

        /// <summary>
        /// 状态单元格样式
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public DataGridViewCellStyle GetStatusCellStyle(int s)
        {
            DataGridViewCellStyle dr = new DataGridViewCellStyle();

            switch (s)
            {
                case 1://放送中
                    dr.ForeColor = Color.Green;
                    break;
                case 2://完结
                    dr.BackColor = Color.FromArgb(198, 239, 206);
                    dr.ForeColor = Color.FromArgb(0, 97, 0);
                    break;
                case 3://新企划
                    break;
                case 9://弃置
                    dr.BackColor = Color.Green;
                    break;
            }
            return dr;
        }


    }
}
