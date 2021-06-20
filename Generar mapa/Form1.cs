using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Practica1_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int numeroCelda;
        private int numeroFila;

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            Archivo archivo = new Archivo();
            archivo.ObtenerArchivo(dataGridView1, openFileDialog1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Informacion informacion = new Informacion();
            Sensores sensores = new Sensores();
            Seres seres = new Seres();
            numeroCelda = e.ColumnIndex;
            numeroFila = e.RowIndex;
            informacion.TipoTerreno(dataGridView1, numeroFila, numeroCelda, textBox1, TipoTerreno, Coordenadas);
            sensores.Izquierda(dataGridView1, numeroFila, numeroCelda);
            sensores.Derecha(dataGridView1, numeroFila, numeroCelda);
            sensores.Arriba(dataGridView1, numeroFila, numeroCelda);
            sensores.Abajo(dataGridView1, numeroFila, numeroCelda);
            seres.Humano(dataGridView1, numeroFila, numeroCelda);
            //sensores.Centro(dataGridView1, numeroFila, numeroCelda);
            //informacion.MarcaPosiciones(dataGridView1, numeroFila, numeroCelda);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Informacion informacion2 = new Informacion();
            informacion2.NumerosFilas(sender);
        }

        private void BtnCambioTerreno_Click(object sender, EventArgs e)
        {
            Mapa mapa = new Mapa();

            if(rbMuro.Checked == true)
            {
                mapa.CambiarTerreno(dataGridView1, numeroFila, numeroCelda, "0");
            }
            else if(rbTierra.Checked == true)
            {
                mapa.CambiarTerreno(dataGridView1, numeroFila, numeroCelda, "1");
            }
            else if (rbAgua.Checked == true)
            {
                mapa.CambiarTerreno(dataGridView1, numeroFila, numeroCelda, "2");
            }
            else if (rbArena.Checked == true)
            {
                mapa.CambiarTerreno(dataGridView1, numeroFila, numeroCelda, "3");
            }
            else if (rbBosque.Checked == true)
            {
                mapa.CambiarTerreno(dataGridView1, numeroFila, numeroCelda, "4");
            }
            else if (rbPantano.Checked == true)
            {
                mapa.CambiarTerreno(dataGridView1, numeroFila, numeroCelda, "5");
            }
            else if (rbNieve.Checked == true)
            {
                mapa.CambiarTerreno(dataGridView1, numeroFila, numeroCelda, "6");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}