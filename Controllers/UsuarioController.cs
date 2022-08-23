using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Controllers.DTOS;
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
            
        }

        [HttpGet("{Nickname}/{Pass}")]
        public bool InicioSesion(string Nickname, string Pass)
        {

            try
            {
                return UsuarioHandler.InicioSesion(Nickname, Pass);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }


        [HttpPut]
        public bool ModUser([FromBody] PutUser user) // fromBody >>> desde Postman "Body"
        {
            return UsuarioHandler.ModUser(new Usuario
            {
                Id = user.Id,
                Name = user.Name
            });
        }


        [HttpPost(Name = "PostUsuario")]
        public bool NewUser([FromBody] Usuario user)
        {
            try
            {
                return UsuarioHandler.NewUser(new Usuario
                {
                    Name = user.Name,
                    Lastname = user.Lastname,
                    Nickname = user.Nickname,
                    Pass = user.Pass,
                    Email = user.Email,

                }); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
