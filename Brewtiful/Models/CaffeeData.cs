namespace Brewtiful.Models
{
    public class CaffeeData
    {
        public IEnumerable<Caffee> Caffees { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CaffeeCategory> CaffeeCategories { get; set; }
    }
}
