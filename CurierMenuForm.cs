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
    public partial class CurierMenuForm : Form
    {

         List<LivrareDepozit> commandlist;
        List<LivrareDepozit> commandlistc;

        public CurierMenuForm()
        {
            InitializeComponent();
            label1.Text = "Buna ziua," + GlobalUsers.GlobalCurier.Prenume;
            label2.Text = "Masina: " + CuriermanController.GetCarByID(GlobalUsers.GlobalCurier.ID).Numar;
            label3.Text = "Model: " + CuriermanController.GetCarByID(GlobalUsers.GlobalCurier.ID).Model;


            listBox1.Items.Clear();

            commandlist = CuriermanController.GetLDs(GlobalUsers.GlobalCurier.ID);

            foreach (LivrareDepozit c in commandlist)
            {

                string format = "#"+c.Comanda + "  Adresa Ridicare:" + c.AdresaExp + "  Depozit destinatie:" + c.Depozit + "  Status:" + c.Status;
                listBox1.Items.Add(format);
            }
            listBox2.Items.Clear();

            commandlistc = CuriermanController.GetLCs(GlobalUsers.GlobalCurier.ID);

            foreach (LivrareDepozit c in commandlistc)
            {

                string format = "#" + c.Comanda + "  Depozit Ridicare:" + c.Depozit + "  Adresa Destinatie:" + c.AdresaExp + " Status:" + c.Status;
                listBox2.Items.Add(format);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            comboBox1.Enabled = true;
            button3.Enabled = true;

            if (listBox1.SelectedIndex < 0) return;
            listBox2.ClearSelected();


            Console.WriteLine(listBox1.SelectedIndex);
            
            
                
            LivrareDepozit cc = commandlist[listBox1.SelectedIndex];

            label6.Text ="ID: " + cc.Comanda ;
            label7.Text ="Depozit: " + DepozitController.GetDepozitByID(cc.Depozit).Adresa;
            label8.Text ="Adresa: " + cc.AdresaExp;
            label10.Text ="Status: " + CuriermanController.StatusToText(cc.Status);

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            button3.Enabled = true;

            if (listBox2.SelectedIndex < 0) return;
            listBox1.ClearSelected();
            
            Console.WriteLine(listBox2.SelectedIndex);
            LivrareDepozit cc = commandlistc[listBox2.SelectedIndex];

            label6.Text = "ID: " + cc.Comanda;
            label7.Text = "Depozit: " + DepozitController.GetDepozitByID(cc.Depozit).Adresa;
            label8.Text = "Adresa: " + cc.AdresaExp;
            label10.Text = "Status: " + CuriermanController.StatusToText(cc.Status);



        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            int status = -1 ;
            int updatedcommand = -1;
            if (listBox1.SelectedIndex != -1 ) //Am selectat LIVRAREDEPOZIT
            {
                if (comboBox1.SelectedIndex == 0) status = 1;
                if (comboBox1.SelectedIndex == 1) status = 2;
                updatedcommand = commandlist[listBox1.SelectedIndex].Comanda;
            }

            if (listBox2.SelectedIndex != -1) //Am selectat LIVRARECLIENT
            {
                if (comboBox1.SelectedIndex == 2) status = 3;
                if (comboBox1.SelectedIndex == 3) status = 4;
                updatedcommand = commandlistc[listBox2.SelectedIndex].Comanda;
            }


            if (status != -1)
            {
                DeliveryController.UpdateCommand(updatedcommand, status); // trebuie implementanta
                MessageBox.Show(updatedcommand.ToString() + "||" + status.ToString());
            }
            else MessageBox.Show("Nu poti efectua");

            
            
        }

   

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Buna ziua," + GlobalUsers.GlobalCurier.Prenume;
            label2.Text = "Masina: " + CuriermanController.GetCarByID(GlobalUsers.GlobalCurier.ID).Numar;
            label3.Text = "Model: " + CuriermanController.GetCarByID(GlobalUsers.GlobalCurier.ID).Model;


            listBox1.Items.Clear();

            commandlist = CuriermanController.GetLDs(GlobalUsers.GlobalCurier.ID);

            foreach (LivrareDepozit c in commandlist)
            {

                string format = "#" + c.Comanda + "  Adresa Ridicare:" + c.AdresaExp + "  Depozit destinatie:" + c.Depozit + "  Status:" + c.Status;
                listBox1.Items.Add(format);
            }
            listBox2.Items.Clear();

            commandlistc = CuriermanController.GetLCs(GlobalUsers.GlobalCurier.ID);

            foreach (LivrareDepozit c in commandlistc)
            {

                string format = "#" + c.Comanda + "  Depozit Ridicare:" + c.Depozit + "  Adresa Destinatie:" + c.AdresaExp + " Status:" + c.Status;
                listBox2.Items.Add(format);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
