﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProEducationalM.Models
{
    public class Seccion
    {
        public short ID { get; set; }

        [Display(Name = @"Paralelo")]
        [Required(ErrorMessage = @"Por favor, ingrese el Paralelo")]
        [StringLength(50, ErrorMessage = @"La longitud máxima es 50 caracteres")]
        public string NombreSeccion { get; set; }
    }
}