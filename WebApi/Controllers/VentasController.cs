using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntities;
using SistemaGestionBusiness;

namespace SistemaGestionUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly VentaBusiness _ventaBusiness;

        public VentaController(VentaBusiness ventaBusiness)
        {
            _ventaBusiness = ventaBusiness;
        }

        [HttpGet]
        public ActionResult<List<Venta>> GetVentas()
        {
            var ventas = _ventaBusiness.GetVentas();
            if (ventas == null || !ventas.Any())
            {
                return NotFound("No se encontraron ventas.");
            }
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public ActionResult<Venta> GetVenta(int id)
        {
            var venta = _ventaBusiness.GetOneVenta(id);
            if (venta == null)
            {
                return NotFound($"No se encontró una venta con el id {id}.");
            }
            return Ok(venta);
        }


        [HttpPost]
        public ActionResult InsertVenta([FromBody] Venta venta)
        {
            if (venta == null)
            {
                return BadRequest("Los datos de la venta no pueden estar vacíos.");
            }

            _ventaBusiness.InsertVenta(venta);
            return CreatedAtAction(nameof(GetVenta), new { id = venta.Id }, venta);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateVenta(int id, [FromBody] Venta venta)
        {
            if (venta == null || id != venta.Id)
            {
                return BadRequest("Los datos de la venta no son válidos.");
            }

            var existingVenta = _ventaBusiness.GetOneVenta(id);
            if (existingVenta == null)
            {
                return NotFound($"No se encontró una venta con el id {id}.");
            }

            _ventaBusiness.UpdateVenta(id, venta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVenta(int id)
        {
            var existingVenta = _ventaBusiness.GetOneVenta(id);
            if (existingVenta == null)
            {
                return NotFound($"No se encontró una venta con el id {id}.");
            }

            _ventaBusiness.DeleteVenta(id);
            return NoContent();
        }

    }
}
