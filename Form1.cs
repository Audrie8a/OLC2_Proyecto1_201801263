using CompiPascal.Analisis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiPascal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTraducir_Click(object sender, EventArgs e)
        {
            bool resultado = Sintactico.analizar(txtEntrada.Text);

            if (resultado)
            {
                txtSalida.Text = "La cadena es correcta";
            }
            else {
                txtSalida.Text = "La cadena es incorrecta";
            }
        }
    }
}
