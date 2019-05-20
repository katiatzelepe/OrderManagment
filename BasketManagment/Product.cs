using System.Collections.Generic;

namespace BasketManagment
{
    public class Product
    {

        public int ProductId{ get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategoryId Category { get; set; }

        //public Basket basket { get; set; }
       // public List<Product> Cart { get; set; }
        public List<Basket> baskets { get; set; }
        public Product()
        {
            baskets = new List<Basket>();
        }

        public override string ToString()
        {
            return $"{ProductId}:{Name}:{Price}:{Category.ToString()}";
        }
    }
}
