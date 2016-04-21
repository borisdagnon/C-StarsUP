namespace StarsUP
{
    partial class Commentaire_Contre_Visite
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
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnreg = new System.Windows.Forms.Button();
            this.tbEtoile = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCommentaire = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbEtoile)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(255, 183);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 13;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // btnEnreg
            // 
            this.btnEnreg.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEnreg.Location = new System.Drawing.Point(143, 183);
            this.btnEnreg.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnreg.Name = "btnEnreg";
            this.btnEnreg.Size = new System.Drawing.Size(68, 24);
            this.btnEnreg.TabIndex = 12;
            this.btnEnreg.Text = "Enregistrer";
            this.btnEnreg.UseVisualStyleBackColor = true;
            // 
            // tbEtoile
            // 
            this.tbEtoile.Location = new System.Drawing.Point(143, 134);
            this.tbEtoile.Margin = new System.Windows.Forms.Padding(2);
            this.tbEtoile.Maximum = 5;
            this.tbEtoile.Name = "tbEtoile";
            this.tbEtoile.Size = new System.Drawing.Size(171, 45);
            this.tbEtoile.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombres d\'étoiles :";
            // 
            // tbCommentaire
            // 
            this.tbCommentaire.Location = new System.Drawing.Point(143, 18);
            this.tbCommentaire.Margin = new System.Windows.Forms.Padding(2);
            this.tbCommentaire.Name = "tbCommentaire";
            this.tbCommentaire.Size = new System.Drawing.Size(187, 80);
            this.tbCommentaire.TabIndex = 9;
            this.tbCommentaire.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ajouter commentaire :";
            // 
            // Commentaire_Contre_Visite
            // 
            this.AcceptButton = this.btnEnreg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(359, 220);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnreg);
            this.Controls.Add(this.tbEtoile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCommentaire);
            this.Controls.Add(this.label1);
            this.Name = "Commentaire_Contre_Visite";
            this.Text = "Commentaire_Contre_Visite";
            ((System.ComponentModel.ISupportInitialize)(this.tbEtoile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnEnreg;
        private System.Windows.Forms.TrackBar tbEtoile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tbCommentaire;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox TbCommentaire
        {
            get { return tbCommentaire; }
            set { tbCommentaire = value; }
        }
        public System.Windows.Forms.TrackBar TbEtoile
        {
            get { return tbEtoile; }
            set { tbEtoile = value; }
        }
    }
}