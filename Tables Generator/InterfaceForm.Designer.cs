
namespace Tables_Generator
{
    partial class InterfaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfaceForm));
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sQLAssistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catégorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterUneSauveguardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importerUneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renitiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenuStrip = new System.Windows.Forms.Panel();
            this.pnlFormContainer = new System.Windows.Forms.Panel();
            this.pnlTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.pnlMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlTopMenu.Controls.Add(this.progressBar1);
            this.pnlTopMenu.Controls.Add(this.label1);
            this.pnlTopMenu.Controls.Add(this.pictureBox1);
            this.pnlTopMenu.Controls.Add(this.lblProgressBar);
            this.pnlTopMenu.Controls.Add(this.btnMinimize);
            this.pnlTopMenu.Controls.Add(this.btnClose);
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(1137, 35);
            this.pnlTopMenu.TabIndex = 1;
            this.pnlTopMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopMenu_Paint);
            this.pnlTopMenu.DoubleClick += new System.EventHandler(this.pnlTopMenu_DoubleClick);
            this.pnlTopMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopMenu_MouseDown);
            this.pnlTopMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTopMenu_MouseMove);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(131, 6);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(372, 23);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(39, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "R-SGBD";
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.AutoSize = true;
            this.lblProgressBar.Location = new System.Drawing.Point(513, 11);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(0, 13);
            this.lblProgressBar.TabIndex = 3;
            this.lblProgressBar.Visible = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = global::Tables_Generator.Properties.Resources.MinimizeButton;
            this.btnMinimize.Location = new System.Drawing.Point(1061, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Tables_Generator.Properties.Resources.CloseButton;
            this.btnClose.Location = new System.Drawing.Point(1102, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sQLAssistanceToolStripMenuItem,
            this.catégorieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(176, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sQLAssistanceToolStripMenuItem
            // 
            this.sQLAssistanceToolStripMenuItem.Name = "sQLAssistanceToolStripMenuItem";
            this.sQLAssistanceToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.sQLAssistanceToolStripMenuItem.Text = "SQL Assistance";
            this.sQLAssistanceToolStripMenuItem.Click += new System.EventHandler(this.sQLAssistanceToolStripMenuItem_Click);
            // 
            // catégorieToolStripMenuItem
            // 
            this.catégorieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.exporterUneSauveguardToolStripMenuItem,
            this.importerUneToolStripMenuItem,
            this.renitiToolStripMenuItem});
            this.catégorieToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.catégorieToolStripMenuItem.Name = "catégorieToolStripMenuItem";
            this.catégorieToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.catégorieToolStripMenuItem.Text = "Catégorie";
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.ajouterToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajouterToolStripMenuItem.Image = global::Tables_Generator.Properties.Resources.Add;
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter / Supprimer";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.modifierToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifierToolStripMenuItem.Image = global::Tables_Generator.Properties.Resources.Edit;
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // exporterUneSauveguardToolStripMenuItem
            // 
            this.exporterUneSauveguardToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.exporterUneSauveguardToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.exporterUneSauveguardToolStripMenuItem.Name = "exporterUneSauveguardToolStripMenuItem";
            this.exporterUneSauveguardToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.exporterUneSauveguardToolStripMenuItem.Text = "Exporter une sauveguard";
            this.exporterUneSauveguardToolStripMenuItem.Click += new System.EventHandler(this.exporterUneSauveguardToolStripMenuItem_Click);
            // 
            // importerUneToolStripMenuItem
            // 
            this.importerUneToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.importerUneToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.importerUneToolStripMenuItem.Name = "importerUneToolStripMenuItem";
            this.importerUneToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.importerUneToolStripMenuItem.Text = "Importer une sauveguard";
            this.importerUneToolStripMenuItem.Click += new System.EventHandler(this.importerUneToolStripMenuItem_Click);
            // 
            // renitiToolStripMenuItem
            // 
            this.renitiToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.renitiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.renitiToolStripMenuItem.Image = global::Tables_Generator.Properties.Resources.Reset;
            this.renitiToolStripMenuItem.Name = "renitiToolStripMenuItem";
            this.renitiToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.renitiToolStripMenuItem.Text = "Réinitialiser";
            this.renitiToolStripMenuItem.Click += new System.EventHandler(this.renitiToolStripMenuItem_Click);
            // 
            // pnlMenuStrip
            // 
            this.pnlMenuStrip.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlMenuStrip.Controls.Add(this.menuStrip1);
            this.pnlMenuStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuStrip.Location = new System.Drawing.Point(0, 35);
            this.pnlMenuStrip.Name = "pnlMenuStrip";
            this.pnlMenuStrip.Size = new System.Drawing.Size(1137, 24);
            this.pnlMenuStrip.TabIndex = 0;
            this.pnlMenuStrip.TabStop = true;
            // 
            // pnlFormContainer
            // 
            this.pnlFormContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormContainer.BackColor = System.Drawing.Color.Lavender;
            this.pnlFormContainer.Location = new System.Drawing.Point(0, 59);
            this.pnlFormContainer.Name = "pnlFormContainer";
            this.pnlFormContainer.Size = new System.Drawing.Size(1137, 557);
            this.pnlFormContainer.TabIndex = 2;
            // 
            // InterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1137, 640);
            this.Controls.Add(this.pnlFormContainer);
            this.Controls.Add(this.pnlMenuStrip);
            this.Controls.Add(this.pnlTopMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1137, 642);
            this.MinimumSize = new System.Drawing.Size(958, 590);
            this.Name = "InterfaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InterfaceForm";
            this.Load += new System.EventHandler(this.InterfaceForm_Load);
            this.DoubleClick += new System.EventHandler(this.Form_Interface_DoubleClick);
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlMenuStrip.ResumeLayout(false);
            this.pnlMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catégorieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMenuStrip;
        private System.Windows.Forms.Panel pnlFormContainer;
        private System.Windows.Forms.ToolStripMenuItem renitiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporterUneSauveguardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importerUneToolStripMenuItem;
        private System.Windows.Forms.Label lblProgressBar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem sQLAssistanceToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}