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
        // Attributes
        private long longitude;
        private long latitude;
        private DateTime reciced;

        // Properties
        public int ID { get; set; }
        public long Longitude { get => longitude; set => longitude = value; }
        public long Latitude { get => latitude; set => latitude = value; }
        public DateTime Reciced { get => reciced; set => reciced = value; }

        // Constructors
        public GPSCordinat() { }
        public GPSCordinat(long longitude, long latitude, DateTime reciced)
        {
            Longitude = longitude;
            Latitude = latitude;
            Reciced = reciced;
        }
    }
}
