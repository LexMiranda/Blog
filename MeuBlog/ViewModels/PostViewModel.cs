using MeuBlog.DAO;
using MeuBlog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuBlog.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

       
        public string Titulo { get; set; }
    
        public string Conteudo { get; set; }
                
        public DateTime? DataPublicacao { get; set; }
        public bool Publicado { get; set; }
        public string Tags { get; set; }

        public Post CriaPost(TagDAO dao) {

            Post post = new Post
            {

                Id = this.Id,
                Titulo = this.Titulo,
                Conteudo = this.Conteudo,
                DataPublicacao = this.DataPublicacao,
                Publicado = this.Publicado

            };
            foreach (String nomeTag in this.Tags.Split(' '))
            {
                Tag tag = dao.BuscaPorNome(nomeTag);
                if (tag == null) {
                    tag = new Tag();
                    tag.Nome = nomeTag;
                    dao.Adiciona(tag);
                }
                post.Tags.Add(tag);
            }
            return post;
        }
    }
}