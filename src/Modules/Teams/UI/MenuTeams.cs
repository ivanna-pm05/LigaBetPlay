using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposMed.Application.Services;
using LigaBetPlay.src.Modules.CuerposMed.Infrastructure.Repositories;
using LigaBetPlay.src.Modules.CuerposTec.Application.Services;
using LigaBetPlay.src.Modules.CuerposTec.Infrastructure.Repositories;
using LigaBetPlay.src.Modules.Teams.Application.Interfaces;
using LigaBetPlay.src.Modules.Teams.Application.Services;
using LigaBetPlay.src.Modules.Teams.Infrastructure.Repositories;
using LigaBetPlay.src.Modules.Torneos.Application.Repositories;
using LigaBetPlay.src.Modules.Torneos.Application.Services;
using LigaBetPlay.src.Shared.Context;

namespace LigaBetPlay.src.Modules.Teams.UI;

public class MenuTeams
{
    private readonly AppDbContext _context;
    readonly TeamRepository repo = null!;
    readonly TorneoRepository torneoRepository = null!;
    readonly CuepoMedRepository cuepoMedRepository = null!;
    readonly CuerpoTecnicoRepository cuerpoTecnicoRepository = null!;
    readonly TeamService service = null!;
    private readonly TorneoService torneoService;
    private readonly CuerpoTecnicoService cuerpoTecnicoService;
    private readonly CuerpoMedService cuerpoMedService;
    public MenuTeams(AppDbContext context)
    {
        _context = context;
        repo = new TeamRepository(context);
        torneoRepository = new TorneoRepository(context);
        cuepoMedRepository = new CuepoMedRepository(context);
        cuerpoTecnicoRepository = new CuerpoTecnicoRepository(context);
        service = new TeamService(repo, torneoRepository);
        torneoService = new TorneoService(torneoRepository);
        cuerpoTecnicoService = new CuerpoTecnicoService(cuerpoTecnicoRepository);
        cuerpoMedService = new CuerpoMedService(cuepoMedRepository);
    }
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
            int opc = LeerEntero("-> ");

            switch (opc)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("+====================+");
                    Console.WriteLine("|  Registrar Equipo  |");
                    Console.WriteLine("+====================+");
                    Console.WriteLine("Ingrese el nombre del equipo: ");
                    string? nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el tipo de equipo (Selección/Local):");
                    string? tipo = Console.ReadLine();
                    Console.Write("Ingrese el país de origen del equipo: ");
                    string? country = Console.ReadLine();
                    await service.RegistrarTeamConTareaAsync(nombre!, tipo!, country!);
                    Console.WriteLine("Equipo registrado con éxito ✅.");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("+============================+");
                    Console.WriteLine("|  Registrar Cuerpo Técnico  |");
                    Console.WriteLine("+============================+");
                    var teamCT = await service.ConsultarTeamAsync();
                    Console.WriteLine("Equipos disponibles:");
                    foreach (var e in teamCT)
                        Console.WriteLine($"Id: {e.Id} - Nombre: {e.Name}");
                    Console.WriteLine("Ingrese el Id del equipo: ");
                    if (!int.TryParse(Console.ReadLine(), out int equipoIdCT))
                    {
                        Console.WriteLine("❌ Id inválido.");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Ingrese el nombre: ");
                    string? nombreCT = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido: ");
                    string? apellidoCT = Console.ReadLine();
                    Console.WriteLine("Ingrese el rol: ");
                    string? role = Console.ReadLine();
                    Console.Write("Ingrese el país de origen del equipo: ");
                    string? countryCT = Console.ReadLine();
                    await cuerpoTecnicoService.RegistrarCuerpoTecnicoConTareaAsync(nombreCT!, apellidoCT!, role!,countryCT!, equipoIdCT);
                    Console.WriteLine("Cuerpo técnico registrado con éxito ✅.");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("+============================+");
                    Console.WriteLine("|  Registrar Cuerpo Médico   |");
                    Console.WriteLine("+============================+");
                    var equiposCM = await service.ConsultarTeamAsync();
                    Console.WriteLine("Equipos disponibles:");
                    foreach (var e in equiposCM)
                        Console.WriteLine($"Id: {e.Id} - Nombre: {e.Name}");
                    Console.WriteLine("Ingrese el Id del equipo: ");
                    if (!int.TryParse(Console.ReadLine(), out int TeamIdCM))
                    {
                        Console.WriteLine("❌ Id inválido.");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Ingrese el nombre: ");
                    string? nombreCM = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido: ");
                    string? apellidoCM = Console.ReadLine();
                    int edadCM = LeerEntero("Ingrese la edad:");
                    Console.WriteLine("Ingrese el cargo: ");
                    string? especialidad = Console.ReadLine();
                    await cuerpoMedService.RegistrarCuerpoMedicoAsync(nombreCM!, apellidoCM!, edadCM, especialidad!, TeamIdCM);
                    Console.WriteLine("✅ Cuerpo médico registrado con éxito.");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("+============================+");
                    Console.WriteLine("| Inscribir Equipo a Torneo  |");
                    Console.WriteLine("+============================+");
                    var teams = await service.ConsultarTeamAsync();
                    Console.WriteLine("Equipos disponibles:");
                    foreach (var e in teams)
                    {
                        Console.WriteLine($"Id: {e.Id} - Nombre: {e.Name}");
                    }
                    Console.WriteLine("Ingrese el Id del equipo a inscribir: ");
                    if (!int.TryParse(Console.ReadLine(), out int equipoId))
                    {
                        Console.WriteLine("❌Id inválido.");
                        Console.ReadKey();
                        break;
                    }
                    var torneos = await torneoService.ConsultarTorneoAsync();
                    Console.WriteLine("Torneos disponibles:");
                    foreach (var t in torneos)
                    {
                        Console.WriteLine($"Id: {t.Id} - Nombre: {t.Name}");
                    }
                    Console.Write("Ingrese el Id del torneo al cual inscribir al equipo: ");
                    if (!int.TryParse(Console.ReadLine(), out int torneoId))
                    {
                        Console.WriteLine("❌ Id inválido.");
                        Console.ReadKey();
                        break;
                    }
                    await service.InscribirATorneoAsync(equipoId, torneoId);
                    Console.WriteLine("Equipo inscrito al torneo con éxito✅.");
                    Console.ReadKey();
                    break;
                case 5:
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("+=================+");
                    Console.WriteLine("| Salir de Torneo |");
                    Console.WriteLine("+=================+");
                    teams = await service.ConsultarTeamAsync();
                    Console.WriteLine("Equipos disponibles:");
                    foreach (var e in teams)
                    {
                        Console.WriteLine($"Id: {e.Id} - Nombre: {e.Name}");
                    }
                    Console.Write("Ingrese el Id del equipo que desea retirar del torneo: ");
                    if (!int.TryParse(Console.ReadLine(), out equipoId))
                    {
                        Console.WriteLine("❌ Id inválido.");
                        Console.ReadKey();
                        break;
                    }
                    torneos = await torneoService.ConsultarTorneoAsync();
                    Console.WriteLine("Torneos disponibles:");
                    foreach (var t in torneos)
                    {
                        Console.WriteLine($"Id: {t.Id} - Nombre: {t.Name}");
                    }
                    Console.Write("Ingrese el Id del torneo del cual desea retirar al equipo: ");
                    if (!int.TryParse(Console.ReadLine(), out torneoId))
                    {
                        Console.WriteLine("❌ Id inválido.");
                        Console.ReadKey();
                        break;
                    }
                    await service.SalirDeTorneoAsync(equipoId, torneoId);
                    Console.WriteLine("Equipo retirado del torneo con éxito✅.");
                    Console.ReadKey();
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("👋Adios...");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("⚠️ Opción inválida.");
                    Console.ReadKey();
                    break;
            }

        }
    }
    private int LeerEntero(string mensaje)
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
