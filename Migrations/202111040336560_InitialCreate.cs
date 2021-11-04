namespace Proyecto_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblEmpleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Documento = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Correo = c.String(),
                        Area = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblDatosHorarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoHorario = c.String(),
                        CantidadHoras = c.Int(nullable: false),
                        CostoNormal = c.Int(nullable: false),
                        CostoExtra = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblRegistroHorarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre2 = c.String(),
                        HorarioDefi = c.String(),
                        Fecha2 = c.DateTime(nullable: false),
                        HorasExtras = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblRegistroHorarios");
            DropTable("dbo.tblDatosHorarios");
            DropTable("dbo.tblEmpleados");
        }
    }
}
