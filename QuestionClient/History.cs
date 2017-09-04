using CCWin;
using QuestionClient.Helper;
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
    public partial class History : CCSkinMain
    {
        Dictionary<int, string> DicPrintQueue = new Dictionary<int, string>();

        List<QuestionWorkflow> qns = new List<QuestionWorkflow>();

        BackgroundWorker bgw = null;

        List<int> printKeys = new List<int>();

        public History()
        {
            InitializeComponent();

            lv_result.FullRowSelect = true;
            ListViewExtender extender = new ListViewExtender(lv_result);
            // extend 2nd column
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(6);
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;

            extender.AddColumn(buttonAction);           
        }

        void bgwoker(object sender, EventArgs arg)
        {
            if (printKeys.Count >= DicPrintQueue.Count) return;

            foreach (KeyValuePair<int, string> kvp in DicPrintQueue)
            {
                if (printKeys.Contains(kvp.Key)) continue;

                printKeys.Add(kvp.Key);

                QuestionWorkflow qwf = qns[kvp.Key];

                var result = qwf.CreateResultPage();

                if (!string.IsNullOrEmpty(result))
                {
                    DicPrintQueue[kvp.Key] = result;

                    try
                    {
                        this.lv_result.Invoke(new Action(()=>{
                            lv_result.Items[kvp.Key].SubItems[6].Text = "预览";
                        }));

                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }

                

            }
        }
        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            var cellName = e.SubItem.Name;

            var cellText = e.SubItem.Text;

            var itemIndex = e.Item.Index;

            if (cellText.Equals("预览") && DicPrintQueue.Keys.Contains(itemIndex))
            {                
                if(!string.IsNullOrEmpty(DicPrintQueue[itemIndex]))
                { 
                    PrintPreview frmPreview = new PrintPreview(DicPrintQueue[itemIndex]);
                    frmPreview.ShowDialog();
                }
            }            

            if (cellText.Equals("正在打印")) return;
            

            if (!DicPrintQueue.Keys.Contains(itemIndex))
            {
                if (!bgw.IsBusy)
                {
                    DicPrintQueue.Add(itemIndex, string.Empty);

                    e.SubItem.Text = "正在打印..";

                    bgw.RunWorkerAsync();

                    return;
                }
                else
                {
                    e.SubItem.Text = "无空闲,请重试";
                }
               
            }

           


        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            var qName = this.tbx_Name.Text;
            var qDate = this.q_date.text;
            var qID = this.tbx_id.Text;

            string dataName = System.IO.Path.Combine(OSHelper.DataDefaultDirectory, "data.xml");

            qns = QuestionHelper.DeSerializeObject<List<QuestionWorkflow>>(dataName);

            if (null == qns) return;

            List<QuestionWorkflow> result = qns.FindAll(o => {
                return o.user.Name.Equals(string.IsNullOrEmpty(qName) ? o.user.Name : qName) &&
                       o.date.ToShortDateString().Equals((null == qDate || string.IsNullOrEmpty(qDate)) ? o.date.ToShortDateString() : qDate) &&
                       o.user.ID.Equals(string.IsNullOrEmpty(qID) ? o.user.ID : qID);
            });

            this.lv_result.Items.Clear();

            foreach (QuestionWorkflow qwf in result)
            {
                ListViewItem lvItem = new ListViewItem(new string[]{ qwf.user.Name,  qwf.user.Age.ToString(),qwf.user.Gender, qwf.user.ID, qwf.result, qwf.date.ToShortDateString(),"打印" });
                this.lv_result.Items.Add(lvItem);
            }
        }

        private void gbox_Enter(object sender, EventArgs e)
        {

        }

        private void History_Load(object sender, EventArgs e)
        {
            bgw = new BackgroundWorker();
            bgw.DoWork += bgwoker;          

            bgw.WorkerSupportsCancellation = true;
            
        }
    }
}
