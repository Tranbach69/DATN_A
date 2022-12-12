using DATN.Core.Common;


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
