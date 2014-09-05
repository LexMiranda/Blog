﻿using System;
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
        public virtual string Titulo { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual DateTime? DataPublicacao { get; set; }
        public virtual bool Publicado { get; set; }
    }
}