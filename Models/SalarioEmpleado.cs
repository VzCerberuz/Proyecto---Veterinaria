using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Veterinaria.Models
{
    public class SalarioEmpleado
    {
        public int IdEmpleado { get; set; }
        public int IdHorario { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public decimal Salario { get; set; }
    }
}