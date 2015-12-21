namespace StarsUP
{
    partial class Connection
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbNomUtil = new System.Windows.Forms.TextBox();
            this.tbMDP = new System.Windows.Forms.TextBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom d\'utilisateur:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mot de passe:";
            // 
            // tbNomUtil
            // 
            this.tbNomUtil.Location = new System.Drawing.Point(205, 42);
            this.tbNomUtil.Name = "tbNomUtil";
            this.tbNomUtil.Size = new System.Drawing.Size(167, 20);
            this.tbNomUtil.TabIndex = 1;
            // 
            // tbMDP
            // 
            this.tbMDP.Location = new System.Drawing.Point(205, 91);
            this.tbMDP.Name = "tbMDP";
            this.tbMDP.Size = new System.Drawing.Size(167, 20);
            this.tbMDP.TabIndex = 1;
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(205, 197);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(128, 23);
            this.btnConnection.TabIndex = 2;
            this.btnConnection.Text = "Se Connecter";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 306);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.tbMDP);
            this.Controls.Add(this.tbNomUtil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.IsMdiContainer = true;
            this.Name = "Connection";
            this.Text = "Connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Connection_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNomUtil;
        private System.Windows.Forms.TextBox tbMDP;
        private System.Windows.Forms.Button btnConnection;
    }
}

