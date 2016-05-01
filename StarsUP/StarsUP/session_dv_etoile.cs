using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StarsUP
{
    [Serializable]
    public class session_dv_etoile
    {
        int idvisite ;
        String commentairecv ;
        int etoille;
        int idhebergement ;
        Boolean contrevisite;


        #region assesseur:

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

        public string COMMENTAIREV
        {
            get
            {
                return commentairecv;
            }

            set
            {
                commentairecv = value;
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

        public int IDHEBERGEMENT
        {
            get
            {
                return idhebergement;
            }

            set
            {
                idhebergement = value;
            }
        }
        [XmlAttribute()]

        public Boolean CONTREVISITE
        {
            get
            {
                return contrevisite;
            }

            set
            {
                contrevisite = value;
            }
        }

        #endregion

   public session_dv_etoile()
        {
        }
       
    }
}
