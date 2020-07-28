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
            cargarPreguntas("sistemas");
            
           

        }
        int click = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            click++;
            // "cargar" fue declarado en el archivo de prolog
            //PlQuery cargar = new PlQuery("cargar('test.bd')");
            // cargar.NextSolution();

            /*
                El ciclo va recorriendo los labels gracias al metodo obtenerElementoPorIndice(), los labels
                que tienen las preguntas están enumerados del 1 al 5 esto para que puedan recorrerse
            */

            //preguntasSistemas();
            //preguntasAdministracion();

            if (click < 0) {
                click = 0;
            }else
            if (click > 5)
            {
                click = 5;
            }

            switch (click)
            {
                case 0:
                    cargarPreguntas("sistemas");
                    
                    break;
                case 1:
                    preguntasSistemas();
                    cargarPreguntas("administracion");
                    break;
                case 2:
                    cargarPreguntas("gastronomia");
                    break;
                case 3:
                    cargarPreguntas("civil");
                    break;
                case 4:
                    cargarPreguntas("medicina");
                    break;
                case 5:
                    cargarPreguntas("arqueologia");
                    break;
            }






        }//button click

        //metodo que consulta en la BD las preguntas de una carrera y las carga en los Lables
        private void cargarPreguntas(String carrera) {
            String[] Pa = new string[5];//PREGUNTAS
            int contador = 0;
            //listBox1.Items.Clear();
            PlQuery cargar = new PlQuery("cargar('test.bd')");
            cargar.NextSolution();

            PlQuery consultas = new PlQuery("pregunta(X,"+carrera+")");
            
            foreach (PlQueryVariables z in consultas.SolutionVariables)
            {
                  //listBox1.Items.Add(z["X"]);
                  Pa[contador] = z["X"].ToString();
               
                  //MessageBox.Show(Pa[contador]);
                  contador++;
            }

            label_p1_sistemas.Text = Pa[0];
            label_p2_sistemas.Text = Pa[1];
            label_p3_sistemas.Text = Pa[2];
            label_p4_sistemas.Text = Pa[3];
            label_p5_sistemas.Text = Pa[4];
            contador = 0;

        }
        private void preguntasSistemas() {
            List<String> respondidos = new List<String>();
            respondidos = responder();
            //Respondidos guarda los valores de todos los RadioButtons

            for (int i = 0; i < 5; i++)
            {
                String pregunta = String.Format("consultar('{0}',{1},{2})", obtenerElementoPorIndice(this.Controls, i + 1), "sistemas", respondidos[i]);
               
                MessageBox.Show(pregunta);
                PlQuery consulta = new PlQuery(pregunta);
                 MessageBox.Show(consulta.NextSolution().ToString());
            }
        }


        private void preguntasAdministracion()
        {
        }
        private void preguntasGastronomia() 
        {
        }
        private void preguntasCivil()
        {
        }
        private void preguntasMeduicina()
        {
        }
        private void preguntasArqueologia()
        {
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

        private void label_p2_sistemas_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            click--;


            if (click < 0)
            {
                click = 0;
                
            }else

            if (click > 5)
            {
                click = 5;
            }

            switch (click)
            {
                case 0:
                    cargarPreguntas("sistemas");
                    break;
                case 1:
                    cargarPreguntas("administracion");
                    break;
                case 2:
                    cargarPreguntas("gastronomia");
                    break;
                case 3:
                    cargarPreguntas("civil");
                    break;
                case 4:
                    cargarPreguntas("medicina");
                    break;
                case 5:
                    cargarPreguntas("arqueologia");
                    break;
            }

        }
    }
}
