namespace DataObjects.Entities
{
    public class Product
    {
        public virtual int ProductId { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
