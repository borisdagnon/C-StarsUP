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
    public partial class Index : Form
    {
        private String nomInsp = "";
        public Index(String nomInsp)
        {
            InitializeComponent();
            gestionToolStripMenuItem.Visible = false;
            pDFToolStripMenuItem.Visible = false;
            this.nomInsp = nomInsp;
        }

        private void listeVisiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeVisite LV = new ListeVisite();
            LV.Show();
        }

       

        private void Index_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            controller.Vmodel.sedeconnecter();
            Connection C = new Connection();
            C.Show();
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controller.init();
            controller.Vmodel.seconnecter();
            if (!controller.Vmodel.Connopen)
            {
                MessageBox.Show("Erreur de Connexion", "La connexion n'a pu avoir lieu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Success Connexion", "Connexion OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
               controller.Vmodel.import(nomInsp.ToString());
                if (controller.Vmodel.Chargement == true)
                {
                    MessageBox.Show("Success Import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gestionToolStripMenuItem.Visible = true;
                    pDFToolStripMenuItem.Visible = true;
                }


                else MessageBox.Show("Error Import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            controller.Vmodel.seconnecter();
        }

        private void générerPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerationPDF GPDF = new GenerationPDF(nomInsp.ToString());
            GPDF.Show();
        }
    }
}
