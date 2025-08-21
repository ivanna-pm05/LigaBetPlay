using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Transferencias.Application.Interfaces;
using LigaBetPlay.src.Modules.Transferencias.Domain.Entities;
using LigaBetPlay.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace LigaBetPlay.src.Modules.Transferencias.Infrastructure.Repositories;

public class TransferenciaRepository : ITransferenciaRepository
{
    private readonly AppDbContext _context;

    public TransferenciaRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Transferencia transferencia)
    {
        await _context.Transferencias.AddAsync(transferencia);
    }
    public async Task<IEnumerable<Transferencia?>> GetAllAsync() =>
        await _context.Transferencias.ToListAsync();
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
