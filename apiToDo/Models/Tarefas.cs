using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        // Lista estática para simular persistência em memória durante a execução da aplicação.
        // Como não há banco de dados, o estado é mantido enquanto o servidor estiver rodando.
        private static List<TarefaDTO> _listaTarefas = new List<TarefaDTO>
        {
            new TarefaDTO { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
            new TarefaDTO { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade Faculdade" },
            new TarefaDTO { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
        };

        public List<TarefaDTO> ListarTarefas()
        {
            try
            {
                return _listaTarefas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TarefaDTO> InserirTarefa(TarefaDTO request)
        {
            try
            {
                _listaTarefas.Add(request);
                return _listaTarefas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TarefaDTO> DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                // Chama método privado pra retornar a tarefa se ela existir
                var tarefa = RetornaTarefaOuExcecao(ID_TAREFA);

                // Remove o objeto encontrado caso exista
                _listaTarefas.Remove(tarefa);

                // Retorna a lista atualizada após a remoção
                return _listaTarefas;
            }
            catch (Exception ex)
            {
                // Relança a exceção pra ser tratada pelo Controller, que decide o status HTTP
                throw ex;
            }
        }

        public TarefaDTO BuscarTarefaPorId(int id)
        {
            try
            {
                var tarefa = RetornaTarefaOuExcecao(id);

                return tarefa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TarefaDTO> AtualizarTarefa(TarefaDTO request)
        {
            try
            {
                var tarefa = RetornaTarefaOuExcecao(request.ID_TAREFA);

                // Atualiza apenas o campo DS_TAREFA com o valor enviado no request
                tarefa.DS_TAREFA = request.DS_TAREFA;

                return _listaTarefas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Por utilizar a mesma lógica em vários lugares, criei um método privado pra verificar se a tarefa existe
        private TarefaDTO RetornaTarefaOuExcecao(int id)
        {
            // Busca a primeira tarefa onde o ID_TAREFA é igual ao valor de ID_TAREFA
            // Se não encontrar nenhuma retorna null
            var tarefa = _listaTarefas.FirstOrDefault(x => x.ID_TAREFA == id);

            // Verifica se a tarefa foi encontrada
            // Caso o ID_TAREFA não exista na lista, lança um erro de Key não encontrada
            if (tarefa == null)
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");

            return tarefa;
        }
    }
}
