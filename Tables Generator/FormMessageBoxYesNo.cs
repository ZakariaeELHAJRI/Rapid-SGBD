using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tables_Generator
{
    public partial class FormMessageBoxYesNo : Form
    {
        public FormMessageBoxYesNo(string msg, string text1)
        {
            InitializeComponent();
            lblMsg.Text = msg;
            lblTxt1.Text = text1;
        }

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
            this.Close();
        }
        #endregion

        #region btnYes
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
        #endregion

        #region btnNo
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
        #endregion

    }
}
