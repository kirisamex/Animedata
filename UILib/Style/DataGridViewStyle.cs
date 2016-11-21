using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using Lib.Lib.Const;

namespace UILib.Style
{
    public class DataGridViewStyle
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
                    dc.Style.BackColor = Color.Pink;
                    break;
                case DataMappingType.Type.ExistInDB:
                    dc.Style.BackColor = Color.Aquamarine;
                    break;
                case DataMappingType.Type.MultiExistInDB:
                case DataMappingType.Type.LikeInDB:
                    dc.Style.BackColor = Color.Khaki;
                    break;
            }
        }

        /// <summary>
        /// 设定选中式按钮背景色
        /// </summary>
        /// <param name="bt">按钮</param>
        /// <param name="choosed">是否选中</param>
        public void SetButtonSelectedColor(Button bt, bool choosed)
        {
            if (choosed)
            {
                bt.BackColor = Color.RoyalBlue;
                bt.ForeColor = Color.White;
            }
            else
            {
                bt.BackColor = Color.Transparent;
                bt.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 对字典式datagridview增加行
        /// 字典式dgv：固定三列：tag+key,tag+name,tag+value
        /// </summary>
        /// <param name="dgv">对应DataGridView</param>
        /// <param name="tag">标签名</param>
        /// <param name="key">字段名</param>
        /// <param name="name">显示名称</param>
        /// <param name="value">显示值</param>
        /// <param name="isReadonly">该行是否只读</param>
        /// <param name="isVisible">该行是否可见</param>
        public void AddDicDataGridView(DataGridView dgv, string tag, string key, string name, string value,
            bool isReadonly, bool isVisible, bool isChooseful = false)
        {
            int idx = dgv.Rows.Add();
            DataGridViewRow dr = dgv.Rows[idx];
            dr.Cells[tag + "key"].Value = key;
            dr.Cells[tag + "name"].Value = name;
            if (value != null)
            {
                dr.Cells[tag + "value"].Value = value;
            }
            dr.Cells[tag + "value"].ReadOnly = isReadonly;
            dr.Visible = isVisible;

            if (!isReadonly)
            {
                dr.Cells[tag + "value"].Style.BackColor = Color.PaleGreen;
            }
            else if (isChooseful)
            {
                dr.Cells[tag + "value"].Style.BackColor = Color.PaleTurquoise;
            }
        }
    }
}
