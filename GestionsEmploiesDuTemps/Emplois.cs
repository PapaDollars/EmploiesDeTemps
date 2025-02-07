﻿using System;
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
            afficheSalle();
            afficheMatiere();
            afficheMatricule();
            afficheSemaine();
            refresh();
           
        }

        public void refresh()
        {
        //fonction rechercher
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "SELECT IdSemC,IdEnsC,Heures,Dates,CodeMatC,CodeSalC,IdCours from cours";
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
            String semaine   = comboBox4.Text;
            String matricule = comboBox3.Text;
            String date = dates.Text;
            String heure = heures.GetItemText(heures.SelectedItem);
            String CodeSalle = comboBox2.Text;
            String salle = NomSalle.Text;
            String CodeMat = comboBox1.Text;
            String libelleMat = LibeleMatiere.Text;
            comboBox3.Focus();
             string heu="";
             string Ens="";
             string dat = "";
             string semain ="";
             string codesal = "";
             int exist = 0;
             int exist2 = 0;

             if (semaine != "" & salle != "" & date != "" & CodeSalle != "" & matricule != "")
             {
                 if (heure == "07H30-09H30" | heure == "09H45-11H45" | heure == "12H00-14H00" | heure == "14H45-16H15" | heure == "16H30-18H30" | heure == "18H45-20H45" | heure == "21H00-23H00")
                 {
                     MySqlConnection con = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                     con.Open();

                     string search = "select IdEnsC,Heures,Dates,IdSemC,CodeSalC from cours";

                     MySqlCommand cmmd = new MySqlCommand(search, con);
                     MySqlDataReader myReader;
                     myReader = cmmd.ExecuteReader();
                     while (myReader.Read())
                     {
                         Ens = myReader.GetString("IdEnsC");
                         heu = myReader.GetString("Heures");
                         dat = myReader.GetString("Dates");
                         semain = myReader.GetString("IdsemC");
                         codesal = myReader.GetString("CodeSalC");
                         if (semain == semaine & heu == heure & date == dat & codesal == CodeSalle)
                         {
                             exist += 1;
                         }
                         if (heure == heu & codesal == CodeSalle & Ens == matricule) 
                         { 
                             exist2 += 1; 
                         }
                     }

                     if (exist == 0 & exist2 == 0)
                     {
                         try
                         {
                             MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                             connexion.Open();
                             // La commande Insert.
                             string sql = "INSERT INTO cours (Heures, Dates, IdSemC, IdEnsC, CodeMatC, CodeSalC) VALUES (@heures,@dates,@idsemaine,@idEnseignant,@matCours,@CodeSal)";

                             MySqlCommand cmd = connexion.CreateCommand();
                             cmd.CommandText = sql;

                             cmd.CommandText = "INSERT INTO cours (Heures, Dates, IdSemC, IdEnsC, CodeMatC, CodeSalC) VALUES (@heures,@dates,@idsemaine,@idEnseignant,@matCours,@CodeSal) ";

                             cmd.Parameters.AddWithValue("@heures", heures.Text);
                             cmd.Parameters.AddWithValue("@dates", dates.Text);
                             cmd.Parameters.AddWithValue("@idsemaine", comboBox4.Text);
                             cmd.Parameters.AddWithValue("@idEnseignant", comboBox3.Text);
                             cmd.Parameters.AddWithValue("@matCours", comboBox1.Text);
                             cmd.Parameters.AddWithValue("@CodeSal", comboBox2.Text);

                             cmd.ExecuteNonQuery();

                             MessageBox.Show("Ajouter Avec Succes ! ", "Reservation Cours", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             refresh();
                             connexion.Close();
                         }
                         catch
                         {
                             MessageBox.Show(" Echec De Connexion. ", " Attention ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                     }
                     else
                     {
                         MessageBox.Show("L'heure est deja prise ! ", "Erreur Cours", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
                 else
                 {
                     MessageBox.Show(" Erreur ! L'Heure saisie n'existe pas ! Veillez choisir parmis les heures lister", " Attention Heure ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }

                 
             }
             else {

                 MessageBox.Show(" Impossible de enregister. il y'a Un(des) Champ(s) Vide(s). ", "Enregistrement Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
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

                comboBox4.Text = dataGridEmplois.Rows[e.RowIndex].Cells[0].Value.ToString();
                dates.Text = dataGridEmplois.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox3.Text = dataGridEmplois.Rows[e.RowIndex].Cells[1].Value.ToString();
                heures.Text = dataGridEmplois.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox2.Text = dataGridEmplois.Rows[e.RowIndex].Cells[5].Value.ToString();
                idCours.Text = dataGridEmplois.Rows[e.RowIndex].Cells[6].Value.ToString();
                comboBox1.Text = dataGridEmplois.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
        //Actualiser
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            string recherch = recherche.Text;
            string semaineRe = semaineRecherche.Text;

            if (recherch == "" && semaineRe == "")
            {
                refresh();
            }
            if(recherch != "" && semaineRe == "") {

                string search = "select  IdSemC,IdEnsC,Heures,Dates,CodeMatC,CodeSalC from cours where  IdEnsC='" + recherche.Text + "'; ";

                MySqlCommand cmmd = new MySqlCommand(search, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridEmplois.DataSource = dt;
            
            }
            if (recherch == "" && semaineRe != "")
            {

                string search = "select  IdSemC,IdEnsC,Heures,Dates,CodeMatC,CodeSalC from cours where  IdSemC='" + semaineRecherche.Text + "'; ";

                MySqlCommand cmmd = new MySqlCommand(search, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridEmplois.DataSource = dt;

            }
            if (recherch != "" && semaineRe != "")
            {// "SELECT IdSemC,IdEnsC,Heures,Dates,CodeMatC,LibMat,CodeSalC,NomSalle from cours";
                string search = "select  IdSemC,IdEnsC,Heures,Dates,CodeMatC,CodeSalC from cours where  IdEnsC='" + recherche.Text + "' and IdSemC ='" + semaineRecherche.Text + "';";

                MySqlCommand cmmd = new MySqlCommand(search, connexion);
                MySqlDataAdapter data = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dataGridEmplois.DataSource = dt;
            
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        //Annuler
            comboBox4.Text = "";
            comboBox3.Text = "";
            dates.Text = "";
            
            heures.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            NomSalle.Text = "";
            LibeleMatiere.Text = "";
            comboBox3.Focus();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        //Modifier

            //Enregistrer
            String semaine = comboBox4.Text;
            String matricule = comboBox3.Text;
            String date = dates.Text;
            String heure = heures.GetItemText(heures.SelectedItem);
            String CodeSalle = comboBox2.Text;
            String salle = NomSalle.Text;
            String CodeMat = comboBox1.Text;
            String libelleMat = LibeleMatiere.Text;
            comboBox3.Focus();
            string heu = "";
            string dat = "";
            string semain = "";
            string codesal = "";
            int exist = 0;

            if (semaine != "" & salle != "" & date != "" & CodeSalle != "" & matricule != "")
            {
                if (heure == "07H30-09H30" | heure == "09H45-11H45" | heure == "12H00-14H00" | heure == "14H45-16H15" | heure == "16H30-18H30" | heure == "18H45-20H45" | heure == "21H00-23H00")
                {
                    MySqlConnection con = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                    con.Open();

                    string search = "select Heures,Dates,IdSemC,CodeSalC from cours";

                    MySqlCommand cmmd = new MySqlCommand(search, con);
                    MySqlDataReader myReader;
                    myReader = cmmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        heu = myReader.GetString("Heures");
                        dat = myReader.GetString("Dates");
                        semain = myReader.GetString("IdsemC");
                        codesal = myReader.GetString("CodeSalC");
                        if (semain == semaine & heu == heure & date == dat & codesal == CodeSalle)
                        {
                            exist += 1;
                        }

                    }


                    if (exist == 0)
                    {
                        try
                        {
                            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                            connexion.Open();

                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = connexion; //(IdEns, NomEns, PrenomEns , SexeEns , AgeEns)
                            cmd.CommandText = String.Format("update cours set Heures='{0}',Dates='{1}',IdSemC='{2}',CodeMatC='{3}',CodeSalC='{4}' where IdEnsC='{5}' and IdCours={6}", heures.Text, dates.Text, comboBox4.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text, idCours.Text);

                            int r = cmd.ExecuteNonQuery();

                            if (r != 0)
                            {
                                MessageBox.Show("Cours a ete Bien Modifié", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                refresh();
                                connexion.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show(" Echec de Modifier ", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("L'heure est deja prise ! ", "Erreur Cours", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(" Erreur ! L'Heure saisie n'existe pas ! Veillez choisir parmis les heures lister", " Attention Heure ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {

                MessageBox.Show(" Impossible de enregister. il y'a Un(des) Champ(s) Vide(s). ", "Enregistrement Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
        //Supprimer
            String semaine = comboBox4.Text;
            String matricule = comboBox3.Text;
            String date = dates.Text;
            String heure = heures.GetItemText(heures.SelectedItem);
            String CodeSalle = comboBox2.Text;
            String salle = NomSalle.Text;
            String CodeMat = comboBox1.Text;
            String libelleMat = LibeleMatiere.Text;
            comboBox3.Focus();

            if (matricule == "" | semaine == "" | salle == "" | CodeSalle == "" | date == "") { MessageBox.Show(" Impossible de Supprimer. il y'a Un(des) Champ(s) Vide(s). ", "Modification Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                if (heure == "07H30-09H30" | heure == "09H45-11H45" | heure == "12H00-14H00" | heure == "14H45-16H15" | heure == "16H30-18H30" | heure == "18H45-20H45" | heure == "21H00-23H00")
                {
                    try
                    {
                        MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                        connexion.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connexion;
                        cmd.CommandText = String.Format("delete from cours where IdCours={0}",idCours.Text);

                        int r = cmd.ExecuteNonQuery();
                        if (r != 0)
                        {
                            MessageBox.Show("Cours a ete Bien Annuler", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refresh();
                            comboBox4.Text = "";
                            comboBox3.Text = "";
                            dates.Text = "";

                            heures.Text = "";
                            comboBox2.Text = "";
                            comboBox1.Text = "";
                            NomSalle.Text = "";
                            LibeleMatiere.Text = "";
                            comboBox3.Focus();

                            connexion.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show(" Echec de Suppression ", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(" Erreur ! L'Heure saisie n'existe pas ! Veillez choisir parmis les heures lister", " Attention Heure ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        //Supprimer en cascade
            String semaine = comboBox4.Text;
            String matricule = comboBox3.Text;
            String date = dates.Text;
            String heure = heures.GetItemText(heures.SelectedItem);
            String CodeSalle = comboBox2.Text;
            String salle = NomSalle.Text;
            String CodeMat = comboBox1.Text;
            String libelleMat = LibeleMatiere.Text;
            comboBox3.Focus();

            if (matricule == "" | semaine == "" | salle == "" | CodeSalle == "" | date == "") { MessageBox.Show(" Impossible de Supprimer. il y'a Un(des) Champ(s) Vide(s). ", "Modification Impossible", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                if (heure == "07H30-09H30" | heure == "09H45-11H45" | heure == "12H00-14H00" | heure == "14H45-16H15" | heure == "16H30-18H30" | heure == "18H45-20H45" | heure == "21H00-23H00")
                {
                    try
                    {
                        MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
                        connexion.Open();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connexion;
                        cmd.CommandText = String.Format("delete from cours where IdEnsC='{0}' and idSemC = '{1}' ", comboBox3.Text, comboBox4.Text);

                        int r = cmd.ExecuteNonQuery();
                        if (r != 0)
                        {
                            MessageBox.Show("Cours a ete  Bien Annuler", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            refresh();
                            comboBox4.Text = "";
                            comboBox3.Text = "";
                            dates.Text = "";
                            heures.Text = "";
                            comboBox2.Text = "";
                            comboBox1.Text = "";
                            NomSalle.Text = "";
                            LibeleMatiere.Text = "";
                            comboBox3.Focus();

                            connexion.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show(" Echec de Suppression ", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(" Erreur ! L'Heure saisie n'existe pas ! Veillez choisir parmis les heures lister", " Attention Heure ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

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
        public  void afficheSalle(){
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "select * from salle";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataReader myReader;

                myReader = cmmd.ExecuteReader();
                while (myReader.Read())
                {
                    string nom = myReader.GetString("CodeSal");
                    comboBox2.Items.Add(nom);
                }
                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        
        }
        public  void afficheMatiere()
        {
           
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "select * from matiere";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataReader myReader;

                myReader = cmmd.ExecuteReader();
                while (myReader.Read())
                {
                    string nom = myReader.GetString("CodeMat");
                    comboBox1.Items.Add(nom);
                     
                   
                }
                

                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        void afficheMatricule()
        {
           
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "select * from enseignant ";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataReader myReader;

                myReader = cmmd.ExecuteReader();
                while (myReader.Read())
                {
                    string nom = myReader.GetString("IdEns");
                    comboBox3.Items.Add(nom);


                }


                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        void afficheSemaine()
        {

            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "select * from semaine ";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataReader myReader;

                myReader = cmmd.ExecuteReader();
                while (myReader.Read())
                {
                    string nom = myReader.GetString("NumSem");
                    comboBox4.Items.Add(nom);


                }


                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "select * from matiere where CodeMat='" + comboBox1.Text + "'; ";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataReader myReader;

                myReader = cmmd.ExecuteReader();
                while (myReader.Read())
                {
                    string nom = myReader.GetString("LibMat");
                    LibeleMatiere.Text = nom;
                }
                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection connexion = new MySqlConnection("database=time_management ; server=localhost ; user id=root ; pwd=");
            connexion.Open();
            try
            {
                string requete = "select * from salle where CodeSal='" + comboBox2.Text + "'; ";
                MySqlCommand cmmd = new MySqlCommand(requete, connexion);
                MySqlDataReader myReader;

                myReader = cmmd.ExecuteReader();
                while (myReader.Read())
                {
                    string nom = myReader.GetString("NomSalle");
                    NomSalle.Text = nom;
                }
                connexion.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void dates_ValueChanged(object sender, EventArgs e)
        {

        }

        private void heures_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }
}
