using Curier.Controller;
using Curier.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curier
{
    public partial class ClientLogForm : Form
    {
        public ClientLogForm()
        {
            InitializeComponent();
        }

        private void ClientLogForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {




            GlobalUsers.GlobalClient = ClientController.GetClientByEmail(emailloginbox.Text);
            if(GlobalUsers.GlobalClient == null)
            {

                MessageBox.Show("Wrong User");
                return;
            }
            

            Console.WriteLine(GlobalUsers.GlobalClient.Nume);

            this.Hide();
            ClientMenuForm ClientMenu = new ClientMenuForm();
            ClientMenu.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client newclient = new Client();
            newclient.Nume = textBox1.Text;
            newclient.Prenume = textBox5.Text;
            newclient.Email = textBox2.Text;
            newclient.Telefon = textBox3.Text;
            newclient.Adresa = textBox4.Text;

            ClientController.InsertClient(newclient);

            
        }
    }
}
