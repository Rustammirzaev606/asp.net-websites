namespace Capstone1._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Books : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Genre = c.String(),
                        ISBN = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                        Taken = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reserves",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReserveBeginDate = c.DateTime(nullable: false),
                        ReserveEndDate = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        book_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.books", t => t.book_ID)
                .Index(t => t.book_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserves", "book_ID", "dbo.books");
            DropIndex("dbo.Reserves", new[] { "book_ID" });
            DropTable("dbo.Reserves");
            DropTable("dbo.books");
        }
    }
}
