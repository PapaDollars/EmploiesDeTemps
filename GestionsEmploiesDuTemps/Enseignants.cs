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
    public partial class Enseignants : Form
    {
        public Enseignants()
        {
            InitializeComponent();
        }

        public void search(String recherchereference, String Values)
        {
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");

            try
            {
                connexion.Open();

                if (recherchereference == "matricule")
                {
                    String recherche = "select * from enseignant where IdEns Like '%" + Values + "%'";

                    MySqlCommand cmmd = new MySqlCommand(recherche, connexion);
                    MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    data.Fill(dt);
                    dataGridEnseignant.DataSource = dt;
                }
                if (recherchereference == "nom")
                {
                    String recherche = "select * from enseignant where NomEns Like '%" + Values + "%'";

                    MySqlCommand cmmd = new MySqlCommand(recherche, connexion);
                    MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    data.Fill(dt);
                    dataGridEnseignant.DataSource = dt;
                }
                if (recherchereference == "prenom")
                {
                    String recherche = "select * from enseignant where PrenomEns Like '%" + Values + "%'";

                    MySqlCommand cmmd = new MySqlCommand(recherche, connexion);
                    MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    data.Fill(dt);
                    dataGridEnseignant.DataSource = dt;
                }
                if (recherchereference == "sexe")
                {
                    String recherche = "select * from enseignant where SexeEns Like '%" + Values + "%'";

                    MySqlCommand cmmd = new MySqlCommand(recherche, connexion);
                    MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    data.Fill(dt);
                    dataGridEnseignant.DataSource = dt;
                }
                if (recherchereference == "age")
                {
                    String recherche = "select * from enseignant where AgeEns Like '%" + Values + "%'";

                    MySqlCommand cmmd = new MySqlCommand(recherche, connexion);
                    MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    data.Fill(dt);
                    dataGridEnseignant.DataSource = dt;
                }

                connexion.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "  Entrez une ''IdEns'' Valide.  ", "Id Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void refresh() {
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "select * from enseignant";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridEnseignant.DataSource = dt;

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

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Emplois objects = new Emplois();
            objects.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Form1 objects = new Form1();
            objects.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridEnseignant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridEnseignant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridEnseignant.CurrentRow.Selected = true;

                matricule.Text = dataGridEnseignant.Rows[e.RowIndex].Cells[0].Value.ToString();
                nom.Text = dataGridEnseignant.Rows[e.RowIndex].Cells[1].Value.ToString();
                prenom.Text = dataGridEnseignant.Rows[e.RowIndex].Cells[2].Value.ToString();
                sexe.Text = dataGridEnseignant.Rows[e.RowIndex].Cells[3].Value.ToString();
                age.Text = dataGridEnseignant.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String recherchereference = rechercheEnseignant.Text.ToString();
         //recherche par options
            String ValueSelect = options.GetItemText(options.SelectedItem);

            if (recherchereference != "")
            {
                search(ValueSelect, recherchereference);
            }
            else
                refresh();     
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
         //Enregistrer
            String Matricule = matricule.Text;
            String Nom = nom.Text;
            String Prenom = prenom.Text;
            String Sexe = sexe.Text;
            String Age = age.Text;
            matricule.Focus();

            if (Matricule != "" & Nom != "" & Prenom != "" & Sexe != "" & Age != "" )
            {
                MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");

                try
                {
                    connexion.Open();
                    // La commande Insert.
                    string sql = "INSERT INTO enseignant (IdEns, NomEns, PrenomEns , SexeEns , AgeEns) "
                                                        + " values (@idEns, @nomEns, @prenomEns ,@sexeEns ,@ageEns ) ";

                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = sql;

                    cmd.CommandText = "INSERT INTO enseignant (IdEns, NomEns, PrenomEns , SexeEns , AgeEns) VALUES (@idEns, @nomEns, @prenomEns ,@sexeEns ,@ageEns ) ";

                    cmd.Parameters.AddWithValue("@IdEns", matricule.Text);
                    cmd.Parameters.AddWithValue("@NomEns", nom.Text);
                    cmd.Parameters.AddWithValue("@PrenomEns", prenom.Text);
                    cmd.Parameters.AddWithValue("@SexeEns", sexe.Text);
                    cmd.Parameters.AddWithValue("@AgeEns", age.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(" Enseignant Ajouter Avec Succes ! ", "Ajout Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connexion.Close();
                }
                catch
                {
                    MessageBox.Show(" Echec De Connexion. ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else { MessageBox.Show(" Echec ! Champ(s) Vide(s). ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        //Annuler
            matricule.Text ="";
            nom.Text = "";
            prenom.Text = "";
            sexe.Text = "" ;
            age.Text = "";
            matricule.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        //modifier
            String Matricule = matricule.Text;
            String Nom = nom.Text;
            String Prenom = prenom.Text;
            String Sexe = sexe.Text;
            String Age = age.Text;
            matricule.Focus();

            if (Matricule == "" | Nom == "" | Prenom == "" | Sexe == "" | Age == "") { MessageBox.Show(" Impossible de modifier. il y'a Un(des) Champ(s) Vide(s). ", "Modification Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion; //(IdEns, NomEns, PrenomEns , SexeEns , AgeEns)
                    cmd.CommandText = String.Format("update enseignant set NomEns='{0}',PrenomEns='{1}',SexeEns='{2}', AgeEns='{3}' where  IdEns='{4}'", nom.Text, prenom.Text, sexe.Text, age.Text, matricule.Text);
                    int r = cmd.ExecuteNonQuery();

                    if (r != 0)
                    {
                        MessageBox.Show("Enseignant Bien Modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connexion.Close();
                    }
                }
                catch
                {
                    MessageBox.Show(" Echec de Modifier ", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        //supprimer
            String Matricule = matricule.Text;
            String Nom = nom.Text;
            String Prenom = prenom.Text;
            String Sexe = sexe.Text;
            String Age = age.Text;
            matricule.Focus();

            if (Matricule == "" | Nom == "" | Prenom == "" | Sexe == "" | Age == "") { MessageBox.Show(" Impossible de Supprimer. il y'a Un(des) Champ(s) Vide(s). ", "Modification Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion;
                    cmd.CommandText = String.Format("delete from enseignant where IdEns='{0}'", matricule.Text);

                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        MessageBox.Show("Enseignant Bien Supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        matricule.Text = "";
                        nom.Text = "";
                        prenom.Text = "";
                        sexe.Text = "";
                        age.Text = "";
                        matricule.Focus();

                        connexion.Close();
                    }
                }
                catch
                {
                    MessageBox.Show(" Echec de Suppression ", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void options_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rechercheEnseignant_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
