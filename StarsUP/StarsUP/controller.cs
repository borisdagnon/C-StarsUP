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

        public static void update(MAJ M,char c)
        {
           
        }

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
        public static void crud_etoile(Char c, String cle)
       {
           int index = 0;
           Commentaire co = new Commentaire();

           if (c == 'u' || c == 'd')
           {
               string sort = "IDVISITE";
               vmodel.Dv_etoile.Sort = sort;
               index=vmodel.Dv_etoile.Find(cle);
               co.TbCommentaire.Text = controller.vmodel.Dv_etoile[index][1].ToString();
               co.TbEtoile.Value =Convert.ToInt32( controller.vmodel.Dv_etoile[index][2]);
               
           }

           co.ShowDialog();

       }
        /// <summary>
        /// Il s'agit d'une expression régulière pour vérifier le numéro de téléphone lorsqu'il change
        /// Si il est correcte on renvoie un message positif sinon un warning et on ne change pas le numéro
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
       
    }
}
