using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;

namespace MakeNote
{
    class BD_Methos
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source = Notas.db");

        public bool AddPath(string title, string importance, string typefile, string filepath, string date)
        {
            try
            {
                string fullFilePath = filepath + title + importance + typefile;
                string comando = "INSERT INTO UrlNotes VALUES (null, @filepath, @title, @dateofcreate)";
                SQLiteCommand sQLiteCommand = new SQLiteCommand(comando, connection);
                sQLiteCommand.Parameters.AddWithValue("@filepath", fullFilePath);
                sQLiteCommand.Parameters.AddWithValue("@title", title);
                sQLiteCommand.Parameters.AddWithValue("@dateofcreate", date);
                connection.Open();
                sQLiteCommand.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("Se ha guardado {0}", fullFilePath);
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable notesInBD()
        {
            try
            {
                string comando = "SELECT Título, FechaCreación From UrlNotes";
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(comando, connection);
                DataTable dataTable = new DataTable();
                sQLiteDataAdapter.Fill(dataTable);
                sQLiteDataAdapter = null;
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
