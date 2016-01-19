using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace StarsUP
{
    [Serializable]
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

        #region

        
        public Session()
         {

         }

        #endregion

    }
}
