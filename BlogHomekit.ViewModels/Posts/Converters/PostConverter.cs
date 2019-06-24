using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHomekit.Model.Dtos;


namespace BlogHomekit.ViewModels.Posts.Converters
{
    public static class PostConverter
    {
        public static void UpdatePost(this Model.Posts.Post post, PostDto postDto)
        {
            post.Titulo = postDto.Titulo;
            post.Subtitulo = postDto.Subtitulo;
            post.Portada = postDto.Portada;
            post.LinkVideo = postDto.linkVideo;
            post.UrlSlug = postDto.UrlSlug;
            post.Autor = postDto.Autor;
            post.ContenidoHTML = postDto.ContenidoHTML;
            post.EsBorrador = postDto.EsBorrador;
            post.FechaPost = postDto.FechaPost;
            post.FechaPublicacion = postDto.FechaPublicacion;
            post.FechaModificacion = DateTime.Now;
        }
    }
}
