using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Shared.Context;
using LigaBetPLay.src.Modules.Jugadores.Application.Services;
using LigaBetPLay.src.Modules.Jugadores.Domain.Entities;
using LigaBetPLay.src.Modules.Jugadores.Infrastructure.Repositories;

namespace LigaBetPLay.src.Modules.Jugadores.UI;

public class MenuJugadores
{
    private readonly AppDbContext _context;
    readonly JugadorRepository repo = null!;
    readonly JugadorService service = null!;
    public MenuJugadores(AppDbContext context)
    {
        _context = context;
        repo = new JugadorRepository(context);
        service = new JugadorService(repo);
    }
    public async Task RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("""
            +====================================+
            |    🧔‍♂️     Menu Jugadores     🧔‍♂️    |
            +====================================+
            | 1) Registrar Jugador               |
            | 2) Buscar Jugador                  |
            | 3) Editar Jugador                  |
            | 4) Eliminar Jugador                |
            | 5) Regresar al Menu Principal      |
            +====================================+

            Seleccione una Opcion
            ->
            """);
            int opt = int.Parse(Console.ReadLine()!);

            switch (opt)
            {
                case 1:
                    Console.Write("Nombre Jugador: ");
                    string? nombre = Console.ReadLine();
                    Console.Write("Apellido Jugador: ");
                    string? apellido = Console.ReadLine();
                    Console.Write("Dorsal Jugador: ");
                    string? dorsal = Console.ReadLine();
                    Console.Write("Posicion Jugador: ");
                    string? position = Console.ReadLine();
                    Console.Write("Pais Jugador: ");
                    string? country = Console.ReadLine();
                    await service.RegistrarJugadorConTareaAsync(nombre!, apellido!, dorsal!, position!, country!);
                    Console.Write("✅ JUgador Registrado.");
                    break;
                case 2:
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine()!);
                    Jugador? jugador = await service.ObtenerJugadorPorIdAsync(id);
                    if (jugador != null)
                        Console.WriteLine($"👤 {jugador.Name} - {jugador.LastName} - {jugador.Dorsal} - {jugador.Position} - {jugador.Country}");
                    else
                        Console.WriteLine("❌ Jugador no encontrado.");
                    break;
                case 3:
                    Console.Write("ID a Editar: ");
                    int idUp = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo Jugador: ");
                    string? nuevoName = Console.ReadLine();
                    Console.Write("Nuevo Apellido: ");
                    string? nuevoLastName = Console.ReadLine();
                    Console.Write("Nueva Dorsal: ");
                    string? nuevaDorsal = Console.ReadLine();
                    Console.Write("Nueva Posicion: ");
                    string? nuevaPosition = Console.ReadLine();
                    Console.Write("Nuevo Pais: ");
                    string? nuevoCountry = Console.ReadLine();
                    await service.EditarJugador(idUp, nuevoName!, nuevoLastName!, nuevaDorsal!, nuevaPosition!, nuevoCountry!);
                    Console.WriteLine("✏️ Editado.");
                    break;
                case 4:
                    Console.Write("ID del JUgador a eliminar: ");
                    int idDel = int.Parse(Console.ReadLine()!);
                    await service.EliminarJugador(idDel);
                    Console.WriteLine("🗑️ Jugador Eliminado.");
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
