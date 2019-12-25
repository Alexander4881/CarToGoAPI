using CarToGoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("DirversLicens")]
    public class DriversLicens : IEntity
    {

        // Properties
        public int ID { get; set; }
        public string DriversLicensNumber { get; set; }
        public string Country { get; set; }
        public DateTime ValidityDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
