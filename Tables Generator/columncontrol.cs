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
    public partial class columncontrol : UserControl
    {

        public columncontrol()
        {
            InitializeComponent();
        }
        public columncontrol(int tblIndex, int clmnIndex)
        {
            InitializeComponent();
            ColumnIndex = clmnIndex;
            TableIndex = tblIndex;
        }
        public int ColumnIndex { get; set; }
        public int TableIndex { get; set; }



        private void columncontrol_Load(object sender, EventArgs e)
        {



        }

        private void primaryCheck_CheckedChanged(object sender, EventArgs e)
        {

            if (primaryCheck.Checked)
                check(!primaryCheck.Checked, NullCheck, DefaultCheck, checCheck, UniqueCheck);
            enable(!primaryCheck.Checked, NullCheck, DefaultCheck, checCheck, UniqueCheck);
            enable(false, IdentityCheck);

            if (comboBox1.SelectedIndex == 0)//int
            {
                enable(primaryCheck.Checked, IdentityCheck);

                check(primaryCheck.Checked, IdentityCheck);
            }

            refresh();

        }

        private void NullCheck_CheckedChanged(object sender, EventArgs e)
        {
            enable(!NullCheck.Checked, checCheck, primaryCheck, DefaultCheck, UniqueCheck);

            if (NullCheck.Checked)
            {
                enable(!NullCheck.Checked, checCheck, primaryCheck, DefaultCheck, UniqueCheck);
                check(false, primaryCheck, DefaultCheck, UniqueCheck, checCheck);

            }
            if (!NullCheck.Checked && comboBox1.SelectedIndex == 2)
            {
                enable(false, checCheck, primaryCheck, DefaultCheck, IdentityCheck, UniqueCheck);
                check(false, checCheck, primaryCheck, DefaultCheck, IdentityCheck, UniqueCheck);
            }
            refresh();

        }



        private void IdentityCheck_CheckedChanged(object sender, EventArgs e)
        {

            visible(IdentityCheck.Checked, numericUpDown1, numericUpDown2, label6, label7);
            refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clearAll();

                initialState();
                if (comboBox1.SelectedIndex == 0) //int
                {
                    //ila 7tagit chi haja l int
                }
                else if (comboBox1.SelectedIndex == 1) //string
                {
                    //Limit option of string
                    comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "In" });
                    // chooseCtg
                    visible(true, button1);
                }
                else if (comboBox1.SelectedIndex == 2) //bool
                {
                    enable(false, checCheck, primaryCheck, DefaultCheck, UniqueCheck);
                    check(false, checCheck, primaryCheck, DefaultCheck, UniqueCheck);

                }
                else if (comboBox1.SelectedIndex == 3) //double
                {
                    visible(true, decimalupdown, doubllbl);
                }
                else if (comboBox1.SelectedIndex == 4) //date
                {
                    visible(true, dateTimePicker1, dateTimePicker2, ddebut, ddfin);
                    dateTimePicker1.Value = DateTime.Now.AddYears(-10);
                    comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "Column" });


                }
                else if (comboBox1.SelectedIndex == 5) //char
                {
                    comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "In" });
                    charcombo.SelectedIndex = 0;
                    visible(true, charlbl, charcombo);
                }
                else if (comboBox1.SelectedIndex == 6) //time
                {
                    enable(false, DefaultCheck, checCheck);
                }
                else  //foreign key
                {
                    visible(true, tblcombo, tblnamelbl, colcombo, colnamlbl);

                    if (AllTables.Tables.Count == 1 || AllTables.getTablesNames(TableIndex).Count == 0)
                    {
                        MessageBox.Show("there is no previous table with primary key to reference ");
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        enable(false, NullCheck, DefaultCheck, UniqueCheck, checCheck);

                        visible(true, colcombo, colnamlbl, tblcombo, tblnamelbl);
                        tblcombo.DataSource = AllTables.getTablesNames(TableIndex);

                    }
                }
                refresh();

            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }



        }

        private void UniqueCheck_CheckedChanged(object sender, EventArgs e)
        {
            enable(!UniqueCheck.Checked, primaryCheck, IdentityCheck, NullCheck, DefaultCheck, checCheck);
            if (UniqueCheck.Checked)
                check(!UniqueCheck.Checked, primaryCheck, IdentityCheck, NullCheck, DefaultCheck, checCheck);

            refresh();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox4.Visible = true;

                visible(comboBox2.Text == "Between", label5, textBox5);
                visible(comboBox2.Text == "In", label4);
                visible(comboBox2.Text == "Column", comboBox3, comboBox4);


                if (comboBox2.Text == "Column")
                {
                    textBox4.Visible = false;

                    if (AllTables.Tables[TableIndex].getStColumns(ColumnIndex).Count == 0)
                    {

                        FormMessageBoxOK mb = new FormMessageBoxOK("Alert", "il n'ya pas de colonne precedente avec le meme type de donnees");
                        mb.ShowDialog();
                        check(false, checCheck);

                    }
                    else
                    {
                        comboBox3.DataSource = AllTables.Tables[TableIndex].getStColumns(ColumnIndex);
                        comboBox4.Items.Clear(); comboBox4.Items.AddRange(new object[] { "<", ">", ">=", "<=" });
                        comboBox4.SelectedIndex = 0;

                    }
                }

                refresh();

            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }
           
        }

        private void checCheck_CheckedChanged(object sender, EventArgs e)
        {
            visible(false, label4, textBox3, textBox4, label5, comboBox3, comboBox4);
            visible(checCheck.Checked, comboBox2, textBox4);
            refresh();

        }

        public void enable(bool b, params Control[] x)
        {
            foreach (var item in x)
            {
                item.Enabled = b;
            }
        }
        public void visible(bool b, params Control[] x)
        {
            foreach (var item in x)
            {
                item.Visible = b;


            }
        }
        public void clearAll()
        {
            try
            {
comboBox2.Items.Clear();
            comboBox3.DataSource = null;
            comboBox4.Items.Clear();
            tblcombo.DataSource = null;
            colcombo.DataSource = null;
            charcombo.SelectedIndex = 0;
            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }

            


        }

        public void initialState()
        {
            try
            { enable(true, primaryCheck, NullCheck, DefaultCheck, UniqueCheck, checCheck);
            check(false, primaryCheck, NullCheck, DefaultCheck, UniqueCheck, checCheck);
            visible(false, button1, charlbl, charcombo, dateTimePicker1, dateTimePicker2, ddebut, ddfin, decimalupdown, doubllbl, tblcombo, tblnamelbl, colcombo, colnamlbl, comboBox3, comboBox4);
            comboBox2.Items.Clear(); comboBox2.Items.AddRange(new object[] { "<", ">", ">=", "<=", "In", "Between", "Column" });

            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }
           
        }
        public void check(bool b, params CheckBox[] x)
        {
            foreach (var item in x)
            {
                item.Checked = b;
            }
        }


        private void tblcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            colcombo.DataSource = null;
            if (tblcombo.DataSource != null)
            {
                colcombo.DataSource = AllTables.Tables.Find(x => x.tableName == tblcombo.SelectedValue.ToString()).getPKNames();


            }
            refresh();
        }


        private void DefaultCheck_CheckedChanged(object sender, EventArgs e)
        {
            visible(DefaultCheck.Checked, textBox3);
            if (comboBox1.SelectedIndex == 4)//Date => dateTime.now()
            {
                visible(!DefaultCheck.Checked, dateTimePicker1, dateTimePicker2, ddebut, ddfin);
                visible(false, textBox3);
            }
            refresh();
        }


        private void refresh()
        {
            //refresh() is necessary to track every little change happen to the column when/after creating the column
            try
            {
                AllTables.Tables[TableIndex].columns[ColumnIndex] = new Column(tbName.Text, comboBox1.Text, UniqueCheck.Checked, primaryCheck.Checked, NullCheck.Checked, DefaultCheck.Checked, IdentityCheck.Checked, checCheck.Checked
                                   , textBox3.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value, comboBox2.Text, textBox4.Text.Split(new char[] { ',', '-', '/' }), textBox5.Text, tblcombo.Text, colcombo.Text, (tblcombo.SelectedIndex != -1 && colcombo.SelectedIndex != -1));
                var choix = AllTables.Tables[TableIndex].extra[ColumnIndex].ChoixCategorie;
                AllTables.Tables[TableIndex].extra[ColumnIndex] = new extraInfo((int)decimalupdown.Value, charcombo.SelectedIndex, dateTimePicker1.Value, dateTimePicker2.Value, choix, comboBox3.Text, comboBox4.Text);

            }
            catch (Exception m)
            {
                FormMessageBoxOK mb = new FormMessageBoxOK("Alert", m.Message);
                mb.ShowDialog();

            }
           
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = new ChoisirCtg(TableIndex, ColumnIndex);
            temp.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void colcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            refresh();
        }

        private void decimalupdown_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void charcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
