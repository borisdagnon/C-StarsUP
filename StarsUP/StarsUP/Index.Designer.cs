namespace StarsUP
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeVisiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeContreVisitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.générerPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProfil = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.gestionToolStripMenuItem,
            this.pDFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(565, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem1,
            this.exportToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.importToolStripMenuItem.Text = "Lien BDD";
            // 
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem1.Text = "import";
            this.importToolStripMenuItem1.Click += new System.EventHandler(this.importToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeVisiteToolStripMenuItem,
            this.listeContreVisitesToolStripMenuItem});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.gestionToolStripMenuItem.Text = "Gestion";
            // 
            // listeVisiteToolStripMenuItem
            // 
            this.listeVisiteToolStripMenuItem.Name = "listeVisiteToolStripMenuItem";
            this.listeVisiteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.listeVisiteToolStripMenuItem.Text = "Liste Visite";
            this.listeVisiteToolStripMenuItem.Click += new System.EventHandler(this.listeVisiteToolStripMenuItem_Click);
            // 
            // listeContreVisitesToolStripMenuItem
            // 
            this.listeContreVisitesToolStripMenuItem.Name = "listeContreVisitesToolStripMenuItem";
            this.listeContreVisitesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.listeContreVisitesToolStripMenuItem.Text = "Liste Contre Visites";
            this.listeContreVisitesToolStripMenuItem.Click += new System.EventHandler(this.listeContreVisitesToolStripMenuItem_Click);
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.générerPDFToolStripMenuItem});
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.pDFToolStripMenuItem.Text = "PDF";
            // 
            // générerPDFToolStripMenuItem
            // 
            this.générerPDFToolStripMenuItem.Name = "générerPDFToolStripMenuItem";
            this.générerPDFToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.générerPDFToolStripMenuItem.Text = "Générer PDF";
            this.générerPDFToolStripMenuItem.Click += new System.EventHandler(this.générerPDFToolStripMenuItem_Click);
            // 
            // btnProfil
            // 
            this.btnProfil.Location = new System.Drawing.Point(423, 6);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(99, 51);
            this.btnProfil.TabIndex = 2;
            this.btnProfil.Text = "Profil";
            this.btnProfil.UseVisualStyleBackColor = true;
            this.btnProfil.Click += new System.EventHandler(this.btnProfil_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 332);
            this.Controls.Add(this.btnProfil);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Index";
            this.Text = "Index";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Index_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Index_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeVisiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem générerPDFToolStripMenuItem;
        private System.Windows.Forms.Button btnProfil;
        private System.Windows.Forms.ToolStripMenuItem listeContreVisitesToolStripMenuItem;
    }
}