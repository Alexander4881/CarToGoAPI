using CarToGoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("Customer")]
    public class Customer : IEntity
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Sex { get; set; }
        public string FirstName { get; set; }
        public string AftertName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BithDate { get; set; }

        public virtual DriversLicens DriversLicens { get; set; }
        public virtual CreditCard CreditCards { get; set; }

        public ICollection<OrderdCars> OrderdCars { get; set; }
        //public virtual DriversLicens DriversLicens { get; set; }
        //public ICollection<CreditCard> CreditCards { get; set; }
    }
}
