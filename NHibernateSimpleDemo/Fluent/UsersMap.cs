using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using NHibernateSimpleDemo.POCO;

namespace NHibernateSimpleDemo.Fluent
{
    public class UsersMap : ClassMap<Users>
    {
        public UsersMap()
        {
            Id(x => x.UserId);
            Map(x => x.Login)
                .Unique();
            Map(x => x.Email)
                .Unique();
            Map(x => x.Password);
        }
    }
}