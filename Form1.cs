using ProyectoDB.ReportViewer;
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
        private static SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["connectionString"].ToString());
        private int intCli_ID = 0;
        private string strCodigoFact = "";
        private static string strBuscar = "";
        private static string strDestinoQuery = $"EXEC st_get_factura '{strBuscar}'";
        private static SqlCommand cmdFactura = new SqlCommand(strDestinoQuery, conn);
        private SqlDataAdapter daFactura = new SqlDataAdapter(cmdFactura);
        private DataTable dtFactura = new DataTable();
        private DataTable dtFacturaMod = new DataTable();

        public Form1()
        {
            InitializeComponent();
            enableDisableNombre(false);
            cargarComboDestino();
            cargardtFactura();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            deleteFactura();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            updateTicked();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void t_i_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            insertFactura();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir_Ticket();
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string strCedula = txtCedula.Text;
                consultarCedula(strCedula);

            }
        }

        private void dgFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        #region FuncionesLocales
        private void consultarCedula(string inCedula)
        {
            strCodigoFact = "";
            string strNombreCliente;
            string strApellidoCliente;
            SqlCommand cmd = new SqlCommand("EXEC st_get_cliente '" + inCedula + "'", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                enableDisableNombre(false);
                intCli_ID = Convert.ToInt32(dt.Rows[0][0]);
                strNombreCliente = dt.Rows[0][1].ToString();
                strApellidoCliente = dt.Rows[0][2].ToString();
                txtNombre.Text = strNombreCliente;
                txtApellido.Text = strApellidoCliente;
                cmbDestino.Focus();
            }
            catch (Exception e)
            {
                enableDisableNombre(true);
                txtNombre.Text = "";
                txtApellido.Text = "";
                intCli_ID = 0;
                txtNombre.Focus();
            }
            conn.Close();
        }
        private void cargarComboDestino()
        {
            DataTable dtDestino = new DataTable();
            string strDestinoQuery = "Select Tic_Id, Dest_Nombre from vw_tickets_disponibles";
            SqlCommand cmdDestino = new SqlCommand(strDestinoQuery, conn);
            SqlDataAdapter daDestino = new SqlDataAdapter(cmdDestino);
            daDestino.Fill(dtDestino);
            cmbDestino.DisplayMember = "Dest_Nombre";
            cmbDestino.ValueMember = "Tic_Id";
            cmbDestino.DataSource = dtDestino;
        }
        private void enableDisableNombre(bool boEDin)
        {
            txtNombre.Enabled = boEDin;
            txtApellido.Enabled = boEDin;
        }
        private bool checkEmpty()
        {
            bool boSeguirIn = false;
            if (txtCedula.Text != "")
            {
                if (txtNombre.Text == "")
                    txtNombre.Focus();
                else
                {
                    if (txtApellido.Text == "")
                        txtApellido.Focus();
                    else
                    {
                        if (intCli_ID == 0)
                        {
                            string inCedula = txtCedula.Text;
                            string inNombreCliente = txtNombre.Text;
                            string inApellidoCliente = txtApellido.Text;
                            var GetCliID = new Clases.insertGetID(inCedula, inNombreCliente, inApellidoCliente);
                            intCli_ID = GetCliID.intGetID;
                        }
                        boSeguirIn = true;
                    }
                }
            }
            else
            {
                txtCedula.Focus();
            }
            return boSeguirIn;
        }
        private void insertFactura()
        {
            bool boCheckDatos = checkEmpty();
            if (boCheckDatos)
            {
                int intTicID = Convert.ToInt32(cmbDestino.SelectedValue);
                string strCodFac = Guid.NewGuid().ToString();
                SqlCommand cmd = new SqlCommand("EXEC st_insert_factura '" + intCli_ID + "', '" + intTicID + "', '" + strCodFac + "'", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteScalar();
                    conn.Close();
                    cargarComboDestino();
                    inicomponent();
                    buscarFactura();
                }
                catch (Exception e)
                {
                    //
                }
            }
        }
        private void inicomponent()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            cmbDestino.SelectedIndex = 0;
            enableDisableNombre(false);
            txtCedula.Enabled = true;
            strCodigoFact = "";
            txtBuscar.Text = "";
            strBuscar = "";
        }
        private void cargardtFactura()
        {
            daFactura.Fill(dtFactura);
            BindingSource bsFactura = new BindingSource();
            bsFactura.DataSource = dtFactura;
            dgFactura.DataSource = bsFactura;
            dgFactura.Columns["Cli_nombre"].Visible = false;
            dgFactura.Columns["Cli_apellido"].Visible = false;
            dgFactura.Columns["Tic_ID"].Visible = false;
            //dgFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void selectedFactura() 
        {
            string strCedula = dgFactura.SelectedCells[0].Value.ToString();
            string strNombre = dgFactura.SelectedCells[6].Value.ToString();
            string strApellido = dgFactura.SelectedCells[7].Value.ToString();
            string strCodigoFactura = dgFactura.SelectedCells[5].Value.ToString();
            string strDestinoNombre = dgFactura.SelectedCells[2].Value.ToString();
            //
            txtNombre.Text = strNombre;
            txtApellido.Text = strApellido;
            txtCedula.Text = strCedula;
            cmbDestino.Text = strDestinoNombre;
            strCodigoFact = strCodigoFactura;
            //
            txtCedula.Enabled = false;
            enableDisableNombre(false);
        }
        private void updateTicked() 
        {
            if(strCodigoFact !="" ) 
            {
                int intTicID = Convert.ToInt32(cmbDestino.SelectedValue);
                SqlCommand cmd = new SqlCommand("EXEC st_update_factura '" + intTicID + "', '" + strCodigoFact + "'", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteScalar();
                    conn.Close();
                    cargarComboDestino();
                    inicomponent();
                    cargardtFactura();
                }
                catch (Exception e)
                {
                    //
                }
            }
        }
        private void deleteFactura() 
        {
            if (strCodigoFact != "")
            {
                int intTicID = Convert.ToInt32(cmbDestino.SelectedValue);
                SqlCommand cmd = new SqlCommand("EXEC st_delete_factura '" + strCodigoFact + "'", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteScalar();
                    conn.Close();
                    cargarComboDestino();
                    inicomponent();
                    cargardtFactura();
                }
                catch (Exception e)
                {
                    //
                }
            }
        }
        private void buscarFactura() 
        {
            BindingSource bsFactura = new BindingSource();
            dtFactura.Clear();
            strBuscar = txtBuscar.Text.Replace("\r\n", "");
            strDestinoQuery = $"EXEC st_get_factura '{strBuscar}'";
            cmdFactura = new SqlCommand(strDestinoQuery, conn);
            daFactura = new SqlDataAdapter(cmdFactura);
            daFactura.Fill(dtFactura);
            dgFactura.Refresh();
            txtBuscar.Text = "";
            strBuscar = "";
        }
        #endregion

        private void dgFactura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedFactura();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarFactura();
            }
        }

        private void Imprimir_Ticket()
        {
            FrmTicket rticket = new FrmTicket();
            rticket.Show();
            string q = "select * from vw_factura_info";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "vw_factura_info");
            CReportViajes crTicket = new CReportViajes();
            crTicket.SetDataSource(ds);
            rticket.CReportTicket.ReportSource = crTicket;
            conn.Close();
            rticket.CReportTicket.Refresh();
        }

        
    }
}
