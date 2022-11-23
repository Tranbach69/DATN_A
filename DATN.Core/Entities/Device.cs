using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
	public class Device: Base
	{

		public string Name { get; set; }
		public string MacAddress { get; set; }
		public float Price { get; set; }
		public string EquipmentShop { get; set; }
		public DateTime PurchaseDate { get; set; }
		public DateTime WarrantyPeriod { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }

		public int UserId { get; set; }
		public int WifiId { get; set; }
		public int EthernetId { get; set; }
		public int Lte4gId { get; set; }
		public int GpsId { get; set; }
		
		public User User { get; set; }
		public Wifi Wifi { get; set; }
		public Ethernet Ethernet { get; set; }
		public Lte4g Lte4g { get; set; }
		public Gps Gps { get; set; }
	}
}
