using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    public class EletricEngineRepository : IRepository<EletricEngine>,IDisposable
    {
        public void Delete(EletricEngine entity)
        {
            DatabaseContext.Instance.EletricEngines.Remove(entity);
        }

        public void Dispose()
        {
            DatabaseContext.Instance.SaveChanges();
        }

        public EletricEngine FindById(int Id)
        {
            foreach (EletricEngine eletricEngine in DatabaseContext.Instance.EletricEngines)
            {
                if (eletricEngine.ID == Id)
                {
                    return eletricEngine;
                }
            }
            return null;
        }

        public List<EletricEngine> GetAll()
        {
            return DatabaseContext.Instance.EletricEngines.ToList();
        }

        public void Update(EletricEngine entity)
        {
            for (int i = 0; i < DatabaseContext.Instance.EletricEngines.Count(); i++)
            {
                if (DatabaseContext.Instance.EletricEngines.ElementAt(i).ID == entity.ID)
                {
                    DatabaseContext.Instance.EletricEngines.ElementAt(i).GetMaxDistance = entity.GetMaxDistance;
                    DatabaseContext.Instance.EletricEngines.ElementAt(i).GetDistanceLeft = entity.GetDistanceLeft;
                    DatabaseContext.Instance.EletricEngines.ElementAt(i).GetCurrentDistance = entity.GetCurrentDistance;
                    DatabaseContext.Instance.EletricEngines.ElementAt(i).Car = entity.Car;
                    DatabaseContext.Instance.EletricEngines.ElementAt(i).TotalKMDriven = entity.TotalKMDriven;
                }
            }
        }
    }
}
