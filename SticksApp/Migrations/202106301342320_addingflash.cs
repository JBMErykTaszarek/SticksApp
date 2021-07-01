namespace SticksApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingflash : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlashCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlashCards");
        }
    }
}
