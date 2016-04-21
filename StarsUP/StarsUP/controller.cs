using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassConnect;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions; //Lien avec la class ClassConnect
namespace StarsUP
{
    class controller
    {
        /// <summary>
        /// Ce controleur nous permet d'avoir un lien avec la BDD pour les reqêtes, qui elles sont situées dans la class Connecter
        /// qui n'est pas dans ce fichier sln. On a par contre importé la dll ClassConnect qui nous permet de faire le lien
        /// </summary>
        private static Connecter vmodel;

        
        #region assesseurs;
        public static Connecter Vmodel
        {
            get { return controller.vmodel; }
            set { controller.vmodel = value; }
        }
        #endregion

        public static void init()
        {
            vmodel = new Connecter();
        }

       

        /// <summary>
        /// Cette méthode crud personne permet de charger les informations de l'inspecteur dans les textbox respectives
        /// Elle a besoin d'un caractèere et d'un clé pour savoir quoi faire
        /// </summary>
        /// <param name="c">Correspond au caractère u=update,d=delete,c=create</param>
        /// <param name="cle">Cette clé correspond à l'identifiant de l'inspecteur</param>
       public static void crud_Inspecteur(Char c, String cle)
        {
            int index = 0;
            MAJ M = new MAJ();
           if(c=='u'||c=='d')
           {
              string sort="IDINSPECTEUR";
              vmodel.Dv_inspecteur.Sort=sort;
               vmodel.Dv_inspecteur.Find(cle);
               M.LbIdentifiant.Text=controller.vmodel.Dv_inspecteur[index][1].ToString();
               M.TbNom.Text = controller.vmodel.Dv_inspecteur[index][2].ToString();
               M.TbPrenom.Text = controller.Vmodel.Dv_inspecteur[index][3].ToString();
               M.TbNumero.Text = controller.vmodel.Dv_inspecteur[index][5].ToString();
               M.TbMdp.Text=controller.vmodel.Dv_inspecteur[index][6].ToString();
           }

           M.ShowDialog();
          
        }
        /// <summary>
        /// Cette méthode permet de charger les information liées au commentaire et à l'étoile dans une richtextbox pour le commentaire et une trackb
        /// </summary>
        /// <param name="c">Correspond au caractère u=update,d=delete,c=create</param>
        /// <param name="cle">Correspond à la clé de l'identifiant de visite</param>
        public static void crud_etoile(Char c, String cle)
       {
           int index = 0;
           Commentaire co = new Commentaire();

           if (c == 'u' || c == 'd')
           {
                try
                {
                    string sort = "IDVISITE";
                    vmodel.Dv_etoile.Sort = sort;
                    index = vmodel.Dv_etoile.Find(cle);
                    co.TbCommentaire.Text = controller.vmodel.Dv_etoile[index][1].ToString();
                    co.TbEtoile.Value = Convert.ToInt16(controller.vmodel.Dv_etoile[index][2].ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Vérifiez dans la BDD que cette visite est présente dans la table historique");
                }

            }


            co.ShowDialog();
            if(co.DialogResult== DialogResult.OK)
            {
                string val = "1";
                controller.Vmodel.Dv_etoile[index]["COMMENTAIREV"] =  co.TbCommentaire.Text.ToString();
                controller.Vmodel.Dv_etoile[index]["ETOILLE"] = Convert.ToInt16(co.TbEtoile.Value.ToString());
                if (co.ChbContreVisite.Checked == true)
                {
                    controller.Vmodel.Dv_etoile[index]["CONTREVISITE"] = Convert.ToInt16(val);
                }
                MessageBox.Show("Les données ont été mises à jour", "Mise à Jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("Annulation : aucune donnée enregistrée");
                co.Dispose();
            }
        }


        public static void crud_contrevisite(Char c,String cle)
        {
            int index = 0;
            Commentaire_Contre_Visite ccv = new Commentaire_Contre_Visite();

            if (c == 'u' || c == 'd')
            {
                string sort = "IDCONTREVISITE";
                vmodel.Dv_contrevisite.Sort = sort;
                index = vmodel.Dv_contrevisite.Find(cle);
                ccv.TbCommentaire.Text = controller.vmodel.Dv_contrevisite[index][5].ToString();
                ccv.TbEtoile.Value = Convert.ToInt16(controller.vmodel.Dv_contrevisite[index][6].ToString());


            }


            ccv.ShowDialog();
            if (ccv.DialogResult == DialogResult.OK)
            {
               
                controller.Vmodel.Dv_contrevisite[index]["COMMENTAIRECV"] = ccv.TbCommentaire.Text.ToString();
                controller.Vmodel.Dv_contrevisite[index]["NBETOILEMOINS"] = Convert.ToInt16(ccv.TbEtoile.Value.ToString());
               
                MessageBox.Show("Les données ont été mises à jour", "Mise à Jour", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Annulation : aucune donnée enregistrée");
                ccv.Dispose();
            }
        }
       
       
    }
}
