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

        // properties
        public int ID { get; set; }
        public string LicensePlate { get; set; }
        public bool AnimalsAllowed { get; set; }

        /// <summary>
        /// <para>0: Standby</para>
        /// <para>1: Waiting to open</para>
        /// <para>2: Driving</para>
        /// <para>3: Finish</para>
        /// </summary>
        public int Status { get; set; }
        public float TotalKM { get; set; }

        //public IEngine Engin { get => engin; set => engin = value; }

        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }

        public virtual EletricEngine EletricEngine { get; set; }

        public virtual GPSCordinat GPSCordinat { get; set; }


        public ICollection<OrderdCars> OrderdCars { get; set; }
        ///public ICollection<GPSCordinat> GPSCordinates {get;set;}

        // constructor

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
