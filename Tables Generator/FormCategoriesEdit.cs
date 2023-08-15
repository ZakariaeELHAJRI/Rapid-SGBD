using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class FormCategoriesEdit : Form
    {
        public FormCategoriesEdit()
        {
            InitializeComponent();
        }

        #region FormCategoriesEdit_Load() Fills comboBoxCategories
        private void FormCategoriesEdit_Load(object sender, EventArgs e)
        {
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                cbCategories.Items.Add(X.Name);
            }
            if (StoredData.categoriesContainer.Count != 0)
            {
                cbCategories.SelectedItem = cbCategories.Items[0];
            }
            lbCategoryDetails.ContextMenuStrip = contextMenuStrip1;
        }

        #endregion

        #region cbCategories_SelectedIndexChanged()
        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbCategoryDetails.DataSource = StoredData.DataSource(cbCategories.Text);
            foreach (Categorie X in StoredData.categoriesContainer)
            {
                if (X.Name == cbCategories.Text)
                {
                    pbCategory.Image = X.Picture;
                    lblCount.Text = "("+X.Data.Count+")";
                }
            }
        }
        #endregion

        #region (Buttons) EditPicture

        Bitmap bmp = null;

        #region btnUploadImage
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Fichier Image|*.jpg;*.jpeg;*.png;*.bmp;*.ico*.tif;*.tiff;*.gif;*.eps;*.raw;*.cr2;*.nef;*.orf;*.sr2;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    bmp = new Bitmap(ofd.FileName);
                    pbCategory.Image = bmp;
                    btnUploadImage.Visible = false;
                    btnEditPicture.Visible = true;
                    btnCancelEditPicture.Visible = true;
                    btnEditPicture.Focus();
                }
            }
            catch (Exception ex)
            {
                bmp = null; // just in case
                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Erreur", ex.Message);
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion
            }
        }
        #endregion

        #region btnEditPicture
        private void btnEditPicture_Click(object sender, EventArgs e)
        {
            foreach (var X in StoredData.categoriesContainer)
            {
                if (X.Name == cbCategories.Text)
                {
                    X.Picture = bmp;
                    bmp = null;
                    StoredData.Serialize();
                }
            }
            btnUploadImage.Visible = true;
            btnEditPicture.Visible = false;
            btnCancelEditPicture.Visible = false;
        }
        #endregion

        #region btnCancelEditPicture
        private void btnCancelEditPicture_Click(object sender, EventArgs e)
        {
            bmp = null;
            foreach (var X in StoredData.categoriesContainer)
            {
                if (X.Name == cbCategories.Text) pbCategory.Image = X.Picture;
            }
            btnUploadImage.Visible = true;
            btnEditPicture.Visible = false;
            btnCancelEditPicture.Visible = false;
        }
        #endregion

        #endregion

        #region txtRename
        private void txtRename_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FormMessageBoxYesNo X = new FormMessageBoxYesNo("Confirmation", "Êtes vous sûre de vouloir renommer cette catégorie en : \"" + txtRename.Text + "\"");
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                if (X.DialogResult == DialogResult.Yes)
                {
                    if (StoredData.RenameCategory(cbCategories.Text, txtRename.Text))
                    {
                        StoredData.SortCategories();
                        StoredData.Serialize();
                        txtRename.Text = string.Empty;

                        cbCategories.Items.Clear();
                        foreach (Categorie cat in StoredData.categoriesContainer)
                        {
                            cbCategories.Items.Add(cat.Name);
                        }
                        if (StoredData.categoriesContainer.Count != 0)
                        {
                            cbCategories.SelectedItem = cbCategories.Items[0];
                        }

                        #region MessageBox.Show()
                        FormMessageBoxOK msg = new FormMessageBoxOK("Information", "Catégorie renommée");
                        msg.StartPosition = FormStartPosition.CenterParent;
                        msg.ShowDialog();
                        #endregion
                    }
                    else
                    {
                        #region MessageBox.Show()
                        FormMessageBoxOK msg = new FormMessageBoxOK("Information", "Le nom \""+ txtRename.Text + "\" existe déja dans la liste\nVeuillez choisir un nouveau nom");
                        msg.StartPosition = FormStartPosition.CenterParent;
                        msg.ShowDialog();
                        #endregion
                    }

                }
            }
        }
        #endregion

        #region btnAdd / txtValue
        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (StoredData.AddToCategory(cbCategories.Text, txtValue.Text))
                {
                    lbCategoryDetails.DataSource = null;
                    lbCategoryDetails.DataSource = StoredData.DataSource(cbCategories.Text);
                    lblCount.Text = "(" + StoredData.CategoryCount(cbCategories.Text).ToString() + ")";
                    txtValue.Text = string.Empty;
                    StoredData.Serialize();
                }
                else
                {
                    #region MessageBox.Show()
                    FormMessageBoxOK msg = new FormMessageBoxOK("Erreur", "Objet existant");
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                    #endregion
                }
            }
        }
        #endregion

        #region contextMenuStrip / Delete
        private void supprimerLaSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int compt = 0;
            int selecedItems = lbCategoryDetails.SelectedItems.Count;
            for (int i = 0; i < lbCategoryDetails.SelectedItems.Count; i++)
            {
                if (!StoredData.DeleteFromCategory(cbCategories.Text, lbCategoryDetails.SelectedItems[i].ToString()))
                {
                    compt++;
                    #region FormMessageBox()
                    FormMessageBoxOK msg = new FormMessageBoxOK("Erreur", "Une erreur est survenue lors de la suppression de : \"" + lbCategoryDetails.SelectedItems[i].ToString() + "\"");
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                    #endregion
                }
            }
            
            lbCategoryDetails.DataSource = null;
            lbCategoryDetails.DataSource = StoredData.DataSource(cbCategories.Text);
            lblCount.Text = "(" + StoredData.CategoryCount(cbCategories.Text).ToString() + ")";
            StoredData.Serialize();

            #region FormMessageBox()
            FormMessageBoxOK X = new FormMessageBoxOK("Information", selecedItems - compt + " Objet(s) supprmé");
            X.StartPosition = FormStartPosition.CenterParent;
            X.ShowDialog();
            #endregion
            
        }
        #endregion

        #region btnExcel
        private void btnExcel_Click(object sender, EventArgs e)
        {
            FormExcel X = new FormExcel(cbCategories.Text);
            (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(X);
        }
        #endregion

        #region btnAccess
        private void btnAccess_Click(object sender, EventArgs e)
        {
            FormAccess X = new FormAccess(cbCategories.Text);
            (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(X);
        }
        #endregion

        #region btnSQL
        private void btnSql_Click(object sender, EventArgs e)
        {
            FormSQL X = new FormSQL(cbCategories.Text);
            (Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(X);            
        }
        #endregion

        #region btnTXT
        private void btnTXT_Click(object sender, EventArgs e)
        {

            #region stream reader
            OpenFileDialog O = new OpenFileDialog();
            O.Filter = "Fichier TXT | *.txt";
            if (O.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(O.FileName);
                string Container = sr.ReadLine();
                while (Container != null)
                {
                    if (Container != string.Empty)
                    {
                        StoredData.AddToCategory(cbCategories.Text, Container);
                    }
                    Container = sr.ReadLine();
                }
                sr.Close();
                
                lbCategoryDetails.DataSource = null;
                lbCategoryDetails.DataSource = StoredData.DataSource(cbCategories.Text);
                lblCount.Text = StoredData.CategoryCount(cbCategories.Text).ToString();
                StoredData.Serialize();

                #region MessageBox.Show();
                FormMessageBoxOK X = new FormMessageBoxOK("Information", "Tous les mots (ou phrases) non existante ont été ajouté(e)s");
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion
            }
            #endregion

        }
        #endregion

        #region Cancel Edit comboBox
        private void cbCategories_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
