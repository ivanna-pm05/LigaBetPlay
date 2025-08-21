using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Domain.Entities;

namespace LigaBetPLay.src.Modules.Jugadores.Domain.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Dorsal { get; set; }
        public string? Position { get; set; }
        public string? Country { get; set; }
        //public bool Disponible { get; set; } = true;
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}