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
        // Attributes
        private string model;
        private double pricePerKM;
        private double pricePerMin;
        private CarBrand carBand;

        // Properties
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Model { get => model; set => model = value; }
        public double PricePerKM { get => pricePerKM; set => pricePerKM = value; }
        public double PricePerMin { get => pricePerMin; set => pricePerMin = value; }
        internal CarBrand CarBand { get => carBand; set => carBand = value; }

        // Constructors
        public CarModel() { }

        public CarModel(string model, double pricePerKM, double pricePerMin, CarBrand carBand)
        {
            Model = model;
            PricePerKM = pricePerKM;
            PricePerMin = pricePerMin;
            CarBand = carBand;
        }
    }
}
