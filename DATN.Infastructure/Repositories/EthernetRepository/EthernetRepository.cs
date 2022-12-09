using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.EthernetRepository
{
	public class EthernetRepository : Repository<Ethernet>, IEthernetRepository
	{
		public EthernetRepository(ApplicationDbContext context) : base(context)
		{

		}
		//public async Task<Ethernet> AddEthernetAsync(Ethernet entity)
		//{
		//	entity.TimingCreate = System.DateTime.Now;
		//	entity.IsDeleted = false;
		//	if (entity.Imei == "") return null;
		//	var a = await _context.Set<Device>().FirstOrDefaultAsync(a => a.Imei.Equals(entity.Imei));
		//	if (a != null) return null;
		//	await _context.Set<Ethernet>().AddAsync(entity);
		//	await _context.SaveChangesAsync();
		//	return entity;
		//}
	}
}
