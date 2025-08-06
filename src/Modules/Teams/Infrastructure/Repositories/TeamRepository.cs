using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay2025.src.Modules.Teams.Application.Interfaces;
using LigaBetPlay2025.src.Modules.Teams.Domain.Entities;
using LigaBetPlay.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace LigaBetPlay2025.src.Modules.Teams.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Team team)
    {
        _context.Teams.Add(team);
    }

    public async Task<IEnumerable<Team?>> GetAllAsync() =>
        await _context.Teams.ToListAsync();


    public async Task<Team?> GetByIdAsync(int id)
    {
        return await _context.Teams.FirstOrDefaultAsync(u => u.Id == id);
    }

    public void Remove(Team team)
    {
        _context.Teams.Remove(team);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();
    
    public void Update(Team team) =>
        _context.SaveChanges();
    
}
