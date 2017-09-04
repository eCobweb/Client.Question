using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionClient.Settings
{
    public class QuestionWorkflow
    {
        private static QuestionWorkflow _questionWorkflow;

        public User user;

        public Report report;

        public int reportCounter;

        public Questionnaire questionnaire;

        public List<QuestionResponse> responses;

        public DateTime date;

        public string result;

        public string resultCode;

        public string questionSheetDir = "";

        public string printNameFinder;

        string dataName = System.IO.Path.Combine(OSHelper.DataDefaultDirectory, "data.xml");

        string dataReportName = System.IO.Path.Combine(OSHelper.DataDefaultDirectory, "report.xml");


        string questionnaireFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "libs/Questionnaire/questionnaires.xml");

        string assessesFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "libs/Questionnaire/assesses.xml");

        List<Questionnaire> questionnaires;

        List<Assess> assesses;

        private QuestionWorkflow()        {
            

            questionnaire = new Questionnaire();

            questionnaires = QuestionHelper.ReadQuestionnairesFromXML(questionnaireFile);

            assesses = QuestionHelper.ReadAssessFromXML(assessesFile);

            report = new Report();

            if (File.Exists(dataReportName))
            {
                report = QuestionHelper.DeSerializeObject<Report>(dataReportName);
            }
        }

        public static QuestionWorkflow Instance()
        {
            if (null == _questionWorkflow)
            {
                _questionWorkflow = new QuestionWorkflow();
            }

            return _questionWorkflow;
        }

        public Questionnaire Get(int id)
        {
            questionnaire = questionnaires.FirstOrDefault<Questionnaire>(o => { return o.QuestionnaireID == id; });

            return questionnaire;
        }

        public Questionnaire Questionnaire { get { return questionnaire; }  }
        public List<Questionnaire> Questionnaires { get { return questionnaires; } }

        public Tuple<bool, string> SaveWorkflow(string _result, string _result_code)
        {
            Tuple<bool, string> tupSaveResult = null;

            if (null == user)
            {
                tupSaveResult = new Tuple<bool, string>(false,string.Format("{0} (用户信息未填写，保存无效)", _result));

                return tupSaveResult;
            }

            try
            {
                //set ace user
                var ds = new DirectorySecurity();
                var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                var ace = new FileSystemAccessRule(sid,
                                                   FileSystemRights.FullControl,
                                                   AccessControlType.Allow);
                ds.AddAccessRule(ace);

                var dataDir = System.IO.Path.Combine(OSHelper.DataDefaultDirectory, "");

                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir, ds);
                }


                result = _result;

                resultCode = _result_code;

                List<QuestionWorkflow> qns = QuestionHelper.DeSerializeObject<List<QuestionWorkflow>>(dataName);

                date = System.DateTime.Now;

                if (null != qns)
                {
                    qns.Add(this);
                }
                else
                {
                    qns = new List<QuestionWorkflow>();
                    qns.Add(this);
                }

                QuestionHelper.SerializeObject<List<QuestionWorkflow>>(qns, dataName);

                tupSaveResult = new Tuple<bool, string>(true, result);
            }
            catch (Exception ex)
            {
                tupSaveResult = new Tuple<bool, string>(false, string.Format("保存异常 {0}",ex.Message));
            }
            return tupSaveResult;
        }

        public Task<string> CreateResultPageAsync()
        {
            return Task.Run(() =>  CreateResultPage());
        }

        public  string CreateResultPage()
        {
            if (null == user)
                throw new Exception("user info is missing");


            var exeBaseDir = AppDomain.CurrentDomain.BaseDirectory;

            var tempDocDir = OSHelper.DocumentDefaultDirectory;

            var resultTempFullPath = System.IO.Path.Combine(exeBaseDir, OSHelper.ResultTemplatePage);
            var previewTempFullPath = System.IO.Path.Combine(exeBaseDir, OSHelper.PreviewTemplatePage);

            var timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var resultHtmlFileName = string.Format("{0}.html", timestamp);
            var resultPdfFileName = string.Format("{0}.pdf", timestamp);
            var previewFileName = string.Format("{0}_pre.html", timestamp);

            var resultHtmlFullPath = System.IO.Path.Combine(tempDocDir, OSHelper.ReportDictory, resultHtmlFileName);
            var resultPdfFullPath = System.IO.Path.Combine(tempDocDir, OSHelper.ReportDictory, resultPdfFileName);
            var previewFullPath = System.IO.Path.Combine(tempDocDir, OSHelper.ReportDictory, previewFileName);

            var tempDir = System.IO.Path.Combine(exeBaseDir, OSHelper.ReportDictory);

            var tempResultDir = System.IO.Path.Combine(tempDocDir, OSHelper.ReportDictory);

            //set ace user
            var ds = new DirectorySecurity();
            var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            var ace = new FileSystemAccessRule(sid,
                                               FileSystemRights.FullControl,
                                               AccessControlType.Allow);
            ds.AddAccessRule(ace);
            


            if (!Directory.Exists(tempResultDir))
            {
                Directory.CreateDirectory(tempResultDir, ds);
            }

            var fullResult = result;

            if (null != assesses && !string.IsNullOrEmpty(resultCode))
            {
                try
                {
                    AssessResult ar = (assesses.FirstOrDefault(o => o.QuestionnaireID == questionnaire.QuestionnaireID)).Results.FirstOrDefault(f => f.Code.Equals(resultCode));

                    if (null != ar)
                    {
                        fullResult += "<br>" + ar.Text;
                    }
                }
                catch (Exception ex)
                {
                    //todo
                }


            }


            var hasHtmlResult = DotNetToHtm.CreateHtml( resultTempFullPath
                                                        , resultHtmlFullPath
                                                        , new string[] { "$basePath$", "$CenterName$", "$reportPhysician$", "$no$", "$QuestionnaireName$", "$name$", "$gender$", "$age$", "$reportDate$", "$result$" }
                                                        , new string[] { exeBaseDir,report.CenterName, report.PhysicianName,string.Format("{0}{1}{2}{3}",System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day,reportCounter), Questionnaire.Name,user.Name, user.Gender,user.Age.ToString(),System.DateTime.Now.ToShortDateString(), fullResult });


            if (hasHtmlResult)
            {
                PdfDocument pdf = new PdfDocument() { HtmlUrl = resultHtmlFullPath, PdfSavePath = resultPdfFullPath };

                var dm = new DocumentManager();

                try
                {
                    var hasPdfDoc = dm.HTMLtoPDFAsync(pdf, "C").Result;

                    var pdfExisted = System.IO.File.Exists(resultPdfFullPath);

                    if (hasPdfDoc || pdfExisted)
                    {
                        var hasPreviewResult = DotNetToHtm.CreateHtml(previewTempFullPath, previewFullPath, new string[] { "$pdf$" }, new string[] { resultPdfFullPath });

                        if (hasPreviewResult)
                        {
                            printNameFinder = timestamp;

                            return previewFullPath;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("error in pdf generator " + ex);
                }

            }



            return string.Empty;
        }


        public bool SaveReportSetting()
        {
            try
            {
                QuestionHelper.SerializeObject<Report>(report,dataReportName);
            }
            catch (Exception ex)
            {
                //TOOD

                return false;
            }

            return true;
        }
    }
}
