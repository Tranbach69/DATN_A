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
		public float Price { get; set; }
		public string EquipmentShop { get; set; }
		public string PurchaseDate { get; set; }
		public string WarrantyPeriod { get; set; }
	}
}
