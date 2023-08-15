using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Tables_Generator
{
    public partial class tableDetail : UserControl
    {
        public tableDetail(int Index, bool import)
        {
            InitializeComponent();

            index = Index;
            Imported = import;
        }
        public tableDetail(DataSet ds, int Index, bool import, SqlConnectionStringBuilder cs)
        {
            InitializeComponent();
            source = ds;
            index = Index;
            Imported = import;
            Cs = cs;

        }

        public SqlConnectionStringBuilder Cs { get; set; }
        public bool Imported { get; set; }
        public DataSet source { get; set; }

        public int index { get; set; }



        private void tableDetail_Load(object sender, EventArgs e)
        {
            textBox1.Visible = button1.Visible = !Imported;
            if (Imported)
            {
                dataGridView1.DataSource = source.Tables[index];

            }
            else
                dataGridView1.DataSource = AllTables.TablesDs.Tables[index];

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int x;
                if (int.TryParse(textBox1.Text, out x))
                {
                    if (x > 0)
                    {
                    AllTables.cleanrows(index);
                    AllTables.FillDataSetTable(index, x);

                    }
                    else
                    {
                        FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "please enter a valid number > 0");
                        mb.ShowDialog();
                        textBox1.Text = "";
                    }
                }
                else
                {
                     FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "please enter a valid number");
                    mb.ShowDialog();
                    textBox1.Text = "";
                }




            }
            catch (Exception m)
            {

                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();
                (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(true);

            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

            
            if (Imported)
            {
                export sx = new export(source.Tables[index], Cs, index);
                this.Hide();
                sx.ShowDialog();
                this.Show();
            }
            else
            {
                if (AllTables.TablesDs.Tables[index].Rows.Count == 0)
                {
                    FormMessageBoxYesNo yn = new FormMessageBoxYesNo("alert", "Table is empty ! you still wanna export it ?");
                    if (yn.ShowDialog() == DialogResult.No)
                    {
                        return;
                    }
                }
               

                    export sx = new export(AllTables.TablesDs.Tables[index], false, index);
                    this.Hide();
                    sx.ShowDialog();
                    this.Show();
               

            }
            }
            catch (Exception m)
            {

                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
