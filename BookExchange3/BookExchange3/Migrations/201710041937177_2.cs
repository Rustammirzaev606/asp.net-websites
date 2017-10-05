namespace BookExchange3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reserves", "book_ID", "dbo.Books");
            DropIndex("dbo.Reserves", new[] { "book_ID" });
            DropTable("dbo.Books");
            DropTable("dbo.Reserves");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reserves",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        book_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Genre = c.String(),
                        ISBN = c.Int(nullable: false),
                        Available = c.Boolean(),
                        Taken = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Reserves", "book_ID");
            AddForeignKey("dbo.Reserves", "book_ID", "dbo.Books", "ID");
        }
    }
}
