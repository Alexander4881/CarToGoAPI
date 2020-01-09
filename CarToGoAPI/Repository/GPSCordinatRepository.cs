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
        public void Add(GPSCordinat entity)
        {
            DatabaseContext.Instance.GPSCordinats.Add(entity);
        }

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
            foreach (GPSCordinat gpsCordinat in DatabaseContext.Instance.GPSCordinats)
            {
                if (gpsCordinat.ID == entity.ID)
                {
                    gpsCordinat.Latitude = entity.Latitude;
                    gpsCordinat.Longitude = entity.Longitude;
                    gpsCordinat.Received = entity.Received;
                }
            }
        }
    }
}
