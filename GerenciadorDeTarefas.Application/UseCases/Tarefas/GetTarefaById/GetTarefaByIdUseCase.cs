using System.Net.Http.Headers;
using GerenciadorDeTarefas.Communication.Response;
using GerenciadorDeTarefas.Infrastructure;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.GetTarefaById;

public class GetTarefaByIdUseCase
{


    public ResponseTarefaUnica Execute(Guid id)
    {
        var dbContext = new GerenciadorTarefasDbContext();

        var tarefa = dbContext.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);

        if (tarefa is null)
        {
            throw new Exception("Não encontrou tarefa com esse id");
        }

        return new ResponseTarefaUnica
        {
            Id = id,
            Nome = tarefa.Nome,
            Descricao = tarefa.Descricao,
            DataLimite = tarefa.DataLimite,
            Prioridade = tarefa.Prioridade,
            Status = tarefa.Status
        };

    }
}
