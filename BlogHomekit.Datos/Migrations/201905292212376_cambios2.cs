namespace BlogHomekit.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Portada", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Portada");
        }
    }
}
