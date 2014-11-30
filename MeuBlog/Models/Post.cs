using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuBlog.Models
{
    public class Post
    {
        
        public virtual int Id { get; set; }

        [StringLength(20)]
        [Required]
        public virtual string Titulo { get; set; }

        [Required]
        public virtual string Conteudo { get; set; }

        
        public virtual DateTime? DataPublicacao { get; set; }
       
        public virtual bool Publicado { get; set; }

        public virtual IList<Tag> Tags { get; set; }

        public Post()
        {
            this.Tags = new List<Tag>();

        }
    }
}