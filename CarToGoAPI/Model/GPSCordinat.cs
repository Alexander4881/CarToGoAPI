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
        // Properties
        public int ID { get; set; }        
        public Decimal Latitude { get; set; }        
        public Decimal Longitude { get; set; }        
        public DateTime Received { get; set; }

        public virtual Car Car { get; set; }


    }
}
