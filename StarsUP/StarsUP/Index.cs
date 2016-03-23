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
    /// <summary>
    /// Cette form est l'interface qui sert à sélectionner la tâche qu'on veut accomplir
    /// On peut donc consulter la liste des visites, ajouter des étoiles et des commentaires et enfin générer des pdf
    /// </summary>
    public partial class Index : MetroForm
    {
        int index;
        private String nomInsp = "";//Création de la variable afin de récupérer le nom de l'inspecteur pour les requêtes
       private String mdpInsp="";
        /// <summary>
        /// Comme un constructeur on récupère la nom de l'ispecteur et on l'instancie
        /// On met le menu à false pour éviter d'avoir une erreur avant l'importation
        /// </summary>
        /// <param name="nomInsp">Récupération du nom de l'inwpecteur pour la requête</param>
        public Index(String nomInsp,String mdpInsp)
        {
            InitializeComponent();
            gestionToolStripMenuItem.Visible = false;
            pDFToolStripMenuItem.Visible = false;
            this.nomInsp = nomInsp;
            this.mdpInsp=mdpInsp;
            btnProfil.Visible = false;
            index = 0;
        }

        private void listeVisiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeVisite LV = new ListeVisite();
            LV.Show();
        }

       

        private void Index_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.Vmodel.sedeconnecter();
            Connection C = new Connection();
            C.Show();
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controller.init();
            controller.Vmodel.seconnecter(); //On se connecte
            if (!controller.Vmodel.Connopen)//Si la connetion se passe mal on renvoie un message d'erreur
            {
                MessageBox.Show("Erreur de Connexion", "La connexion n'a pu avoir lieu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Sinon on affiche un message et on autorise l'accès au menu
                MessageBox.Show("Success Connexion", "Connexion OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
               controller.Vmodel.import(nomInsp.ToString());
                if (controller.Vmodel.Chargement == true)
                {
                    MessageBox.Show("Success Import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gestionToolStripMenuItem.Visible = true;
                    pDFToolStripMenuItem.Visible = true;
                    btnProfil.Visible = true;
                }


                else MessageBox.Show("Error Import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            controller.Vmodel.seconnecter();
        }

        /// <summary>
        /// On passe en paramètre le nom de l'inspecteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void générerPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerationPDF GPDF = new GenerationPDF(nomInsp.ToString());
            GPDF.Show();
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            index++;
            Profil P = new Profil( nomInsp.ToString(),mdpInsp.ToString(),index);
            P.Show();
            
        }

        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.Vmodel.seconnecter();
            if (!controller.Vmodel.Connopen)//Si la connetion se passe mal on renvoie un message d'erreur
            {
                MessageBox.Show("Erreur de Connexion", "La connexion n'a pu avoir lieu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Connexion réussie", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!controller.Vmodel.export())
                    MessageBox.Show("Erreur Export");
                controller.Vmodel.sedeconnecter();
            }
        }
    }
}
