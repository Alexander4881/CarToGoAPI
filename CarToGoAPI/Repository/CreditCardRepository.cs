using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Repository
{
    public class CreditCardRepository : IRepository<CreditCard>, IDisposable
    {
        public void Delete(CreditCard entity)
        {
            DatabaseContext.Instance.CreditCards.Remove(entity);
        }

        public void Dispose()
        {
            DatabaseContext.Instance.SaveChanges();
        }

        public CreditCard FindById(int Id)
        {
            return DatabaseContext.Instance.CreditCards.ElementAt(Id);
        }

        public List<CreditCard> GetAll()
        {
            return DatabaseContext.Instance.CreditCards.ToList();
        }

        public void Update(CreditCard entity)
        {
            for (int i = 0; i < DatabaseContext.Instance.CreditCards.Count(); i++)
            {
                if (DatabaseContext.Instance.CreditCards.ElementAt(i).ID == entity.ID)
                {
                    DatabaseContext.Instance.CreditCards.ElementAt(i).Ccv = entity.Ccv;
                    DatabaseContext.Instance.CreditCards.ElementAt(i).CreditCardHolder = entity.CreditCardHolder;
                    DatabaseContext.Instance.CreditCards.ElementAt(i).CreditCardNumber = entity.CreditCardNumber;
                    DatabaseContext.Instance.CreditCards.ElementAt(i).ExpiryDate = entity.ExpiryDate;
                }
            }
        }
    }
}
