using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StarsUP
{
    [Serializable]
    public class Premiere
    {
        int num;//Permet de savoir s'il s'est déjà connecté une fois
        int importXml ;//Permet de savoir s'il peut effectuer import à partir des fichiers xml

        [XmlAttribute()]
        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        [XmlAttribute()]
        public int ImportXml
        {
            get
            {
                return importXml;
            }

            set
            {
                importXml = value;
            }
        }

        
        

       

        public Premiere()
        {
        }
    }
}
