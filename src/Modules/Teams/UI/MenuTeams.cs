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
                        Console.WriteLine("== Registrar Equipo ==");
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
                        Console.WriteLine("== Registrar Cuerpo Técnico ==");
                        var teamCT = await service.ConsultarTeamAsync();
                        Console.WriteLine("Equipos disponibles:");
                        foreach (var e in teamCT)
                            Console.WriteLine($"Id: {e.Id} - Nombre: {e.Name}");
                        Console.WriteLine("Ingrese el Id del equipo: ");
                        if (!int.TryParse(Console.ReadLine(), out int equipoId))
                        {
                            Console.WriteLine("Id inválido.");
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
                        await cuerpoTecnicoService.RegistrarCuerpoTecnicoConTareaAsync(nombreCT!, apellidoCT!, role!,countryCT!, equipoId);
                        Console.WriteLine("Cuerpo técnico registrado con éxito ✅.");
                        Console.ReadKey();
                        break;
                case 3:
                    Console.Clear();
                        Console.WriteLine("== Registrar Cuerpo Médico ==");
                        var equiposCM = await service.ConsultarTeamAsync();
                        Console.WriteLine("Equipos disponibles:");
                        foreach (var e in equiposCM)
                            Console.WriteLine($"Id: {e.Id} - Nombre: {e.Name}");
                        Console.WriteLine("Ingrese el Id del equipo: ");
                        if (!int.TryParse(Console.ReadLine(), out int equipoIdCM))
                        {
                            Console.WriteLine("Id inválido.");
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
                        await CuerpoMedService.RegistrarCuerpoMedicoAsync(nombreCM!, apellidoCM!, edadCM, especialidad!, equipoIdCM);
                        Console.WriteLine("✅ Cuerpo médico registrado con éxito.");
                        Console.ReadKey();
                        break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
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
