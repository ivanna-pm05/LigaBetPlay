using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;

namespace LigaBetPlay.src.Modules.CuerposTec.Domain.Entities;

public class CuerpoTecnico
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public int Edad { get; set; }
    public string? Role { get; set; }
    public string? Country { get; set; }
    public int TeamId { get; set; }
    public Team? Teams { get; set; }
}
