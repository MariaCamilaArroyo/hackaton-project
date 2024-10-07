using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.shared.Entities
{
    public class Team
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del equipo")]
        [Required]
        [MaxLength(200, ErrorMessage = "El nombre del equipo debe ser mas corto")]
        public string Name { get; set; }

        [JsonIgnore]
        public Mentor Mentors { get; set; }
        public int MentorId { get; set; }

        [JsonIgnore]
        public HackatonTable Hackatons { get; set; }
        public int HackatonId { get; set; }

    }
}