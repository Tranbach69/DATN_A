using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Share
{
    public class BConvertor
    {
        /// <summary>
        /// Convert lat long string to array with first element is lattitude and second element is longtitude
        /// </summary>
        /// <param name="latLong">String lat and long</param>
        /// <returns>[0] is lattitude, [1] is longtitude</returns>
        static public string[] LatLongToArray(string latLong)
        {
            return latLong.Split(',');
        }
    }
}
