using RentShopVehicle.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.BusinessLogic
{
    public class Helpers
    {
        public static (int, int) SParseMinMax(string input)
        {
            return SParser.ParseMinMax(input);
        }
    }
}
