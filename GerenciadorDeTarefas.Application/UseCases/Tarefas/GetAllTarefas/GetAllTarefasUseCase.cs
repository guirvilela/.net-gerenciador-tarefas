using GerenciadorDeTarefas.Communication.Response;
using GerenciadorDeTarefas.Infrastructure;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.GetAllTarefas;

public class GetAllTarefasUseCase
{

    public ResponseTodasTarefas Execute()
    {
        var dbContext = new GerenciadorTarefasDbContext();

        var tarefas = dbContext.Tarefas.ToList();



        return new ResponseTodasTarefas
        {
            Tarefas = tarefas.Select(tarefa => new ResponseTarefaUnica
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                Descricao = tarefa.Descricao,
                DataLimite = tarefa.DataLimite,
                Prioridade = tarefa.Prioridade,
                Status = tarefa.Status
            }).ToList()
        };
    }
}
