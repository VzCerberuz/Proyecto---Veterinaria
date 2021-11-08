using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Veterinaria.Models
{
    [Table("tblEmpleados")]

    public class Empleados
    {
        public int Id { get; set; }

        
        [Display(Name = "Nombre Empleado")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el Documento del empleado")]
        [Display(Name = "Documento del Empleado")]
        public int Documento { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        public System.DateTime Fecha { get; set; }

        
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }

        [Display(Name = "Area de Trabajo")]
        public string Area { get; set; }
    }
}