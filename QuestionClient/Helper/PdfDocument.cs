using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Serialization;

namespace QuestionClient
{
   
    public class PdfDocument
    {
        
        //we can put multiple url with space
        public string HtmlUrlRoot { get; set; }

        public string CoverUrl { get; set; }

        public string TocUrl { get; set; }        

        public string HeaderString { get; set; }

        public string FooterString { get; set; }

        public string FooterUrl { get; set; }        

        public string Printer { get; set; }

        public string HtmlUrl { get; set; }

        public string PdfSavePath { get; set; }
        
    }
}