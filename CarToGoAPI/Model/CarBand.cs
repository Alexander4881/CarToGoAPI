using System.ComponentModel.DataAnnotations.Schema;

namespace CarToGoAPI.Model
{
    [Table("CarBrand")]
    public class CarBand
    {
        // Attributes
        private string name;

        // Properties
        public string Name { get => name; set => name = value; }

        // Constructor
        public CarBand() { }

        public CarBand(string name)
        {
            Name = name;
        }
    }
}