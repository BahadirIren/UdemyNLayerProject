using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Core.Repositories
{
    // Generic olacak o yuzden TEntity
    // model ve entity ayni sey
    public interface IRepository<TEntity> where TEntity : class
        // TEntity mutlaka class olmak zorunda (where sorgusu ile)
    {
        // id ye gore urun cekme
        Task<TEntity> GetByIdAsync(int id);

        // tumunu getir
        Task<IEnumerable<TEntity>> GetAllAsync();

        // where(x=>x.id=23)
        // function olacak, donus tipi bool olacak
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        // category.SingleOrDefaultAsync(x=>x.name="kalem")
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        // bir entity nin eklenmesi
        Task<TEntity> AddAsync(TEntity entity);

        // toplu kayit
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        // urunu silme
        void Remove(TEntity entity);

        // birden fazla kayit silme
        void RemoveRange(IEnumerable<TEntity> entities);

        // update
        TEntity Update(TEntity entity);


    }
}
