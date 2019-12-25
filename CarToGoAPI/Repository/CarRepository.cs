using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    public class CarRepository : IRepository<Car>, IDisposable
    {
        public void Delete(Car entity)
        {
            // remove the local entity
            DatabaseContext.Instance.Cars.Remove(entity);
        }

        public void Dispose()
        {
            DatabaseContext.Instance.SaveChanges();
        }

        public Car FindById(int Id)
        {
            foreach (Car car in DatabaseContext.Instance.Cars)
            {
                if (car.ID == Id)
                {
                    return car;
                }
            }
            return null;
        }

        public List<Car> GetAll()
        {
            return DatabaseContext.Instance.Cars.ToList();
        }

        public void Update(Car entity)
        {
            for (int i = 0; i < DatabaseContext.Instance.Cars.Count(); i++)
            {
                if (DatabaseContext.Instance.Cars.ElementAt(i).ID == entity.ID)
                {
                    // TODO make pritty
                    //DatabaseContext.Instance.Cars.ElementAt(i).GPSCordinates = entity.GPSCordinates;
                    DatabaseContext.Instance.Cars.ElementAt(i).LicensePlate = entity.LicensePlate;
                    //DatabaseContext.Instance.Cars.ElementAt(i).Orders = entity.Orders;
                    DatabaseContext.Instance.Cars.ElementAt(i).Status = entity.Status;
                    DatabaseContext.Instance.Cars.ElementAt(i).TotalKM = entity.TotalKM;
                    DatabaseContext.Instance.Cars.ElementAt(i).AnimalsAllowed = entity.AnimalsAllowed;
                    DatabaseContext.Instance.Cars.ElementAt(i).CarModel = entity.CarModel;
                    //DatabaseContext.Instance.Cars.ElementAt(i).Engin = entity.Engin;
                }
            }
        }
    }
}
