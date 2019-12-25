using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarToGoAPI.ViewModel;
using CarToGoAPI.Model;
using CarToGoAPI.Repository;
using CarToGoAPI.Helper;

namespace CarToGoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        // GET: Reserve
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: Reserve/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: Reserve

        [HttpPost]
        public ActionResult<OrderdCars> Post([FromBody] ReserverCar value)
        {


            Helper.Helper helper = new Helper.Helper();

            var orderCar = new OrderdCars { Status = 0, CreateDT = DateTime.Now, ValidityDT = DateTime.Now.AddMinutes(20), PinkCode = helper.GetPinkCode().ToString(), CustomerID = value.CustomerID, CarID = value.CarID};

             

            OrderdCarsRepository oc = new OrderdCarsRepository();
            oc.Add(orderCar);
            oc.Dispose();

            return orderCar;
        }

        // POST: Reserve/unlock
        [Route("unlock")]
        [HttpPost]
        public string Unlock()
        {
            return "abc";

        }

        // PUT: Reserve/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
