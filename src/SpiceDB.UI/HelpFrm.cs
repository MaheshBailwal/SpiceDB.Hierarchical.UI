using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthClient
{
    public partial class HelpFrm : Form
    {
        public HelpFrm()
        {
            InitializeComponent();


            var helpFile = $"file://{Directory.GetParent(Assembly.GetEntryAssembly().Location)}/Help.html".Replace('\\', '/');



           // helpFile = helpFile.Replace('\\', '/');

           //helpFile = $"file:///{helpFile}";


      
            Process myProcess = new Process();

        
                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = helpFile;
                myProcess.Start();
         

            this.webView21.Source = new System.Uri(helpFile, System.UriKind.Absolute);

        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void HelpFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
