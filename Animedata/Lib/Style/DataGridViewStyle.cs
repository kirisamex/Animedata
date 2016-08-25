using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using Main.Lib.Const;

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

        /// <summary>
        /// 设置DataGridView各列宽度
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="wid"></param>
        public void SetDataGridViewColumnWidch(DataGridView dgv, int[] wid)
        {
            int colcnt = wid.Length;
            for (int i = 0; i < colcnt; i++)
            {
                dgv.Columns[i].Width = wid[i];
            }
            
        }

        /// <summary>
        /// 设置单元格背景颜色
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="type"></param>
        public void SetMappingTypeBackColor(DataGridViewCell dc, DataMappingType.Type type)
        {
            switch(type)
            {
                case DataMappingType.Type.New:
                case DataMappingType.Type.ExistInDic:
                    dc.Style.BackColor = Color.Pink;
                    break;
                case DataMappingType.Type.ExistInDB:
                    dc.Style.BackColor = Color.Aquamarine;
                    break;
                case DataMappingType.Type.MultiExistInDB:
                    dc.Style.BackColor = Color.Khaki;
                    break;
            }
        }
    }
}
