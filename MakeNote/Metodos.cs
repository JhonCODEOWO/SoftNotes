using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeNote
{
    class Metodos
    {
        public string saludar()
        {
            string mañana = "Buenos Dias";
            string tarde = "Buenas Tardes";
            string noche = "Buenas Noches";

            int horaActual = DateTime.Now.Hour;
            if (horaActual <= 12)
            {
                return mañana;
            }
            if (horaActual > 12 && horaActual <= 19)
            {
                return tarde;
            }
            if (horaActual > 20 && horaActual <= 23)
            {
                return noche;
            }

            throw new InvalidOperationException("No se pudo determinar el saludo.");
        }

        public bool verificarFilas(DataGridView view)
        {
            if (view.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool guardarTXT(string titulo, string importancia, string contenido, string ruta , string tipo)
        {
            try
            {
                string fileCompletePath = ruta + titulo + importancia + tipo;
                File.WriteAllText(fileCompletePath, contenido);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
