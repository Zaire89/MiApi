using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;
using MyFirstAPI.Repository;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuario")]
        public List<Usuario> GetUsuario()
        {
            return UsuarioHandler.GetUsuario();
            //return new List<Usuario>();
        }

        [HttpGet("{Nickname}/{Pass}")]
        public Usuario InicioSesion(string Nickname, string Pass)
        {
            return UsuarioHandler.InicioSesion(Nickname, Pass);
        }


        //[HttpPost(Name = "PostUsuario")]
        //public bool NewUser([FromBody] Usuario user)
        //{
        //    try
        //    {
        //        return UsuarioHandler.NewUser(new Usuario
        //        {
        //            Name = user.Name,
        //            Lastname = user.Lastname,
        //            Nickname = user.Nickname,
        //            Pass = user.Pass,
        //            Email = user.Email,

        //        }); ;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //}

    }
}
