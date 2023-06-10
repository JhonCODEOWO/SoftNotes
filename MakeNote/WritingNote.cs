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
            string tituloArchivo = "\\"+txtTitulo.Text + cmbImportancia.SelectedItem + ".txt";
            string texto = rtbContenido.Text;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Selecciona la carpeta en donde quieres que se almacene esta nota";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaGuardado = folderBrowserDialog.SelectedPath;
                metodos.guardarTXT(tituloArchivo, texto, rutaGuardado);
                Console.WriteLine(tituloArchivo);
                Console.WriteLine(rutaGuardado);
                this.Dispose();
            }
        }
    }
}
