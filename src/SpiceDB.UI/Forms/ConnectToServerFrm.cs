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

        private async void btnConnect_Click(object sender, EventArgs e)
        {

            SpiceDBService.Instance.ServerAddress = txtServer.Text;
            SpiceDBService.Instance.Token = txtToken.Text;
            try
            {
                await EventContainer.PublishEventAsync(EventType.LoadData, new EventArg());
                Close();
                Properties.Settings.Default.SpiceDBUrl = txtServer.Text;
                Properties.Settings.Default.SpiceDBToken = txtToken.Text;
                Properties.Settings.Default.Save();
            }
            catch
            {

            }
        }
    }
}
