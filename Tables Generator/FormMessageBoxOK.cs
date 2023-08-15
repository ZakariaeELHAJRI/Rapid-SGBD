using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class FormMessageBoxOK : Form
    {
        public FormMessageBoxOK(string msg, string text1)
        {
            InitializeComponent();
            lblMsg.Text = msg;
            lblTxt1.Text = text1;
        }
        public FormMessageBoxOK(string msg, string text1,bool closeApp)
        {
            InitializeComponent();
            lblMsg.Text = msg;
            lblTxt1.Text = text1;
            this.closeApp = closeApp;
        }

        bool closeApp = false;

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

        #region btnClose
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (closeApp)
            {
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                this.Close();
            }           
        }
        #endregion

        #region btnOk
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        private void pnlTopMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
