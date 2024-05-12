using Core.Entities;


namespace Entities.Concrete
{
    public class Room :IEntity
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int BuildingId { get; set; }
    }
}
