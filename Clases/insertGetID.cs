using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoDB.Clases
{
    class insertGetID
    {
        public int InsertID;
         public insertGetID(string inCedula, string inNombre, string inApellido) 
         {
             SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
             SqlCommand cmd = new SqlCommand("st_insert_cliente", conn);
             try 
             {
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add("@Cedula", inCedula);
                 cmd.Parameters.Add("@Nombre", inNombre);
                 cmd.Parameters.Add("@Apellido", inApellido);
                 var returnID = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);

                conn.Open();
                cmd.ExecuteNonQuery();
                InsertID = Convert.ToInt32(returnID.Value);
             }
             catch(Exception e)
             {
                 //
             }

         }

        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable D_listado_Clientes()
        {
            SqlCommand cmd = new SqlCommand("st_insert_cliente", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_Clientes(ClassEntidades obje)
        {
            SqlCommand cmd = new SqlCommand("st_get_cliente", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@documento", obje.ndocumento);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /*public string D_Mantenimiento_Clientes(ClassEntidades obje)
        {
           // string accion = "";
           // SqlCommand cmd = SqlCommand("")
        }*/
        
    }
}
