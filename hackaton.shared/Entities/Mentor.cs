using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton.shared.Entities
{
    public class Mentor
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Mentor")]
        [Required]
        [MaxLength(200, ErrorMessage = "El nombre del mentor debe ser mas corto")]
        public string Name { get; set; }

        [Display(Name = "área de experiencia")]
        [Required]
        public string expertise { get; set; }

        [Display(Name = "Numero de documento")]
        [Required]
        public int identificationNumber { get; set; }
    }
}
