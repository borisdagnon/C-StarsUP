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
using System.Text.RegularExpressions;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            int index = 0;
      
            
                //On ne change pas le numéro si il n'est pas bon 
            if (verif_numero(TbNumero.Text) && TbNumero.Text.Count() < 11)
            {
                controller.Vmodel.Dv_inspecteur[index]["NUMEROTEL"] = TbNumero.Text;
                MessageBox.Show(controller.Vmodel.Dv_inspecteur[index]["NUMEROTEL"].ToString());
            }
            else
            {
                MessageBox.Show("Veuillez vérifier le numéro", "Attention", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
                

                controller.Vmodel.Dv_inspecteur[index]["IDINSPECTEUR"] = LbIdentifiant.Text;
                controller.Vmodel.Dv_inspecteur[index]["PRENOMINSPECTEUR"] = TbPrenom.Text;
                controller.Vmodel.Dv_inspecteur[index]["MDPINSPECTEUR"] = TbMdp.Text;
            

            MessageBox.Show("Mise à jour OK", "MAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();//Sert à femer la form

        }

        /// <summary>
        /// Il s'agit d'une expression régulière pour vérifier le numéro de téléphone lorsqu'il change
        /// Si il est correcte on renvoie un message positif sinon un warning et on ne change pas le numéro
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool verif_numero(string num)
        {
            bool ret = false;
            string match = @"^(6|7)[0-9]{8}";
            if (Regex.IsMatch(num, match))
            {
                MessageBox.Show("Numéro de téléphone valide", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ret = true;
            }
            else
            {
                MessageBox.Show("Numéro de téléphone invalide", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            return ret;
        }

     
    }
}
