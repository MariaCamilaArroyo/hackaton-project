﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Hackaton.shared.Entities;


namespace Hackaton.shared.Entities
{
    public class Evaluation
    {
        public int Id { get; set; }

        [Display(Name = "Calificación del proyecto")]
        [Required]
        public int value { get; set; }

        [Display(Name = "Comentarios")]
        public string comments { get; set; }

        [JsonIgnore]
        public Mentor Mentor { get; set; } 
        public int MentorId { get; set; }

        [JsonIgnore]
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}

