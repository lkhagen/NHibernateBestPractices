using System.Collections.Generic;

namespace DataObjects.Entities
{
    public class Customer
    {
        public virtual int CustomerId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set;}
        public virtual string PostalCode { get; set; }
        public virtual string City { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }

        public virtual IList<Order> Orders { get; private set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
