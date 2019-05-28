using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogHomekit.Model
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

        [AllowHtml]
        public string Subtitulo { get; set; }
        
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
