using CarToGoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("Car")]
    public class Car : IEntity
    {
        // attributes
        private CarModel carModel;
        private string licensePlate;
        private IEngine engin;
        private bool animalsAllowed;
        private int status;
        private float totalKM;

        // properties
        public int ID { get; set; }
        public string LicensePlate { get => licensePlate; set => licensePlate = value; }
        public bool AnimalsAllowed { get => animalsAllowed; set => animalsAllowed = value; }
        public int Status { get => status; set => status = value; }
        public float TotalKM { get => totalKM; set => totalKM = value; }

        public IEngine Engin { get => engin; set => engin = value; }
        public CarModel CarModel { get => carModel; set => carModel = value; }
        public ICollection<OrderdCars> Orders { get; set; }
        public ICollection<GPSCordinat> GPSCordinates {get;set;}

        // constructor
        public Car(CarModel carModel, string licensePlate, IEngine engin, bool animalsAllowed, int status, float totalKM, ICollection<OrderdCars> orders, ICollection<GPSCordinat> gPSCordinates)
        {
            CarModel = carModel;
            LicensePlate = licensePlate;
            Engin = engin;
            AnimalsAllowed = animalsAllowed;
            Status = status;
            TotalKM = totalKM;
            Orders = orders;
            GPSCordinates = gPSCordinates;
        }

        // Methods
        public bool UnlockCar(int pin)
        {
            // TODO check pin
            return false;
        }

        public void LockCar()
        {
            // TODO lock the car
        }
    }
}
