using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;

namespace LigaBetPlay.src.Modules.CuerposTec.Application.Interfaces;

public interface ICuerpoTecnicoRepository
{
    Task<IEnumerable<CuerpoTecnico?>> GetAllAsync();
    Task AddAsync(CuerpoTecnico cuerpotecnico);
    Task SaveAsync();
}
