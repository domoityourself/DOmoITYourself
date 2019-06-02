using System.Data.Entity;
using BlogHomekit.Model;
using BlogHomekit.Model.Posts;


namespace BlogHomekit.Datos
{
    public class ContextDB : DbContext
    {
       public ContextDB() 
            : base("DefaultConnection")
        {

        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
