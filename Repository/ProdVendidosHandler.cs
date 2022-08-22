using System.Data;
using System.Data.SqlClient;
using MyFirstAPI.Model;

namespace MyFirstAPI.Repository
{
    public class ProdVendidosHandler
    {
        // server name SQL
        public const string ConectStr = @"Server=ZAIRE-PC\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";

        public static List<ProductosVendidos> GetProdVendidos()
        {
            List<ProductosVendidos> prodVendidos = new List<ProductosVendidos>();

            using (SqlConnection sqlConPV = new SqlConnection(ConectStr))
            {
                using (SqlCommand sqlCommPV = new SqlCommand())
                {
                    sqlCommPV.Connection = sqlConPV;
                    sqlCommPV.Connection.Open();
                    sqlCommPV.CommandText = "SELECT * FROM ProductoVendido";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = sqlCommPV;

                    DataTable Tabla = new DataTable();
                    sqlDataAdapter.Fill(Tabla);
                    sqlCommPV.Connection.Close();

                    foreach (DataRow r in Tabla.Rows)
                    {
                        ProductosVendidos prodVen = new ProductosVendidos();
                        prodVen.Id = Convert.ToInt32(r["Id"]);
                        prodVen.Stock = Convert.ToInt32(r["Stock"]);
                        prodVen.IdProduct = Convert.ToInt32(r["IdProducto"]);
                        prodVen.IdStock = Convert.ToInt32(r["IdVenta"]);

                        prodVendidos.Add(prodVen);
                    }
                }
            }

            return prodVendidos;
        }
    }
}
