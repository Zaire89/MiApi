using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Model;
using MyFirstAPI.Repository;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProdVendidosController : ControllerBase
    {
        [HttpGet(Name = "GetProdVendidos")]
        public List<ProductosVendidos> GetProdVendidos()
        {
            return ProdVendidosHandler.GetProdVendidos();

        }

    }
}
