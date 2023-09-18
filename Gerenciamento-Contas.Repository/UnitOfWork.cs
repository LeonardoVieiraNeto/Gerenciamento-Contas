using Gerenciamento.Contas.Models;
using Gerenciamento.Contas.Models.Interfaces;

namespace Gerenciamento.Contas.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContextClass _dbContext;
        
        public UnitOfWork(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
}
