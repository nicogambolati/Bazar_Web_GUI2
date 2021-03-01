namespace Bazar_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregamosprecioystock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Precio", c => c.Double(nullable: false));
            AddColumn("dbo.Productoes", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "Stock");
            DropColumn("dbo.Productoes", "Precio");
        }
    }
}
