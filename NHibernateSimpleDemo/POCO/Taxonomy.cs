using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateSimpleDemo.POCO
{
    public class Taxonomy
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Taxonomy Parent { get; set; }

        public virtual IList<Taxonomy> Children { get; set; }
    }
}