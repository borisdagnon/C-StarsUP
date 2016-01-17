namespace StarsUP
{
    partial class Profil
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNom = new System.Windows.Forms.Label();
            this.lbPrenom = new System.Windows.Forms.Label();
            this.lbNumero = new System.Windows.Forms.Label();
            this.lbIdentifiant = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StarsUP.Properties.Resources.icon_store_member;
            this.pictureBox1.Location = new System.Drawing.Point(1, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 67);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.Location = new System.Drawing.Point(1, 159);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(35, 13);
            this.lbNom.TabIndex = 1;
            this.lbNom.Text = "label1";
            // 
            // lbPrenom
            // 
            this.lbPrenom.AutoSize = true;
            this.lbPrenom.Location = new System.Drawing.Point(71, 159);
            this.lbPrenom.Name = "lbPrenom";
            this.lbPrenom.Size = new System.Drawing.Size(35, 13);
            this.lbPrenom.TabIndex = 1;
            this.lbPrenom.Text = "label1";
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.Location = new System.Drawing.Point(163, 114);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(35, 13);
            this.lbNumero.TabIndex = 1;
            this.lbNumero.Text = "label1";
            // 
            // lbIdentifiant
            // 
            this.lbIdentifiant.AutoSize = true;
            this.lbIdentifiant.Location = new System.Drawing.Point(163, 79);
            this.lbIdentifiant.Name = "lbIdentifiant";
            this.lbIdentifiant.Size = new System.Drawing.Size(35, 13);
            this.lbIdentifiant.TabIndex = 1;
            this.lbIdentifiant.Text = "label1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(47, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Profil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 332);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbPrenom);
            this.Controls.Add(this.lbIdentifiant);
            this.Controls.Add(this.lbNumero);
            this.Controls.Add(this.lbNom);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Profil";
            this.Text = "Profil";
            this.Load += new System.EventHandler(this.Profil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNom;
        private System.Windows.Forms.Label lbPrenom;
        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.Label lbIdentifiant;
        private System.Windows.Forms.Button btnSave;
    }
}