using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    class CustomerRepository : IRepository<Customer>, IDisposable
    {
        public void Delete(Customer entity)
        {
            // remove a customer
            DatabaseContext.Instance.Customers.Remove(entity);
        }

        public void Dispose()
        {
            DatabaseContext.Instance.SaveChanges();
        }

        public Customer FindById(int Id)
        {
            // loop through the customers
            foreach (Customer customer in DatabaseContext.Instance.Customers)
            {
                // check the id
                if (customer.ID == Id)
                {
                    // return the customers
                    return customer;
                }
            }
            // return null
            return null;
        }

        public Customer FindByEmailAndPW(string email, string pw)
        {
            // loop through the customers
            foreach (Customer customer in DatabaseContext.Instance.Customers)
            {
                // check the id
                if ( (customer.Email == email) && (customer.Password == pw) )
                {
                    // return the customers
                    return customer;
                }
            }
            return null;

        }
        public List<Customer> GetAll()
        {
            // return a list of customers 
            return DatabaseContext.Instance.Customers.ToList();            
        }

        public void Add(Customer entity) {
            DatabaseContext.Instance.Customers.Add(entity);        
        }


        public void Update(Customer entity)
        {
            // loop through the customers
            for (int i = 0; i < DatabaseContext.Instance.Customers.Count(); i++)
            {
                // find the correct customer
                if (DatabaseContext.Instance.Customers.ElementAt(i).ID == entity.ID)
                {
                    // TODO make pritty
                    DatabaseContext.Instance.Customers.ElementAt(i).Password = entity.Password;
                    DatabaseContext.Instance.Customers.ElementAt(i).PhoneNumber = entity.PhoneNumber;
                    DatabaseContext.Instance.Customers.ElementAt(i).Sex = entity.Sex;
                    DatabaseContext.Instance.Customers.ElementAt(i).Address = entity.Address;
                    DatabaseContext.Instance.Customers.ElementAt(i).BithDate = entity.BithDate;
                    //DatabaseContext.Instance.Customers.ElementAt(i).CreditCards = entity.CreditCards;
                    //DatabaseContext.Instance.Customers.ElementAt(i).DriversLicens = entity.DriversLicens;
                    DatabaseContext.Instance.Customers.ElementAt(i).Email = entity.Email;
                }
            }
        }
    }
}
