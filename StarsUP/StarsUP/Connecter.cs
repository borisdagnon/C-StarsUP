using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
using System.Windows.Forms;

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

        private DataView dv_visite = new DataView(), dv_departement = new DataView(), dv_saison = new DataView(), dv_inspecteur = new DataView(), dv_etoile = new DataView(), dv_vm_contrevisite = new DataView(),dv_contrevisite=new DataView(), dv_import2 = new DataView(), dv_import3 = new DataView();

       
       

       


        #endregion

        #region assesseurs:
        public DataView Dv_etoile
        {
            get { return dv_etoile; }
            set { dv_etoile = value; }
        }
        public DataView Dv_inspecteur
        {
            get { return dv_inspecteur; }
            set { dv_inspecteur = value; }
        }
        public bool Connopen
        {
            get { return connopen; }

        }

        public DataView Dv_vm_contrevisite
        {
            get { return dv_vm_contrevisite; }
            set { dv_vm_contrevisite = value; }
        }

        public DataView Dv_contrevisite
        {
            get { return dv_contrevisite; }
            set { dv_contrevisite = value; }
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
        public DataView Dv_import2
        {
            get { return dv_import2; }
            set { dv_import2 = value; }
        }
        public DataView Dv_import3
        {
            get { return dv_import3; }
            set { dv_import3 = value; }
        }
        #endregion

        #region méthodes:



       

        public void seconnecter()
        {
            string myConnectionString = "Database=bd_boris_starsup;Data Source=192.168.236.;User Id=boris;Password=123 ";
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

     
    
       public void import(String nomInsp)
        {
            if (!connopen) return;

            StringBuilder sb = new StringBuilder();
            sb.Append("Select i.IDINSPECTEUR, PRENOMINSPECTEUR, NOMINSPECTEUR, DATEV");
            sb.Append(" FROM inspecteur i INNER JOIN visite v ON i.IDINSPECTEUR = v.IDINSPECTEUR INNER JOIN datev d_v ON d_v.IDDATEV = v.IDDATEV");
            sb.Append(" WHERE i.IDINSPECTEUR = (SELECT IDINSPECTEUR FROM INSPECTEUR WHERE NOMINSPECTEUR = '" + nomInsp + "') ");

            StringBuilder sb2 = new StringBuilder();
            sb2.Append("SELECT v.IDVISITE,NOMHEBERGEMENT,ADRESSEHEBERGEMENT,ETOILLE,DATEV");
            sb2.Append(" FROM visite v INNER JOIN hebergement h ON h.IDHEBERGEMENT = v.IDHEBERGEMENT");
            sb2.Append(" INNER JOIN historique his ON v.IDVISITE = his.IDVISITE");
            sb2.Append(" INNER JOIN datev d_v ON d_v.IDDATEV = v.IDDATEV");
            sb2.Append(" WHERE v.IDINSPECTEUR = (SELECT IDINSPECTEUR FROM inspecteur WHERE NOMINSPECTEUR = '" + nomInsp + "')");

          

            MySqlCommand cmd = new MySqlCommand("call maj_vm_visites() ", myConnection);
            MySqlCommand cmd2 = new MySqlCommand("CALL `maj_vm_saison`();", myConnection);


            mySqlDataAdapter.SelectCommand = new MySqlCommand("select * from departement;select * from vm_saison where Nom_Inspecteur='" + nomInsp + "';select * from vm_visites where Nom_Inspecteur='" + nomInsp.ToString() + "';select * from inspecteur where NOMINSPECTEUR='" + nomInsp.ToString() + "';select v.IDVISITE,COMMENTAIREV,ETOILLE,v.IDHEBERGEMENT,CONTREVISITE from visite v inner join historique h on v.IDVISITE=h.IDVISITE where  IDINSPECTEUR=(select IDINSPECTEUR from inspecteur where NOMINSPECTEUR='" + nomInsp.ToString() + "');SELECT * FROM vm_contrevisite WHERE Nom_Inspecteur='" + nomInsp + "';SELECT * FROM contrevisite;" + sb.ToString() + ";" + sb2.ToString() + ";", myConnection);
            try
            {
                dataSet.Clear();
                mySqlDataAdapter.Fill(dataSet);
                MySqlCommand vcommand = myConnection.CreateCommand();

                vcommand.CommandText = "SELECT AUTO_INCREMENT as last_id FROM INFORMATION_SCHEMA.TABLES WHERE table_name = 'visite'";
                UInt64 der_visite = (UInt64)vcommand.ExecuteScalar();
                dataSet.Tables[2].Columns[0].AutoIncrement = true;
                dataSet.Tables[2].Columns[0].AutoIncrementSeed = Convert.ToInt64(der_visite);
                dataSet.Tables[2].Columns[0].AutoIncrementStep = 1;


                dv_departement = dataSet.Tables[0].DefaultView;
                dv_saison = dataSet.Tables[1].DefaultView;
                dv_visite = dataSet.Tables[2].DefaultView;
                dv_inspecteur = dataSet.Tables[3].DefaultView;
                dv_etoile = dataSet.Tables[4].DefaultView;
                dv_vm_contrevisite = dataSet.Tables[5].DefaultView;
                dv_contrevisite = dataSet.Tables[6].DefaultView;
                dv_import2 = dataSet.Tables[7].DefaultView;
                dv_import3 = dataSet.Tables[8].DefaultView;


                chargement = true;
            }
            catch (Exception err)
            {
                errgrave = true;
            }
            cmd.Dispose();
            cmd2.Dispose();
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
            Int64 nb2 = 0;
           if(args.Status==UpdateStatus.ErrorsOccurred)
           {
               if(vaction=='u')
               {
                   MySqlCommand vcommand = myConnection.CreateCommand();
                   if(vtable=='i')
                   {
                       vcommand.CommandText="SELECT COUNT(*) FROM inspecteur WHERE IDINSPECTEUR ='"+args.Row[0,DataRowVersion.Original]+"'";
                   }
                  else
                    {
                        if (vtable == 'v')
                        {
                            vcommand.CommandText = "SELECT COUNT(*) FROM visite WHERE IDVISITE ='" + args.Row[0, DataRowVersion.Original] + "'";
                        }
                        else
                        {
                            if (vtable == 'c')
                            {
                                vcommand.CommandText = "SELECT COUNT(*) FROM contrevisite WHERE IDCONTREVISITE ='" + args.Row[0, DataRowVersion.Original] + "'";
                            }
                        }
                         
                    }
                   //on veut savoir si l'inspecteur existe ou si la visite existe dans la bdd
                  
                    nb = (Int64)vcommand.ExecuteScalar();
                }


               if(vaction=='u')
               {
                    if (nb == 1) 
                    {
                        if (vtable == 'i')
                        {
                            msg = "pour le numéro de personne: " + args.Row[0, DataRowVersion.Original] + " impossible MAJ car enr modifié dans la base";
                        }
                       else
                        {
                            if (vtable == 'v')
                            {
                                msg = "pour le numéro de visite: " + args.Row[0, DataRowVersion.Original] + " impossible MAJ car enr modifié dans la base";
                            }
                            else
                            {
                                if(vtable=='c')
                                {
                                    msg = "pour le numéro de contre visite: " + args.Row[0, DataRowVersion.Original] + " impossible MAJ car enr modifié dans la base";

                                }
                            }
                        }
                       
                        rapport.Add(msg);
                        errmaj = true;

                    }
                    else
                    {
                        if (vtable == 'i')
                        {
                            msg = "pour le numéro de l'inspecteur: " + args.Row[0, DataRowVersion.Original] + " impossible MAJ car enr supprimé dans la base";
                        }
                       else
                        {
                            if (vtable == 'v')
                            {
                                msg = "pour le numéro de visite: " + args.Row[0, DataRowVersion.Original] + " impossible MAJ car enr supprimé dans la base";
                            }
                            else
                            {
                                if(vtable=='c')
                                {
                                    msg = "pour le numéro de contre visite: " + args.Row[0, DataRowVersion.Original] + " impossible MAJ car enr supprimé dans la base";

                                }
                            }
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
           mySqlDataAdapter.UpdateCommand = new MySqlCommand("UPDATE inspecteur set PRENOMINSPECTEUR=?PRENOMINSPECTEUR, NUMEROTEL=?NUMEROTEL, MDPINSPECTEUR=?MDPINSPECTEUR WHERE IDINSPECTEUR=?IDINSPECTEUR", myConnection);

           mySqlDataAdapter.UpdateCommand.Parameters.Add("?PRENOMINSPECTEUR", MySqlDbType.Text, 655, "PRENOMINSPECTEUR");
           mySqlDataAdapter.UpdateCommand.Parameters.Add("?NUMEROTEL", MySqlDbType.Int32, 20, "NUMEROTEL");
           mySqlDataAdapter.UpdateCommand.Parameters.Add("?MDPINSPECTEUR", MySqlDbType.Text, 655, "MDPINSPECTEUR");
           mySqlDataAdapter.UpdateCommand.Parameters.Add("?IDINSPECTEUR", MySqlDbType.Int16, 10, "IDINSPECTEUR");

           mySqlDataAdapter.ContinueUpdateOnError = true;

           DataTable table = dataSet.Tables[3];

           mySqlDataAdapter.Update(table.Select(null, null, DataViewRowState.ModifiedCurrent));

           mySqlDataAdapter.RowUpdated -= new MySqlRowUpdatedEventHandler(onRowUpdated);
        
        }
        
       public void mod_etoile()
        {
            vaction = 'u';
            vtable = 'v';

            if (!connopen) return;
            mySqlDataAdapter.RowUpdated += new MySqlRowUpdatedEventHandler(onRowUpdated);
            
            mySqlDataAdapter.UpdateCommand = new MySqlCommand("update visite v inner join historique h ON v.IDVISITE=h.IDVISITE SET ETOILLE=?ETOILLE,COMMENTAIREV=?COMMENTAIREV,CONTREVISITE=?CONTREVISITE WHERE v.IDVISITE=?IDVISITE", myConnection);

            mySqlDataAdapter.UpdateCommand.Parameters.Add("?ETOILLE", MySqlDbType.Int16, 10, "ETOILLE");
            mySqlDataAdapter.UpdateCommand.Parameters.Add("?IDVISITE", MySqlDbType.Int16, 10, "IDVISITE");
            mySqlDataAdapter.UpdateCommand.Parameters.Add("?COMMENTAIREV", MySqlDbType.Text, 3000, "COMMENTAIREV");
            mySqlDataAdapter.UpdateCommand.Parameters.Add("?CONTREVISITE", MySqlDbType.Text, 655, "CONTREVISITE");

           

            mySqlDataAdapter.ContinueUpdateOnError = true;

            DataTable table = dataSet.Tables[4];

            mySqlDataAdapter.Update(table.Select(null, null, DataViewRowState.ModifiedCurrent));

            mySqlDataAdapter.RowUpdated -= new MySqlRowUpdatedEventHandler(onRowUpdated);



        }


        public void mod_contrevisite()
        {
            vaction = 'u';
            vtable = 'c';

            if (!connopen) return;
            mySqlDataAdapter.RowUpdated += new MySqlRowUpdatedEventHandler(onRowUpdated);

            mySqlDataAdapter.UpdateCommand = new MySqlCommand("update contrevisite SET COMMENTAIRECV=?COMMENTAIRECV,NBETOILEMOINS=?NBETOILEMOINS WHERE IDCONTREVISITE=?IDCONTREVISITE", myConnection);

            mySqlDataAdapter.UpdateCommand.Parameters.Add("?COMMENTAIRECV", MySqlDbType.Text, 3000, "COMMENTAIRECV");
            mySqlDataAdapter.UpdateCommand.Parameters.Add("?NBETOILEMOINS", MySqlDbType.Int16, 10, "NBETOILEMOINS");
            mySqlDataAdapter.UpdateCommand.Parameters.Add("?IDCONTREVISITE", MySqlDbType.Int16, 10, "IDCONTREVISITE");


            mySqlDataAdapter.ContinueUpdateOnError = true;

            DataTable table = dataSet.Tables[6];

            mySqlDataAdapter.Update(table.Select(null, null, DataViewRowState.ModifiedCurrent));

            mySqlDataAdapter.RowUpdated -= new MySqlRowUpdatedEventHandler(onRowUpdated);



        }



        public bool export()
        {
            bool ret = false;
            if (connopen)
            {
                try
                {
                   mod_inspecteur();
                    mod_etoile();
                    mod_contrevisite();


                    ret = true;
                }

                catch (Exception err)
                {
                    errgrave = true;
                }
            }
            return ret;
        }

    }
}

        #endregion


