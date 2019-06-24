using BlogHomekit.Model.Posts;
using System;
using System.Collections.Generic;

namespace BlogHomekit.Model.Dtos
{
    public class PostDto
    {
        public PostDto()
            {
            }
        public PostDto(Post post)
        {
            Id = post.Id;
            Titulo = post.Titulo;
            Subtitulo = post.Subtitulo;
            Portada = post.Portada;
            UrlSlug = post.UrlSlug;
            ContenidoHTML = post.ContenidoHTML;
            linkVideo = post.LinkVideo;
            EsBorrador = post.EsBorrador;
            FechaPost = post.FechaPost;
            FechaPublicacion = post.FechaPublicacion;
            Autor = post.Autor;
            Tags = post.Tags;
        }
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Subtitulo { get; set; }

        public string Portada { get; set; }

        public string UrlSlug { get; set; }

        public string ContenidoHTML { get; set; }

        public string linkVideo { get; set; }

        public bool EsBorrador { get; set; }

        public DateTime FechaPost { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string Autor { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public bool EsPublico => !EsBorrador && FechaPublicacion <= DateTime.Now;

    }
}
