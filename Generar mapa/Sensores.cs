using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_v1
{
    class Sensores
    {
        Mapa mapa = new Mapa();

        public void Izquierda(DataGridView dataGridView, int fila, int colu)
        {
            try
            {
                colu -= 1;
                int valor = Convert.ToInt32(dataGridView.Rows[fila].Cells[colu].Value.ToString());
                mapa.ColorCelda(fila, colu, valor, dataGridView);
            }
            catch
            {
            }
        }

        public void Derecha(DataGridView dataGridView, int fila, int colu)
        {
            try
            {
                colu += 1;
                int valor = Convert.ToInt32(dataGridView.Rows[fila].Cells[colu].Value.ToString());
                mapa.ColorCelda(fila, colu, valor, dataGridView);
            }
            catch
            {
            }
        }

        public void Arriba(DataGridView dataGridView, int fila, int colu)
        {
            try
            {
                fila -= 1;
                int valor = Convert.ToInt32(dataGridView.Rows[fila].Cells[colu].Value.ToString());
                mapa.ColorCelda(fila, colu, valor, dataGridView);
            }
            catch
            {
            }
        }

        public void Abajo(DataGridView dataGridView, int fila, int colu)
        {
            try
            {
                fila += 1;
                int valor = Convert.ToInt32(dataGridView.Rows[fila].Cells[colu].Value.ToString());
                mapa.ColorCelda(fila, colu, valor, dataGridView);
            }
            catch
            {
            }
        }
    }
}