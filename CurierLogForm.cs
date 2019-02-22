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
    public partial class CurierLogForm : Form
    {
        public CurierLogForm()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            GlobalUsers.GlobalCurier = CuriermanController.GetCurierByID(Int32.Parse(textBox1.Text));

            if(GlobalUsers.GlobalCurier == null)
            {
                MessageBox.Show("Wrong ID");
                return;
            }
            new CurierMenuForm().Show();

            
        }
    }
}
