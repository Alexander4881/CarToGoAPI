using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarToGoAPI.Model;
using CarToGoAPI.Repository;

namespace CarToGoAPI.ViewModel
{
    public class LoginAuthentication
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
