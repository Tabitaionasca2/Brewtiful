namespace Brewtiful.Models
{
    public class CaffeeCategory
    {
        public int ID { get; set; }
        public int CaffeeID { get; set; }
        public Caffee Caffee { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
