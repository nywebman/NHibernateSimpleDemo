using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using NHibernateSimpleDemo.POCO;

namespace NHibernateSimpleDemo
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            SeedData();
            Logging l = NHibernateHelper.RetrieveEntity<Logging>(1);
            Console.WriteLine(l.Message);
        }
        void SeedData()
        {
            Users u = new Users() { Email = "brosen@mdsol.com", Login = "brosen", Password = "password" };

            Taxonomy t = new Taxonomy() { Name = "Healh" };
            Taxonomy t2 = new Taxonomy() { Name = "Healh.Doctor" };
            t2.Parent = t;
            Taxonomy t3 = new Taxonomy() { Name = "Health.Doctor.Dentist" };
            t3.Parent = t2;

            NHibernateHelper.Save(u);
            NHibernateHelper.Save(t);
            NHibernateHelper.Save(t2);
            NHibernateHelper.Save(t3);

            Logging l = new Logging() { Message = "this is a test", Date = DateTime.UtcNow };
            l.User=u;
            l.Taxonomy = t3;

            NHibernateHelper.Save(l);

            l.Message = "second message";
            l.Date = DateTime.UtcNow;

            NHibernateHelper.Save(l);

            
        }
    
        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
