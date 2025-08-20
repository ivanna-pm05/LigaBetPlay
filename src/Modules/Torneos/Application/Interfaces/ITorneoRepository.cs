using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;

namespace LigaBetPlay.src.Modules.Torneos.Application.Interfaces;

public interface ITorneoRepository
{
    Task<Torneo?> GetByIdAsync(int id);
    Task<IEnumerable<Torneo?>> GetAllAsync();
    void Add(Torneo torneo);
    void Remove(Torneo torneo);
    void Update(Torneo torneo);
    Task SaveAsync(); 
}