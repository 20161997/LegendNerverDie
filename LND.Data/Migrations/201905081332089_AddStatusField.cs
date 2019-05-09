namespace LND.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactDetails", "Status", c => c.Boolean(nullable: false));
            Sql(" update dbo.ContactDetails set Status = 1 ");
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactDetails", "Status");
        }
    }
}
