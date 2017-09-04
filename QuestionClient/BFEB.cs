using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using QuestionClient.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionClient
{
    public class BFEB
    {
        [JavascriptIgnore]
        public ChromiumWebBrowser m_chromeBrowser { get; set; }

        public BFEB()
        {
           
        }

        [JavascriptIgnore]
        public void SetChromeBrowser(ChromiumWebBrowser b)
        {
            m_chromeBrowser = b;
        }

        //use someFunction from javascript call, who knows!
        public string SomeFunction()
        {

            return "yippieee";
        }

        public void sendData()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction() {");
            sb.AppendLine("     return $('#result').val();");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction();");

            TaskScheduler syncContextScheduler;
            if (SynchronizationContext.Current != null)
            {
                syncContextScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            }
            else
            {
                // If there is no SyncContext for this thread (e.g. we are in a unit test
                // or console scenario instead of running in an app), then just use the
                // default scheduler because there is no UI thread to sync with.
                syncContextScheduler = TaskScheduler.Current;
            }

            var task = m_chromeBrowser.EvaluateScriptAsync(sb.ToString());

            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    // Step 04: Recieve value from JS
                    var response = t.Result;

                    if (response.Success == true)
                    {
                        // Use JSON.net to convert to object;
                        System.Windows.Forms.MessageBox.Show(response.Result.ToString());
                    }
                }
            }, syncContextScheduler);
        }

        public int getMainFormHeight()
        {
            Form mainForm = Application.OpenForms["main"];

            return mainForm.Controls.Find("panel_main",false)[0].Height;
        }

        public string getQuestionnaireCovers()
        {
            int fadeID = 0;

            StringBuilder sb = new StringBuilder();

            sb.Append("[");


            List<Questionnaire> qns = QuestionWorkflow.Instance().Questionnaires;

            List<QuestionnaireCover> qcs = new List<QuestionnaireCover>();


            var groups = qns.FindAll(q => !string.IsNullOrEmpty(q.GroupName));

            List<string> groupNames = new List<string>();

            groups.ForEach(o => groupNames.Add(o.GroupName));

            groupNames = groupNames.Distinct<string>().ToList();

            groupNames.ForEach(g => {
                List<QuestionnaireCover> subCovers = new List<QuestionnaireCover>();

                qns.FindAll(q => q.GroupName.Equals(g)).ForEach(sq => subCovers.Add(new QuestionnaireCover() { Name = sq.Name, ID = sq.QuestionnaireID }));

                qcs.Add(new QuestionnaireCover() { Name = g, ID = fadeID--, SubCovers = subCovers });
            });


            qns.ForEach(o =>
            {
                if(!groups.Contains(o))
                    qcs.Add(new QuestionnaireCover() { Name = o.Name, ID = o.QuestionnaireID });
            });

            return JsonConvert.SerializeObject(qcs);
        }

        public string getQuestionnaire(int id)
        {
            string jsResult = string.Empty;

            Questionnaire qn = QuestionWorkflow.Instance().Get(id);


            if (null != qn)
            {
                jsResult = JsonConvert.SerializeObject(qn);
            }

            return jsResult;
        }

        public string getCurrentUser()
        {
            if (null == QuestionWorkflow.Instance().user)
            {
                return string.Empty;
            }

            return QuestionWorkflow.Instance().user.Name;
        }

        public string FinishQuestionnaire(object result)
        {
            string ret = string.Empty;
            if (null == (result))
            {
                return ret;
            }

            Dictionary<string, object> dicResult = (Dictionary<string, object>)result;

            JSResult jsResult = new JSResult();

            List<JSOptions> jsOptions = new List<JSOptions>();

            jsResult.QuestionnaireID = Convert.ToInt32(dicResult["QuestionnaireID"]);

            Questionnaire qn = QuestionWorkflow.Instance().Questionnaire;

            string resultCode = string.Empty;

            object[] objOptions = (object[])dicResult["Options"];

            for (int i = 0; i < objOptions.Length; i++)
            {
                Dictionary<string, object> dicOption = (Dictionary<string, object>)objOptions[i];

                JSOptions jso = new JSOptions() { key = dicOption["key"].ToString(), value = Convert.ToInt32(dicOption["val"]) };

                jsOptions.Add(jso);
            }           

            jsResult.Options = jsOptions;



            switch(jsResult.QuestionnaireID)
            {
                case 1:
                    ret = QuestionHelper.resultMessage1(qn, jsResult, out resultCode);
                    break;
                case 2:
                    ret = QuestionHelper.resultMessage2(qn, jsResult, out resultCode);
                    break;
                case 3:
                    ret = QuestionHelper.resultMessage3(qn, jsResult, out resultCode);
                    break;
                case 4:
                    ret = QuestionHelper.resultMessage4(qn, jsResult, out resultCode);
                    break;
                case 5:
                    ret = QuestionHelper.resultMessage5(qn, jsResult, out resultCode);
                    break;
                case 6:
                    ret = QuestionHelper.resultMessage6(qn, jsResult, out resultCode);
                    break;
                case 7:
                    ret = QuestionHelper.resultMessage7(qn, jsResult, out resultCode);
                    break;
                case 8:
                    ret = QuestionHelper.resultMessage8(qn, jsResult, out resultCode);
                    break;
                case 9:
                    ret = QuestionHelper.resultMessage9(qn, jsResult, out resultCode);
                    break;
                case 10:
                    ret = QuestionHelper.resultMessage10(qn, jsResult,out resultCode);
                    break;
                case 11:

                    ret = QuestionHelper.resultMessage11(qn, jsResult, out resultCode);

                    break;
                case 12:

                    ret = QuestionHelper.resultMessage12(qn, jsResult, out resultCode);

                    break;
                case 13:

                    ret = QuestionHelper.resultMessage13(qn, jsResult, out resultCode);

                    break;

                case 14:

                    ret = QuestionHelper.resultMessage14(qn, jsResult, out resultCode);

                    break;

                case 15:

                    ret = QuestionHelper.resultMessage15(qn, jsResult, out resultCode);

                    break;

            }

            Tuple<bool,string> saveResult = QuestionWorkflow.Instance().SaveWorkflow(ret, resultCode);


            return "{\"code\":" + (saveResult.Item1?1:0) + ",\"message\":\"" + (string.IsNullOrEmpty(saveResult.Item2)? "无法确定基本体质": saveResult.Item2) + "\"}";
        }


        public string PrintReport()
        {
            try
            {
                var result = QuestionWorkflow.Instance().CreateResultPageAsync().Result;

                if (!string.IsNullOrEmpty(result))
                {
                    Form mainForm = Application.OpenForms["main"];
                    mainForm.BeginInvoke(new Action(() => { new PrintPreview(result).ShowDialog(); }));
                    //PrintPreview frmPreview = new PrintPreview(result);
                    //frmPreview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                //TODO

                MessageBox.Show(string.Format("Print Error {0}", ex.Message));
                return string.Empty;
            }

            return "p.ok";
        }
    }

    public class JSResult
    {
        public int QuestionnaireID { get; set; }

        public List<JSOptions> Options { get; set; }
    }

    public class JSOptions
    {
        public string key { get; set; }
        public int value { get; set; }
    }

    public class QuestionnaireCover
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public List<QuestionnaireCover> SubCovers { get; set; }

        public QuestionnaireCover()
        {
            if (null == SubCovers)
                SubCovers = new List<QuestionnaireCover>();
        }
    }
}
