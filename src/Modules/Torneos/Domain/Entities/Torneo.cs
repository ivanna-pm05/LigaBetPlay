using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaBetPlay.src.Modules.Torneos.Domain.Entities;

public class Torneo
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Type { get; set; }
    public string? Country { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}