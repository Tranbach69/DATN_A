using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
	public class User : Base
	{
		public int Age { get; set; }
		public string Phone { get; set; }		
		public string Imei { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
	}
}
