namespace forumAspMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        level = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 255),
                        image = c.String(nullable: false, maxLength: 255),
                        description = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                        Category_id = c.Int(),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Category_id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.Category_id)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(nullable: false, maxLength: 255),
                        createdAt = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                        Post_id = c.Int(),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.Post_id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.Post_id)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_id", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Post_id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Category_id", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "User_id" });
            DropIndex("dbo.Comments", new[] { "Post_id" });
            DropIndex("dbo.Posts", new[] { "User_id" });
            DropIndex("dbo.Posts", new[] { "Category_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
