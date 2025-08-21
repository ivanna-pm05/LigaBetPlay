using LigaBetPlay.src.Modules.Teams.UI;
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
    Console.WriteLine("+====================================+");
    Console.WriteLine("| ⚜️   Administrador de Torneos   ⚜️   |");
    Console.WriteLine("+====================================+");
    Console.WriteLine("| 1) Crear Torneo                    |");
    Console.WriteLine("| 2) Registro Equipos                |");
    Console.WriteLine("| 3) Registro Jugadores              |");
    Console.WriteLine("| 4) Transferencias                  |");
    Console.WriteLine("| 5) Estadisticas                    |");
    Console.WriteLine("| 6) Salir                           |");
    Console.WriteLine("+====================================+");
    Console.WriteLine();
    Console.WriteLine("Seleccione una opción");
    int opm = LeerEntero("-> ");

    switch (opm)
    {
        case 1:
            await new MenuTorneos(context).RenderMenu();
            break;
        case 2:
            await new MenuTeams(context).RenderMenu();
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
    int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje + " "); 
        if (int.TryParse(Console.ReadLine(), out valor))
            return valor;

        Console.WriteLine("⚠️ Ingrese un número válido.");
        }
    }
}