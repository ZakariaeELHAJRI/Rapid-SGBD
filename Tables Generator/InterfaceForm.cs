using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient; //Needed here to catch the Exception in FormSQL
using System.IO;
using System.Threading.Tasks;


namespace Tables_Generator
{
    public partial class InterfaceForm : Form
    {
        public InterfaceForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.MinimumSize = new Size(1520, 790);
            //this.MaximumSize= new Size(1521, 79);

            StoredData.FirstTimeUse();
        }

        #region InterfaceForm_Load()
        private void InterfaceForm_Load(object sender, EventArgs e)
        {
            
            start x = new start();
            OpenForm(x);
            #region Deserialize()
            try
            {
                StoredData.Deserialize();
            }
            catch
            {
                #region MessageBox()
                FormMessageBoxOK msg = new FormMessageBoxOK("Erreur", "Une Erreur est survenue lors de l'appel de la sauveguard.");
                msg.StartPosition = FormStartPosition.CenterParent;
                msg.ShowDialog();
                #endregion
            }
            #endregion
            
        }
        #endregion

        #region Borderless_ResizeableForm
        //private const int cGrip = 16;      // Grip size
        //private const int cCaption = 32;   // Caption bar height;

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
        //    ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
        //}

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x84)
        //    {  // Trap WM_NCHITTEST
        //        Point pos = new Point(m.LParam.ToInt32());
        //        pos = this.PointToClient(pos);
        //        if (pos.Y < cCaption)
        //        {
        //            m.Result = (IntPtr)2;  // HTCAPTION
        //            return;
        //        }
        //        if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
        //        {
        //            m.Result = (IntPtr)17; // HTBOTTOMRIGHT
        //            return;
        //        }
        //    }
        //    base.WndProc(ref m);
        //}

        #endregion

        #region DraggableForm
        Point lastPoint;
        private void pnlTopMenu_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void pnlTopMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        #endregion

        #region btnMaximizeForm
        private void pnlTopMenu_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void Form_Interface_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        #endregion

        #region btnCloseForm
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (StoredData.backgroundTaskRunning)
            {
                #region MessageBox()
                FormMessageBoxOK msg = new FormMessageBoxOK("Avertissement", "Une activité en arrière plan est en cours d'execution.\nForcer l'arrêt de l'application en ce moment endommagera votre sauveguarde.\nUn message vous sera fournis quand cette activité sera terminé.");
                msg.StartPosition = FormStartPosition.CenterParent;
                msg.ShowDialog();
                #endregion
            }
            else
            {
                Application.Exit();
            }
        }
        #endregion

        #region btnMinimizeForm
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region OpenForm ()
        public void OpenForm(Form X)
        {
            foreach (Control C in pnlFormContainer.Controls)
            {
                if ((Form)C is Menu) ((Form)C).Hide();
                else
                    ((Form)C).Close();
            }

            X.TopLevel = false;
            X.Dock = DockStyle.Fill;
            X.Parent = pnlFormContainer;
            X.Show();
        }
        public void OpenForm(bool xx)
        {
            foreach (Control C in pnlFormContainer.Controls)
            {
                if ((Form)C is Menu && xx) ((Form)C).Show();


            }
            if(xx==false)
            sQLAssistanceToolStripMenuItem.PerformClick();
           
        }
        #endregion

        #region MenuStrip Item_CLick
       

        #region Add / Delete
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategoriesAddDelete X = new FormCategoriesAddDelete();
            OpenForm(X);
        }
        #endregion

        #region Edit
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategoriesEdit X = new FormCategoriesEdit();
            OpenForm(X);
        }
        #endregion

        #region Reset
        private void renitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateData.AddDefaultCategories();
            GenerateData.FillDefaultCategories();
            GenerateData.NotifyUser();
        }
        #endregion

        #region ExportSave
        private void exporterUneSauveguardToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            SaveFileDialog X = new SaveFileDialog();
            X.FileName = "Tables Generator Save File";
            if (X.ShowDialog() == DialogResult.OK)
            {
                                
                #region Copy ProgressBar
                FileInfo fileCopy = new FileInfo(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Tables Generator\SavedCategories");
                FileInfo filePaste = new FileInfo(X.FileName);

                if (filePaste.Exists) filePaste.Delete();

                progressBar1.Visible = true;
                lblProgressBar.Visible = true;
                StoredData.backgroundTaskRunning = true;

                Task.Run(() =>
                {
                    fileCopy.CopyTo(filePaste, x => progressBar1.BeginInvoke(new System.Action(() => {
                        
                        progressBar1.Value = x;
                        lblProgressBar.Text = x.ToString() + "%";
                    })));
                }).GetAwaiter().OnCompleted(() => progressBar1.BeginInvoke(new System.Action(() =>
                {
                    progressBar1.Value = 100;
                    lblProgressBar.Text = "100%";

                    lblProgressBar.Visible = false;
                    progressBar1.Visible = false;
                    StoredData.backgroundTaskRunning = false;

                    #region MessageBox()
                    FormMessageBoxOK msg = new FormMessageBoxOK("Information","Fichier Exporté");
                    msg.StartPosition = FormStartPosition.CenterParent;
                    msg.ShowDialog();
                    #endregion

                })));
                #endregion
          
            }
        }
        #endregion

        #region ImportSave
        private void importerUneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMessageBoxYesNo msg = new FormMessageBoxYesNo("Rappel", "Aucune vérification de la compatibilité de l'application n'est effectée.Il est conseillé d'exporter une sauveguard avant de continuer.\n\"confirmer\" ecrasera votre sauveguard actuelle");
            msg.StartPosition = FormStartPosition.CenterParent;
            msg.ShowDialog();
            if (msg.DialogResult == DialogResult.Yes)
            {
                SaveFileDialog X = new SaveFileDialog();
                X.FileName = "Tables Generator Save File";
                if (X.ShowDialog() == DialogResult.OK)
                {

                    #region Copy ProgressBar
                    FileInfo fileCopy = new FileInfo(X.FileName);
                    FileInfo filePaste = new FileInfo(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Tables Generator\SavedCategories");

                    if (filePaste.Exists) filePaste.Delete();

                    progressBar1.Visible = true;
                    lblProgressBar.Visible = true;
                    StoredData.backgroundTaskRunning = true;

                    Task.Run(() =>
                    {
                        fileCopy.CopyTo(filePaste, x => progressBar1.BeginInvoke(new System.Action(() => {

                            progressBar1.Value = x;
                            lblProgressBar.Text = x.ToString() + "%";
                        })));
                    }).GetAwaiter().OnCompleted(() => progressBar1.BeginInvoke(new System.Action(() =>
                    {
                        progressBar1.Value = 100;
                        lblProgressBar.Text = "100%";

                        lblProgressBar.Visible = false;
                        progressBar1.Visible = false;
                        StoredData.backgroundTaskRunning = false;

                        #region MessageBox()
                        FormMessageBoxOK msg1 = new FormMessageBoxOK("Information", "Sauveguard Remplacé\nUn redemarrage de l'application est nécessaire.",true);
                        msg1.StartPosition = FormStartPosition.CenterParent;
                        msg1.ShowDialog();
                        if(msg1.DialogResult == DialogResult.OK)
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                        #endregion

                    })));
                    #endregion

                }
            }
        }
        #endregion

        #endregion

        private void pnlTopMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sQLAssistanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start x = new start();
            AllTables.reset();
            OpenForm(x);
        }

       

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            FormMessageBoxOK mb = new FormMessageBoxOK("Info", "Rapid-sgbd is a project created By \n\t Hamza Belaidi , Zakariae Elhajri , Ayoub Abdallaoui \n" +
              "to Mark the final MileStone of our studies at OFPPT Bab Tizimi 2021 \n Made With Love <3");
            mb.ShowDialog();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            FormMessageBoxOK mb = new FormMessageBoxOK("Info", "Rapid-sgbd is a project created By \n\t Hamza Belaidi , Zakariae Elhajri , Ayoub Abdallaoui \n" +
              "to Mark the final MileStone of our studies at OFPPT Bab Tizimi 2021 \n Made With Love <3");
            mb.ShowDialog();
        }
    }
}
