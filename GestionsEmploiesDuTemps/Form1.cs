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
    public partial class Form1 : Form
    {
        public void ConnectionImpossible()
        {
            try
            {
                MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                connexion.Open();
                bool p; String names = connecteNom.Text, passwords = connecteMatricule.Text;

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connexion;
                cmd.CommandText = String.Format("select IdEns,NomEns from enseignant where IdEns ='{0}' AND NomEns ='{1}' ", passwords, names);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) p = true; else p = false;
                if (p == false)
                {
                    MessageBox.Show(" Impossible d'Ouvrir ! Veillez Vous Connecter.  ", "Compte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch { MessageBox.Show(" NOM ou MATRICULE Invalide.  ", "Compte", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            //Connection Impossible
            ConnectionImpossible();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Connection Impossible
            ConnectionImpossible();
        }
       
        private void label6_Click_1(object sender, EventArgs e)
        {
          Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(connecteMatricule.Text != "" | connecteNom.Text != "")
            {
                try
                {
                    MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                    connexion.Open();
                    bool p; String names = connecteNom.Text, passwords = connecteMatricule.Text;

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connexion;
                    cmd.CommandText = String.Format("select IdEns,NomEns from enseignant where IdEns ='{0}' AND NomEns ='{1}' ", passwords, names);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows) p = true; else p = false;
                
                    if (p == true)
                    {
                        MessageBox.Show("CONNEXION REUSSI !  ", "CONNEXION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Enseignants objects = new Enseignants();
                        objects.Show();
                        this.Hide();

                        connexion.Close();
                    }
                    else { MessageBox.Show(" NOM ou MATRICULE Invalide.  ", "Compte", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
                catch { MessageBox.Show(" La Connexion a Echouer.  ", "Compte", MessageBoxButtons.OK, MessageBoxIcon.Error); }    
           }
            else { MessageBox.Show(" NOM ou MATRICULE Est Vide.  ", "Compte", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                   
        }

        
    }
}
