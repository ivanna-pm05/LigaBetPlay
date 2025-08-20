using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposMed.Domain.Entities;
using LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;

namespace LigaBetPlay.src.Modules.Teams.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Type { get; set; } = string.Empty;
    public string? Country { get; set; } = string.Empty;
    public ICollection<Jugador>? jugadors { get; set; } = new HashSet<Jugador>();
    public ICollection<CuerpoMedico>? cuerpoMedicos { get; set; } = new HashSet<CuerpoMedico>();
    public ICollection<CuerpoTecnico>? CuerpoTecnicos { get; set; } = new HashSet<CuerpoTecnico>();
    public ICollection<Torneo> Torneos { get; set; } = new HashSet<Torneo>();
}