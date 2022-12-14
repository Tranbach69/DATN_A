using DATN.Core.Common;


namespace DATN.Core.Entities
{
	public class Ethernet : Base
	{
		public string Imei { get; set; }
		public int DriverType { get; set; }
		public int DriverEn { get; set; }
		public int BringUpdownEn { get; set; }
		public int IpStaticEn { get; set; }
		public string IpAddr { get; set; }
		public string Netmask { get; set; }
		public Device Device { get; set; }

	}
}
