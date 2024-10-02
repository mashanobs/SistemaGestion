using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500, ErrorMessage = "Los Comentarios no pueden tener más de 500 caracteres.")]
        [Display(Name = "Comentarios")]
        public string Comentarios { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Id del Usuario es requerido.")]
        [Display(Name = "Id del Usuario")]
        public int IdUsuario { get; set; }
    }
}
