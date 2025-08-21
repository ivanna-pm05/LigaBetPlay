/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;

namespace LigaBetPlay.src.Modules.Transferencias.Domain.Entities;

public class Transferencia
{
    public int Id { get; set; }
    public int JugadorId { get; set; }
    public Jugador? Jugador { get; set; }
    public int TeamOrigenId { get; set; }
    public Team? TeamOrigen { get; set; }
    public int TeamDestinoId { get; set; }
    public Team? TeamDestino { get; set; }
    public bool EsPrestamo { get; set; } // true = préstamo, false = compra
    public DateTime Fecha { get; set; } = DateTime.Now;
}
 */