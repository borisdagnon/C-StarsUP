using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StarsUP
{
    [Serializable]
    public class session_dv_departement
    {
        int iddepartement ;
        int numdepartement ;
        String libdepartement ;

        #region
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

        public int NUMDEPARTEMENT
        {
            get
            {
                return numdepartement;
            }

            set
            {
                numdepartement = value;
            }
        }
        [XmlAttribute()]

        public string LIBDEPARTEMENT
        {
            get
            {
                return libdepartement;
            }

            set
            {
                libdepartement = value;
            }
        }
        #endregion

        public session_dv_departement()
        {

        }
    }
}
