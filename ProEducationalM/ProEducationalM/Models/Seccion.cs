using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProEducationalM.Models
{
    public class Seccion
    {
        public short ID { get; set; }

        [Display(Name =@"Sección/Paralelo")]
        [Required(ErrorMessage = @"Por favor, ingrese la sección / paralelo")]
        [StringLength(50)]
        public string NombreSeccion { get; set; }
    }
}