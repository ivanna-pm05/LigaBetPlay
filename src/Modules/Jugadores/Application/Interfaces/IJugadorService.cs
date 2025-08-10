using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;

namespace LigaBetPLay.src.Modules.Jugadores.Application.Interfaces;

public interface IJugadorService
{
    Task RegistrarJugadorConTareaAsync(string nombre, string apellido, string dorsal, string position, string country);
    Task EditarJugador(int id, string nuevoNombre, string nuevoApellido, string nuevaDorsal, string nuevaPosition, string nuevoCountry);
    Task EliminarJugador(int id);
    Task<Jugador?> ObtenerJugadorPorIdAsync(int id);
    Task<IEnumerable<Jugador>> ConsultarJugadorAsync();
}
