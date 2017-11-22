namespace DvdShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addisfullboxtostudio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Studios", "IsFullBox", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Studios", "IsFullBox");
        }
    }
}
