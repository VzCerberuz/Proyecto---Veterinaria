namespace Proyecto_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatosHorarios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblDatosHorarios", "CostoNormal", c => c.Double(nullable: false));
            AlterColumn("dbo.tblDatosHorarios", "CostoExtra", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblDatosHorarios", "CostoExtra", c => c.Int(nullable: false));
            AlterColumn("dbo.tblDatosHorarios", "CostoNormal", c => c.Int(nullable: false));
        }
    }
}
