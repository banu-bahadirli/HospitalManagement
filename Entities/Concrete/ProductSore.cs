using Core.Entities;


namespace Entities.Concrete
{
    public  class ProductSore :IEntity
    {
        public int ProductSoreId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
    }
}
