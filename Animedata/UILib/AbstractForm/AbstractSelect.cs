using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.UILib
{
    public partial class AbstractSelect : Form
    {
        string tableName = string.Empty;
        string columnName = string.Empty;
        bool enableFlgUsed = true;

        AbstractSelectService service = new AbstractSelectService();

        public AbstractSelect(string tablename, string columnname, bool enableFlgUsed)
        {
            this.tableName = tablename;
            this.columnName = columnname;
            this.enableFlgUsed = enableFlgUsed;
            InitializeComponent();
        }

        private void ComboboxSelect_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = service.GetTargetList(this.tableName, this.columnName, this.enableFlgUsed);

            keyWordcomboBox.DataSource = dt.DefaultView;
            keyWordcomboBox.Focus();
        }
    }
}
