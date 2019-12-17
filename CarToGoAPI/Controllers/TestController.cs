﻿using System.Collections.Generic;
using System.Linq;
using CarToGoAPI.Model;
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
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            Arduino arduino = null;

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
            return "nothing found on id:" + id + " Connection String " + DatabaseContext.Instance.Database.Connection;
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
