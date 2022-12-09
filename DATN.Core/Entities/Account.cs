using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
	public class Account : Base
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public int Role { get; set; }
	}
}
