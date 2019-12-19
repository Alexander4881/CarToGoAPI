using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    public class GPSCordinatRepository : IRepository<GPSCordinat>, IDisposable
    {
        public void Delete(GPSCordinat entity)
        {
            DatabaseContext.Instance.GPSCordinats.Remove(entity);
        }

        public void Dispose()
        {
            DatabaseContext.Instance.SaveChanges();
        }

        public GPSCordinat FindById(int Id)
        {
            foreach (GPSCordinat gpsCordinat in DatabaseContext.Instance.GPSCordinats)
            {
                if (gpsCordinat.ID == Id)
                {
                    return gpsCordinat;
                }
            }
            return null;
        }

        public List<GPSCordinat> GetAll()
        {
            return DatabaseContext.Instance.GPSCordinats.ToList();
        }

        public void Update(GPSCordinat entity)
        {
            for (int i = 0; i < DatabaseContext.Instance.GPSCordinats.Count(); i++)
            {
                if (DatabaseContext.Instance.GPSCordinats.ElementAt(i).ID == entity.ID)
                {
                    DatabaseContext.Instance.GPSCordinats.ElementAt(i).Latitude = entity.Latitude;
                    DatabaseContext.Instance.GPSCordinats.ElementAt(i).Longitude = entity.Longitude;
                    DatabaseContext.Instance.GPSCordinats.ElementAt(i).Received = entity.Received;
                }
            }
        }
    }
}
