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


        public static bool CrearProd(Producto prod)
        {
            bool retorno = false;

            using (SqlConnection sqlCon = new SqlConnection(ConectStr))
            {
                string insProd = "INSERT INTO SistemaGestion.dbo.Producto " +
                    "(Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES " +
                    "(@descripcionP, @costoP, @precioVentaP, @stockP, @idUserP);";

                SqlParameter descripcionP = new SqlParameter("descripcionP", SqlDbType.VarChar) { Value = prod.Description };
                SqlParameter costoP = new SqlParameter("costoP", SqlDbType.Int) { Value = prod.Price };
                SqlParameter precioVentaP = new SqlParameter("precioVentaP", SqlDbType.Int) { Value = prod.SelPrice };
                SqlParameter stockP = new SqlParameter("stockP", SqlDbType.Int) { Value = prod.Stock };
                SqlParameter idUserP = new SqlParameter("idUserP", SqlDbType.Int) { Value = prod.Id };

                sqlCon.Open();

                using (SqlCommand sqlCommand = new SqlCommand(insProd, sqlCon))
                {
                    sqlCommand.Parameters.Add(descripcionP);
                    sqlCommand.Parameters.Add(costoP);
                    sqlCommand.Parameters.Add(precioVentaP);
                    sqlCommand.Parameters.Add(stockP);
                    sqlCommand.Parameters.Add(idUserP);

                    int rows = sqlCommand.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        retorno = true;
                    }
                }

                sqlCon.Close();
            }

            return retorno;
        }




        public static bool ModifProd(Producto prod)
        {
            bool retorno = false;

            using (SqlConnection sqlCon = new SqlConnection(ConectStr))
            {
                string sqlComUp = "UPDATE SistemaGestion.dbo.Producto " +
                    "(Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES " +
                    "(@descripcionP, @costoP, @precioVentaP, @stockP, @idUserP);"; ;

                SqlParameter descripcionP = new SqlParameter("descripcionP", SqlDbType.VarChar) { Value = prod.Description };
                SqlParameter costoP = new SqlParameter("costoP", SqlDbType.Int) { Value = prod.Price };
                SqlParameter precioVentaP = new SqlParameter("precioVentaP", SqlDbType.Int) { Value = prod.SelPrice };
                SqlParameter stockP = new SqlParameter("stockP", SqlDbType.Int) { Value = prod.Stock };
                SqlParameter idUserP = new SqlParameter("idUserP", SqlDbType.Int) { Value = prod.Id };
                sqlCon.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sqlComUp, sqlCon))
                {
                    sqlCommand.Parameters.Add(descripcionP);
                    sqlCommand.Parameters.Add(costoP);
                    sqlCommand.Parameters.Add(precioVentaP);
                    sqlCommand.Parameters.Add(stockP);
                    sqlCommand.Parameters.Add(idUserP);

                    int row = sqlCommand.ExecuteNonQuery(); 

                    if (row > 0)
                    {
                        retorno = true;
                    }
                }

                sqlCon.Close();
            }

            return retorno;
        }

        public static bool SuprProd(int id)
        {
            bool retorno = false;

            using (SqlConnection sqlCon = new SqlConnection(ConectStr))
            {
                string delProd = "DELETE FROM Producto WHERE Id = @id";

                SqlParameter sqlP = new SqlParameter("id", System.Data.SqlDbType.BigInt);
                sqlP.Value = id;

                sqlCon.Open();

                using (SqlCommand sqlCommand = new SqlCommand(delProd, sqlCon))
                {
                    sqlCommand.Parameters.Add(sqlP);

                    int rows = sqlCommand.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        retorno = true;
                    }
                }

                sqlCon.Close();
            }

            return retorno;
        }
    }
}
