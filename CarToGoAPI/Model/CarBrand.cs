using CarToGoAPI.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarToGoAPI.Model
{
    [Table("CarBrand")]
    public class CarBrand : IEntity
    {

        // Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<CarModel> CarModel { get; set; }
    }
}