using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;

namespace LigaBetPLay.src.Modules.Jugadores.Application.Interfaces
{
    public interface IJugadorRepository
    {
        Task<Jugador?> GetByIdAsync(int id);
        Task<IEnumerable<Jugador?>> GetAllAsync();
        void Add(Jugador jugador);
        void Remove(Jugador jugador);
        void Update(Jugador jugador);
        Task SaveAsync();
    }
}