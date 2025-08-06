using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LigaBetPlay2025.src.Modules.Teams.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Type { get; set; }
    public string? Country { get; set; }
}
