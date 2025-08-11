using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Shared.Context;

namespace LigaBetPlay.src.Modules.Teams.UI;

public class MenuTeams
{
    public async Task RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("+====================================+");
            Console.WriteLine("|             Menu Equipos           |");
            Console.WriteLine("+====================================+");
            Console.WriteLine("| 1) Registrar Equipo                |");
            Console.WriteLine("| 2) Registrar Cuerpo Tecnico        |");
            Console.WriteLine("| 3) Registrar Cuerpo Medico         |");
            Console.WriteLine("| 4) Inscripcion Torneo              |");
            Console.WriteLine("| 5) Notificacion de Transferencia   |");
            Console.WriteLine("| 6) Salir de Torneo                 |");
            Console.WriteLine("| 7) Salir al Menu Principal         |");
            Console.WriteLine("+====================================+");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opción");
        }
    }
}
