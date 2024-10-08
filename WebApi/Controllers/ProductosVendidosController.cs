using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntities;
using SistemaGestionBusiness;

namespace SistemaGestionUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        private readonly ProductoVendidoBusiness _productoVendidoBusiness;

        public ProductoVendidoController(ProductoVendidoBusiness productoVendidoBusiness)
        {
            _productoVendidoBusiness = productoVendidoBusiness;
        }

        [HttpGet]
        public ActionResult<List<ProductoVendido>> GetProductoVendidos()
        {
            var productosVendidos = _productoVendidoBusiness.GetProductoVendidos();
            if (productosVendidos == null || !productosVendidos.Any())
            {
                return NotFound("No se encontraron productos vendidos.");
            }
            return Ok(productosVendidos);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductoVendido> GetProductoVendido(int id)
        {
            var productoVendido = _productoVendidoBusiness.GetOneProductoVendido(id);
            if (productoVendido == null)
            {
                return NotFound($"No se encontró un producto vendido con el id {id}.");
            }
            return Ok(productoVendido);
        }

        [HttpPost]
        public ActionResult InsertProductoVendido([FromBody] ProductoVendido productoVendido)
        {
            if (productoVendido == null)
            {
                return BadRequest("Los datos del producto vendido no pueden estar vacíos.");
            }

            _productoVendidoBusiness.InsertProductoVendido(productoVendido);
            return CreatedAtAction(nameof(GetProductoVendido), new { id = productoVendido.Id }, productoVendido);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProductoVendido(int id, [FromBody] ProductoVendido productoVendido)
        {
            if (productoVendido == null || id != productoVendido.Id)
            {
                return BadRequest("Los datos del producto vendido no son válidos.");
            }

            var existingProductoVendido = _productoVendidoBusiness.GetOneProductoVendido(id);
            if (existingProductoVendido == null)
            {
                return NotFound($"No se encontró un producto vendido con el id {id}.");
            }

            _productoVendidoBusiness.UpdateProductoVendido(id, productoVendido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProductoVendido(int id)
        {
            var existingProductoVendido = _productoVendidoBusiness.GetOneProductoVendido(id);
            if (existingProductoVendido == null)
            {
                return NotFound($"No se encontró un producto vendido con el id {id}.");
            }

            _productoVendidoBusiness.DeleteProductoVendido(id);
            return NoContent();
        }

    }
}
