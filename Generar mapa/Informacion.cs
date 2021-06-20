using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_v1
{
    class Informacion
    {
        public void TipoTerreno(DataGridView dataGridView, int fila, int columna, TextBox textBox, Label label, Label label1)
        {
            string valor = dataGridView.Rows[fila].Cells[columna].Value.ToString();
            string nombreColumna = dataGridView.Columns[columna].HeaderText;
            string nombreFila = dataGridView.CurrentRow.Index.ToString();
            int numeroFila = Convert.ToInt32(nombreFila) + 1;
            int dato = Convert.ToInt32(valor); //.Substring(0,1)

            label1.Text = "Coordenada seleccionada:\n( " + numeroFila + " , " + nombreColumna + " )";

            switch (dato)
            {
                case 0:
                    label.Text = "Tipo de terreno:\nMuro/Montaña";
                    textBox.BackColor = Color.Gray;
                    break;
                case 1:
                    label.Text = "Tipo de terreno:\nTierra";
                    textBox.BackColor = Color.SandyBrown;
                    break;
                case 2:
                    label.Text = "Tipo de terreno:\nAgua";
                    textBox.BackColor = Color.Blue;
                    break;
                case 3:
                    label.Text = "Tipo de terreno:\nArena";
                    textBox.BackColor = Color.Orange;
                    break;
                case 4:
                    label.Text = "Tipo de terreno:\nBosque";
                    textBox.BackColor = Color.ForestGreen;
                    break;
                case 5:
                    label.Text = "Tipo de terreno:\nPantano";
                    textBox.BackColor = Color.Purple;
                    break;
                case 6:
                    label.Text = "Tipo de terreno:\nNieve";
                    textBox.BackColor = Color.White;
                    break;
                default:
                    break;
            }

        }

        public void NumerosFilas(object sender)
        {
            DataGridView dataGridView = sender as DataGridView;
            if(dataGridView != null)
            {
                foreach (DataGridViewRow r in dataGridView.Rows)
                    dataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString().Trim();
            }
        }

        /*public void MarcaPosiciones(DataGridView dataGridView, int fila, int columna)
        {
            string marcas = dataGridView.Rows[fila].Cells[columna].Value.ToString();
            if(marcas != "0")
            {
                marcas += ", V";
                dataGridView.Rows[fila].Cells[columna].Value = marcas;
            }
        }*/
    }
}