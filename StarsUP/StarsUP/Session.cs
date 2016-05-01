using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace StarsUP
{
    /// <summary>
    /// Cette classe est comme une session de sauvegarde des informations de l'inspecteur dans la form profil
    /// Elle permet d'éviter de déranger la BDD. Une fois le premier chargement fini les informations sont serialisez et rechargé lors du deuxième clic
    /// sur le bouton Profil
    /// </summary>
    [Serializable]//Pemret de dire que cette classe est serializable
   public class Session
    {
        #region propriétes;
      private  string nomInspecteur;
      private string prenomInspecteur;
      private string numeroInspecteur;
      private string identifiantInspecteur;
        #endregion

        #region assesseurs
        [XmlAttribute()]
        public string NomInspecteur
        {
            get { return nomInspecteur; }
            set { nomInspecteur = value; }
        }

         [XmlAttribute()]
        public string PrenomInspecteur
        {
            get { return prenomInspecteur; }
            set { prenomInspecteur = value; }
        }

         [XmlAttribute()]
        public string NumeroInspecteur
        {
            get { return numeroInspecteur; }
            set { numeroInspecteur = value; }
        }

         [XmlAttribute()]
        public string IndentifiantInspecteur
        {
            get { return identifiantInspecteur; }
            set { identifiantInspecteur = value; }
        }

        #endregion




        #region constructeur;

        
        public Session()
         {

         }

        #endregion

    }
}
