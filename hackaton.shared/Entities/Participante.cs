using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.shared.Entities
{
    public class Participante
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL nombre debe ser menor a 50 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Experiencia")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL nombre debe ser menor a 50 caracteres")]
        public string expertise { get; set; }

        [JsonIgnore]
        public Rol Roles { get; set; }
        public int RolId { get; set; }

        [JsonIgnore]
        public Team Teams { get; set; }
        public int TeamId { get; set; }

    }
}
