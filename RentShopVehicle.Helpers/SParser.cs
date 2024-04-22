using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentShopVehicle.Helpers
{
    public class SParser
    {
        public static (int, int) ParseMinMax(string input)
        {
            string[] parts = input.Replace("[", "").Replace("]", "").Split('-');

            int min = int.Parse(parts[0].Trim().Replace("$", "").Replace(" ", ""));
            int max = int.Parse(parts[1].Trim().Replace("$", "").Replace(" ", ""));

            return (min, max);
        }
    }
}
