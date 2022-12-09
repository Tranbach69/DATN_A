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
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Altitude { get; set; }
		public string Speed { get; set; }
		public string Bearing { get; set; }
		public string Accuracy { get; set; }
		public string Time { get; set; }
		public Device Device { get; set; }


	}
}
