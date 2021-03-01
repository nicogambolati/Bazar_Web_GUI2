namespace Bazar_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregamoscarrito : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.CarritoProductoes");
        }
    }
}
