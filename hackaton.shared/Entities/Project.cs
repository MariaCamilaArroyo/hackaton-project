using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.shared.Entities
{
    public class Project
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Proyecto")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Fecha de entrega")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Puntuación")]
        public string Score { get; set; }

        [Display(Name = "Estado")]
        public int StatusId { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }
    }
}

