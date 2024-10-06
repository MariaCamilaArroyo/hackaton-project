using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton.shared.Entities
{
    internal class Premio
    {
        public int Id { get; set; }

        [Display(Name = "Premio Obtenido")]
        [Required]
        [MaxLength(100, ErrorMessage = "EL nombre debe ser menor a 100 caracteres")]
        public string Premio_Obtenido { get; set; }

        [Display(Name = "Puesto Obtenido")]
        [Required]
        public string Puesto { get; set; }

        [Display(Name = "Id Hackaton")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL nombre debe ser menor a 50 caracteres")]
        public string IdHackaton { get; set; }

    }
}
