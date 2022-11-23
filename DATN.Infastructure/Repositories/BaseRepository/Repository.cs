using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DATN.Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DATN.Infastructure.Repositories.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        #region add
        public async Task<T> BAddAsync(T entity)
        {
            entity.TimingCreate = System.DateTime.Now;
            entity.IsDeleted = false;
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        #endregion

        #region delete
        public async Task BDeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task BDeleteByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task BDeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var listExist = _context.Set<T>().Where(a => a.IsDeleted == false);
            var listWithCondition = await listExist.Where(predicate).ToListAsync();
            foreach (var item in listWithCondition)
            {
                item.IsDeleted = true;
                _context.Entry(item).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
        #endregion

        #region update
        public async Task BUpdateAsync(T entity)
        {
            entity.TimingUpdate = System.DateTime.Now;
            entity.IsDeleted = false;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task BUpdateByIdAsync(int id)
        {
            //var entity.TimingUpdate = System.DateTime.Now;
            //entity.IsDeleted = false;
            //_context.Entry(entity).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }
        #endregion

        #region get
        public async Task<T> BFistOrDefaultAsync(Func<T, bool> predicate)
        {
            var listUseCondition = _context.Set<T>().Where(a => a.IsDeleted == false);
            if (!listUseCondition.Any())
            {
                return null;
            }

            var listExist = await listUseCondition.ToListAsync();
            return listExist.FirstOrDefault(predicate);
        }
        public async Task<T> BFistOrDefaultAsync()
        {
            var listUseCondition = (IQueryable<T>)_context.Set<T>().Where(a => a.IsDeleted == false);
            if (!listUseCondition.Any())
            {
                return null;
            }
            var listExist = await listUseCondition.ToListAsync();
            return listExist.First();
        }
        public async Task<IReadOnlyList<T>> BGetAllAsync()
        {
            return await _context.Set<T>().Where(a => a.IsDeleted == false).ToListAsync();
        }
        public async Task<IReadOnlyList<T>> BGetPagingAsync(int skip, int pageSize)
        {
            return await _context.Set<T>().Where(a => a.IsDeleted == false).Skip(skip).Take(pageSize).ToListAsync();
        }
        public async Task<IReadOnlyList<T>> BGetAsync(Func<T, bool> predicate)
        {
            var listExist = await _context.Set<T>().Where(a => a.IsDeleted == false).ToListAsync();
            return listExist.Where(predicate).ToList();
        }
        public async Task<int> BGetTotalAsync()
        {
            return await _context.Set<T>().Where(a => a.IsDeleted == false).CountAsync();
        }
        public async Task<T> BGetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(t => t.Id.Equals(id));
            _context.Entry(entity).State = EntityState.Detached;
            if (entity?.IsDeleted == true)
            {
                return null;
            }
            return entity;
        }
        #endregion
    }
}
