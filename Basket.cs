using System.Collections.Generic;
using System;

using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BasketManagment
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }

        public int customerId { get; set; }
        public Customer Customer { get; set; }
        //public List<Product> Cart { get; set; }
        public List<BasketProduct> basketproducts { get; set; }

        public Basket()
        {
            //Cart = new List<Product>();
        }


    }
}



