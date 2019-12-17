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
        // Attributes
        private string creditCardNumber;
        private string creditCardHolder;
        private DateTime expiryDate;
        private string ccv;

        // Properties
        public int ID { get; set; }
        public string CreditCardNumber { get => creditCardNumber; set => creditCardNumber = value; }
        public string CreditCardHolder { get => creditCardHolder; set => creditCardHolder = value; }
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public string Ccv { get => ccv; set => ccv = value; }

        // constructor
        public CreditCard(){}

        public CreditCard(string creditCardNumber, string creditCardHolder, DateTime expiryDate, string ccv)
        {
            CreditCardNumber = creditCardNumber;
            CreditCardHolder = creditCardHolder;
            ExpiryDate = expiryDate;
            Ccv = ccv;
        }
    }
}
