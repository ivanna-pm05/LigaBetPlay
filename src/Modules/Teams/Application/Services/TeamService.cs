using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposTec.Application.Interfaces;
using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;
using LigaBetPlay.src.Modules.Teams.Application.Interfaces;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;
using LigaBetPlay.src.Modules.Torneos.Application.Interfaces;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;

namespace LigaBetPlay.src.Modules.Teams.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _repo;
    private readonly ICuerpoTecnicoRepository _cuerpoTecRepo;
    private readonly ITorneoRepository _torneoRepo;
    public TeamService(ITeamRepository repo, ICuerpoTecnicoRepository cuerpoTecRepo, ITorneoRepository torneoRepo)
    {
        _repo = repo;
        _cuerpoTecRepo = cuerpoTecRepo;
        _torneoRepo = torneoRepo;
    }
    public Task<IEnumerable<Team>> ConsultarTeamAsync()
    {
        return _repo.GetAllAsync();
    }

    public async Task RegistrarTeamConTareaAsync(string nombre, string tipo)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(t => t.Name == nombre))
            throw new Exception("El equipo ya existe.");
        var team = new Team
        {
            Name = nombre,
            Type = tipo,
        };
        _repo.Add(team);
        _repo.Update(team);
    }
    public async Task EditarTeam(int id, string nuevoNombre, string nuevoTipo)
    {
        var team = await _repo.GetByIdAsync(id);
        if (team == null)
            throw new Exception($"❌ Equipo con ID {id} no encontrado.");
        team.Name = nuevoNombre;
        team.Type = nuevoTipo;

        _repo.Update(team);
        await _repo.SaveAsync();
    }

    public async Task EliminarTeam(int id)
    {
        var team = await _repo.GetByIdAsync(id);
        if (team == null)
            throw new Exception($"❌ Equipo con ID {id} no encontrado.");
        _repo.Remove(team);
        await _repo.SaveAsync();
    }
    public async Task<Team?> ObtenerTeamPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    Task ITeamService.RegistrarTeamConTareaAsync(string nombre, string tipo)
    {
        return RegistrarTeamConTareaAsync(nombre, tipo);
    }

    public async Task AsignarCuerpoTecnicoAsync(int teamId, CuerpoTecnico tecnico)
    {
        var team = await _repo.GetByIdWithCuerpoTecnicosAsync(teamId);
        if (team == null)
            throw new Exception($"Equipo con ID {teamId} no encontrado.");

        if (team.CuerpoTecnicos == null)
            team.CuerpoTecnicos = new List<CuerpoTecnico>();

        team.CuerpoTecnicos.Add(tecnico);
        await _repo.SaveAsync();
    }
    public async Task AsignarTorneoAsync(int teamId, Torneo torneo)
    {
        var team = await _repo.GetByIdAsync(teamId);
        if (team == null)
            throw new Exception($"Equipo con ID {teamId} no encontrado.");

        if (team.Torneos == null)
            team.Torneos = new List<Torneo>();

        team.Torneos.Add(torneo);
        await _repo.SaveAsync();
    }
}
