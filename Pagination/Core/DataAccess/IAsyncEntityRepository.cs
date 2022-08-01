using Core.Dto;
using Core.Entity;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IAsyncEntityRepository<TEntity, TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        Task<TEntity> AddAsync(TDto entity);
        Task<TEntity> UpdateAsync(int id, TDto entity);
        Task DeleteAsync(int id);

        Task<TDto> GetAsync(Expression<Func<TDto, bool>> predicate);
        Task<IEnumerable<TDto>> GetListAsync();
        Task<IEnumerable<TDto>> GetListAsync(Expression<Func<TDto, bool>> predicate);
    }
}
