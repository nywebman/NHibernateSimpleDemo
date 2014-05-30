using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateSimpleDemo.POCO
{
    public class Users
    {
        public virtual int UserId { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
    }
}