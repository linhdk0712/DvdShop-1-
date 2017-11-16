namespace DvdShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusermodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateInput = c.DateTime(nullable: false),
                        Amount = c.Byte(nullable: false),
                        Inventory = c.Int(nullable: false),
                        IngredientsId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientsId, cascadeDelete: true)
                .Index(t => t.IngredientsId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "IngredientsId", "dbo.Ingredients");
            DropIndex("dbo.Stocks", new[] { "IngredientsId" });
            DropTable("dbo.Users");
            DropTable("dbo.Stocks");
            DropTable("dbo.Ingredients");
        }
    }
}
