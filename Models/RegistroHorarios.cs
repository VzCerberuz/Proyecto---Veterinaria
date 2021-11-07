using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Veterinaria.Models
{
    [Table("tblRegistroHorarios")]

    public class RegistroHorarios
    {
        public int Id { get; set; }

        public int? tblEmpleadosId { get; set; }

        public int? tblDatosHorariosId { get; set; }
      

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Fecha2 { get; set; }

        [Display(Name = "Horas")]
        public int Horas { get; set; }

        public Empleados tblEmpleados { get; set; }
        public DatosHorarios tblDatosHorarios { get; set; }
    }
}