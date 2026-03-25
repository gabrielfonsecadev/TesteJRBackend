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
        [HttpGet]
        public ActionResult<List<TarefaDTO>> lstTarefas()
        {
            try
            {
                var lista = _tarefas.lstTarefas();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { msg = $"Ocorreu um erro ao listar as tarefas: {ex.Message}" });
            }
        }

        //Nesse caso a nomeclatura InserirTarefas é só pra organização, porque o verbo POST já define a ação de criar. Vou manter pra seguir o padrão do projeto.
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
                return StatusCode(500, new { msg = $"Ocorreu um erro ao inserir a tarefa: {ex.Message}" });
            }
        }

        [HttpGet("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {

                return StatusCode(200);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
