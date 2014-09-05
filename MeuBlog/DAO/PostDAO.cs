using MeuBlog.Infra;
using MeuBlog.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuBlog.DAO
{
    public class PostDAO
    {
        [HttpPost]
        public void Adiciona(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                ITransaction tx = session.BeginTransaction();
                session.Save(post);
                tx.Commit();


            }

        }

        
        public Post BuscaPorId(int id) { 
            
            using(ISession session = NHibernateHelper.AbreSession()){

                return session.Get<Post>(id);
            }
        }

        public void Remover(Post post) {

            using (ISession session = NHibernateHelper.AbreSession())
            {

                ITransaction tx = session.BeginTransaction();
                session.Delete(post);
                tx.Commit();


            }

        }

        public void Atualiza(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {

                ITransaction tx = session.BeginTransaction();
                session.Merge(post);
                tx.Commit();

            }
          
        }

        public IList<Post> Lista()
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                string hql = "select p from Post p";
                IQuery query = session.CreateQuery(hql);
                return query.List<Post>();
            }
        }
    }
}