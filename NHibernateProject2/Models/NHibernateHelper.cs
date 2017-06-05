using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernateProject2.Models.Maps;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
namespace NHibernateProject2.Models
{
    public class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration
                .MsSql2008
                .ConnectionString(c=>c.FromConnectionStringWithKey("PISConn"))).
                Mappings(m=>m.FluentMappings
                .AddFromAssemblyOf<ProductMap>()).ExposeConfiguration(CreateSchema).BuildSessionFactory();
                
        }
        public static void CreateSchema(Configuration cfg)
        {
            var schemaExport =new  SchemaExport(cfg);
            schemaExport.Create(false,false);
        }
    }
}