namespace StarsUP
{
    partial class Commentaire
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCommentaire = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEtoile = new System.Windows.Forms.TrackBar();
            this.btnEnreg = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbEtoile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter commentaire :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbCommentaire
            // 
            this.tbCommentaire.Location = new System.Drawing.Point(131, 35);
            this.tbCommentaire.Margin = new System.Windows.Forms.Padding(2);
            this.tbCommentaire.Name = "tbCommentaire";
            this.tbCommentaire.Size = new System.Drawing.Size(187, 80);
            this.tbCommentaire.TabIndex = 1;
            this.tbCommentaire.Text = "";
            this.tbCommentaire.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombres d\'étoiles :";
            // 
            // tbEtoile
            // 
            this.tbEtoile.Location = new System.Drawing.Point(131, 151);
            this.tbEtoile.Margin = new System.Windows.Forms.Padding(2);
            this.tbEtoile.Name = "tbEtoile";
            this.tbEtoile.Size = new System.Drawing.Size(171, 45);
            this.tbEtoile.TabIndex = 3;
            this.tbEtoile.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // btnEnreg
            // 
            this.btnEnreg.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEnreg.Location = new System.Drawing.Point(131, 214);
            this.btnEnreg.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnreg.Name = "btnEnreg";
            this.btnEnreg.Size = new System.Drawing.Size(68, 24);
            this.btnEnreg.TabIndex = 4;
            this.btnEnreg.Text = "Enregistrer";
            this.btnEnreg.UseVisualStyleBackColor = true;
            this.btnEnreg.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(243, 214);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.button2_Click);
            // 
            // Commentaire
            // 
            this.AcceptButton = this.btnEnreg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAnnuler;
            this.ClientSize = new System.Drawing.Size(326, 246);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnreg);
            this.Controls.Add(this.tbEtoile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCommentaire);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Commentaire";
            this.Text = "Commentaire";
            ((System.ComponentModel.ISupportInitialize)(this.tbEtoile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox tbCommentaire;

        public System.Windows.Forms.RichTextBox TbCommentaire
        {
            get { return tbCommentaire; }
            set { tbCommentaire = value; }
        }
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbEtoile;

        public System.Windows.Forms.TrackBar TbEtoile
        {
            get { return tbEtoile; }
            set { tbEtoile = value; }
        }
        private System.Windows.Forms.Button btnEnreg;
        private System.Windows.Forms.Button btnAnnuler;
    }
}