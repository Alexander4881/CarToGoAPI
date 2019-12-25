using CarToGoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("CarModel")]
    public class CarModel : IEntity
    {

        // Properties
        public int ID { get; set; }
        public string Model { get; set; }
        public double PricePerKM { get; set; }
        public double PricePerMin { get; set; }

        public int CarBandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }
        public ICollection<Car> Car { get; set; }

    }
}
