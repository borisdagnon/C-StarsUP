using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassConnect;
namespace StarsUP
{
    class controller
    {
        private static ClassConnect.Connecter vmodel;

        
        #region assesseurs
        public static ClassConnect.Connecter Vmodel
        {
            get { return controller.vmodel; }
            set { controller.vmodel = value; }
        }
        #endregion

        public static void init()
        {
            vmodel = new Connecter();
        }

       
    }
}
