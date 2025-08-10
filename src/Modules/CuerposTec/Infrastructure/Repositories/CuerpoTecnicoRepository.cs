using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposTec.Application.Interfaces;
using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;
using LigaBetPlay.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace LigaBetPlay.src.Modules.CuerposTec.Infrastructure.Repositories;

public class CuerpoTecnicoRepository : ICuerpoTecnicoRepository
{
    private readonly AppDbContext _context;

    public CuerpoTecnicoRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(CuerpoTecnico cuerpotecnico)
    {
        _context.CuerpoTec.Add(cuerpotecnico);
    }

    public async Task<IEnumerable<CuerpoTecnico?>> GetAllAsync() =>
        await _context.CuerpoTec.ToListAsync();


    public async Task<CuerpoTecnico?> GetByIdAsync(int id)
    {
        return await _context.CuerpoTec.FirstOrDefaultAsync(c => c.Id == id);

    }

    public void Remove(CuerpoTecnico cuerpotecnico)
    {
        _context.CuerpoTec.Remove(cuerpotecnico);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public void Update(CuerpoTecnico cuerpotecnico) =>
        _context.SaveChanges();
    
    public async Task<IEnumerable<CuerpoTecnico?>> GetAllWithTeamAsync() =>
        await _context.CuerpoTec.AsNoTracking()
            .Include(c => c.Teams)
            .ToListAsync();
}
