using CarToGoAPI.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarToGoAPI.Model
{
    [Table("CarBrand")]
    public class CarBrand : IEntity
    {
        // Attributes
        private string name;

        // Properties
        public string Name { get => name; set => name = value; }
        public int ID { get; set; }

        // Constructor
        public CarBrand() { }

        public CarBrand(string name)
        {
            Name = name;
        }
    }
}