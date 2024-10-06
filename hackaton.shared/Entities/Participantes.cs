using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton.shared.Entities
{
    internal class Participantes
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL nombre debe ser menor a 50 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Experiencia")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL nombre debe ser menor a 50 caracteres")]
        public string Experiencia { get; set; }

        [Display(Name = "Rol")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL Rol debe ser menor a 50 caracteres")]
        public string rol { get; set; }

        [Display(Name = "Id Equipoo")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL ID del equipo debe ser menor a 50 caracteres")]
        public string Id_Equipo { get; set; }
    }
}
