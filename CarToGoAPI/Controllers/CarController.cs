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
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        // GET: Car
        //        public IEnumerable<string> Get()

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            //using (CustomerRepository cr = new CustomerRepository())
            //{
            //    return JsonSerializer.Serialize(cr.GetAll());
            //}
            using (CarRepository ca = new CarRepository()) 
            {
                return ca.GetAll();
            }
                //return JsonSerializer.Serialize(DatabaseContext.Instance.Cars);
        }

        // GET: Car/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            //return "value";
            using (CarRepository ca = new CarRepository())
            {
                Car car = ca.FindById(id);
                return car;
                //return JsonSerializer.Serialize(customer);
            }
        }
    }
}
