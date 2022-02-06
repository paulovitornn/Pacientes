using System;
using System.Threading.Tasks;
using Pacientes.Application.Interfaces;
using Pacientes.Domain;
using Pacientes.Persistence.Interfaces;

namespace Pacientes.Application
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacientePersistence PacientePersist;
        public PacienteService(IPacientePersistence PacientePersist)
        {
            this.PacientePersist = PacientePersist;
        }
        public async Task<Paciente> AddPacientes(Paciente model)
        {
            try
            {
                this.PacientePersist.Add<Paciente>(model);
                if (await this.PacientePersist.SaveChangesAsync())
                {
                    return await this.PacientePersist.GetPacienteByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletePacientes(int pacienteId)
        {
            try
            {
                var paciente = await this.PacientePersist.GetPacienteByIdAsync(pacienteId);
                if (paciente == null) throw new Exception("O paciente para delete, não foi encontrado.");
                
                this.PacientePersist.Delete<Paciente>(paciente);
                return await this.PacientePersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Paciente> UpdatePacientes(int pacienteId, Paciente model)
        {
            try
            {
                var paciente = await this.PacientePersist.GetPacienteByIdAsync(pacienteId);
                if (paciente == null) return(null);

                model.Id = paciente.Id;
                
                this.PacientePersist.Update(model);
                if (await this.PacientePersist.SaveChangesAsync())
                {
                    return await this.PacientePersist.GetPacienteByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Paciente[]> GetAllPacientesAsync()
        {
            try
            {
                 var paciente = await this.PacientePersist.GetAllPacientesAsync();
                 if (paciente == null) return null;

                 return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Paciente> GetAllPacientesByIdAsync(int id)
        {
            try
            {
                 var paciente = await this.PacientePersist.GetPacienteByIdAsync(id);
                 if (paciente == null) return null;

                 return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Paciente[]> GetAllPacientesByCPFAsync(string cpf)
        {
            try
            {
                 var paciente = await this.PacientePersist.GetPacientesByCPFAsync(cpf);
                 if (paciente == null) return null;

                 return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Paciente[]> GetAllPacientesByNomeAsync(string nome)
        {
            try
            {
                 var paciente = await this.PacientePersist.GetPacientesByNomeAsync(nome);
                 if (paciente == null) return null;

                 return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}