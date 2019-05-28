namespace BlogHomekit.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "linkVideo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "linkVideo");
        }
    }
}
