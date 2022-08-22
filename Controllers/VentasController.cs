using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;
using MyFirstAPI.Repository;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public List<Ventas> GetVentas()
        {
            return VentasHandler.GetVentas();

        }

    }
}
