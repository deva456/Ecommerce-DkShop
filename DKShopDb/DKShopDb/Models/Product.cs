using System;
using System.Collections.Generic;

#nullable disable

namespace dkshopDb.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public decimal Quantity { get; set; }
        public string ShortDesc { get; set; }
        public int? CategorieId { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }

        public virtual Category Categorie { get; set; }
    }
}
