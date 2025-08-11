using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;

namespace LigaBetPlay.src.Modules.Teams.Application.Interfaces;

public interface ITeamService
{
    Task RegistrarTeamConTareaAsync(string nombre, string tipo);
    Task EditarTeam(int id, string nuevoNombre, string nuevoTipo);
    Task EliminarTeam(int id);
    Task<Team?> ObtenerTeamPorIdAsync(int id);
    Task<IEnumerable<Team>> ConsultarTeamAsync();
}
