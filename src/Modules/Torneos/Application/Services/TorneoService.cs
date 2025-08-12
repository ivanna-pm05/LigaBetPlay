using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Torneos.Application.Interfaces;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;

namespace LigaBetPlay.src.Modules.Torneos.Application.Services;

public class TorneoService : ITorneoService
{
    private readonly ITorneoRepository _repo;
    public TorneoService(ITorneoRepository repo)
    {
        _repo = repo;
    }
    public Task<IEnumerable<Torneo>> ConsultarTorneoAsync()
    {
        return _repo.GetAllAsync();
    }

    public async Task RegistrarTorneoConTareaAsync(string nombre, string type, string country, DateTime fechainicio, DateTime fechafin)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(u => u.Name == nombre))
            throw new Exception("El torneo ya existe.");
        var torneo = new Torneo
        {
            Name = nombre,
            Type = type,
            Country = country,
            FechaInicio = fechainicio,
            FechaFin = fechafin,
        };

        _repo.Add(torneo);
        _repo.Update(torneo);
    }
    public async Task ActualizarTorneo(int id, string nuevoNombre, string nuevoType, string nuevoCountry, DateTime nuevaFechaInicio, DateTime nuevaFechaFin)
    {
        var torneo = await _repo.GetByIdAsync(id);
        if (torneo == null)
            throw new Exception($"❌ Torneo con ID {id} no encontrado.");
        torneo.Name = nuevoNombre;
        torneo.Type = nuevoType;
        torneo.Country = nuevoCountry;
        torneo.FechaInicio = nuevaFechaInicio;
        torneo.FechaFin = nuevaFechaFin;

        _repo.Update(torneo);
        await _repo.SaveAsync();
    }

    public async Task EliminarTorneo(int id)
    {
        var torneo = await _repo.GetByIdAsync(id);
        if (torneo == null)
            throw new Exception($"❌ Torneo con ID {id} no encontrado.");
        _repo.Remove(torneo);
        await _repo.SaveAsync();
    }
    public async Task<Torneo?> ObtenerTorneoPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
    
}