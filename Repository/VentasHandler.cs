using System.Data;
using System.Data.SqlClient;
using MyFirstAPI.Model;

namespace MyFirstAPI.Repository
{
    public class VentasHandler
    {
        // server name SQL
        public const string ConectStr = @"Server=ZAIRE-PC\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Ventas> GetVentas()
        {
            List<Ventas> ventalTotal = new List<Ventas>();

            using (SqlConnection sqlConV = new SqlConnection(ConectStr))
            {
                using (SqlCommand sqlCommV = new SqlCommand())
                {
                    sqlCommV.Connection = sqlConV;
                    sqlCommV.Connection.Open();
                    sqlCommV.CommandText = "SELECT * FROM Venta";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = sqlCommV;

                    DataTable Tabla = new DataTable();
                    sqlDataAdapter.Fill(Tabla);
                    sqlCommV.Connection.Close();

                    foreach (DataRow r in Tabla.Rows)
                    {
                        Ventas ven = new Ventas();
                        ven.Id = Convert.ToInt32(r["Id"]);
                        ven.Comment = r["Comentarios"].ToString();

                        ventalTotal.Add(ven);
                    }
                }
            }

            return ventalTotal;
        }
    }
}
