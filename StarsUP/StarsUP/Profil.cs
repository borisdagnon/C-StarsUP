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
using System.IO;
using System.Reflection;
using MySql.Data.MySqlClient;
namespace StarsUP
{
    public partial class Profil : MetroForm
    {
        PictureBox PB;
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;
        String nomInsp;
        String mdpInsp;
        private OpenFileDialog OP;
        private MySqlParameter image;
        public Profil(String nomInsp,String mdpInsp)
        {
            InitializeComponent();
            this.nomInsp = nomInsp;
            this.mdpInsp = mdpInsp;
            chargerinfo();

        }

        public void chargerinfo()
        {
           
            List<String> lesInfos;
            
            MessageBox.Show(nomInsp.ToString()+"  "+ mdpInsp.ToString());
            lesInfos = controller.Vmodel.infoInspecteur(nomInsp.ToString(), mdpInsp.ToString());

           lbIdentifiant.Text = lesInfos[0].ToString();
           lbNom.Text = lesInfos[1].ToString();
           lbPrenom.Text=lesInfos[2].ToString();
           lbNumero.Text = "+33" + lesInfos[3].ToString();

           
                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OP = new OpenFileDialog();
                OP.InitialDirectory = "C:/Picture/";
                OP.Filter = "JPEG|*.jpg|PNG|*.png|GIFs|*.gifs|BMP|*.bmp";
                OP.FilterIndex = 2;
                if (OP.ShowDialog() == DialogResult.OK)
                {
                    FileInfo FI = new FileInfo(OP.FileName);

                    if (FI.Exists)
                    {

                        Image image = Image.FromFile(OP.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        ResizeImage(OP.FileName.ToString());
                        SauvegarderImage();
                      
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void SauvegarderImage()
        {
            if(pictureBox1.Image!=null)
            {
               
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] a = ms.GetBuffer();
                ms.Close();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@image", a);
                cmd.CommandText = "SELECT * from image where IDINSPECTEUR='"+Convert.ToInt32(lbIdentifiant.Text)+"'";
                cn.Open();
                dr = cmd.ExecuteReader();
              
                int count = 0;
                while(dr.Read())
                {
                    count++;
                }

                if(count==1)
                {
                    DialogResult dialogResult = MessageBox.Show("Voulez-vous changer votre photo de profil ?", "Modifier", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        cmd.CommandText = "UPDATE image set nomImage='"+OP.SafeFileName.ToString()+"', image='"+@image+"'";
                       
                        cmd.ExecuteNonQuery();
                        
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Votre image de base a été conservé");
                        dr.Close();
                        chargerImage();
                    }
                  
                }
                else
                {
                   
                    cmd.CommandText = "INSERT INTO image(nomImage,image,IDINSPECTEUR) VALUES('" + OP.SafeFileName.ToString() + "','@image','" + Convert.ToInt32(lbIdentifiant.Text) + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Image Saved", "Ok");
                    pictureBox1.Image = PB.Image;
                }

                cn.Close();
                
            
            }


        }

        private void chargerImage()
        {
            
            try{

                cmd.CommandText="SELECT image from image where IDINSPECTEUR='"+lbIdentifiant.Text.ToString()+"'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder cbd = new MySqlCommandBuilder(da);
            DataSet ds =new DataSet();
            da.Fill(ds);
            cn.Close();
            byte[] ap = (byte[])(ds.Tables[0].Rows[0]["image"]);
            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            ms.Close();
            ms.Dispose();

            }
                 
           
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// Cette méthode sert à redimentionner l'image dans le cadre du picturebox
        /// </summary>
        /// <param name="path"> Il s'agit du chemin du fichier</param>
        private void ResizeImage(string path)
        {
            // réglages des valeurs servant au calcul
            int Lmax = pictureBox1.Width;
            // IMG est le nom de ma pictureBox
            int Hmax = pictureBox1.Height;
 
            Image i = Image.FromFile(path);
            // objet image à partir de l'image choisie
            double ratio = (double) Lmax / Hmax;
     // ratio de base à obtenir pour rentrer correctement dans la picturebox
            double ratioImage = (double) i.Width / i.Height;
    // ratio de l'image d'origine
            double Flng = i.Width;
    // largeur de l'image d'origine
            double Fht = i.Height;
   // hauteur de l'image d'origine
            if (Flng > Lmax || Fht > Hmax) 
  // si l'image est plus grande d'une quelconque longueur
            {
                if (Flng > Lmax) // si la longueur est plus longue
                {
                    if (1 > ratioImage) // et si la largueur est plus longue
                    {
                        Fht = Hmax; // la hauteur prend la hauteur maximale
                        if (Flng > i.Height)Flng = Fht / ratioImage;
 // calcul de la longueur
                        else Flng = Fht * ratioImage;
 // calcul de la longueur (bis)
                    }
                    else // seule la largeur est plus longue
                    {
                        Flng = Lmax; // la largeur prend la largeur maximale
                        if (Fht > i.Width) Fht = Flng / ratioImage;
 // calcul de la hauteur
                        else Fht = Flng / ratioImage;
                    }
            }
            else // seule la largeur est plus longue
            {
                Fht = Hmax;
                Flng = Fht * ratioImage;
            }
                pictureBox1.Image = Image.FromFile(path).GetThumbnailImage
(Convert.ToInt32(Flng),Convert.ToInt32(Fht),null, IntPtr.Zero);
 // j'en tire une miniature
            }
            else pictureBox1.Image = Image.FromFile(path);
 // sinon j'affiche l'image de base
        }

        private void Profil_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = "Database=bd_boris_starsup;Data Source=localhost;User Id=root;";
            cmd.Connection = cn;
           
            image = new MySqlParameter("@image", SqlDbType.Image);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SauvegarderImage();
        }
       

    }
}
