using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using NHibernateSimpleDemo.POCO;

namespace NHibernateSimpleDemo.Fluent
{
    public class LoggingMap : ClassMap<Logging>
    {
        public LoggingMap()
        {

            Id(x => x.Id);
            Map(x => x.Date)
                .Not.Nullable();
            Map(x => x.Message).Default(string.Empty);

            References(x => x.User)
                .Not.Nullable()
                .Cascade.All();
            References(x => x.Taxonomy)
                .Not.Nullable()
                .Cascade.All();
        }
    }
}