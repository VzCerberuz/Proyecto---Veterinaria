namespace Proyecto_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatosHorarios1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblDatosHorarios", "tblEmpleadosId", c => c.Int());
            AddColumn("dbo.tblDatosHorarios", "Empleado_Id", c => c.Int());
            CreateIndex("dbo.tblDatosHorarios", "Empleado_Id");
            AddForeignKey("dbo.tblDatosHorarios", "Empleado_Id", "dbo.tblEmpleados", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblDatosHorarios", "Empleado_Id", "dbo.tblEmpleados");
            DropIndex("dbo.tblDatosHorarios", new[] { "Empleado_Id" });
            DropColumn("dbo.tblDatosHorarios", "Empleado_Id");
            DropColumn("dbo.tblDatosHorarios", "tblEmpleadosId");
        }
    }
}
