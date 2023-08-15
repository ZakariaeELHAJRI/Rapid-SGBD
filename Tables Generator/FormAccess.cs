using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class FormAccess : Form
    {
        public FormAccess(string previousFormSelectedValue)
        {
            InitializeComponent();
            selectedValue = previousFormSelectedValue;
        }

        string selectedValue;
        string fileName;     

        #region FormAccess_Load()
        private void FormAccess_Load(object sender, EventArgs e)
        {
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                cbCategories.Items.Add(X.Name);
            }
            if (cbCategories.Items.Count != 0)
            {
                cbCategories.SelectedItem = cbCategories.Items[cbCategories.Items.IndexOf(selectedValue)];
            }
        }
        #endregion

        #region btnTestQuery
        private void btnTestQuery_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog X = new OpenFileDialog();
                X.Filter = "Base de données Microsoft Access (*.accdb)|*.accdb";
                if (X.ShowDialog() == DialogResult.OK)
                {
                    fileName = X.FileName;
                    OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + X.FileName + ";Persist Security Info=False;");
                    cn.Open();
                    //{TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE}
                    object[] array = new object[] { null, null, null, "TABLE" };
                    DataTable dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, array);
                    cbTables.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cbTables.Items.Add(row["TABLE_NAME"]);
                    }
                    cn.Close();
                    if (cbTables.Items.Count != 0)
                    {
                        cbTables.SelectedItem = cbTables.Items[0];
                    }
                }
            }
            catch (Exception ex)
            {
                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Erreur", ex.Message);
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion
            }
        }
        #endregion

        #region cbTables_SelectedIndexChanged()
        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Persist Security Info=False;");
                cn.Open();
                object[] array = new object[] { null, null, cbTables.SelectedItem, null };
                DataTable dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, array);
                cbColumn.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cbColumn.Items.Add(row["COLUMN_NAME"]);
                }
                cn.Close();
                if (cbColumn.Items.Count != 0)
                {
                    cbColumn.SelectedItem = cbColumn.Items[0];
                }
            }
            catch (Exception ex)
            {
                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Erreur", ex.Message);
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion
            }
        }
        #endregion

        #region btnAddQuery
        private void btnAddQuery_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Persist Security Info=False;");
                OleDbCommand cmd = new OleDbCommand("select distinct " + cbColumn.SelectedItem + " from " + cbTables.SelectedItem, cn);
                cn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StoredData.AddToCategory(cbCategories.SelectedItem.ToString(), dr[0].ToString());
                }
                dr.Close();
                cn.Close();
                StoredData.Serialize();

                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Information", "Tous les objets non existant ont été ajouté a la liste : \"" + cbCategories.SelectedItem + "\"");
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion

                FormCategoriesEdit form = new FormCategoriesEdit();
                (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(form);
            }
            catch (Exception ex)
            {
                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Erreur", ex.Message);
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion
            }
        }
        #endregion

        #region Cancel Edit comboBox

        private void cbColumn_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cbTables_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cbCategories_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        #endregion


    }
}
