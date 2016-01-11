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
            DataTable dt = new DataTable();
            String Nom="";
            String Prénom="";
            dt= controller.Vmodel.infoInspecteur(nomInsp.ToString(),mdpInsp.ToString());
            foreach(DataRow row in dt.Rows)
            {
                 Nom = row["Nom"].ToString();
                 Prénom = row["Prénom"].ToString();
                
            }
            lbNom.Text = Nom.ToString();
            lbPrenom.Text = Prénom.ToString();
        }

    }
}
