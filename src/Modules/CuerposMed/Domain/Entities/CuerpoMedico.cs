using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;

namespace LigaBetPlay.src.Modules.CuerposMed.Domain.Entities;

public class CuerpoMedico
{
    
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public int Edad { get; set; }
    public string? Especialidad { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}
