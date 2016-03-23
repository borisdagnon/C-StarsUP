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
using MetroFramework.Forms;

namespace StarsUP
{
    /// <summary>
    /// Cette class permet de générer un document PDF grâce au dll iTextSharp
    /// Il faut premièrement sélectionner la date de la visite dans la combobox dont on veut générer le document PDF, puis celui-ci s'ouvre grâce à un logiciel.
    /// On a alors la possibilité de l'imprimer, de l'enregistrer...etc selon ce que permett le logiciel qui l'ouvre.
    /// </summary>
    public partial class GenerationPDF : MetroForm
    {
        private String nomInsp = "";
       
        /// <summary>
        /// Cette méthode charge la combobox, ( List<KeyValuePair<int, string>>) nous permet de récupérer l'identifiant et la chaine de caractère lié
        /// On fait ensuite un for(){} pour pouvoir remplir  la combobox
        /// On fait la liaison après avec 
        /// </summary>
        public void remplirCb()
        {
            List<KeyValuePair<int, string>> Flist = new List<KeyValuePair<int, string>>();
            Flist.Add(new KeyValuePair<int, string>(0, "Visites")); //on ajoute à l'index 0 le string "Visites", c'st donc le premier qu'on verra
            cbVisites.Items.Add("Visites");

            for (int i = 0; i < controller.Vmodel.Dv_visite.ToTable().Rows.Count; i++)
            {
                //On récupère les valeurs qui sont dans le DataView grâce à leurs index ( [ligne][colonne] )
                Flist.Add(new KeyValuePair<int, string>(Convert.ToInt32(controller.Vmodel.Dv_visite.ToTable().Rows[i][0].ToString()),
                controller.Vmodel.Dv_visite.ToTable().Rows[i][6].ToString()));
            }

            //liaison à la combobox
            cbVisites.DataSource = Flist;
            cbVisites.ValueMember = "Key";
            cbVisites.DisplayMember = "Value";
            cbVisites.Text = cbVisites.Items[0].ToString();
            cbVisites.DropDownStyle = ComboBoxStyle.DropDownList; //Comobox de style DropDownList ce qui veut dire pas de possibilité de rajouter à la mains
        }
        /// <summary>
        /// Au chargement de la form GenerationPDF on remplit la listbox
        /// On récupère ensuite le nom de l'inspecteur
        /// </summary>
        /// <param name="nomInsp">Il s'agit du nom de l'inspecteur qui va nous servir à faire la requête d'import des informations liées
        /// à la visite de l'inspecteur</param>
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
                MessageBox.Show(nomInsp + " " + final);
                String requete =controller.Vmodel.import2(nomInsp.ToString(), final.ToString());
                String requete2 = controller.Vmodel.import3(nomInsp.ToString(), final.ToString());
                MessageBox.Show(requete.ToString());
                MessageBox.Show(requete2.ToString());

                
                try
                {
                    
                    
                    string imageSRC = System.IO.Path.GetFullPath("star.gif"); //Récupération de l'image de l'étoile
                    string imageSRCTitre = System.IO.Path.GetFullPath("Titre.png"); //Récupération de l'image du titre
                    string copyOfOriginal = System.IO.Path.GetFullPath("Planning.pdf");//Création du document 

                    iTextSharp.text.Image imageTitre = iTextSharp.text.Image.GetInstance(imageSRCTitre);
                    iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4); //Format dela page pdf
                    rec.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);//Couleur de la page pdf
                    iTextSharp.text.Image imageStarsUP = iTextSharp.text.Image.GetInstance(imageSRC);
                    FileStream fs = new FileStream(copyOfOriginal, FileMode.Create, FileAccess.Write, FileShare.None);
                    
                    Document doc = new Document(rec);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();


                    imageStarsUP.Alignment = Element.ALIGN_TOP;
                    imageStarsUP.Alignment = Element.ALIGN_LEFT;

                    imageTitre.Alignment = Element.ALIGN_TOP;
                    imageTitre.Alignment = Element.ALIGN_MIDDLE;
                    Paragraph para = new Paragraph(requete);
                    
                    Paragraph para2 = new Paragraph(requete2);
                    para.Alignment = Element.ALIGN_JUSTIFIED;
                    para.Alignment = Element.ALIGN_RIGHT;
                    para2.Alignment = Element.ALIGN_JUSTIFIED;
                    para2.Alignment = Element.ALIGN_BOTTOM;
                    para2.Alignment = Element.ALIGN_CENTER;
                    doc.Add(imageTitre);
                    doc.Add(imageStarsUP);
                    
                    doc.Add(para); //Ajout des éléments text ou image
                    doc.Add(para2);
                    doc.Close(); //Fermer le document 
                    MessageBox.Show("Génération OK");
                    System.Diagnostics.Process.Start(copyOfOriginal.ToString());
                   
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
