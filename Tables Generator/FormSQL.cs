using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tables_Generator
{
    public partial class FormSQL : Form
    {
        
        public FormSQL(string previousFormSelectedValue)
        {
            InitializeComponent();
            selectedValue = previousFormSelectedValue;
        }

        string selectedValue;
        string connectionString;

        #region FormSQL_Load()
        private void FormSQL_Load(object sender, EventArgs e)
        {
            foreach(Categorie X in StoredData.categoriesContainer)
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

                SqlConnection cn = new SqlConnection(txtConnectionString.Text);
                SqlCommand cmd = new SqlCommand("SELECT name FROM sys.Tables", cn);
                cn.Open();
                cbTables.Items.Clear();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbTables.Items.Add(dr["name"].ToString());
                }
                dr.Close();
                connectionString = txtConnectionString.Text;
                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Erreur", cn.State.ToString());
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion
                cn.Close();

                if (cbTables.Items.Count != 0)
                {
                    cbTables.SelectedItem = cbTables.Items[0];
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
                SqlConnection cn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @a", cn);
                cn.Open();
                cbColumn.Items.Clear();
                cmd.Parameters.AddWithValue("@a", cbTables.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbColumn.Items.Add(dr[0]);
                }
                dr.Close();
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
                SqlConnection cn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select distinct " + cbColumn.SelectedItem + " from " + cbTables.SelectedItem, cn);
                cn.Open();               
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StoredData.AddToCategory(cbCategories.SelectedItem.ToString(), dr[0].ToString());
                }
                dr.Close();
                cn.Close();
                StoredData.Serialize();

                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Information", "Tous les objets non existant ont été ajouté a la liste : \""+cbCategories.SelectedItem +"\"");
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
