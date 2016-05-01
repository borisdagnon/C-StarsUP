using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StarsUP
{
    [Serializable]
    public class session_dv_contrevisite
    {
        int idcontrevisite ;
        int idinspecteur ;
        int idsaison ;
        int idvisite ;
        int iddatev ;
        String commentairecv ;
        int nbetoilemoins ;

        #region assesseur:
        [XmlAttribute()]
        public int IDCONTREVISITE
        {
            get
            {
                return idcontrevisite;
            }

            set
            {
                idcontrevisite = value;
            }
        }
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

        public int IDSAISON
        {
            get
            {
                return idsaison;
            }

            set
            {
                idsaison = value;
            }
        }
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

        public int IDDATEV
        {
            get
            {
                return iddatev;
            }

            set
            {
                iddatev = value;
            }
        }
        [XmlAttribute()]

        public string COMMENTAIRECV
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

        public int NBETOILEMOINS
        {
            get
            {
                return nbetoilemoins;
            }

            set
            {
                nbetoilemoins = value;
            }
        }
        #endregion
        public session_dv_contrevisite()
        {

        }
    }
}
