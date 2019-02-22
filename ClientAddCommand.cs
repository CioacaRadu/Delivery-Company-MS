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
    public partial class ClientAddCommand : Form
    {
        public ClientAddCommand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comanda command = new Comanda();
            command.Expeditor = GlobalUsers.GlobalClient.ID;
            command.AdresaDest = textBox1.Text;
            command.Descriere = textBox2.Text;

            command.ID = ComandaController.InsertCommand(command);
            DeliveryController.AssignCommandStage1(command.ID);

            this.Hide();
        }
    }
}
