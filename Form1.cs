using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void Modificar_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void t_i_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var Pru1 = new Clases.insertGetID("00100000004", "Ramon", "Martinez");
            int intResult = Pru1.InsertID;
            MessageBox.Show(intResult.ToString());
        }
    }
}
