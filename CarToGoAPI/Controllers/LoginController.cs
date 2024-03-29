﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
    public class LoginController : ControllerBase
    {
        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        //        public ActionResult<Customer> Post([FromBody] Customer value)

        public ActionResult<Customer> Post([FromBody] LoginAuthentication value)
        {
            using (CustomerRepository cr = new CustomerRepository())
            {
                Customer customer = cr.FindByEmailAndPW(value.Email, value.PassWord);
                return customer;
            }
        }

        // PUT: api/Login/5
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
