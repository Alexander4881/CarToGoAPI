using CarToGoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("OrderdCars")]
    public class OrderdCars : IEntity
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; }

        /// <summary>
        /// <para>0: Standby</para>
        /// <para>1: Waiting to open</para>
        /// <para>2: Driving</para>
        /// <para>3: Finish</para>
        /// </summary>
        public int Status { get; set; }
        public DateTime CreateDT { get; set; }
        public DateTime? StarteDT { get; set; }
        public DateTime? EndDT { get; set; }
        public DateTime ValidityDT { get; set; }
        public string PinkCode { get; set; }
        public string QRCode { get; set; }
        public float? DrivenKM { get; set; }
        public float? Total { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }


        public int CarID { get; set; }
        public virtual Car Car { get; set; }

    }
}
