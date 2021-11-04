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

        [Display(Name = "Nombre del Empleado")]
        public string Nombre2 { get; set; }

        [Display(Name = "Horario Definido")]
        public string HorarioDefi { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha2 { get; set; }

        [Display(Name = "Horas Extras Trabajadas")]
        public int HorasExtras { get; set; }
    }
}