using CarToGoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Interfaces
{
    interface IExtendedRepository<T> where T:IEntity
    {
        List<T> GetAll();
    }
}
