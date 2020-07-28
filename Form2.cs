using SbsSW.SwiPlCs;
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

        public string recibirDatos;
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            limpiarArchivo();
            F.Visible = true;
            this.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("Path", @"C:\\Program Files (x86)\\swipl\bin");
            limpiarArchivo();
            Form1 f = new Form1();
            label1.Text = recibirDatos;
            f.carreraElegida = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            limpiarArchivo();
            Application.Exit();


        }

        private void Form2_Shown(Object sender, EventArgs e)
        {

            MessageBox.Show("Hola mundo");
        }

        private void limpiarArchivo()
        {
            string[] p = { "-q", "-f", @"test.pl" };
            PlEngine.PlCleanup();
        }

    }
}
