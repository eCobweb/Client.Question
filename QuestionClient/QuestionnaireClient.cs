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
using CCWin.SkinControl;

namespace QuestionClient
{
    public partial class QuestionnaireClient : CCSkinMain
    {
        private QuestionWorkflow questionWorkflow = QuestionWorkflow.Instance();

        private int currentQuestion = 0;
        public QuestionnaireClient()
        {
            InitializeComponent();
        }

        private void QuestionnaireClient_Load(object sender, EventArgs e)
        {            
            this.WindowState = FormWindowState.Maximized;

            questionWorkflow.responses = new List<QuestionResponse>();

            DrawQuestionPanel();

            this.btn_end.Enabled = false;

            this.Text = questionWorkflow.questionnaire.Name;
        }

        int space = 100;
        private void DrawQuestionPanel()
        {
            if (null == questionWorkflow.questionnaire.Questions || currentQuestion >= questionWorkflow.questionnaire.Questions.Count)
            {//end to response
                this.button2.Enabled = false;

                this.btn_end.Enabled = true;

                return;
            }
            Question q = questionWorkflow.questionnaire.Questions[currentQuestion];

            this.lbl_QuestionText.Text = string.Format("{0}. {1}   ",q.NO,q.Text);

            int optionIndex = 1;

            

            this.panel_option.Controls.Clear();

            foreach (Option op in q.Options)
            {
                SkinButton rb = new SkinButton();

                rb.Name = "rb_" + questionWorkflow.questionnaire.QuestionnaireID + "_" + q.NO;

                rb.Size = new Size(70, 70);

                rb.AutoSize = true;                

                rb.Text = op.Text;

                rb.TextAlign = ContentAlignment.MiddleCenter;

                rb.Font = setButtonStyle(0,rb);

                rb.BaseColor = System.Drawing.Color.Yellow;
                rb.DownBaseColor = System.Drawing.Color.Gold;

                rb.Location = new Point(getAddedButtonWidth(), getAddedButtonHeight(rb));

                rb.Margin = new Padding(3, 3, 20, 3);

                rb.Tag = optionIndex++;                

                rb.Visible = true;

                QuestionResponse eqr = questionWorkflow.responses.FirstOrDefault(o => {
                    return o.ResponseQuestionnaireID == questionWorkflow.questionnaire.QuestionnaireID &&
                     o.ResponseNO.Equals(q.NO) &&
                     (int)rb.Tag == o.ResponseOption;
                });

                if (null != eqr)
                {
                    setChecked(rb);

                    rb.Font = setButtonStyle(1, rb);
                }

                rb.Click += new EventHandler((obj, ev) => {

                    QuestionResponse qr = questionWorkflow.responses.FirstOrDefault(o => { return o.ResponseQuestionnaireID == questionWorkflow.questionnaire.QuestionnaireID && 
                                                                                        o.ResponseNO.Equals(q.NO) && 
                                                                                        (int)rb.Tag == o.ResponseOption; });

                    if (null != qr)
                    {
                        qr.ResponseOption = (int)rb.Tag;
                    }
                    else
                    {
                        questionWorkflow.responses.Add(new QuestionResponse() { ResponseQuestionnaireID = questionWorkflow.questionnaire.QuestionnaireID,
                                                                                ResponseNO = q.NO,
                                                                                ResponseOption = (int)rb.Tag });
                    }

                   

                    setChecked(rb);

                    rb.Font = setButtonStyle(1,rb);

                });

                this.panel_option.Controls.Add(rb);
            }
        }

        int getAddedButtonWidth()
        {
            var ctrls = this.panel_option.Controls;

            if(ctrls.Count > 0)
            { 
                 var lastX = ctrls[ctrls.Count - 1].Location.X;
                var lastWidth = ctrls[ctrls.Count - 1].Width;
                return lastX + lastWidth + space ;
            }
            

            return 0;
        }

        int getAddedButtonHeight(SkinButton sb)
        {
            int totalWeight = getAddedButtonWidth();

            if (totalWeight + space + sb.Width > this.panel_option.Width)
            {
                return 30+ 30 +30;
            }

            return 30;
        }

        Point getNewButtonPoint(SkinButton sb)
        {
            int w = getAddedButtonWidth();
            int h = getAddedButtonHeight(sb);

            return new Point(0,0);

            //TODO;

        }
        Font setButtonStyle(int flag,SkinButton sb)
        {
            if (flag < 1)
            {
                sb.BaseColor = System.Drawing.Color.Yellow;
                return new Font(FontFamily.GenericMonospace, 15, FontStyle.Regular);
            }
            else
            {
                sb.BaseColor = System.Drawing.Color.Red;
                return new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold);

            }
        }

        void setChecked(SkinButton sb)
        {
            foreach (Control ctl in this.panel_option.Controls)
            {
                if (ctl is SkinButton && !((SkinButton)ctl).Equals(sb))
                {
                    ctl.Font = setButtonStyle(0, (SkinButton)ctl);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool canNext = false;

            foreach (Control ctl in this.panel_option.Controls)
            {
                canNext = ctl is SkinButton && ((SkinButton)ctl).Font.Bold;

                if (canNext) break;
            }

            if (!canNext)
            {
                MessageBox.Show("请选择");

                return;
            }

            currentQuestion++;

            DrawQuestionPanel();
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            //calculte 

            questionWorkflow.result = QuestionHelper.GetCurrentResult();

            MessageBox.Show(questionWorkflow.result);

            //save to file

            if (null == questionWorkflow.user)
            {
                MessageBox.Show("请录入身份信息，方可保存数据");

                return;
            }

            string dataName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "data.xml");

            List<QuestionWorkflow> qns = QuestionHelper.DeSerializeObject<List<QuestionWorkflow>>(dataName);

            questionWorkflow.date = System.DateTime.Now;

            if (null != qns)
            {
                qns.Add(questionWorkflow);
            }
            else
            {
                qns = new List<QuestionWorkflow>();
                qns.Add(questionWorkflow);
            }

            QuestionHelper.SerializeObject<List<QuestionWorkflow>>(qns, dataName);

            this.Close();
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (currentQuestion > 0)
            {
                currentQuestion--;
                DrawQuestionPanel();
            }
        }
    }
}
