using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;

namespace LigaBetPlay.src.Modules.CuerposTec.Application.Interfaces;

public interface ICuerpoTecnicoRepository
{
    Task<CuerpoTecnico?> GetByIdAsync(int id);
    Task<IEnumerable<CuerpoTecnico?>> GetAllAsync();
    void Add(CuerpoTecnico cuerpotecnico);
    void Remove(CuerpoTecnico cuerpotecnico);
    void Update(CuerpoTecnico cuerpotecnico);
    Task SaveAsync();
    Task<IEnumerable<CuerpoTecnico?>> GetAllWithTeamAsync();
}
