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

    public async Task AddAsync(CuerpoTecnico cuerpotecnico)
    {
       await _context.CuerpoTec.AddAsync(cuerpotecnico);
    }

    public async Task<IEnumerable<CuerpoTecnico?>> GetAllAsync() =>
        await _context.CuerpoTec.ToListAsync();

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
