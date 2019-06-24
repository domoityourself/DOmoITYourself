using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using BlogHomekit.Model;
using Omu.ValueInjecter;

namespace BlogHomekit.ViewModels.Posts
{
   public class EditPost
    {
        public EditPost()
        {
        }
        public EditPost(Model.Posts.Post post): this()
        {
            this.InjectFrom(post);
        }
        public int Id { get; set; }

        public string Titulo { get; set; }

        [AllowHtml]
        public string Subtitulo { get; set; }

        [AllowHtml]
        public string Portada { get; set; }

        public string UrlSlug { get; set; }

        [AllowHtml]
        public string ContenidoHTML { get; set; }

        [AllowHtml]
        [Display(Name = "Link Video")]
        public string linkVideo { get; set; }

        public bool EsBorrador { get; set; }

        [Display(Name = "Fecha Post")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime FechaPost { get; set; }

        [Display(Name = "Fecha Publicación")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime FechaPublicacion { get; set; }

        public string Autor { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public bool EsPublico => !EsBorrador && FechaPublicacion <= DateTime.Now;
    }
}
