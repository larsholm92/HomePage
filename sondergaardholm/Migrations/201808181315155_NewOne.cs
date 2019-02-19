namespace sondergaardholm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewOne : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wishes", "Link", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wishes", "Link", c => c.String());
        }
    }
}
