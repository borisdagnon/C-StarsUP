﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarsUP
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            if(tbNomUtil.Text=="" && tbMDP.Text=="" | tbNomUtil.Text=="" | tbMDP.Text=="")
            {
                MessageBox.Show("Veuillez remplir toous les champs");
            }
            else
            {
            controller.init();
            controller.Vmodel.seconnecter();
            if (!controller.Vmodel.Connopen)
            {
                MessageBox.Show("Erreur de Connexion", "La connexion n'a pu avoir lieu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                MessageBox.Show("Access BDD Success", "Connexion résussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (controller.Vmodel.login(tbNomUtil.Text, tbMDP.Text))
                {
                    StringBuilder sb = new StringBuilder("Connection de : ");
                    sb.Append(tbNomUtil.Text).Append(" réussie");
                    MessageBox.Show(sb.ToString());
                    this.Hide();
                    
                    Index I = new Index();
                    I.Show();
                }
                else
                {
                    MessageBox.Show("Invalide : Votre identifiant ou mot de passe");
                    MessageBox.Show("Deconnxion BDD");
                    controller.Vmodel.sedeconnecter();
                    tbNomUtil.Clear();
                    tbMDP.Clear();
                }
                   
            }
        }
                }

        private void Connection_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            controller.Vmodel.sedeconnecter();
        
        }
    }
}