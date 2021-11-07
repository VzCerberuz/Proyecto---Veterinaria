namespace Proyecto_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistroHorarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblRegistroHorarios", "tblEmpleadosId", c => c.Int());
            AddColumn("dbo.tblRegistroHorarios", "tblDatosHorariosId", c => c.Int());
            AddColumn("dbo.tblRegistroHorarios", "Empleado_Id", c => c.Int());
            AddColumn("dbo.tblRegistroHorarios", "Horario_Id", c => c.Int());
            CreateIndex("dbo.tblRegistroHorarios", "Empleado_Id");
            CreateIndex("dbo.tblRegistroHorarios", "Horario_Id");
            AddForeignKey("dbo.tblRegistroHorarios", "Empleado_Id", "dbo.tblEmpleados", "Id");
            AddForeignKey("dbo.tblRegistroHorarios", "Horario_Id", "dbo.tblDatosHorarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblRegistroHorarios", "Horario_Id", "dbo.tblDatosHorarios");
            DropForeignKey("dbo.tblRegistroHorarios", "Empleado_Id", "dbo.tblEmpleados");
            DropIndex("dbo.tblRegistroHorarios", new[] { "Horario_Id" });
            DropIndex("dbo.tblRegistroHorarios", new[] { "Empleado_Id" });
            DropColumn("dbo.tblRegistroHorarios", "Horario_Id");
            DropColumn("dbo.tblRegistroHorarios", "Empleado_Id");
            DropColumn("dbo.tblRegistroHorarios", "tblDatosHorariosId");
            DropColumn("dbo.tblRegistroHorarios", "tblEmpleadosId");
        }
    }
}
