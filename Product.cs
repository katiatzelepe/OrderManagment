using System.Collections.Generic;
using System;

using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BasketManagment
{
    public class Product
    {
        [Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategoryId Category { get; set; }

        public List<BasketProduct> basketproducts { get; set; }

        //public Basket basket { get; set; }
        // public List<Product> Cart { get; set; }
        public List<Basket> baskets { get; set; }
        public Product()
        {
            baskets = new List<Basket>();
        }

        public override string ToString()
        {
            return $"{Id}:{Name}:{Price}:{Category.ToString()}";
        }
    }
}
