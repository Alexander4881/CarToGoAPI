using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    public class DriversLicensRepository : IRepository<DriversLicens>, IDisposable
    {
        public void Delete(DriversLicens entity)
        {
            DatabaseContext.Instance.DirversLicenes.Remove(entity);
        }

        public void Dispose()
        {
            DatabaseContext.Instance.SaveChanges();
        }

        public DriversLicens FindById(int Id)
        {
            foreach (DriversLicens driversLicens in DatabaseContext.Instance.DirversLicenes)
            {
                if (driversLicens.ID == Id)
                {
                    return driversLicens;
                }
            }
            return null;
        }

        public List<DriversLicens> GetAll()
        {
            return DatabaseContext.Instance.DirversLicenes.ToList();
        }

        public void Update(DriversLicens entity)
        {
            for (int i = 0; i < DatabaseContext.Instance.DirversLicenes.Count(); i++)
            {
                if (DatabaseContext.Instance.DirversLicenes.ElementAt(i).ID == entity.ID)
                {
                    DatabaseContext.Instance.DirversLicenes.ElementAt(i).ExpiryDate = entity.ExpiryDate;
                    DatabaseContext.Instance.DirversLicenes.ElementAt(i).DriversLicensNumber = entity.DriversLicensNumber;
                    DatabaseContext.Instance.DirversLicenes.ElementAt(i).Country = entity.Country;
                    DatabaseContext.Instance.DirversLicenes.ElementAt(i).ValidityDate = entity.ValidityDate;
                }
            }
        }
    }
}
