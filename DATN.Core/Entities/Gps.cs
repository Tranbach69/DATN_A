using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
	public class Gps : Base
	{
		public string MacAddress { get; set; }
		public string DoubleLatitude { get; set; }
		public string DoubleLongitude { get; set; }
		public string DoubleAltitude { get; set; }
		public string FloatSpeed { get; set; }
		public string FloatAccuracy { get; set; }
		public string Time { get; set; }
		public int GpsOfDeviceId { get; set; }
		public Device Device { get; set; }

	}
}
