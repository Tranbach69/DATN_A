using DATN.Core.Common;

namespace DATN.Core.Entities
{
	public class Gps : Base
	{
		public new string Imei { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double Altitude { get; set; }
		public float Speed { get; set; }
		public float Bearing { get; set; }
		public float Accuracy { get; set; }
		public string Time { get; set; }
		public Device Device { get; set; }


	}
}
