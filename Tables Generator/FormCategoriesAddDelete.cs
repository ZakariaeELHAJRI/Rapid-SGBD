using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class FormCategoriesAddDelete : Form
    {
        public FormCategoriesAddDelete()
        {
            InitializeComponent();
        }

        #region FormCategoriesAddDelete_Load() Fills comboBoxDelete
        private void FormCategoriesAddDelete_Load(object sender, EventArgs e)
        {
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                cbCategories.Items.Add(X.Name);
            }
            if (StoredData.categoriesContainer.Count != 0)
            {
                cbCategories.SelectedItem = cbCategories.Items[0];
            }
        }
        #endregion

        #region Add New Category

        Bitmap bmp = null;

        #region btnAdd
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region case Picture included
            if (bmp != null)
            {
                if (StoredData.AddCategory(txtNewCategoryName.Text, bmp))
                {
                    StoredData.SortCategories();
                    StoredData.Serialize();
                    btnUpload.Text = "Importer une image";
                    btnUpload.BackColor = Color.LightSteelBlue;
                    txtNewCategoryName.Text = string.Empty;
                    bmp = null;
                    pbNewCategoryPicture.Image = Tables_Generator.Properties.Resources.Unavailable;
                    cbCategories.Items.Clear();
                    foreach (Categorie X in StoredData.categoriesContainer)
                    {
                        cbCategories.Items.Add(X.Name);
                    }
                    if (StoredData.categoriesContainer.Count != 0)
                    {
                        cbCategories.SelectedItem = cbCategories.Items[0];
                    }
                    #region MessageBox.Show()
                    FormMessageBoxOK msg = new FormMessageBoxOK("Information", "Ajouté");
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                    #endregion
                }
                else
                {
                    #region MessageBox.Show()
                    FormMessageBoxOK X = new FormMessageBoxOK("Erreur", "Une erreur est survenue lors de l'ajout");
                    X.StartPosition = FormStartPosition.CenterParent;
                    X.ShowDialog();
                    #endregion
                }
            }
            #endregion

            #region case Picture Not included
            else
            {
                if (StoredData.AddCategory(txtNewCategoryName.Text))
                {
                    StoredData.SortCategories();
                    StoredData.Serialize();
                    txtNewCategoryName.Text = string.Empty;
                    cbCategories.Items.Clear();
                    foreach (Categorie X in StoredData.categoriesContainer)
                    {
                        cbCategories.Items.Add(X.Name);
                    }
                    if (StoredData.categoriesContainer.Count != 0)
                    {
                        cbCategories.SelectedItem = cbCategories.Items[0];
                    }

                    #region MessageBox.Show()
                    FormMessageBoxOK msg = new FormMessageBoxOK("Information", "Ajouté");
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                    #endregion
                }
                else
                {
                    #region MessageBox.Show()
                    FormMessageBoxOK X = new FormMessageBoxOK("Erreur", "une erreur est survenue lors de l'ajout");
                    X.StartPosition = FormStartPosition.CenterParent;
                    X.ShowDialog();
                    #endregion
                }
            }
            #endregion
        }
        #endregion

        #region btnUpload
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Fichier Image|*.jpg;*.jpeg;*.png;*.bmp;*.ico*.tif;*.tiff;*.gif;*.eps;*.raw;*.cr2;*.nef;*.orf;*.sr2;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    bmp = new Bitmap(ofd.FileName);
                    pbNewCategoryPicture.Image = bmp;
                    btnUpload.Text = "Choisir une autre image ?";
                    btnUpload.BackColor = Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                bmp = null; // just in case
                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Erreur",ex.Message);
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion
            }
        }
        #endregion

        #endregion

        #region DeleteCategories

        #region btnDelete 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (StoredData.DeleteCategory(cbCategories.SelectedItem.ToString()))
            {
                cbCategories.Items.Remove(cbCategories.SelectedItem);
                if (StoredData.categoriesContainer.Count != 0)
                {
                    cbCategories.SelectedItem = cbCategories.Items[0];
                }
                StoredData.Serialize();
                #region MessageBox.Show()
                FormMessageBoxOK msg = new FormMessageBoxOK("Information", "Supprimé");
                msg.StartPosition = FormStartPosition.CenterParent;
                msg.ShowDialog();
                #endregion
            }
            else
            {
                #region MessageBox.Show()
                FormMessageBoxOK msg = new FormMessageBoxOK("Erreur", "une erreur est survenue lors de la suppression");
                msg.StartPosition = FormStartPosition.CenterParent;
                msg.ShowDialog();
                #endregion
            }
        }
        #endregion

        #region cbCategories_SelectedIndexChanged()
        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var X in StoredData.categoriesContainer)
            {
                if (X.Name == cbCategories.Text) pbCategories.Image = X.Picture;
            }
        }
        #endregion

        #endregion

        #region Cancel Edit comboBox
        private void cbCategories_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
