using QuestionClient.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CefSharp;
using CefSharp.WinForms;
using System.Threading.Tasks;
using System.Threading;

namespace QuestionClient
{
    public partial class main : CCSkinMain
    {
        ChromiumWebBrowser m_chromeBrowser = null;

        BFEB befbObj = null;

        private QuestionWorkflow questionWorkflow = QuestionWorkflow.Instance();

        public static string GetHtmlViewPage(string fileName)
        {
            return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), string.Format("HtmlPages/views/{0}",fileName));
        }
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            try
            {

                string page = GetHtmlViewPage("main.html");
                m_chromeBrowser = new ChromiumWebBrowser(page);

                this.panel_main.Controls.Add(m_chromeBrowser);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            //register interface obj
            befbObj = new BFEB();
            befbObj.SetChromeBrowser(m_chromeBrowser);

            m_chromeBrowser.RegisterJsObject("winObj", befbObj);

            ChromeDevToolsSystemMenu.CreateSysMenu(this);
        }

        private void menu_IDInfo_Click(object sender, EventArgs e)
        {
            IDInfo info = new IDInfo();
            info.StartPosition = FormStartPosition.CenterParent;
            if (info.ShowDialog(this) == DialogResult.OK)
            {
                //
            }
        }

        void openQuestionnaireClient(object sender)
        {
            Label lbl = (Label)sender;

            if (null != lbl)
            {
                var name = lbl.Name;

                int id = Convert.ToInt32(name.Split('_')[1]);

                questionWorkflow.questionnaire = QuestionWorkflow.Instance().Questionnaires.FirstOrDefault(o => { return o.QuestionnaireID == id; });



                QuestionnaireClient qc = new QuestionnaireClient();

                qc.ShowDialog();
            }
        }

        private void lbl_1_Click(object sender, EventArgs e)
        {
            openQuestionnaireClient(sender);
        }

        private void menu_History_Click(object sender, EventArgs e)
        {
            History info = new History();
            info.StartPosition = FormStartPosition.CenterParent;
            if (info.ShowDialog(this) == DialogResult.OK)
            {
                //
            }
        }

        int hotkeyPress = 0;

        private void menu_devTools_Click(object sender, EventArgs e)
        {
            if (hotkeyPress++ > 4)
            {
                m_chromeBrowser.ShowDevTools();

                hotkeyPress = 0;
            }
        }

        private void menu_report_Click(object sender, EventArgs e)
        {
            ReportSetting info = new ReportSetting();
            info.StartPosition = FormStartPosition.CenterParent;
            if (info.ShowDialog(this) == DialogResult.OK)
            {
                //
            }
        }
    }
}
