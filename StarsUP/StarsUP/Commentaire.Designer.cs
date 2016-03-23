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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbEtoile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter commentaire :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbCommentaire
            // 
            this.tbCommentaire.Location = new System.Drawing.Point(175, 43);
            this.tbCommentaire.Name = "tbCommentaire";
            this.tbCommentaire.Size = new System.Drawing.Size(248, 97);
            this.tbCommentaire.TabIndex = 1;
            this.tbCommentaire.Text = "";
            this.tbCommentaire.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombres d\'étoiles :";
            // 
            // tbEtoile
            // 
            this.tbEtoile.Location = new System.Drawing.Point(175, 186);
            this.tbEtoile.Name = "tbEtoile";
            this.tbEtoile.Size = new System.Drawing.Size(228, 56);
            this.tbEtoile.TabIndex = 3;
            this.tbEtoile.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Commentaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbEtoile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCommentaire);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button button1;

    }
}