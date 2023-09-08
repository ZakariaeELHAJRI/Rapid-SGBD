using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var input = Interaction.InputBox("Enter your Connection String :", "Connection String", "");
            var ds = new DataSet();
            try
            {

                SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder(input);

                if (cs.InitialCatalog == string.Empty || cs.ConnectionString == string.Empty || cs.DataSource == string.Empty)
                {
                    FormMessageBoxOK m = new FormMessageBoxOK("Alert", "ConnectionString Invalide");
                    m.ShowDialog();
                    return;

                }

                else
                {
                    SqlConnection cn = new SqlConnection(cs.ConnectionString);
                    SqlCommand cmd = new SqlCommand($"SELECT TABLE_NAME FROM {cs.InitialCatalog}.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", cn);
                    List<string> tableNames = new List<string>();
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tableNames.Add(dr[0].ToString());

                        }
                    }
                    ds.DataSetName = cs.InitialCatalog;
                    DataTable dt;
                    foreach (var item in tableNames)
                    {
                        cmd.CommandText = "select * from " + item;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(dr);
                            dt.TableName = item;
                            ds.Tables.Add(dt);
                        }

                    }
                    cn.Close();

                    extratable x = new extratable(cs, ds);
                    (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(x);

                }
            }
   
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(m);


        }

        private void start_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill; 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
