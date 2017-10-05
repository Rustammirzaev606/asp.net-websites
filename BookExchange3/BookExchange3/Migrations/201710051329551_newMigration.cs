namespace BookExchange3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        Genre = c.String(),
                        ISBN = c.Double(nullable: false),
                        Available = c.Boolean(),
                        Taken = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reserves",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ReserveBeginDate = c.DateTime(nullable: false),
                        ReserveEndDate = c.DateTime(nullable: false),
                        book_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.book_ID)
                .Index(t => t.book_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserves", "book_ID", "dbo.Books");
            DropIndex("dbo.Reserves", new[] { "book_ID" });
            DropTable("dbo.Reserves");
            DropTable("dbo.Books");
        }
    }
}
