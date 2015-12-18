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
        private DataSet dataSet = new DataSet();
        private DataView dv_visite = new DataView(), dv_departement = new DataView(), dv_saison = new DataView();


        #endregion

        #region assesseurs:
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


        public void import()
        {
            if (!connopen) return;
            mySqlDataAdapter.SelectCommand = new MySqlCommand(" select * from departement;select * from saison;select * from visite;", myConnection);
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


