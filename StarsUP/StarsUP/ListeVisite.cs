using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarsUP
{
    public partial class ListeVisite : Form
    {

        private BindingSource bindingSource1 = new BindingSource();

        public void remplirdgv()
        {
            List<KeyValuePair<int, string>> Flist = new List<KeyValuePair<int, string>>();
            Flist.Add(new KeyValuePair<int, string>(0, "Tous les départements"));
            cbDepartement.Items.Add("Tous les départements");

            List<KeyValuePair<int, string>> FlistS = new List<KeyValuePair<int, string>>();
            FlistS.Add(new KeyValuePair<int, string>(0, "Toutes les saisons"));
            cbSaison.Items.Add("Toutes les saisons");

            for (int i = 0; i < controller.Vmodel.Dv_departement.ToTable().Rows.Count; i++) 
            {
              //  MessageBox.Show(controller.Vmodel.Dv_departement.ToTable().Rows[i][0].ToString() + " - " + controller.Vmodel.Dv_departement.ToTable().Rows[i][2].ToString());
                Flist.Add(new KeyValuePair<int, string>(Convert.ToInt32(controller.Vmodel.Dv_departement.ToTable().Rows[i][0].ToString()),
                controller.Vmodel.Dv_departement.ToTable().Rows[i][2].ToString()));
            }
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
            dataGV.Columns[6].Visible = false;
            dataGV.Columns[7].Visible = false;

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

        public void filtreD()
        {
           
            string Filter = "Date_de_visite>='"+dateTimePicker1.Value.ToShortDateString()+"' AND Date_de_visite<='"+dateTimePicker2.Value.ToShortDateString()+"'";
            controller.Vmodel.Dv_visite.RowFilter=Filter;
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
            filtre();
        }

        private void cbSaison_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filtreS();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filtreD();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            filtreD();
        }

        


    }
}
