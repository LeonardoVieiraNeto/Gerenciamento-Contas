using Gerenciamento.Contas.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento.Contas.Models.Interfaces;

public interface IUnitOfWork
{
    void Dispose();
    int Save();
}
