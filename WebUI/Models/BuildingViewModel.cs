using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class BuildingViewModel
    {
        public int BuildingId { get; set; }

        [Display(Name = "Bina Adı")]
        public string BuildingName { get; set; }
    }
}
