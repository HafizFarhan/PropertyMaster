namespace PropertyMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LandAcquisitions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        projectId = c.Int(nullable: false),
                        name = c.String(),
                        details = c.String(),
                        deleted = c.Boolean(nullable: false),
                        datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        details = c.String(),
                        deleted = c.Boolean(nullable: false),
                        datetime = c.DateTime(nullable: false),
                        updatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
            DropTable("dbo.LandAcquisitions");
        }
    }
}
