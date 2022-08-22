using System.Data;
using System.Data.SqlClient;
using MyFirstAPI.Model;

namespace MyFirstAPI.Repository
{
    public static class ProductoHandler
    {
        // server name SQL
        public const string ConectStr = @"Server=ZAIRE-PC\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Producto> GetProductos()
        {
            List<Producto> prod = new List<Producto>();

            using (SqlConnection sqlCon = new SqlConnection(ConectStr))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = sqlCon;
                    sqlComm.Connection.Open();
                    sqlComm.CommandText = "SELECT * FROM Producto";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = sqlComm;

                    DataTable Tabla = new DataTable();
                    sqlDataAdapter.Fill(Tabla);
                    sqlComm.Connection.Close();

                    foreach (DataRow row in Tabla.Rows)
                    {
                        Producto product = new Producto();
                        product.Id = Convert.ToInt32(row["Id"]);
                        product.Description = row["Descripciones"].ToString();
                        product.Price = Convert.ToInt32(row["Costo"]);
                        product.Stock = Convert.ToInt32(row["Stock"]);
                        product.IdUser = Convert.ToInt32(row["IdUsuario"]);
                        product.SelPrice = Convert.ToInt32(row["PrecioVenta"]);
                        

                        prod.Add(product);
                    }
                }
            }

            return prod;
        }

        // 08/08 quedè en 1h
    }
}
