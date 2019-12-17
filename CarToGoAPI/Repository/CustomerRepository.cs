using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    interface CustomerRepository : IRepository<Customer>, IExtendedRepository<Customer>
    {
    }
}
