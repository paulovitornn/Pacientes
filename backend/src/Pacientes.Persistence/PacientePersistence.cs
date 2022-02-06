using System.Linq;
using System.Threading.Tasks;
using Pacientes.Persistence.Interfaces;
using Pacientes.Persistence.Context;
using Pacientes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Pacientes.Persistence
{
    public class PacientePersistence : IPacientePersistence
    {
        public readonly PacientesContext context;
    
        public PacientePersistence (PacientesContext context){
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync()) > 0;
        }
        public async Task<Paciente[]> GetAllPacientesAsync()
        {
            IQueryable<Paciente> query = this.context.Pacientes;
            query = query.OrderBy(p => p.Nome)
                .Include(t => t.Telefones);

            return await query.ToArrayAsync();
        }

        public async Task<Paciente[]> GetPacientesByCPFAsync(string cpf)
        {
            IQueryable<Paciente> query = this.context.Pacientes;
            query = query.OrderBy(p => p.Nome)
                .Include(t => t.Telefones)
                .Where(p => p.CPF.Contains(cpf));
            return await query.ToArrayAsync();
        }

        public async Task<Paciente[]> GetPacientesByNomeAsync(string nome)
        {
            IQueryable<Paciente> query = this.context.Pacientes;
            query = query.OrderBy(p => p.Nome)
                .Include(t => t.Telefones)
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

         public async Task<Paciente> GetPacienteByIdAsync(int pacienteId)
        {
            IQueryable<Paciente> query = this.context.Pacientes;
            query = query.Where(p => p.Id == pacienteId)
                .Include(t => t.Telefones);
            return await query.FirstOrDefaultAsync();
        }      
    }
}