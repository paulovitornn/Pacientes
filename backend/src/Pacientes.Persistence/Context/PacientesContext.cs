using System;
using Microsoft.EntityFrameworkCore;
using Pacientes.Domain;

namespace Pacientes.Persistence.Context
{
    public class PacientesContext  : DbContext
    {
        public PacientesContext( DbContextOptions<PacientesContext> options) 
            : base(options) { }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>()
                .HasOne(t => t.Paciente);
            
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.Telefones)
                .WithOne(p => p.Paciente)
                .OnDelete(DeleteBehavior.Cascade);

            var tel1 = new Telefone {
                                Id = 1,
                                Tipo = "Celular",
                                DDD = 62,
                                Numero = 992929292,
                                PacienteId = 1
                            };
            var tel2 = new Telefone {
                                Id = 2,
                                Tipo = "Celular",
                                DDD = 62,
                                Numero = 991919191,
                                PacienteId = 2
                            };
            
            var pac1 = new Paciente 
                    {
                        Id = 1,
                        Nome = "Paulo Vitor Nunes do Nascimento",
                        CPF = "79341014069",
                        RG = "123456",
                        CNS = "123456",
                        DataNascimento = DateTime.Parse("1989-05-09"),
                        Sexo = "m",
                        NomeMae = "Maria Nunes",
                        Endereco = "Rua Aliança, QD XX LT XX",
                        Bairro = "Maysa 1",
                        CEP = 75380000,
                        UF = "GO",
                        Cidade = "Trindade"
                    };
            var pac2 = new Paciente 
                    {
                        Id = 2,
                        Nome = "Ariane Tabata",
                        CPF = "20202126099",
                        RG = "987654",
                        CNS = "987654",
                        DataNascimento = DateTime.Parse("1989-10-08"),
                        Sexo = "f",
                        NomeMae = "Ana Rita",
                        Endereco = "Rua Aliança, QD XX LT XX",
                        Bairro = "Maysa 1",
                        CEP = 75380000,
                        UF = "GO",
                        Cidade = "Trindade"
                    };

            modelBuilder.Entity<Paciente>()
                .HasData(pac1,pac2);
                
            modelBuilder.Entity<Telefone>()
                .HasData(tel1,tel2);
        }


    }

    


}