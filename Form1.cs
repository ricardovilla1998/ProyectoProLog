﻿using SbsSW.SwiPlCs;
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
            btn_atras.Enabled = false;
            btn_finalizar.Enabled = false;
            //Ruta de instalacion de prolog
            Environment.SetEnvironmentVariable("Path", @"C:\\Program Files (x86)\\swipl\bin");
            //Cargar archivo prolog
            string[] p = { "-q", "-f", @"test.pl" };
            PlEngine.Initialize(p);
            cargarPreguntas("sistemas");
           //PlQuery cargar = new PlQuery("cargar('test.bd')");
           //cargar.NextSolution();

            puntos.Add(0);
            puntos.Add(0);
            puntos.Add(0);
            puntos.Add(0);
            puntos.Add(0);
            puntos.Add(0);


        }
        //VARIABLES GLOBALES
        int click = 0;
        String carreraActual = "";
        List<int> puntos = new List<int>();
        public String carreraElegida = "";



        private void button1_Click(object sender, EventArgs e)
        {
            puntos[click] = 0;
            guardarPuntos();
            click++;
        
           if(click == 0)
            {
                btn_atras.Enabled = false;
                btn_siguiente.Enabled = true;
                btn_finalizar.Enabled = false;
                click = 0;

            }
           else if(click == 5)
            {
                btn_atras.Enabled = true;
                btn_siguiente.Enabled = false;
                btn_finalizar.Enabled = true;
                click = 5;
                
            }
            else
            {
                btn_atras.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_finalizar.Enabled = false;
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






        }//button click

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

      


        private void label_p2_sistemas_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            puntos[click] = 0;
            click--;
            
            if (click == 0)
            {
                btn_atras.Enabled = false;
                btn_siguiente.Enabled = true;
                btn_finalizar.Enabled = false;
                click = 0;
                puntos[click] = 0;

            }
            else if (click == 5)
            {
                btn_atras.Enabled = true;
                btn_siguiente.Enabled = false;
                btn_finalizar.Enabled = true;
                click = 5;

            }
            else
            {
                btn_atras.Enabled = true;
                btn_siguiente.Enabled = true;
                btn_finalizar.Enabled = false;
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
        
        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            guardarPuntos();

            //Verificar que carrera tuvo más puntos
            int mayor = puntos.Max();
            List<int> ganadores = new List<int>();

            for(int i = 0; i < puntos.Count; i++)
            {
                if (puntos[i] == mayor)
                {
                    ganadores.Add(i);
                }
            }


            for (int i = 0; i < ganadores.Count; i++)
            {

                switch (ganadores[i])
                {
                    case 0: carreraElegida += "Ing Sistemas\n"; break;
                    case 1: carreraElegida += "Lic Administración\n"; break;
                    case 2: carreraElegida += "Gastronomia\n"; break;
                    case 3: carreraElegida += "Ing Civil\n"; break;
                    case 4: carreraElegida += "Medicina\n"; break;
                    case 5: carreraElegida += "Arqueologia\n"; break;


                }
            }

            MessageBox.Show("Su carrera o carreras ideales son:\n" + carreraElegida);
            label1.Text = label1.Text+"\n"+carreraElegida;
            
            //carreraElegida = "";
           
            Form2 F = new Form2();
            
            F.Show();
        }//btn_finalizar



        /* ============================================== METODOS ========================================================== */

        //metodo que consulta en la BD las preguntas de una carrera y las carga en los Labels
        private void cargarPreguntas(String carrera)
        {
            String[] Pa = new string[5];//PREGUNTAS
            int contador = 0;
            //listBox1.Items.Clear();
            carreraActual = carrera;
            PlQuery consultas = new PlQuery("pregunta(X," + carrera + ")");

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


        }//cargarPreguntas
        private void guardarPuntos()
        {
            List<String> respondidos = new List<String>();
            respondidos = responder();
            //Respondidos guarda los valores de todos los RadioButtons


            /*
                El ciclo va recorriendo los labels gracias al metodo obtenerElementoPorIndice(), los labels
                que tienen las preguntas están enumerados del 1 al 5 esto para que puedan recorrerse
            */

            for (int i = 0; i < 5; i++)
            {
                String pregunta = String.Format("consultar('{0}',{1},{2})", obtenerElementoPorIndice(this.Controls, i + 1), carreraActual, respondidos[i]);

                //MessageBox.Show(pregunta);
                PlQuery consulta = new PlQuery(pregunta);
                // MessageBox.Show(consulta.NextSolution().ToString());
                // MessageBox.Show(carreraActual + "");
                if (consulta.NextSolution())
                {
                    //Acumula puntos dependiendo la carrera
                    acumulaPuntos(carreraActual);
                }
            }
        }//guardarPuntos


        //Obtiene el valor de todos los RadioButtons y los guarda en una Lista
        private List<String> responder()
        {
            List<String> contestados = new List<String>();
            var radio_buttons = new[] { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5 }
                   .SelectMany(g => g.Controls.OfType<RadioButton>()
                                            .Where(r => r.Checked));
            foreach (var c in radio_buttons)
            {
                contestados.Add(c.Text.ToLower());
            }
            return contestados;


        }//responder


        //Mediante la propiedad TabIndex, obtiene el indice y el texto de el Label
        private static string obtenerElementoPorIndice(Control.ControlCollection controls, int index)
        {
            return controls.OfType<Control>()
                           .Where(c => c.TabIndex == index)
                           .Select(c => c.Text).First();
        }//obtenerElementoPorIndice

        //Acumular puntos
        private void acumulaPuntos(String carrera)
        {
            switch (carrera)
            {
                case "sistemas": puntos[0] += 1; break;
                case "administracion": puntos[1] += 1; break;
                case "gastronomia": puntos[2] += 1; break;
                case "civil": puntos[3] += 1; break;
                case "medicina": puntos[4] += 1; break;
                case "arqueologia": puntos[5] += 1; break;
            }
        }//acumulaPuntos




    }
}
