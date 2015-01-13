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
        public int? AutorId { get; set; }
        
        public PostViewModel() { }

        public PostViewModel(Post post)
        {
            this.Id = post.Id;
            this.Titulo = post.Titulo;
            this.Conteudo = post.Conteudo;
            this.DataPublicacao = post.DataPublicacao;
            this.Publicado = post.Publicado;
            this.Tags = String.Join(" ", post.Tags.Select(p =>p.Nome));
            if (post.Autor != null)
            {
                this.AutorId = post.Autor.Id;
            }
        }

        public Post CriaPost(TagDAO dao, UsuarioDAO usuarioDao) {

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

            post.Autor = usuarioDao.BuscaPorId(this.AutorId);
            return post;
        }
    }
}