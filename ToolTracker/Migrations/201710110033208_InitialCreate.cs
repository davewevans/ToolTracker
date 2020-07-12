namespace ToolTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inmates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GDCNumber = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToolId = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Officers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ToolsIssued",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToolId = c.Int(nullable: false),
                        DateOut = c.DateTime(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                        TimeIn = c.DateTime(nullable: false),
                        ReceivedByInmateId = c.Int(nullable: false),
                        ReceivedByOfficerId = c.Int(nullable: false),
                        IssuedByOfficerId = c.Int(nullable: false),
                        ReturnedByInmateId = c.Int(nullable: false),
                        ToolReturned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShopInmates",
                c => new
                    {
                        Shop_Id = c.Int(nullable: false),
                        Inmate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Shop_Id, t.Inmate_Id })
                .ForeignKey("dbo.Shops", t => t.Shop_Id, cascadeDelete: true)
                .ForeignKey("dbo.Inmates", t => t.Inmate_Id, cascadeDelete: true)
                .Index(t => t.Shop_Id)
                .Index(t => t.Inmate_Id);
            
            CreateTable(
                "dbo.ToolShops",
                c => new
                    {
                        Tool_Id = c.Int(nullable: false),
                        Shop_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tool_Id, t.Shop_Id })
                .ForeignKey("dbo.Tools", t => t.Tool_Id, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.Shop_Id, cascadeDelete: true)
                .Index(t => t.Tool_Id)
                .Index(t => t.Shop_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToolShops", "Shop_Id", "dbo.Shops");
            DropForeignKey("dbo.ToolShops", "Tool_Id", "dbo.Tools");
            DropForeignKey("dbo.ShopInmates", "Inmate_Id", "dbo.Inmates");
            DropForeignKey("dbo.ShopInmates", "Shop_Id", "dbo.Shops");
            DropIndex("dbo.ToolShops", new[] { "Shop_Id" });
            DropIndex("dbo.ToolShops", new[] { "Tool_Id" });
            DropIndex("dbo.ShopInmates", new[] { "Inmate_Id" });
            DropIndex("dbo.ShopInmates", new[] { "Shop_Id" });
            DropTable("dbo.ToolShops");
            DropTable("dbo.ShopInmates");
            DropTable("dbo.ToolsIssued");
            DropTable("dbo.Officers");
            DropTable("dbo.Tools");
            DropTable("dbo.Shops");
            DropTable("dbo.Inmates");
        }
    }
}
