using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposMed.Domain.Entities;

namespace LigaBetPlay.src.Modules.CuerposMed.Application.Interfaces
{
    public interface ICuerpoMedRepository
    {
        Task<IEnumerable<CuerpoMedico?>> GetAllAsync();
        Task AddAsync(CuerpoMedico cuerpomedico);
        Task SaveAsync();
    }
}