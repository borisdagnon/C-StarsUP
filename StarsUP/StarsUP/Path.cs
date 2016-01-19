using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace StarsUP
{
     [Serializable]
   public class Path
    {
         [XmlAttribute()]
        private string path = "";

        public string Path1
        {
            get { return path; }
            set { path = value; }
        }


        public Path()
        {

        }
    }
}
