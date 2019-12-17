using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Interfaces
{
    interface IRepository<T> where T : IEntity
    {
        void Add() { }
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
    }
}
