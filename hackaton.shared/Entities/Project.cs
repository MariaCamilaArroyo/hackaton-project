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

        [Display(Name = "Nombre del proyecto")]
        [Required]
        public int Name  { get; set; }

        [Display(Name = "Descripcion del proyecto")]
        public string Description { get; set; }

        [Display(Name = "Fecha de entrega del proyecto")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => DeliveryDate.ToLocalTime();
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Puntuación del proyecto")]
        public string Score { get; set; }

        [JsonIgnore]
        public Status Statuses { get; set; }
        public int StatusId { get; set; }

        [JsonIgnore]
        public Team Teams { get; set; }
        public int TeamId { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
