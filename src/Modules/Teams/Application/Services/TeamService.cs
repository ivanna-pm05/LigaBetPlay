using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay2025.src.Modules.Teams.Application.Interfaces;
using LigaBetPlay2025.src.Modules.Teams.Domain.Entities;
using LigaBetPlay.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace LigaBetPlay2025.src.Modules.Teams.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task RegistrarTeamConTareaAsync(Team team)
    {
        _teamRepository.Add(team);
        await _teamRepository.SaveAsync();
    }

    public async Task ActualizarTeam(int id, Team team)
    {
        var existingTeam = await _teamRepository.GetByIdAsync(id);
        if (existingTeam != null)
        {
            existingTeam.Name = team.Name;
            _teamRepository.Update(existingTeam);
            await _teamRepository.SaveAsync();
        }
    }

    public async Task EliminarTeam(int id)
    {
        var team = await _teamRepository.GetByIdAsync(id);
        if (team != null)
        {
            _teamRepository.Remove(team);
            await _teamRepository.SaveAsync();
        }
    }

    public async Task<IEnumerable<Team?>> ConsultarTeamAsync()
    {
        return await _teamRepository.GetAllAsync();
    }

    public Task<Team?> ObtenerTeamPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
