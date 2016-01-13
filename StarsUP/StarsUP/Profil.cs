using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace StarsUP
{
    public partial class Profil : MetroForm
    {
        String nomInsp;
        String mdpInsp;
        public Profil(String nomInsp,String mdpInsp)
        {
            InitializeComponent();
            this.nomInsp = nomInsp;
            this.mdpInsp = mdpInsp;
            chargerinfo();

        }

        public void chargerinfo()
        {
            String lst = "";
            Int32 Idenifiant = 0;
            String Nom="";
            String Prénom="";
            String Numero="";

            MessageBox.Show(nomInsp.ToString()+"  "+ mdpInsp.ToString());
            lst= controller.Vmodel.infoInspecteur(nomInsp.ToString(),mdpInsp.ToString());
            MessageBox.Show(lst.ToString());
           
            lbNom.Text = Nom.ToString();
            lbPrenom.Text = Prénom.ToString();
        }

    }
}
