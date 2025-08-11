using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Application.Interfaces;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;

namespace LigaBetPlay.src.Modules.Teams.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _repo;
    public TeamService(ITeamRepository repo)
    {
        _repo = repo;
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
}
