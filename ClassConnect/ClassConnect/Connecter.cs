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
        private bool errmaj = false;
        private static bool errgrave = false;
        private bool chargement = false;
       
      

        private MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
        private DataTable dt = new DataTable();

        private DataSet dataSet = new DataSet();
        

        private DataView dv_visite = new DataView(), dv_departement = new DataView(), dv_saison = new DataView(), dv_inspecteur = new DataView();

       


        #endregion

        #region assesseurs:
        public DataView Dv_inspecteur
        {
            get { return dv_inspecteur; }
            set { dv_inspecteur = value; }
        }
        public bool Connopen
        {
            get { return connopen; }

        }
      

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
                cmd.Dispose();
                dr.Close();
                dr.Dispose();
              
            }
            catch (Exception err)
            {
                errgrave = true;
               
            }

            return sb2.ToString();
            sb2 = null;
        }
        public List<String> infoInspecteur(String nominsp, String  mdpInsp)
        {


            List<String> infos  = new List<String>();
          
            
            MySqlDataReader dr;
            MySqlCommand cd = new MySqlCommand("SELECT IDINSPECTEUR,NOMINSPECTEUR,PRENOMINSPECTEUR,NUMEROTEL FROM inspecteur where NOMINSPECTEUR='" + nominsp + "' AND MDPINSPECTEUR='" + mdpInsp + "';", myConnection);

            try
            {
                
                dr = cd.ExecuteReader();
               
                
                   while (dr.Read())
                        {
                            infos.Add(dr[0].ToString());
                           infos.Add( dr[1].ToString());
                            infos.Add( dr[2].ToString());
                           infos.Add( dr[3].ToString());
                           
                        }
                 
                    }
               
            
            catch(Exception err)
            {
                errgrave = true;
            }
            return infos;
            cd.Dispose();
            dr.Close();
            dr.Dispose();
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
                cmd.Dispose();
                dr.Close();
                dr.Dispose();

            }
            catch (Exception err)
            {
                errgrave = true;

            }
          
            return sb2.ToString();
            sb2 = null;
        }
        public void import(String nomInsp)
        {
            if (!connopen) return;

           
            MySqlCommand cmd = new MySqlCommand("call maj_vm_visites() ", myConnection);

            mySqlDataAdapter.SelectCommand = new MySqlCommand(" select * from departement;select * from saison;select * from vm_visites where Nom_Inspecteur='" + nomInsp.ToString() + "';select * from inspecteur where NOMINSPECTEUR='"+nomInsp.ToString()+"';", myConnection);
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
                dv_inspecteur = dataSet.Tables[3].DefaultView;


                chargement = true;
            }
            catch (Exception err)
            {
                errgrave = true;
            }
            cmd.Dispose();
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
            cmd.Dispose();
            dr.Close();
            
        }

       private void onRowUpdated(object sender, MySqlRowUpdatedEventArgs args)
        {
            string msg = "";
            Int64 nb = 0;
           if(args.Status==UpdateStatus.ErrorsOccurred)
           {
               if(vaction=='u')
               {
                   MySqlCommand vcommand = myConnection.CreateCommand();
                   if(vtable=='i')
                   {
                       vcommand.CommandText="SELECT COUNT(*) FROM inspecteur WHERE IDINSPECTEUR ='"+args.Row[0,DataRowVersion.Original]+"'";
                   }
                   nb = (Int64)vcommand.ExecuteScalar();
                   //on veut savoir si l'inspecteur existe dans la bdd
               }
               if(vaction=='u')
               {
                   if(nb==1)
                   {
                       if(vtable=='i')
                       {
                           msg = "pour le numéro de personne: " + args.Row[0, DataRowVersion.Original] + " impossible MAJ car enr modifié dans la base";
                       }
                       rapport.Add(msg);
                       errmaj = true;
                   }
                   else
                   {
                       if(vtable=='i')
                       {
                           msg = "pour le numéro de personne : " + args.Row[0, DataRowVersion.Original] + " impossible MAJ car enr supprimé dans la base";
                       }
                       rapport.Add(msg);
                       errmaj = true;
                   }
               }
           }
        }


        public void mod_inspecteur()
       {
           vaction = 'u';
           vtable = 'i';

           if (!connopen) return;
           mySqlDataAdapter.RowUpdated += new MySqlRowUpdatedEventHandler(onRowUpdated);
           mySqlDataAdapter.InsertCommand = new MySqlCommand("UPDATE inspecteur set PRENOMINSPECTEUR=?PRENOMINSPECTEUR, NUMEROTEL=?NUMEROTEL, MDPINSPECTEUR=?MDPINSPECTEUR WHERE IDINSPECTEUR= ?IDINSPECTEUR,", myConnection);

           mySqlDataAdapter.InsertCommand.Parameters.Add("?PRENOMINSPECTEUR", MySqlDbType.Text, 655, "PRENOMINSPECTEUR");
           mySqlDataAdapter.InsertCommand.Parameters.Add("?NUMEROTEL", MySqlDbType.Text, 655, "NUMEROTEL");
           mySqlDataAdapter.InsertCommand.Parameters.Add("?MDPINSPECTEUR", MySqlDbType.Text, 655, "MDPINSPECTEUR");
           mySqlDataAdapter.InsertCommand.Parameters.Add("?IDINSPECTEUR", MySqlDbType.Text, 655, "IDINSPECTEUR");

           mySqlDataAdapter.ContinueUpdateOnError = true;

           DataTable table = dataSet.Tables[3];

           mySqlDataAdapter.Update(table.Select(null, null, DataViewRowState.Added));

           mySqlDataAdapter.RowUpdated -= new MySqlRowUpdatedEventHandler(onRowUpdated);
        
        }


        public void export()
        {
            if (!connopen) return;
            try
            {
                mod_inspecteur();
            }
            catch(Exception err)
            {
                errgrave = true;
            }
        }

    }
}

        #endregion


