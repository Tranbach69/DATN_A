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
		public string MacAddress { get; set; }
		public string NetworkProvider { get; set; }
		public string NetworkMode { get; set; }
		public string SystemMode { get; set; }
		public string OperationMode { get; set; }
		public string MobileCountryMode { get; set; }
		public string MobileNetworkMode { get; set; }
		public string LocationArea { get; set; }
		public string ServiceCellId { get; set; }
		public string FregBand { get; set; }
		public string Current4gData { get; set; }
		public string SimCardStatus { get; set; }
		public string SimCardType { get; set; }
		public string SimCardState { get; set; }
		public string SimCardPhone { get; set; }
		public string Rssi4g { get; set; }
		public int Lte4gOfDeviceId { get; set; }
		public Device Device { get; set; }

	}
}
