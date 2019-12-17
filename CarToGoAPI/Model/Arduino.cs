using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("RemoteDevice")]
    public class Arduino
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public string Message { get; set; }

        public ICollection<ArduinoMessage> ArduinoMessages { get; set; }

        // constructors
        public Arduino()
        {
            ArduinoMessages = new List<ArduinoMessage>();
        }
        public Arduino(string name, DateTime startTime, string message)
        {
            Name = name;
            StartTime = startTime;
            Message = message;
            ArduinoMessages = new List<ArduinoMessage>();
        }
    }
}
