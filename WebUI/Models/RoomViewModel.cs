using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
	public class RoomViewModel
	{
		[Display(Name = "Oda No")]
		public int RoomId { get; set; }
        [Display(Name = "Oda Adı")]
        public string RoomName { get; set; }
        public int BuildingId { get; set; }
        [Display(Name = "Bina Adı")]
        public string BuildingName { get; set; }
	}
}
