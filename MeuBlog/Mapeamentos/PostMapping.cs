
using FluentNHibernate.Mapping;
using MeuBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuBlog.Mapeamentos
{
    public class PostMapping : ClassMap<Post>
    {
        public PostMapping()
        {
            Id(post => post.Id).GeneratedBy.Identity();
            Map(post => post.Titulo);
            Map(post => post.Conteudo);
            Map(post => post.DataPublicacao);
            Map(post => post.Publicado);

            HasManyToMany(p => p.Tags)
                .Table("Post_Tags")
                .ParentKeyColumn("PostId")
                .ChildKeyColumn("TagId");
            References(p => p.Autor, "AutorId");


        }
    }
}