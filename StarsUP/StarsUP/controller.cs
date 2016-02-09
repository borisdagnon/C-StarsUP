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
        private static ClassConnect.Connecter vmodel;

        
        #region assesseurs;
        public static ClassConnect.Connecter Vmodel
        {
            get { return controller.vmodel; }
            set { controller.vmodel = value; }
        }
        #endregion

        public static void init()
        {
            vmodel = new Connecter();
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
           if (M.DialogResult == DialogResult.OK)
           {


           if(c=='u')
           {
                    //On ne change pas le numéro si il n'est pas bon 
               if(verif_numero(M.TbNumero.Text))
               {
                   vmodel.Dv_inspecteur[index]["NUMEROTEL"] = M.TbNumero.Text;
               }
                   

               vmodel.Dv_inspecteur[index]["IDINSPECTEUR"] = Convert.ToInt32( M.LbIdentifiant.Text);
               vmodel.Dv_inspecteur[index]["PRENOMINSPECTEUR"] = M.TbPrenom.Text;
              
               vmodel.Dv_inspecteur[index]["MDPINSPECTEUR"] = M.TbMdp.Text;
           }

           MessageBox.Show("Mise à jour OK", "MAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
           M.Dispose();//Sert à femer la form

               
           }
           else
           {
               MessageBox.Show("Mise à jour annulée", "MAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
               M.Dispose();
           }
        }
        /// <summary>
        /// Il s'agit d'une expression régulière pour vérifier le numéro de téléphone lorsqu'il change
        /// Si il est correcte on renvoie un message positif sinon un warning et on ne change pas le numéro
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool verif_numero(string num)
       {
           bool ret = false;
           string match = @"^(6|7)[0-9]{8}";
           if (Regex.IsMatch(num, match))
           {
               MessageBox.Show("Numéro de téléphone valide", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
               ret = true;
           }
            else
           {
               MessageBox.Show("Numéro de téléphone invalide", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
           }
           return ret;
       }
    }
}
