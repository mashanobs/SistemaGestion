using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class ProductoVendido
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Id del Producto es requerido.")]
        [Display(Name = "Id del Producto")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El campo Stock es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El Stock debe ser mayor o igual a 0.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El campo Id de la Venta es requerido.")]
        [Display(Name = "Id de la Venta")]
        public int IdVenta { get; set; }
    }
}
