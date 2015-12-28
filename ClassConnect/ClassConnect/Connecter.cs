using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
namespace ClassConnect
{
    public class Connecter
    {
        #region propriétés
        public static MySqlConnection myConnection;
        private bool connopen = false;
        private char vaction, vtable;
        private ArrayList rapport = new ArrayList();
        private static bool errgrave = false;
        private bool chargement = false;



        private MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
        private DataTable dt = new DataTable();

        private DataSet dataSet = new DataSet();
        

        private DataView dv_visite = new DataView(), dv_departement = new DataView(), dv_saison = new DataView(), dv_pdf = new DataView();

       


        #endregion

        #region assesseurs:
        public DataView Dv_pdf
        {
            get { return dv_pdf; }
            set { dv_pdf = value; }
        }
        public bool Connopen
        {
            get { return connopen; }

        }
        private bool errmaj = false;

        public bool Errmaj
        {
            get { return errmaj; }
            set { errmaj = value; }
        }
        public char Vtable
        {
            get { return vtable; }
            set { vtable = value; }
        }

        public char Vaction
        {
            get { return vaction; }
            set { vaction = value; }
        }
        public ArrayList Rapport
        {
            get { return rapport; }
            set { rapport = value; }
        }
        public bool Chargement
        {
            get { return chargement; }

        }
        public static bool Errgrave
        {
            get { return Connecter.errgrave; }
            set { Connecter.errgrave = value; }
        }
        public DataView Dv_saison
        {
            get { return dv_saison; }
            set { dv_saison = value; }
        }

        public DataView Dv_departement
        {
            get { return dv_departement; }
            set { dv_departement = value; }
        }

        public DataView Dv_visite
        {
            get { return dv_visite; }
            set { dv_visite = value; }
        }
        #endregion

        #region méthodes:

        public void seconnecter()
        {
            string myConnectionString = "Database=bd_boris_starsup;Data Source=localhost;User Id=root;";
            myConnection = new MySqlConnection(myConnectionString);
            connopen = true;
            try //tentative
            {
                myConnection.Open();
            }
            catch (Exception err) //gestion des erreurs
            {
                connopen = false;
                errgrave = true;
            }
        }

        public void sedeconnecter()
        {
            if (!connopen)
                return;
            try
            {
                myConnection.Close();
                myConnection.Dispose();
                connopen = false;
            }
            catch (Exception err)
            {

                errgrave = true;
            }
        }

        public String import2(String nomInsp, String date)
        {
            StringBuilder sb2 = new StringBuilder("");


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM inspecteur i INNER JOIN visite v ON i.IDINSPECTEUR=v.IDINSPECTEUR");
            sb.Append(" INNER JOIN hebergement h ON v.IDHEBERGEMENT=h.IDHEBERGEMENT");
            sb.Append(" INNER JOIN datev dv ON v.IDDATEV=dv.IDDATEV ");
            sb.Append("INNER JOIN historique his ON h.IDHEBERGEMENT=his.IDHEBERGEMENT");
            sb.Append(" INNER JOIN specialite s ON i.IDSPECIALITEI=s.IDSPECIALITE WHERE v.IDINSPECTEUR=");
            sb.Append(" (SELECT i.IDINSPECTEUR FROM inspecteur WHERE NOMINSPECTEUR='" + nomInsp.ToString() + "') AND DATEV='" + date.ToString() + "'");
            
             MySqlDataReader dr;
      
            MySqlCommand cmd = new MySqlCommand(sb.ToString(), myConnection);
           
            try
            {
                dr = cmd.ExecuteReader();
               

                if(dr.HasRows)
                {
                     //lecture de ta table
                    
                        while (dr.Read())
                        {
                                sb2 = sb2.Append("Numéro Inspecteur :  " + (dr.GetString(0)) + "\n");
                                sb2 = sb2.Append("\n");
                                sb2.Append("Prénom Inspecteur :  "+ (dr.GetString(3))+"\n");
                                sb2 = sb2.Append("\n");
                                sb2 = sb2.Append("Nom Inspecteur :  " + (dr.GetString(2))+"\n");
                                sb2 = sb2.Append("\n");
                            try
                            {
                                DateTime d = Convert.ToDateTime( dr.GetString(21));
                                string finaldate = d.ToString("dd/MM/yyyy");
                                sb2 = sb2.Append("Date Visite :  " + (finaldate.ToString()) + "");
                            }
                            catch (Exception err)
                            {
                                errgrave = true;
                            }
                           
                            
                                
                            
                            dr.Read();


                        
                    }
                }
                dr.NextResult();
                dr.Close();
            }
            catch (Exception err)
            {
                errgrave = true;
               
            }

            return sb2.ToString();

        }

        public String import3(String nomInsp, String date)
        {
            StringBuilder sb2 = new StringBuilder("");


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM inspecteur i INNER JOIN visite v ON i.IDINSPECTEUR=v.IDINSPECTEUR");
            sb.Append(" INNER JOIN hebergement h ON v.IDHEBERGEMENT=h.IDHEBERGEMENT");
            sb.Append(" INNER JOIN datev dv ON v.IDDATEV=dv.IDDATEV ");
            sb.Append("INNER JOIN historique his ON h.IDHEBERGEMENT=his.IDHEBERGEMENT");
            sb.Append(" INNER JOIN specialite s ON i.IDSPECIALITEI=s.IDSPECIALITE WHERE v.IDINSPECTEUR=");
            sb.Append(" (SELECT i.IDINSPECTEUR FROM inspecteur WHERE NOMINSPECTEUR='" + nomInsp.ToString() + "') AND DATEV='" + date.ToString() + "'");

            MySqlDataReader dr;

            MySqlCommand cmd = new MySqlCommand(sb.ToString(), myConnection);

            try
            {
                dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    //lecture de ta table

                    while (dr.Read())
                    {
                        sb2 = sb2.Append("Numéro Visite :  " + (dr.GetString(7)) + "\n");
                        sb2 = sb2.Append("\n");
                        sb2.Append("Nom Hébergement :  " + (dr.GetString(15)) + "\n");
                        sb2 = sb2.Append("\n");
                        sb2 = sb2.Append("Adresse Hébergement :  " + (dr.GetString(17)) + "\n");
                        sb2 = sb2.Append("\n");
                        sb2 = sb2.Append("Étoile Actuel :  " + (dr.GetString(24)) + "");




                        dr.Read();



                    }
                }
                dr.NextResult();
                dr.Close();
            }
            catch (Exception err)
            {
                errgrave = true;

            }

            return sb2.ToString();

        }
        public void import(String nomInsp)
        {
            if (!connopen) return;

           
            MySqlCommand cmd = new MySqlCommand("call maj_vm_visites() ", myConnection);

            mySqlDataAdapter.SelectCommand = new MySqlCommand(" select * from departement;select * from saison;select * from vm_visites where Nom_Inspecteur='" + nomInsp.ToString() + "';", myConnection);
            try
            {
                dataSet.Clear();
                mySqlDataAdapter.Fill(dataSet);
                MySqlCommand vcommand = myConnection.CreateCommand();

                vcommand.CommandText = "SELECT AUTO_INCREMENT as last_id FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'visite'";
                UInt64 der_visite = (UInt64)vcommand.ExecuteScalar();
                dataSet.Tables[1].Columns[0].AutoIncrement = true;
                dataSet.Tables[1].Columns[0].AutoIncrementSeed = Convert.ToInt64(der_visite);
                dataSet.Tables[1].Columns[0].AutoIncrementStep = 1;

                dv_departement = dataSet.Tables[0].DefaultView;
                dv_saison = dataSet.Tables[1].DefaultView;
                dv_visite = dataSet.Tables[2].DefaultView;
                


                chargement = true;
            }
            catch (Exception err)
            {
                errgrave = true;
            }
        }

        public bool login(string pseudo, string mdp)
        {
            bool ret;

            MySqlCommand cmd = new MySqlCommand("Select * from inspecteur where NOMINSPECTEUR='" + pseudo + "' and MDPINSPECTEUR='" + mdp + "'", myConnection);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }

            if (count == 1)
            {
                
           
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;

        }

       


    }
}

        #endregion


