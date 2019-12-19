using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarToGoAPI.Model;
using CarToGoAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarToGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        // GET: api/Car
        [HttpGet]
        public string Get()
        {
            using (CustomerRepository cr = new CustomerRepository())
            {
                return JsonSerializer.Serialize(cr.GetAll());
            }
        }

        // GET: api/Car/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            using (CustomerRepository cr = new CustomerRepository())
            {
                Customer customer = cr.FindById(id);
                return JsonSerializer.Serialize(customer);
            }
        }
    }
}
