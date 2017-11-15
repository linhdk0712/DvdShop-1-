namespace DvdShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class installautomaper : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsFullBox", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "Comment", c => c.String(maxLength: 500));
            AddColumn("dbo.Studios", "MobiNumber", c => c.String(maxLength: 15));
            AddColumn("dbo.Studios", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.Studios", "Zalo", c => c.String(maxLength: 50));
            AddColumn("dbo.Studios", "Comment", c => c.String(maxLength: 500));
            AddColumn("dbo.Studios", "Owner", c => c.String(maxLength: 50));
            AlterColumn("dbo.Studios", "StudioCode", c => c.String(maxLength: 30));
            AlterColumn("dbo.Studios", "SkypeName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Studios", "Address", c => c.String(maxLength: 500));
            AlterColumn("dbo.Studios", "Name", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Studios", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Studios", "Address", c => c.String());
            AlterColumn("dbo.Studios", "SkypeName", c => c.String());
            AlterColumn("dbo.Studios", "StudioCode", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Studios", "Owner");
            DropColumn("dbo.Studios", "Comment");
            DropColumn("dbo.Studios", "Zalo");
            DropColumn("dbo.Studios", "Email");
            DropColumn("dbo.Studios", "MobiNumber");
            DropColumn("dbo.Products", "Comment");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "IsFullBox");
        }
    }
}
