﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton.shared.Entities
{
    internal class Estado
    {
        public int Id { get; set; }
        [Display(Name = "Estado")]
        [Required]
        [MaxLength(50, ErrorMessage = "EL Estado debe ser menor a 50 caracteres")]
        public string estado { get; set; }

    }
}
