using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogHomekit.Model.Posts 
    {
    public static class PostExtensions
    {
        public static IQueryable<Post> Published(this IQueryable<Post> posts)
        {
            return posts.Where(m => !m.EsBorrador &&    m.FechaPublicacion <= DateTime.Now);
                
        }

        public static IQueryable<PostSummary> SelectPostSummaryLine(this IQueryable<Post> posts)
        {
            return posts.Select(m => new PostSummary
            {
                Id = m.Id,
                UrlSlug = m.UrlSlug,
                Titulo = m.Titulo,
                Portada = m.Portada,
                FechaPost = m.FechaPost,
                Autor = m.Autor,
                Subtitulo = m.Subtitulo
            });
        }

    }
}
