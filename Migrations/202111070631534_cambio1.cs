namespace Proyecto_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblDatosHorarios", "tblEmpleadosId");
            RenameColumn(table: "dbo.tblDatosHorarios", name: "Empleado_Id", newName: "tblEmpleadosId");
            RenameIndex(table: "dbo.tblDatosHorarios", name: "IX_Empleado_Id", newName: "IX_tblEmpleadosId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.tblDatosHorarios", name: "IX_tblEmpleadosId", newName: "IX_Empleado_Id");
            RenameColumn(table: "dbo.tblDatosHorarios", name: "tblEmpleadosId", newName: "Empleado_Id");
            AddColumn("dbo.tblDatosHorarios", "tblEmpleadosId", c => c.Int());
        }
    }
}
