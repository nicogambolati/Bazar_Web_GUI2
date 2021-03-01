namespace Bazar_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregamoselcontexto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ordens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.String(),
                        FechaPedido = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrdenItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Precio = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Orden_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ordens", t => t.Orden_Id)
                .Index(t => t.Orden_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdenItems", "Orden_Id", "dbo.Ordens");
            DropIndex("dbo.OrdenItems", new[] { "Orden_Id" });
            DropTable("dbo.OrdenItems");
            DropTable("dbo.Ordens");
        }
    }
}
