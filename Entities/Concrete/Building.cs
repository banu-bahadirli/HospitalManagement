using Core.Entities;


namespace Entities.Concrete
{
    public class Building : IEntity
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        // Bina ile Oda arasında 1:N ilişki
        public ICollection<Room>? Rooms { get; set; }
        // Bina ile Depo arasında 1:N ilişki
        public ICollection<Store>? Stores { get; set; }

    }
}
