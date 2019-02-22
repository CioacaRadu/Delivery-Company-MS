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
    public partial class ClientMenuModifyForm : Form
    {
        public ClientMenuModifyForm()
        {
            InitializeComponent();

            label1.Text = "Client:" + GlobalUsers.GlobalClient.Nume + " " + GlobalUsers.GlobalClient.Prenume;
            textBox1.Text = GlobalUsers.GlobalClient.Email;
            textBox2.Text = GlobalUsers.GlobalClient.Telefon;
            textBox3.Text = GlobalUsers.GlobalClient.Adresa;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client clientup = new Client();
            clientup.Email = textBox1.Text;
            clientup.Telefon = textBox2.Text;
            clientup.Adresa = textBox3.Text;
            ClientController.UpdateClientByID(GlobalUsers.GlobalClient.ID, clientup);

            GlobalUsers.GlobalClient.Email = clientup.Email;
            GlobalUsers.GlobalClient.Telefon = clientup.Telefon;
            GlobalUsers.GlobalClient.Adresa = clientup.Adresa;

            this.Hide();


        }
    }
}
