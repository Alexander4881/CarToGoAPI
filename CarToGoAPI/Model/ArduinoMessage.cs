using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    [Table("ArduinoMessage")]
    public class ArduinoMessage
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        
        [JsonIgnore]
        public Arduino Arduino{ get; set; }

        public ArduinoMessage()
        {

        }

        public ArduinoMessage(string title, string message, Arduino arduino)
        {
            Title = title;
            Message = message;
            Arduino = arduino;
        }
    }
}
