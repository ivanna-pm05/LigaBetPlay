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
            Console.Clear();
            Console.WriteLine("+====================================+");
            Console.WriteLine("|    🧔     Menu Jugadores     🧔   |");
            Console.WriteLine("+====================================+");
            Console.WriteLine("| 1) Registrar Jugador               |");
            Console.WriteLine("| 2) Buscar Jugador                  |");
            Console.WriteLine("| 3) Editar Jugador                  |");
            Console.WriteLine("| 4) Eliminar Jugador                |");
            Console.WriteLine("| 5) Regresar al Menu Principal      |");
            Console.WriteLine("+====================================+");
            Console.WriteLine();
            int opt = LeerEntero("Seleccione una Opción\n-> ");

            switch (opt)
            {
                case 1:
                    Console.Write("Nombre Jugador: ");
                    string? nombre = Console.ReadLine();
                    Console.Write("Apellido Jugador: ");
                    string? apellido = Console.ReadLine();
                    int dorsal = LeerEntero("Dorsal Jugador: ");
                    Console.Write("Posicion Jugador: ");
                    string? position = Console.ReadLine();
                    Console.Write("Pais Jugador: ");
                    string? country = Console.ReadLine();
                    await service.RegistrarJugadorConTareaAsync(nombre!, apellido!, dorsal.ToString(), position!, country!);
                    Console.Write("✅ Jugador Registrado.");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 2:
                    int id = LeerEntero("ID del jugador a buscar: ");
                    Jugador? jugador = await service.ObtenerJugadorPorIdAsync(id);
                    if (jugador != null)
                        Console.WriteLine($"👤 {jugador.Name} - {jugador.LastName} - {jugador.Dorsal} - {jugador.Position} - {jugador.Country}");
                    else
                        Console.WriteLine("❌ Jugador no encontrado.");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    int idUp = LeerEntero("ID a editar: ");
                    Console.Write("Nuevo Jugador: ");
                    string? nuevoName = Console.ReadLine();
                    Console.Write("Nuevo Apellido: ");
                    string? nuevoLastName = Console.ReadLine();
                    int nuevaDorsal = LeerEntero("Nueva Dorsal: ");
                    Console.Write("Nueva Posicion: ");
                    string? nuevaPosition = Console.ReadLine();
                    Console.Write("Nuevo Pais: ");
                    string? nuevoCountry = Console.ReadLine();
                    await service.EditarJugador(idUp, nuevoName!, nuevoLastName!, nuevaDorsal.ToString(), nuevaPosition!, nuevoCountry!);
                    Console.WriteLine("✏️ Editado.");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 4:
                    int idDel = LeerEntero("ID del Jugador a eliminar: ");
                    await service.EliminarJugador(idDel);
                    Console.WriteLine("🗑️ Jugador Eliminado.");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
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
