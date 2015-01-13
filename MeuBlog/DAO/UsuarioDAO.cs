using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeuBlog.Models;
using NHibernate;

namespace MeuBlog.DAO
{
    public class UsuarioDAO
    {
        private ISession session;

        public UsuarioDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            ITransaction tx = session.BeginTransaction();
            session.Save(usuario);
            tx.Commit();
        }

        public IList<Usuario> Lista()
        {
            String hql = "Select u From Usuario u";
            IQuery query = session.CreateQuery(hql);
            return query.List<Usuario>();

        }

        public Usuario BuscaPorId(int? id)
        {
            if (id != null)
            {
                return session.Get<Usuario>(id);
            }
            else
            {
                return null;
            }
           
        }

    }
}