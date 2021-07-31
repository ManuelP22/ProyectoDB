using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            var Pru1 = new Clases.insertGetID("00200000010", "Pablo", "Neruda");
            int intResult = Pru1.InsertID;
            MessageBox.Show(intResult.ToString());
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string strCedula = txtCedula.Text;
                consultarCedula(strCedula);

            }
        }
        #region FuncionesLocales
        private void consultarCedula(string Cedula)
        {
            string ConnectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
            SqlCommand cmd = new SqlCommand("EXEC st_insert_cliente '" + inCedula + "', '" + inNombre + "', '" + inApellido + "'", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ValueResult = Convert.ToInt32(dt.Rows[0][0]);
            conn.Close();
        }
        #endregion
    }
}
