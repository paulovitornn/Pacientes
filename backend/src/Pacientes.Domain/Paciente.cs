using System;
using System.Collections.Generic;

namespace Pacientes.Domain
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string CNS { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string NomeMae { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int CEP { get; set; }
        public string UF { get; set; }
        public string  Cidade { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }

    }
}