using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using NHibernateSimpleDemo.POCO;

namespace NHibernateSimpleDemo.Fluent
{
    public class TaxonomyMap : ClassMap<Taxonomy>
    {
        public TaxonomyMap()
        {
            Id(x => x.Id);
            Map(x => x.Name)
                .Unique();

            References(x => x.Parent)
                .Column("ParentId");

            HasMany(x => x.Children);
        }

    }
}