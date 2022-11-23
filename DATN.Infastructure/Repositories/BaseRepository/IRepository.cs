using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Repositories.BaseRepository
{
    public interface IRepository<T> where T : Base
    {
        #region add
        Task<T> BAddAsync(T entity);
        #endregion

        #region delete
        Task BDeleteAsync(T entity);
        Task BDeleteByIdAsync(int id);
        Task BDeleteAsync(Expression<Func<T, bool>> predicate);
        #endregion

        #region update
        Task BUpdateAsync(T entity);
        Task BUpdateByIdAsync(int id);
        #endregion

        #region get
        Task<T> BFistOrDefaultAsync(Func<T, bool> predicate);
        Task<T> BFistOrDefaultAsync();
        Task<IReadOnlyList<T>> BGetAllAsync();
        Task<IReadOnlyList<T>> BGetPagingAsync(int skip, int pageSize);
        Task<IReadOnlyList<T>> BGetAsync(Func<T, bool> predicate);
        Task<int> BGetTotalAsync();
        Task<T> BGetByIdAsync(int id);
        #endregion

    }
}
