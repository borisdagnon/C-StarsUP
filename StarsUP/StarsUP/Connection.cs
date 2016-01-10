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

namespace StarsUP
{
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
                MessageBox.Show("Veuillez remplir toous les champs");
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
                    Index I = new Index(nomInsp);
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

        private void Connection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Voulez-vous quitter StarsUP ?", "Quitter", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(1);
            }
        }

       
    }
}
