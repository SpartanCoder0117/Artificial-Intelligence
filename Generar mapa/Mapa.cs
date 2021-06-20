using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Practica1_v1
{
    class Mapa
    {
        private int totalColumnas;

        public DataTable CrearMapa(string ruta)
        {
            DataTable dtMapa = new DataTable();
            int numFila = 0, totalCol = 0;

            try
            {
                FileInfo fiArchivo = new FileInfo(ruta);
                StreamReader srLeerArchivo = new StreamReader(ruta, Encoding.UTF8);
                
                using(srLeerArchivo = fiArchivo.OpenText())
                {
                    string lineasTexto = string.Empty;
                    while((lineasTexto = srLeerArchivo.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(lineasTexto))
                            continue;

                        if (numFila == 0)
                        {
                            var obtenerColumnas = lineasTexto.Split(',');
                            totalCol = obtenerColumnas.Length;
                            SetColum(totalCol);
                            foreach (string itemCol in obtenerColumnas)
                                dtMapa.Columns.Add(itemCol.Split('\r')[0].Trim());
                            numFila++;
                        }
                        else
                        {
                            var obtenerFila = lineasTexto.Split(',');
                            if (string.IsNullOrEmpty(obtenerFila[0].Split('\r')[0].Trim()))
                                continue;
                            DataRow drFila = dtMapa.NewRow();
                            int contCol = 0;
                            foreach (var itemFila in obtenerFila)
                            {
                                if(contCol < totalCol)
                                    drFila[contCol] = itemFila.Split('\r')[0].Trim();
                                contCol++;                                
                            }
                            dtMapa.Rows.Add(drFila);
                        }
                    }
                }
                return dtMapa;
            }
            catch
            {
                MessageBox.Show("No se pudo crear el mapa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public void ColorMapa(DataGridView dataGridView)
        {
            int n = GetColum();
            try
            {
                int m = n;
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        string texto = dataGridView.Rows[j].Cells[i].Value.ToString();
                        int numero = Convert.ToInt32(texto);
                        ColorCelda(j, i, numero, dataGridView);
                    }
                }
            }
            catch
            {
                MessageBox.Show("No se puede aplicar el color\n Verifique el tamaño de la matriz",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ColorCelda(int fila, int columna, int num, DataGridView dataGrid)
        {
            switch (num)
            {
                case 0:
                    dataGrid.Rows[fila].Cells[columna].Style.BackColor = Color.Gray;
                    dataGrid.Rows[fila].Cells[columna].Style.ForeColor = Color.Gray;
                    break;
                case 1:
                    dataGrid.Rows[fila].Cells[columna].Style.BackColor = Color.SandyBrown;
                    //dataGrid.Rows[fila].Cells[columna].Style.ForeColor = Color.SandyBrown;
                    break;
                case 2:
                    dataGrid.Rows[fila].Cells[columna].Style.BackColor = Color.Blue;
                    dataGrid.Rows[fila].Cells[columna].Style.ForeColor = Color.Blue;
                    break;
                case 3:
                    dataGrid.Rows[fila].Cells[columna].Style.BackColor = Color.Orange;
                    dataGrid.Rows[fila].Cells[columna].Style.ForeColor = Color.Orange;
                    break;
                case 4:
                    dataGrid.Rows[fila].Cells[columna].Style.BackColor = Color.ForestGreen;
                    dataGrid.Rows[fila].Cells[columna].Style.ForeColor = Color.ForestGreen;
                    break;
                case 5:
                    dataGrid.Rows[fila].Cells[columna].Style.BackColor = Color.Purple;
                    dataGrid.Rows[fila].Cells[columna].Style.ForeColor = Color.Purple;
                    break;
                case 6:
                    dataGrid.Rows[fila].Cells[columna].Style.BackColor = Color.White;
                    dataGrid.Rows[fila].Cells[columna].Style.ForeColor = Color.White;
                    break;
                default:
                    break;
            }
        }

        public void AutoSizeCol(DataGridView dataGridView)
        {
            for (int i = 0; i < GetColum(); i++)
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void SetColum(int tamaño)
        {
            totalColumnas = tamaño;
        }

        private int GetColum()
        {
            return totalColumnas;
        }

        public void CambiarTerreno(DataGridView dataGridView, int fila, int col, string val)
        {
            try
            {
                dataGridView.Rows[fila].Cells[col].Value = val;
                int num = Convert.ToInt32(val);
                ColorCelda(fila, col, num, dataGridView);
            }
            catch
            {
                MessageBox.Show("No se pudo cambiar el terreno", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EnmascararMapa(DataGridView dataGridView)
        {
            int n = GetColum();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    dataGridView.Rows[j].Cells[i].Style.BackColor = Color.Black;
                    dataGridView.Rows[j].Cells[i].Style.ForeColor = Color.Black;
                }
            }
        }
    }
}