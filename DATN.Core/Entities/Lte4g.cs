using DATN.Core.Common;

namespace DATN.Core.Entities
{
	public class Lte4g : Base
	{
		public string Imei { get; set; }
		public int CardStatus { get; set; }
		public int Apptype { get; set; }
		public int AppState { get; set; }
		public int Pin { get; set; }
		public string SimIccid { get; set; }
		public string SimImsi { get; set; }
		public string SystemMode { get; set; }
		public string OperationMode { get; set; }
		public string MobileCountryCode { get; set; }
		public string MobileNetworkCode { get; set; }
		public string LocationAreaCode { get; set; }
		public string ServiceCellId { get; set; }
		public string FreqBand { get; set; }
		public string Current4GData { get; set; }
		public string Afrcn { get; set; }
		public string PhoneNumber { get; set; }
		public int Rssi4G { get; set; }
		public int NetworkMode { get; set; }
		public Device Device { get; set; }


	}
}
