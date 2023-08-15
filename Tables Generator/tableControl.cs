using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class tableControl : UserControl
    {

        public tableControl(int tblIndex)
        {
            InitializeComponent();
            TableIndex = tblIndex;

        }
        public int TableIndex { get; set; }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl2.TabCount == 0)
                {
                    AllTables.Tables[TableIndex].columns.Add(initializeColumn());
                    AllTables.Tables[TableIndex].extra.Add(initializeExtra());

                    var temp = new columncontrol(TableIndex, 0);
                    TabPage inner = new TabPage("new column");
                    inner.Controls.Add(temp);
                    tabControl2.TabPages.Add(inner);


                }
                else
                {

                    var currentColumn = AllTables.Tables[TableIndex].columns[AllTables.Tables[TableIndex].columns.Count - 1];

                    if (currentColumn.Type == string.Empty || currentColumn.Nom == string.Empty)
                    {
                        FormMessageBoxOK mb = new FormMessageBoxOK("Alert", " vous devez declare le nomet le type de la derniere colonne avant d'en ajouter une nouvelle");
                        mb.ShowDialog();
                    }
                    else
                    {
                        tabControl2.TabPages[tabControl2.TabPages.Count - 1].Text = currentColumn.Nom;
                        AllTables.Tables[TableIndex].columns.Add(initializeColumn());
                        AllTables.Tables[TableIndex].extra.Add(initializeExtra());
                        var temp = new columncontrol(TableIndex, AllTables.Tables[TableIndex].columns.Count - 1);
                        TabPage x = new TabPage("new");
                        x.Controls.Add(temp);
                        tabControl2.TabPages.Add(x);
                        tabControl2.SelectedTab = x;


                    }
                }

            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }



        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl2.TabPages.Count > 0)
                {
                    AllTables.Tables[TableIndex].columns.RemoveAt(tabControl2.SelectedIndex);
                    tabControl2.TabPages.Remove(tabControl2.SelectedTab);
                    if (tabControl2.TabPages.Count > 0)

                        tabControl2.SelectedTab = tabControl2.TabPages[tabControl2.TabPages.Count - 1];

                }

            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }

        }

        private void tableControl_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AllTables.Tables[TableIndex].tableName = textBox1.Text;
        }
        private extraInfo initializeExtra()
        {
            return new extraInfo() { ChoixCategorie = new List<string>() };
        }

        private Column initializeColumn()
        {
            return new Column() { Nom = "", Type = "" };
        }


    }
}
