using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Shared.Context;
using LigaBetPLay.src.Modules.Jugadores.Application.Interfaces;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LigaBetPLay.src.Modules.Jugadores.Infrastructure.Repositories;

public class JugadorRepository : IJugadorRepository
{
    private readonly AppDbContext _context;

    public JugadorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Jugador?> GetByIdAsync(int id)
    {
        return await _context.Jugadors
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Jugador?>> GetAllAsync() =>
        await _context.Jugadors.ToListAsync();

    public void Add(Jugador jugador) =>
        _context.Jugadors.Add(jugador);

    public void Remove(Jugador jugador) =>
        _context.Jugadors.Remove(jugador);

    public void Update(Jugador jugador) =>
        _context.SaveChanges();
    public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}
