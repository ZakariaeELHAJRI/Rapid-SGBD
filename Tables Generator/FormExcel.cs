using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Tables_Generator
{
    public partial class FormExcel : Form
    {
        public FormExcel(string previousFormSelectedValue)
        {
            InitializeComponent();
            selectedValue = previousFormSelectedValue;
        }
        string selectedValue;
        string fileName;

        #region FormExcel_Load()
        private void FormExcel_Load(object sender, EventArgs e)
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
            Microsoft.Office.Interop.Excel.Application DocImport = new Microsoft.Office.Interop.Excel.Application();
            Workbook wbImport = null;
            try
            {
                OpenFileDialog X = new OpenFileDialog();
                X.Filter = "Fichier Excel | *.xlsx; *.xls;*.xlsm;*.xlsb;*.xltx;";
                if (X.ShowDialog() == DialogResult.OK)
                {
                    fileName = X.FileName;
                    wbImport = DocImport.Workbooks.Open(fileName);
                    cbSheet.Items.Clear();
                    foreach (Worksheet worksheet in DocImport.Worksheets)
                    {
                        cbSheet.Items.Add(worksheet.Name);
                    }
                    wbImport.Close(true, System.Type.Missing, System.Type.Missing);
                    if (cbSheet.Items.Count != 0) 
                    {
                        cbSheet.SelectedItem = cbSheet.Items[0];
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
            finally
            {
                DocImport.Quit();
                Marshal.ReleaseComObject(wbImport);
                Marshal.ReleaseComObject(DocImport);
            }
        }
        #endregion        

        #region cbSheet_SelectedIndexChanged()
        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application DocImport = new Microsoft.Office.Interop.Excel.Application();
            Workbook wbImport = DocImport.Workbooks.Open(fileName);
            Worksheet wsImport = DocImport.Sheets[cbSheet.SelectedItem];
            try
            {
                Microsoft.Office.Interop.Excel.Range uR = wsImport.UsedRange;
                cbColumn.Items.Clear();
                for (int i = uR.Column; i < (uR.Column + uR.Columns.Count); i++)
                {
                    cbColumn.Items.Add(GetExcelColumnName(i));
                }
                wbImport.Close(true, System.Type.Missing, System.Type.Missing);
                if(cbColumn.Items.Count != 0)
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
            finally
            {
                DocImport.Quit();
                Marshal.ReleaseComObject(wsImport);
                Marshal.ReleaseComObject(wbImport);
                Marshal.ReleaseComObject(DocImport);
            }
        }
        #endregion
        #region btnAddQuery
        private void btnAddQuery_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application DocImport = new Microsoft.Office.Interop.Excel.Application();
            Workbook wbImport = DocImport.Workbooks.Open(fileName);
            Worksheet wsImport = wbImport.Sheets[cbSheet.SelectedItem];
            try
            {
                Microsoft.Office.Interop.Excel.Range uR = wsImport.UsedRange;
                if (uR != null)
                {
                    for (int i = uR.Rows.Row; i < uR.Rows.Row + uR.Rows.Count; i++)
                    {
                        if (wsImport.Cells[i, cbColumn.SelectedItem].Value != null)
                        {
                            StoredData.AddToCategory(cbCategories.SelectedItem.ToString(), wsImport.Cells[i, cbColumn.SelectedItem].Value.ToString());
                        }
                    }
                }
         wbImport.Close(true, System.Type.Missing, System.Type.Missing);

            }
            catch (Exception ex)
            {
                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Erreur", ex.Message);
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion
            }
            finally
            {
                DocImport.Quit();
                Marshal.ReleaseComObject(wsImport);
                Marshal.ReleaseComObject(wbImport);
                Marshal.ReleaseComObject(DocImport);

                StoredData.Serialize();

                #region MessageBox.Show()
                FormMessageBoxOK X = new FormMessageBoxOK("Information", "Tous les objets non existant ont été ajouté a la liste : \"" + cbCategories.SelectedItem + "\"");
                X.StartPosition = FormStartPosition.CenterParent;
                X.ShowDialog();
                #endregion

                FormCategoriesEdit form = new FormCategoriesEdit();
                (System.Windows.Forms.Application.OpenForms["InterfaceForm"] as InterfaceForm).OpenForm(form);
            }
        }
        #endregion

        #region Convert columnIndexToName()
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        }
        #endregion

        #region Cancel Edit comboBox

        private void cbSheet_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cbColumn_KeyDown_1(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void cbCategories_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        #endregion

        #region cbColumn_MouseHover
        ToolTip X = new ToolTip();
        private void cbColumn_MouseHover(object sender, EventArgs e)
        {
            X.ToolTipIcon = ToolTipIcon.Info;
            X.Show("NB : une colonne utilisée ne contient pas obligatoirement des données", cbColumn);            
        }
        #endregion
    
    }
}
