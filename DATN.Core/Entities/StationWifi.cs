using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
	public class StationWifi : Base
	{
		public string StaIp { get; set; }
		public string StaSsidExt { get; set; }
		public string StaSecurity { get; set; }
		public string StaProtocol { get; set; }
		public int StaPassword { get; set; }
	}
}
