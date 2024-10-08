using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly ProductoBusiness _productoBusiness;

        public ProductosController(ILogger<ProductosController> logger, ProductoBusiness productoBusiness)
        {
            _logger = logger;
            _productoBusiness = productoBusiness;
        }

        [HttpGet(Name = "Get Productos")]
        public ActionResult<List<Producto>> GetProductos([FromQuery(Name = "filtro")] string? filtro)
        {
            if (filtro == null)
            {
                return _productoBusiness.GetProductos();
            }
            return _productoBusiness.GetProductosBy(filtro);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            _logger.LogInformation("Consultando por el producto con id {id}", id);
            var producto = _productoBusiness.GetOneProducto(id);
            if (producto is null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public ActionResult<Producto> CrearProducto([FromBody] Producto producto)
        {
            var productoCreado = _productoBusiness.InsertProducto(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = productoCreado.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult ModificarProducto([FromRoute(Name = "id")] int id, [FromBody] Producto producto)
        {
            _productoBusiness.UpdateProducto(id, producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProducto([FromRoute(Name = "id")] int id)
        {
            _productoBusiness.DeleteProducto(id);
            return NoContent();
        }

        [HttpPut("fix-total")]
        public ActionResult FixTotalProductos()
        {
            _productoBusiness.UpdateTotalProductos();
            return NoContent();
        }


    }
}
