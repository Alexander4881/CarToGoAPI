using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarToGoAPI.Model;
using CarToGoAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CarToGoAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]

    public class CustomeController : ControllerBase
    {
        // GET: Custome
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: Custome/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: Custome
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer value)
        {
            
            var newDriversLicens = new DriversLicens { DriversLicensNumber = "12345", Country = "china", ValidityDate = Convert.ToDateTime("2000-11-11"), ExpiryDate = Convert.ToDateTime("2000-11-11") };
           var newCreditCard = new CreditCard { CreditCardNumber = "123456789",  CreditCardHolder = "XiPan", ExpiryDate= Convert.ToDateTime("2020-11-26"), Ccv ="123"  };
            var newCustomer = new Customer { Email = "Emai444ghgh4l", Password = "Password", Sex = true, FirstName = "abcFirstname", AftertName = "xyz", Address = "Address", PhoneNumber = "1234567", BithDate = Convert.ToDateTime("2019-11-26"), DriversLicens = newDriversLicens, CreditCards = newCreditCard };

            CustomerRepository cr = new CustomerRepository(); 
            //cr.Add(newCustomer);
            cr.Add(value);
            cr.Dispose();
            return value;
            //return value.Email.ToString();
            //return value.FirstName.ToString();
        }

        // PUT: api/Custome/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
