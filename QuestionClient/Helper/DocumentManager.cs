using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuestionClient
{
    /// <summary>
    /// Test for PDF function with wkhtmltopdf SDK
    /// </summary>
    public class DocumentManager
    {
        private static readonly object GlobalObj = new object();
        private string _pdfProgram;
        private string _gsProgram;

        public bool CanRead { get; private set; }

        public string PDFFileFullName { get; private set; }

        public DataSet Documents { get; set; }

        public DocumentManager()
        {
            CanRead = false;
            var wrappKey = OSHelper.OS_IsXpOr2003Below ? OSHelper.WapperStartKeyxp : (OSHelper.OS_Is32XpHigher ? OSHelper.WapperStartKey32 : OSHelper.WapperStartKey64);
            LoadWkHtmltoPdfLib(wrappKey);
            //LoadWkHtmltoPdfLib(OSHelper.WapperStartKey4gs); //for Ghostscript
        }

        public Task<bool> HTMLtoPDFAsync(PdfDocument doc,string action)
        {
            return Task.Run(() => HtmlToPdf(doc, action));
        }

        private bool HtmlToPdf(PdfDocument document, string action)
        {
            try
            {
                //verify inputs

                if (string.IsNullOrEmpty(document.HtmlUrl) || !System.IO.File.Exists(document.HtmlUrl))
                {
                    throw new Exception("no document");
                }

                PDFFileFullName = document.PdfSavePath;

                //if (!Directory.Exists(_outputPath))
                //    Directory.CreateDirectory(_outputPath);

                var paramsBuilder = new StringBuilder();
                //paramsBuilder.Append("--orientation Landscape ");                

                paramsBuilder.Append("--page-size Letter ");

                paramsBuilder.Append(" --margin-top 15mm --margin-left 15mm --margin-right 15mm --margin-bottom 15mm ");

                paramsBuilder.Append(" --custom-header meta charset=utf-8 ");

                if (action != "B" && action != "W")
                    paramsBuilder.Append("--footer-center \"[page] of [topage]\" ");
                else
                {
                    var date = DateTime.Now.ToString("MM/dd/yyyy");
                    var time = DateTime.Now.ToString("HH:mm");
                    var lastPrinted = date + " at " + time;
                    document.FooterString = string.Format("Printed on {0} by {1}", lastPrinted, document.Printer);

                    paramsBuilder.AppendFormat("--footer-right \"{0}\" ", document.FooterString);
                    //paramsBuilder.Append("--footer-right \"[page] of [topage]\" ");
                }              

                // paramsBuilder.Append("--print-media-type ");
                //paramsBuilder.Append("--redirect-delay 0 "); not available in latest version
                if (!string.IsNullOrEmpty(document.CoverUrl))
                {
                    paramsBuilder.AppendFormat("cover {0} ", document.CoverUrl);
                }
                

                paramsBuilder.AppendFormat("{0} {1}",  document.HtmlUrl, PDFFileFullName);
                //paramsBuilder.AppendFormat("toc {0} {1}", document.HtmlUrl, outputFilename);
               


                var startInfo = new ProcessStartInfo
                {
                    FileName = _pdfProgram,
                    Arguments = paramsBuilder.ToString(),
                    UseShellExecute = false
                };

                using (var p = new Process())
                {
                    p.StartInfo = startInfo;

                    p.EnableRaisingEvents = true;                    

                    p.Start();
                    // ...then wait n milliseconds for exit (as after exit, it can't read the output)
                    // in fact, it will may more longer than 60s
                    p.WaitForExit();

                    /* move the return code outside of exit eventhandler,bcz sometimes it can't be readed */
                    var returnCode = p.ExitCode;

                    CanRead = (returnCode == 0) || (returnCode == 2);                   

                    return CanRead;
                }

            }
            catch (Exception ex)
            { 
                CanRead = false;
                //return CanRead;

                //we want to save the exception to DB, so
                //only way is throw exception
                throw ex;
            }
        }       

        private void setAttributesNormal(DirectoryInfo dir)
        {
            foreach (var subDir in dir.GetDirectories())
                setAttributesNormal(subDir);
            foreach (var file in dir.GetFiles())
            {
                file.Attributes = FileAttributes.Normal;
            }
        }

        /// <summary>
        /// Load wkhtmltopdf command line program
        /// note: 
        /// We can copy the latest wkhtmltopdf.exe 
        /// to the Bin folder
        /// ---------------------------
        /// modified by Peter 10/26/16
        /// we also want to load Ghostscript lib , merge them together!
        /// </summary>
        private void LoadWkHtmltoPdfLib(string wrapperStartKey = OSHelper.WapperStartKey)
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            var binPath = System.IO.Path.Combine(OSHelper.ToolDefaultDirectory ,"");
            var executingAssembly = Assembly.LoadFrom(appPath + OSHelper.PdfEngineWrapper);

            var manifestResourceNames = executingAssembly.GetManifestResourceNames();

            foreach (var name in manifestResourceNames)
            {
                if (!name.StartsWith(wrapperStartKey)) continue;
                var path = Path.Combine(binPath, Path.GetFileNameWithoutExtension(name));

                if (OSHelper.WapperStartKey4gs == wrapperStartKey && name.Contains(".exe"))
                {
                    _gsProgram = path;
                }
                else 
                { 
                    _pdfProgram = path;
                }

                lock (GlobalObj)
                {
                    if (File.Exists(path))
                    {
                        SetFullControlRights(path, OSHelper.MsmqUser);

                        if (File.GetLastWriteTime(path) > File.GetLastWriteTime(executingAssembly.Location))
                            continue;
                    }

                    if (!Directory.Exists(binPath))
                        Directory.CreateDirectory(binPath);
                    var stream = executingAssembly.GetManifestResourceStream(name);

                    if (stream != null)
                        using (var resource1 = new GZipStream(stream, CompressionMode.Decompress, false))
                        {
                            using (var resource0 = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                var local9 = new byte[65536];
                                int local10;
                                while ((local10 = resource1.Read(local9, 0, local9.Length)) > 0)
                                    resource0.Write(local9, 0, local10);
                            }
                        }

                    SetFullControlRights(path, OSHelper.MsmqUser);
                }
            }
        }

        private static void SetFullControlRights(string fileName, string account)
        {
            if (!FileCompress.IsFileUserSecurity(fileName, account, FileSystemRights.FullControl))
            {
                // Add the FullControl rights to the file.
                FileCompress.AddFileUserSecurity(fileName, account, FileSystemRights.FullControl, AccessControlType.Allow);
            }
        }       
    }
}
