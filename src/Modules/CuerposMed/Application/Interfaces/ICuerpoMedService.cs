using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposMed.Domain.Entities;

namespace LigaBetPlay.src.Modules.CuerposMed.Application.Interfaces
{
    public interface ICuerpoMedService
    {
        Task<IEnumerable<CuerpoMedico>> ConsultarCuerpoMedicoAsync();
        Task RegistrarCuerpoMedicoAsync(string nombre, string apellido, int edad, string especialidad, int teamId);
    }
}