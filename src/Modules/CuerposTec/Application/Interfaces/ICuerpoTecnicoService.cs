using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;

namespace LigaBetPlay.src.Modules.CuerposTec.Application.Interfaces;

public interface ICuerpoTecnicoService
{
    Task RegistrarCuerpoTecnicoConTareaAsync(string nombre, string apellido, string role, string country, int equipoId);
    Task<IEnumerable<CuerpoTecnico>> ConsultarCuerpoTecnicosAsync();
}
