using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay2025.src.Modules.Teams.Domain.Entities;
using LigaBetPlay.src.Shared.Context;

namespace LigaBetPlay2025.src.Modules.Teams.Application.Interfaces;

public interface ITeamService
{
    Task RegistrarTeamConTareaAsync(Team team);
    Task ActualizarTeam(int id, Team team);
    Task EliminarTeam(int id);
    Task<Team?> ObtenerTeamPorIdAsync(int id);
    Task<IEnumerable<Team?>> ConsultarTeamAsync();
}
