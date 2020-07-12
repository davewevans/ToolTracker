namespace ToolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToolTrackerDbContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopInmates", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.ShopInmates", "Inmate_Id", "dbo.Inmates");
            DropIndex("dbo.ShopInmates", new[] { "Shop_Id" });
            DropIndex("dbo.ShopInmates", new[] { "Inmate_Id" });
            AddColumn("dbo.Inmates", "AssignedShop_Id", c => c.Int());
            CreateIndex("dbo.Inmates", "AssignedShop_Id");
            AddForeignKey("dbo.Inmates", "AssignedShop_Id", "dbo.Shops", "Id");
            DropTable("dbo.ShopInmates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShopInmates",
                c => new
                    {
                        Shop_Id = c.Int(nullable: false),
                        Inmate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Shop_Id, t.Inmate_Id });
            
            DropForeignKey("dbo.Inmates", "AssignedShop_Id", "dbo.Shops");
            DropIndex("dbo.Inmates", new[] { "AssignedShop_Id" });
            DropColumn("dbo.Inmates", "AssignedShop_Id");
            CreateIndex("dbo.ShopInmates", "Inmate_Id");
            CreateIndex("dbo.ShopInmates", "Shop_Id");
            AddForeignKey("dbo.ShopInmates", "Inmate_Id", "dbo.Inmates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ShopInmates", "Shop_Id", "dbo.Shops", "Id", cascadeDelete: true);
        }
    }
}
