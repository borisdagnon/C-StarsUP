using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;


namespace StarsUP
{
    public partial class GenerationPDF : Form
    {
        private BindingSource bindingSource1 = new BindingSource();

        public void remplirCb()
        {
            List<KeyValuePair<int, string>> Flist = new List<KeyValuePair<int, string>>();
            Flist.Add(new KeyValuePair<int, string>(0, "Visites"));
            cbVisites.Items.Add("Visites");

            for (int i = 0; i < controller.Vmodel.Dv_visite.ToTable().Rows.Count; i++)
            {
                
                Flist.Add(new KeyValuePair<int, string>(Convert.ToInt32(controller.Vmodel.Dv_visite.ToTable().Rows[i][0].ToString()),
                controller.Vmodel.Dv_visite.ToTable().Rows[i][6].ToString()));
            }

            //liaison à la combobox
            cbVisites.DataSource = Flist;
            cbVisites.ValueMember = "Key";
            cbVisites.DisplayMember = "Value";
            cbVisites.Text = cbVisites.Items[0].ToString();
            cbVisites.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public GenerationPDF()
        {
            InitializeComponent();
            remplirCb();
        }

        private void GenerationPDF_Load(object sender, EventArgs e)
        {

        }
    }
}
