using System.Collections.Generic;
using System.Linq;
using CarToGoAPI.Model;
using CarToGoAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace CarToGoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: Test
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(DatabaseContext.Instance.Arduinos);
        }

        // GET: Test/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            CarRepository cr = new CarRepository();
            cr.UpdateStatusByCarID(1, 2);

            TimeZoneInfo localZone = TimeZoneInfo.Local;
            string res1 = "Local Time Zone ID: {0}" + localZone.Id;
            res1 = res1 + "   Display Name is: {0}." + localZone.DisplayName;
            res1 = res1 + "   Standard name is: {0}." +  localZone.StandardName;
            res1 = res1 + "   Daylight saving name is: {0}." +  localZone.DaylightName;
            return res1;

            Arduino arduino = null;

            //CreditCard creditCard = new CreditCard("101010101010", "Test User", new DateTime(1998, 08, 09), "997");
            //DriversLicens driversLicens = new DriversLicens("000889998", "Denmark", DateTime.Now, DateTime.Now.AddDays(1));
            //Customer customer = new Customer("temp@mail.com", "temp", false, "temp address", "88888888",DateTime.Now);

            //customer.CreditCards.Add(creditCard);
            //customer.DriversLicens.Add(driversLicens);

            //DatabaseContext.Instance.CreditCards.Add(creditCard);
            //DatabaseContext.Instance.DirversLicenes.Add(driversLicens);
            //DatabaseContext.Instance.Customers.Add(customer);

            Arduino newArduino = new Arduino("First Arduino Thing", DateTime.Now, "The First Thingy");

            DatabaseContext.Instance.Arduinos.Add(newArduino);
            DatabaseContext.Instance.SaveChanges();

            foreach (Arduino device in DatabaseContext.Instance.Arduinos)
            {
                if (device.ID == id)
                {
                    arduino = device;
                }
            }

            if (arduino != null)
            {

                return JsonSerializer.Serialize(arduino) + " Connection String " + DatabaseContext.Instance.Database.Connection.ConnectionString;
            }
            return "nothing found on id:" + id + " Connection String " + DatabaseContext.Instance.Database.Connection.ConnectionString;
        }

        // POST: Test
        [Route("post1")]
        [HttpPost]
        public string Post()
        {
            return "hello from test controller";
        }

        [Route("post2")]
        [HttpPost]
        public void Post2([FromForm]int id, [FromForm] float longitude, [FromForm] float latitude)
        {
            Arduino arduino = null;

            foreach (Arduino device in DatabaseContext.Instance.Arduinos)
            {
                if (device.ID == id)
                {
                    arduino = device;
                }
            }

            if (arduino != null)
            {
                ArduinoMessage message = new ArduinoMessage("Arduino GPS Cordinates", $"longitude:{longitude} , latitude:{latitude}", arduino);

                DatabaseContext.Instance.ArduinoMessages.Add(message);
                DatabaseContext.Instance.SaveChanges();
            }
        }
    }
}