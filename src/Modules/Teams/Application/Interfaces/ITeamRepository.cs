using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;

namespace LigaBetPlay.src.Modules.Teams.Application.Interfaces;

public interface ITeamRepository
{
    Task<Team?> GetByIdAsync(int id);
    Task<IEnumerable<Team?>> GetAllAsync();
    void Add(Team team);
    void Remove(Team team);
    void Update(Team team);
    Task SaveAsync();
    
}
