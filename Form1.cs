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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
     
            ClientLogForm ClientForm = new ClientLogForm();
            ClientForm.Show();


            this.Hide();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CurierLogForm CurierForm = new CurierLogForm();
            button1.Enabled = false;
            button2.Enabled = false;
     
            CurierForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new StatisticiForm()).Show();
        }
    }
}
