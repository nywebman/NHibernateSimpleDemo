using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernateSimpleDemo.POCO
{
    public class Logging
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual String Message { get; set; }

        public virtual Users User { get; set; }
        public virtual Taxonomy Taxonomy { get; set; }
    }
}