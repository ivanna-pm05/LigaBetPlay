using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaBetPLay.src.Modules.Jugadores.Domain.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Dorsal { get; set; }
        public string? Position { get; set; }
        public string? Country { get; set; }
    }
}