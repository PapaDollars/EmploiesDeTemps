using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionsEmploiesDuTemps
{
    public partial class EmploisTemps : Form
    {
        public EmploisTemps()
        {
            InitializeComponent();
            refresh();
            refreshE();
            refreshM();
            refreshSemaine();
            refreshSalle();

        }

        public void search()
        {
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");

            try
            {
                connexion.Open();

                String recherche = "SELECT * FROM cours LEFT JOIN salle ON salle.CodeSal = cours.CodeSalC LEFT JOIN enseignant ON enseignant.IdEns = cours.IdEnsC LEFT JOIN matiere ON matiere.CodeMat = cours.CodeMatC LEFT JOIN jour ON jour.IdJour = cours.IdJourC";

                MySqlCommand cmmd = new MySqlCommand(recherche, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridEmploidTemps.DataSource = dt;


                connexion.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "  Entrez une ''IdEns'' Valide.  ", "Id Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            search();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            //fonction rechercher
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "SELECT * from cours";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridView2.DataSource = dt;

                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public void refreshM()
        {
            //fonction rechercher
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "SELECT * from matiere";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridView3.DataSource = dt;

                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void refreshSalle()
        {
            //fonction rechercher
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "SELECT * from salle";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridView4.DataSource = dt;

                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void refreshSemaine()
        {
            //fonction rechercher
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "SELECT * from semaine";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridView5.DataSource = dt;

                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        public void refreshE()
        {
            //fonction rechercher
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "SELECT * from enseignant";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridView1.DataSource = dt;

                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
