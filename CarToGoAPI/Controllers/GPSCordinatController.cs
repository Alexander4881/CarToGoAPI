using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarToGoAPI.Model;
using CarToGoAPI.Repository;
using CarToGoAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarToGoAPI.Controllers
{
    [Route("Coordinate")]
    [ApiController]
    public class GPSCordinatController : ControllerBase
    {
        // POST: Coordinate/New
        [Route("New")]
        [HttpPost]
        public ActionResult<bool> New([FromBody] GPSPostCordinat value)
        {
            bool returnVal = false;
            using (CarRepository cr = new CarRepository())
            {
                Car car = cr.FindById(value.CarID);
                if (car != null)
                {
                    using (GPSCordinatRepository gr = new GPSCordinatRepository())
                    {
                        GPSCordinat newCordinat = new GPSCordinat(car.GPSCordinat.ID, value.Latitude, value.Longitude, DateTime.Now, car);
                        gr.Update(newCordinat);
                        returnVal = true;
                    }
                }
            }
            return returnVal;
        }
    }
}