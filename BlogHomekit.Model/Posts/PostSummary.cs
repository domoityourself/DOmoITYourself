using System;


namespace BlogHomekit.Model.Posts
{
    public class PostSummary
    {
        public int Id { get; set; }
        public string UrlSlug { get; set; }
        public string Titulo { get; set; }
        public string Portada { get; set; }
        public string Subtitulo { get; set; }
        public DateTime FechaPost { get; set; }
        public string Autor { get; set; }
    }
}
