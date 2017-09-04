using System;
using System.Collections.Specialized;

namespace QuestionClient
{
    public class OSHelper
    {
        public const string MsmqUser = @"nt authority\network service";      
        
        public const string DocumentDefaultDirectory = @"c:\mistdata\temp";
        public const string DataDefaultDirectory = @"c:\mistdata\data";
        public const string ToolDefaultDirectory = @"c:\mistdata\bin";


        //print variable config
        public const string PdfEngineWrapper = @"eCC.Tool.dll";
        public const string WapperStartKey = @"eCC.Tool.PrintEngine.HtmlToPdf.wkhtmltopdf.";
        public const string WapperStartKey64 = @"eCC.Tool.PrintEngine.HtmlToPdf.wkhtmltopdf.64.";
        public const string WapperStartKey32 = @"eCC.Tool.PrintEngine.HtmlToPdf.wkhtmltopdf.32.";
        public const string WapperStartKeyxp = @"eCC.Tool.PrintEngine.HtmlToPdf.wkhtmltopdf.xp.";


        public const string WapperStartKey4gs = @"eCC.Tool.PrintEngine.Ghostscript.gswin64c.";

        public const string ResultTemplatePage = @"HtmlPages\views\result-template.html";
        public const string PreviewTemplatePage = @"HtmlPages\views\preview-template.html";
        public const string ReportDictory = @"report\";



        public static bool OS_IsXpOr2003Below { get {
                var version = System.Environment.OSVersion;
                return version.Version.Major <= 5;
            } }

        public static bool OS_Is32XpHigher
        {
            get
            {
                var version = System.Environment.OSVersion;
                bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));

                return version.Version.Major > 5 && !is64bit;
            }
        }

        public static bool OS_Is64XpHigher
        {
            get
            {
                var version = System.Environment.OSVersion;
                bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));

                return version.Version.Major > 5 && is64bit;
            }
        }

        public static void VCVersionPatch()
        {
            try {
                //administator permission requires
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;

                var patchDir = System.IO.Path.Combine(baseDir, @"libs\VCPatch");

                var targetDir = @"C:\Windows\System32";

                foreach (var file in System.IO.Directory.GetFiles(patchDir))
                {
                    var targetFile = System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(file));

                    if (System.IO.Directory.Exists(targetDir) && !System.IO.File.Exists(targetFile))

                        System.IO.File.Copy(file, targetFile);
                }
            }
            catch (Exception ex)
            {
                //todoo
            }

        }

    }
}