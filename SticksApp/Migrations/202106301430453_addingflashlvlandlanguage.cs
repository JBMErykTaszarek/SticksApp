namespace SticksApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingflashlvlandlanguage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlashCards", "Level", c => c.Int(nullable: false));
            AddColumn("dbo.FlashCards", "Language", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlashCards", "Language");
            DropColumn("dbo.FlashCards", "Level");
        }
    }
}
