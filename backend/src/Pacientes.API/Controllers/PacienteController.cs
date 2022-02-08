using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pacientes.Application.Interfaces;
using Pacientes.Domain;
using System.Text.Json;


namespace Pacientes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            this.pacienteService = pacienteService;
        }

        [HttpPost("novoPaciente")]
         public async Task<IActionResult> AddPeople(Paciente paciente)
        {
            try
            {
                var p = await this.pacienteService.AddPacientes(paciente);
                if (p == null) return BadRequest("Erro ao tentar adicionar um novo cadastro");

                return Ok(p);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro desconhecido ao tentar adicionar uma novo paciente. Erro:{ex.Message}");
            }
        }

        [HttpPut("atualizarCadastroPaciente/{idPaciente}")]
         public async Task<IActionResult> Put(int idPaciente, Paciente model)
        {
            try
            {
                var paciente = await pacienteService.UpdatePacientes(idPaciente, model);
                if (paciente == null) return NotFound("Não foi possivel atualizar o cadastro.");

                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro desconhecido ao tentar atualizar cadastro. Erro:{ex.Message}");
            }
        }

        [HttpDelete("excluirCadastro/{idPaciente}")]
         public async Task<IActionResult> Delete(int idPaciente)
        {
            try
            {
                return await pacienteService.DeletePacientes(idPaciente) ?
                    Ok(JsonSerializer.Serialize("Cadastro excluido com sucesso."))
                        : BadRequest("Não foi encontrado o cadastro a ser excluido.");  
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar eventos. Erro:{ex.Message}");
            }
        }

        [HttpGet("getAllPacientes")]
        public async Task<IActionResult> GetAllPacientesAsync()
        {
             try
            {
                var pacientes = await this.pacienteService.GetAllPacientesAsync();
                if (pacientes == null) return NotFound("Nenhum Paciente foi encontrado.");

                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar dados. Erro:{ex.Message}");
            }
        }

        [HttpGet("getPacienteById/{idPaciente}")]
        public async Task<IActionResult> GetPacienteByIdAsync(int idPaciente)
        {
             try
            {
                var pacientes = await this.pacienteService.GetAllPacientesByIdAsync(idPaciente);
                if (pacientes == null) return NotFound("Paciente foi encontrado.");

                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar dados. Erro:{ex.Message}");
            }
        }

        [HttpGet("getPacientesByNome/{nomePaciente}")]
        public async Task<IActionResult> GetPacienteByNomeAsync(string nomePaciente)
        {
             try
            {
                var pacientes = await this.pacienteService.GetAllPacientesByNomeAsync(nomePaciente);
                if (pacientes == null) return NotFound("Paciente foi encontrado.");

                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar dados. Erro:{ex.Message}");
            }
        }

        [HttpGet("getPacientesByCPF/{cpfPaciente}")]
        public async Task<IActionResult> GetPacienteByCpfAsync(string cpfPaciente)
        {
             try
            {
                var pacientes = await this.pacienteService.GetAllPacientesByCPFAsync(cpfPaciente);
                if (pacientes == null) return NotFound("Paciente foi encontrado.");

                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar dados. Erro:{ex.Message}");
            }
        }

    }
}
