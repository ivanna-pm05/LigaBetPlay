using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Transferencias.Domain.Entities;

namespace LigaBetPlay.src.Modules.Transferencias.Application.Interfaces
{
    public interface ITransferenciaRepository
    {
        Task<IEnumerable<Transferencia?>> GetAllAsync();
        Task AddAsync(Transferencia transferencia);
        Task SaveAsync();
    }
}