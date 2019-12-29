using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    public class OrderdCarsRepository : IRepository<OrderdCars>, IDisposable
    {
        public void Delete(OrderdCars entity)
        {
            DatabaseContext.Instance.OrderdCars.Remove(entity);
        }

        public void Dispose()
        {
            DatabaseContext.Instance.SaveChanges();
        }

        public OrderdCars FindById(int Id)
        {
            foreach (OrderdCars orderdCars in DatabaseContext.Instance.OrderdCars)
            {
                if (orderdCars.ID == Id)
                {
                    return orderdCars;
                }
            }
            return null;
        }

        public OrderdCars FindByCarIdAndPinkCode(int carID, string pinkCode)
        {
             OrderdCars currentOrderCar = DatabaseContext.Instance.OrderdCars
                .Where(c => c.CarID == carID )
                .Where(c=> c.PinkCode == pinkCode )
                .First();
            return currentOrderCar;
        }

        public void Add(OrderdCars entity)
        {
            DatabaseContext.Instance.OrderdCars.Add(entity);
        }

        public List<OrderdCars> GetAll()
        {
            return DatabaseContext.Instance.OrderdCars.ToList();
        }

        public List<OrderdCars> GetOrderCarsByCustomerId(int customerId)
        {
            return DatabaseContext.Instance.OrderdCars
                .Where(c => c.CustomerID == customerId)
                .OrderBy(c => c.Status)
                .ToList();
        }

        public void Update(OrderdCars entity)
        {
            for (int i = 0; i < DatabaseContext.Instance.OrderdCars.Count(); i++)
            {
                if (DatabaseContext.Instance.OrderdCars.ElementAt(i).ID == entity.ID)
                {
                    DatabaseContext.Instance.OrderdCars.ElementAt(i).OrderNumber = entity.OrderNumber;
                    //DatabaseContext.Instance.OrderdCars.ElementAt(i).StarteTime = entity.StarteTime;
                    //DatabaseContext.Instance.OrderdCars.ElementAt(i).EndTime = entity.EndTime;
                    DatabaseContext.Instance.OrderdCars.ElementAt(i).DrivenKM = entity.DrivenKM;
                    //DatabaseContext.Instance.OrderdCars.ElementAt(i).CreateDate = entity.CreateDate;
                    DatabaseContext.Instance.OrderdCars.ElementAt(i).CarID = entity.CarID;
                }
            }
        }
    }
}
