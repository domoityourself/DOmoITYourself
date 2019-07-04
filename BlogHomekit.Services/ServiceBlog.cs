using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogHomekit.Model.Posts;
using BlogHomekit.Datos;
using System.Data.Entity;



namespace BlogHomekit.Services
{
    public class ServiceBlog
    {
        private readonly ContextDB _db;

        public ServiceBlog(ContextDB db)
        {
            _db = db;
        }

        public IQueryable<Post> Posts()
        {
            return _db.Posts;
        }


        public async Task<List<PostSummary>> GetPostSummariesPublished(int PostsNumber)
        {
            return await Posts()
                .Published()
                .SelectPostSummaryLine()
                .OrderByDescending(m => m.FechaPost)
                .Take(PostsNumber)
                .ToListAsync();
        }
    }
}
