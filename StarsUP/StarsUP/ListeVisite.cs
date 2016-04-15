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

namespace StarsUP
{
    public partial class ListeVisite : MetroForm
    {

        private BindingSource bindingSource1 = new BindingSource();

        public void remplirdgv()
        {
            List<KeyValuePair<int, string>> Flist = new List<KeyValuePair<int, string>>();
            Flist.Add(new KeyValuePair<int, string>(0, "Tous les départements"));
            cbDepartement.Items.Add("Tous les départements");
            
            for (int i = 0; i < controller.Vmodel.Dv_departement.ToTable().Rows.Count; i++) 
            {
              //  MessageBox.Show(controller.Vmodel.Dv_departement.ToTable().Rows[i][0].ToString() + " - " + controller.Vmodel.Dv_departement.ToTable().Rows[i][2].ToString());
                Flist.Add(new KeyValuePair<int, string>(Convert.ToInt32(controller.Vmodel.Dv_departement.ToTable().Rows[i][0].ToString()),
                controller.Vmodel.Dv_departement.ToTable().Rows[i][2].ToString()));
            }


            List<KeyValuePair<int, string>> FlistS = new List<KeyValuePair<int, string>>();
            FlistS.Add(new KeyValuePair<int, string>(0, "Toutes les saisons"));
            cbSaison.Items.Add("Toutes les saisons");

            for (int i = 0; i < controller.Vmodel.Dv_saison.ToTable().Rows.Count; i++)
            {
                FlistS.Add(new KeyValuePair<int, string>(Convert.ToInt32(controller.Vmodel.Dv_saison.ToTable().Rows[i][0].ToString()),
                controller.Vmodel.Dv_saison.ToTable().Rows[i][1].ToString()));
            }
            //on relie la liste à la combox
            cbDepartement.DataSource = Flist;
            cbDepartement.ValueMember = "Key";
            cbDepartement.DisplayMember = "Value";
            cbDepartement.Text = cbDepartement.Items[0].ToString();
            cbDepartement.DropDownStyle = ComboBoxStyle.DropDownList;
            

            cbSaison.DataSource = FlistS;
            cbSaison.ValueMember = "Key";
            cbSaison.DisplayMember = "Value";
            cbSaison.Text = cbSaison.Items[0].ToString();
            cbSaison.DropDownStyle = ComboBoxStyle.DropDownList;

            bindingSource1.DataSource = controller.Vmodel.Dv_visite;
            dataGV.DataSource = bindingSource1;

            dataGV.Columns[0].Visible = false;
            dataGV.Columns[1].Visible = false;
            dataGV.Columns[7].Visible = false;
            dataGV.Columns[8].Visible = false;
            dataGV.Columns[11].Visible = false;

            int vwidth = dataGV.RowHeadersWidth;
            for(int i = 0;i<dataGV.Columns.Count;i++)
            {
                if (dataGV.Columns[i].Visible)
                    vwidth = vwidth + dataGV.Columns[i].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);

            }
            if(dataGV.ScrollBars.Equals(ScrollBars.Both)|dataGV.ScrollBars.Equals(ScrollBars.Vertical))
            {
                dataGV.Width += 20;
            }
            dataGV.Refresh();

        }
        /// <summary>
        /// Il s'agit d'un filtre qu'on effectue avec l'identifiant du département
        /// </summary>
        public void filtre()
        {
            string num = cbDepartement.SelectedValue.ToString();
            int n = Convert.ToInt32(num);
            if(n==0)
            {
                controller.Vmodel.Dv_visite.RowFilter = "";
                
            }
            else
            {
                string Filter = "Identifiant_Departement='" + n + "'";
                controller.Vmodel.Dv_visite.RowFilter = Filter;
            }
            dataGV.Refresh();
        }

        /// <summary>
        /// Il s'agit ici du filtre pour la saison.On voit le nom de la saison 
        /// </summary>
        public void filtreS()
        {
            string num = cbSaison.SelectedValue.ToString();
            int n = Convert.ToInt32(num);
            if (n == 0)
            {
                controller.Vmodel.Dv_visite.RowFilter = "";

            }
            else
            {
                string Filter = "Identifiant_Saison='" + n + "'";
                controller.Vmodel.Dv_visite.RowFilter = Filter;
            }
            dataGV.Refresh();
        }

        /// <summary>
        /// Il s'agit du filtre pour les dates que l'inspecteur va selectionner. On filtre les visites situées entre les deux dates
        /// </summary>
        public void filtreD()
        {
           //Ce filtre permet de charger les visites qui sont situées entre les deux dates 
            string Filter = "Date_de_visite>='"+dateTimePicker1.Value.ToShortDateString()+"' AND Date_de_visite<='"+dateTimePicker2.Value.ToShortDateString()+"'";
            controller.Vmodel.Dv_visite.RowFilter=Filter;
            //Il s'agit du filtre de la saison
            string FilterSaison = "Annee_Saison='" + dateTimePicker1.Value.Year.ToString()+"'";
            controller.Vmodel.Dv_saison.RowFilter = FilterSaison;
            
            //On crée une nouvelle liste pour lui ajouter les nouvelles saison en fonction de l'année de la date
            List<KeyValuePair<int, string>> FlistS = new List<KeyValuePair<int, string>>();
            FlistS.Add(new KeyValuePair<int, string>(0, "Toutes les saisons"));
      

           //On parcour le dataview pour charger les nouvelles saisons
            for (int i = 0; i < controller.Vmodel.Dv_saison.ToTable().Rows.Count; i++)
            {
                FlistS.Add(new KeyValuePair<int, string>(Convert.ToInt32(controller.Vmodel.Dv_saison.ToTable().Rows[i][0].ToString()),
                controller.Vmodel.Dv_saison.ToTable().Rows[i][1].ToString()));
            }
            cbSaison.DataSource=FlistS;
            //On fait un rafraichissement pour la combobox pour pouvoir voir les nouvelles saison en fonction de l'année de l'une des dates
            cbSaison.Refresh();
            //On fait un rafraichissement de la datagridview pour pouvoir voir le résultat
            dataGV.Refresh();
        }
        
        public ListeVisite()
        {
            InitializeComponent();
            remplirdgv();
            dataGV.AllowUserToAddRows = false;
            dataGV.AllowUserToDeleteRows = false;
            dataGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }

        private void cbDepartement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //On appele le filtre sur cet évènement
            filtre();
        }

        private void cbSaison_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Même chose
            filtreS();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //""
            filtreD();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //""
            filtreD();
        }

        private void dataGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// Au clic de ce boutton on transfert l'option u et le numéro de visite présent dans le datagridview pour la modification du commentaire
        /// et des étoiles en appelant la méthode crud_etoile qui se trouve dans la classe controller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGV.Rows.Count!=0)
            {
                if (dataGV.Rows[dataGV.SelectedRows[0].Index].Cells[0].Value != null)
                {
                    controller.crud_etoile('u', dataGV.Rows[dataGV.SelectedRows[0].Index].Cells[0].Value.ToString());

                    bindingSource1.MoveLast();
                    bindingSource1.MoveFirst();
                    dataGV.Refresh();
                }
            }
           
            else
            {
                MessageBox.Show("Veuillez sélectionner une visite", "Visites", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void ListeVisite_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.Vmodel.Dv_visite.RowFilter = null;
        }
    }
}
