
using System.Threading.Tasks;
using Pacientes.Domain;

namespace Pacientes.Persistence.Interfaces
{
    public interface IPacientePersistence
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();
        Task<Paciente[]> GetAllPacientesAsync();
        Task<Paciente[]> GetPacientesByNomeAsync(string nome);
        Task<Paciente[]> GetPacientesByCPFAsync(string cpf);
        Task<Paciente> GetPacienteByIdAsync(int id);
    }
}