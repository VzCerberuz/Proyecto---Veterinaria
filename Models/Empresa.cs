using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Proyecto_Veterinaria.Models
{

    public class Empresas
    {
        public int Id { get; set; }
    }

    public class EmpresaDBContext : DbContext
    {
        public DbSet<DatosHorarios> Horarios { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<RegistroHorarios> Registro { get; set; }

    }
}