using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_v1
{
    class Archivo
    {
        public void ObtenerArchivo(DataGridView dataGridView, OpenFileDialog openFileDialog)
        {
            try
            {
                openFileDialog.InitialDirectory = @"C:\";
                openFileDialog.Title = "Carga de archivo";
                openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 2;
                openFileDialog.ShowReadOnly = true;
                openFileDialog.ReadOnlyChecked = true;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Mapa map = new Mapa();
                    string ruta = openFileDialog.FileName;
                    dataGridView.AutoGenerateColumns = true;
                    //dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None; //Quitar borde de celda
                    dataGridView.DataSource = map.CrearMapa(ruta);
                    map.ColorMapa(dataGridView);
                    map.AutoSizeCol(dataGridView);
                    map.EnmascararMapa(dataGridView);
                }

            }
            catch
            {
                MessageBox.Show("No se pudo cargar el archivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}