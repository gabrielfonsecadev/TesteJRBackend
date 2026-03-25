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

        public List<TarefaDTO> lstTarefas()
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
                // Busca a primeira tarefa onde o ID_TAREFA é igual ao valor de ID_TAREFA
                // Se não encontrar nenhuma retorna null
                var tarefa = _listaTarefas.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);

                // Verifica se a tarefa foi encontrada
                // Caso o ID_TAREFA não exista na lista, lança um erro de Key não encontrada
                if (tarefa == null)
                    throw new KeyNotFoundException($"Tarefa com ID {ID_TAREFA} não encontrada.");

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
    }
}
