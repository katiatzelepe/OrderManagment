using System.Collections.Generic;

namespace BasketManagment
{
    public class Basket
    {
        public int BasketId { get; set; }
        
        public Customer Customer { get; set; }
        public List<Product> Cart { get; set; }

        public Basket()
        {
            Cart = new List<Product>();
        }


    }
}



