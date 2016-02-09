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
using System.Xml.Serialization;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
namespace StarsUP
{
    public partial class Profil : MetroForm
    {
        List<String> lesInfos = new List<String>();
        PictureBox PB;
        MySqlConnection cn = new MySqlConnection();//Connection pour les requêtes 
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;
        String nomInsp;
        String mdpInsp;
        int nbClic;//Cette variable sert à connaître le nombre de clic qu'il y a eu sur le bouton Profil dans Index
        private OpenFileDialog OP;
        private MySqlParameter image;
        MySqlDataAdapter sda;
        public string cheminComplet;//Chemin complet pour les requêtes et pour la serialisation
        int clicImage=0;//Cette variable sert à compter le nombre de fois qu'on clic sur l'image afin d'ouvrir la connection ou de la fermer
        String nomplusExtension = "";
        /// <summary>
        /// Je récupère ici les valeurs envoyé depuis la form Index
        /// </summary>
        /// <param name="nomInsp">Nom de l'inspecteur</param>
        /// <param name="mdpInsp">Mot de passe de l'inspecteur</param>
        /// <param name="nbClic">Nombre de clic sur le bouton Profil</param>
        public Profil(String nomInsp,String mdpInsp,int nbClic)
        {
            InitializeComponent();
            
           
            this.nomInsp = nomInsp;
            this.mdpInsp = mdpInsp;
            this.nbClic = nbClic;
            
            chargerinfo();
 
        }

        public void chargerinfo()
        {
           

           //Si c'est la première fois qu'il accède à cette form depuis la connection alors on charge les données depuis la BDD 
        if(nbClic==1)
        {
            lesInfos = controller.Vmodel.infoInspecteur(nomInsp.ToString(), mdpInsp.ToString());
            Session s = new Session{
            
            IndentifiantInspecteur = lbIdentifiant.Text = lesInfos[0].ToString(),
            NomInspecteur = lbNom.Text = lesInfos[1].ToString(),
            PrenomInspecteur = lbPrenom.Text = lesInfos[2].ToString(),
            NumeroInspecteur = lbNumero.Text = "+33" + lesInfos[3].ToString()
            };
               
            //On procède ensuite à une serialisation pour pouvoir enregistrer les données dans le fichier xml.
            
           

         //On crée une instance de XmlSerializer dans lequel on lui spécifie le type
         //de l'objet à sérialiser. On utiliser l'opérateur typeof pour cela.
         XmlSerializer serial = new XmlSerializer(typeof(Session));


         //Création d'un Stream Writer qui permet d'écrire dans un fichier. On lui spécifie le chemin
         //et si le flux devrait mettre le contenu à la suite de notre document (true) ou s'il devrait
         //l'écraser (false).
         StreamWriter ecrire = new StreamWriter("Session.xml", false);


            //On spécifi ici la flux d'écriture ainsi que l'objet à serializer
         serial.Serialize(ecrire, s);

            //On ferme ensuite le flux
         ecrire.Close();

        }
        else
        {
            //On deserialize pour récupérer les données de l'inspecteur 
            XmlSerializer serial = new XmlSerializer(typeof(Session));

            StreamReader lire = new StreamReader("Session.xml");


            //Comme cette métthode renvoie un objet il faut trastyper(caster) le retour
            Session s = (Session)serial.Deserialize(lire);
            lire.Close();

           lbIdentifiant.Text= s.IndentifiantInspecteur;
               lbNom.Text= s.NomInspecteur;
                   lbPrenom.Text= s.PrenomInspecteur;
                   lbNumero.Text = s.NumeroInspecteur ;
        }
            

           
                
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            clicImage++;
            try
            {
                OP = new OpenFileDialog();
                OP.InitialDirectory = "C:/Picture/";
                OP.Filter = "JPEG|*.jpg|PNG|*.png|GIFs|*.gifs|BMP|*.bmp";
                OP.FilterIndex = 1;
                if (OP.ShowDialog() == DialogResult.OK)
                {
                    FileInfo FI = new FileInfo(OP.FileName);

                    if (FI.Exists)
                    {

                        Image image = Image.FromFile(OP.FileName);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        ResizeImage(OP.FileName.ToString());
                        nomplusExtension = OP.SafeFileName.ToString();
                    
                        cheminComplet = OP.FileName;
                       
                        SauvegarderImage();
                      
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                cn.Close();
            }

        }
        /// <summary>
        /// Cette méthode définit le chemin à utilisé, car dans le fichier xml le double slash n'est pas traduit en simple slash mais bien en double ce qui pose un
        /// problème lors de la récupération du chemin
        /// </summary>
        /// <param name="param">booléen qui nous permet de savoir si c'est un cheminpour la requêe ou pour le fichier xml</param>
        /// <returns></returns>
        public string verifChemin(Char param)
        {
            string chemin = "";
            string remplace="";
            if (param.Equals('R'))
            {
               
                string path = @"C:\\StarsUP\\Images\\" + remplace;
                string cheminComplet = path.ToString();
                 chemin = cheminComplet.ToString();
            }
            else 
            {
                if (param.Equals('X'))
                {
                    string path = @"C:\StarsUP\Images\" + nomplusExtension.ToString();
                    string cheminComplet = path.ToString();
                    chemin = cheminComplet.ToString();
                }
                else
                {
                    string path = @"C:\StarsUP\Images\";
                    string cheminComplet = path.ToString();
                    chemin = cheminComplet.ToString();
                }
            }

          
            return chemin.ToString();

        }


      /// <summary>
      /// Cette méthode nous permet de sauvegarder l'image de l'inspecteur
      /// Si c'est un inspecteur qui 
      /// 
      /// Si c'est sa première fois on enregistre l'image dans le deuxième else
      /// </summary>
        private void SauvegarderImage()
        {
            if(pictureBox1.Image!=null)
            {
              
                
                cmd.Parameters.Clear();
             
                cmd.CommandText = "SELECT * from image where IDINSPECTEUR='"+Convert.ToInt32(lbIdentifiant.Text)+"'";
                
                
                    cn.Open();
                
                    
               
                
                dr = cmd.ExecuteReader();
              
                int count = 0; //Cette variable va nous permettre de compter le nombre de résultat de la reqête
                while(dr.Read())
                {
                    count++;
                }
                dr.Close();
                if(count==1)//Si il a déjà une image on lui demande s'il veut changer si oui alors on change le nom et le chemin, sans oublier d'enregistrer la nouvelle image
                    //et ne oublier aussi la serialization du chemin car celui-ci change aussi.
                {
                    DialogResult dialogResult = MessageBox.Show("Voulez-vous changer votre photo de profil ?", "Modifier", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        
                        cmd.CommandText = "UPDATE image set nomImage='"+OP.SafeFileName.ToString()+"', pathImage='"+verifChemin('R').ToString()+"'";
                       
                        cmd.ExecuteNonQuery();//Ceci permet d'exécuter la requête, ne pas oublier qu'on peut faire ça seulementt quand cn (la connexion) est ouverte sinon une erreur intervient

                        MessageBox.Show("Votre image a été modifié", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        XmlSerializer cheminPrecedent = new XmlSerializer(typeof(Path));
                        StreamReader lirecheminPrecedent = new StreamReader("CheminImage.xml");
                        Path pathCheminPrecedent = (Path)cheminPrecedent.Deserialize(lirecheminPrecedent);
                        
                        lirecheminPrecedent.Close();
                        
                        File.Delete(pathCheminPrecedent.Path1);
       //On remplace ensuite l'image
                        File.Copy(cheminComplet, verifChemin('X').ToString());
  //On procède à une sérialization dans le fichier CheminImage.xml
                        Path chemin = new Path { Path1 = verifChemin('X').ToString() }; //On met false en paramètre pour lui dire qu'il ne s'agit pas d'un chemin pour la base de donnée
                        XmlSerializer serial = new XmlSerializer(typeof(Path));
                        StreamWriter ecrire = new StreamWriter("CheminImage.xml", false);
                        serial.Serialize(ecrire, chemin);
                        //On n'oubli pas de fermer le serializer sinon il y aura des problèmes
                        ecrire.Close();

                        //On ne doit pas trop déranger la base de donnée donc il est préférable de récupérer le chemin enregistré dans le document xml
                        XmlSerializer serial2 = new XmlSerializer(typeof(Path));
                        StreamReader lire = new StreamReader("CheminImage.xml");
                        Path p = (Path)serial2.Deserialize(lire);
                        lire.Close();

                        pictureBox1.Image = Image.FromFile(p.Path1.ToString());
                      
                    }
                    else 
                    {
                        MessageBox.Show("Votre image de base a été conservé","Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Close();
                        chargerImage();//On charge l'image qu'il avait déjà
                        cmd.Dispose();
                    }
                  
                }
                else
                {
                    MessageBox.Show(verifChemin('X').ToString());
                   
                    //On copie le fichier dans le chemin qu'on récupère plus haut
                    File.Copy(cheminComplet, verifChemin('X').ToString());
                    //On effectue la requête d'insertion avec en paramètre le nom de l'image le chemin et l'identifiant de l'inspecteur
                    cmd.CommandText = "INSERT INTO image(nomImage,pathImage,IDINSPECTEUR) VALUES('" + OP.SafeFileName.ToString() + "','"+verifChemin('R').ToString()/*On met true parce que c'est une requête */+"','" + Convert.ToInt32(lbIdentifiant.Text) + "')";
                    cmd.ExecuteNonQuery();
                    //On renvoie un message pour spécifié que l'enregistrement s'est bien effectué
                    MessageBox.Show("Image Saved", "Ok");

                    //On procède à une sérialization dans le fichier CheminImage.xml
                    Path chemin = new Path { Path1=verifChemin('X').ToString()};
                    XmlSerializer serial = new XmlSerializer(typeof(Path));
                    StreamWriter ecrire = new StreamWriter("CheminImage.xml", false);
                    serial.Serialize(ecrire, chemin);
                    //On n'oubli pas de fermer le serializer
                    ecrire.Close();
                    //Comme c'est sa premier image on lui remet son image selectionné
                    pictureBox1.Image = Image.FromFile(verifChemin('X').ToString());

                }
                //On ferme  la connexion
                cn.Close();
                
            
            }


        }

        /// <summary>
        /// Cette méthode remplit un DataTable grâce à une requête effecuté par un MySqlDataAdapter
        /// Une fois la reqête exécuté, on va chercher dans le DataTable le chemin de l'image de l'inspecteur
        /// </summary>
        private void chargerImage()
        {
            
            try{

                sda = new MySqlDataAdapter("SELECT pathImage from image where IDINSPECTEUR='" + lbIdentifiant.Text.ToString() + "'", cn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                pictureBox1.Image = Image.FromFile(dt.Rows[0]["pathImage"].ToString());
                sda.Dispose();
                dt.Dispose();

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
        public void ResizeImage(string path)
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
                //On charge l'ancienne image à partir du chemin passé en paramètre de la méthode
                pictureBox1.Image = Image.FromFile(path).GetThumbnailImage (Convert.ToInt32(Flng),Convert.ToInt32(Fht),null,IntPtr.Zero);
               
 // j'en tire une miniature
            }
            //Même principe si on atterit ici, on récupère l'image à partir du chemin passé en paramètre de la méthode
            else pictureBox1.Image = Image.FromFile(path);
 // sinon j'affiche l'image de base
        }



       

        private void Profil_Load(object sender, EventArgs e)
        {
            Int16 result = 0;
            cn.ConnectionString = "Database=bd_boris_starsup;Data Source=localhost;User Id=root;";
            cmd.Connection = cn;
            try
            {
                string Dossier = @"C:\StarsUP";
                string SousDossier = System.IO.Path.Combine(Dossier, "Images");

                if (!Directory.Exists(SousDossier))
                {
                    Directory.CreateDirectory(SousDossier);
                }
                else
                    MessageBox.Show("Le chemin pour l'avatar existe déjà");

                XmlSerializer serial = new XmlSerializer(typeof(Path));
                StreamReader lire = new StreamReader("CheminImage.xml");
                Path p = (Path)serial.Deserialize(lire);
                lire.Close();
                if(File.Exists(p.Path1))
                {
                    pictureBox1.Image = NonLockingOpen(p.Path1);
                }
                else
                
                {
                    try
                    {
                        
                        pictureBox1.Image = null;
                        cmd.CommandText = "SELECT * FROM image WHERE IDINSPECTEUR=" + lbIdentifiant.Text + "";
                       
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        while(dr.Read())
                        {
                            result++;
                        }
                        if (result >= 1)
                        {
                            cmd.CommandText = "DELETE FROM image WHERE IDINSPECTEUR=" + lbIdentifiant.Text + "";
                            cmd.ExecuteNonQuery();
                        }
                            
                        cn.Close();

                    }
                    catch(Exception ex )
                    {
                        MessageBox.Show(ex.ToString());
                    }


                }
              

            }
            
            catch(Exception ex)
            {
                MessageBox.Show("Bonjour " + nomInsp.ToString() +",pensez à changer votre avatar, ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SauvegarderImage();
        }

        private void Profil_FormClosing(object sender, FormClosingEventArgs e)
        {
            cmd.Dispose();
            cn.Close();
            lesInfos.Clear();
        }
       
        public static Image NonLockingOpen(string filename)
        {
            Image result;

            long size = (new FileInfo(filename)).Length;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[size];
            try
            {
                fs.Read(data, 0, (int)size);

            }
            finally { 
                fs.Close(); fs.Dispose(); 
            }

            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, (int)size);
            result = new Bitmap(ms);
          result=  Image.FromStream(ms).GetThumbnailImage(Convert.ToInt32(122), Convert.ToInt32(67), null, IntPtr.Zero);
              
            ms.Close();
            return result;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            controller.crud_Inspecteur('u', lbIdentifiant.Text.ToString());

        }

       



    }
}
