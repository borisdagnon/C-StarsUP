using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StarsUP
{
    [Serializable]
    public class session_dv_visite
    {
        int identifiant_visite ;
        int identifiant_inspecteur;
        String nom_inspecteur ;
        String prenom_inspecteur ;
        String nom_hebergement ;
        String adresse_hebergement ;
        String date_de_visite ;
        int identifiant_saison ;
        int identifiant_departement ;
        String nom_departement ;
        String nom_saison ;
        String annee_date_Visite ;

        #region assesseur:

        [XmlAttribute()]
        public int Identifiant_Visite
        {
            get
            {
                return identifiant_visite;
            }

            set
            {
                identifiant_visite = value;
            }
        }
        [XmlAttribute()]

        public int Identifiant_Inspecteur
        {
            get
            {
                return identifiant_inspecteur;
            }

            set
            {
                identifiant_inspecteur = value;
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
        [XmlAttribute()]

        public string Prenom_Inspecteur
        {
            get
            {
                return prenom_inspecteur;
            }

            set
            {
                prenom_inspecteur = value;
            }
        }
        [XmlAttribute()]

        public string Nom_Hebergement
        {
            get
            {
                return nom_hebergement;
            }

            set
            {
                nom_hebergement = value;
            }
        }
        [XmlAttribute()]

        public string Adresse_Hebergement
        {
            get
            {
                return adresse_hebergement;
            }

            set
            {
                adresse_hebergement = value;
            }
        }
        [XmlAttribute()]

        public string Date_de_visite
        {
            get
            {
                return date_de_visite;
            }

            set
            {
                date_de_visite = value;
            }
        }
       
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

        public int Identifiant_Departement
        {
            get
            {
                return identifiant_departement;
            }

            set
            {
                identifiant_departement = value;
            }
        }
        [XmlAttribute()]

        public string Nom_Departement
        {
            get
            {
                return nom_departement;
            }

            set
            {
                nom_departement = value;
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

        public string Annee_Date_Visite
        {
            get
            {
                return annee_date_Visite;
            }

            set
            {
                annee_date_Visite = value;
            }
        }
        #endregion
        public session_dv_visite()
        {

        }
    }
}
