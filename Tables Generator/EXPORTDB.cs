using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class EXPORTDB : Form
    {
        public EXPORTDB(string script, string dbname)
        {
            InitializeComponent();
            Script = script;
            Dbname = dbname;
        }
        public string Script { get; set; }
        public string Dbname { get; set; }
        private void EXPORTDB_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sf.DefaultExt = "sql";
            sf.FileName = Dbname + " SCRIPT";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sf.FileName))
                {
                    sw.WriteLine(Script.ToString());
                }
            }
            MessageBox.Show("finished");
            this.Close();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {


                var connstring = Interaction.InputBox("Donnez la Connection String", "Connection String", "");
                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder(connstring);

                if (cs.InitialCatalog == string.Empty || cs.ConnectionString == string.Empty || cs.DataSource == string.Empty)
                {
                     FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "ConnectionString Invalide");
                    mb.ShowDialog();
                    return;

                }
                else
                {

                    SqlConnection conn = new SqlConnection(cs.ConnectionString);
                    Server server = new Server(new ServerConnection(conn));
                    server.ConnectionContext.ExecuteNonQuery(Script);
                    MessageBox.Show("finished");
                    this.Close();

                }
            }
            catch (Exception )
            {

                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "une erreur dans l'execution de script transactSQL");
                mb.ShowDialog();
            }

        }
    }
}
