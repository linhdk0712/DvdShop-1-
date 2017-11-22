namespace DvdShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixshowproductindex : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Comment", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
    }
}
