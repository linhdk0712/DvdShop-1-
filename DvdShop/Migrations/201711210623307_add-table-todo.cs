namespace DvdShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtabletodo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "User_Id", "dbo.Users");
            DropIndex("dbo.ToDoes", new[] { "User_Id" });
            DropTable("dbo.ToDoes");
        }
    }
}
