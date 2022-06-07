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
    public partial class Emplois : Form
    {
        public Emplois()
        {
            InitializeComponent();
        }

        public void refresh()
        {
        //fonction rechercher
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "SELECT IdSemC,IdEnsC,IdJourC,Heures,Dates,CodeMatC,LibMat,CodeSalC,NomSalle FROM cours LEFT JOIN salle ON salle.CodeSal = cours.CodeSalC LEFT JOIN enseignant ON enseignant.IdEns = cours.IdEnsC LEFT JOIN matiere ON matiere.CodeMat = cours.CodeMatC LEFT JOIN jour ON jour.IdJour = cours.IdJourC";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridEmplois.DataSource = dt;

                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 objects = new Form1();
            objects.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Enseignants objects = new Enseignants();
            objects.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        //Enregistrer
            String a="11", b="13", r;
            r = a+"H-" + b+"H";
            MessageBox.Show(r);
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridEmplois_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        //Data Grid View
            if (dataGridEmplois.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridEmplois.CurrentRow.Selected = true;

                semaine.Text = dataGridEmplois.Rows[e.RowIndex].Cells[0].Value.ToString();
                dates.Text = dataGridEmplois.Rows[e.RowIndex].Cells[4].Value.ToString();
                matricule.Text = dataGridEmplois.Rows[e.RowIndex].Cells[1].Value.ToString();
                jour.Text = dataGridEmplois.Rows[e.RowIndex].Cells[2].Value.ToString();
                heures.Text = dataGridEmplois.Rows[e.RowIndex].Cells[3].Value.ToString();
                CodeSalle.Text = dataGridEmplois.Rows[e.RowIndex].Cells[7].Value.ToString();
                CodeMatiere.Text = dataGridEmplois.Rows[e.RowIndex].Cells[5].Value.ToString();
                NomSalle.Text = dataGridEmplois.Rows[e.RowIndex].Cells[8].Value.ToString();
                LibeleMatiere.Text = dataGridEmplois.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
        //Actualiser
                refresh(); 
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        //Annuler
            semaine.Text = "";
            matricule.Text = "";
            dates.Text = "";
            jour.Text = "";
            heures.Text = "";
            CodeSalle.Text =  "";
            CodeMatiere.Text = "";
            NomSalle.Text = "";
            LibeleMatiere.Text = "";
            matricule.Focus();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        //Modifier

        }

        private void button3_Click(object sender, EventArgs e)
        {
        //Supprimer

        }

        private void button4_Click(object sender, EventArgs e)
        {
        //Supprimer en cascade

        }

        private void button13_Click(object sender, EventArgs e)
        {
            EmploisTemps form = new EmploisTemps();
            form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Cours form = new Cours();
            form.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Jour form = new Jour();
            form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Salle form = new Salle();
            form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Matiere form = new Matiere();
            form.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Semaine form = new Semaine();
            form.ShowDialog();
        }
    }
}
