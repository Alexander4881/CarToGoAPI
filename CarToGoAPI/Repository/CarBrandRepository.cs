using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    public class CarBrandRepository : IRepository<CarBrand>, IDisposable
    {
        public void Delete(CarBrand entity)
        {
            DatabaseContext.Instance.CarBrands.Remove(entity);
        }

        public void Dispose()
        {
            DatabaseContext.Instance.SaveChanges();
        }

        public CarBrand FindById(int Id)
        {
            foreach (CarBrand carBrand in DatabaseContext.Instance.CarBrands)
            {
                if (carBrand.ID == Id)
                {
                    return carBrand;
                }
            }
            return null;
        }

        public List<CarBrand> GetAll()
        {
            return DatabaseContext.Instance.CarBrands.ToList();
        }

        public void Update(CarBrand entity)
        {
            for (int i = 0; i < DatabaseContext.Instance.CarBrands.Count(); i++)
            {
                if (DatabaseContext.Instance.CarBrands.ElementAt(i).ID == entity.ID)
                {
                    DatabaseContext.Instance.CarBrands.ElementAt(i).Name = entity.Name;
                }
            }
        }
    }
}
