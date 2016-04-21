namespace StarsUP
{
    partial class ContreVisites
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCbSaison = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGV
            // 
            this.dataGV.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV.Location = new System.Drawing.Point(3, 166);
            this.dataGV.Name = "dataGV";
            this.dataGV.Size = new System.Drawing.Size(849, 242);
            this.dataGV.TabIndex = 0;
            // 
            // cbSaison
            // 
            this.cbSaison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSaison.FormattingEnabled = true;
            this.cbSaison.Location = new System.Drawing.Point(167, 79);
            this.cbSaison.Name = "cbSaison";
            this.cbSaison.Size = new System.Drawing.Size(130, 21);
            this.cbSaison.TabIndex = 2;
            this.cbSaison.SelectedIndexChanged += new System.EventHandler(this.cbSaison_SelectionChangeCommitted);
            // 
            // cbDepartement
            // 
            this.cbDepartement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartement.FormattingEnabled = true;
            this.cbDepartement.Location = new System.Drawing.Point(463, 79);
            this.cbDepartement.Name = "cbDepartement";
            this.cbDepartement.Size = new System.Drawing.Size(130, 21);
            this.cbDepartement.TabIndex = 3;
            this.cbDepartement.SelectionChangeCommitted += new System.EventHandler(this.cbDepartement_SelectionChangeCommitted);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(97, 123);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(463, 123);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "De :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "A :";
            // 
            // lbCbSaison
            // 
            this.lbCbSaison.AutoSize = true;
            this.lbCbSaison.Location = new System.Drawing.Point(94, 87);
            this.lbCbSaison.Name = "lbCbSaison";
            this.lbCbSaison.Size = new System.Drawing.Size(42, 13);
            this.lbCbSaison.TabIndex = 10;
            this.lbCbSaison.Text = "Saison:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Département:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(705, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "Commentaire et Etoile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ContreVisites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 410);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCbSaison);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbDepartement);
            this.Controls.Add(this.cbSaison);
            this.Controls.Add(this.dataGV);
            this.Name = "ContreVisites";
            this.Resizable = false;
            this.Text = "ContreVisites";
            ((System.ComponentModel.ISupportInitialize)(this.dataGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGV;
        private System.Windows.Forms.ComboBox cbSaison;
        private System.Windows.Forms.ComboBox cbDepartement;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCbSaison;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}