using Core.Entities;


namespace Entities.Concrete
{
    public class Store : IEntity
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int BuildingId { get; set; }
		public Building? Building { get; set; }
		public  ICollection<ProductSore>? Products { get; set; }
    }
}
