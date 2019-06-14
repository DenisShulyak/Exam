namespace ExamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        DateOfIssue = c.DateTime(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        CountryOriginId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.CountryOrigins", t => t.CountryOriginId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.CountryOriginId);
            
            CreateTable(
                "dbo.CountryOrigins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CountryOriginId", "dbo.CountryOrigins");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CountryOriginId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.CountryOrigins");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
