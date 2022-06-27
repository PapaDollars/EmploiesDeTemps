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
            Emplois form = new Emplois();
            form.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Enregistrer
            String idSemaine = NomSalle.Text;
            //String heure = heures.GetItemText(heures.SelectedItem);

            if (idSemaine != "" )
            {
                //if (heure == "07H30-09H30" | heure == "09H45-11H45" | heure == "12H00-14H00" | heure == "14H45-16H15" | heure == "16H30-18H30" | heure == "18H45-20H45" | heure == "21H00-23H00")
               // {
                    try
                    {
                        MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");

                        connexion.Open();
                        // La commande Insert.
                        string sql = "INSERT INTO semaine (IdSem) "
                                                            + " values (@idsem) ";
                        MySqlCommand cmd = connexion.CreateCommand();
                        cmd.CommandText = sql;

                        cmd.CommandText = "INSERT INTO semaine (IdSem) "
                                                            + " values (@idsem) ";

                        cmd.Parameters.AddWithValue("@idsem", NomSalle.Text);
                        //cmd.Parameters.AddWithValue("@heures", heures.GetItemText(heures.SelectedItem));

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Semaine a ete ajouter Avec Succes ! ", "Ajout Semaine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //refresh();
                        connexion.Close();
                    }
                    catch
                    {
                        MessageBox.Show(" Echec De Connexion. ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                //}
                //else
                //{
                  //  MessageBox.Show(" Erreur ! L'Heure saisie n'existe pas ! Veillez choisir parmis les heures lister", " Attention Heure ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}


            }
            else { MessageBox.Show(" Echec ! Champ(s) Vide(s). ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void NomSalle_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NomSalle.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //supprimer
            String idSemaine = NomSalle.Text;


            if (idSemaine == "" ) { MessageBox.Show(" Impossible de Supprimer. il y'a Un(des) Champ(s) Vide(s). ", "Modification Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

            if (idSemaine == "") { MessageBox.Show(" Impossible de modifier. il y'a Un(des) Champ(s) Vide(s). ", "Modification Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion; 
                    cmd.CommandText = String.Format("update semaine set IdSem='{0}' where  IdSem='{0}'", NomSalle.Text);
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
