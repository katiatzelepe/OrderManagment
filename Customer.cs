using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BasketManagment
{
    public class Customer : ICustomerService
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Dob { get; set; }
        public DateTime Dor { get; set; }
        public string Email { get; set; }

        public List<Basket> baskets { get; set; } //** for 1 to many

        //public List<Customer> Customers { get; set; }

        //public virtual ICollection<Basket> PreviousBaskets { get; set; }

      


        public Customer()
        {
            //Customers = new List<Customer>();
            //baskets = new List<Basket>();
        }

        public Customer(string name, string address, string dob, string email)
        {
            Name = name;
            Address = address;
            Dob = dob;
            Email = email;
            Dor = DateTime.Today;
        }

        public override string ToString()
        {
            return $"{Id}:{Name}:{Address}:{Dob}:{Dor}:{Email}";
        }




        public Customer Register( string Name, string Address, string Dob, string Email)
        {
            try
            {
                
                var rep = new Repository();
                rep.Add(new Customer(Name, Address, Dob, Email));
                rep.SaveChanges();
                
                var customer = rep.Set<Customer>().Last();
                return customer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
                return null;
            }

            

        }

        public bool Update(string Email, string Name, string Address, string Dob)
        {
            try
            {
                var rep = new Repository();
                var update = rep.Set<Customer>().SingleOrDefault(b => b.Email == Email);
                if (update == null)
                {
                    Console.WriteLine("Please Try Again"); 
                }
                update.Name = Name;
                update.Address = Address;
                update.Dob = Dob;
                rep.SaveChanges();

                return true;   
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(string Email)
        {
            try
            {
                var rep = new Repository();
                var delete = rep.Set<Customer>().SingleOrDefault(b => b.Email == Email);
                rep.Remove(delete);
                rep.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AddBasket(string Email, Basket basket)
        {
            try
            {
                var rep = new Repository();
                var add = rep.Set<Customer>()
                    .SingleOrDefault(b => b.Email == Email);
                if (add != null)
                {
                    add.baskets.Add(basket);
                    rep.Add(basket);
                    rep.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void DeleteBasket(string Email, int BasketId)
        {
            try
            {
                var rep = new Repository();
                var remove = rep.Set<Customer>()
                    .SingleOrDefault(c => c.Email == Email);
                if (remove != null)
                {
                    var remove1 = rep.Set<Basket>() //Basket with given basketId that belongs to above customer
                    .SingleOrDefault(b => b.Id == BasketId);
                    if (remove1 != null && remove1.Customer.Id == remove.Id)
                    {
                        remove.baskets.Remove(remove1);
                        rep.SaveChanges();
                    }

                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }

        public List<Customer> GetRecentCustomers()
        {
            var recentCustomers = new List<Customer>();
            try
            {
                var rep = new Repository();
                recentCustomers = rep.Set<Customer>()
                    .Where(c => c.Dor.AddDays(7) >= DateTime.Today)
                    .ToList();

                return recentCustomers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return recentCustomers;
            }
        }

    }



}
