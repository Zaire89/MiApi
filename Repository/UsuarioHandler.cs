using System.Data;
using System.Data.SqlClient;
using MyFirstAPI.Model;

namespace MyFirstAPI.Repository
{
    public static class UsuarioHandler
    {
        
        public const string ConectStr = @"Server=ZAIRE-PC\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Usuario> GetUsuario()
        {
            List<Usuario> nuevos = new List<Usuario>();

            using (SqlConnection sqlConect = new SqlConnection(ConectStr))
            {
                using (SqlCommand sqlCom = new SqlCommand("SELECT * FROM Usuario", sqlConect))
                {
                    sqlConect.Open();

                    using (SqlDataReader dtRead = sqlCom.ExecuteReader())
                    {
                        if (dtRead.HasRows)
                        {
                            while (dtRead.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dtRead["Id"]);
                                usuario.Name = dtRead["Nombre"].ToString();
                                usuario.Lastname = dtRead["Apellido"].ToString();
                                usuario.Nickname = dtRead["NombreUsuario"].ToString();
                                usuario.Pass = dtRead["Contraseña"].ToString();
                                usuario.Email = dtRead["Mail"].ToString();

                                nuevos.Add(usuario); 
                            }
                        }
                    }

                    sqlConect.Close();

                }
            }

            return nuevos;
        }

        public static bool InicioSesion(string Nickname, string Pass)
        {
            //Usuario userInicio = new Usuario();
            bool retorno = false;

            using (SqlConnection sqlConect = new SqlConnection(ConectStr))
            {
                using (SqlCommand sqlCom = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @Nickname AND Contraseña = @Pass", sqlConect))
                {
                   
                    SqlParameter nicknameP = new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = Nickname };
                    SqlParameter passP = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = Pass };

                    sqlConect.Open();

                    using (SqlDataReader dtRead = sqlCom.ExecuteReader())
                    {
                        if (dtRead.HasRows)
                        {
                            retorno = true;
                        }
                        
                    }

                    sqlConect.Close();

                }
            }

            return retorno;
        }


        public static bool ModUser(Usuario user)
        {
            bool retorno = false;
            using (SqlConnection sqlConect = new SqlConnection(ConectStr))
            {
                string sqlComUp = "UPDATE SistemaGestion.dbo.Usuario SET Nombre = @nombre WHERE Id = @id ";

                SqlParameter nameP = new SqlParameter("nombre", SqlDbType.VarChar) { Value = user.Name };
                SqlParameter idP = new SqlParameter("id", SqlDbType.BigInt) { Value = user.Id };

                sqlConect.Open();

                using (SqlCommand sqlComm = new SqlCommand(sqlComUp, sqlConect))
                {
                    sqlComm.Parameters.Add(nameP);
                    sqlComm.Parameters.Add(idP);

                    int rows = sqlComm.ExecuteNonQuery(); 

                    if (rows > 0)
                    {
                        retorno = true;
                    }
                }

                sqlConect.Close();
            }

            return retorno;
        }


        public static bool NewUser(Usuario user)
        {
            bool res = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConectStr))
            {
                string insUser = "INSERT INTO SistemaGestion.dbo.Usuario " +
                    "(Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES " +
                    "(@nameP, @lastnameP, @nicknameP, @passP, @emailP);";

                SqlParameter nameP = new SqlParameter("nameP", SqlDbType.VarChar) { Value = user.Name };
                SqlParameter lastnameP = new SqlParameter("lastnameP", SqlDbType.VarChar) { Value = user.Lastname };
                SqlParameter nicknameP = new SqlParameter("nicknameP", SqlDbType.VarChar) { Value = user.Nickname };
                SqlParameter passP = new SqlParameter("passP", SqlDbType.VarChar) { Value = user.Pass };
                SqlParameter emailP = new SqlParameter("emailP", SqlDbType.VarChar) { Value = user.Email };

                sqlConnection.Open();

                using (SqlCommand sqlComm = new SqlCommand(insUser, sqlConnection))
                {
                    sqlComm.Parameters.Add(nameP);
                    sqlComm.Parameters.Add(lastnameP);
                    sqlComm.Parameters.Add(nicknameP);
                    sqlComm.Parameters.Add(passP);
                    sqlComm.Parameters.Add(emailP);

                    int r = sqlComm.ExecuteNonQuery();

                    if (r > 0)
                        res = true;

                }

                sqlConnection.Close();
            }

            return res;
        }
    }
}
