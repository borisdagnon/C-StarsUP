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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connection));
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
            this.label1.Location = new System.Drawing.Point(105, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom d\'utilisateur:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mot de passe:";
            // 
            // tbNomUtil
            // 
            this.tbNomUtil.Location = new System.Drawing.Point(252, 120);
            this.tbNomUtil.Name = "tbNomUtil";
            this.tbNomUtil.Size = new System.Drawing.Size(177, 25);
            this.tbNomUtil.TabIndex = 1;
            this.tbNomUtil.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNomUtil_KeyUp);
            // 
            // tbMDP
            // 
            this.tbMDP.Location = new System.Drawing.Point(252, 179);
            this.tbMDP.Name = "tbMDP";
            this.tbMDP.Size = new System.Drawing.Size(177, 25);
            this.tbMDP.TabIndex = 1;
            this.tbMDP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbMDP_KeyUp);
            // 
            // btnConnection
            // 
            this.btnConnection.Image = global::StarsUP.Properties.Resources.icon_store_member1;
            this.btnConnection.Location = new System.Drawing.Point(252, 261);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(177, 48);
            this.btnConnection.TabIndex = 2;
            this.btnConnection.Text = "Se Connecter";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 332);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.tbMDP);
            this.Controls.Add(this.tbNomUtil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

        public System.Windows.Forms.TextBox TbNomUtil
        {
            get { return tbNomUtil; }
            set { tbNomUtil = value; }
        }
        private System.Windows.Forms.TextBox tbMDP;
        private System.Windows.Forms.Button btnConnection;
    }
}

