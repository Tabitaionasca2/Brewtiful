using System.Security.Policy;

namespace Brewtiful.Models
{
    public class VendorIndexData
    {
        public IEnumerable<Vendor> Vendors { get; set; }
        public IEnumerable<Caffee> Caffees { get; set; }
    }
}
