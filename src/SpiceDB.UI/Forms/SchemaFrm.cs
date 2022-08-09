using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiceDB.UI.Forms
{
    public partial class SchemaFrm : Form
    {
        public SchemaFrm()
        {
            InitializeComponent();
        }

        private void SchemaFrm_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = SpiceDBService.Instance.Schema;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text.Trim()))
            {
                SpiceDBService.Instance.ImportSchemaFromString(richTextBox1.Text);
                MessageBox.Show("Schema Updated Successfully");
            }
            else
            {
                MessageBox.Show("Please Define Schema");
            }
        }
    }
}
