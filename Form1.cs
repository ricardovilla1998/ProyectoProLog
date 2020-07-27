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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            //Ruta de instalacion de prolog
            Environment.SetEnvironmentVariable("Path", @"C:\\Program Files (x86)\\swipl\bin");
            //Cargar archivo prilig
            string[] p = { "-q", "-f", @"test.pl" };
            PlEngine.Initialize(p);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // "cargar" fue declarado en el archivo de prolog
            //PlQuery cargar = new PlQuery("cargar('test.bd')");
            // cargar.NextSolution();


            /*
                El ciclo va recorriendo los labels gracias al metodo obtenerElementoPorIndice(), los labels
                que tienen las preguntas están enumerados del 1 al 5 esto para que puedan recorrerse
            */


            //Respondidos guarda los valores de todos los RadioButtons
            List<String> respondidos = new List<String>();
            respondidos = responder();

            for (int i = 0; i < 5; i++)
            {
                String pregunta = String.Format("consultar('{0}',{1},{2})", obtenerElementoPorIndice(this.Controls,i+1), "sistemas", respondidos[i]);
                MessageBox.Show(pregunta);
                PlQuery consulta = new PlQuery(pregunta);
                MessageBox.Show(consulta.NextSolution().ToString());
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Obtiene el valor de todos los RadioButtons y los guarda en una Lista
        private List<String> responder()
        {
            List<String> contestados = new List<String>();
            var radio_buttons = new[] { groupBox1,groupBox2,groupBox3,groupBox4,groupBox5}
                   .SelectMany(g => g.Controls.OfType<RadioButton>()
                                            .Where(r => r.Checked));
            foreach (var c in radio_buttons)
            {
                contestados.Add(c.Text.ToLower());
            }
            return contestados;


        }
       

        //Mediante la propiedad TabIndex, obtiene el indice y el texto de el Label
        private static string obtenerElementoPorIndice(Control.ControlCollection controls, int index)
        {
            return controls.OfType<Control>()
                           .Where(c => c.TabIndex == index)
                           .Select(c => c.Text).First();
        }
    }
}
