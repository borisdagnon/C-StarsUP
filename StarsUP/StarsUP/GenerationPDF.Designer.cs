namespace StarsUP
{
    partial class GenerationPDF
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
            this.btnPDF = new System.Windows.Forms.Button();
            this.cbVisites = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnPDF
            // 
            this.btnPDF.Location = new System.Drawing.Point(194, 169);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(131, 48);
            this.btnPDF.TabIndex = 0;
            this.btnPDF.Text = "Generer";
            this.btnPDF.UseVisualStyleBackColor = true;
            // 
            // cbVisites
            // 
            this.cbVisites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVisites.FormattingEnabled = true;
            this.cbVisites.Location = new System.Drawing.Point(12, 50);
            this.cbVisites.Name = "cbVisites";
            this.cbVisites.Size = new System.Drawing.Size(478, 21);
            this.cbVisites.TabIndex = 1;
            // 
            // GenerationPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 293);
            this.Controls.Add(this.cbVisites);
            this.Controls.Add(this.btnPDF);
            this.Name = "GenerationPDF";
            this.Text = "GenerationPDF";
            this.Load += new System.EventHandler(this.GenerationPDF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.ComboBox cbVisites;
    }
}