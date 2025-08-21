/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Transferencias.Domain.Entities;

namespace LigaBetPlay.src.Modules.Transferencias.Application.Interfaces
{
    public interface ITransferenciaService
    {
        Task<IEnumerable<Transferencia>> ConsultarTransferenciasAsync();
        Task ComprarJugadorAsync(int jugadorId, int teamDestinoId);
        Task PrestarJugadorAsync(int jugadorId, int teamDestinoId);
    }
} */