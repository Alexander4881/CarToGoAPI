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
        // Attributes
        private string email;
        private string password;
        private bool sex;
        private string address;
        private string phoneNumber;
        private DateTime bithDate;
        private DateTime dirversLicens;

        // Properties
        public int ID { get; set; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool Sex { get => sex; set => sex = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime BithDate { get => bithDate; set => bithDate = value; }

        public ICollection<DriversLicens> DriversLicens { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }

        // Constructor
        public Customer()
        {
            DriversLicens = new List<DriversLicens>();
            CreditCards = new List<CreditCard>();
        }

        public Customer(string email, string password, bool sex, string address, string phoneNumber, DateTime bithDate)
        {
            Email = email;
            Password = password;
            Sex = sex;
            Address = address;
            PhoneNumber = phoneNumber;
            BithDate = bithDate;
            DriversLicens = new List<DriversLicens>();
            CreditCards = new List<CreditCard>();
        }
    }
}
