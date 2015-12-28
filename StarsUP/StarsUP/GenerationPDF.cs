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
        private String nomInsp = "";
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
        public GenerationPDF(String nomInsp)
        {
            InitializeComponent();
            remplirCb();
            this.nomInsp = nomInsp;
        }

        private void GenerationPDF_Load(object sender, EventArgs e)
        {

        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("");
           
           string res= cbVisites.Text;
            try
            {
                DateTime d = DateTime.Parse(res);
                string final = d.ToString("yyy/MM/dd");
                String requete =controller.Vmodel.import2(nomInsp.ToString(), final.ToString());
                String requete2 = controller.Vmodel.import3(nomInsp.ToString(), final.ToString());
                MessageBox.Show(requete.ToString());
                MessageBox.Show(requete2.ToString());

                try
                {
                    
                    string copyOfOriginal = "H:/Fichiers/PPE4/Planning.pdf"; //Création du document 
                    string imageSRC = "H:/Fichiers/PPE4/C-StarsUP/imagestar.gif"; //Récupération de l'image 
                    iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4); 
                    rec.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageSRC);
                    FileStream fs = new FileStream(copyOfOriginal, FileMode.Create, FileAccess.Write, FileShare.None);
                    
                    Document doc = new Document(rec);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();
                    image.Alignment = Element.ALIGN_TOP;
                    image.Alignment = Element.ALIGN_LEFT;
                    Paragraph para = new Paragraph(requete);
                    Paragraph para2 = new Paragraph(requete2);
                    para.Alignment = Element.ALIGN_JUSTIFIED;
                    para.Alignment = Element.ALIGN_RIGHT;
                    para2.Alignment = Element.ALIGN_JUSTIFIED;
                    para2.Alignment = Element.ALIGN_BOTTOM;
                    para2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(image);
                    doc.Add(para);
                    doc.Add(para2);
                    doc.Close();
                   
                }
               catch(Exception er)
                {
                    MessageBox.Show("Une erreur est survenue lors de la génération du fichier " + er + "", "Erreur Génération", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                
            }
           catch
            {
                MessageBox.Show("Sélectionnez une date");
            }

           
            

            
            
        }

        private void GenerationPDF_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
