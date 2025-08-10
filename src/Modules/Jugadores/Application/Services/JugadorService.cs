using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPLay.src.Modules.Jugadores.Application.Interfaces;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;

namespace LigaBetPLay.src.Modules.Jugadores.Application.Services;

public class JugadorService : IJugadorService
{
    private readonly IJugadorRepository _repo;
    public JugadorService(IJugadorRepository repo)
    {
        _repo = repo;
    }
    public Task<IEnumerable<Jugador>> ConsultarJugadorAsync()
    {
        return _repo.GetAllAsync();
    }

    public async Task RegistrarJugadorConTareaAsync(string nombre, string apellido, string dorsal, string position, string country)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(j => j.Name == nombre))
            throw new Exception("El jugador ya existe.");
        var jugador = new Jugador
        {
            Name = nombre,
            LastName = apellido,
            Dorsal = dorsal,
            Position = position,
            Country = country,
        };

        _repo.Add(jugador);
        _repo.Update(jugador);
    }

    public async Task EditarJugador(int id, string nuevoNombre, string nuevoApellido, string nuevaDorsal, string nuevaPosition, string nuevoCountry)
    {
        var jugador = await _repo.GetByIdAsync(id);
        if (jugador == null)
            throw new Exception($"❌ Jugador con ID {id} no encontrado.");
        jugador.Name = nuevoNombre;
        jugador.LastName = nuevoApellido;
        jugador.Dorsal = nuevaDorsal;
        jugador.Position = nuevaPosition;
        jugador.Country = nuevoCountry;

        _repo.Update(jugador);
        await _repo.SaveAsync();
    }

    public async Task EliminarJugador(int id)
    {
        var jugador = await _repo.GetByIdAsync(id);
        if (jugador == null)
            throw new Exception($"❌ Jugador con ID {id} no encontrado.");
        _repo.Remove(jugador);
        await _repo.SaveAsync();
    }
    
    public async Task<Jugador?> ObtenerJugadorPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
}
