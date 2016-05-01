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
using System.Xml.Serialization;

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
                MessageBox.Show("La connexion n'a pu avoir lieu, vérifiez votre réseau", "Erreur de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                XmlSerializer serial = new XmlSerializer(typeof(Premiere));
                StreamReader lire = new StreamReader("Premiere.xml");
                Premiere p = (Premiere)serial.Deserialize(lire);
                 lire.Close();

                    XmlSerializer serial2 = new XmlSerializer(typeof(DateConnexion));
                    StreamReader lire2 = new StreamReader("DateConnexion.xml");
                    DateConnexion dc = (DateConnexion)serial2.Deserialize(lire2);
                    lire2.Close();

                    //Si 24H sont passés alors on supprime les données
                    if(dc.D.AddDays(1)==DateTime.Now)
                    {
                        p.Num = 0;

                    }

                    //Il s'agit ici du cas ou il se serai connecté une fois et que sa session ne sois pas dépassé cf:(DateConnexion)
                    if (p.Num==1)
                {

                        Premiere Pexception = new Premiere();
                       
                        XmlSerializer serialException = new XmlSerializer(typeof(Premiere));
                        StreamWriter ecrireException = new StreamWriter("Premiere.xml", false);
                        Pexception.ImportXml = 1;
                        Pexception.Num = 1;
                        serialException.Serialize(ecrireException, Pexception);
                       
                        MessageBox.Show("Vous-vous êtes déjà connecté une fois sur ce poste et votre session est encore valide  ", "Exception", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        
                        ecrireException.Close();
                        Index I = new Index(tbNomUtil.Text, tbMDP.Text);
                        I.Show();
                    }
                    else
                    {
                        MessageBox.Show("Vous-vous êtes déjà connecté une fois sur ce poste mais votre session n'est plus valide  ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            else
            {
                MessageBox.Show("Access BDD Success", "Connexion résussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (controller.Vmodel.login(tbNomUtil.Text, tbMDP.Text)) //Cette instruction permet de tester si la valeur booleenne est vrai ou fausse et de récupérer le nom de l'inspecteur.
                    //Ce qui nous renvoie sur la form Index
                {
                    StringBuilder sb = new StringBuilder("Connection de : ");
                    sb.Append(tbNomUtil.Text).Append(" réussie");

                    //On met en xml 1 pour précisier qu'il s'est déjà connecté une fois
                    Premiere p = new Premiere();
                    p.Num = 1;
                    p.ImportXml = 0;
                    XmlSerializer serial = new XmlSerializer(typeof(Premiere));
                    StreamWriter ecrire = new StreamWriter("Premiere.xml", false);
                    serial.Serialize(ecrire, p);
                    ecrire.Close();

                    //On serialize la date à laquelle on a fait l'importation des données a partir du serveur
                    DateConnexion dc = new DateConnexion();
                    dc.D = DateTime.Now;
                    XmlSerializer serial2 = new XmlSerializer(typeof(DateConnexion));
                      StreamWriter ecrire2 = new StreamWriter("DateConnexion.xml", false);
                    serial2.Serialize(ecrire2,dc);
                    ecrire2.Close();


                        //On enregistre ensuite toutes les données dans un fichier xml afin de pouvoir les utliser si il n'y a pas de connexion. Mais on les supprimera si l'inspecteur réussi à exporter.


                        



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
