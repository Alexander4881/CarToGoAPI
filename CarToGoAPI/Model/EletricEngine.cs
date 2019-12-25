using CarToGoAPI.Interfaces;
using CarToGoAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("EletricEngine")]
    public class EletricEngine : IEntity
    {

        // properties
        public int ID { get; set; }
        public float EnergyLeft { get; set; }
        public float KMsAvailable { get; set; }
        public virtual Car Car { get; set; }

    }
}
