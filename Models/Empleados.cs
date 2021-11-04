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

        [Display(Name = "Documento del Empleado")]
        public int Documento { get; set; }

        [Display(Name = "Fecha de Nacimiento")]

        public DateTime Fecha { get; set; }

        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }

        [Display(Name = "Area de Trabajo")]
        public string Area { get; set; }
    }
}