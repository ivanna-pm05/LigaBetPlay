using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Torneos.Application.Repositories;
using LigaBetPlay.src.Modules.Torneos.Application.Services;
using LigaBetPlay.src.Modules.Torneos.Domain.Entities;
using LigaBetPlay.src.Shared.Context;

namespace LigaBetPlay.src.Modules.Torneos.UI;

public class MenuTorneos
{
    private readonly AppDbContext _context;
    readonly TorneoRepository repo = null!;
    readonly TorneoService service = null!;
    public MenuTorneos(AppDbContext context)
    {
        _context = context;
        repo = new TorneoRepository(context);
        service = new TorneoService(repo);
    }
    public async Task RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("""
            +====================================+
            |     ⚽     Menu Torneos     ⚽     |
            +====================================+
            | 1) Add Torneo                      |
            | 2) Buscar Torneos                  |
            | 3) Eliminar Torneos                |
            | 4) Actualizar Torneos              |
            | 5) Regresar al Menu Principal      |
            +====================================+

            Seleccione una Opcion
            ->
            """);
            int op = int.Parse(Console.ReadLine()!);

            switch (op)
            {
                case 1:
                    Console.Write("Nombre Torneo: ");
                    string? nombre = Console.ReadLine();
                    Console.Write("Tipo de Torneo: ");
                    string? type = Console.ReadLine();
                    Console.Write("Pais: ");
                    string? country = Console.ReadLine();
                    Console.Write("Fecha de Inicio de Torneo: ");
                    string? fechainicio = Console.ReadLine();
                    Console.Write("Fecha de Fin de Torneo: ");
                    string? fechafin = Console.ReadLine();
                    await service.RegistrarTorneoConTareaAsync(nombre!, type!, country!, Convert.ToDateTime(fechainicio!), Convert.ToDateTime(fechafin!));
                    Console.Write("✅ Torneo creado.");
                    break;
                case 2:
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine()!);
                    Torneo? torneo = await service.ObtenerTorneoPorIdAsync(id);
                    if (torneo != null)
                        Console.WriteLine($"👤 {torneo.Name} - {torneo.Type} - {torneo.Country} - {torneo.FechaInicio} - {torneo.FechaFin}");
                    else
                        Console.WriteLine("❌ No encontrado.");
                    break;
                case 3:
                    Console.Write("ID a eliminar: ");
                    int idDel = int.Parse(Console.ReadLine()!);
                    await service.EliminarTorneo(idDel);
                    Console.WriteLine("🗑️ Eliminado.");
                    break;
                case 4:
                    Console.Write("ID a actualizar: ");
                    int idUp = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo Torneo: ");
                    string? nuevoName = Console.ReadLine();
                    Console.Write("Nuevo Tipo de Torneo: ");
                    string? nuevoType = Console.ReadLine();
                    Console.Write("Nuevo Pais: ");
                    string? nuevoCountry = Console.ReadLine();
                    Console.Write("Nueva Fecha de Inico Torneo: ");
                    string? nuevaFechaInicio = Console.ReadLine();
                    Console.Write("Nueva Fecha de Fin Torneo: ");
                    string? nuevaFechaFin = Console.ReadLine();
                    await service.ActualizarTorneo(idUp, nuevoName!, nuevoType!, nuevoCountry!, Convert.ToDateTime(nuevaFechaInicio!), Convert.ToDateTime(nuevaFechaFin!));
                    Console.WriteLine("✏️ Actualizado.");
                    break;
                case 5:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("❗ Opción inválida.");
                    break;
            }
        }
    }
}