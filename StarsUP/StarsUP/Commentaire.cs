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
        /// <summary>
        /// Lorsqu'on clic sur ce boutton on modifi dans le dataview les valeurs des champs.
        /// Ici on change l'étoile et le commentaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
           
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
