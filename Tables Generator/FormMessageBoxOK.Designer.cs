﻿namespace Tables_Generator
{
    partial class FormMessageBoxOK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.lblTxt1 = new System.Windows.Forms.Label();
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlBotomBorder = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlRightBorder = new System.Windows.Forms.Panel();
            this.pnlLeftBorder = new System.Windows.Forms.Panel();
            this.pnlTopBorder = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-87, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Veuillez patienter";
            // 
            // lblTxt1
            // 
            this.lblTxt1.Font = new System.Drawing.Font("Candara", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt1.Location = new System.Drawing.Point(131, 64);
            this.lblTxt1.Name = "lblTxt1";
            this.lblTxt1.Size = new System.Drawing.Size(331, 79);
            this.lblTxt1.TabIndex = 2;
            this.lblTxt1.Text = "Text 1";
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlTopMenu.Controls.Add(this.lblMsg);
            this.pnlTopMenu.Controls.Add(this.btnClose);
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMenu.Location = new System.Drawing.Point(1, 1);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(498, 35);
            this.pnlTopMenu.TabIndex = 1;
            this.pnlTopMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopMenu_Paint);
            this.pnlTopMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopMenu_MouseDown);
            this.pnlTopMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTopMenu_MouseMove);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lblMsg.Location = new System.Drawing.Point(3, 5);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(49, 24);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Msg";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Tables_Generator.Properties.Resources.CloseButton;
            this.btnClose.Location = new System.Drawing.Point(463, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlBotomBorder
            // 
            this.pnlBotomBorder.BackColor = System.Drawing.Color.Black;
            this.pnlBotomBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotomBorder.Location = new System.Drawing.Point(1, 177);
            this.pnlBotomBorder.Name = "pnlBotomBorder";
            this.pnlBotomBorder.Size = new System.Drawing.Size(498, 1);
            this.pnlBotomBorder.TabIndex = 44;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnOk.FlatAppearance.BorderSize = 5;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnOk.Location = new System.Drawing.Point(398, 135);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 31);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlRightBorder
            // 
            this.pnlRightBorder.BackColor = System.Drawing.Color.Black;
            this.pnlRightBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightBorder.Location = new System.Drawing.Point(499, 1);
            this.pnlRightBorder.Name = "pnlRightBorder";
            this.pnlRightBorder.Size = new System.Drawing.Size(1, 177);
            this.pnlRightBorder.TabIndex = 40;
            // 
            // pnlLeftBorder
            // 
            this.pnlLeftBorder.BackColor = System.Drawing.Color.Black;
            this.pnlLeftBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftBorder.Location = new System.Drawing.Point(0, 1);
            this.pnlLeftBorder.Name = "pnlLeftBorder";
            this.pnlLeftBorder.Size = new System.Drawing.Size(1, 177);
            this.pnlLeftBorder.TabIndex = 39;
            // 
            // pnlTopBorder
            // 
            this.pnlTopBorder.BackColor = System.Drawing.Color.Black;
            this.pnlTopBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBorder.Name = "pnlTopBorder";
            this.pnlTopBorder.Size = new System.Drawing.Size(500, 1);
            this.pnlTopBorder.TabIndex = 37;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tables_Generator.Properties.Resources.Message;
            this.pictureBox1.Location = new System.Drawing.Point(12, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // FormMessageBoxOK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(500, 178);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTxt1);
            this.Controls.Add(this.pnlTopMenu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlBotomBorder);
            this.Controls.Add(this.pnlRightBorder);
            this.Controls.Add(this.pnlLeftBorder);
            this.Controls.Add(this.pnlTopBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMessageBoxOK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMessageBoxOK";
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTxt1;
        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBotomBorder;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlRightBorder;
        private System.Windows.Forms.Panel pnlLeftBorder;
        private System.Windows.Forms.Panel pnlTopBorder;
    }
}