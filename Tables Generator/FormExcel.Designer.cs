namespace Tables_Generator
{
    partial class FormExcel
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
            this.btnTestQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddQuery = new System.Windows.Forms.Button();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.cbColumn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTestQuery
            // 
            this.btnTestQuery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTestQuery.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTestQuery.FlatAppearance.BorderSize = 5;
            this.btnTestQuery.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestQuery.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnTestQuery.Location = new System.Drawing.Point(348, 201);
            this.btnTestQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestQuery.Name = "btnTestQuery";
            this.btnTestQuery.Size = new System.Drawing.Size(207, 42);
            this.btnTestQuery.TabIndex = 22;
            this.btnTestQuery.Text = "Fichier destination";
            this.btnTestQuery.UseVisualStyleBackColor = false;
            this.btnTestQuery.Click += new System.EventHandler(this.btnTestQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SlateBlue;
            this.label2.Location = new System.Drawing.Point(45, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(620, 45);
            this.label2.TabIndex = 21;
            this.label2.Text = "Importer les données d’un fichier Excel";
            // 
            // btnAddQuery
            // 
            this.btnAddQuery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddQuery.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAddQuery.FlatAppearance.BorderSize = 5;
            this.btnAddQuery.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuery.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAddQuery.Location = new System.Drawing.Point(101, 512);
            this.btnAddQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddQuery.Name = "btnAddQuery";
            this.btnAddQuery.Size = new System.Drawing.Size(407, 42);
            this.btnAddQuery.TabIndex = 24;
            this.btnAddQuery.Text = "Ajouter les données de cette colonne  à :";
            this.btnAddQuery.UseVisualStyleBackColor = false;
            this.btnAddQuery.Click += new System.EventHandler(this.btnAddQuery_Click);
            // 
            // cbCategories
            // 
            this.cbCategories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCategories.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(516, 517);
            this.cbCategories.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(301, 35);
            this.cbCategories.TabIndex = 23;
            this.cbCategories.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCategories_KeyDown);
            // 
            // cbSheet
            // 
            this.cbSheet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSheet.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.Location = new System.Drawing.Point(105, 366);
            this.cbSheet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(301, 35);
            this.cbSheet.TabIndex = 31;
            this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
            this.cbSheet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSheet_KeyDown);
            // 
            // cbColumn
            // 
            this.cbColumn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbColumn.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbColumn.FormattingEnabled = true;
            this.cbColumn.Location = new System.Drawing.Point(618, 366);
            this.cbColumn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Size = new System.Drawing.Size(301, 35);
            this.cbColumn.TabIndex = 30;
            this.cbColumn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbColumn_KeyDown_1);
            this.cbColumn.MouseHover += new System.EventHandler(this.cbColumn_MouseHover);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(22, 371);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Feuille :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(416, 372);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 23);
            this.label4.TabIndex = 29;
            this.label4.Text = "Colonne(s) utilisée(s) :";
            // 
            // FormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(947, 676);
            this.Controls.Add(this.cbSheet);
            this.Controls.Add(this.cbColumn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddQuery);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.btnTestQuery);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormExcel";
            this.Text = "FormExcel";
            this.Load += new System.EventHandler(this.FormExcel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddQuery;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.ComboBox cbSheet;
        private System.Windows.Forms.ComboBox cbColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}