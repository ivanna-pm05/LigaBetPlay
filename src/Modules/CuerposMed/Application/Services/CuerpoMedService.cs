using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaBetPlay.src.Modules.CuerposMed.Application.Interfaces;
using LigaBetPlay.src.Modules.CuerposMed.Domain.Entities;

namespace LigaBetPlay.src.Modules.CuerposMed.Application.Services
{
    public class CuerpoMedService : ICuerpoMedService
    {
        private readonly ICuerpoMedRepository _repo;

        public CuerpoMedService(ICuerpoMedRepository repo)
        {
            _repo = repo;
        }
        public Task<IEnumerable<CuerpoMedico>> ConsultarCuerpoMedicoAsync()
        {
            return _repo.GetAllAsync()!;
        }
        public async Task RegistrarCuerpoMedicoAsync(string nombre, string apellido, int edad, string especialidad, int teamId)
        {
            var CuerpoMed = new CuerpoMedico
            {
                Name = nombre,
                LastName = apellido,
                Edad = edad,
                Especialidad = especialidad,
                TeamId = teamId
            };

            await _repo.AddAsync(CuerpoMed);
            await _repo.SaveAsync();
            
        }
    }
}