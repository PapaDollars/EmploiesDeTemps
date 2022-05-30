using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionsEmploiesDuTemps
{
    public partial class Form1 : Form
    {
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
            Enseignants objects = new Enseignants();
            objects.Show();
            this.Hide();
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
       
        private void label6_Click_1(object sender, EventArgs e)
        {
          Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        
    }
}
