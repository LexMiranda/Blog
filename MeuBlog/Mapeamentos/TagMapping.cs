﻿using FluentNHibernate.Mapping;
using MeuBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuBlog.Mapeamentos
{
    public class TagMapping : ClassMap<Tag>
    {
        public TagMapping()
        {
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.Nome);
        }

    }
}
