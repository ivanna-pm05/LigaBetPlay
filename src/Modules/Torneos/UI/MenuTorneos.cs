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
            Console.Clear();
            Console.WriteLine("+====================================+");
            Console.WriteLine("|     ⚽     Menu Torneos     ⚽    |");
            Console.WriteLine("+====================================+");
            Console.WriteLine("| 1) Add Torneo                      |");
            Console.WriteLine("| 2) Buscar Torneos                  |");
            Console.WriteLine("| 3) Eliminar Torneos                |");
            Console.WriteLine("| 4) Editar Torneos                  |");
            Console.WriteLine("| 5) Regresar al Menu Principal      |");
            Console.WriteLine("+====================================+");
            Console.WriteLine();
            int op = LeerEntero("Seleccione una Opción\n-> ");

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
                    int id = LeerEntero("ID a Buscar: ");
                    Torneo? torneo = await service.ObtenerTorneoPorIdAsync(id);
                    if (torneo != null)
                        Console.WriteLine($"👤 {torneo.Name} - {torneo.Type} - {torneo.Country} - {torneo.FechaInicio:dd/MM/yyyy} - {torneo.FechaFin:dd/MM/yyyy}");
                    else
                        Console.WriteLine("❌Torneo No encontrado.");
                    break;
                case 3:
                    int idDel = LeerEntero("ID a eliminar: ");
                    await service.EliminarTorneo(idDel);
                    Console.WriteLine("🗑️ Eliminado.");
                    break;
                case 4:
                    int idUp = LeerEntero("ID a editar: ");
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
    private int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.WriteLine(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor))
                return valor;

            Console.WriteLine("⚠️ Ingrese un número válido.");
        }
    }
}