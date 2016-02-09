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
    public partial class MAJ : MetroForm
    {
        public MAJ()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MAJ_Load(object sender, EventArgs e)
        {
            tbNom.ReadOnly = true;
            tbPrenom.ReadOnly = true;
            tbNumero.ReadOnly = true;
            tbMdp.ReadOnly = true;
        }

      

        private void btnReset_Click(object sender, EventArgs e)
        {
            chbMdp.Checked = false;
            chbNumero.Checked = false;
            chbPrenom.Checked = false;
        }

        private void chbPrenom_CheckedChanged(object sender, EventArgs e)
        {
            if(chbPrenom.Checked)
            {
                tbPrenom.ReadOnly = false;
            }
            else
            {
                tbPrenom.ReadOnly = true;
            }
        }

        private void chbNumero_CheckedChanged(object sender, EventArgs e)
        {
            if(chbNumero.Checked)
            {
                tbNumero.ReadOnly = false;
            }
            else
            {
                tbNumero.ReadOnly = true;
            }
        }

        private void chbMdp_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMdp.Checked)
            {
                tbMdp.ReadOnly = false;
            }
            else
                tbMdp.ReadOnly = true;
        }

       

     
    }
}
