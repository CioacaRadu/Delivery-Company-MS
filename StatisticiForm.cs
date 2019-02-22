using Curier.Controller;
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
    public partial class StatisticiForm : Form
    {
        public StatisticiForm()
        {
            InitializeComponent();
            label1.Text = "Comenzi efectuate cu succes: " + StatsController.GetSuccessCommands().ToString();
            label5.Text = "Clienti: " + StatsController.GetClientsNumber().ToString();
            label2.Text = "Comenzi active: " + StatsController.GetActiveCommands().ToString();
            label3.Text = "Depozite: " + StatsController.GetDepositsNumber().ToString();
            label4.Text = "Cel mai activ curier: " + StatsController.GetBestCurier().Nume + " " + StatsController.GetBestCurier().Prenume;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
