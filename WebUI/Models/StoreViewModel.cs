using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class StoreViewModel
    {
        public int StoreId { get; set; }
        [Display(Name = "Depo Adı")]
        public string StoreName { get; set; }
        public int BuildingId { get; set; }
        [Display(Name = "Bina Adı")]
        public string BuildingName { get; set; }
    }
}
