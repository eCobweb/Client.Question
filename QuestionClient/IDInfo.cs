using CCWin;
using QuestionClient.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuestionClient
{
    public partial class IDInfo : CCSkinMain
    {
        public IDInfo()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var name = this.tbx_Name.Text;
            int age = 0;
            if(!string.IsNullOrEmpty(this.tbx_age.Text) && int.TryParse(this.tbx_age.Text, out age))
            {

            }

            var id = this.tbx_id.Text;

            var gender = this.cmb_gender.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender))
            {
                QuestionWorkflow.Instance().user = new User() { Name = name, Age = age, Gender = gender, ID = id };
            }
            else
            {
                MessageBox.Show("保存失败，姓名和性别不能为空");

                this.btn_save.DialogResult =  DialogResult.Retry;
            }

            this.btn_save.DialogResult = DialogResult.OK;
        }

        private void IDInfo_Load(object sender, EventArgs e)
        {
            var user = QuestionWorkflow.Instance().user;

            if (null != user)
            {
                this.tbx_Name.Text = user.Name;
                this.tbx_age.Text = user.Age.ToString();

                this.cmb_gender.Text = user.Gender;

                this.tbx_id.Text = user.ID;
            }
        }
    }
}
