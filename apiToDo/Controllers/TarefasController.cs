using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly Tarefas _tarefas = new Tarefas();

        // GET é o verbo correto para leitura
        // Authorize removido pois não existe autenticação no projeto
        [HttpGet("ListarTarefas")]
        public ActionResult<List<TarefaDTO>> ListarTarefas()
        {
            try
            {
                var lista = _tarefas.ListarTarefas();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "listar as tarefas");
            }
        }

        // Nesse caso a nomeclatura InserirTarefas é só pra organização, porque o verbo POST já define a ação de criar. Vou manter pra seguir o padrão do projeto
        [HttpPost("InserirTarefas")]
        public ActionResult<List<TarefaDTO>> InserirTarefas([FromBody] TarefaDTO request)
        {
            try
            {
                var lista = _tarefas.InserirTarefa(request);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "inserir a tarefa");
            }
        }

        // DELETE é o verbo correto para remoção
        [HttpDelete("DeletarTarefa")]
        public ActionResult<List<TarefaDTO>> DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                var lista = _tarefas.DeletarTarefa(ID_TAREFA);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "deletar a tarefa");
            }
        }

        // Buscar tarefa por ID com parâmetro de rota (id)
        [HttpGet("BuscarTarefaPorId/{id}")]
        public ActionResult<TarefaDTO> BuscarTarefaPorId(int id)
        {
            try
            {
                var tarefa = _tarefas.BuscarTarefaPorId(id);

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "buscar a tarefa");
            }
        }

        // Atualiza a tarefa de acordo com o id.
        [HttpPut("AtualizarTarefa")]
        public ActionResult<List<TarefaDTO>> AtualizarTarefa([FromBody] TarefaDTO request)
        {
            try
            {
                var lista = _tarefas.AtualizarTarefa(request);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "atualizar a tarefa");
            }
        }

        // Método privado para tratar exceções, pois estava repetindo os blocos try catch.
        private ActionResult HandleException(Exception ex, string contexto)
        {
            if (ex is KeyNotFoundException)
                return NotFound(new { msg = ex.Message });

            return StatusCode(500, new { msg = $"Erro ao {contexto}" });
        }
    }
}
