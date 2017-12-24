using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tarea3
{
    public partial class Form1 : Form
    {
        Arbol arbol = new Arbol();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arbol.Insertar(arbol.Raiz, new Nodo(textBox1.Text.ElementAt(0)));
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = arbol.PreOrden(arbol.Raiz);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = arbol.EnOrden(arbol.Raiz);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = arbol.PostOrden(arbol.Raiz);
        }

    }
}
