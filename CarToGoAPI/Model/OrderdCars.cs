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
        // Attributes
        private string orderNumber;
        private DateTime createDate;
        private DateTime customeID;
        private Car carID;
        private DateTime starteTime;
        private DateTime endTime;
        private float drivenKM;

        // Properties
        public string OrderNumber { get => orderNumber; set => orderNumber = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime CustomeID { get => customeID; set => customeID = value; }
        public Car CarID { get => carID; set => carID = value; }
        public DateTime StarteTime { get => starteTime; set => starteTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public float DrivenKM { get => drivenKM; set => drivenKM = value; }
        public int ID { get; set; }

        // Constructor
        public OrderdCars() { }

        public OrderdCars(string orderNumber, DateTime createDate, DateTime customeID, Car carID, DateTime starteTime, DateTime endTime, float drivenKM)
        {
            OrderNumber = orderNumber;
            CreateDate = createDate;
            CustomeID = customeID;
            CarID = carID;
            StarteTime = starteTime;
            EndTime = endTime;
            DrivenKM = drivenKM;
        }
    }
}
