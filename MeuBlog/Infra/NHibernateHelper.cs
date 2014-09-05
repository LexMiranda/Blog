using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MeuBlog.Infra
{
    public class NHibernateHelper
    {
        private static ISessionFactory factory = CriaSessionFactory();

        private static ISessionFactory CriaSessionFactory()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            return Fluently.Configure(cfg)
                .Mappings(x => 
                    x.FluentMappings.AddFromAssembly(
                        Assembly.GetExecutingAssembly()
                    )
                ).BuildSessionFactory();
        }

        public static ISession AbreSession()
        {
            return factory.OpenSession();
                 
        }

    }
}