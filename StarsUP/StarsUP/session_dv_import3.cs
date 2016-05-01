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
   public class session_dv_import3
    {
        #region propriétes;
      private  int idvisite;
      private String nomhebergement;
      private String adressehebergement;
      private int etoille;
        private String datev;

        [XmlAttribute()]
        public int IDVISITE
        {
            get
            {
                return idvisite;
            }

            set
            {
                idvisite = value;
            }
        }

        [XmlAttribute()]
        public string NOMHEBERGEMENT
        {
            get
            {
                return nomhebergement;
            }

            set
            {
                nomhebergement = value;
            }
        }

        [XmlAttribute()]
        public string ADRESSEHEBERGEMENT
        {
            get
            {
                return adressehebergement;
            }

            set
            {
                adressehebergement = value;
            }
        }

        [XmlAttribute()]
        public int ETOILLE
        {
            get
            {
                return etoille;
            }

            set
            {
                etoille = value;
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

      
          
         public session_dv_import3()
         {

         }

        #endregion

    }
}
