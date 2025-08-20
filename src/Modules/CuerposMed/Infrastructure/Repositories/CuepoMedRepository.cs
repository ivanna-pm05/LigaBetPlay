using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposMed.Application.Interfaces;
using LigaBetPlay.src.Modules.CuerposMed.Domain.Entities;
using LigaBetPlay.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace LigaBetPlay.src.Modules.CuerposMed.Infrastructure.Repositories
{
    public class CuepoMedRepository : ICuerpoMedRepository
    {
        private readonly AppDbContext _context;

        public CuepoMedRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CuerpoMedico?>> GetAllAsync() =>
            await _context.CuerposMedicos.ToListAsync();
        public async Task AddAsync(CuerpoMedico cuerpomedico)
        {
            await _context.CuerposMedicos.AddAsync(cuerpomedico);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}