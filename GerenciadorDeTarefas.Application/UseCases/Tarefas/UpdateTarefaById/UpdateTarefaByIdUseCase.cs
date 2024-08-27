using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Communication.Response;
using GerenciadorDeTarefas.Infrastructure;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefas.UpdateTarefaById;

public class UpdateTarefaByIdUseCase
{

    public Guid Execute(Guid id, RequestTarefa request)
    {

        var dbContext = new GerenciadorTarefasDbContext();

       var tarefa = dbContext.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);

        if(tarefa is null)
        {
            throw new Exception("Não encontrado com esse id");
        }

        tarefa.Nome = request.Nome;
        tarefa.Descricao = request.Descricao;
        tarefa.DataLimite = request.DataLimite;
        tarefa.Prioridade = request.Prioridade;
        tarefa.Status = request.Status;

        dbContext.Update(tarefa);

        dbContext.SaveChanges();

        return id;

    }
}
