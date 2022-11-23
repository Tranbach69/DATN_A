using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
	public class Ethernet : Base
	{
		public string MacAddress { get; set; }
		public string DriverType { get; set; }
		public string LanCtrl { get; set; }
		public string LanMode { get; set; }
		public string EthernetIp { get; set; }
		public int EthernetOfDeviceId { get; set; }

		public Device Device { get; set; }
	}
}
