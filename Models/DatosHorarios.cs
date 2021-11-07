using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Veterinaria.Models
{
    [Table("tblDatosHorarios")]

    public class DatosHorarios
    {
        public int Id { get; set; }

        public int? tblEmpleadosId  { get; set; }

        [Display(Name = "Tipo de Horario")]
        public string TipoHorario { get; set; }

        [Display(Name = "Cantidad de Horas")]
        public int CantidadHoras { get; set; }

        [Display(Name = "Costo Hora Normal")]
        public double CostoNormal { get; set; }

        [Display(Name = "Costo Hora Extra")]
        public double CostoExtra { get; set; }

        public Empleados Empleado { get; set; }
    }
}