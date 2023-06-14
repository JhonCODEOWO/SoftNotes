using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeNote
{
    public partial class WritingNote : Form
    {
        BD_Methos bd_method = new BD_Methos();
        Metodos metodos = new Metodos();
        public WritingNote()
        {
            InitializeComponent();
        }

        private void WritingNote_Load(object sender, EventArgs e)
        {
            rtbContenido.RightMargin = 300;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string tituloArchivo = txtTitulo.Text;
            string importancia = cmbImportancia.SelectedItem.ToString();
            string texto = rtbContenido.Text;
            string typeFile = ".txt";
            string date = DateTime.Today.ToShortDateString();
            

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Selecciona la carpeta en donde quieres que se almacene esta nota";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaGuardado = folderBrowserDialog.SelectedPath + "\\";
                if (bd_method.AddPath(tituloArchivo, importancia, typeFile, rutaGuardado, date) == true)
                {
                    metodos.guardarTXT(tituloArchivo, importancia, texto, rutaGuardado, typeFile);
                }
                else
                {
                    MessageBox.Show("Error al crear archivo");
                }
                //Console.WriteLine(tituloArchivo);
                //Console.WriteLine(rutaGuardado);
                this.Dispose();
            }
        }
    }
}
