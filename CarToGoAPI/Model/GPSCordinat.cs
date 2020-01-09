using CarToGoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("GPSCordinat")]
    public class GPSCordinat : IEntity
    {
        public GPSCordinat(){}
        public GPSCordinat(int id,decimal latitude, decimal longitude, DateTime received, Car car)
        {
            ID = id;
            Latitude = latitude;
            Longitude = longitude;
            Received = received;
            Car = car;
        }

        // Properties
        public int ID { get; set; }        
        public Decimal Latitude { get; set; }        
        public Decimal Longitude { get; set; }        
        public DateTime Received { get; set; }

        public virtual Car Car { get; set; }


    }
}
