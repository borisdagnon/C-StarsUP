using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace StarsUP
{
    /// <summary>
    /// Cette classe nous permet de serializer le chemin de l'image
    /// </summary>
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
