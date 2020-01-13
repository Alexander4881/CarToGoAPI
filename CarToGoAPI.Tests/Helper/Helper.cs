using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarToGoAPI.Helper;
using Xunit;

namespace CarToGoAPI.Tests.Helper
{
    public class Helper_Test
    {
       
        [Fact]
        public void GetPinkCode_Test()
        {
            CarToGoAPI.Helper.Helper helper_test = new CarToGoAPI.Helper.Helper();
            Assert.True(helper_test.GetPinkCode().ToString().Length == 5);
        }
    }
}
