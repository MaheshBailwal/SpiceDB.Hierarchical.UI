using SpiceDB.UI.Events;
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
    public partial class ConnectToServerFrm : Form
    {
        public ConnectToServerFrm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SpiceDBService.Instance.ServerAddress = txtServer.Text;
            SpiceDBService.Instance.Token = txtToken.Text;
            EventContainer.PublishEvent(EventType.LoadData.ToString(), new EventArg());
            Close();
        }
    }
}
