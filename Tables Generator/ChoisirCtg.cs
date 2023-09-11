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
    public partial class ChoisirCtg : Form
    {
        public ChoisirCtg(int tblIndex, int clmnIndex)
        {
            InitializeComponent();
            ColumnIndex = clmnIndex;
            TableIndex = tblIndex;
        }
        public int ColumnIndex { get; set; }
        public int TableIndex { get; set; }

        private void ChoisirCtg_Load(object sender, EventArgs e)
        {

            foreach (Categorie X in StoredData.categoriesContainer)
            {
                comboBox1.Items.Add(X.Name);
            }
            if (StoredData.categoriesContainer.Count != 0)
            {
                comboBox1.SelectedItem = comboBox1.Items[0];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var X in StoredData.categoriesContainer)
            {
                if (X.Name == comboBox1.Text) pictureBox1.Image = X.Picture;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllTables.Tables[TableIndex].extra[ColumnIndex].ChoixCategorie = StoredData.categoriesContainer[comboBox1.SelectedIndex].Data;
            this.DialogResult = DialogResult.OK;
        }
    }
}
