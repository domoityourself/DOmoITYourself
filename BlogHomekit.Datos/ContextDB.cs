using System;
using System.Data.Entity;
using BlogHomekit.Model;
using BlogHomekit.Model.Posts;
using System.Threading.Tasks;


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
        public async Task SaveMyChanges()
        {
            try
            {
                await SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
