using DATN.Core.Common;

namespace DATN.Core.Entities
{
	public class Device: Base
	{
		public string DeviceName { get; set; }
		public float Price { get; set; }
		public string EquipmentShop { get; set; }
		public string PurchaseDate { get; set; }
		public string WarrantyPeriod { get; set; }
		public string Phone { get; set; }
		public int Age { get; set; }
		public string OwnerName { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public Wifi Wifi { get; set; }
		public Ethernet Ethernet { get; set; }
		public Lte4g Lte4g { get; set; }
		public Gps Gps { get; set; }
	}
}
