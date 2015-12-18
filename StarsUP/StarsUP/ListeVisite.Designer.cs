namespace StarsUP
{
    partial class ListeVisite
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
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.cbSaison = new System.Windows.Forms.ComboBox();
            this.cbDepartement = new System.Windows.Forms.ComboBox();
            this.lbCbSaison = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGV
            // 
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Location = new System.Drawing.Point(0, 63);
            this.dataGV.Name = "dataGV";
            this.dataGV.Size = new System.Drawing.Size(628, 235);
            this.dataGV.TabIndex = 0;
            // 
            // cbSaison
            // 
            this.cbSaison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSaison.FormattingEnabled = true;
            this.cbSaison.Location = new System.Drawing.Point(116, 23);
            this.cbSaison.Name = "cbSaison";
            this.cbSaison.Size = new System.Drawing.Size(130, 21);
            this.cbSaison.TabIndex = 1;
            this.cbSaison.SelectionChangeCommitted += new System.EventHandler(this.cbSaison_SelectionChangeCommitted);
            // 
            // cbDepartement
            // 
            this.cbDepartement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartement.FormattingEnabled = true;
            this.cbDepartement.Location = new System.Drawing.Point(393, 23);
            this.cbDepartement.Name = "cbDepartement";
            this.cbDepartement.Size = new System.Drawing.Size(130, 21);
            this.cbDepartement.TabIndex = 2;
            this.cbDepartement.SelectionChangeCommitted += new System.EventHandler(this.cbDepartement_SelectionChangeCommitted);
            // 
            // lbCbSaison
            // 
            this.lbCbSaison.AutoSize = true;
            this.lbCbSaison.Location = new System.Drawing.Point(13, 30);
            this.lbCbSaison.Name = "lbCbSaison";
            this.lbCbSaison.Size = new System.Drawing.Size(42, 13);
            this.lbCbSaison.TabIndex = 3;
            this.lbCbSaison.Text = "Saison:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Département:";
            // 
            // ListeVisite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 299);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCbSaison);
            this.Controls.Add(this.cbDepartement);
            this.Controls.Add(this.cbSaison);
            this.Controls.Add(this.dataGV);
            this.Name = "ListeVisite";
            this.Text = "Liste Visite";
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGV;
        private System.Windows.Forms.ComboBox cbSaison;
        private System.Windows.Forms.ComboBox cbDepartement;
        private System.Windows.Forms.Label lbCbSaison;
        private System.Windows.Forms.Label label1;
    }
}