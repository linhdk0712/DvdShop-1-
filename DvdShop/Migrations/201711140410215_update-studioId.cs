namespace DvdShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestudioId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Studio_Id", "dbo.Studios");
            DropIndex("dbo.Products", new[] { "Studio_Id" });
            RenameColumn(table: "dbo.Products", name: "Studio_Id", newName: "StudioId");
            AlterColumn("dbo.Products", "StudioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "StudioId");
            AddForeignKey("dbo.Products", "StudioId", "dbo.Studios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "StudioId", "dbo.Studios");
            DropIndex("dbo.Products", new[] { "StudioId" });
            AlterColumn("dbo.Products", "StudioId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "StudioId", newName: "Studio_Id");
            CreateIndex("dbo.Products", "Studio_Id");
            AddForeignKey("dbo.Products", "Studio_Id", "dbo.Studios", "Id");
        }
    }
}
