namespace DvdShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removetodotable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoes", "User_Id", "dbo.Users");
            DropIndex("dbo.ToDoes", new[] { "User_Id" });
            DropTable("dbo.ToDoes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ToDoes", "User_Id");
            AddForeignKey("dbo.ToDoes", "User_Id", "dbo.Users", "Id");
        }
    }
}
