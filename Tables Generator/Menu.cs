using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabCount == 0)
                {
                    //first tab
                    AllTables.Tables.Add(initializeTable());
                    var temp = new tableControl(0);
                    TabPage outer = new TabPage("new table");

                    outer.Controls.Add(temp);
                    tabControl1.TabPages.Add(outer);
                }
                else
                {

                    var tablename = AllTables.Tables[AllTables.Tables.Count - 1].tableName;

                    if (tablename == string.Empty)
                    {
                        FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "vous dever declarer le nom de la table avant d'en ajouter un nouveau");
                        mb.ShowDialog();

                    }
                    else if (AllTables.Tables[AllTables.Tables.Count - 1].columns.Count == 0)
                    {
                        FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "La tale ne contient aucune colonne !!");
                        mb.ShowDialog();


                    }
                    else if (!AllTables.Tables[AllTables.Tables.Count - 1].isValid())
                    {
                        FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "le nom ou le type de colonne est vide");
                        mb.ShowDialog();

                    }
                    else
                    {
                        tabControl1.TabPages[tabControl1.TabPages.Count - 1].Text = tablename;
                        AllTables.Tables.Add(initializeTable());
                        var temp = new tableControl(AllTables.Tables.Count - 1);
                        TabPage outer = new TabPage("new table");

                        outer.Controls.Add(temp);
                        tabControl1.TabPages.Add(outer);
                        tabControl1.SelectedTab = outer;


                    }
                }

            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count > 0)
                {
                    AllTables.Tables.RemoveAt(tabControl1.SelectedIndex);
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);

                    if (tabControl1.TabPages.Count > 0)
                    {

                        tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                        for (int i = tabControl1.SelectedIndex; i < tabControl1.TabPages.Count; i++)
                        {

                            (tabControl1.TabPages[i].Controls[0] as tableControl).TableIndex = i;

                        }

                    }
                }

            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {
                    if (AllTables.Tables.Count == 0)
                    {
                        FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "la base de donnees est vide ! veuillez creer un tableau");
                        mb.ShowDialog();
                        return;
                    }
                    foreach (table item in AllTables.Tables)
                    {

                        if (item.tableName == string.Empty)
                        {
                            FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "le nom du tableau est manquant!");
                            mb.ShowDialog();
                            return;
                        }
                        if (item.columns.Count == 0)
                        {
                            FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "Le tableau ne contient aucune colonne");
                            mb.ShowDialog();
                            return;

                        }
                        if (!item.isValid())
                        {
                            FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "Le nom ou le type de la colonne est vide!");
                            mb.ShowDialog();
                            return;
                        }

                    }
                    AllTables.dbname = textBox1.Text;
                    extratable x = new extratable();
                    (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(x);
                }
                else
                {
                    FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "entrez le nom de la base de donnees");
                    mb.ShowDialog();
                }
            }
            catch (Exception m)
            {

                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            AllTables.Tables = new List<table>();

        }
        private table initializeTable()
        {
            return new table() { columns = new List<Column>(), insert = new List<string>(), extra = new List<extraInfo>(), tableName = "" };
        }
    }
}
