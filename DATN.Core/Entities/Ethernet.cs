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
		public string DriverType { get; set; }
		public string BringUpdownEn { get; set; }
		public string IpStaticEn { get; set; }
		public string IpAddr { get; set; }
		public string DriverEn { get; set; }
		public string Netmask { get; set; }
		public Device Device { get; set; }

	}
}
