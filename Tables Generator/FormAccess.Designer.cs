namespace Tables_Generator
{
    partial class FormAccess
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbColumn = new System.Windows.Forms.ComboBox();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddQuery = new System.Windows.Forms.Button();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.btnTestQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.cbColumn);
            this.groupBox1.Controls.Add(this.cbTables);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(52, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 58);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requêtte";
            // 
            // cbColumn
            // 
            this.cbColumn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbColumn.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbColumn.FormattingEnabled = true;
            this.cbColumn.Location = new System.Drawing.Point(129, 19);
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Size = new System.Drawing.Size(227, 29);
            this.cbColumn.TabIndex = 18;
            this.cbColumn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbColumn_KeyDown);
            // 
            // cbTables
            // 
            this.cbTables.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbTables.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(414, 20);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(227, 29);
            this.cbTables.TabIndex = 17;
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.cbTables_SelectedIndexChanged);
            this.cbTables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTables_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "SELECT DISTINCT";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(362, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "FROM";
            // 
            // btnAddQuery
            // 
            this.btnAddQuery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddQuery.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAddQuery.FlatAppearance.BorderSize = 5;
            this.btnAddQuery.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuery.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAddQuery.Location = new System.Drawing.Point(77, 374);
            this.btnAddQuery.Name = "btnAddQuery";
            this.btnAddQuery.Size = new System.Drawing.Size(366, 34);
            this.btnAddQuery.TabIndex = 22;
            this.btnAddQuery.Text = "Ajouter le résultat de la requêtte à la catégorie :";
            this.btnAddQuery.UseVisualStyleBackColor = false;
            this.btnAddQuery.Click += new System.EventHandler(this.btnAddQuery_Click);
            // 
            // cbCategories
            // 
            this.cbCategories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbCategories.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(449, 378);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(227, 29);
            this.cbCategories.TabIndex = 21;
            this.cbCategories.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCategories_KeyDown);
            // 
            // btnTestQuery
            // 
            this.btnTestQuery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTestQuery.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTestQuery.FlatAppearance.BorderSize = 5;
            this.btnTestQuery.Font = new System.Drawing.Font("Gill Sans MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestQuery.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnTestQuery.Location = new System.Drawing.Point(288, 142);
            this.btnTestQuery.Name = "btnTestQuery";
            this.btnTestQuery.Size = new System.Drawing.Size(155, 34);
            this.btnTestQuery.TabIndex = 20;
            this.btnTestQuery.Text = "Fichier destination";
            this.btnTestQuery.UseVisualStyleBackColor = false;
            this.btnTestQuery.Click += new System.EventHandler(this.btnTestQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SlateBlue;
            this.label2.Location = new System.Drawing.Point(26, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(638, 36);
            this.label2.TabIndex = 17;
            this.label2.Text = "Importer les données d’une base de données Access";
            // 
            // FormAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(747, 454);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddQuery);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.btnTestQuery);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAccess";
            this.Text = "FormAccess";
            this.Load += new System.EventHandler(this.FormAccess_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbColumn;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddQuery;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.Button btnTestQuery;
        private System.Windows.Forms.Label label2;
    }
}