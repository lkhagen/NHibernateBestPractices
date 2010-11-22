using DataObjects.Entities;
using FluentNHibernate.Mapping;

namespace DataObjects.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.ProductId);

            Map(x => x.Name);
            Map(x => x.Description);
        }
    }
}
