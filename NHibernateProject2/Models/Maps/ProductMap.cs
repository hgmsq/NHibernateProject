using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
namespace NHibernateProject2.Models.Maps
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Length(50).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.UnitPrice).Not.Nullable();
            Map(x => x.ReorderLevel);
            Map(x => x.Discontinued);
            References(x => x.Category).Not.Nullable();
        }
    }
}