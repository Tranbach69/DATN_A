using DATN.Core.Entities;
using DATN.Infastructure.Persistence;
using DATN.Infastructure.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.GpsRepository
{
	public class GpsRepository : Repository<Gps>, IGpsRepository
	{
		public GpsRepository(ApplicationDbContext context) : base(context)
		{

		}
	
	}
}
