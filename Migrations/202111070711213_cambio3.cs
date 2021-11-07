namespace Proyecto_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblRegistroHorarios", "Horas", c => c.Int(nullable: false));
            DropColumn("dbo.tblRegistroHorarios", "HorasExtras");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblRegistroHorarios", "HorasExtras", c => c.Int(nullable: false));
            DropColumn("dbo.tblRegistroHorarios", "Horas");
        }
    }
}
