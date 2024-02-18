using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Brewtiful.Models
{
    public class Caffee
    {
        public int ID { get; set; }
        [Display(Name = "Caffee Name")]
        public string Name { get; set; }
        public string Brand { get; set; }
        public int? VendorID { get; set; }
        public Vendor? Vendor { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public ICollection<CaffeeCategory>? CaffeeCategories { get; set; }
    }
}
