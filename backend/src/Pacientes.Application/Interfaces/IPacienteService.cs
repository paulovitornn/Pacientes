using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pacientes.Domain;

namespace Pacientes.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> AddPacientes(Paciente model);
        Task<Paciente> UpdatePacientes(int PacienteId, Paciente model);
        Task<bool> DeletePacientes(int PacienteId);
        Task<Paciente[]> GetAllPacientesAsync();
        Task<Paciente[]> GetAllPacientesByCPFAsync(string cpf);
        Task<Paciente[]> GetAllPacientesByNomeAsync(string nome);
        Task<Paciente> GetAllPacientesByIdAsync(int id);
    }
}