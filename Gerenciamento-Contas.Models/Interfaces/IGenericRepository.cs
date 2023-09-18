using System.Linq.Expressions;

namespace Gerenciamento.Contas.Models.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    Task<IQueryable<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
}