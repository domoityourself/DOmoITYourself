using System;
using BlogHomekit.Model.Posts;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using BlogHomekit.Model.Dtos;


namespace BlogHomekit.ViewModels.Posts
{
    public class EditPostViewModel
    {
        public EditPostViewModel()
        { }
        public EditPost EditPost { get; set; }
        public EditPostViewModel(Post post)
        {
            Id = post.Id;
            Titulo = post.Titulo;
            Subtitulo = post.Subtitulo;
            Portada = post.Portada;
            UrlSlug = post.UrlSlug;
            LinkVideo = post.LinkVideo;
            ContenidoHTML = post.ContenidoHTML;
            FechaPost = post.FechaPost;
            FechaPublicacion = post.FechaPublicacion;
            Autor = post.Autor;
            EsBorrador = post.EsBorrador;

        }
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Escribe un Titulo")]
        public string Titulo { get; set; }

        [AllowHtml]
        [Display(Name = "Subtitulo")]
        [Required(ErrorMessage = "Es necesario un subtitulo")]
        public string Subtitulo { get; set; }

        [Display(Name = "UrlSlug")]
        [Required(ErrorMessage = "Es necesario UrlSlug")]
        public string UrlSlug { get; set; }

        [Display(Name = "LinkVideo")]
        [Required(ErrorMessage = "Es necesario linkVideo")]
        public string LinkVideo { get; set; }

        [Display(Name = "FechaPost")]
        [Required(ErrorMessage = "Es necesaria fecha post")]
        public DateTime FechaPost { get; set; }

        [Display(Name = "FechaPublicacion")]
        [Required(ErrorMessage = "Es necesaria fecha publicacion")]
        public DateTime FechaPublicacion { get; set; }

        [AllowHtml]
        [Display(Name = "ContenidoHTML")]
        [Required(ErrorMessage = "Es Necesario Contenido HTML")]
        public string ContenidoHTML { get; set; }

        [AllowHtml]
        [Display(Name = "Portada")]
        [Required(ErrorMessage = "Es Necesaria Portada")]
        public string Portada { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Es Necesario Autor")]
        public string Autor { get; set; }

        [Display(Name = "EsBorrador")]
        public bool EsBorrador { get; set; }

    }
    public static class EditPostViewModelExtensions
    {
        public static PostDto ToDto(this EditPostViewModel editor)
        {
            return new PostDto
            {
                Id = editor.Id,
                Titulo = editor.Titulo,
                Subtitulo = editor.Subtitulo,
                Portada = editor.Portada,
                UrlSlug = editor.UrlSlug,
                ContenidoHTML = editor.ContenidoHTML,
                linkVideo = editor.LinkVideo,
                EsBorrador = editor.EsBorrador,
                FechaPost = editor.FechaPost,
                FechaPublicacion = editor.FechaPublicacion,
                Autor = editor.Autor               

            };
        }
    }
}