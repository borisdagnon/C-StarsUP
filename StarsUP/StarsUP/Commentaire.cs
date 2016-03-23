using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarsUP
{
    public partial class Commentaire : Form
    {
        public Commentaire()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tbEtoile.Maximum = 5;
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            int index=0;
            string n = controller.Vmodel.Dv_visite[index]["Identifiant_Visite"].ToString();
            string Filter = "IDVISITE='" + n + "'";
            controller.Vmodel.Dv_etoile.RowFilter = Filter;

            controller.Vmodel.Dv_etoile[index]["COMMENTAIREV"] = tbCommentaire.Text;
            controller.Vmodel.Dv_etoile[index]["ETOILLE"] = Convert.ToInt16(tbEtoile.Value);
            MessageBox.Show("Les données ont été mises à jour", "Mise à Jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }
    }
}
