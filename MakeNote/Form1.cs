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
    public partial class Form1 : Form
    {
        BD_Methos bd_methods = new BD_Methos();
        Metodos metodos = new Metodos();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bd_methods.notesInBD();
            lblBienvenida.Text = metodos.saludar() + " ¿Que deseas hacer?";
            if (metodos.verificarFilas(dataGridView1) == false)
            {
                lblSinNotas.Visible = true;
            }
            else
            {
                lblSinNotas.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WritingNote writing = new WritingNote();
            writing.Show();
        }
    }
}
