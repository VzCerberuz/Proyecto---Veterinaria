namespace Proyecto_Veterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistroHorarios1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblRegistroHorarios", "Nombre2");
            DropColumn("dbo.tblRegistroHorarios", "HorarioDefi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblRegistroHorarios", "HorarioDefi", c => c.String());
            AddColumn("dbo.tblRegistroHorarios", "Nombre2", c => c.String());
        }
    }
}
