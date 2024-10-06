using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackaton.shared.Entities
{
    public class Hackaton
    {

        public int Id { get; set; }

        [Display(Name = "Nombre Hackaton")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Fecha de inicio")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime InitialDateLocal => InitialDate.ToLocalTime();
        public DateTime InitialDate { get; set; }
        [Display(Name = "Fecha de Fin")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FinalDateLocal => FinalDate.ToLocalTime();
        public DateTime FinalDate { get; set; }

        [Display(Name = "Tema del Hackaton")]
        [Required]
        [MaxLength(100, ErrorMessage = "El Tema debe ser menor a 100 Caracteres")]
        public string Topic { get; set; }

        [Display(Name = "Organizador")]
        [Required]
        public string Organizer { get; set; }

    }
}