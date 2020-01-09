using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.ViewModel
{
    public class ReserverCar
    {
        public int CustomerID { get; set; }
        public int CarID { get; set; }
    }

    public class UnlockCar
    {
        public int CarID { get; set; }
        public string PinkCode { get; set; }
    }

    public class GPSPostCordinat
    {
        public int CarID { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
    }

    public class TryPayment
    {
        public DateTime EndDT { get; set; }
        public double Total { get; set; }
    }

    public class CheckOutOrder
    {
        public int OrderCarID { get; set; }
        public int CustomerID { get; set; }
    }
}
