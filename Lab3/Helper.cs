using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;


namespace Lab3
{
    public static class DBHelper
    {
        public static ISession OpenSession()
        {
            string database = "Lab1";
            string user = "postgres";
            string password = "********";
            string conString = $"Host=localhost;Username={user};Password={password};Database={database}";

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard.ConnectionString(conString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(cfg => { new SchemaUpdate(cfg).Execute(false, true); })
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
