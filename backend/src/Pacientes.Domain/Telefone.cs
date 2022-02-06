namespace Pacientes.Domain
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

    }
}