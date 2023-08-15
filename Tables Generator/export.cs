using Microsoft.Office.Interop.Excel;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class export : Form
    {
        public export(System.Data.DataTable dt, SqlConnectionStringBuilder cn, int index)
        {
            InitializeComponent();
            table = dt;
            Cn = cn;
            this.index = index;

        }
        
        public export(System.Data.DataTable dt, bool imported, int index)
        {
            InitializeComponent();
            table = dt;
            Imported = imported;
            this.index = index;
        }
        public bool Imported { get; set; }
        public int index { get; set; }
        public System.Data.DataTable table { get; set; }
        public SqlConnectionStringBuilder Cn { get; set; }

        private void export_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = table.TableName;
            sf.DefaultExt = "xml";
            sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (sf.ShowDialog() == DialogResult.OK)
            {
                table.WriteXml(sf.FileName);
            if (MessageBox.Show("finished") == DialogResult.OK) this.Close();
            }

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = table.TableName;
            sf.DefaultExt = "csv";
            sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (sf.ShowDialog() == DialogResult.OK)
            {
                csv(table, sf.FileName);
            if (MessageBox.Show("finished") == DialogResult.OK) this.Close();
            }


        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = table.TableName;
            sf.DefaultExt = "html";
            sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.WriteLine(ConvertDataTableToHTML(table));
                sw.Close();

            if (MessageBox.Show("finished") == DialogResult.OK) this.Close();
            }


        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = table.TableName;
            sf.DefaultExt = "json";
            sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.WriteLine(DataTableToJSONWithStringBuilder(table));
                sw.Close();

            if (MessageBox.Show("finished") == DialogResult.OK) this.Close();
            }


        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (Imported==false)
            {

                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = table.TableName;
                sf.DefaultExt = "sql";
                sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                StringBuilder sb = new StringBuilder();
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sf.FileName))
                    {
                        sb.AppendLine(AllTables.generateCreateTable(index));

                        foreach (var item in AllTables.Tables[index].insert)
                        {
                            sb.AppendLine(item);

                        }

                        sb.AppendLine(AllTables.generateconstraintTable( index));
                        sw.WriteLine(sb.ToString());
                    }

                if (MessageBox.Show("finished") == DialogResult.OK) this.Close();
                }

            }
            else
            {
                var myServer = new Server(Cn.DataSource);
                var table = myServer.Databases[Cn.InitialCatalog].Tables[index];


                StringBuilder sb = new StringBuilder();
                StringBuilder sbConstraints = new StringBuilder();
                StringBuilder sbData = new StringBuilder();



                Scripter createScrp = new Scripter(myServer);
                createScrp.Options.ScriptSchema = true;
                createScrp.Options.NoCommandTerminator = false;
                createScrp.Options.ScriptBatchTerminator = true;
                createScrp.Options.DriPrimaryKey = true;
                createScrp.Options.IncludeIfNotExists = true;

                Scripter constratintScrp = new Scripter(myServer);
                constratintScrp.Options.Default = false;
                constratintScrp.Options.DriUniqueKeys = true;
                constratintScrp.Options.DriForeignKeys = true;
                constratintScrp.Options.DriPrimaryKey = false;

                Scripter dataScrp = new Scripter(myServer);
                dataScrp.Options.ScriptData = true;
                dataScrp.Options.ScriptSchema = false;





                foreach (string s in createScrp.EnumScript(new Urn[] { table.Urn }))
                {
                    sb.AppendLine(s);
                }

                foreach (string s in constratintScrp.EnumScript(new Urn[] { table.Urn }))
                {
                    sbConstraints.AppendLine(s);
                }

                foreach (string s in dataScrp.EnumScript(new Urn[] { table.Urn }))
                {
                    sbData.AppendLine(s);
                }




                sb.AppendLine(sbData.ToString());
                sb.AppendLine(sbConstraints.ToString());


                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                save.FileName = Cn.InitialCatalog + " Script";
                save.DefaultExt = "sql";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(save.FileName))
                    {
                        sw.WriteLine(sb.ToString());
                    }
                if (MessageBox.Show("finished") == DialogResult.OK) this.Close();
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application DocExport = new Microsoft.Office.Interop.Excel.Application();
            Workbook wbExport = null;
            Worksheet wsExport = null;
            SaveFileDialog X = new SaveFileDialog();
            X.FileName = table.TableName;
            X.DefaultExt ="xlsx";
            X.Filter = "Fichier Excel | *.xlsx; *.xls;*.xlsm;*.xlsb;*.xltx;";
            if (X.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    wbExport = DocExport.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                   
                        wsExport = DocExport.Sheets.Add();
                      
                        wsExport.Name = table.TableName;
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            wsExport.Cells[2, i + 2].Value = table.Columns[i].ColumnName;
                            wsExport.Cells[2, i + 2].Interior.Color = Color.LightCoral;
                            wsExport.Cells[2, i + 2].Borders.LineStyle = XlLineStyle.xlContinuous;
                            wsExport.Cells[2, i + 2].Borders.Weight = 3d;
                        }
                        wsExport.Rows[2].Font.Size = 22;
                        wsExport.Rows[2].Font.Italic = true;
                        wsExport.Rows[2].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            for (int j = 0; j < table.Columns.Count; j++)
                            {
                                wsExport.Cells[i + 3, j + 2].Value = table.Rows[i][j];
                                wsExport.Cells[i + 3, j + 2].Interior.Color = Color.Bisque;
                                wsExport.Cells[i + 3, j + 2].Borders.LineStyle = XlLineStyle.xlDashDot;
                                wsExport.Cells[i + 3, j + 2].Borders.Weight = 1d;
                            }
                        }
                    
                    wbExport.SaveAs(X.FileName);
                    wbExport.Close();
                }
                catch (Exception m)
                {



                    FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                    mb.ShowDialog();



                }
                finally
                {
                    if (wsExport != null)
                    {
                        Marshal.ReleaseComObject(wsExport);
                    }
                    if (wbExport != null)
                    {
                        Marshal.ReleaseComObject(wbExport);
                    }
                    DocExport.Quit();
                    Marshal.ReleaseComObject(DocExport);
                }
            }
        }

        
        public string DataTableToJSONWithStringBuilder(System.Data.DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.AppendLine("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.AppendLine("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.AppendLine("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.AppendLine("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.AppendLine("}");
                    }
                    else
                    {
                        JSONString.AppendLine("},");
                    }
                }
                JSONString.AppendLine("]");
            }
            return JSONString.ToString();
        }

        public void csv(System.Data.DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        public static string ConvertDataTableToHTML(System.Data.DataTable dt)
        {
            string html = "<table style=\"border: 1px solid black;\">";
            //add header row
            html += "<tr style=\"border: 1px solid black;\">";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td style=\"border: 1px solid black;\">" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td style=\"border: 1px solid black;\">" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }
    }
}
