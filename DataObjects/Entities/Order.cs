using System;

namespace DataObjects.Entities
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual DateTime OrderDate { get; set; }
        
        public virtual Customer Customer { get; set; }
    }
}
