using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using System;

using System.Data;
using System.Data.SqlClient;

using System.Text;

using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class extratable : Form
    {

        public DataSet dsImport;
        string server;
        public SqlConnectionStringBuilder CS { get; set; }
        public extratable()
        {
            //cas normal
            InitializeComponent();


        }
        public extratable(SqlConnectionStringBuilder cs, DataSet dd)
        {
            //fl cas dyal import
            InitializeComponent();
            CS = cs;
            server = cs.DataSource;
            dsImport = dd;

        }

        private void extratable_Load(object sender, EventArgs e)
        {
            try
            {
                if (dsImport != null)
                {
                    for (int i = 0; i < dsImport.Tables.Count; i++)
                    {
                        tableDetail td = new tableDetail(dsImport, i, true, CS);

                        TabPage x = new TabPage(dsImport.Tables[i].TableName);
                        x.Controls.Add(td);
                        tabControl1.TabPages.Add(x);
                    }

                }
                else
                {
                    AllTables.TablesDs = new DataSet();
                    label1.Text = AllTables.dbname;
                    try
                    {
                        AllTables.ConvertToDataSet();
                        for (int i = 0; i < AllTables.TablesDs.Tables.Count; i++)
                        {


                            tableDetail td = new tableDetail(i, false);
                            TabPage x = new TabPage(AllTables.TablesDs.Tables[i].TableName);
                            x.Controls.Add(td);
                            tabControl1.TabPages.Add(x);
                        }

                    }
                    catch (Exception m)
                    {

                        FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                        mb.ShowDialog();


                    }

                }

            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }


        }



        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
  if (dsImport != null)
                (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(false);
            else
                (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(true);
            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                // -----> imprort db
                if (dsImport != null)
                {

                    var myServer = new Server(server);
                    var database = myServer.Databases[dsImport.DataSetName];
                    if (database == null)
                    {
                        FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "La base de donnees n'est pas valid");
                        mb.ShowDialog();
                        return;
                    }

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

                    sb.AppendLine("USE master \n go");
                    sb.AppendLine($"DROP DATABASE IF EXISTS {dsImport.DataSetName}");
                    sb.AppendLine($" CREATE DATABASE {dsImport.DataSetName} \n go ");
                    sb.AppendLine($"Use  {dsImport.DataSetName} \n go ");

                    foreach (Table tb in database.Tables)
                    {
                        if (tb.IsSystemObject == false)
                        {

                            foreach (string s in createScrp.EnumScript(new Urn[] { tb.Urn }))
                            {
                                sb.AppendLine(s);
                            }

                            foreach (string s in constratintScrp.EnumScript(new Urn[] { tb.Urn }))
                            {
                                sbConstraints.AppendLine(s);
                            }

                            foreach (string s in dataScrp.EnumScript(new Urn[] { tb.Urn }))
                            {
                                sbData.AppendLine(s);
                            }
                            //MessageBox.Show(sb.ToString());

                            sb.AppendLine("");
                            sbConstraints.AppendLine("");
                            sbData.AppendLine("");
                        }
                    }

                    sb.AppendLine(sbData.ToString());
                    sb.AppendLine(sbConstraints.ToString());


                    EXPORTDB x = new EXPORTDB(sb.ToString(), dsImport.DataSetName);
                    x.Show();
                }
                // -----> generate db
                else
                {
                    if (!AllTables.dbFull)
                    {
                        FormMessageBoxYesNo yn = new FormMessageBoxYesNo("alert", "certaines tables sont vide !vous voullez toujours le script ?");
                        if (yn.ShowDialog() == DialogResult.No)
                        {
                            return;
                        }
                    }

                    StringBuilder all = new StringBuilder();
                    all.AppendLine(AllTables.generateCreatedb());
                    foreach (var table in AllTables.Tables)
                    {
                        foreach (var item in table.insert)
                        {
                            all.AppendLine(item);

                        }
                    }
                    all.AppendLine(AllTables.generateconstraint());

                    EXPORTDB ex = new EXPORTDB(all.ToString(), AllTables.dbname);
                    this.Hide();
                    ex.ShowDialog();
                    this.Show();

                }
            }
            catch (Exception m)
            {

                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();
                (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(true);

            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
