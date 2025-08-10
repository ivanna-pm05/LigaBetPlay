using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposTec.Application.Interfaces;
using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;


namespace LigaBetPlay.src.Modules.CuerposTec.Application.Services;

public class CuerpoTecnicoService : ICuerpoTecnicoService
{
    private readonly ICuerpoTecnicoRepository _cuerpotecRository;

    public CuerpoTecnicoService(ICuerpoTecnicoRepository cuerpotecRepository)
    {
        _cuerpotecRository = cuerpotecRepository;
    }

    public Task<IEnumerable<CuerpoTecnico>> ConsultarJugadorAsync()
    {
        return _cuerpotecRository.GetAllAsync();
    }
    public async Task RegistrarCuerpoTecnicoConTareaAsync(string nombre, string apellido, string dorsal, string role, string country)
    {
        var existentes = await _cuerpotecRository.GetAllAsync();
        if (existentes.Any(c => c.Name == nombre))
            throw new Exception("El Cuerpo Tecnico ya existe.");
        var Cuerpotec = new CuerpoTecnico
        {
            Name = nombre,
            LastName = apellido,
            Role = role,
            Country = country,
        };
        _cuerpotecRository.Add(Cuerpotec);
        _cuerpotecRository.Update(Cuerpotec);
    }

    public async Task EditarCuerpoTecnico(int id, string nuevoNombre, string nuevoApellido, string nuevaRole, string nuevoCountry)
    {
        var cuerpotec = await _cuerpotecRository.GetByIdAsync(id);
        if (cuerpotec == null)
            throw new Exception($"❌ Cuerpo Tecnico con ID {id} no encontrado.");
        cuerpotec.Name = nuevoNombre;
        cuerpotec.LastName = nuevoApellido;
        cuerpotec.Role = nuevaRole;
        cuerpotec.Country = nuevoCountry;

        _cuerpotecRository.Update(cuerpotec);
        await _cuerpotecRository.SaveAsync();
    }

    public async Task ElimnarCuerpoTecncio(int id)
    {
        var cuerpotec = await _cuerpotecRository.GetByIdAsync(id);
        if (cuerpotec == null)
            throw new Exception($"❌ Cuerpo Tecnico con ID {id} no encontrado.");
        _cuerpotecRository.Remove(cuerpotec);
        await _cuerpotecRository.SaveAsync();
    }

    public async Task<CuerpoTecnico?> ObtenerCuerpoTecnicoPorIdAsync(int id)
    {
        return await _cuerpotecRository.GetByIdAsync(id);
    }

    public Task RegistrarCuerpoTecnicoConTareaAsync(string nombre, string apellido, string role, string country)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CuerpoTecnico?>> ConsultarCuerpoTecnicosAsync()
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<CuerpoTecnico?>> VerCuerpoTecConTeam()
    {
        return await _cuerpotecRository.GetAllWithTeamAsync();
    }
}
