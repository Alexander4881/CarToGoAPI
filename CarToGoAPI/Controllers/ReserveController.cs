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

            CarRepository cr = new CarRepository();
            cr.UpdateStatusByCarID(1, value.CarID);

            Helper.Helper helper = new Helper.Helper();

            var orderCar = new OrderdCars { Status = 1, CreateDT = DateTime.Now, ValidityDT = DateTime.Now.AddMinutes(20), PinkCode = helper.GetPinkCode().ToString(), CustomerID = value.CustomerID, CarID = value.CarID};             

            OrderdCarsRepository oc = new OrderdCarsRepository();
            oc.Add(orderCar);
            oc.Dispose();

            return orderCar;
        }

        // POST: Reserve/unlock
        [Route("unlock")]
        [HttpPost]        
        public ActionResult<OrderdCars> Unlock([FromBody] UnlockCar value)
        {

            OrderdCarsRepository oc = new OrderdCarsRepository();
            CarRepository cr = new CarRepository();
            OrderdCars currentOrder = oc.FindByCarIdAndPinkCode(value.CarID, value.PinkCode);
            //return currentOrder;
            if (!(currentOrder == null))
            {
                if (currentOrder.PinkCode == value.PinkCode)
                {
                    currentOrder.Status = 2;
                    currentOrder.StarteDT = DateTime.Now;
                    oc.Dispose();

                    Car currentCar = cr.FindById(value.CarID);
                    currentCar.Status = 2;
                    cr.Dispose();

                    return currentOrder;
                }
                return currentOrder;
            } 

            return null;

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
