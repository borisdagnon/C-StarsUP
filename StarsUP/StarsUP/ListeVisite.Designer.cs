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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListeVisite));
            this.dataGV = new System.Windows.Forms.DataGridView();
            this.cbSaison = new System.Windows.Forms.ComboBox();
            this.cbDepartement = new System.Windows.Forms.ComboBox();
            this.lbCbSaison = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGV
            // 
            this.dataGV.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Location = new System.Drawing.Point(-1, 204);
            this.dataGV.Margin = new System.Windows.Forms.Padding(4);
            this.dataGV.Name = "dataGV";
            this.dataGV.Size = new System.Drawing.Size(1092, 298);
            this.dataGV.TabIndex = 0;
            this.dataGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV_CellContentClick);
            // 
            // cbSaison
            // 
            this.cbSaison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSaison.FormattingEnabled = true;
            this.cbSaison.Location = new System.Drawing.Point(223, 97);
            this.cbSaison.Margin = new System.Windows.Forms.Padding(4);
            this.cbSaison.Name = "cbSaison";
            this.cbSaison.Size = new System.Drawing.Size(172, 24);
            this.cbSaison.TabIndex = 1;
            this.cbSaison.SelectionChangeCommitted += new System.EventHandler(this.cbSaison_SelectionChangeCommitted);
            // 
            // cbDepartement
            // 
            this.cbDepartement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartement.FormattingEnabled = true;
            this.cbDepartement.Location = new System.Drawing.Point(617, 97);
            this.cbDepartement.Margin = new System.Windows.Forms.Padding(4);
            this.cbDepartement.Name = "cbDepartement";
            this.cbDepartement.Size = new System.Drawing.Size(172, 24);
            this.cbDepartement.TabIndex = 2;
            this.cbDepartement.SelectionChangeCommitted += new System.EventHandler(this.cbDepartement_SelectionChangeCommitted);
            // 
            // lbCbSaison
            // 
            this.lbCbSaison.AutoSize = true;
            this.lbCbSaison.Location = new System.Drawing.Point(125, 107);
            this.lbCbSaison.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCbSaison.Name = "lbCbSaison";
            this.lbCbSaison.Size = new System.Drawing.Size(55, 17);
            this.lbCbSaison.TabIndex = 3;
            this.lbCbSaison.Text = "Saison:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Département:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(129, 151);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(617, 151);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker2.TabIndex = 5;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 160);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "A :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "De :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(895, 464);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Commentaire et Etoile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListeVisite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 505);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCbSaison);
            this.Controls.Add(this.cbDepartement);
            this.Controls.Add(this.cbSaison);
            this.Controls.Add(this.dataGV);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListeVisite";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Liste Visites";
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}