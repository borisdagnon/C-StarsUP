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
   public class session_dv_import2
    {
        #region propriétes;
      private  int idinspecteur;
      private String prenominspecteur;
      private String nominspecteur;
      private String datev;
        [XmlAttribute()]
        public int IDINSPECTEUR
        {
            get
            {
                return idinspecteur;
            }

            set
            {
                idinspecteur = value;
            }
        }
        [XmlAttribute()]
        public string PRENOMINSPECTEUR
        {
            get
            {
                return prenominspecteur;
            }

            set
            {
                prenominspecteur = value;
            }
        }
        [XmlAttribute()]
        public string NOMINSPECTEUR
        {
            get
            {
                return nominspecteur;
            }

            set
            {
                nominspecteur = value;
            }
        }
        [XmlAttribute()]
        public string DATEV
        {
            get
            {
                return datev;
            }

            set
            {
                datev = value;
            }
        }
        #endregion

        #region assesseurs
  
        
        #endregion




        #region constructeur;


         public session_dv_import2()
         {

         }

        #endregion

    }
}
