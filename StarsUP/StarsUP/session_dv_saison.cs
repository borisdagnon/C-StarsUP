using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StarsUP
{
    [Serializable]
    public class session_dv_saison
    {
        int identifiant_saison ;
        String nom_saison ;
        String annee_saison ;
        String nom_inspecteur ;

        #region assesseur:
        [XmlAttribute()]
        public int Identifiant_Saison
        {
            get
            {
                return identifiant_saison;
            }

            set
            {
                identifiant_saison = value;
            }
        }
        [XmlAttribute()]

        public string Nom_Saison
        {
            get
            {
                return nom_saison;
            }

            set
            {
                nom_saison = value;
            }
        }
        [XmlAttribute()]

        public string Annee_Saison
        {
            get
            {
                return annee_saison;
            }

            set
            {
                annee_saison = value;
            }
        }

        [XmlAttribute()]
        public string Nom_Inspecteur
        {
            get
            {
                return nom_inspecteur;
            }

            set
            {
                nom_inspecteur = value;
            }
        }
        #endregion
        public session_dv_saison()
        {

        }
    }
}
