using DataObjects.Entities;
using FluentNHibernate.Mapping;

namespace DataObjects.Mapping
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.CustomerId);

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Address);
            Map(x => x.PostalCode);
            Map(x => x.City);
            Map(x => x.Phone);
            Map(x => x.Email);

            HasMany(x => x.Orders)
                .Cascade.AllDeleteOrphan();
        }
    }
}
