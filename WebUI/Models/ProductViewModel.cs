using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ProductViewModel
    {
		[Display(Name = "Ürün No")]
		public int ProductId { get; set; }
        [Display(Name = "Ürün Kodu")]
        public string ProductCode { get; set; }
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }
    }
}
