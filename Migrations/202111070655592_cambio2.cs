namespace Proyecto_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblRegistroHorarios", "tblEmpleadosId");
            DropColumn("dbo.tblRegistroHorarios", "tblDatosHorariosId");
            RenameColumn(table: "dbo.tblRegistroHorarios", name: "Empleado_Id", newName: "tblEmpleadosId");
            RenameColumn(table: "dbo.tblRegistroHorarios", name: "Horario_Id", newName: "tblDatosHorariosId");
            RenameIndex(table: "dbo.tblRegistroHorarios", name: "IX_Empleado_Id", newName: "IX_tblEmpleadosId");
            RenameIndex(table: "dbo.tblRegistroHorarios", name: "IX_Horario_Id", newName: "IX_tblDatosHorariosId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.tblRegistroHorarios", name: "IX_tblDatosHorariosId", newName: "IX_Horario_Id");
            RenameIndex(table: "dbo.tblRegistroHorarios", name: "IX_tblEmpleadosId", newName: "IX_Empleado_Id");
            RenameColumn(table: "dbo.tblRegistroHorarios", name: "tblDatosHorariosId", newName: "Horario_Id");
            RenameColumn(table: "dbo.tblRegistroHorarios", name: "tblEmpleadosId", newName: "Empleado_Id");
            AddColumn("dbo.tblRegistroHorarios", "tblDatosHorariosId", c => c.Int());
            AddColumn("dbo.tblRegistroHorarios", "tblEmpleadosId", c => c.Int());
        }
    }
}
