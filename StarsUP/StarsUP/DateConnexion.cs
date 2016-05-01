using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StarsUP
{
   public class DateConnexion
    {

        DateTime d = new DateTime();

        [XmlAttribute()]
        public DateTime D
        {
            get { return d; }
            set { d = value; }
        }
        public DateConnexion()
        { }

    }
}
