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

    public Task<IEnumerable<CuerpoTecnico>> ConsultarCuerpoTecnicosAsync()
    {
        return _cuerpotecRository.GetAllAsync()!;
    }
    public async Task RegistrarCuerpoTecnicoConTareaAsync(string nombre, string apellido,  string role, string country, int teamId)
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
            TeamId = teamId
        };
        await _cuerpotecRository.AddAsync(Cuerpotec);
        await _cuerpotecRository.SaveAsync();
    }
}
