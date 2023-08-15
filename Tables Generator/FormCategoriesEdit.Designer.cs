
namespace Tables_Generator
{
    partial class FormCategoriesEdit
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
            this.components = new System.ComponentModel.Container();
            this.pbCategory = new System.Windows.Forms.PictureBox();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.btnEditPicture = new System.Windows.Forms.Button();
            this.btnCancelEditPicture = new System.Windows.Forms.Button();
            this.lblTxt2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRename = new System.Windows.Forms.TextBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTXT = new System.Windows.Forms.Button();
            this.btnAccess = new System.Windows.Forms.Button();
            this.btnSql = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lbCategoryDetails = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.supprimerLaSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCategory
            // 
            this.pbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCategory.Location = new System.Drawing.Point(63, 135);
            this.pbCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbCategory.Name = "pbCategory";
            this.pbCategory.Size = new System.Drawing.Size(344, 230);
            this.pbCategory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCategory.TabIndex = 1;
            this.pbCategory.TabStop = false;
            // 
            // cbCategories
            // 
            this.cbCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(141, 23);
            this.cbCategories.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(301, 32);
            this.cbCategories.TabIndex = 0;
            this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            this.cbCategories.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCategories_KeyDown);
            // 
            // btnEditPicture
            // 
            this.btnEditPicture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEditPicture.BackColor = System.Drawing.Color.White;
            this.btnEditPicture.FlatAppearance.BorderSize = 5;
            this.btnEditPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPicture.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnEditPicture.Location = new System.Drawing.Point(200, 423);
            this.btnEditPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditPicture.Name = "btnEditPicture";
            this.btnEditPicture.Size = new System.Drawing.Size(55, 47);
            this.btnEditPicture.TabIndex = 3;
            this.btnEditPicture.Text = "√";
            this.btnEditPicture.UseVisualStyleBackColor = false;
            this.btnEditPicture.Visible = false;
            this.btnEditPicture.Click += new System.EventHandler(this.btnEditPicture_Click);
            // 
            // btnCancelEditPicture
            // 
            this.btnCancelEditPicture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelEditPicture.BackColor = System.Drawing.Color.White;
            this.btnCancelEditPicture.FlatAppearance.BorderSize = 5;
            this.btnCancelEditPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEditPicture.ForeColor = System.Drawing.Color.Red;
            this.btnCancelEditPicture.Location = new System.Drawing.Point(263, 421);
            this.btnCancelEditPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelEditPicture.Name = "btnCancelEditPicture";
            this.btnCancelEditPicture.Size = new System.Drawing.Size(55, 48);
            this.btnCancelEditPicture.TabIndex = 4;
            this.btnCancelEditPicture.Text = "X";
            this.btnCancelEditPicture.UseVisualStyleBackColor = false;
            this.btnCancelEditPicture.Visible = false;
            this.btnCancelEditPicture.Click += new System.EventHandler(this.btnCancelEditPicture_Click);
            // 
            // lblTxt2
            // 
            this.lblTxt2.AutoSize = true;
            this.lblTxt2.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt2.Location = new System.Drawing.Point(33, 30);
            this.lblTxt2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTxt2.Name = "lblTxt2";
            this.lblTxt2.Size = new System.Drawing.Size(95, 23);
            this.lblTxt2.TabIndex = 0;
            this.lblTxt2.Text = "Catégories";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRename);
            this.groupBox1.Controls.Add(this.cbCategories);
            this.groupBox1.Controls.Add(this.lblTxt2);
            this.groupBox1.Controls.Add(this.pbCategory);
            this.groupBox1.Controls.Add(this.btnCancelEditPicture);
            this.groupBox1.Controls.Add(this.btnEditPicture);
            this.groupBox1.Controls.Add(this.btnUploadImage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 134);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(476, 540);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(73, 483);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Renommer :";
            // 
            // txtRename
            // 
            this.txtRename.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtRename.Location = new System.Drawing.Point(193, 477);
            this.txtRename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRename.Name = "txtRename";
            this.txtRename.Size = new System.Drawing.Size(196, 29);
            this.txtRename.TabIndex = 5;
            this.txtRename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRename_KeyDown);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUploadImage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUploadImage.FlatAppearance.BorderSize = 5;
            this.btnUploadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnUploadImage.Location = new System.Drawing.Point(167, 425);
            this.btnUploadImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(187, 42);
            this.btnUploadImage.TabIndex = 2;
            this.btnUploadImage.Text = "Modifier l\'image";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTXT);
            this.groupBox2.Controls.Add(this.btnAccess);
            this.groupBox2.Controls.Add(this.btnSql);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtValue);
            this.groupBox2.Controls.Add(this.lblCount);
            this.groupBox2.Controls.Add(this.lbCategoryDetails);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(488, 134);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(575, 540);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnTXT
            // 
            this.btnTXT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnTXT.BackColor = System.Drawing.Color.White;
            this.btnTXT.FlatAppearance.BorderSize = 5;
            this.btnTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTXT.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnTXT.Location = new System.Drawing.Point(301, 435);
            this.btnTXT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTXT.Name = "btnTXT";
            this.btnTXT.Size = new System.Drawing.Size(233, 94);
            this.btnTXT.TabIndex = 5;
            this.btnTXT.Text = "Importer les données d’un fichier TXT";
            this.btnTXT.UseVisualStyleBackColor = false;
            this.btnTXT.Click += new System.EventHandler(this.btnTXT_Click);
            // 
            // btnAccess
            // 
            this.btnAccess.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(166)))));
            this.btnAccess.FlatAppearance.BorderSize = 5;
            this.btnAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccess.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAccess.Location = new System.Drawing.Point(301, 333);
            this.btnAccess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAccess.Name = "btnAccess";
            this.btnAccess.Size = new System.Drawing.Size(233, 94);
            this.btnAccess.TabIndex = 3;
            this.btnAccess.Text = "Importer les données d’une base de données Access";
            this.btnAccess.UseVisualStyleBackColor = false;
            this.btnAccess.Click += new System.EventHandler(this.btnAccess_Click);
            // 
            // btnSql
            // 
            this.btnSql.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.btnSql.FlatAppearance.BorderSize = 5;
            this.btnSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSql.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSql.Location = new System.Drawing.Point(52, 434);
            this.btnSql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSql.Name = "btnSql";
            this.btnSql.Size = new System.Drawing.Size(233, 97);
            this.btnSql.TabIndex = 4;
            this.btnSql.Text = "Importer les données d’une base de données SQL Server";
            this.btnSql.UseVisualStyleBackColor = false;
            this.btnSql.Click += new System.EventHandler(this.btnSql_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(53, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ajouter un mot ou une phrase : ";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtValue.Location = new System.Drawing.Point(332, 281);
            this.txtValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(196, 29);
            this.txtValue.TabIndex = 1;
            this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyDown);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(323, 36);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(32, 24);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "(0)";
            // 
            // lbCategoryDetails
            // 
            this.lbCategoryDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCategoryDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbCategoryDetails.FormattingEnabled = true;
            this.lbCategoryDetails.ItemHeight = 24;
            this.lbCategoryDetails.Location = new System.Drawing.Point(39, 74);
            this.lbCategoryDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbCategoryDetails.Name = "lbCategoryDetails";
            this.lbCategoryDetails.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbCategoryDetails.Size = new System.Drawing.Size(500, 148);
            this.lbCategoryDetails.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Objets ajoutés à cette catégorie :";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.btnExcel.FlatAppearance.BorderSize = 5;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExcel.Location = new System.Drawing.Point(52, 332);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(233, 97);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "Importer les données d’un fichier Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 583F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 485F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 678);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateBlue;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 23, 0, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modifier une catégorie";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supprimerLaSelectionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(252, 32);
            // 
            // supprimerLaSelectionToolStripMenuItem
            // 
            this.supprimerLaSelectionToolStripMenuItem.BackColor = System.Drawing.Color.GhostWhite;
            this.supprimerLaSelectionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.supprimerLaSelectionToolStripMenuItem.Name = "supprimerLaSelectionToolStripMenuItem";
            this.supprimerLaSelectionToolStripMenuItem.Size = new System.Drawing.Size(251, 28);
            this.supprimerLaSelectionToolStripMenuItem.Text = "Supprimer la selection ?";
            this.supprimerLaSelectionToolStripMenuItem.Click += new System.EventHandler(this.supprimerLaSelectionToolStripMenuItem_Click);
            // 
            // FormCategoriesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1067, 678);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormCategoriesEdit";
            this.Text = "FormModifier";
            this.Load += new System.EventHandler(this.FormCategoriesEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCategory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbCategory;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.Button btnEditPicture;
        private System.Windows.Forms.Button btnCancelEditPicture;
        private System.Windows.Forms.Label lblTxt2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRename;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbCategoryDetails;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnSql;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem supprimerLaSelectionToolStripMenuItem;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnTXT;
        private System.Windows.Forms.Button btnAccess;
    }
}