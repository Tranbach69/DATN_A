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
		public int ClientCount { get; set; }
		public string Imei { get; set; }
		public string WifiOpen { get; set; }
		public string WifiMode { get; set; }
		public string CurrentAp { get; set; }
		public string WifiNat { get; set; }
		public string Ssid { get; set; }
		public string AuthPwd { get; set; }
		public string BroadCast { get; set; }
		public string Isolation { get; set; }
		public string MacAddress { get; set; }
		public string AuthType { get; set; }
		public string EncryptMode { get; set; }
		public string Channel { get; set; }
		public string ChannelMode { get; set; }
		public string DhcpHostIp { get; set; }
		public string DhcpStartIp { get; set; }
		public string DhcpEndIp { get; set; }
		public string DhcpTime { get; set; }

	}
}
