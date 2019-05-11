namespace LND.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Address = c.String(maxLength: 250),
                        Email = c.String(maxLength: 50),
                        Website = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            Sql("update dbo.ContactDetails set Email=legendneverdie@gmail.com");
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactDetails");
        }
    }
}
