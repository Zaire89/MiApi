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

        public static List<Usuario> InicioSesion(string Nickname, string Pass)
        {
            List<Usuario> userInicio = new List<Usuario>();

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
                            while (dtRead.Read())
                            {
                                Usuario user = new Usuario();
                                user.Nickname = dtRead["NombreUsuario"].ToString();
                                user.Pass = dtRead["Contraseña"].ToString();

                                userInicio.Add(user);
                            }
                        }
                    }

                    sqlConect.Close();

                }
            }

            return userInicio;
        }

        //public static bool NewUser(Usuario user)
        //{
        //    bool res = false;
        //    using (SqlConnection sqlConnection = new SqlConnection(ConectStr))
        //    {
        //        string insUser = "INSERT INTO SistemaGestion.dbo.Usuario " +
        //            "(Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES " +
        //            "(@nameP, @lastnameP, @nicknameP, @passP, @emailP);";

        //        SqlParameter nameP = new SqlParameter("nameP", SqlDbType.VarChar) { Value = user.Name };
        //        SqlParameter lastnameP = new SqlParameter("lastnameP", SqlDbType.VarChar) { Value = user.Lastname };
        //        SqlParameter nicknameP = new SqlParameter("nicknameP", SqlDbType.VarChar) { Value = user.Nickname };
        //        SqlParameter passP = new SqlParameter("passP", SqlDbType.VarChar) { Value = user.Pass };
        //        SqlParameter emailP  = new SqlParameter("emailP", SqlDbType.VarChar) { Value = user.Email };

        //        sqlConnection.Open();

        //        using (SqlCommand sqlComm = new SqlCommand(insUser, sqlConnection))
        //        {
        //            sqlComm.Parameters.Add(nameP);
        //            sqlComm.Parameters.Add(lastnameP);
        //            sqlComm.Parameters.Add(nicknameP);
        //            sqlComm.Parameters.Add(passP);
        //            sqlComm.Parameters.Add(emailP);

        //            int r = sqlComm.ExecuteNonQuery(); 

        //            if (r > 0)
        //                res = true;

        //        }

        //        sqlConnection.Close();
        //    }

        //    return res;
        //}
    }
}
