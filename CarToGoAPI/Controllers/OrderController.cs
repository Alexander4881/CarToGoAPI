using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarToGoAPI.Model;
using CarToGoAPI.Repository;
using CarToGoAPI.ViewModel;

namespace CarToGoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        // GET: Order/5/Customer
        [Route("{id:int}/customer")]
        [HttpGet]
        public IEnumerable<OrderdCars> OrdersByCustomer(int id)
        {            
            OrderdCarsRepository oc = new OrderdCarsRepository();
            return oc.GetOrderCarsByCustomerId(id);
        }

        // GET: Order/5/TryPayment
        [Route("{id:int}/trypayment")]
        [HttpGet]
        public ActionResult<TryPayment> TryPayment(int id)
        {
            OrderdCarsRepository oc = new OrderdCarsRepository();
            OrderdCars currentOrderCar = oc.FindById(id);
            DateTime startDT = (DateTime)currentOrderCar.StarteDT;
            TimeSpan ts = DateTime.Now - startDT;
            if (currentOrderCar.Status == 2)
            {
                TryPayment result = new TryPayment
                {
                    EndDT = DateTime.Now,
                    Total = Math.Round(ts.TotalMinutes * currentOrderCar.Car.CarModel.PricePerMin, 1)
                };
                return result;
            }
            else
            {
                return null;
            }
        }

        // POST: Order/checkoutorder
        [Route("checkoutorder")]
        [HttpPost]
        public ActionResult<OrderdCars> CheckOutOrder([FromBody] CheckOutOrder value)
        //public String CheckOutOrder([FromBody] CheckOutOrder value)
        {
            //return value.OrderCarID.ToString() + ',' + value.CustomerID.ToString();
            OrderdCarsRepository oc = new OrderdCarsRepository();
            OrderdCars currentOrderCar = oc.FindById(value.OrderCarID);
            
            if (currentOrderCar != null)
            {                
                if ( (currentOrderCar.Status == 2) && (currentOrderCar.CustomerID == value.CustomerID) )
                {
                    
                    DateTime startDT = (DateTime)currentOrderCar.StarteDT;
                    TimeSpan ts = DateTime.Now.AddMinutes(-1) - startDT;
                    double total = Math.Round(ts.TotalMinutes * currentOrderCar.Car.CarModel.PricePerMin, 1);

                    currentOrderCar.Status = 3;
                    currentOrderCar.EndDT = DateTime.Now;
                    currentOrderCar.Total = (float)total;
                    oc.Dispose();

                    CarRepository cr = new CarRepository();
                    Car currentCar = cr.FindById(currentOrderCar.CarID);
                    currentCar.Status = 0;
                    cr.Dispose();

                    return currentOrderCar;

                }
            }
            return null;
        }

        // PUT: Order/5
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
