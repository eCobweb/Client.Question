using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Forms;
using System.Data;

using Microsoft.Office.Interop.Excel;

namespace QuestionClient
{
    public class ExcelHelper
    {
        OleDbConnection OleConn = null;

        ~ExcelHelper()
        {
            //Close();
        }

        public bool Load(string stFilename)
        {
            try
            {
                string stConnString;

                /*
                 * 
                 ---------------------Excel 2007连接字符串总结-------------------
                ACE OLEDB 12.0连接方式
                Xlsx文件
                     这是用来连接带Xlsx扩展名的Excel 2007文件。这是不带宏的Office Open XML格式。 
                以下是语法格式：
                    Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\myFolder\myExcel2007file.xlsx;Extended Properties="Excel 12.0 Xml;HDR=YES"; 
                    "HDR=yes;"是说第一行是列名而不是数据。"HDR=No;"正好与前面的相反。
                把数据当做文本对待
                    使用这条连接当你想把所有的数据都当做文本对待时，覆盖Excel通常的猜测这列的数据类型。 以下是语法格式：
                Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\myFolder\myExcel2007file.xlsx;Extended Properties="Excel 12.0 Xml;HDR=YES;IMEX=1"; 
                    如果你想把列名也读到结果集中(使用“HDR=NO”尽管第一行是列名)并且列中的数据是数值型的，使用“IMEX=1”可必免冲突。
                     使用"IMEX=1"检索混合数据列是一种安全的方法。试想一下，当Driver检索出数据列中有一种数据类型的excel文件可以正常工作，而另一个excel文件(某列)被检测出两种类型，这会造成你的程序的冲突。
                 * 
                 
                                string stExt = Path.GetExtension(stFilename);
                                if (string.Compare(stExt, ".XLSX", true) == 0)
                                {
                                    // XLSX 文件
                                    stConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + stFilename +
                                            ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";";
                                }
                                else
                                {
                                    // XLS 文件
                                    stConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + stFilename +
                                            ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";

                                }
                */

                stConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + stFilename +
                          ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";";

                

                OleConn = new OleDbConnection(stConnString);
                OleConn.Open();
            }
            catch (Exception err) 
            { 
                MessageBox.Show("打开excel文件失败!失败原因：" + err.Message, "提示信息", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                OleConn = null;
                return false; 
            }
            
            return true;
        }

        public System.Data.DataTable QueryTable()
        {
            if (OleConn == null)
                return null;

            try
            {
                Object [] ob = new object[] { null, null, null, "TABLE" };
                System.Data.DataTable schemaTable = OleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, ob);

                int i = ob.Length;

                DataRow[] dr = schemaTable.Select("1=1");

                return schemaTable;
            }
            catch (Exception err)
            {
                MessageBox.Show("解析excel文件页面失败!失败原因：" + err.Message, "提示信息", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return null; 
            }

            return null;
        }

        public string [] QueryPagesInExcelFile()
        {
            if (OleConn == null)
                return null;

            try
            {
                List<string> ls = new List<string>();
                Object[] ob = new object[] { null, null, null, "TABLE" };
                System.Data.DataTable schemaTable = OleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables_Info, ob);

                if (schemaTable.Rows.Count > 0) 
                { 
                    int row = 0; 
                    row = schemaTable.Rows.Count; 
                    int col = schemaTable.Columns.Count; 
                    for (int i = 0; i < row; i++) 
                    {
                        System.Data.DataRow row1 = schemaTable.Rows[i];
                        string str = row1["TABLE_TYPE"].ToString(); 
                        if (str == "TABLE")
                        {
                            string pagename = row1["TABLE_NAME"].ToString();

                            // 对于 类似 'D04-504-C01铯钟$'_xlnm#Print_Area的页面不统计
                            
                            int ind = pagename.IndexOf('$');
                            if (pagename[0] == '\'')
                            {
                                if (ind == pagename.Length -2)
                                    ls.Add(pagename.Substring(1, ind-1));
                            }
                            else
                            {
                                if (ind == pagename.Length -1)
                                    ls.Add(pagename.Substring(0, ind));
                            }
                            

                        }
                    }
                }

                return ls.ToArray();;
            }
            catch (Exception err)
            {
                MessageBox.Show("解析excel文件页面失败!失败原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return null;
        }

        public DataSet QuerySheet(string stSheetname)
        {
            if (OleConn == null)
                return null;

            String sql = "SELECT * FROM [" + stSheetname + "]";

            OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
            DataSet OleDsExcle = new DataSet();
            OleDaExcel.Fill(OleDsExcle, stSheetname);

            return OleDsExcle;
        }

        public bool Save(System.Data.DataTable excelTable, string stFilename) 
        { 
            Microsoft.Office.Interop.Excel.Application app = 
                new Microsoft.Office.Interop.Excel.ApplicationClass(); 
            try 
            { 
                app.Visible = false; 
                Workbook wBook = app.Workbooks.Add(true); 
                Worksheet wSheet = wBook.Worksheets[1] as Worksheet; 
                if (excelTable.Rows.Count > 0) 
                { 
                    int row = 0; 
                    row = excelTable.Rows.Count; 
                    int col = excelTable.Columns.Count; 
                    for (int i = 0; i < row; i++) 
                    { 
                        for (int j = 0; j < col; j++) 
                        { 
                            string str = excelTable.Rows[i][j].ToString(); 
                            wSheet.Cells[i + 2, j + 1] = str; 
                        } 
                    } 
                }

                int size = excelTable.Columns.Count; 
                for (int i = 0; i < size; i++) 
                { 
                    wSheet.Cells[1, 1 + i] = excelTable.Columns[i].ColumnName; 
                } 
                //设置禁止弹出保存和覆盖的询问提示框 
                app.DisplayAlerts = false; 
                app.AlertBeforeOverwriting = false; 
                //保存工作簿 
                wBook.Save(); 
                //保存excel文件 
                app.Save(stFilename);
                app.SaveWorkspace(stFilename); 
                app.Quit(); 
                app = null; 
                return true; 
            } 
            catch (Exception err) 
            { 
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return false; 
            } 
            finally 
            { 
            } 
        }

        public void Close()
        {
            if (OleConn != null)
            {
                OleConn.Close();
            }
            OleConn = null;
        }

    }
}
