using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Main
{
    public partial class seiyuu : Form
    {
        public seiyuu()
        {
            InitializeComponent();
        }

        #region//方法模块
        public OleDbConnection GetConn()//公用：数据库连接
        {
            string connstr = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Animedata.mdb";
            OleDbConnection conn = new OleDbConnection(connstr);
            return conn;
        }
        private void LoadSeiyuu()
        {
            OleDbConnection conn = GetConn();
            string sqlcmd = "SELECT seiyuuname AS 姓名,sex AS 性别, birthday AS 生日 FROM seiyuu ORDER BY seiyuuname";

            try
            {
                conn.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter(sqlcmd, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            conn.Close();
        }
        #endregion

        private void seiyuu_Load(object sender, EventArgs e)
        {
            LoadSeiyuu();
        }
    }
}
