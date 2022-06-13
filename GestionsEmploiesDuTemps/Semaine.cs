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
    public partial class Semaine : Form
    {
        public Semaine()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Enregistrer
            String idSemaine = NomSalle.Text;
            String numeroSemaine = CodeSalle.Text;
            String heur = heure.Text;
            String jour = idjour.Text;


            if (idSemaine != "" & numeroSemaine != "" & jour != "" & heur != "")
            {
                MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");

                try
                {
                    connexion.Open();
                    // La commande Insert.
                    string sql = "INSERT INTO semaine (NumSem, IdSem, IdJour, Heures) VALUES (@NumSem,@IdSem,@IdJour,@Heures)";

                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = sql;

                    cmd.CommandText =" INSERT INTO semaine (NumSem, IdSem, IdJour, Heures) VALUES (@NumSem,@IdSem,@IdJour,@Heures) ";

                    cmd.Parameters.AddWithValue("@NumSem", CodeSalle.Text);
                    cmd.Parameters.AddWithValue("@IdSem", NomSalle.Text);
                    cmd.Parameters.AddWithValue("@IdJour", idjour.Text);
                    cmd.Parameters.AddWithValue("@Heures", heure.Text);
                   

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(" Semaine Ajouter Avec Succes ! ", "Ajout Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connexion.Close();
                }
                catch
                {
                    MessageBox.Show(" Echec De Connexion. ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else { MessageBox.Show(" Echec ! Champ(s) Vide(s). ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void NomSalle_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NomSalle.Text = "";
            CodeSalle.Text = "";
            idjour.Text = "";
            heure.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //supprimer
            String idSemaine = NomSalle.Text;
            String numeroSemaine = CodeSalle.Text;
            String heur = heure.Text;
            String jour = idjour.Text;


            if (idSemaine == "" | numeroSemaine == "" | heur == "" | jour == "") { MessageBox.Show(" Impossible de Supprimer. il y'a Un(des) Champ(s) Vide(s). ", "Modification Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion;
                    cmd.CommandText = String.Format("DELETE FROM semaine WHERE  IdSem='{0}'", NomSalle.Text);

                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        MessageBox.Show("Semaine a ete Bien Supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        NomSalle.Text = "";
                        CodeSalle.Text = "";
                        idjour.Text = "";
                        heure.Text = "";
                        connexion.Close();
                    }
                    else {
                        MessageBox.Show("Erreur de suppression", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show(" Echec de Suppression ", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //modifier
            String idSemaine = NomSalle.Text;
            String numeroSemaine = CodeSalle.Text;
            String heur = heure.Text;
            String jour = idjour.Text;

            if (idSemaine == "" | numeroSemaine == "" | heur == "" | jour == "") { MessageBox.Show(" Impossible de modifier. il y'a Un(des) Champ(s) Vide(s). ", "Modification Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion; //(IdEns, NomEns, PrenomEns , SexeEns , AgeEns)
                    cmd.CommandText = String.Format("update semaine set IdSem='{0}',IdJour='{1}', Heures='{2}' where  IdSem='{3}'", CodeSalle.Text, heure.Text, idjour.Text, NomSalle.Text);
                    int r = cmd.ExecuteNonQuery();

                    if (r != 0)
                    {
                        MessageBox.Show("Semaine a ete Bien Modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connexion.Close();
                    }
                }
                catch
                {
                    MessageBox.Show(" Echec de Modifier ", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
