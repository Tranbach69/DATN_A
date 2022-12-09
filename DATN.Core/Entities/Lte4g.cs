using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
	public class Lte4g : Base
	{
		public string SimStatus { get; set; }
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
		public string Rssi4G { get; set; }
		public Device Device { get; set; }


	}
}
