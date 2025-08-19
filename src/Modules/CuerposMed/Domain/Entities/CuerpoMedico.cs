using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;

namespace LigaBetPlay.src.Modules.CuerposMed.Domain.Entities;

public class CuerpoMedico
{
    
    public int Id { get; set; }
    public string? Name { get; set; } 
    public string? LastName { get; set; }
    public int Edad { get; set; }
    public string? Especialidad { get; set; }
    public int EquipoId { get; set; }
    public Team? Team { get; set; }
}
