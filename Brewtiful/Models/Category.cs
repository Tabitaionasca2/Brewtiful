﻿namespace Brewtiful.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<CaffeeCategory>? CaffeeCategories { get; set; }
    }
}
