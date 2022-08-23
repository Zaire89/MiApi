using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Controllers.DTOS;
using MyFirstAPI.Model;
using MyFirstAPI.Repository;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]

        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }
    }

    [HttpPost] // crea - insert
    public bool CrearProd([FromBody] PostProd prod)
    {
        try
        {
            return ProductoHandler.CrearProd(new Producto
            {
                Description = prod.Description,
                Id = prod.Id,
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    [HttpPut] // modifica - update
    public bool ModifProd([FromBody] PutProd prod)
    {
        return ProductoHandler.ModifProd(new Producto
        {
            Description = prod.Description,
            Id = prod.Id,
            Price = prod.Price,
            Stock = prod.Stock,
            SelPrice = prod.SelPrice,
            IdUser = prod.IdUser,

        });
    }

    [HttpDelete]
    public bool SuprProd([FromBody] int id)
    {
        try
        {
            return ProductoHandler.SuprProd(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
