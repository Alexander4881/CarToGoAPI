using CarToGoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("CreditCard")]
    public class CreditCard : IEntity
    {
        // Properties
        public int ID { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardHolder { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Ccv { get; set; }

        public virtual Customer Customer { get; set; }


    }
}
