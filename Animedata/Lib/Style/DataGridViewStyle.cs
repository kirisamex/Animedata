using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace Main.Lib.Style
{
    class DataGridViewStyle
    {
        /// <summary>
        /// 设置DataGridView列格式以及SplitContainer的距离（横向）
        /// </summary>
        /// <param name="sc">外层SplicContainer</param>
        /// <param name="dgv">需计算列宽的DataGridView</param>
        /// <param name="basicWidth">基准列宽，默认为20</param>
        public void SetDataGridViewAndSplit(SplitContainer sc, DataGridView dgv, int basicWidth = 20)
        {
            int splitterDistance = basicWidth;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (col.Visible)
                {
                    splitterDistance += col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                }
            }
            sc.SplitterDistance = splitterDistance;
        }
    }
}
