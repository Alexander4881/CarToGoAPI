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
    public class EletricEngine : IEngine, IEntity
    {
        // attributes
        private float getMaxDistance;
        private float getCurrentDistance;
        private float getDistanceLeft;
        private long totalKMDriven;

        // properties
        public float GetMaxDistance { get => getMaxDistance; set => getMaxDistance = value; }
        public float GetCurrentDistance { get => getCurrentDistance; set => getCurrentDistance = value; }
        public float GetDistanceLeft { get => getDistanceLeft; set => getDistanceLeft = value; }
        public long TotalKMDriven { get => totalKMDriven; set => totalKMDriven = value; }
        public int ID { get; set; }

        // constructor
        public EletricEngine() { }

        public EletricEngine(float getMaxDistance, float getCurrentDistance, float getDistanceLeft, long totalKMDriven)
        {
            GetMaxDistance = getMaxDistance;
            GetCurrentDistance = getCurrentDistance;
            GetDistanceLeft = getDistanceLeft;
            TotalKMDriven = totalKMDriven;
        }
    }
}
