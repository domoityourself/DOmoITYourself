using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using BlogHomekit.Model.Dtos;

namespace BlogHomekit.Model.Posts
{
    public class Post
    {
        public static Post CreateNewPost()
        {
            return new Post
            {
                FechaPost = DateTime.Now,
                FechaPublicacion = DateTime.Now.AddMonths(1)
            };
        }
        public Post()
        {
            Tags = new List<Tag>();

        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        //[AllowHtml]
        public string Subtitulo { get; set; }

        //[AllowHtml]
        public string Portada { get; set; }

        public string UrlSlug { get; set; }

        //[AllowHtml]
        public string ContenidoHTML { get; set; }

        //[AllowHtml]
        //[Display(Name = "Link Video")]
        public string LinkVideo { get; set; }

        public bool EsBorrador { get; set; }

        public DateTime FechaPost { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string Autor { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public bool EsPublico => !EsBorrador && FechaPublicacion <= DateTime.Now;




        public void CopyValues(PostDto postDto)
        {
            CopyTitulo(postDto.Titulo);
            CopySubtitulo(postDto.Subtitulo);
            CopyUrlSlug(postDto.UrlSlug);
            CopyPortada(postDto.Portada);
            CopyContenidoHTML(postDto.ContenidoHTML);
            CopyLinkVideo(postDto.linkVideo);
            CopyEsBorrador(postDto.EsBorrador);
            CopyFechaPost(postDto.FechaPost);
            CopyFechaPublicacion(postDto.FechaPublicacion);
            CopyFechaModificacion(DateTime.Now);
            CopyAutor(postDto.Autor);
            CopyTags(postDto.Tags);
        }
        public void CopyTitulo(string titulo)
        {
            Titulo = titulo;
        }
        public void CopySubtitulo(string subtitulo)
        {
            Subtitulo = subtitulo;
        }
        public void CopyPortada(string portada)
        {
            Portada = portada;
        }
        public void CopyContenidoHTML(string contenidoHTML)
        {
            ContenidoHTML = contenidoHTML;
        }
        public void CopyLinkVideo(string linkVideo)
        {
            LinkVideo = linkVideo;
        }
        public void CopyUrlSlug(string urlSlug)
        {
            UrlSlug = urlSlug;
        }
        public void CopyEsBorrador(bool esBorrador)
        {
            EsBorrador = esBorrador;
        }
        public void CopyFechaPost(DateTime fechaPost)
        {
            FechaPost = fechaPost;
        }
        public void CopyFechaPublicacion(DateTime fechaPublicacion)
        {
            FechaPublicacion = fechaPublicacion;
        }
        public void CopyFechaModificacion(DateTime fechaModificacion)
        {
            FechaModificacion = fechaModificacion;
        }
        public void CopyAutor(string autor)
        {
            Autor = autor;
        }
        public void CopyTags( ICollection<Tag> tags)
         {
            Tags = tags;
         }
    }
}
