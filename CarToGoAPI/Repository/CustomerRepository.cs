using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    class CustomerRepository : IRepository<Customer>
    {
        public void Delete(Customer entity)
        {
            DatabaseContext.Instance.Customers.Remove(entity);
        }

        public Customer FindById(int Id)
        {
            foreach (Customer customer in DatabaseContext.Instance.Customers)
            {
                if (customer.ID == Id)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return DatabaseContext.Instance.Customers.ToList();
        }

        public void Update(Customer entity)
        {
            
        }
    }
}
