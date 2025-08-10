using LigaBetPlay.src.Modules.Torneos.Application.Repositories;
using LigaBetPlay.src.Modules.Torneos.Application.Services;
using LigaBetPlay.src.Modules.Torneos.UI;
using LigaBetPlay.src.Shared.Helpers;
using LigaBetPLay.src.Modules.Jugadores.UI;

var context = DbContextFactory.Create();


bool salir = false;
while (!salir)
{
    Console.Clear();
     Console.WriteLine("""
            +====================================+
            | ⚜️   Administrador de Torneos   ⚜️|
            +====================================+
            | 1) Crear Torneo                    |
            | 2) Registro Equipos                |
            | 3) Registro Jugadores              |
            | 4) Transferencias                  |
            | 5) Estadisticas                    |
            | 6) Salir                           |
            +====================================+
            """);
    int opm = int.Parse(Console.ReadLine()!);

    switch (opm)
    {
        case 1:
            await new MenuTorneos(context).RenderMenu();
            break;
        case 2:
            break;
        case 3:
            await new MenuJugadores(context).RenderMenu();
            break;
        case 4:
            break;
        case 5:
            break;
        case 6:
            salir = true;
            break;
        default:
            Console.WriteLine("❗ Opción inválida.");
            break;
    }
}