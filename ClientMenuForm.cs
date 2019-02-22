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
    public partial class ClientMenuForm : Form
    {
        public ClientMenuForm()
        {
            InitializeComponent();

            label1.Text = "Buna ziua," + GlobalUsers.GlobalClient.Prenume;
            label2.Text = "Adresa:" + GlobalUsers.GlobalClient.Adresa;
            label3.Text = "Telefon:" + GlobalUsers.GlobalClient.Telefon;
            label4.Text = "Email:" + GlobalUsers.GlobalClient.Email;

            listBox1.Items.Clear();

            List<Comanda> commandlist = ComandaController.GetComandaByClientID(GlobalUsers.GlobalClient.ID);

            foreach (Comanda c in commandlist)
            {

                string format = "#" + c.ID +"  "+ c.AdresaDest +"  "+ c.Descriere + " Status:" + ComandaController.StatusToText( ComandaController.GetStatus(c.ID) );
                listBox1.Items.Add(format);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientMenuModifyForm ClientMenuModify = new ClientMenuModifyForm();
            ClientMenuModify.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            label1.Text = "Buna ziua," + GlobalUsers.GlobalClient.Prenume;
            label2.Text = "Adresa:" + GlobalUsers.GlobalClient.Adresa;
            label3.Text = "Telefon:" + GlobalUsers.GlobalClient.Telefon;
            label4.Text = "Email:" + GlobalUsers.GlobalClient.Email;

            listBox1.Items.Clear();

            List<Comanda> commandlist = ComandaController.GetComandaByClientID(GlobalUsers.GlobalClient.ID);

            foreach (Comanda c in commandlist)
            {

                string format = "#"+c.ID + "  " + c.AdresaDest + "  " + c.Descriere + " Status:" + ComandaController.StatusToText(ComandaController.GetStatus(c.ID));
                listBox1.Items.Add(format);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientAddCommand ClientAdd = new ClientAddCommand();
            ClientAdd.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
