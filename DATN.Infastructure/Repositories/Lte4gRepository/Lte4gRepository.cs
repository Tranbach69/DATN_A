using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.Lte4gRepository
{
	public class Lte4gRepository : Repository<Lte4g>, ILte4gRepository
	{
		public Lte4gRepository(ApplicationDbContext context) : base(context)
		{

		}

	}
}
