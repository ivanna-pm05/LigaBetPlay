using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;

namespace LigaBetPlay.src.Modules.Torneos.Application.Interfaces;

public interface ITorneoService
{
    Task RegistrarTorneoConTareaAsync(string nombre, string type, string country, DateTime fechainicio, DateTime fechafin);
    Task ActualizarTorneo(int id, string nuevoNombre, string nuevoType, string nuevoCountry, DateTime nuevaFechainicio, DateTime NuevaFechafin);
    Task EliminarTorneo(int id);
    Task<Torneo?> ObtenerTorneoPorIdAsync(int id);
    Task<IEnumerable<Torneo>> ConsultarTorneoAsync();
    
}