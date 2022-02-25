using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Reflection;

namespace BasicNHibernate.Console.Data
{
    public class NHibernateManager : IDisposable
    {
        private readonly ISessionFactory sessionFactory;
        private readonly ITransaction transaction;
        public readonly ISession Session;
        private bool doUpdate = true;


        public NHibernateManager(string connString)
        {
            this.sessionFactory = Fluently.Configure(new Configuration())
                .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(connString))
                .Mappings(mappings => mappings.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, doUpdate))
                .BuildConfiguration()
                .BuildSessionFactory();

            Session = sessionFactory.OpenSession();
            transaction = Session.BeginTransaction();
        }

        public void Dispose()
        {
            if (transaction.IsActive)
            {
                transaction.Commit();
                transaction.Dispose();
            }

            if (Session.IsOpen)
            {
                Session.Close();
                Session.Dispose();
            }

            if (sessionFactory != null && !sessionFactory.IsClosed)
            {
                sessionFactory.Close();
                sessionFactory.Dispose();
            }
        }
    }
}
