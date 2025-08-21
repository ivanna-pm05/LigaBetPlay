/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Transferencias.Application.Interfaces;
using LigaBetPlay.src.Modules.Transferencias.Domain.Entities;
using LigaBetPLay.src.Modules.Jugadores.Application.Interfaces;

namespace LigaBetPlay.src.Modules.Transferencias.Application.Services;

public class TransferenciaService : ITransferenciaService
{
    private readonly ITransferenciaRepository _transferenciarepo;
    private readonly IJugadorRepository _jugadorRepo;
    public TransfenciaService(ITransferenciaRepository transferenciarepo, IJugadorRepository jugadorRepo)
    {
        _transferenciarepo = transferenciarepo;
        _jugadorRepo = jugadorRepo;
    }
    public Task<IEnumerable<Transferencia>> ConsultarTransferenciasAsync()
    {
        return _transferenciarepo.GetAllAsync()!;
    }
       
    public async Task ComprarJugadorAsync(int jugadorId, int teamDestinoId)
    {
        var jugador = await _jugadorRepo.GetByIdAsync(jugadorId);
        if (jugador == null || !jugador.Disponible)
            throw new InvalidOperationException("Jugador no disponible para compra.");

        var transferencia = new Transferencia
        {
            JugadorId = jugador.Id,
            TeamOrigenId = jugador.TeamId ?? 0,
            TeamDestinoId = teamDestinoId,
            EsPrestamo = false
        };

        jugador.TeamId = teamDestinoId;
        jugador.Disponible = false;

        await _transferenciarepo.AddAsync(transferencia);
        await _transferenciarepo.SaveAsync();
        await _jugadorRepo.UpdateAsync(jugador);
        await _jugadorRepo.SaveAsync();
    }

    public async Task PrestarJugadorAsync(int jugadorId, int teamDestinoId)
    {
        var jugador = await _jugadorRepo.GetByIdAsync(jugadorId);
        if (jugador == null || !jugador.Disponible || jugador.TeamId == null)
            throw new InvalidOperationException("Jugador no disponible para préstamo.");

        var transferencia = new Transferencia
        {
            JugadorId = jugador.Id,
            TeamOrigenId = jugador.TeamId.Value,
            TeamDestinoId = teamDestinoId,
            EsPrestamo = true
        };

        jugador.TeamId = teamDestinoId; // préstamo temporal
        jugador.Disponible = false;

        await _transferenciarepo.AddAsync(transferencia);
        await _transferenciarepo.SaveAsync();
        await _jugadorRepo.UpdateAsync(jugador);
        await _jugadorRepo.SaveAsync(); 
    }
        
}
 */