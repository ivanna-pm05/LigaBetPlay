using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Application.Interfaces;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;
using LigaBetPlay.src.Modules.Torneos.Application.Interfaces;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;

namespace LigaBetPlay.src.Modules.Teams.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _repo;
    private readonly ITorneoRepository _torneoRepository;
    public TeamService(ITeamRepository repo, ITorneoRepository torneoRepository)
    {
        _repo = repo;
        _torneoRepository = torneoRepository;
    }
    public async Task<IEnumerable<Team>> ConsultarTeamAsync()
    {
        return await _repo.GetAllAsync();
    }
    public async Task<Team?> ObtenerTeamPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
    public async Task RegistrarTeamConTareaAsync(string nombre, string tipo, string country)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(t => t.Name == nombre))
            throw new Exception("El equipo ya existe.");
        var team = new Team
        {
            Name = nombre,
            Type = tipo,
            Country = country
        };
        _repo.Add(team);
        await _repo.SaveAsync();
    }
    public async Task InscribirATorneoAsync(int equipoId, int torneoId)
    {
        var team = await _repo.GetByIdAsync(equipoId);
        if (team == null)
            throw new Exception("El equipo no existe.");

        var torneo = await _torneoRepository.GetByIdAsync(torneoId);
        if (torneo == null)
            throw new Exception("El torneo no existe.");
        team.Torneos ??= new List<Torneo>();
        if (!team.Torneos.Any(t => t.Id == torneoId))
        {
            team.Torneos.Add(torneo);
            await _repo.SaveAsync();
        }
        else
        {
            throw new Exception("El equipo ya está inscrito en este torneo.");
        }
    }

    public async Task SalirDeTorneoAsync(int equipoId, int torneoId)
    {
        var team = await _repo.GetByIdAsync(equipoId);
        if (team == null)
            throw new Exception("El equipo no existe.");

        var torneo = await _torneoRepository.GetByIdAsync(torneoId);
        if (torneo == null)
            throw new Exception("El torneo no existe.");

        if (team.Torneos != null && team.Torneos.Any(t => t.Id == torneoId))
        {
            var torneoAEliminar = team.Torneos.First(t => t.Id == torneoId);
            team.Torneos.Remove(torneoAEliminar);
            await _repo.SaveAsync();
        }
    }
}
