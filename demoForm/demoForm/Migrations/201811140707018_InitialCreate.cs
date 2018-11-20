namespace demoForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ques",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ques = c.String(),
                        Op1 = c.String(),
                        Op2 = c.String(),
                        Op3 = c.String(),
                        Op4 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ques");
        }
    }
}
