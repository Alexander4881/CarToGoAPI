using CarToGoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("DirversLicens")]
    public class DirversLicens : IEntity
    {
        // Attributes
        private string driversLicensNumber;
        private string country;
        private DateTime validityDate;
        private DateTime expiryDate;

        // Properties
        public int ID { get; set; }
        public string DriversLicensNumber { get => driversLicensNumber; set => driversLicensNumber = value; }
        public string Country { get => country; set => country = value; }
        public DateTime ValidityDate { get => validityDate; set => validityDate = value; }
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }

        // Constructor
        public DirversLicens(){}

        public DirversLicens(string driversLicensNumber, string country, DateTime validityDate, DateTime expiryDate)
        {
            DriversLicensNumber = driversLicensNumber;
            Country = country;
            ValidityDate = validityDate;
            ExpiryDate = expiryDate;
        }
    }
}
