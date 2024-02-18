using System.ComponentModel.DataAnnotations;

namespace Brewtiful.Models
{
    public class Vendor
    {
        public int ID { get; set; }
        [Display(Name = "Vendor")]
        public string VendorName { get; set; }
        public ICollection<Caffee>? Caffees { get; set; }
    }
}
