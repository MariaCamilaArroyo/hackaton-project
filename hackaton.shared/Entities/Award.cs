using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.shared.Entities
{
    public class Award
    {
        public int Id { get; set; }

        [Display(Name = "Premio a otorgar")]
        [Required]
        [MaxLength(100, ErrorMessage = "EL nombre debe ser menor a 100 caracteres")]
        public string Awards { get; set; }

        [Display(Name = "Puesto")]
        [Required]
        public string Position { get; set; }

        [JsonIgnore]
        public HackatonTable Hackatons { get; set; }
        public int HackatonId { get; set; }


    }
}
