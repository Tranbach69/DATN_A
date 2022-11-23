using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
	public class Wifi: Base
	{
		public string MacAddress { get; set; }
		public string Ssid { get; set; }
		public string Pwd { get; set; }
		public string BroadCast { get; set; }
		public string Iso { get; set; }
		public string AuthType { get; set; }
		public string EncryptMode { get; set; }
		public string Channel { get; set; }
		public string ChannelMode { get; set; }
		public string Mode { get; set; }
		public string DhcpHostIp { get; set; }
		public string DhcpStartIp { get; set; }
		public string DhcpEndIp { get; set; }
		public string DhcpTime { get; set; }
		public string MacAdd { get; set; }
		public string MacCount { get; set; }
		public string NatType { get; set; }
		public string Status { get; set; }
		public string CurrentAp { get; set; }
		public int ClientCount { get; set; }
		public string WpsEnable { get; set; }
		public int WifiOfDeviceId { get; set; }
		public Device Device { get; set; }

	}
}
