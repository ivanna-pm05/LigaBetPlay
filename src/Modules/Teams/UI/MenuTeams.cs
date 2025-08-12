using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.Teams.Application.Interfaces;
using LigaBetPlay.src.Modules.Teams.Application.Services;
using LigaBetPlay.src.Shared.Context;

namespace LigaBetPlay.src.Modules.Teams.UI;

public class MenuTeams
{
    private readonly AppDbContext _context;

        public MenuTeams(AppDbContext context)
        {
            _context = context;
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
                    Console.Write("Nombre del equipo: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Tipo de equipo: ");
                    string tipo = Console.ReadLine();
                    try
                    {
                        await ITeamService.RegistrarTeamConTareaAsync(nombre);
                        Console.WriteLine("✅ Equipo registrado.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error: {ex.Message}");
                    }
                    Console.ReadKey();
                    break;
                case 4:
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
