using Proyecto_Veterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Veterinaria.ViewModels
{
    public class VmEmpleado
    {
        public VmEmpleado()
        {
            listaEmpleados = new List<Empleados>(); 
        }

        public List<Empleados> listaEmpleados { get; set; }
        
    }
}