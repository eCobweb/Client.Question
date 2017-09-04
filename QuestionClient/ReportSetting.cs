using CCWin;
using QuestionClient.Settings;
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
    public partial class ReportSetting : CCSkinMain
    {
        public ReportSetting()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var centerName = this.tbx_centerName.Text;
            var physician = this.txb_physiican.Text;

            if (string.IsNullOrEmpty(centerName) && string.IsNullOrEmpty(physician))
            {
                MessageBox.Show("请输入必要的信息");
                return;
            }

            QuestionWorkflow.Instance().report.CenterName = centerName;
            QuestionWorkflow.Instance().report.PhysicianName = physician;

            if (QuestionWorkflow.Instance().SaveReportSetting())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("保存出错,请重试");
            }
        }

        private void ReportSetting_Load(object sender, EventArgs e)
        {
            this.tbx_centerName.Text = QuestionWorkflow.Instance().report.CenterName;

            this.txb_physiican.Text = QuestionWorkflow.Instance().report.PhysicianName;
        }
    }
}
