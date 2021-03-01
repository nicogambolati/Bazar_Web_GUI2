namespace Bazar_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregamoselNombredeusuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ordens", "UsuarioNombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ordens", "UsuarioNombre");
        }
    }
}
