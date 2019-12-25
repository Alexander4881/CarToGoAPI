using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Helper
{
    public class Helper
    {
        public string GetPinkCode()
        {
            Random ran = new Random();
            return ran.Next(10000, 99999).ToString();
        }
    }
}
