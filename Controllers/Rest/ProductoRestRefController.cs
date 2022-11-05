using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using catstore.Models;
using catstore.Services;


namespace catstore.Controllers.Rest
{
    [ApiController]
    [Route("api/productoref")]
    public class ProductoRestRefController : ControllerBase
    {
        private readonly ProductoService _service;


        public ProductoRestRefController(ProductoService service){
             _service = service;
        }

  
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateProducto(Producto producto){
            try{
                var data = _service.crearProducto(producto);  
                return Ok(data);
            }catch(Exception ex){
               var res=new ObjectResult(ex.Message);
               res.StatusCode = 500;
               return res;
            }
        }

    }
}