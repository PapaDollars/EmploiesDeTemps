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
    public partial class Jour : Form
    {
        public Jour()
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
            String code = CodeSalle.Text;
            String nomSalle = NomSalle.Text;
            if (code != "" & nomSalle != "")
            {
                MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                try
                {
                    connexion.Open();
                    // La commande Insert.
                    string sql = "INSERT INTO date (NumJour, IdJour) "
                                                        + " values (@NumJour, @IdJour) ";

                    MySqlCommand cmd = connexion.CreateCommand();
                    cmd.CommandText = sql;

                    cmd.CommandText = "INSERT INTO jour (NumJour, IdJour) "
                                                        + " values (@NumJour, @IdJour)  ";

                    cmd.Parameters.AddWithValue("@NumJour", code);
                    cmd.Parameters.AddWithValue("@IdJour", nomSalle);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show(" Jour Ajouter Avec Succes ! ", "Ajout Matiere", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connexion.Close();
                }
                catch
                {
                    MessageBox.Show(" Echec De Connexion. ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(" Echec ! Champ(s) Vide(s). ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Modifier
            String code = CodeSalle.Text;
            String nomSalle = NomSalle.Text;

            if (code != "" & nomSalle != "")
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion;
                    cmd.CommandText = String.Format("update jour set NumJour='{0}' where IdJour='{1}'", NomSalle.Text, CodeSalle.Text);
                    int r = cmd.ExecuteNonQuery();

                    if (r != 0)
                    {
                        MessageBox.Show("Jour a ete Modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connexion.Close();
                    }
                }
                catch
                {
                    MessageBox.Show(" Echec De Connexion. ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(" Echec ! Champ(s) Vide(s). ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Suprimer
            String code = CodeSalle.Text;

            if (code != "")
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion;
                    cmd.CommandText = String.Format("delete from jour where NumJour='{0}'", CodeSalle.Text);

                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        MessageBox.Show("Jour a ete Bien Supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CodeSalle.Text = "";
                        NomSalle.Text = "";



                        connexion.Close();
                    }
                }
                catch
                {
                    MessageBox.Show(" Echec De Connexion. ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(" Echec ! Champ(s) Vide(s). ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
