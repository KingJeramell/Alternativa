using System.Data;
using System.Data.SqlClient;
using AgendaContactos.Clases;

namespace AgendaContactos.Datos
{
    public class ContactoDAO
    {
        // CADENA DE CONEXIÓN CORRECTA SEGÚN TU INSTANCIA
        private string conexion =
        "Data Source=DESKTOP-HD0VV4B\\SQLEXPRESS01;Initial Catalog=AgendaContactosDB;Integrated Security=True";

        // ================= INSERTAR =================
        public void Insertar(Contacto c)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarContacto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", c.Direccion);
                    cmd.Parameters.AddWithValue("@Instagram", c.Instagram);
                    cmd.Parameters.AddWithValue("@Facebook", c.Facebook);
                    cmd.Parameters.AddWithValue("@LinkedIn", c.LinkedIn);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ================= LISTAR =================
        public DataTable Listar()
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("sp_ListarContactos", cn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // ================= BUSCAR =================
        public DataTable Buscar(string texto)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_BuscarContacto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Texto", texto);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
