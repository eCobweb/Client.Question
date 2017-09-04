using CCWin;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionClient
{
    public partial class PrintPreview : CCSkinMain
    {
        ChromiumWebBrowser m_chromeBrowser = null;
        string htmlPage = string.Empty;
        public PrintPreview(string file)
        {
            InitializeComponent();

            htmlPage = file;
        }

        private void PrintPreview_Load(object sender, EventArgs e)
        {
            try
            {

                m_chromeBrowser = new ChromiumWebBrowser(htmlPage);

                this.Controls.Add(m_chromeBrowser);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
