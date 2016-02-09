using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;

namespace StarsUP
{
    /// <summary>
    /// Cette form permet la connetion de l'inspecteur à la base de donnéee. Une fois connecté il a accès à la form Index qui lui permet,
    /// de choisir ce qu'il veut faire
    /// </summary>
    /// 

    public partial class Connection : MetroForm
    {
        public String var="";
        
        public Connection()
        {
            InitializeComponent();
      
            tbMDP.PasswordChar='*'; //Ceci permet d'avoir des étoiles lorsqu'on saisi le mot de passe

        }

       
        
        private void btnConnection_Click(object sender, EventArgs e)
        {
           
        
           
            if(tbNomUtil.Text=="" && tbMDP.Text=="" | tbNomUtil.Text=="" | tbMDP.Text=="") // les textbox sont vides alors on envoie un message
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
            else
            {
                //Sinon on essaie de se connecter
            controller.init();
            controller.Vmodel.seconnecter();
            if (!controller.Vmodel.Connopen)
            {
                MessageBox.Show("Erreur de Connexion", "La connexion n'a pu avoir lieu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                MessageBox.Show("Access BDD Success", "Connexion résussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (controller.Vmodel.login(tbNomUtil.Text, tbMDP.Text)) //Cette instruction permet de tester si la valeur booleenne est vrai ou fausse et de récupérer le nom de l'inspecteur.
                    //Ce qui nous renvoie sur la form Index
                {
                    StringBuilder sb = new StringBuilder("Connection de : ");
                    sb.Append(tbNomUtil.Text).Append(" réussie");
                    MessageBox.Show(sb.ToString());
                    this.Hide();
                    String nomInsp=tbNomUtil.Text;
                    String mdpInsp=tbMDP.Text;
                    Index I = new Index(nomInsp.ToString(),mdpInsp.ToString());
                 
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
        /// <summary>
        /// Cette méthode permet de fermer le programme après avoir clické sur le bouton X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Voulez-vous quitter StarsUP ?", "Quitter", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(1);

            }
        }

        private void tbNomUtil_KeyUp(object sender, KeyEventArgs e)
        {
           if(e.KeyCode==Keys.Enter)
           {
               btnConnection_Click(sender, e);
           }
        }

        private void tbMDP_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnConnection_Click(sender, e);
            }
        }

       
      

        

        

       
    }
}
