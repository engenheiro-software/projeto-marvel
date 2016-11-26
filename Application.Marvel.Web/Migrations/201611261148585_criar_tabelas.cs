namespace Application.Marvel.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criar_tabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        modified = c.String(),
                        resourceURI = c.String(),
                        comics_ID = c.Int(),
                        thumbnail_ID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Comics", t => t.comics_ID)
                .ForeignKey("dbo.Thumbnail", t => t.thumbnail_ID)
                .Index(t => t.comics_ID)
                .Index(t => t.thumbnail_ID);
            
            CreateTable(
                "dbo.Comics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        available = c.Int(nullable: false),
                        collectionURI = c.String(),
                        returned = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        resourceURI = c.String(),
                        name = c.String(),
                        type = c.String(),
                        Comics_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comics", t => t.Comics_ID)
                .Index(t => t.Comics_ID);
            
            CreateTable(
                "dbo.Thumbnail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        path = c.String(),
                        extension = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fasciculos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        issueNumber = c.Int(nullable: false),
                        description = c.String(),
                        thumbnail_ID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Thumbnail", t => t.thumbnail_ID)
                .Index(t => t.thumbnail_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fasciculos", "thumbnail_ID", "dbo.Thumbnail");
            DropForeignKey("dbo.Character", "thumbnail_ID", "dbo.Thumbnail");
            DropForeignKey("dbo.Character", "comics_ID", "dbo.Comics");
            DropForeignKey("dbo.Items", "Comics_ID", "dbo.Comics");
            DropIndex("dbo.Fasciculos", new[] { "thumbnail_ID" });
            DropIndex("dbo.Items", new[] { "Comics_ID" });
            DropIndex("dbo.Character", new[] { "thumbnail_ID" });
            DropIndex("dbo.Character", new[] { "comics_ID" });
            DropTable("dbo.Fasciculos");
            DropTable("dbo.Thumbnail");
            DropTable("dbo.Items");
            DropTable("dbo.Comics");
            DropTable("dbo.Character");
        }
    }
}
