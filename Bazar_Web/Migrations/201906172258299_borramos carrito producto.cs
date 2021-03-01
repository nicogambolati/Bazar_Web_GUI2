namespace Bazar_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borramoscarritoproducto : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CarritoProductoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarritoProductoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Precio = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
