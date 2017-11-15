namespace DvdShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimagetostudio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Studios", "Image", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Studios", "Image");
        }
    }
}
