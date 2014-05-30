using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Tool.hbm2ddl;
using NHibernateSimpleDemo.POCO;
using FluentNHibernate.Cfg;
using System.ServiceModel.Channels;
using NHibernate.Cfg;
using NHibernate;

namespace NHibernateSimpleDemo
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static bool RunDDL = false;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            if (_sessionFactory == null)
            {

                _sessionFactory = Fluently
                    .Configure(new Configuration().Configure(@"C:\Users\brosen8\Documents\Visual Studio 2010\Projects\NHibernateSimpleDemo\NHibernateSimpleDemo\dev.cfg.xml"))
                    .Mappings(m => m.FluentMappings
                        .AddFromAssemblyOf<Users>())
                        //.ExposeConfiguration(cfg => new SchemaExport(cfg)
                        //    .Create(true, RunDDL))
                            .BuildSessionFactory();
            }
        }

        public static NHibernate.ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            if (!SessionFactory.IsClosed)
                SessionFactory.Dispose();
        }
        public static void Save(object o)
        {
            var session = OpenSession();
            var transaction = session.BeginTransaction();
            try
            {
                session.Save(o);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
            }

            CloseSession();

        }

        public static T RetrieveEntity<T>(int Id)
        {
            var session = OpenSession();
            return session.Get<T>(Id);
        }
    }
}