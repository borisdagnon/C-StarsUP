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
using System.Xml.Serialization;
using System.IO;


namespace StarsUP
{
    /// <summary>
    /// Cette form est l'interface qui sert à sélectionner la tâche qu'on veut accomplir
    /// On peut donc consulter la liste des visites, ajouter des étoiles et des commentaires et enfin générer des pdf
    /// </summary>
    public partial class Index : MetroForm
    {
        int index;
        private String nomInsp = "";//Création de la variable afin de récupérer le nom de l'inspecteur pour les requêtes
       private String mdpInsp="";
        /// <summary>
        /// Comme un constructeur on récupère la nom de l'ispecteur et on l'instancie
        /// On met le menu à false pour éviter d'avoir une erreur avant l'importation
        /// </summary>
        /// <param name="nomInsp">Récupération du nom de l'inwpecteur pour la requête</param>
        public Index(String nomInsp,String mdpInsp)
        {
            InitializeComponent();
            gestionToolStripMenuItem.Visible = false;
            pDFToolStripMenuItem.Visible = false;
            this.nomInsp = nomInsp;
            this.mdpInsp=mdpInsp;
            btnProfil.Visible = false;
            index = 0;
        }

        private void listeVisiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListeVisite LV = new ListeVisite();
            LV.Show();
        }

       
        /// <summary>
        /// Cette méthode se décleche lorsqu'on quitte la forme Index sans cliquer sur export.
        /// Elle permet de d'appeler la méthode d'export du boutton export présente plus bas
        /// On crée ensuite une nouvelle forme de connection, qu'on affiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Index_FormClosed(object sender, FormClosedEventArgs e)
        {

            exportToolStripMenuItem_Click(sender, e);
            controller.Vmodel.sedeconnecter();
            Connection C = new Connection();
            C.Show();
        }

        public void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            XmlSerializer serial = new XmlSerializer(typeof(DateConnexion));
            StreamReader lire = new StreamReader("DateConnexion.xml");
            DateConnexion dc = (DateConnexion)serial.Deserialize(lire);
            lire.Close();
            if (dc.D.AddDays(1)==DateTime.Now)
            {
                MessageBox.Show("La session n'est plus valide, vous devez trouver un point de connexion", "Session", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XmlSerializer s = new XmlSerializer(typeof(Premiere));
                StreamReader l = new StreamReader("Premiere.xml");
                Premiere p = (Premiere)s.Deserialize(l);
                l.Close();

                if (p.ImportXml==1)
            {
                    MessageBox.Show("Import à partir des fichiers xml");

                    ImportXml();
               
                gestionToolStripMenuItem.Visible = true;
                pDFToolStripMenuItem.Visible = true;
                btnProfil.Visible = true;


            }
            else
            {
                controller.init();
                controller.Vmodel.seconnecter(); //On se connecte
                if (!controller.Vmodel.Connopen)//Si la connetion se passe mal on renvoie un message d'erreur
                {
                    MessageBox.Show("La connexion n'a pu avoir lieu ", "Erreur de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                else
                {
                    //Sinon on affiche un message et on autorise l'accès au menu
                    MessageBox.Show("Success Connexion", "Connexion OK", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    controller.Vmodel.import(nomInsp.ToString());
                    if (controller.Vmodel.Chargement == true)
                    {
                        MessageBox.Show("Success Import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gestionToolStripMenuItem.Visible = true;
                        pDFToolStripMenuItem.Visible = true;
                        btnProfil.Visible = true;


                    }


                    else MessageBox.Show("Error Import", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
           

        }

        /// <summary>
        /// On passe en paramètre le nom de l'inspecteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void générerPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerationPDF GPDF = new GenerationPDF(nomInsp.ToString());
            GPDF.Show();
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            index++;
            Profil P = new Profil( nomInsp.ToString(),mdpInsp.ToString(),index);
            P.Show();
            
        }

        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
        /// <summary>
        /// Cette méthode se déclenche sous l'action du clic export et permet d'appeler le controleur pour se connecter et pour exporter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.Vmodel.seconnecter();
            if (!controller.Vmodel.Connopen)//Si la connetion se passe mal on renvoie un message d'erreur
            {
                MessageBox.Show("La connexion n'a pu avoir lieu ", "Erreur de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExportXml();
            }
            else
            {
                MessageBox.Show("Connexion réussie", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!controller.Vmodel.export())
                {
                    MessageBox.Show("L'exportation a rencontré un problème", "Erreur Export", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    ExportXml();
                }
                else
                {
                    MessageBox.Show("L'exportation s'est bien effectuée", "Exportation", MessageBoxButtons.OK,MessageBoxIcon.Information);

                    ExportXml();

                   
                }
                //Enfin on se déconnecte après l'export ou l'échec de celui-ci
                controller.Vmodel.sedeconnecter();
            }
        }
        public void ExportXml()
        {
            List<session_dv_departement> l = new List<session_dv_departement>();
            XmlSerializer serial = new XmlSerializer(typeof(List<session_dv_departement>));
            StreamWriter ecrire = new StreamWriter("session_dv_departement.xml", false);

            for (int i = 0; i < controller.Vmodel.Dv_departement.ToTable().Rows.Count; i++)
            {
                session_dv_departement sdd = new session_dv_departement();
                sdd.IDDEPARTEMENT = Convert.ToInt16(controller.Vmodel.Dv_departement[i]["IDDEPARTEMENT"].ToString());
                sdd.LIBDEPARTEMENT = controller.Vmodel.Dv_departement[i]["LIBDEPARTEMENT"].ToString();
                sdd.NUMDEPARTEMENT = Convert.ToInt16(controller.Vmodel.Dv_departement[i]["NUMDEPARTEMENT"].ToString());
                l.Add(sdd);
            }
            serial.Serialize(ecrire, l);


            l.Clear();



            List<session_dv_etoile> l2 = new List<session_dv_etoile>();

            XmlSerializer serial2 = new XmlSerializer(typeof(List<session_dv_etoile>));
            StreamWriter ecrire2 = new StreamWriter("session_dv_etoile.xml", false);
            for (int i = 0; i < controller.Vmodel.Dv_etoile.ToTable().Rows.Count; i++)
            {
                session_dv_etoile sde = new session_dv_etoile();
                sde.COMMENTAIREV = controller.Vmodel.Dv_etoile[i]["COMMENTAIREV"].ToString();
                sde.CONTREVISITE = Convert.ToBoolean(controller.Vmodel.Dv_etoile[i]["CONTREVISITE"]);
                sde.ETOILLE = Convert.ToInt16(controller.Vmodel.Dv_etoile[i]["ETOILLE"].ToString());
                sde.IDHEBERGEMENT = Convert.ToInt16(controller.Vmodel.Dv_etoile[i]["IDHEBERGEMENT"].ToString());
                sde.IDVISITE = Convert.ToInt16(controller.Vmodel.Dv_etoile[i]["IDVISITE"].ToString());

                l2.Add(sde);


            }
            serial2.Serialize(ecrire2, l2);
            l2.Clear();


            List<session_dv_inspecteur> l3 = new List<session_dv_inspecteur>();

            XmlSerializer serial3 = new XmlSerializer(typeof(List<session_dv_inspecteur>));
            StreamWriter ecrire3 = new StreamWriter("session_dv_inspecteur.xml", false);

            for (int i = 0; i < controller.Vmodel.Dv_inspecteur.ToTable().Rows.Count; i++)
            {
                session_dv_inspecteur sdi = new session_dv_inspecteur();
                sdi.IDDEPARTEMENT = Convert.ToInt16(controller.Vmodel.Dv_inspecteur[i]["IDDEPARTEMENT"].ToString());
                sdi.IDINSPECTEUR = Convert.ToInt16(controller.Vmodel.Dv_inspecteur[i]["IDINSPECTEUR"].ToString());
                sdi.IDSPECIALITEI = Convert.ToInt16(controller.Vmodel.Dv_inspecteur[i]["IDSPECIALITEI"].ToString());
                sdi.MDPINSPECTEUR = controller.Vmodel.Dv_inspecteur[i]["MDPINSPECTEUR"].ToString();
                sdi.NOMINSPECTEUR = controller.Vmodel.Dv_inspecteur[i]["NOMINSPECTEUR"].ToString();
                sdi.PRENOMINSPECTEUR = controller.Vmodel.Dv_inspecteur[i]["PRENOMINSPECTEUR"].ToString();
                sdi.NUMEROTEL = Convert.ToInt32(controller.Vmodel.Dv_inspecteur[i]["NUMEROTEL"].ToString());


                l3.Add(sdi);
            }
            serial3.Serialize(ecrire3, l3);
            l3.Clear();


            List<session_dv_saison> l4 = new List<session_dv_saison>();

            XmlSerializer serial4 = new XmlSerializer(typeof(List<session_dv_saison>));
            StreamWriter ecrire4 = new StreamWriter("session_dv_saison.xml", false);

            for (int i = 0; i < controller.Vmodel.Dv_saison.ToTable().Rows.Count; i++)
            {
                session_dv_saison sds = new session_dv_saison();
                sds.Annee_Saison = controller.Vmodel.Dv_saison[i]["Annee_Saison"].ToString();
                sds.Identifiant_Saison = Convert.ToInt16(controller.Vmodel.Dv_saison[i]["Identifiant_Saison"].ToString());
                sds.Nom_Inspecteur = controller.Vmodel.Dv_saison[i]["Nom_Inspecteur"].ToString();
                sds.Nom_Saison = controller.Vmodel.Dv_saison[i]["Nom_Saison"].ToString();
                l4.Add(sds);
            }
            serial4.Serialize(ecrire4, l4);
            l4.Clear();



            List<session_dv_visite> l5 = new List<session_dv_visite>();

            XmlSerializer serial5 = new XmlSerializer(typeof(List<session_dv_visite>));
            StreamWriter ecrire5 = new StreamWriter("session_dv_visite.xml", false);

            for (int i = 0; i < controller.Vmodel.Dv_visite.ToTable().Rows.Count; i++)
            {
                session_dv_visite sdv = new session_dv_visite();
                sdv.Identifiant_Departement = Convert.ToInt16(controller.Vmodel.Dv_visite[i]["Identifiant_Departement"].ToString());
                sdv.Identifiant_Inspecteur = Convert.ToInt16(controller.Vmodel.Dv_visite[i]["Identifiant_Inspecteur"].ToString());
                sdv.Identifiant_Saison = Convert.ToInt16(controller.Vmodel.Dv_visite[i]["Identifiant_Saison"].ToString());
                sdv.Identifiant_Visite = Convert.ToInt16(controller.Vmodel.Dv_visite[i]["Identifiant_Visite"].ToString());
                sdv.Nom_Departement = controller.Vmodel.Dv_visite[i]["Nom_Departement"].ToString();
                sdv.Nom_Hebergement = controller.Vmodel.Dv_visite[i]["Nom_Hebergement"].ToString();
                sdv.Nom_Inspecteur = controller.Vmodel.Dv_visite[i]["Nom_Inspecteur"].ToString();
                sdv.Nom_Saison = controller.Vmodel.Dv_visite[i]["Nom_Saison"].ToString();
                sdv.Prenom_Inspecteur = controller.Vmodel.Dv_visite[i]["Prenom_Inspecteur"].ToString();
                sdv.Adresse_Hebergement = controller.Vmodel.Dv_visite[i]["Adresse_Hebergement"].ToString();
                DateTime res = Convert.ToDateTime(controller.Vmodel.Dv_visite[i]["Date_de_visite"].ToString());
                sdv.Date_de_visite = res.ToShortDateString().ToString();

                sdv.Annee_Date_Visite = controller.Vmodel.Dv_visite[i]["Annee_Date_Visite"].ToString();


                l5.Add(sdv);

            }
            serial5.Serialize(ecrire5, l5);
            l5.Clear();

            /*

            List<session_dv_vm_contrevisite> l6 = new List<session_dv_vm_contrevisite>();

            XmlSerializer serial6 = new XmlSerializer(typeof(List<session_dv_vm_contrevisite>));
            StreamWriter ecrire6 = new StreamWriter("session_dv_vm_contrevisite.xml", false);

            for (int i = 0; i < controller.Vmodel.Dv_vm_contrevisite.ToTable().Rows.Count; i++)
            {
                session_dv_vm_contrevisite sdvc = new session_dv_vm_contrevisite();
                sdvc.Identifiant_Contrevisite = Convert.ToInt16(controller.Vmodel.Dv_vm_contrevisite[i]["Identifiant_Contrevisite"].ToString());
                sdvc.Identifiant_Departement = Convert.ToInt16(controller.Vmodel.Dv_vm_contrevisite[i]["Identifiant_Departement"].ToString());
                sdvc.Identifiant_Inspecteur = Convert.ToInt16(controller.Vmodel.Dv_vm_contrevisite[i]["Identifiant_Inspecteur"].ToString());
                sdvc.Identifiant_Saison = controller.Vmodel.Dv_vm_contrevisite[i]["Identifiant_Saison"].ToString();
                sdvc.Nom_Departement = controller.Vmodel.Dv_vm_contrevisite[i]["Nom_Departement"].ToString();
                sdvc.Nom_Hebergement = controller.Vmodel.Dv_vm_contrevisite[i]["Nom_Hebergement"].ToString();
                sdvc.Nom_Inspecteur = controller.Vmodel.Dv_vm_contrevisite[i]["Nom_Inspecteur"].ToString();
                sdvc.Nom_Saison = controller.Vmodel.Dv_vm_contrevisite[i]["Nom_Saison"].ToString();
                sdvc.Prenom_Inspecteur = controller.Vmodel.Dv_vm_contrevisite[i]["Prenom_Inspecteur"].ToString();
                sdvc.Annee_Date_Visite = controller.Vmodel.Dv_vm_contrevisite[i]["Annee_Date_Visite"].ToString();
                sdvc.Date_de_contrevisite = controller.Vmodel.Dv_vm_contrevisite[i]["Date_de_contrevisite"].ToString();
                sdvc.Date_de_visite = controller.Vmodel.Dv_vm_contrevisite[i]["Date_de_visite"].ToString();
                sdvc.Adresse_Hebergement = controller.Vmodel.Dv_vm_contrevisite[i]["Adresse_Hebergement"].ToString();
                sdvc.Annee_Date_Contrevisite = controller.Vmodel.Dv_vm_contrevisite[i]["Annee_Date_Contrevisite"].ToString();

                l6.Add(sdvc);
            }
            serial6.Serialize(ecrire6, l6);
            l6.Clear();

    */
            List<session_dv_contrevisite> l7 = new List<session_dv_contrevisite>();

            XmlSerializer serial7 = new XmlSerializer(typeof(List<session_dv_contrevisite>));
            StreamWriter ecrire7 = new StreamWriter("session_dv_contrevisite.xml", false);

            for (int i = 0; i < controller.Vmodel.Dv_contrevisite.ToTable().Rows.Count; i++)
            {
                session_dv_contrevisite sdc = new session_dv_contrevisite();
                sdc.COMMENTAIRECV = controller.Vmodel.Dv_contrevisite[i]["COMMENTAIRECV"].ToString();
                sdc.IDCONTREVISITE = Convert.ToInt16(controller.Vmodel.Dv_contrevisite[i]["IDCONTREVISITE"].ToString());
                sdc.IDDATEV = Convert.ToInt16(controller.Vmodel.Dv_contrevisite[i]["IDDATEV"].ToString());
                sdc.IDINSPECTEUR = Convert.ToInt16(controller.Vmodel.Dv_contrevisite[i]["IDINSPECTEUR"].ToString());
                sdc.IDSAISON = Convert.ToInt16(controller.Vmodel.Dv_contrevisite[i]["IDSAISON"].ToString());
                sdc.IDVISITE = Convert.ToInt16(controller.Vmodel.Dv_contrevisite[i]["IDVISITE"].ToString());
                sdc.NBETOILEMOINS = Convert.ToInt16(controller.Vmodel.Dv_contrevisite[i]["NBETOILEMOINS"].ToString());

                l7.Add(sdc);
            }
            serial7.Serialize(ecrire7, l7);
            l7.Clear();

            List<session_dv_import2> l8 = new List<session_dv_import2>();
            XmlSerializer serial8 = new XmlSerializer(typeof(List<session_dv_import2>));
            StreamWriter ecrire8 = new StreamWriter("session_dv_import2.xml", false);

            for (int i = 0; i < controller.Vmodel.Dv_import2.ToTable().Rows.Count; i++)
            {
                session_dv_import2 sdi = new session_dv_import2();
                sdi.DATEV = controller.Vmodel.Dv_import2[i]["DATEV"].ToString();
                sdi.IDINSPECTEUR = Convert.ToInt16(controller.Vmodel.Dv_import2[i]["IDINSPECTEUR"].ToString());
                sdi.NOMINSPECTEUR = controller.Vmodel.Dv_import2[i]["NOMINSPECTEUR"].ToString();
                sdi.PRENOMINSPECTEUR = controller.Vmodel.Dv_import2[i]["PRENOMINSPECTEUR"].ToString();
                l8.Add(sdi);


            }
            serial8.Serialize(ecrire8, l8);
            l8.Clear();

            List<session_dv_import3> l9 = new List<session_dv_import3>();
            XmlSerializer serial9 = new XmlSerializer(typeof(List<session_dv_import3>));
            StreamWriter ecrire9 = new StreamWriter("session_dv_import3.xml", false);

            for (int i = 0; i < controller.Vmodel.Dv_import3.ToTable().Rows.Count; i++)
            {
                session_dv_import3 sdi3 = new session_dv_import3();
                sdi3.IDVISITE = Convert.ToInt16(controller.Vmodel.Dv_import3[i]["IDVISITE"].ToString());
                sdi3.NOMHEBERGEMENT = controller.Vmodel.Dv_import3[i]["NOMHEBERGEMENT"].ToString();
                sdi3.ETOILLE = Convert.ToInt16(controller.Vmodel.Dv_import3[i]["ETOILLE"].ToString());
                sdi3.DATEV = controller.Vmodel.Dv_import3[i]["DATEV"].ToString();
                l9.Add(sdi3);


            }
            serial8.Serialize(ecrire8, l8);
            l8.Clear();

            ecrire.Close();
            ecrire2.Close();
            ecrire3.Close();
            ecrire4.Close();
            ecrire5.Close();
         /*   ecrire6.Close();*/
            ecrire7.Close();
            ecrire8.Close();
            ecrire9.Close();
        }
        public void ImportXml()
        {


           
            DataSet ds = new DataSet();
            ds.ReadXml("session_dv_departement.xml");
            controller.Vmodel.Dv_departement = ds.Tables[0].DefaultView;
           


            DataSet ds1 = new DataSet();
            ds1.ReadXml("session_dv_etoile.xml");
            controller.Vmodel.Dv_etoile = ds1.Tables[0].DefaultView;




            DataSet ds2 = new DataSet();
            ds2.ReadXml("session_dv_inspecteur.xml");
            controller.Vmodel.Dv_inspecteur = ds2.Tables[0].DefaultView;



            DataSet ds3 = new DataSet();

            ds3.ReadXml("session_dv_saison.xml");
            controller.Vmodel.Dv_saison = ds3.Tables[0].DefaultView;




            DataSet ds4 = new DataSet();
            ds4.ReadXml("session_dv_visite.xml");
            controller.Vmodel.Dv_visite = ds4.Tables[0].DefaultView;


            

            DataSet ds5 = new DataSet();
            try
            {
                ds5.ReadXml("session_dv_vm_contrevisite.xml");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            try
            {
                controller.Vmodel.Dv_vm_contrevisite = ds5.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Il n'y a pas de contre visite");
            }




            DataSet ds6 = new DataSet();
            ds6.ReadXml("session_dv_contrevisite.xml");
            controller.Vmodel.Dv_contrevisite = ds6.Tables[0].DefaultView;
            

     /*   
     
            Il ne faut pas faire ça si on veut concerver les données
            ds.Clear();
            ds.Dispose();
            ds1.Clear();
            ds1.Dispose();
            ds2.Clear();
            ds2.Dispose();
            ds3.Clear();
            ds3.Dispose();
            ds4.Clear();
            ds4.Dispose();
            ds5.Clear();
            ds5.Dispose();
            ds6.Clear();
            ds6.Dispose();
            */

        }
        private void listeContreVisitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContreVisites cv = new ContreVisites();
                cv.Show();
        }
    }
}
