using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTestEquipo3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
           
            //MessageBox.Show(F.carreraElegida.ToString());
            label1.Text = F.carreraElegida;
            F.carreraElegida = "";
        }

        private void Form2_Shown(Object sender, EventArgs e)
        {

            MessageBox.Show("Hola mundo");
        }

    }
}
