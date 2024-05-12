using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        // Bir envanterin birden fazla depoda olabileceği için ICollection kullanıyoruz
        public  ICollection<ProductSore>? Stores { get; set; }
    }
}
