using MeuBlog.Infra;
using MeuBlog.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuBlog.DAO
{
    public class TagDAO
    {
        private ISession session;

        public TagDAO(ISession session)
        {
            this.session = session;

        }
        public void Adiciona(Tag tag)
        {
           
                ITransaction tx = session.BeginTransaction();
                session.Save(tag);
                tx.Commit();

            
        }

        public Tag BuscaPorNome(String nome)
        {
           
                String hql = "select t from Tag t where t.Nome = :nome";
                IQuery query = session.CreateQuery(hql);
                query.SetParameter("nome", nome);
                return query.UniqueResult<Tag>();
           
        }
        
    }
}