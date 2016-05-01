using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StarsUP
{
    [Serializable]
    public class session_dv_inspecteur
    {
        int idinspecteur ;
        int idspecialitei ;
        String nominspecteur ;
        String prenominspecteur ;
        int iddepartement ;
        int numerotel ;
        String mdpinspecteur ;

        #region assesseur:
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

        public int IDSPECIALITEI
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

        public int IDDEPARTEMENT
        {
            get
            {
                return iddepartement;
            }

            set
            {
                iddepartement = value;
            }
        }
        [XmlAttribute()]

        public int NUMEROTEL
        {
            get
            {
                return numerotel;
            }

            set
            {
                numerotel = value;
            }
        }
        [XmlAttribute()]

        public string MDPINSPECTEUR
        {
            get
            {
                return mdpinspecteur;
            }

            set
            {
                mdpinspecteur = value;
            }
        }
        #endregion
        public session_dv_inspecteur()
        {

        }
    }
}
